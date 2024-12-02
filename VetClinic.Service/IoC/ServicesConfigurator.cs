using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VetClinic.BL.Users.Manager;
using VetClinic.BL.Users.Provider;
using VetClinic.DataAccess;
using VetClinic.DataAccess.Entities;
using VetClinic.DataAccess.Repository;

namespace VetClinic.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Регистрация репозитория
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        // Регистрация репозитория для сущности User
        services.AddScoped<IRepository<User>>(x => 
            new Repository<User>(x.GetRequiredService<IDbContextFactory<VetClinicDbContext>>()));

        // Регистрация провайдера пользователей
        services.AddScoped<IUsersProvider>(x => 
            new UsersProvider(
                x.GetRequiredService<IRepository<User>>(), 
                x.GetRequiredService<IMapper>()));

        // Регистрация менеджера пользователей
        services.AddScoped<IUsersManager>(x =>
            new UsersManager(
                x.GetRequiredService<IRepository<User>>(),
                x.GetRequiredService<IMapper>()));
    }
}