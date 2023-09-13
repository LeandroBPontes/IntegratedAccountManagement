
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IntegratedAccountManagement.ApiConfiguration.Startup;

    public static class AuthenticationConfig
    {
        public static IServiceCollection AppAddAuthentication(this IServiceCollection services,
            IConfiguration config,
            IHostEnvironment env)
        {
            return services;
        }
    }

