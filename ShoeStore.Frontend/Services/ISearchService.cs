using ShoeStore.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStore.Frontend.Services
{
    public interface ISearchService
    {
        public Task<SearchResult> SearchProductsAsync(string query);
    }
}
