using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance.Seeder;


public class Seeder
{
    private readonly OccurrensDbContext _dbContext;

    public Seeder(OccurrensDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ApplyPendingMigrations()
    {
        if (await _dbContext.Database.CanConnectAsync() && _dbContext.Database.IsRelational())
        {
            var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();
            if (pendingMigrations != null && pendingMigrations.Any())
            {
                await _dbContext.Database.MigrateAsync();
            }
        }
    }
}