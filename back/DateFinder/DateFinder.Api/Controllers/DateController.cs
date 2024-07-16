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
        public async Task<IActionResult> Get([FromQuery] FindMapDatesRequestDto findMapDatesRequestDto)
        {
            // call the service 
            var mapDatesResponse = await _dateService.GetDatesAsync(findMapDatesRequestDto);
            // return the JSON result
            //var jsonResult = JsonSerializer.Serialize(mapDatesResponse);

            //Console.WriteLine("u called api/date, good job. Here's the result:\n", map);
            return Ok(mapDatesResponse);
        }
    }
}
