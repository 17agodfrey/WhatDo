using AutoMapper;
using DateFinder.Domain.DTO;
using DateFinder.Domain.Storage;
using DateFinder.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json;

namespace DateFinder.Api.Controllers
{
    //https://localhost:1234/api/date
    [Route("api/date")]
    [ApiController]
    public class DateController : ControllerBase
    {
        private readonly IDateService _dateService;

        // use / import services here, its those services that will actually call the external API and talk to our database 
        public DateController(IDateService dateService)
        {
            _dateService = dateService;
        }

        // GET TEXT SEARCH RESULTS 
        // GET api/date
        [HttpGet]
        [Route("map-dates")]
        public async Task<IActionResult> GetMapResults([FromQuery] FindMapDatesRequestDto findMapDatesRequestDto)
        {
            Console.WriteLine("\n\n\n\n\n\n\napi/map-dates hit\n\n\n\n\n\n\nrequest: ", findMapDatesRequestDto);
            //Console.WriteLine("\n\n\n\n\n\n\napi/map-dates hit\n\n\n\n\n\n\nrequest date ideas: ", findMapDatesRequestDto.DateIdeas[0]);
            Console.WriteLine("\n\n\n\n\n\n\napi/map-dates hit\n\n\n\n\n\n\ndate ideas number: ", findMapDatesRequestDto.DateIds.Length);

            // call the service 
            var mapDatesResponse = await _dateService.GetMapResultsAsync(findMapDatesRequestDto);
            // return the JSON result
            //var jsonResult = JsonSerializer.Serialize(mapDatesResponse);

            Console.WriteLine("\n\n\n\n\n\n\napi/map-dates hit\n\n\n\n\n\n\nresponse: ", mapDatesResponse);
            return Ok(mapDatesResponse);
        }

        [HttpGet]
        [Route("date-ideas")]
        public async Task<IActionResult> GetDateIdeas([FromQuery] DateRequestDto dateRequestDto)
        {
            Console.WriteLine("\n\n\n\n\n\n\napi/date-ideas hit\n\n\n\n\n\n\nrequest: ", dateRequestDto);

            // Call the service to get the date ideas
            var dateIdeasResponse = await _dateService.GetDateIdeasAsync(dateRequestDto);

            // Return the JSON result
            return Ok(dateIdeasResponse);
        }

    }

}
