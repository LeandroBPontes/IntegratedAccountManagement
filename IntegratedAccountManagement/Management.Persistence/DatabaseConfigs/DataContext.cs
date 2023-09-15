using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace IntegratedAccountManagement.Persistence.DatabaseConfigs;


 public class DataContext : DbContext
    {
        public DbContext DbContext { get; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            DbContext = this;
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.HasDefaultSchema("public");
        }
    }