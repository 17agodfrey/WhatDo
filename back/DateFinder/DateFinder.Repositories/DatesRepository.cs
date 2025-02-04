using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateFinder.Domain.DTO;
using DateFinder.Domain.Storage;
using DateFinder.Domain.Repositories;
using DateFinder.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using DateFinder.Domain.Storage.EnumAttributes;

namespace DateFinder.Repositories
{
    public class DatesRepository : IDatesRepository
    {
        private DateFinderDbContext _context;

        public DatesRepository(DateFinderDbContext context) 
        {
            _context = context;
        }

        public Task AddAsync(Date entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Date>> GetAllAsync(Date date, (double, double)? durationRange = null)
        {
            var query = _context.Dates.AsQueryable();

            if (durationRange != null)
            {
                query = query.Where(d => d.Duration >= durationRange.Value.Item1 && d.Duration <= durationRange.Value.Item2);
            }

            if (date.ActivityLevel.HasValue)
            {
                query = query.Where(d => d.ActivityLevel == date.ActivityLevel);
            }

            if (date.IndoorOutdoor.HasValue)
            {
                query = query.Where(d => d.IndoorOutdoor == date.IndoorOutdoor);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Date>> GetAllFromRequestAsync(DateRequestDto dateRequestDto)
        {
            Console.WriteLine($"DbContext instance hash code: {_context.GetHashCode()}");

            try
            {
                var query = _context.Dates.AsQueryable();



                if (dateRequestDto.IndoorOutdoor != null && dateRequestDto.IndoorOutdoor.Any())
                {
                    if (dateRequestDto.IndoorOutdoor.Contains(IndoorOutdoor.Any))
                    {
                        query = query.Where(d => d.IndoorOutdoor != null); // dates where Indoor or Outdoor is not null (all)
                    }
                    else
                    {
                        query = query.Where(d => dateRequestDto.IndoorOutdoor.Contains(d.IndoorOutdoor.Value) || (d.IndoorOutdoor.Value == IndoorOutdoor.Any));
                    }

                }

                if (dateRequestDto.DurationRange != null) // Start and End required in DurationRange
                {
                    var minDuration = dateRequestDto.DurationRange.Min;
                    var maxDuration = dateRequestDto.DurationRange.Max;
                    query = query.Where(d => d.Duration >= minDuration && d.Duration <= maxDuration);
                }

                //if (findMapDatesRequestDto.Prices != null && findMapDatesRequestDto.Prices.Any())
                //{
                //    query = query.Where(d => findMapDatesRequestDto.Prices.Contains(d.Price));
                //}

                //if (findMapDatesRequestDto.Ratings != null && findMapDatesRequestDto.Ratings.Any())
                //{
                //    query = query.Where(d => findMapDatesRequestDto.Ratings.Contains(d.Rating));
                //}

                if (dateRequestDto.ActivityLevels != null && dateRequestDto.ActivityLevels.Any())
                {
                    query = query.Where(d => dateRequestDto.ActivityLevels.Contains(d.ActivityLevel.Value));
                }

                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error getting date ideas: {e.Message}");
                throw;
            }
        }

        public async Task<Date?> GetByIdAsync(int id)
        {
            return await _context.Dates.FirstOrDefaultAsync(d => d.Id == id);

        }

        public Task UpdateAsync(Date entity)
        {
            throw new NotImplementedException();
        }
    }
}
