using Microsoft.AspNetCore.Authentication;
using DateFinder.Storage;
using Microsoft.EntityFrameworkCore;
using DateFinder.Domain.Api.Configuration;
using DateFinder.External;
using DateFinder.Domain.External;
using DateFinder.Domain.Mappings;
using DateFinder.Domain.Repositories;
using DateFinder.Repositories;
using DateFinder.Domain.Services;
using DateFinder.Services;



namespace DateFinder.Api.Configuration
{
    public class DateFinderServiceCollection
    {
        private readonly bool? _isTest;

        public DateFinderServiceCollection(bool? isTest = false)
        {
            _isTest = isTest;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddSingleton<IDateFinderConfigurationSettings, DateFinderConfigurationSettings>(); // singleton means single instance throughout the application
            services.AddScoped<IDatesRepository, DatesRepository>(); // scoped - created once per request

            services.AddTransient<IGoogleMapsClient, GoogleMapsClient>(); // transient means a new instance is created every time it is requested
            services.AddTransient<IDateService, DateService>();

            ConfigureJwtAuthentication(services);
            ConfigureMiddlewareServices(services);
        }

        // NOTE: might want to rename/change this eventually... look at how NZ does middleware... RR doesn't put this here 
        private void ConfigureMiddlewareServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DateFinderDbContext>(options =>
            {
                var configuration = services.BuildServiceProvider().GetRequiredService<IDateFinderConfigurationSettings>();

                if (_isTest == false)
                {
                    options.UseSqlServer(configuration.DateFinderConnectionString);
                }
                else
                {
                    options.UseInMemoryDatabase("DateFinderInMemoryDb");
                }
            });

            services.AddAutoMapper(typeof(AutoMapperProfiles));

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
