﻿using HybridModelBinding;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using Socialite.Api.CustomAttribute;
using Socialite.Application.Exceptions;
using Socialite.Application.Filters;
using Socialite.Application.Queries;
using Socialite.Application.Requests.Post;
using Socialite.Application.Services.Posts;
using Socialite.Domain.Entities;
using Socialite.Domain.Entities.PostAggregate;

namespace Socialite.Api.Controllers
{

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : RESTFulController
    {
        public IPostService _postService { get; }
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet()]
        public async Task<IQueryResult> GetCurrentUserPostsAsync(
            [FromQuery] PaginationFilter<Post> paginationFilter)
        {
            return await _postService.GetCurrentUserPostsAsync(paginationFilter);
        }

        [HttpPost()]
        public async Task<IActionResult> PostPostAsync(
            [FromBody] PostPostRequest postPostRequest)
        {
            try
            {
                await _postService.PostPostsAsync(postPostRequest);
                return Ok();
            }
            catch (PostValidationException ex)
                when (ex.InnerException is PostNotFoundException)
            {
                return NotFound(ex);
            }
            catch (PostValidationException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception)
            { 
                return InternalServerError("Something bad happened");
            }
        }

        [HttpGet("{postId}/impressions")]
        public async Task<IActionResult> GetPostImpressionsAsync(int postId)
        {
            try
            {
                return Ok(await _postService.GetPostImpressionsAsync(postId));
            }
            catch (PostValidationException ex)
                when (ex.InnerException is PostNotFoundException)
            {
                return NotFound(ex.InnerException);
            }
        }

        [HttpPut("{PostId}/impressions/{ImpressionType}")]
        public async Task<IActionResult> PutPostImpressionsAsync(
             [FromRoute] PutImpressionRequest impressionRequest)
        {
            try
            {
                await _postService.PutPostImpressionsAsync(impressionRequest.PostId,impressionRequest);
                return Ok();
            }
            catch (PostValidationException ex)
                when(ex.InnerException is PostNotFoundException)
            {
                return NotFound(ex.InnerException);
            }
            catch (ImpressionValidationException ex)
            {
                return BadRequest(ex);
            }
            catch(Exception) 
            {
                return InternalServerError("Something bad happened");
            }
        }


        [HttpGet("{postId}/comments")]
        public async Task<IActionResult> GetPostCommentsAsync(
            int postId,
            [FromQuery] PaginationFilter<PostComment> paginationFilter)
        {
            try
            {
                return Ok(await _postService.GetPostCommentsAsync(postId));
            }
            catch (PostValidationException ex)
                when (ex.InnerException is PostNotFoundException)
            {
                return NotFound(ex.InnerException);
            }
            catch (Exception)
            {
                return InternalServerError("Something bad happened");
            }
        }

        [HttpPost("{postId}/comments")]
        public async Task<IActionResult> CommentToPostAsync(
            [FromHybrid] PostCommentRequest postCommentRequest)
        {
            try
            {
                await _postService.PostPostCommentsAsync(postCommentRequest);
                return Ok();
            }
            catch (PostValidationException ex)
                when (ex.InnerException is PostNotFoundException)
            {
                return NotFound(ex.InnerException);
            }
            catch (CommentValidationException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception)
            {
                return InternalServerError("Something bad happened");
            }
        }
    }
}
