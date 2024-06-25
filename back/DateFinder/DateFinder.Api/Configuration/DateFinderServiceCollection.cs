using Microsoft.AspNetCore.Authentication;
using DateFinder.Storage;
using Microsoft.EntityFrameworkCore;
using DateFinder.Domain.Api.Configuration;
using DateFinder.External;
using DateFinder.Domain.External;



namespace DateFinder.Api.Configuration
{
    public class DateFinderServiceCollection
    {
        private readonly IDateFinderConfigurationSettings _configuration;

        public DateFinderServiceCollection(IDateFinderConfigurationSettings dateFinderConfigurationSettings = null)
        {
            _configuration = dateFinderConfigurationSettings ?? new DateFinderConfigurationSettings();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddSingleton<IDateFinderConfigurationSettings, DateFinderConfigurationSettings>(); // singleton means single instance throughout the application

            services.AddTransient<IGoogleMapsClient, GoogleMapsClient>(); // transient means a new instance is created every time it is requested

            ConfigureJwtAuthentication(services);
            ConfigureMiddlewareServices(services);
        }

        // NOTE: might want to rename/change this eventually... look at how NZ does middleware... RR doesn't put this here 
        private void ConfigureMiddlewareServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DateFinderDbContext>(options =>
            {
                if (_configuration.DateFinderConnectionString != null)
                {
                    options.UseSqlServer(_configuration.DateFinderConnectionString);
                }
                else
                {
                    options.UseInMemoryDatabase("DateFinderInMemoryDb");
                }
            });

            // Add Swagger services
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("DateFinder", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "DateFinder API",
                    Version = "v1"
                });
            });
        }

        private void ConfigureJwtAuthentication(IServiceCollection services)
        {
            //TODO
        }


    }
}
