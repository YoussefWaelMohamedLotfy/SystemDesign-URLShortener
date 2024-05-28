using Microsoft.EntityFrameworkCore;

namespace UrlShortener_API.Data;

public sealed class AppDbContextMigrationHostedService : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<AppDbContextMigrationHostedService> _logger;

    public AppDbContextMigrationHostedService(IServiceProvider service, ILogger<AppDbContextMigrationHostedService> logger)
    {
        _serviceProvider = service;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using IServiceScope scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        _logger.LogInformation("Starting Db Migration...");
        await context.Database.MigrateAsync(cancellationToken);
        _logger.LogInformation("Finished Db Migration...");
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        using IServiceScope scope = _serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        _logger.LogInformation("Starting Db Removal...");
        await context.Database.EnsureDeletedAsync(cancellationToken);
        _logger.LogInformation("Finished Db Removal...");
    }
}
