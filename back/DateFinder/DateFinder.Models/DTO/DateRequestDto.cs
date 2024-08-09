using DateFinder.Domain.Storage.EnumAttributes;
using DateFinder.Domain.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DateFinder.Domain.DTO
{
    public class DateRequestDto
    {
        [Required(ErrorMessage = "Setting is required.")]
        public IndoorOutdoor[]? IndoorOutdoor { get; set; } // Date

        [Required(ErrorMessage = "Duration is required.")]
        public DurationRange DurationRange { get; set; } // Date
        [Required(ErrorMessage = "Activity Level is required.")]
        public ActivityLevel[]? ActivityLevels { get; set; } // Date

        //public Price[]? PriceLevels { get; set; }
        //public double? Rating { get; set; } // needs to be between 1.0 and 5.0

    }
}
