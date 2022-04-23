using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestGoalSystems.Identity.Configurations;
using TestGoalSystems.Identity.Models;

namespace TestGoalSystems.Identity
{
    public class InventoryIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public InventoryIdentityDbContext(DbContextOptions<InventoryIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
