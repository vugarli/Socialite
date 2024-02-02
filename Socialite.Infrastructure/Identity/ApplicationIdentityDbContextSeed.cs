using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socialite.Infrastructure.Identity
{
    public static class ApplicationIdentityDbContextSeed
    {
        public static async Task SeedAsync(ApplicationIdentityDbContext identityDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {

            if (identityDbContext.Database.IsSqlServer())
            {
                identityDbContext.Database.Migrate();
            }

            await roleManager.CreateAsync(new IdentityRole(AppConstants.Roles.MEMBERROLE));
            await roleManager.CreateAsync(new IdentityRole(AppConstants.Roles.SUPERADMINROLE));

            var defaultUser = new ApplicationUser { UserName = AppConstants.REG_USERNAME, Email = AppConstants.REG_USERNAME };
            await userManager.CreateAsync(defaultUser, AppConstants.REG_PASSWORD);
            


            var adminUser = new ApplicationUser { UserName = AppConstants.SUPERADMIN_USERNAME, Email = AppConstants.SUPERADMIN_USERNAME };
            
            await userManager.CreateAsync(adminUser, AppConstants.SUPERADMIN_PASSWORD);
            
            adminUser = await userManager.FindByNameAsync(AppConstants.SUPERADMIN_USERNAME);

            if (adminUser != null)
            {
                await userManager.AddToRoleAsync(adminUser, AppConstants.Roles.SUPERADMINROLE);
            }
        }
    }
}
