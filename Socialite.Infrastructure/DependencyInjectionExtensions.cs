using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Socialite.Application.Services.Auth;
using Socialite.Domain.Abstract.Identity;
using Socialite.Infrastructure.Data;
using Socialite.Infrastructure.Identity;
using Socialite.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Infrastructure
{
    public static class DependencyInjectionExtensions
    {

        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
        {
            
            services.AddDbContext<ApplicationIdentityDbContext>()
            .AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationIdentityDbContext>();

            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<ITokenService,TokenService>();

            services.AddCustomIdentity();

            return services;
        }

        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;



                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                /* Bunlar real layihede true olur test meqsedi ile false etmisem
                 * 
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                 */

                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // Default User settings.
                options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            return services;
        }
    }
}
