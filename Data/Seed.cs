using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepairItBack.Entities;

namespace RepairItBack.Data
{
    public class Seed
    {
        public static async  Task SeedRoles(RoleManager<AppRole> roleManager,UserManager<AppUser> userManager){

            if (await userManager.Users.AnyAsync()) return;
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            if (users == null) return;

            if(!await roleManager.Roles.AnyAsync()){

                var roles = new List<AppRole>
                {
                    new AppRole{Name = "Guest"},
                    new AppRole{Name = "Admin"},
                    new AppRole{Name = "Reparateur"},
                };
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }
            }

            foreach(var user in users){
                user.Verifed=true;
                await userManager.CreateAsync(user,"123456789aA");
                await userManager.AddToRoleAsync(user,"Reparateur");
            }
            var admin = new AppUser{
                Email = "Admin@gmail.com"
            };
            await userManager.CreateAsync(admin,"123456789aA");
            await userManager.AddToRoleAsync(admin,"Admin");
        }
    }
}