using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using repom.domain.core.Entity;

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
    public virtual DbSet<PersonEntity> Person { get; set; } 
    public virtual DbSet<JobEntity> Job { get; set; }
    public virtual DbSet<AddressEntity> Address { get; set; }
    public virtual DbSet<PhoneEntity> Phone { get; set; }
    public virtual DbSet<DepartmentEntity?> Department { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PhoneEntity>()
            .HasOne(p => p.Person)
            .WithMany(pe => pe.Phones)
            .HasForeignKey(p => p.PersonId);

    }


    public async Task<int> SaveChangesAsync()
    {
        ChangeTracker.DetectChanges();

        return await base.SaveChangesAsync();
    }
}