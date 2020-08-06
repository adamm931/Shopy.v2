using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopy.Domain.Entitties;

namespace Shopy.Infrastructure.Persistance.Configurations
{
    public class UserCredentialConfiguration : EntityTypeConfiguration<UserCredentials>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<UserCredentials> builder)
        {
            builder.OwnsOne(model => model.Password, password =>
            {
                password.Property(model => model.Hash).HasColumnName("PasswordHash");
                password.Property(model => model.Salt).HasColumnName("PasswordSalt");
            });

            builder.OwnsOne(model => model.Username, username =>
            {
                username.Property(model => model.Value).HasColumnName("Username");
            });

            builder
                .HasOne(model => model.User)
                .WithOne(model => model.Credentials)
                .HasForeignKey<UserCredentials>("UserId");
        }
    }
}
