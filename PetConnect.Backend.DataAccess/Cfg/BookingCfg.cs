using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core;
using PetConnect.Backend.DataAccess.Dto;

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

        
        builder.HasOne(b => b.Service)
               .WithMany()
               .HasForeignKey(b => b.ServiceId)
               .OnDelete(DeleteBehavior.Restrict); 

        builder.HasOne(b => b.Customer)
               .WithMany()
               .HasForeignKey(b => b.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(b => b.Pets)
               .WithMany()
               .UsingEntity<BookingPetsDto>(
                    j =>
                    {
                        j.ToTable("BookingPets");
                        j.HasKey(bp => new { bp.BookingId, bp.PetId });

                        j.HasOne(bpd => bpd.Pet) 
                            .WithMany()
                            .HasForeignKey(bp => bp.PetId); 
                        j.HasOne(bpd => bpd.Booking) 
                            .WithMany()
                            .HasForeignKey(bp => bp.BookingId); 
                    });

        builder.HasOne(b => b.Payment)
           .WithOne(p => p.Booking)
           .HasForeignKey<Payment>(p => p.BookingId);
    }
}
