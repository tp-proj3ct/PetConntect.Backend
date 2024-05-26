using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.DataAccess.Cfg;

internal class UserProfileCfg : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> builder)
    {
        builder.HasKey(up => up.Id);

        builder.Property(up => up.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(up => up.Surname)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(up => up.ProfilePic)
            .HasColumnType("varbinary(max)");

        builder.HasOne(up => up.User)
            .WithOne(u => u.Profile)
            .HasForeignKey<User>(u => u.UserProfileId);

        builder.ToTable("UserProfiles");
    }
}