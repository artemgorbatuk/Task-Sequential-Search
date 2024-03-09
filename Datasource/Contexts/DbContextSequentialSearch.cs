using Datasource.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Datasource.Contexts
{
    public class DbContextSequentialSearch : DbContext
    {
        public DbContextSequentialSearch() { }
        public DbContextSequentialSearch(DbContextOptions<DbContextSequentialSearch> options) : base(options) { }

        public virtual DbSet<TextSource> TextSources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies(false);
            options.UseChangeTrackingProxies(false);
            options.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasDefaultSchema("dto");
            base.OnModelCreating(modelBuilder);
        }
    }
}