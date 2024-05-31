using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using PetConnect.Backend.Core;

namespace PetConnect.Backend.DataAccess.Cfg;

internal class PetCfg : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.PetOwner)
                   .WithMany(po => po.Pets)
                   .HasForeignKey(p => p.PetOwnerId)
                   .IsRequired();

        builder.Property(p => p.Images)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<byte[]>>(v, (JsonSerializerOptions)null)
            );
    }
}
