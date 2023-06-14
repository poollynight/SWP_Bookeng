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
        SwpContext context = new SwpContext();

        private readonly ILogger<HotelDetailController> _logger;

        public HotelDetailController(ILogger<HotelDetailController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult HotelDetail(string id, string HotelName)
        {
            Console.WriteLine("id="+id);
            //var hotel = context.Hotels.Where(h => h.HotelId.Equals(id)).FirstOrDefault();
            ViewBag.hotel_name = HotelName;
            List<Room> room = context.Rooms.Where(r => r.HotelId.Equals(id)).ToList();
            room.ForEach(r => Console.WriteLine( r.RoomName));
            return View(room);
        }
    }
}