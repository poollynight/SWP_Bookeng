using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWP_template.Models;
using System.Data.SqlClient;
using static ServiceStack.Script.Lisp;

namespace SWP_template.Controllers
{
    [Route("[controller]")]

    public class SearchController : Controller
    {
        Swp1Context context = new Swp1Context();

        private readonly ILogger<SearchController> _logger;

        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public ActionResult Search(string province, string name)
        {
            var hotels = context.Hotels.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                hotels = hotels.Where(h => h.HotelName.Contains(name));
            }

            if (!string.IsNullOrEmpty(province))
            {
                hotels = hotels.Where(h => h.Province.Contains(province));
            }
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(province))
            {
                hotels = hotels.Where(h => h.Province.Contains(province) && h.HotelName.Contains(name));
            }
            var searchResults = hotels.ToList();

            return View("Search", searchResults);
        }
    }
}