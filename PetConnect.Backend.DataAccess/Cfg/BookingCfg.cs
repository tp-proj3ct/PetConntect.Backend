using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;

namespace PetConnect.Backend.DataAccess.Cfg;

internal class BookingCfg : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Status)
            .IsRequired();

        builder.Property(b => b.StartedDate)
            .IsRequired();

        builder.Property(b => b.ServiceAddress)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(b => b.AdditionalRequirements)
            .HasMaxLength(1024);

        builder.Property(b => b.CustomerComment)
            .HasMaxLength(1024);

        builder.HasOne(b => b.Service)
            .WithMany()
            .HasForeignKey(b => b.ServiceId);

        builder.HasOne(b => b.Customer)
            .WithMany()
            .HasForeignKey(b => b.CustomerId);

        builder.HasMany(b => b.Pets)
            .WithOne()
            .HasForeignKey(p => p.Id);
    }
}
