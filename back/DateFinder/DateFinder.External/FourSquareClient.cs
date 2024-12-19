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
using Newtonsoft.Json;



namespace DateFinder.External
{
    public class FourSquareClient : IFourSquareClient
    {
        private readonly IDateFinderConfigurationSettings _dateFinderConfigurationSettings;
        private readonly HttpClient _httpClient;

        public FourSquareClient(IDateFinderConfigurationSettings dateFinderConfigurationSettings, HttpClient httpClient)
        {

            _dateFinderConfigurationSettings = dateFinderConfigurationSettings;
            _httpClient = httpClient;
        }

        // the base response from the places API, returning a list of places
        public async Task<List<PlaceSearchResultDto>> PlacesSearchAsync(Date date, FindMapDatesRequestDto findMapDatesRequestDto)
        {
            // Construct the API URL for the Foursquare Places Search API
            string apiKey = _dateFinderConfigurationSettings.FourSquareApiKey;
            string searchKeyword = date.Name; // 'date.Name' is something like "golf" or "zoo"
            double latitude = findMapDatesRequestDto.LatLng.Latitude;
            double longitude = findMapDatesRequestDto.LatLng.Longitude;

            // Set the radius (adjustable based on your needs, e.g., 500 meters or 1 km)
            int radius = 1000; // 1000 meters

            // Foursquare API Endpoint
            string url = $"https://api.foursquare.com/v2/venues/search?ll={latitude},{longitude}&query={searchKeyword}&radius={radius}&client_id={apiKey}&v=20231111";

            // Send GET request to Foursquare API
            var response = await _httpClient.GetAsync(url);

            // Ensure a successful response
            response.EnsureSuccessStatusCode();

            // Read the response content as a string
            var content = await response.Content.ReadAsStringAsync();

            // Deserialize the response into a dynamic object
            dynamic foursquareResponse = JsonConvert.DeserializeObject(content);

            // Extract venues directly from the response
            var venues = foursquareResponse.response.results;

            // Map Foursquare response to a list of PlaceSearchResultDto
            var placeSearchResultDtos = new List<PlaceSearchResultDto>();

            foreach (var venue in venues)
            {
                var placeSearchResultDto = new PlaceSearchResultDto
                {
                    Location = new LocationDto
                    {
                        Latitude = venue.location.lat,
                        Longitude = venue.location.lng,
                        Address = venue.location.address
                    },
                    Distance = venue.location.distance ?? 0, // Default to 0 if Distance is null
                    ClosedBucket = venue.location.isClosed ?? false,
                    Description = venue.description ?? string.Empty,
                    Website = venue.url ?? string.Empty,
                    Rating = venue.rating ?? 0,
                    Popularity = venue.popularity ?? 0,
                    Stats = new StatsDto
                    {
                        CheckinsCount = venue.stats.checkinsCount ?? 0,
                        TipCount = venue.stats.tipCount ?? 0,
                        UserCount = venue.stats.userCount ?? 0
                    },
                    Photos = venue.photos?.group != null
                    ? ((IEnumerable<dynamic>)venue.photos.group)
                        .Select(photo => new PhotoDto
                        {
                            Url = photo.url,
                            Description = photo.description ?? string.Empty
                        })
                        .ToList()
                    : new List<PhotoDto>(),
                    Hours = new HoursDto
                    {
                        Status = venue.hours?.status ?? string.Empty,
                        OpenTimes = venue.hours?.openTimes ?? new List<string>()
                    },
                    HoursPopular = new HoursPopularDto
                    {
                        PopularHours = venue.hoursPopular?.popularHours ?? new List<string>()
                    }
                };

                placeSearchResultDtos.Add(placeSearchResultDto);
            }

            return placeSearchResultDtos;
        }
    }
}
