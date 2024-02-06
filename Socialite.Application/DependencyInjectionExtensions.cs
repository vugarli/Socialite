﻿using Microsoft.Extensions.DependencyInjection;
using Socialite.Application.Services.Auth;
using Socialite.Application.Services.Auth.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Infrastructure
{
    public static class DependencyInjectionExtensions
    {

        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthValidator, AuthValidator>();


            return services;
        }


    }
}
