using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChatApp.EntityFrameworkCore.Data;

/// <summary>
/// The initializer for the <see cref="ApplicationDbContext"/>.
/// </summary>
public class DbContextInitializer
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger _logger;

    /// <summary>
    /// A class responsible for initializing the application's database.
    /// </summary>
    public DbContextInitializer(ApplicationDbContext dbContext, ILogger logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    
    /// <summary>
    /// Initialize the database.
    /// </summary>
    public async Task InitializeDatabaseAsync()
    {
        try
        {
            _logger.LogInformation("Initializing the database");
            await _dbContext.Database.MigrateAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error initializing the database");
        }
    }
}