using Microsoft.AspNetCore.Authentication;
using DateFinder.Storage;
using Microsoft.EntityFrameworkCore;
using DateFinder.External;



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
            services.AddSingleton<IDateFinderConfigurationSettings, DateFinderConfigurationSettings>(); // singleton means single instance throughout the application

            services.AddTransient<IGoogleMapsClient, GoogleMapsClient>(); // transient means a new instance is created every time it is requested

            ConfigureJwtAuthentication(services);
            ConfigureMiddlewareServices(services);
        }

        // NOTE: might want to rename/change this eventually... look at how NZ does middleware
        private void ConfigureMiddlewareServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DateFinderDbContext>(options =>
            {
                if (_configuration.GetConnectionString("DateFinderConnectionString") != null)
                {
                    options.UseSqlServer(_configuration.GetConnectionString("DateFinderConnectionString"));
                }
                else
                {
                    options.UseInMemoryDatabase("DateFinderInMemoryDb");
                }
            });
        }

        private void ConfigureJwtAuthentication(IServiceCollection services)
        {
            //TODO
        }


    }
}
