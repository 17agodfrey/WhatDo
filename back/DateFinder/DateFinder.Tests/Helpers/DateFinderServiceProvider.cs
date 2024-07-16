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

                // Add test data
                var dates = new List<Date>
{
    new Date { Id = Guid.NewGuid(), Name = "rock climbing", Duration = 4, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "indoor rock climbing", Duration = 2.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "amusement park", Duration = 5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "bowling", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "mini golf", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "golf", Duration = 4, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "driving range", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "trampoline park", Duration = 2, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "live music", Duration = 3.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "zoo", Duration = 3.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "botanical garden", Duration = 2.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "museum", Duration = 3, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "art museum", Duration = 2.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "mall", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "laser tag", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "indoor scuba diving", Duration = 2.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "indoor skydiving", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "ice castle", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "play/musical", Duration = 3, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "beach", Duration = 4, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "butterfly", Duration = 2, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "farmers market", Duration = 1.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "movie", Duration = 3.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "drive in movie", Duration = 3.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "arcade", Duration = 1.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "ice skating", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "mountain biking", Duration = 3, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "axe throwing", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "archery", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "boba", Duration = 1, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "ice cream", Duration = 1, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "park", Duration = 1.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "christmas lights/lights", Duration = 1.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "pickle ball", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "raquetball", Duration = 1.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "horseback riding", Duration = 2.5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "jetskiing", Duration = 2, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "kayaking", Duration = 3.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "road trip", Duration = 5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "snowboarding", Duration = 4, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "skiing", Duration = 4, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "paintballing", Duration = 3, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "skydiving", Duration = 2.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "concert", Duration = 3, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Both },
    new Date { Id = Guid.NewGuid(), Name = "air show", Duration = 5, ActivityLevel = ActivityLevel.Medium, IndoorOutdoor = IndoorOutdoor.Outdoor },
    new Date { Id = Guid.NewGuid(), Name = "ballet", Duration = 2.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "symphony", Duration = 2.5, ActivityLevel = ActivityLevel.Low, IndoorOutdoor = IndoorOutdoor.Indoor },
    new Date { Id = Guid.NewGuid(), Name = "hiking", Duration = 3.5, ActivityLevel = ActivityLevel.High, IndoorOutdoor = IndoorOutdoor.Outdoor },
};
                context.AddRange(dates); // Add the dates to the context
                context.SaveChanges();
            }
        }
    }
}
