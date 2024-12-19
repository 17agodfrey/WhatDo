using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


// returns a single Date (a type of date) and a list of places that match the date

namespace DateFinder.Domain.DTO
{
    public class FindMapDatesResponseItemDto
    {
        [Required]
        public DateDto Date { get; set; }
        public List<PlaceSearchResultDto>? Results { get; set; }

    }
}
