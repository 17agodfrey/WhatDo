using System;
//using DateFinder.Api.Configuration;
//using DateFinder.Domain.Configuration;
//using DateFinder.Domain.DataLayer;
using DateFinder.Tests.Fakes;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Microsoft.Extensions.Configuration;

namespace DateFinder.Tests.Helpers
{
    public class DateFinderServiceProvider
    {
        public IServiceProvider Create()
        {
            var container = new ServiceCollection();
            (new DateFinderServiceCollection()).ConfigureServices(container);

            RegisterAll(container);

            var serviceProvider = container.BuildServiceProvider();

            return serviceProvider;
        }

        private void RegisterAll(IServiceCollection serviceCollection)
        {
            RegisterMemoryFake(serviceCollection);
        }

        private void RegisterMemoryFake(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IDateFinderStorage, MemoryDateFinderStorage>();
        }
    }
}
