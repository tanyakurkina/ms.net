using VetClinic.Service.IoC;
using VetClinic.Service.Settings;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();
var settings = VetClinicSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

DbContextConfigurator.ConfigureService(builder.Services, settings);
SwaggerConfigurator.ConfigureServices(builder.Services);
SerilogConfigurator.ConfigureService(builder);

var app = builder.Build();

DbContextConfigurator.ConfigureApplication(app);
SwaggerConfigurator.ConfigureApplication(app);
SerilogConfigurator.ConfigureApplication(app);

app.UseHttpsRedirection();

app.Run();