using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;

namespace SWP_template.Areas.Admin.Controllers
{
    public class OwnerHomeController : Controller
    {
        public IActionResult OwnerHome(string mess) //List ra từng hotel
        {
            ViewData["Update"] = mess;
            using var context = new Swp1Context();
            IHttpContextAccessor Accessors = new HttpContextAccessor();
            string OwnerID = Accessors.HttpContext.Session.GetString("ID");
            var hotels = context.Hotels.Where(h => h.AccountId.Equals(OwnerID)).ToList();
            return View("/Views/Owner/OwnerHome.cshtml", hotels);
        }
        [HttpPost]
        public IActionResult OwnerHomeRoom(string HotelId)//List ra từng room
        {
            ViewData["HotelId"] = HotelId;
            using var context = new Swp1Context();
            IHttpContextAccessor Accessors = new HttpContextAccessor();
            var hoteldetail = context.Rooms.Where(h => h.HotelId == HotelId).ToList();
            return View("/Views/Owner/OwnerHome_Room.cshtml", hoteldetail);
        }
    }
}