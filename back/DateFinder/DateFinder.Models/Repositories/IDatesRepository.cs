using DateFinder.Domain.DTO;
using DateFinder.Domain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DateFinder.Domain.Repositories
{
    public interface IDatesRepository
    {
        Task<IEnumerable<Date>> GetAllAsync(Date date, (double, double)? duration);
        Task<IEnumerable<Date>> GetAllFromRequestAsync(DateRequestDto dateRequestDto);
        Task<Date?> GetByIdAsync(int id);
        Task AddAsync(Date entity);
        Task UpdateAsync(Date entity);
        Task DeleteAsync(int id);   
    }
}
