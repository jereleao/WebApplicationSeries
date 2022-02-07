using Microsoft.EntityFrameworkCore;
using Series.Models;

namespace Series.DataBase
{
    public class SeriesContext : DbContext
    {
        public DbSet<Serie> Series { get; set; }

        public SeriesContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                //var connectionString = configuration.GetConnectionString("DefaultConnection");
                //optionsBuilder.UseSqlServer(connectionString);

                optionsBuilder.UseInMemoryDatabase("SeriesDb");
            }
        }
    }
}
