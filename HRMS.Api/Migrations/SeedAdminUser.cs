using HRMS.Api.Data.Database;
using HRMS.Api.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HRMS.Api.Migrations
{
    public class SeedAdminUser
    {
        public static async Task Initializer(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<AppDbContex>();
            string[] roles = new string[] {  "Administrator" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<HrmsRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                  await  roleStore.CreateAsync(new HrmsRole() { Name = role, NormalizedName = role});
                }
            }


            var user = new HrmsUser
            {
                FirstName = "Anand",
                LastName = "Shukla",
                Email = "anand@gmail.com",
                NormalizedEmail = "anand@gmail.com",
                UserName = "Administrator",
                NormalizedUserName = "ADMINISTRATOR",
                PhoneNumber = "111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<HrmsUser>();
                var hashed = password.HashPassword(user, "Administrator");
                user.PasswordHash = hashed;

                var userStore = new UserStore<HrmsUser>(context);
                var result = await userStore.CreateAsync(user);

               await AssignRoles(serviceProvider, user.Email, roles);
               await context.SaveChangesAsync();

            }

        }


        public static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<HrmsUser> _userManager = services.GetService<UserManager<HrmsUser>>();
            HrmsUser user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return null;

            var result = await _userManager.AddToRolesAsync(user, roles);
            return result;
        }
    }
}
