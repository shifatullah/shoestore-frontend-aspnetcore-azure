using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShoeStore.Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShoeStore.Frontend.Services
{
    public class SearchService : ISearchService
    {
        private readonly IConfiguration _configuration;

        public SearchService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SearchResult> SearchProductsAsync(string query)
        {
            var productSearchEndpoint = _configuration.GetValue<string>("ProductSearchEndpoint");
            using (HttpClient client = new HttpClient())
            {
                using (var response = await client.GetAsync($"{productSearchEndpoint}?query={query}"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        var searchResult = new SearchResult();
                        var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(apiResponse);
                        searchResult.Products = products;

                        return searchResult;
                    }
                }
            }

            return null;
        }
    }
}
