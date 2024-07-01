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
        public async Task<List<FindMapDatesResponseItemDto>> GetDatesAsync (FindMapDatesRequestDto findMapDatesRequestDto)
        {
            var dateDomainModel = _mapper.Map<Date>(findMapDatesRequestDto);
            // call the database - get dates (Date objects) according to the request
            var suggestedDates = await _datesRepository.GetAllAsync(dateDomainModel, findMapDatesRequestDto.DurationRange);
            // call the external API - using the dates (Date objects) from the database
            var dateResultsResponseItems = new List<FindMapDatesResponseItemDto>();

            foreach (var suggestedDate in suggestedDates)
            {
                // add the suggested date (from database) to the responseItem
                var findMapDatesResponseItemDto = new FindMapDatesResponseItemDto
                {
                    Date = _mapper.Map<DateDto>(suggestedDate)
                };
                var googleMapsResponse = await _googleMapsClient.TextSearchAsync(suggestedDate, findMapDatesRequestDto.Location);
                // Extract relevant fields from the Google response
                var findMapDatesResults = new List<FindMapDatesResultDto>();
                foreach (var place in googleMapsResponse.Places)
                {
                    if (!string.IsNullOrEmpty(place.DisplayName.ToString()))
                    {
                        var findMapDatesResultDto = new FindMapDatesResultDto
                        {
                            GoogleMapsId = place.Id,
                            DisplayName = place.DisplayName.Text
                        };
                        findMapDatesResults.Add(findMapDatesResultDto);
                    }
                }

                findMapDatesResponseItemDto.Results = findMapDatesResults;
                dateResultsResponseItems.Add(findMapDatesResponseItemDto);
            }
            // return the results (the remaining dates - findMapDatesResponse objects -
            // which will be what the front uses to do things - render stuff on map)
            return dateResultsResponseItems;
        }
    }
}
