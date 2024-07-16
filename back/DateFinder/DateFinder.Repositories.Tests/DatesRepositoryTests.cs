using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;
using DateFinder.Domain.Repositories;
using DateFinder.Tests.Helpers;
using DateFinder.Domain.Storage;
using DateFinder.Domain.Storage.EnumAttributes;




namespace DateFinder.Repositories.Tests
{
    public class DatesRepositoryTests
    {
        private readonly ITestOutputHelper _output;
        private IDatesRepository _systemUnderTest;

        public DatesRepositoryTests(ITestOutputHelper output)
        {
            _output = output;

            var serviceProvider = (new DateFinderServiceProvider()).Create();

            _systemUnderTest = serviceProvider.GetService<IDatesRepository>()
                ?? throw new InvalidOperationException("IDatesRepository service not registered.");
        }

        public class GetAllAsync : DatesRepositoryTests
        {
            public GetAllAsync(ITestOutputHelper output) : base(output) { }

            [Fact]
            public async Task WHEN_GetAllAsync_is_called_THEN_results_not_empty()
            {
                // Arrange
                var date = new Date
                {
                    //Price = "$$",
                    //Rating = "4",
                    ActivityLevel = ActivityLevel.High,
                    //IndoorOutdoor = IndoorOutdoor.Outdoor
                };

                (double, double) duration = (1.0, 5.0);

                // Act
                var result = await _systemUnderTest.GetAllAsync(date, duration);

                foreach (var dateResult in result)
                {
                    _output.WriteLine(dateResult.Name);
                }

                // Assert
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }

            // test adding a date and then another test to see if its there to see if 
            // it actually isolates tests
        }
    }
}