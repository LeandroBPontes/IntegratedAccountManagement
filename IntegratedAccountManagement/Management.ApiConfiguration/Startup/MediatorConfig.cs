using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IntegratedAccountManagement.ApiConfiguration.Startup;
    public static class MediatorConfig
    {
        public static IServiceCollection AppAddMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Management.Domain");
            services.AddMediatR(assembly);
            return services;
        }
    }

