using Microsoft.AspNetCore.Mvc;
using ShoeStore.Frontend.Models;
using ShoeStore.Frontend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeStore.Frontend.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task<IActionResult> Index(string q)
        {
            SearchResult searchreult = await _searchService.SearchProductsAsync(q);
            return View(searchreult);
        }
    }
}
