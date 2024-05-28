var builder = DistributedApplication.CreateBuilder(args);

var postgresServer = builder.AddPostgres("postgres-db")
    .WithImageTag("alpine")
    .WithPgAdmin(x => x.WithImageTag("latest"));
    
var db = postgresServer.AddDatabase("ShortenedUrlsDb");

var redisCache = builder.AddRedis("redis-cache")
    .WithImageTag("alpine");

var api = builder.AddProject<Projects.UrlShortener_API>("urlshortener-api")
    .WithReference(db)
    .WithReference(redisCache);

await builder.Build().RunAsync();
