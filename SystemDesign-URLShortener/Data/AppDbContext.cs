using Microsoft.EntityFrameworkCore;
using URLShortener.Core.Entities;

namespace SystemDesign_URLShortener.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<URL> URLs { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Startup).Assembly);
    }
}
