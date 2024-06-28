using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Date>> GetAllAsync(Date date, Tuple<double, double>? durationRange = null)
        {
            var query = _context.Dates.AsQueryable();

            if (durationRange != null)
            {
                query = query.Where(d => d.Duration >= durationRange.Item1 && d.Duration <= durationRange.Item2);
            }

            if (!string.IsNullOrEmpty(date.Price))
            {
                query = query.Where(d => d.Price == date.Price);
            }

            if (!string.IsNullOrEmpty(date.Rating))
            {
                query = query.Where(d => d.Rating == date.Rating);
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
