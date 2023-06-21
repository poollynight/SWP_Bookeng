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
    public class HotelDetailController : Controller
    {
        Swp1Context context = new Swp1Context();

        private readonly ILogger<HotelDetailController> _logger;

        public HotelDetailController(ILogger<HotelDetailController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult HotelDetail(string id)
        {


            var hotel = context.Hotels.Where(h => h.HotelId.Equals(id)).FirstOrDefault();
            int fileCount = Directory.GetFiles($"wwwroot/img/{hotel.Province}/{hotel.HotelName}").Length;
            string imgURL = $"{hotel.Province}/{hotel.HotelName}";
            Console.WriteLine(fileCount);
            ViewBag.hotel_name = hotel.HotelName;
            ViewBag.img_Number = fileCount;
            ViewBag.img_URl = imgURL;
            List<Room> room = context.Rooms.Where(r => r.HotelId.Equals(id)).ToList();
            return View(room);
        }
    }
}