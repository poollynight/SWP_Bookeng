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
        SwpContext context = new SwpContext();

        private readonly ILogger<HotelListController> _logger;
         
        public HotelListController(ILogger<HotelListController> logger)
        {
            _logger = logger;
        }



        public IActionResult HotelList()
        {
            var ListHotel = context.Hotels.ToList();
            return View(ListHotel);
        }
    }
}