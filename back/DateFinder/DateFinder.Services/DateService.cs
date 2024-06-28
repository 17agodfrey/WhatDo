using DateFinder.Domain.Storage;
using DateFinder.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateFinder.Domain.Services;
using DateFinder.Domain.Repositories;
using AutoMapper;
using DateFinder.Domain.External;
using Microsoft.AspNetCore.Mvc;


namespace DateFinder.Services
{
    internal class DateService : IDateService
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
        public async Task<List<string>> GetDatesAsync (FindMapDatesRequestDto findMapDatesRequestDto)
        {
            var dateDomainModel = _mapper.Map<Date>(findMapDatesRequestDto);
            // call the database - get dates (Date objects) according to the request
            var suggestedDates = await _datesRepository.GetAllAsync(dateDomainModel, findMapDatesRequestDto.DurationRange);
            // call the external API - using the dates (Date objects) from the database
            var dateResults = new List<string>();
            foreach (var suggestedDate in suggestedDates)
            {
                var response = await _googleMapsClient.TextSearchAsync(suggestedDate, findMapDatesRequestDto.Location)
                dateResults.Add(response);
            }


            // return the results (the remaining dates - findMapDatesResponse objects -
            // which will be what the front uses to do things - render stuff on map)
            return dateResults;
        }
    }
}
