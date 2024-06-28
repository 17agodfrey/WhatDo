using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DateFinder.Domain.Storage.EnumAttributes;

namespace DateFinder.Domain.DTO
{
    public class DateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double? Duration { get; set; } // Duration (1.0 to 5.0 by .5 intervals)
        public string? Price { get; set; }
        public string? Rating { get; set; }
        public ActivityLevel? ActivityLevel { get; set; } // Low/Medium/High
        public IndoorOutdoor? IndoorOutdoor { get; set; } // Indoor/Outdoor/Both
    }
}
