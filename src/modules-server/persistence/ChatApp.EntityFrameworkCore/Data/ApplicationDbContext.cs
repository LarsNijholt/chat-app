using System.Reflection;
using ChatApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.EntityFrameworkCore.Data;

/// <summary>
/// The main DbCContext for the application
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// The user repository for the DbContext.
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// The credentials repository for the DbContext.
    /// </summary>
    public DbSet<Credential> Credentials { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<User>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Credential>()
            .HasKey(x => x.Id);
    }

    /// <inheritdoc />
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }
}