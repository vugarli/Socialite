using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using RESTFulSense.Controllers;
using Socialite.Application.Filters;
using Socialite.Application.Queries;

namespace Socialite.Api.ActionFilters
{
    public class PaginationActionFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is OkObjectResult okResult)
            {
                if (okResult.Value is IPaginatedResult paginatedResult)
                {
                    var request = context.HttpContext.Request;
                    UrlHelperFactory factory = new UrlHelperFactory();
                    var urlhelper = factory.GetUrlHelper(context);
                    
                    var controller = context.Controller as RESTFulController;

                    var parameterDescriptor = context
                        .ActionDescriptor
                        .Parameters
                        .FirstOrDefault(t =>
                        t.ParameterType.GetInterfaces().Contains(typeof(IPaginationFilter)));

                    if (parameterDescriptor != null)
                    { 
                    
                        IPaginationFilter paginationFilter = Activator.CreateInstance(parameterDescriptor.ParameterType) as IPaginationFilter;

                        await controller.TryUpdateModelAsync(paginationFilter, parameterDescriptor.ParameterType, "");


                        var queryStr = context
                            .HttpContext
                            .Request.QueryString
                            .Value;

                        var queryValues = QueryHelpers.ParseQuery(queryStr);

                        var baseUrl = context.HttpContext.Request.Path;

                        if (paginatedResult.HasNext)
                        {
                            queryValues
                                .TryGetValue(
                                nameof(paginationFilter.page),
                                out StringValues page);

                            var pageInt = Convert.ToInt32(page);

                            var updatedQuery = QueryHelpers.ParseQuery(queryStr);

                            updatedQuery[nameof(paginationFilter.page)] = (pageInt + 1).ToString();

                            var nextUrl = QueryHelpers.AddQueryString(baseUrl,updatedQuery);

                            paginatedResult.Next = nextUrl;
                        }
                        if (paginatedResult.HasPrev)
                        {
                            queryValues
                                .TryGetValue(
                                nameof(paginationFilter.page),
                                out StringValues page);

                            var pageInt = Convert.ToInt32(page);

                            var updatedQuery = QueryHelpers.ParseQuery(queryStr);

                            updatedQuery[nameof(paginationFilter.page)] = (pageInt - 1).ToString();

                            var prevUrl = QueryHelpers.AddQueryString(baseUrl, updatedQuery);

                            paginatedResult.Previous = prevUrl;
                        }
                        

                    }
                    
                }
            }
            await next();
        }
    }
}
