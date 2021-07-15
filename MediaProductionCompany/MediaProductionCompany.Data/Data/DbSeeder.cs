using MediaProductionCompany.Data.DbEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaProductionCompany.Data.Data
{
    public static class DbSeeder
    {

        public static IHost SeedDb(this IHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                try
                {
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    roleManager.InitRoles().Wait();
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserDbEntity>>();
                    userManager.SeedUser().Wait();


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            return webHost;
        }

        public static async Task InitRoles(this RoleManager<IdentityRole> roleManager)
        {
            var rolesName = new List<string>();
            rolesName.Add("Admin");
            rolesName.Add("Employee");
            foreach (var role in rolesName)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
        public static async Task SeedUser(this UserManager<UserDbEntity> userManager)
        {
            if (await userManager.Users.AnyAsync())
            {
                return;
            }
            var user = new UserDbEntity
            {
                Email = "Admin@Admin.com",
                FullName = "Admin",
                UserName = "fAdmin@Admin.com",
                CountryId = 1,
                PhoneNumber = "0595167570000",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(user, "Admin11$$");
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
