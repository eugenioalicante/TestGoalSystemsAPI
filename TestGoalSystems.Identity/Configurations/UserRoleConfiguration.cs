using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestGoalSystems.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "8629b2f6-5601-4bc7-bc60-6e598cb1da7c",
                    UserId = "462d5cc0-3ff8-4e1f-a8c0-5105bce99b6e"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "44348ab3-aec3-46ef-95d6-48c76656e0d9",
                    UserId = "b0a52ab6-e5ba-4def-ba8b-0aaa1a38c3ee"
                }
            );
        }
    }
}
