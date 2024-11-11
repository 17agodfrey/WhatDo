using DateFinder.Domain.Storage;
using DateFinder.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DateFinder.Domain.Services;
using DateFinder.Domain.Repositories;
using AutoMapper;
using DateFinder.Domain.External;
using Microsoft.AspNetCore.Mvc;
using DateFinder.Domain.Storage.EnumAttributes;


namespace DateFinder.Services
{
    public class DateService : IDateService
    {
        private readonly IMapper _mapper;
        private readonly IDatesRepository _datesRepository;
        private readonly IGoogleMapsClient _googleMapsClient;

        public DateService(IMapper mapper, IDatesRepository datesRepository, IGoogleMapsClient googleMapsClient)
        {
            _mapper = mapper;
            _datesRepository = datesRepository;
            _googleMapsClient = googleMapsClient;
        }

        public async Task<List<FindMapDatesResponseItemDto>> GetMapResultsAsync(FindMapDatesRequestDto findMapDatesRequestDto)
        {
            // call the database - get dates (Date objects) according to the request
            //var suggestedDates = await _datesRepository.GetAllFromRequestAsync(findMapDatesRequestDto);
            var suggestedDates = new List<Date>();
            foreach (int dateId in findMapDatesRequestDto.DateIds)
            {
                var date = await _datesRepository.GetByIdAsync(dateId);
                if (date != null)
                {
                    suggestedDates.Add(date);
                }
            }

            foreach (Date date in suggestedDates)
            {
                Console.WriteLine("Date: " + date.Name);
            }

            // call the external API - using the dates (Date objects) from the database
            var dateResultsResponseItems = new List<FindMapDatesResponseItemDto>();

            foreach (var suggestedDate in suggestedDates)
            {
                // add the suggested date (from database) to the responseItem
                var findMapDatesResponseItemDto = new FindMapDatesResponseItemDto
                {
                    Date = _mapper.Map<DateDto>(suggestedDate)
                };
                var googleMapsResponse = await _googleMapsClient.TextSearchAsync(suggestedDate, findMapDatesRequestDto);

                Console.WriteLine("Google Maps Response: " + googleMapsResponse);

                // Extract relevant fields from the Google response
                var findMapDatesResults = new List<FindMapDatesResultDto>();
                foreach (var place in googleMapsResponse.Places)
                {
                    if (place.DisplayName != null)
                    {
                        //if ((findMapDatesRequestDto.PriceLevels != null && !findMapDatesRequestDto.PriceLevels.Contains((Price)place.PriceLevel))
                        //    || (findMapDatesRequestDto.Rating != null && !(findMapDatesRequestDto.Rating >= place.Rating))
                        //)
                        //{
                        //    continue;
                        //}
                        var findMapDatesResultDto = new FindMapDatesResultDto
                        {
                            GoogleMapsId = place.Id,
                            DisplayName = place.DisplayName.Text,
                            DateType = suggestedDate.Name,
                            Description = place.EditorialSummary?.Text,
                            PriceLevel = place.PriceLevel.ToString() != null ? place.PriceLevel.ToString() : null,
                            Rating = place.Rating.ToString() != null ? place.Rating : null,
                            LatLng = new LatLngDto
                            {
                                Latitude = place.Location.Latitude,
                                Longitude = place.Location.Longitude
                            },
                            Photos = place.Photos?.Select(p => new Photo
                            {
                                Name = p.Name,
                                WidthPx = p.WidthPx,
                                HeightPx = p.HeightPx,
                                //PhotoUri = p.getURI().ToString()
                            }).ToArray()
                        };

                        /// soooo... bascialyl 
                        //if (findMapDatesResultDto.Photos != null)
                        //{
                        //    var photos = await _googleMapsClient.GetPlacePhotos(findMapDatesResultDto.Photos);
                        //    findMapDatesResultDto.PhotosUris = photos;
                        //}
                        findMapDatesResults.Add(findMapDatesResultDto);
                    }
                }
                findMapDatesResponseItemDto.Results = findMapDatesResults;
                dateResultsResponseItems.Add(findMapDatesResponseItemDto);
            }
            // return the results (the remaining dates - findMapDatesResponse objects -
            // which will be what the front uses to do things - render stuff on map)
            Console.WriteLine("from service: ", dateResultsResponseItems);
            return dateResultsResponseItems;
        }

        public async Task<IEnumerable<Date>> GetDateIdeasAsync(DateRequestDto dateRequestDto)
        {
            var suggestedDates = await _datesRepository.GetAllFromRequestAsync(dateRequestDto);

            return suggestedDates;
        }
    }
}
