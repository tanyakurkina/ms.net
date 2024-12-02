using VetClinic.Service.IoC;
using VetClinic.Service.DI;
using VetClinic.Service.Settings;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();
var settings = VetClinicSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);

ApplicationConfigurator.ConfigureServices(builder);

var app = builder.Build();

ApplicationConfigurator.ConfigureApplication(app);


app.Run();