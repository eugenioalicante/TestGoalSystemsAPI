using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestGoalSystems.Identity.Models;

namespace TestGoalSystems.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                    new ApplicationUser
                    {
                        Id = "462d5cc0-3ff8-4e1f-a8c0-5105bce99b6e",
                        Email = "eugenio.malfeito@gmail.com",
                        NormalizedEmail = "eugenio.malfeito@gmail.com",
                        Name = "Eugenio",
                        Surname = "Malfeito",
                        UserName = "emalfeito",
                        NormalizedUserName = "emalfeito",
                        PasswordHash = hasher.HashPassword(null, "euge5656$"),
                        EmailConfirmed = true
                    },
                    new ApplicationUser
                    {
                        Id = "b0a52ab6-e5ba-4def-ba8b-0aaa1a38c3ee",
                        Email = "eugenio.empleo@gmail.com",
                        NormalizedEmail = "eugenio.empleo@gmail.com",
                        Name = "Eugenio",
                        Surname = "Malfeito",
                        UserName = "emalfeitoempleo",
                        NormalizedUserName = "emalfeitoempleo",
                        PasswordHash = hasher.HashPassword(null, "euge5656$"),
                        EmailConfirmed = true
                    }
                );
        }
    }
}
