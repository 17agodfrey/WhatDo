using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DateFinder.Domain.Storage.EnumAttributes
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum IndoorOutdoor
    {
        Indoor,
        Outdoor,
        Any
    }
}
