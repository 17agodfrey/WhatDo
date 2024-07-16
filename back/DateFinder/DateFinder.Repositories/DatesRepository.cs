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

        public async Task<IEnumerable<Date>> GetAllFromRequestAsync(FindMapDatesRequestDto findMapDatesRequestDto)
        {
            var query = _context.Dates.AsQueryable();

            if (findMapDatesRequestDto.DurationRange != null) // Start and End required in DurationRange
            {
                var minDuration = findMapDatesRequestDto.DurationRange.Min;
                var maxDuration = findMapDatesRequestDto.DurationRange.Max;
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

            if (findMapDatesRequestDto.ActivityLevels != null && findMapDatesRequestDto.ActivityLevels.Any())
            {
                query = query.Where(d => findMapDatesRequestDto.ActivityLevels.Contains(d.ActivityLevel.Value));
            }

            if (findMapDatesRequestDto.IndoorOutdoor != null && findMapDatesRequestDto.IndoorOutdoor.Any())
            {
                query = query.Where(d => findMapDatesRequestDto.IndoorOutdoor.Contains(d.IndoorOutdoor.Value));
            }

            return await query.ToListAsync();
        }

        public Task<Date> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Date entity)
        {
            throw new NotImplementedException();
        }
    }
}
