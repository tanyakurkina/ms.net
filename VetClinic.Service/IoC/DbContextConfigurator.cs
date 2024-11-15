using Microsoft.EntityFrameworkCore;
using VetClinic.DataAccess;
using VetClinic.Service.Settings;

namespace VetClinic.Service.IoC;

public class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, VetClinicSettings settings)
    {
        services.AddDbContextFactory<VetClinicDbContext>(options =>
        {
            options.UseNpgsql(settings.VetClinicDbConnectionString);
        }, ServiceLifetime.Scoped);

    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<VetClinicDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}