using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Via.Web.Models;

namespace Via.Web.Data
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
            builder.Entity<IdentityRole>().HasKey("Id");
            builder.Entity<IdentityRole>().HasIndex(x => x.NormalizedName).HasName("RoleNameIndex");
            builder.Entity<IdentityRole>().ToTable("Roles");

            builder.Entity<IdentityRoleClaim<string>>().HasKey("Id");
            builder.Entity<IdentityRoleClaim<string>>().HasIndex(x => x.RoleId);
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

            builder.Entity<IdentityUserClaim<string>>().HasKey("Id");
            builder.Entity<IdentityUserClaim<string>>().HasIndex(x => x.UserId);
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");

            builder.Entity<IdentityUserLogin<string>>().HasKey("LoginProvider", "ProviderKey");
            builder.Entity<IdentityUserLogin<string>>().HasIndex(x => x.UserId);
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");

            builder.Entity<IdentityUserRole<string>>().HasKey("UserId", "RoleId");
            builder.Entity<IdentityUserRole<string>>().HasIndex(x => x.RoleId);
            builder.Entity<IdentityUserRole<string>>().HasIndex(x => x.UserId);
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");

            builder.Entity<IdentityUserToken<string>>().HasKey("UserId", "LoginProvider", "Name");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            builder.Entity<ApplicationUser>().HasKey("Id");
            builder.Entity<ApplicationUser>().HasIndex(x => x.NormalizedEmail).HasName("EmailIndex");
            builder.Entity<ApplicationUser>().HasIndex(x => x.NormalizedUserName).IsUnique().HasName("UserNameIndex");
            builder.Entity<ApplicationUser>().ToTable("Users");
        }
    }
}
