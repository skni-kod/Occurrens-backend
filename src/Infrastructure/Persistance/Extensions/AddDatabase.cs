using System.Reflection.Metadata;
using Domain.Entities;
using Infrastructure.Persistance.Seeders.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistance.Extensions;

public static class AddDatabase
{
    public static IServiceCollection DatabaseConfiguration(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddDbContext<OccurrensDbContext>(opt => opt.UseNpgsql(
            configuration.GetConnectionString("Database"),
            m => m.MigrationsAssembly(typeof(AssemblyReference).Assembly.ToString())));

        services.AddHostedService<DatabaseSeeder>();
        
        services.AddIdentity<Account, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<OccurrensDbContext>()
            .AddDefaultTokenProviders();
        
        return services;
    }
}