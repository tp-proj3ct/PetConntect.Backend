using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.DataAccess.Cfg;

internal class ReviewCfg : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Rating)
            .HasPrecision(3, 2) // Предположим, что Rating имеет две цифры после запятой
            .IsRequired();

        builder.Property(r => r.Comment)
            .HasMaxLength(1000);

        builder.HasOne(r => r.Reviewer)
            .WithMany()
            .HasForeignKey(r => r.ReviewerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.Target)
            .WithMany(psp => psp.Reviews)
            .HasForeignKey(r => r.TargetId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
