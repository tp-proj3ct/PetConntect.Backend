using PetConnect.Backend.Core;
using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.DataAccess.Cfg;

namespace PetConnect.Backend.DataAccess;

public class Context : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Pet> Pets { get; set; }

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<PetOwnerProfile> PetOwnerProfiles { get; set; }
    public DbSet<PetSitterProfile> PetSitterProfiles { get; set; }

    public DbSet<Service> Services { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Booking> Bookings { get; set; }


    public Context(DbContextOptions<Context> option) : base(option)
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserCfg());
        modelBuilder.ApplyConfiguration(new PetCfg());
        modelBuilder.ApplyConfiguration(new UserProfileCfg());
        modelBuilder.ApplyConfiguration(new PetOwnerProfileCfg());
        modelBuilder.ApplyConfiguration(new PetSitterProfileCfg());
        modelBuilder.ApplyConfiguration(new ServiceCfg());
        modelBuilder.ApplyConfiguration(new ReviewCfg());
        modelBuilder.ApplyConfiguration(new BookingCfg());
    }
}