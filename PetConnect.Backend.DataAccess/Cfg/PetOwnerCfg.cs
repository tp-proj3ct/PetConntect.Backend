using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core.Users;

namespace PetConnect.Backend.DataAccess.Cfg;

internal class PetOwnerCfg : IEntityTypeConfiguration<PetOwner>
{
    public void Configure(EntityTypeBuilder<PetOwner> builder)
    {
        builder.HasMany(pop => pop.Pets)
            .WithOne(p => p.PetOwner)
            .HasForeignKey(p => p.PetOwnerId);

        builder.HasMany(psp => psp.Reviews)
            .WithOne(r => r.Reviewer)
            .HasForeignKey(r => r.ReviewerId);
    }
}
