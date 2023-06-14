using Microsoft.AspNetCore.Mvc;
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
        public IActionResult HotelDetail(string id)
        {
            Console.WriteLine("id="+id);
            var hotel = context.Hotels.Where(h => h.HotelId.Equals(id)).FirstOrDefault();
            ViewBag.hotel_name = hotel.HotelName;
            List<Room> room = context.Rooms.Where(r => r.HotelId.Equals(id)).ToList();
            room.ForEach(r => Console.WriteLine( r.RoomName));
            return View(room);
        }
    }
}