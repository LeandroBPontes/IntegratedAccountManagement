using IntegratedAccountManagement.Persistence.DatabaseConfigs;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IntegratedAccountManagement.ApiConfiguration.Startup;
    public static class DatabaseConfig
    {
        public static IServiceCollection AppAddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DataContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default")));
            
            return services;
        }

        public static IApplicationBuilder AppUseMigrations(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            
            var context = serviceScope.ServiceProvider.GetService<DataContext>();
        
            if (context == null)
            {
                throw new Exception("Could not get injected DataContext");
            }
        
            if (context.DbContext.Database.GetPendingMigrations().Any())
            {
                context.DbContext.Database.Migrate();
            }
        
            SeedUser.CreateUsers(context);
        
            return app;
        }
    }

