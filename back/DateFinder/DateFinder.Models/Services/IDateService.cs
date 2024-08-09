using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DateFinder.Domain.Storage;
using DateFinder.Domain.DTO;

namespace DateFinder.Domain.Services
{
    public interface IDateService
    {
        Task<List<FindMapDatesResponseItemDto>> GetMapResultsAsync(FindMapDatesRequestDto findMapDatesRequestDto);
        Task<IEnumerable<Date>> GetDateIdeasAsync(DateRequestDto dateRequestDto);

    }
}
