using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using UserManagementMVCExample.Models;
using UserManagementMVCExample.Models.ViewModels;

namespace UserManagementMVCExample.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            builder.Entity<SushiAssignmentViewModel>()
                .HasKey(s => new { s.SushiID, s.ComboID });

            builder.Entity<SushiAssignmentViewModel>()
                            .HasOne(s => s.Sushi)
                            .WithMany(c => c.SushiAssignments)
                            .HasForeignKey(c => c.SushiID)
                            .OnDelete(DeleteBehavior.NoAction);
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Sushi> Sushis { get; set; }
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Dessert> Desserts { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<SushiAssignmentViewModel> SushiAssignments { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
