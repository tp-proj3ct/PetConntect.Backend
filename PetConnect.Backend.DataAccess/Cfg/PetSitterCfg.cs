using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core.Users;

namespace PetConnect.Backend.DataAccess.Cfg;

internal class PetSitterCfg : IEntityTypeConfiguration<PetSitter>
{
    public void Configure(EntityTypeBuilder<PetSitter> builder)
    {
        builder.Property(psp => psp.Description)
            .HasMaxLength(2048);

        builder.Property(psp => psp.Rating)
            .IsRequired() 
            .HasDefaultValue(0);

        builder.Property(psp => psp.ExperienceYears)
            .IsRequired()
            .HasDefaultValue(0);

        builder.HasMany(psp => psp.Services)
            .WithOne(s => s.PetSitter)
            .HasForeignKey(s => s.PetSitterId);

        builder.HasMany(psp => psp.Reviews)
            .WithOne(r => r.Target)
            .HasForeignKey(r => r.TargetId);
    }
}