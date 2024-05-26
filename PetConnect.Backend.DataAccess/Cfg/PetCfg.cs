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

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Age)
            .IsRequired();

        builder.Property(p => p.Weight)
            .IsRequired();

        builder.Property(p => p.Gender)
            .IsRequired();

        builder.Property(p => p.Behavior)
            .HasMaxLength(512);

        builder.Property(p => p.Type)
            .IsRequired()
            .HasMaxLength(32);

        builder.Property(p => p.Breed)
            .HasMaxLength(64);

        builder.Property(p => p.Description)
            .HasMaxLength(1024);

        builder.Property(p => p.MedicalInfo)
            .HasMaxLength(512);

        builder.HasOne(p => p.UserProfile)
            .WithMany(up => up.Pets)
            .HasForeignKey(p => p.UserProfileId);

        builder.Property(p => p.Images)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<byte[]>>(v, (JsonSerializerOptions)null)
            );
    }
}
