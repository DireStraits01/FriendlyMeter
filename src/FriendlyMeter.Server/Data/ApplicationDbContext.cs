using Microsoft.EntityFrameworkCore;
using FriendlyMeter.Shared.Models;

namespace FriendlyMeter.Server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set;}
    public DbSet<Flat> Flats { get; set; }
    public DbSet<Tariff> Tariffs {get; set; }
    public DbSet<Metrics> Metrics {get; set;}

    protected  override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.OwnFlats)
            .WithOne(f => f.Owner)
            .HasForeignKey(f => f.OwnerId)
            .IsRequired();

        modelBuilder.Entity<User>()
            .HasMany(u => u.RentFlats)
            .WithOne(f => f.Renter)
            .HasForeignKey(f => f.RenterId);
    }
}