using Microsoft.AspNetCore.Identity;
using System.Data;

namespace MyFleetManAPI.API.Extensions
{
    public static class AdminSeeder
    {
        public static async Task SeedAdminUserAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var userName = "kairee";
            var email = "dipak.satpute@zingworks.co";
            var user = await userManager.FindByEmailAsync(userName);

            if (user == null)
            {
                user = new IdentityUser
                {
                    Email = email,
                    UserName = userName,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, "Admin@123");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
