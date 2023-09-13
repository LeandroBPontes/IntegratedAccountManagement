using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegratedAccountManagement.IocConfiguration;

public static class IocServiceConfiguration
{
    public static IServiceCollection AppAddIoCServices(this IServiceCollection services, IConfiguration config)
    {
        //infra
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        

      //  services.AddScoped<ISessionProvider, SessionProvider>();
        

        //events
       // services.AddScoped<IDomainNotification, DomainNotification>();

        // unit of work
        //services.AddScoped<IUnitOfWork, UnitOfWork>();

     

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
        //
        // InjectSolutionsPortalService(services, config);

        return services;
    }
}