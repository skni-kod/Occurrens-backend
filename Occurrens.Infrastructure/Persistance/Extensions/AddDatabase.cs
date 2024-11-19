using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Occurrens.Domain.Entities;
using Occurrens.Infrastructure.Persistance.Seeders.Database;

namespace Occurrens.Infrastructure.Persistance.Extensions;

public static class AddDatabase
{
    public static IServiceCollection DatabaseConfiguration(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddDbContext<OccurrensDbContext>(opt => opt.UseNpgsql(
            configuration.GetConnectionString("Database"),
            m => m.MigrationsAssembly(typeof(OccurrensDbContext).Assembly.FullName)));

        services.AddHostedService<DatabaseSeeder>();
        
        services.AddIdentity<Account, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<OccurrensDbContext>()
            .AddDefaultTokenProviders();
        
        return services;
    }
}