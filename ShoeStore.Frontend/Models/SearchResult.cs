using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStore.Frontend.Models
{
    public class SearchResult
    {
        public IEnumerable<Product> Products { get; set; }
    }
}
