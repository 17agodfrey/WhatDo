using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq.Expressions;
using DateFinder.External;
using DateFinder.Tests.Helpers;
using Google.Api.Gax.Grpc;
using Google.Maps.Places.V1;
using System.Collections;
using DateFinder.Domain.External;
using Xunit.Abstractions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Text.Json;




namespace DateFinder.External.Tests
{
    public class GoogleMapsClientTests
    {
        private readonly ITestOutputHelper _output;
        private IGoogleMapsClient _systemUnderTest;
        public GoogleMapsClientTests(ITestOutputHelper output)
        {
            _output = output;

            var serviceProvider = (new DateFinderServiceProvider()).Create();

            _systemUnderTest = serviceProvider.GetService<IGoogleMapsClient>()
                ?? throw new InvalidOperationException("IGoogleMapsClient service not registered.");
            
        }

        public class TextSearchAsync : GoogleMapsClientTests
        {
            public TextSearchAsync(ITestOutputHelper output) : base(output) { }

            [Fact]
            public async Task Basic()
            {
                var response = await _systemUnderTest.TextSearchAsync("mini golf in Murray, Utah");
                var responseJson = JsonSerializer.Serialize(response, new JsonSerializerOptions { WriteIndented = true });

                _output.WriteLine(responseJson);
                Assert.True(response != null);
            }

            //[Fact]
            //public async Task WHEN_SendMessageAsync_is_called_THEN_response_is_NOT_NULL()
            //{
            //    var response = await _systemUnderTest.TextSearchAsync("mini golf in Murray, Utah");

            //    Assert.True(response != null);
            //}
        }
    }
}