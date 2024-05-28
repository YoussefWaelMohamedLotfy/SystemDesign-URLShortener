var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.UrlShortener_API>("urlshortener-api");

builder.Build().Run();
