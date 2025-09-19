using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DataSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            // Seed Role
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var adminRole = new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),      
                    Name = "Admin",
                    NormalizedName = "ADMIN"              
                };
                await roleManager.CreateAsync(adminRole);
            }

            // Seed User
            var defaultUser = await userManager.FindByEmailAsync("Safa@gmail.com");
            if (defaultUser == null)
            {
                defaultUser = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),  

                    UserName = "Safa",
                    Email = "Safa@gmail.com",
                    EmailConfirmed = true,
                    FullName= "safa"
                };

                await userManager.CreateAsync(defaultUser, "Safa@123");
                await userManager.AddToRoleAsync(defaultUser, "Admin");
            }
        }
    }
}
