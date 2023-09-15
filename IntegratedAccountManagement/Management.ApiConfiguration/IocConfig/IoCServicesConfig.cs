using IntegratedAccountManagement.Persistence.DatabaseConfigs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegratedAccountManagement.ApiConfiguration.IocConfig;

public static class IoCServicesConfig
{
    public static IServiceCollection AppAddIoCServices(this IServiceCollection services,
        IConfiguration config)
    {
        // options/config
        ConfigureOptions(services, config);

        // infra
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddScoped<DataContext, DataContext>();

        //services.AddSingleton<PasswordHasherService>();

        // unit of work
        //services.AddScoped<IUnitOfWork, UnitOfWork>();

        // repositories
        // typeof(UserRepository).Assembly.GetTypes()
        //     .Where(x => x.FullName != null && x.FullName.Contains("Repositories") && x.GetInterfaces().Any() && x.IsClass && x != typeof(RepositoryBase<,>))
        //     .ToList().ForEach(x =>
        //     {
        //         var @interface = x.GetInterfaces().FirstOrDefault(s => s.Name.Contains(x.Name));
        //
        //         if (@interface == null) return;
        //
        //         services.AddScoped(@interface, x);
        //     });

        return services;
    }

    private static void ConfigureOptions(IServiceCollection services,
        IConfiguration config)
    {
        // var appConfig = new AppConfig();
        // config.GetSection(nameof(AppConfig)).Bind(appConfig);
        // services.AddSingleton(appConfig);
    }
}