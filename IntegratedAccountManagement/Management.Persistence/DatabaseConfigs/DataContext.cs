using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace IntegratedAccountManagement.Persistence.DatabaseConfigs;


 public class DataContext : DbContext
    {
        public DbContext DbContext { get; }

        public DataContext(){}
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            DbContext = this;
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.HasDefaultSchema("public");
            mb.ApplyConfigurationsFromAssembly(typeof(DataContext).GetTypeInfo().Assembly);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Management.Api");
                
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.Development.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("Default");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }