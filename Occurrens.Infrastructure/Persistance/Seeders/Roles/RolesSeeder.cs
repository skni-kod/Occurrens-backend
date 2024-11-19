using Microsoft.AspNetCore.Identity;
using Occurrens.Domain.Roles;

namespace Occurrens.Infrastructure.Persistance.Seeders.Roles;

public static class RolesSeeder
{
    public static async Task SeedRolesAsync(RoleManager<IdentityRole<Guid>> roleManager, OccurrensDbContext context, CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var roles = UserRoles.Get();
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role.Name))
            {
                await roleManager.CreateAsync(role);
            }
        }

        await transaction.CommitAsync(cancellationToken);
    }
}