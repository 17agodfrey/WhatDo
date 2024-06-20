using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateFinder.External
{
    internal interface IGoogleMapsClient
    {
        // text search: given a query, return a list of places, displayName only, the first 5
        Task<IEnumerable<string>> TextSearch(string query);


    }
}
