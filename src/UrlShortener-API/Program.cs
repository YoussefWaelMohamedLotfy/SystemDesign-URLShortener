var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapPost("/shorten", async (ShortenerBody body) =>
{


    return Results.Ok();
});

app.MapGet("/{shortCode:required}", async () =>
{


    return Results.RedirectToRoute();
});

await app.RunAsync();

sealed record ShortenerBody(string Url);