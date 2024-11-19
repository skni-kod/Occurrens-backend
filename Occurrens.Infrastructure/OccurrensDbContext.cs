using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Occurrens.Domain.Entities;

namespace Occurrens.Infrastructure;

public class OccurrensDbContext : IdentityDbContext<Account, IdentityRole<Guid>, Guid, IdentityUserClaim<Guid>, IdentityUserRole<Guid>, IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    public OccurrensDbContext(DbContextOptions<OccurrensDbContext> options) : base(options){}

    public DbSet<Domain.Entities.DoctorWorkPlace> DoctorWorkPlaces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AccountConfiguration());
    }
}