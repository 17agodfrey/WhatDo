using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using System.Diagnostics;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq.Expressions;
using DateFinder.External;
using DateFinder.Tests.Helpers;
using Google.Api.Gax.Grpc;
using Google.Maps.Places.V1;
using System.Collections;




namespace DateFinder.External.Tests
{
    public class GoogleMapsClientTests
    {
        private IGoogleMapsClient _systemUnderTest;
        public GoogleMapsClientTests()
        {
            var serviceProvider = (new DateFinderServiceProvider()).Create();

            _systemUnderTest = serviceProvider.GetService<IGoogleMapsClient>()
                ?? throw new InvalidOperationException("IGoogleMapsClient service not registered.");
        }

        public class TextSearchAsync : GoogleMapsClientTests
        {
            [Fact]
            public async Task Basic()
            {
                var response = await _systemUnderTest.TextSearchAsync("mini golf in Murray, Utah");
                Console.WriteLine(response);
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