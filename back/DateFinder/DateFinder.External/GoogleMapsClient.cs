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
using DateFinder.Domain.DTO;
using Google.Protobuf.Collections;
using DateFinder.Domain.Storage.EnumAttributes;
using Microsoft.Extensions.Logging;
using System.Collections;
using Newtonsoft.Json;



namespace DateFinder.External
{
    public class GoogleMapsClient : IGoogleMapsClient
    {
        private readonly IDateFinderConfigurationSettings _dateFinderConfigurationSettings;
        private readonly HttpClient _httpClient;
        private readonly ILogger<GoogleMapsClient> _logger;

        public GoogleMapsClient(IDateFinderConfigurationSettings dateFinderConfigurationSettings, ILogger<GoogleMapsClient> logger, HttpClient httpClient)
        {
            _dateFinderConfigurationSettings = dateFinderConfigurationSettings;
            _logger = logger;
            _httpClient = httpClient;
        }

        // the base response from the places API, returning a list of places
        // the base response from the places API, returning a list of places
        public async Task<SearchTextResponse> TextSearchAsync(Date date, FindMapDatesRequestDto findMapDatesRequestDto)
        {
            // create query from date object
            string query = $"{date.Name} in {findMapDatesRequestDto.Location}";

            var requestBody = new
            {
                textQuery = query,
                maxResultCount = 1
            };

            var jsonRequestBody = JsonConvert.SerializeObject(requestBody);
            var apiKey = _dateFinderConfigurationSettings.GoogleMapsApiKey;
            var fields = "" +
                "places.id," +
                "places.displayName.text," +
                "places.editorialSummary," +
                "places.priceLevel," +
                "places.rating," +
                "places.location," +
                "places.photos";
            var url = $"https://places.googleapis.com/v1/places:searchText?fields={fields}&key={apiKey}";

            var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

            try
            {
                _logger.LogInformation("Sending request to Google Places API with query: {Query}", query);
                var response = await _httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("Received response from Google Places API: {ResponseBody}", responseBody);

                // Deserialize the response to SearchTextResponse
                var searchTextResponse = JsonConvert.DeserializeObject<SearchTextResponse>(responseBody);
                return searchTextResponse;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error occurred while calling Google Places API");
                throw;
            }
        }

        /// <summary>
        /// gets photo uri's from google places api from a list of photo names.
        /// names are used to build a url to call google api for the uri's
        /// </summary>
        /// <param name="photos"></param>
        /// <returns></returns>
        public async Task<List<string>> GetPlacePhotoUris(Domain.Storage.Photo[] photos)
        {
            var photoUris = new List<string>();
            var apiKey = _dateFinderConfigurationSettings.GoogleMapsApiKey;

            foreach (var photo in photos)
            {
                var nameParts = photo.Name.Split('/');
                if (nameParts.Length >= 4)
                {
                    var placeId = nameParts[1];
                    var photoReference = nameParts[3];

                    var url = $"https://maps.googleapis.com/maps/api/place/photo?maxwidth={photo.WidthPx}&maxheight={photo.HeightPx}&placeid={placeId}&photoreference={photoReference}&key={apiKey}";

                    try
                    {
                        _logger.LogInformation("Sending request to Google Places API for photo reference: {PhotoReference}", photoReference);
                        var response = await _httpClient.GetAsync(url);
                        response.EnsureSuccessStatusCode();

                        var photoUri = response.RequestMessage.RequestUri.ToString();
                        _logger.LogInformation("Received photo URI from Google Places API: {PhotoUri}", photoUri);

                        photoUris.Add(photoUri);
                    }
                    catch (HttpRequestException ex)
                    {
                        _logger.LogError(ex, "Error occurred while calling Google Places API for photo reference: {PhotoReference}", photoReference);
                    }
                }
            }

            return photoUris;
        }
    }
}
