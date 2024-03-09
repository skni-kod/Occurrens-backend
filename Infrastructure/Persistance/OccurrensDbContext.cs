using Microsoft.EntityFrameworkCore;
using occurrensBackend.Entities.DatabaseEntities;

namespace Infrastructure.Persistance;

public class OccurrensDbContext : DbContext
{
    public OccurrensDbContext(DbContextOptions<OccurrensDbContext> options) : base(options){}
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Specialization> Specializations { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Is_opened> IsOpeneds { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Disease> Diseases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>()
            .HasIndex(r => r.Email)
            .IsUnique();
         
        modelBuilder.Entity<Doctor>()
            .HasIndex(r => r.Pesel)
            .IsUnique();

        modelBuilder.Entity<Patient>()
            .HasIndex(r => r.Email)
            .IsUnique();
        
        modelBuilder.Entity<Patient>()
            .HasIndex(r => r.Pesel)
            .IsUnique();

    }
}