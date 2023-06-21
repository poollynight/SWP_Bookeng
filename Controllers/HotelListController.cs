using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SWP_template.Models;

namespace SWP_template.Controllers
{

    [Route("[controller]")]
    public class HotelListController : Controller
    {
        Swp1Context context = new Swp1Context();

        private readonly ILogger<HotelListController> _logger;
         
        public HotelListController(ILogger<HotelListController> logger)
        {
            _logger = logger;
        }



        public IActionResult HotelList(string province)
        {
            var ListHotel = context.Hotels.Where(h => h.Province.Contains(province)).ToList();
            return View(ListHotel);
        }
    }
}