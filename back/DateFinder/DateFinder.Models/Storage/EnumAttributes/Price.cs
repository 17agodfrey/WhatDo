using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DateFinder.Domain.Storage.EnumAttributes
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Price
    {
        PRICE_LEVEL_UNSPECIFIED,
        PRICE_LEVEL_FREE,
        PRICE_LEVEL_INEXPENSIVE,
        PRICE_LEVEL_MODERATE,
        PRICE_LEVEL_EXPENSIVE,
        PRICE_LEVEL_VERY_EXPENSIVE
    }
}
