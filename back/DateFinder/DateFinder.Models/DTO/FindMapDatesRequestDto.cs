using DateFinder.Domain.Storage.EnumAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateFinder.Domain.DTO
{
    public class FindMapDatesRequestDto
    {
        public Tuple<double, double>? DurationRange { get; set; }
        public string? Price { get; set; }
        public string? Rating { get; set; }
        public ActivityLevel? ActivityLevel { get; set; }
        public IndoorOutdoor? IndoorOutdoor { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }
    }
}
