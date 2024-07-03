﻿using Application.Enums;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Seeds
{
    public static class DefaultAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default Admin User
            var defaultUser = new ApplicationUser
            {
                UserName = "userAdmin",
                Email = "userAdmin@gmail.com",
                Nombre = "Diego",
                Apellido = "Alvira",
                PhoneNumberConfirmed = true,
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Contra$eña");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    //await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }
            }
            
        }
    }
}
