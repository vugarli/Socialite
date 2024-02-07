using Microsoft.Extensions.DependencyInjection;
using Socialite.Application.Services.Auth;
using Socialite.Application.Services.Auth.Validators;
using Socialite.Application.Services.Posts;
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
            

            services.AddScoped<IAuthValidator, AuthValidator>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }


    }
}
