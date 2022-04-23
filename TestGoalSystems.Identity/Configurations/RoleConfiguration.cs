using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestGoalSystems.Identity.Models;

namespace TestGoalSystems.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                    new IdentityRole
                    {
                        Id = "8629b2f6-5601-4bc7-bc60-6e598cb1da7c",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR"
                    },
                   new IdentityRole
                   {
                       Id = "44348ab3-aec3-46ef-95d6-48c76656e0d9",
                       Name = "Operator",
                       NormalizedName = "OPERATOR"
                   }
                );
        }
    }
}
