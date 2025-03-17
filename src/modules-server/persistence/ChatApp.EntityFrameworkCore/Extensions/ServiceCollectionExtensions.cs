using ChatApp.EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.EntityFrameworkCore.Extensions;

/// <summary>
/// An extension on the <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add the persistence module to the <see cref="IServiceCollection"/>.
    /// </summary>
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        return services
            .AddScoped<DbContextInitializer>()
            .AddDbContextFactory<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
    }
}