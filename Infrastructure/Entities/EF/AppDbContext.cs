using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Reflection;
using UPD8.CSharp.Infrastructure.Entities.Settings;

namespace UPD8.CSharp.Infrastructure.Entities.EF
{
    public class AppDbContext : DbContext
    {
        private readonly AppSettings _appSettings;

        public AppDbContext(
            DbContextOptions<AppDbContext> options,
            IOptions<AppSettings> sharedSettings

        ) : base(options)
        {
            _appSettings = sharedSettings.Value;
        }

        public DbSet<CustomerEntity> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_appSettings.GetConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister =
                    Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces().Any(gi => gi.IsGenericType
                    && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
