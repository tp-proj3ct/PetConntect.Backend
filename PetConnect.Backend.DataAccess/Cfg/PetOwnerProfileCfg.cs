using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.DataAccess.Cfg;

internal class PetOwnerProfileCfg : IEntityTypeConfiguration<PetOwnerProfile>
{
    public void Configure(EntityTypeBuilder<PetOwnerProfile> builder)
    {
        builder.HasKey(pop => pop.Id);

        builder.HasOne(pop => pop.UserProfile)
            .WithOne()
            .HasForeignKey<PetOwnerProfile>(pop => pop.UserProfileId);

        builder.HasMany(pop => pop.Pets)
            .WithOne(p => p.PetOwnerProfile)
            .HasForeignKey(p => p.PetOwnerProfileId);
    }
}
