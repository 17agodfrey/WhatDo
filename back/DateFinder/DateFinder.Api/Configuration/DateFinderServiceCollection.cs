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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AWS.Logger.AspNetCore;
using Microsoft.Extensions.Options;
using System;




namespace DateFinder.Api.Configuration
{
    public class DateFinderServiceCollection
    {
        private readonly bool? _isTest;
        private readonly IConfiguration _configuration;

        public DateFinderServiceCollection(IConfiguration configuration, bool? isTest = false)
        {
            _configuration = configuration;
            _isTest = isTest;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            // Configuration is automatically registered with the DI container in ASP.NET Core
            // services.AddSingleton<IConfiguration>(_configuration);// Register IConfiguration

            // Register DateFinderConfigurationSettings and inject IConfiguration
            services.AddSingleton<IDateFinderConfigurationSettings>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                return new DateFinderConfigurationSettings(configuration); // Pass IConfiguration into the constructor
            });



            // add AWS lambda hosting 
            services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

            // Add services to the container.
            //services.AddSingleton<IDateFinderConfigurationSettings, DateFinderConfigurationSettings>(); // singleton means single instance throughout the application
            services.AddScoped<IDatesRepository, DatesRepository>(); // scoped - created once per request

            //services.AddTransient<IGoogleMapsClient, GoogleMapsClient>(); // transient means a new instance is created every time it is requested
            services.AddScoped<IGoogleMapsClient, GoogleMapsClient>();

            // Add GoogleMapsClient with logger injection
            services.AddScoped<IGoogleMapsClient, GoogleMapsClient>(provider =>
            {
                var logger = provider.GetRequiredService<ILogger<GoogleMapsClient>>();
                var config = provider.GetRequiredService<IDateFinderConfigurationSettings>();
                return new GoogleMapsClient(config, logger);
            });

            // Add AWS logging to the services
            // ***IMPORTANT*** this cannot be used if running locally, will cause crash 
            if (Environment.GetEnvironmentVariable("SOMETHING_ELSE") != null)
            {
                services.AddLogging(builder =>
                {
                    builder.AddAWSProvider();
                });
            }

            services.AddTransient<IDateService, DateService>();

            ConfigureJwtAuthentication(services);
            ConfigureMiddlewareServices(services);
        }

        // NOTE: might want to rename/change this eventually... look at how NZ does middleware... RR doesn't put this here 
        private void ConfigureMiddlewareServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            services.AddControllers();

            services.AddDbContext<DateFinderDbContext>((serviceProvider, options) =>
            {
                //var dateFinderSettings = _configuration.GetSection("DateFinderSettings").Get<DateFinderConfigurationSettings>();
                //var provider = services.BuildServiceProvider();
                //var configSettings = provider.GetRequiredService<IDateFinderConfigurationSettings>();
                var configSettings = serviceProvider.GetRequiredService<IDateFinderConfigurationSettings>();

                if (_isTest == false)
                {
                    options.UseNpgsql(configSettings.DateFinderConnectionString);
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
