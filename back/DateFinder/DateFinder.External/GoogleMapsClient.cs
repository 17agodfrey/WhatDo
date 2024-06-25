using Microsoft.AspNetCore.Http;
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


namespace DateFinder.External
{
    public class GoogleMapsClient : IGoogleMapsClient
    {
        private GoogleMapsSettings _googleMapsSettings;

        public GoogleMapsClient(IOptions<GoogleMapsSettings> googleMapsSettings)
        {
            _googleMapsSettings = googleMapsSettings.Value;
        }

        public async Task<string> TextSearchAsync(string query)
        {
            PlacesClient client = PlacesClient.Create();
            CallSettings callSettings = CallSettings.FromHeader("X-Goog-Api-Key", _googleMapsSettings.ApiKey)
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

            return displayNames;
        }
    }
}
