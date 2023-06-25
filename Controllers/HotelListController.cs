using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;

namespace SWP_template.Controllers
{
    [Route("[controller]")]
    public class HotelListController : Controller
    {
        public HotelListController(ILogger<HotelListController> logger)
        {
            Logger = logger;
        }

        public ILogger<HotelListController> Logger { get; }

        public IActionResult HotelList(string province)
        {
            var ListHotel = new Swp1Context().Hotels.Where(h => h.Province.Contains(province)).ToList();
            return View(ListHotel);
        }
    }
}