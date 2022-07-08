using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RepairItBack.Data
{
    public class Seed
    {
        public static async  Task SeedRoles(RoleManager<AppRole> roleManager){


            if(await roleManager.Roles.AnyAsync()) return;
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
    }
}