using DateFinder.Domain.Storage.EnumAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateFinder.Domain.Storage
{
    // the date as it appears in the database 
    public class Date
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string? Description { get; set; } 
        public double Duration { get; set; } // Duration (1.0 to 5.0 by .5 intervals)
        //public Price? Price { get; set; }
        //public string? Rating { get; set; }
        public ActivityLevel? ActivityLevel { get; set; } // Low/Medium/High
        public IndoorOutdoor? IndoorOutdoor { get; set; } // Indoor/Outdoor/Both

    }
}
