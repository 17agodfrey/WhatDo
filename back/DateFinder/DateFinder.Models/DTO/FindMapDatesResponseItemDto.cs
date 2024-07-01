using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DateFinder.Domain.DTO
{
    public class FindMapDatesResponseItemDto
    {
        [Required]
        public DateDto Date { get; set; }
        public List<FindMapDatesResultDto>? Results { get; set; }

    }
}
