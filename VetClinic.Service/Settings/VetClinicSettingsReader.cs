namespace VetClinic.Service.Settings;

public class VetClinicSettingsReader
{
    public static VetClinicSettings Read(IConfiguration configuration)
    {
        return new VetClinicSettings()
        {
            VetClinicDbConnectionString = configuration.GetValue<string>("VetClinicDbContext")
        };
    }
}