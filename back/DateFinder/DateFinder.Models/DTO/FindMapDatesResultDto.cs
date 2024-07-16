using DateFinder.Domain.Storage;
using DateFinder.Domain.Storage.EnumAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateFinder.Domain.DTO
{
    public class FindMapDatesResultDto
    {
        // these should all be fields from google api response
        public string GoogleMapsId { get; set; }
        public string DisplayName { get; set; }
        public string? Description { get; set; }
        public string? PriceLevel { get; set; }
        public double? Rating { get; set; }
        public LatLngDto? LatLng { get; set; }
        public Photo[]? Photos { get; set; }
        public List<string>? PhotosUris { get; set; }
    }
}
