using Microsoft.AspNetCore.Mvc;
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
        public IActionResult HotelDetail(string HotelID)
        {
            var hotel = context.Hotels.Where(h => h.HotelId.Equals(HotelID)).FirstOrDefault();
            int fileCount = Directory.GetFiles($"wwwroot/img/{hotel.Province}/{hotel.HotelName}").Length;
            string imgURL = $"{hotel.Province}/{hotel.HotelName}";
            Console.WriteLine(fileCount);
            ViewBag.hotel_name = hotel.HotelName;
            ViewBag.img_Number = fileCount;
            ViewBag.img_URl = imgURL;
            ViewBag.id = HotelID;
            List<Room> room = context.Rooms.Where(r => r.HotelId.Equals(HotelID)).ToList();
            return View(room);
        }
    }
}