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



namespace DateFinder.External
{
    public class GoogleMapsClient : IGoogleMapsClient
    {
        private readonly IDateFinderConfigurationSettings _dateFinderConfigurationSettings;
        private readonly PlacesClient _placesClient;
        public GoogleMapsClient(IDateFinderConfigurationSettings dateFinderConfigurationSettings)
        {
            _dateFinderConfigurationSettings = dateFinderConfigurationSettings;
            _placesClient = PlacesClient.Create();
        }

        // the base response from the places API, returning a list of places
        public async Task<SearchTextResponse> TextSearchAsync(Date date, FindMapDatesRequestDto findMapDatesRequestDto)
        {
            // create query from date object
            string query = $"{date.Name} in {findMapDatesRequestDto.Location}";


            CallSettings callSettings = CallSettings.FromHeader("X-Goog-Api-Key", _dateFinderConfigurationSettings.GoogleMapsApiKey)
                .WithHeader("Content-Type", "applications/json")
                .WithHeader("X-Goog-FieldMask",
                    "places.id," +
                    "places.displayName.text," + 
                    "places.editorialSummary," +
                    "places.priceLevel," +
                    "places.rating," +
                    "places.location," +
                    "places.photos,"
                ); // when adding more fields use commas 
            
            
            //if (findMapDatesRequestDto.Prices != null)
            //{
            //    callSettings = callSettings.WithHeader("X-Goog-FieldMask", "places.priceLevel");
            //}

            //if (findMapDatesRequestDto.Rating != null)
            //{
            //    callSettings = callSettings.WithHeader("X-Goog-FieldMask", "places.rating");
            //}

            SearchTextRequest request = new SearchTextRequest
            {
                TextQuery = query,
                MaxResultCount = 5,
            };

            SearchTextResponse response = await _placesClient.SearchTextAsync(request, callSettings);

            // Extract display names
            //var displayNames = response.Places
            //    .Where(place => !string.IsNullOrEmpty(place.DisplayName.ToString()))
            //    .Select(place => place.DisplayName.ToString())
            //    .ToList();

            return response;
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

            foreach (var photo in photos)
            {
                var nameParts = photo.Name.Split('/');
                if (nameParts.Length >= 4)
                {
                    var placeId = nameParts[1];
                    var photoReference = nameParts[3];

                    var photoResponse = await _placesClient.GetPhotoMediaAsync(new GetPhotoMediaRequest
                    {
                        PhotoMediaName = PhotoMediaName.FromPlacePhotoReference(placeId, photoReference),
                        MaxWidthPx = photo.WidthPx,
                        MaxHeightPx = photo.HeightPx
                    });

                    if (photoResponse != null)
                    {
                        photoUris.Add(photoResponse.PhotoUri);
                    }
                }
            }

            return photoUris;
        }
    }
}
