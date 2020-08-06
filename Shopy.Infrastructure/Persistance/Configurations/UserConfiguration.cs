using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopy.Domain.Entitties;

namespace Shopy.Infrastructure.Persistance.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.OwnsOne(model => model.Email, email =>
            {
                email.Property(model => model.Value).HasColumnName("Email");
            });

            builder.OwnsOne(model => model.Person, person =>
            {
                person.Property(model => model.FirstName).HasColumnName("FirstName");
                person.Property(model => model.LastName).HasColumnName("LastName");
                person.Property(model => model.MiddleName).HasColumnName("MiddleName");
            });

            builder
                .HasOne(model => model.Credentials)
                .WithOne(model => model.User)
                .HasForeignKey<User>("UserCredentialsId");
        }
    }
}
