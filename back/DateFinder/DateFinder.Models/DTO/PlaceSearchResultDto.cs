using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateFinder.Domain.DTO
{
    public class PlaceSearchResultDto
    {
        // Core data
        public LocationDto Location { get; set; } // Nested Location class for structured data
        public double Distance { get; set; } // Distance (could be in meters, depending on the API response)
        public bool ClosedBucket { get; set; } // Assuming this is a boolean indicating the status of the location

        // Rich data
        public string Description { get; set; } // Description of the place
        public string Website { get; set; } // Website URL of the place
        public HoursDto Hours { get; set; } // Nested Hours class for structured data
        public HoursPopularDto HoursPopular { get; set; } // Nested HoursPopular class for structured data
        public double Rating { get; set; } // Rating value, can be decimal
        public StatsDto Stats { get; set; } // Nested Stats class for structured data
        public int Popularity { get; set; } // Popularity score
        public List<PhotoDto> Photos { get; set; } // List of photos, assuming each photo is a separate object
    }

    // Define supporting classes for structured data
    public class LocationDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; } // You can include more fields based on the location object from the API
    }

    public class HoursDto
    {
        public string Status { get; set; } // "Open" or "Closed"
        public List<string> OpenTimes { get; set; } // List of open times, e.g., ["9:00 AM", "6:00 PM"]
    }

    public class HoursPopularDto
    {
        public List<string> PopularHours { get; set; } // List of popular hours
    }

    public class StatsDto
    {
        public int CheckinsCount { get; set; } // Number of check-ins
        public int TipCount { get; set; } // Number of tips
        public int UserCount { get; set; } // Number of users
    }

    public class PhotoDto
    {
        public string Url { get; set; } // URL to the photo
        public string Description { get; set; } // Optional description for the photo
    }
}
