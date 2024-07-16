using DateFinder.Domain.Storage;
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
        public DurationRange? DurationRange { get; set; } // Date
        public Price[]? PriceLevels { get; set; } 
        public double? Rating { get; set; } // needs to be between 1.0 and 5.0
        public ActivityLevel[]? ActivityLevels { get; set; } // Date
        public IndoorOutdoor[]? IndoorOutdoor { get; set; } // Date

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get; set; }
    }
}
