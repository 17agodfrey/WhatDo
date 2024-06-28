using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
//using GoogleApi.Entities.Places.Search.Text.Request;
//using GoogleApi.Entities.Places.Search.Text.Response;
//using GoogleApi;
using Google.Api.Gax.Grpc;
using Google.Maps.Places.V1;
using DateFinder.Domain.External;
using DateFinder.Domain.Api.Configuration;
using DateFinder.Domain.Storage;


namespace DateFinder.External
{
    public class GoogleMapsClient : IGoogleMapsClient
    {
        private readonly IDateFinderConfigurationSettings _dateFinderConfigurationSettings;
        public GoogleMapsClient(IDateFinderConfigurationSettings dateFinderConfigurationSettings)
        {
            _dateFinderConfigurationSettings = dateFinderConfigurationSettings;
        }

        public async Task<string> TextSearchAsync(Date date, string location)
        {
            PlacesClient client = PlacesClient.Create();

            // create query from date object
            string query = $"{date} in {location}";

            CallSettings callSettings = CallSettings.FromHeader("X-Goog-Api-Key", _dateFinderConfigurationSettings.GoogleMapsApiKey)
                .WithHeader("Content-Type", "applications/json")
                .WithHeader("X-Goog-FieldMask", "places.displayName,places.formattedAddress,places.priceLevel");
            SearchTextRequest request = new SearchTextRequest
            {
                TextQuery = query
            };
            SearchTextResponse response = await client.SearchTextAsync(request, callSettings);
            Console.WriteLine(response);

            var displayNames = response.Places
                .Where(place => !string.IsNullOrEmpty(place.DisplayName.ToString()))
                .Select(place => place.DisplayName)
                .Take(5) // Return only the first 5 results
                .ToList().ToString();

            // need to return whatever data the front end needs to render the map (id's and whatnot probably)
            // but for now lets just get the display names
            return displayNames;
        }
    }
}
