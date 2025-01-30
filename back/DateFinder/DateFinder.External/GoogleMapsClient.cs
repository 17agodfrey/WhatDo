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
using Google.Apis.Auth.OAuth2;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Auth;



namespace DateFinder.External
{
    public class GoogleMapsClient : IGoogleMapsClient
    {
        private readonly IDateFinderConfigurationSettings _dateFinderConfigurationSettings;
        private PlacesClient? _placesClient;
        private readonly ILogger<GoogleMapsClient> _logger;

        public GoogleMapsClient(IDateFinderConfigurationSettings dateFinderConfigurationSettings, ILogger<GoogleMapsClient> logger)
        //public GoogleMapsClient(IDateFinderConfigurationSettings dateFinderConfigurationSettings)
        {
            _dateFinderConfigurationSettings = dateFinderConfigurationSettings;
            _logger = logger;


            // Explicitly use API key
            //_placesClient = new PlacesClientBuilder
            //{
            //    Settings = new PlacesSettings
            //    {
            //        CallSettings = CallSettings.FromHeader("X-Goog-Api-Key", _dateFinderConfigurationSettings.GoogleMapsApiKey)
            //    }
            //}.Build();

            //_placesClient = PlacesClient.Create();

            // Load service account credentials from JSON file

            //GoogleCredential credential;
            //using (var stream = new FileStream("clientLibraryConfig-aws-provider.json", FileMode.Open, FileAccess.Read))
            //{
            //    credential = GoogleCredential.FromStream(stream)
            //        //.CreateScoped("https://www.googleapis.com/auth/maps-platform.places");
            //        .CreateScoped("https://www.googleapis.com/auth/cloud-platform");

            //}

            // Create PlacesClient with the credentials
            //_placesClient = new PlacesClientBuilder
            //{
            //    ChannelCredentials = credential.ToChannelCredentials()
            //}.Build();



            try
            {
                GoogleCredential credential;
                string filePath = @"clientLibraryConfig-aws-provider.json";

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    _logger.LogError($"The file '{filePath}' was not found.");
                    throw new FileNotFoundException($"The file '{filePath}' was not found.");
                }

                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    credential = GoogleCredential.FromStream(stream)
                        .CreateScoped("https://www.googleapis.com/auth/cloud-platform");
                }

                //GoogleCredential credential = GoogleCloudAuth.CreateGoogleCredential();

                _placesClient = new PlacesClientBuilder
                {
                    ChannelCredentials = credential.ToChannelCredentials()
                }.Build();

                //LogCredentialInformation(credential);

                _logger.LogInformation("PlacesClient initialized successfully.");
                Console.WriteLine("PlacesClient initialized successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing PlacesClient: {ex.Message}");
            }
        }



        // print awsCallerIdentity using http client
        private async void LogAwsCallerIdentity()
        {
            using (var httpClient = new HttpClient())
            {
                string awsCallerIdentity = await httpClient.GetStringAsync("https://sts.amazonaws.com?Action=GetCallerIdentity&Version=2011-06-15");
                _logger.LogInformation($"AWS Caller Identity: {awsCallerIdentity}");
            }
        }

        //private void LogCredentialInformation(GoogleCredential credential)
        //{
        //    _logger.LogInformation("Credential Information:");
        //    _logger.LogInformation($"Audience: {credential.}");
        //    _logger.LogInformation($"SubjectToken: {credential.SubjectToken}");
        //    _logger.LogInformation($"TokenUrl: {credential.TokenUrl}");
        //    _logger.LogInformation($"CredentialSource: {credential.CredentialSource}");
        //    _logger.LogInformation($"ServiceAccountImpersonationUrl: {credential.ServiceAccountImpersonationUrl}");
        //}






        // the base response from the places API, returning a list of places
        public async Task<SearchTextResponse> TextSearchAsync(Date date, FindMapDatesRequestDto findMapDatesRequestDto)
        {
            // create query from date object
            string query = $"{date.Name} in {findMapDatesRequestDto.Location}";


            //CallSettings callSettings = CallSettings.FromHeader("X-Goog-Api-Key", _dateFinderConfigurationSettings.GoogleMapsApiKey)
            CallSettings callSettings = CallSettings
                .FromHeader("Content-Type", "applications/json")
                .WithHeader("X-Goog-FieldMask",
                    "places.id," +
                    "places.displayName.text," + 
                    "places.editorialSummary," +
                    "places.priceLevel," +
                    "places.rating," +
                    "places.location," +
                    "places.photos,"
                ); // when adding more fields use commas 
            
            SearchTextRequest request = new SearchTextRequest
            {
                TextQuery = query,
                MaxResultCount = 1,
            };

            //SearchTextResponse response = await _placesClient.SearchTextAsync(request, callSettings);

            try
            {
                LogAwsCallerIdentity();
                SearchTextResponse response = await _placesClient.SearchTextAsync(request, callSettings);
                return response;
                //throw new Exception("yea, yea, yea, ok");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while calling SearchTextAsync with query: {Query}", query);
                throw; // Re-throw the exception after logging it
            }

            //return response;
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
