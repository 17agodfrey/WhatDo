using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DateFinder.Storage
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DateFinderDbContext>
    {
        public DateFinderDbContext CreateDbContext(string[] args)
        {
            // Set the path to your API project directory
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../DateFinder.Api"))
                .AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<DateFinderDbContext>();
            var connectionString = configuration.GetConnectionString("DateFinderConnectionString");
            builder.UseNpgsql(connectionString);

            return new DateFinderDbContext(builder.Options);
        }
    }
}
