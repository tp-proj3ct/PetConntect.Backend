using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.DataAccess.Cfg;

internal class UserCfg : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Password)
            .IsRequired();

        builder.Property(u => u.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(u => u.Role)
            .IsRequired();

        builder.HasOne(u => u.Profile)
            .WithOne()
            .HasForeignKey<User>(u => u.Profile.Id);
    }
}