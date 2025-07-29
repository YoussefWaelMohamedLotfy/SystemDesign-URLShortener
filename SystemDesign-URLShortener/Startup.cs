using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using SystemDesign_URLShortener.Data;

namespace SystemDesign_URLShortener;

public class Startup
{
    internal IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddDbContext<AppDbContext>(options => 
            options.UseSqlite(Configuration.GetConnectionString("SqliteConnection")));

        services.AddAutoMapper(x => x.AddProfile<AutoMappingConfig>());

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(swaggerOptions =>
        {
            swaggerOptions.ExampleFilters();

            swaggerOptions.SwaggerDoc("v1", 
                new OpenApiInfo
                {
                    Title = "URL Shortener",
                    Description = "My implementation of URL Shortener in ASP.NET Core 6.",
                    Version = "v1",
                    Contact = new OpenApiContact 
                    { 
                        Name = "Youssef Wael Mohamed-Lotfy",
                        Email = "youssefwael8@gmail.com",
                        Url = new("https://www.linkedin.com/in/youssefwaelmohamed-lotfy/")
                    }
                });

            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            swaggerOptions.IncludeXmlComments(xmlPath);

            swaggerOptions.UseApiEndpoints();
        });

        services.AddSwaggerExamplesFromAssemblyOf<Startup>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment() || env.IsStaging())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "URL Shortener - Swagger UI";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "URL Shortener v1");
            });
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
