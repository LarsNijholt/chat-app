using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChatApp.EntityFrameworkCore.Data;

/// <summary>
/// The initializer for the <see cref="ApplicationDbContext"/>.
/// </summary>
public class DbContextInitializer
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
    private readonly ILogger<DbContextInitializer> _logger;

    /// <summary>
    /// A class responsible for initializing the application's database.
    /// </summary>
    public DbContextInitializer(IDbContextFactory<ApplicationDbContext> dbContextFactory, ILogger<DbContextInitializer> logger)
    {
        _dbContextFactory = dbContextFactory;
        _logger = logger;
    }
    
    /// <summary>
    /// Initialize the database.
    /// </summary>
    public async Task InitializeDatabaseAsync()
    {
        try
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            _logger.LogInformation("Initializing the database");
            await dbContext.Database.MigrateAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error initializing the database");
        }
    }
}