using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.DataAccess.Cfg;

internal class PetSitterProfileCfg : IEntityTypeConfiguration<PetSitterProfile>
{
    public void Configure(EntityTypeBuilder<PetSitterProfile> builder)
    {
        builder.HasKey(psp => psp.Id);

        builder.Property(psp => psp.Description)
            .HasMaxLength(2048);

        builder.Property(psp => psp.Rating)
            .IsRequired() 
            .HasDefaultValue(0);

        builder.Property(psp => psp.ExperienceYears)
            .IsRequired()
            .HasDefaultValue(0);

        builder.HasOne(psp => psp.UserProfile)
            .WithOne()
            .HasForeignKey<PetSitterProfile>(psp => psp.UserProfileId);

        builder.HasMany(psp => psp.Services)
            .WithOne(s => s.PetSitterProfile)
            .HasForeignKey(s => s.PetSitterProfileId);

        builder.HasMany(psp => psp.Reviews)
            .WithOne(r => r.Target)
            .HasForeignKey(r => r.TargetId);
    }
}