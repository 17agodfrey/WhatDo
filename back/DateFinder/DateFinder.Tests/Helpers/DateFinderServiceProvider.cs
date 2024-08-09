using System;
//using DateFinder.Api.Configuration;
//using DateFinder.Domain.Configuration;
//using DateFinder.Domain.Storage;
using DateFinder.Tests.Fakes;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Microsoft.Extensions.Configuration;
using DateFinder.Api.Configuration;
using DateFinder.Storage;
using Microsoft.EntityFrameworkCore;
using DateFinder.Domain.Storage.EnumAttributes;
using DateFinder.Domain.Storage;

namespace DateFinder.Tests.Helpers
{
    public class DateFinderServiceProvider
    {
        private static bool _isDatabaseSeeded = false;

        public IServiceProvider Create()
        {
            var container = new ServiceCollection();
            //var configuration = new ConfigurationBuilder().Build(); // Empty configuration for tests
            (new DateFinderServiceCollection(true)).ConfigureServices(container);

            RegisterAll(container);

            var serviceProvider = container.BuildServiceProvider();

            // Seed the database only if it hasn't been seeded yet
            if (!_isDatabaseSeeded)
            {
                SeedDatabase(serviceProvider);
                _isDatabaseSeeded = true;
            }

            return serviceProvider;
        }

        private void RegisterAll(IServiceCollection serviceCollection)
        {
            RegisterMemoryFake(serviceCollection);
        }

        private void RegisterMemoryFake(IServiceCollection serviceCollection)
        {
            // Use InMemory database for testing
            serviceCollection.AddDbContext<DateFinderDbContext>(options =>
            {
                options.UseInMemoryDatabase("DateFinderInMemoryDb");
            });

            // Add any additional fake or mock services here
        }

        private void SeedDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DateFinderDbContext>();

                // Ensure the database is created
                context.Database.EnsureCreated();

                int i = 1; 

                // Add test data
                var dates = new List<Date>
{
    new Date { Id = i++, Name = "rock climbing", Duration = 4, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "indoor rock climbing", Duration = 2.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "amusement park", Duration = 5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "bowling", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "mini golf", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "golf", Duration = 4, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "driving range", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "trampoline park", Duration = 2, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "live music", Duration = 3.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "zoo", Duration = 3.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "botanical garden", Duration = 2.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "museum", Duration = 3, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "art museum", Duration = 2.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "mall", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "laser tag", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "indoor scuba diving", Duration = 2.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "indoor skydiving", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "ice castle", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "play/musical", Duration = 3, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "beach", Duration = 4, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "butterfly", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "farmers market", Duration = 1.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "movie", Duration = 3.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "drive in movie", Duration = 3.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "arcade", Duration = 1.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "ice skating", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "mountain biking", Duration = 3, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "axe throwing", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "archery", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "boba", Duration = 1, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "ice cream", Duration = 1, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "park", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "christmas lights/lights", Duration = 1.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "pickle ball", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "raquetball", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "horseback riding", Duration = 2.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "jetskiing", Duration = 2, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "kayaking", Duration = 3.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "road trip", Duration = 5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "snowboarding", Duration = 4, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "skiing", Duration = 4, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "paintballing", Duration = 3, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "skydiving", Duration = 2.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "concert", Duration = 3, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Any },
    new Date { Id = i++, Name = "air show", Duration = 5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = i++, Name = "ballet", Duration = 2.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "symphony", Duration = 2.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = i++, Name = "hiking", Duration = 3.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
};
                context.AddRange(dates); // Add the dates to the context
                context.SaveChanges();
            }
        }
    }
}
