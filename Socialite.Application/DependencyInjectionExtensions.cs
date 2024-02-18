using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using Socialite.Application.Services.Auth;
using Socialite.Application.Services.Auth.Validators;
using Socialite.Application.Services.File;
using Socialite.Application.Services.Posts;
using Socialite.Application.Services.Posts.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Infrastructure
{
    public static class DependencyInjectionExtensions
    {

        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostValidator, PostValidator>();

            services.AddScoped<ICommentValidator, CommentValidator>();
            
            services.AddScoped<IImpressionValidator, ImpressionValidator>();
            services.AddSingleton<IPresignedUploadUrlGeneratorService, PresignedUploadUrlGeneratorService>();


            services.AddSingleton<IMinioClient>(c =>
            {

                var config = c.GetRequiredService<IConfiguration>();
                var endpoint = config.GetSection("MINIO").GetValue<string>("Endpoint");
                var accessKey = config.GetSection("MINIO").GetValue<string>("AccessKey");
                var secretKey = config.GetSection("MINIO").GetValue<string>("SecretKey");

                var minio = new MinioClient()
                    .WithEndpoint(endpoint)
                    .WithCredentials(accessKey, secretKey)
                    .WithSSL()
                    .Build();

                return minio;
            });

            services.AddScoped<IAuthValidator, AuthValidator>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }


    }
}
