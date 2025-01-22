using DateFinder.Api.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Collections;

namespace DateFinder.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            (new DateFinderServiceCollection()).ConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/DateFinder/swagger.json", "DateFinder");
                c.RoutePrefix = string.Empty;

            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            // Log a message to verify the application is starting correctly
            logger.LogInformation("Application started successfully.");

            //// Log environment variables
            //var environmentVariables = Environment.GetEnvironmentVariables();
            //logger.LogInformation("Logging all environment variables:");
            //foreach (DictionaryEntry env_ in environmentVariables)
            //{
            //    logger.LogInformation($"{env_.Key}: {env_.Value}");
            //}

            //// Log the contents of the /var/task directory
            //var files = Directory.GetFiles("/var/task");
            //logger.LogInformation("Files in /var/task:");
            //foreach (var file in files)
            //{
            //    logger.LogInformation(file);
            //}
        }
    }
}