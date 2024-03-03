using LabAppointmentSystem.API.Models;
using Microsoft.AspNetCore.Identity;

namespace LabAppointmentSystem.API.Services.Classes
{
    public static class IdentityInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            var adminUser = await userManager.FindByEmailAsync("admin.user@gmail.com");
            if (adminUser == null)
            {
                var newAdminUser = new User
                {
                    UserName = "admin.user@gmail.com",
                    Email = "admin.user@gmail.com",
                    Gender = "Male"
                };

                var result = await userManager.CreateAsync(newAdminUser, "Admin@123");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(newAdminUser, "Admin");
                }
            }
        }
    }
}
