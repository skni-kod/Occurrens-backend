using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Occurrens.Infrastructure.Persistance.Seeders.Roles;

namespace Occurrens.Infrastructure.Persistance.Seeders.Database;

public sealed class DatabaseSeeder : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public DatabaseSeeder(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetService(typeof(OccurrensDbContext)) as OccurrensDbContext;

        var roles =
            scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole<Guid>>)) as
                RoleManager<IdentityRole<Guid>>;

        if (context is not null)
        {
            await context.Database.MigrateAsync(cancellationToken);

            await RolesSeeder.SeedRolesAsync(roles, context, cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}