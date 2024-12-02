using Microsoft.EntityFrameworkCore;
using VetClinic.DataAccess;
using VetClinic.Service.Settings;

namespace VetClinic.Service.IoC;

public class DbContextConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
                
        string connectionString = configuration.GetValue<string>("ConnectionStrings:FlowersShopDbContext");

        builder.Services.AddDbContextFactory<VetClinicDbContext>(
            options => { options.UseNpgsql(connectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<VetClinicDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}