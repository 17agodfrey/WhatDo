using Microsoft.AspNetCore.Authentication;
using DateFinder.Storage;
using Microsoft.EntityFrameworkCore;

namespace DateFinder.Api.Configuration
{
    public class DateFinderServiceCollection
    {
        private readonly IConfiguration _configuration;

        public DateFinderServiceCollection(IConfiguration? configuration = null)
        {
            _configuration = configuration ?? new ConfigurationBuilder().Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.

            ConfigureJwtAuthentication(services);
            ConfigureMiddlewareServices(services);
        }

        // NOTE: might want to rename/change this eventually... look at how NZ does middleware
        private void ConfigureMiddlewareServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DateFinderDbContext>(options =>
            {
                options.UseSqlServer(_configuration?.GetConnectionString("DateFinderConnectionString"));
            });
        }

        private void ConfigureJwtAuthentication(IServiceCollection services)
        {
            //TODO
        }


    }
}
