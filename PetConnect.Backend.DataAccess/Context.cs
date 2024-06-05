using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.DataAccess.Cfg;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.Core.Users;
using PetConnect.Backend.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PetConnect.Backend.DataAccess;

public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<PetSitter> PetSitters { get; set; }
    public DbSet<PetOwner> PetOwners { get; set; }

    public DbSet<UserProfile> UserProfiles { get; set; }

    public DbSet<Pet> Pets { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Payment> Payments { get; set; }

    private readonly bool _isDevelopment;

    public Context(DbContextOptions<Context> option, IWebHostEnvironment env) : base(option)
    {
        _isDevelopment = env.IsDevelopment();

        //Database.EnsureDeleted();
        Database.EnsureCreated();
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (_isDevelopment)
        {
            // TODO
        }

        modelBuilder.ApplyConfiguration(new UserCfg());
        modelBuilder.ApplyConfiguration(new PetOwnerCfg());
        modelBuilder.ApplyConfiguration(new PetSitterCfg());
        modelBuilder.ApplyConfiguration(new UserProfileCfg());
        modelBuilder.ApplyConfiguration(new PetCfg());
        modelBuilder.ApplyConfiguration(new ServiceCfg());
        modelBuilder.ApplyConfiguration(new ReviewCfg());
        modelBuilder.ApplyConfiguration(new BookingCfg());
        modelBuilder.ApplyConfiguration(new PaymentCfg());
    }
}