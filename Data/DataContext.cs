using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepairItBack.Entities;

namespace RepairItBack.Data
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Commande> Commandes {get;set;}

          protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
              builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
            builder.Entity<Commande>()
                .HasOne(u => u.Client)
                .WithMany(m => m.CommandeClient)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Commande>()
                .HasOne(u => u.Reparateur)
                .WithMany(m => m.CommandeReparateur)
                .OnDelete(DeleteBehavior.SetNull);
            
        }
    }
}
