using IntegratedAccountManagement.CrossCutting.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IntegratedAccountManagement.ApiConfiguration.Startup;

public static class AuthorizationConfig
{
    public static IServiceCollection AppAddAuthorization(this IServiceCollection services,
        IConfiguration config, IHostEnvironment env)
    {
        var jwtTokenConfig = new JwtTokenConfig();
        config.GetSection(nameof(JwtTokenConfig)).Bind(jwtTokenConfig);
        services.AddSingleton(jwtTokenConfig);

        services.AddAuthentication(o =>
        {
            o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.TokenValidationParameters = jwtTokenConfig.TokenValidationParameters;
            x.RequireHttpsMetadata = !env.IsDevelopment();
        });

        return services;
    }
}