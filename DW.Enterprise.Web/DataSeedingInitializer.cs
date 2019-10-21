using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DW.Enterprise.Web
{
    public static class DataSeedingInitializer
    {
        public async static Task UserAndRoleSeedAsync(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Aqui creamos los roles de la Aplicacion
            string[] roles = { "Admin", "Manager", "Teacher", "Staff" };
            foreach (var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    IdentityResult result = await roleManager.CreateAsync(
                        new IdentityRole(role)
                        );
                }
            }

            // Vamos a crear un usuario de la aplicacion
            if (userManager.FindByEmailAsync("ralvaradot@outlook.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    Email = "ralvaradot@outlook.com",
                    UserName = "ralvaradot@outlook.com"
                };
                IdentityResult identityResult = await userManager.CreateAsync(
                    user, "Password1!"
                    );

                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByEmailAsync("manager@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    Email = "manager@gmail.com",
                    UserName = "manager@gmail.com"
                };
                IdentityResult identityResult = await userManager.CreateAsync(
                    user, "Password1!"
                    );

                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Manager").Wait();
                }
            }

            if (userManager.FindByEmailAsync("teacher@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    Email = "teacher@gmail.com",
                    UserName = "teacher@gmail.com"
                };
                IdentityResult identityResult = await userManager.CreateAsync(
                    user, "Password1!"
                    );

                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Teacher").Wait();
                }
            }

            if (userManager.FindByEmailAsync("staff@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    Email = "staff@gmail.com",
                    UserName = "staff@gmail.com"
                };
                IdentityResult identityResult = await userManager.CreateAsync(
                    user, "Password1!"
                    );

                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Staff").Wait();
                }
            }

            if (userManager.FindByEmailAsync("pepitoperez@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser()
                {
                    Email = "pepitoperez@gmail.com",
                    UserName = "pepitoperez@gmail.com"
                };
                IdentityResult identityResult = await userManager.CreateAsync(
                    user, "Password1!"
                    );

            }

        }
    }
}
