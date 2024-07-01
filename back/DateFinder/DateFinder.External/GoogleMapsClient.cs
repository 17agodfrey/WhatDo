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
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;



namespace DateFinder.External
{
    public class GoogleMapsClient : IGoogleMapsClient
    {
        private readonly IDateFinderConfigurationSettings _dateFinderConfigurationSettings;
        public GoogleMapsClient(IDateFinderConfigurationSettings dateFinderConfigurationSettings)
        {
            _dateFinderConfigurationSettings = dateFinderConfigurationSettings;
        }

        // the base response from the places API, returning a list of places
        public async Task<SearchTextResponse> TextSearchAsync(Date date, string location)
        {
            PlacesClient client = PlacesClient.Create();

            // create query from date object
            string query = $"{date.Name} in {location}";

            CallSettings callSettings = CallSettings.FromHeader("X-Goog-Api-Key", _dateFinderConfigurationSettings.GoogleMapsApiKey)
                .WithHeader("Content-Type", "applications/json")
                .WithHeader("X-Goog-FieldMask", "places.id,places.displayName.text"); // when adding more fields use commas 

            SearchTextRequest request = new SearchTextRequest
            {
                TextQuery = query,
                MaxResultCount = 5
            };
            SearchTextResponse response = await client.SearchTextAsync(request, callSettings);

            // Extract display names
            //var displayNames = response.Places
            //    .Where(place => !string.IsNullOrEmpty(place.DisplayName.ToString()))
            //    .Select(place => place.DisplayName.ToString())
            //    .ToList();

            return response;
        }
    }
}
