using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContextInitializer
{
    private readonly ApplicationDbContext _dbContext;

    public ApplicationDbContextInitializer(
        ApplicationDbContext applicationDbContext)
    {
        _dbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
    }
    public async Task InitialAsync()
    {
        {
            if (_dbContext.Database.GetPendingMigrations().Any())
            {
                await _dbContext.Database.MigrateAsync();
            }
        }
    }
}