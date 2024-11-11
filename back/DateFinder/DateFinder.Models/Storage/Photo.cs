using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateFinder.Domain.Storage
{
    public class Photo
    {
        public string Name { get; set; }
        public int WidthPx { get; set; }
        public int HeightPx { get; set; }
        public string? PhotoUri { get; set; }
    }
}
