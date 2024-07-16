using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DateFinder.Domain.Storage;
using Microsoft.AspNetCore.Mvc;
using Google.Maps.Places.V1;
using DateFinder.Domain.DTO;



namespace DateFinder.Domain.External
{
    public interface IGoogleMapsClient
    {
        // text search: given a query, return a list of places, displayName only, the first 5
        Task<SearchTextResponse> TextSearchAsync(Date date, FindMapDatesRequestDto findMapDatesRequestDto);
        Task<List<string>> GetPlacePhotos(Storage.Photo[] names);
    }
}
