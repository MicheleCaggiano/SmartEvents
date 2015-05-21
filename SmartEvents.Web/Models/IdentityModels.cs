using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartEvents.Web.Models.Identity;

namespace SmartEvents.Web.Models
{
    // Custom Aspnet Identity implemented: for more info http://www.asp.net/identity/overview/extensibility/change-primary-key-for-users-in-aspnet-identity

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<Guid, UserLogin, UserRole, UserClaim>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, Guid> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, Guid, UserLogin, UserRole, UserClaim>
    {
        public ApplicationDbContext()
            : base("BondSystemContainer")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserLogin>().ToTable("User").Property(p => p.UserId).HasColumnName("UserId");
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<UserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<Role>().ToTable("Role");
        }
    }

    public static class IdentityExtensions
    {
        // Identity GetUserId<T>() extension method
        public static T GetUserIdGeneric<T>(this IIdentity identity)
        {
            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(identity.GetUserId());
        }
    }
}