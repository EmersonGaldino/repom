using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace repom.persistence.Context;

public class ContextDb(DbContextOptions<ContextDb> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(
            builder
                .EnableSensitiveDataLogging()
        );
    }
    // public virtual DbSet<UserEntity> User { get; set; } 
    //
    // public virtual DbSet<StoreEntity> Store { get; set; }
    // public virtual DbSet<AddressEntity> Address { get; set; }
    //
    // public virtual DbSet<DataBankEntity> Account { get; set; }
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    //     modelBuilder.Entity<StoreEntity>()
    //         .HasOne(s => s.User)
    //         .WithMany(a => a.Stores)
    //         .HasForeignKey(s => s.UserId);
    //
    //     modelBuilder.Entity<DataBankEntity>()
    //         .HasKey(d => d.UserId);
    //     modelBuilder.Entity<DataBankEntity>()
    //         .HasOne(d => d.User)
    //         .WithOne(u => u.Account)
    //         .HasForeignKey<DataBankEntity>(d => d.UserId);
    //     
    //     modelBuilder.Entity<AddressEntity>()
    //         .HasKey(d => d.UserId);
    //     modelBuilder.Entity<AddressEntity>()
    //         .HasOne(ad => ad.User)
    //         .WithOne(us => us.Address)
    //         .HasForeignKey<AddressEntity>(u => u.UserId);

    public async Task<int> SaveChangesAsync()
    {
        ChangeTracker.DetectChanges();

        return await base.SaveChangesAsync();
    }
}