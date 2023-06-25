using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;

namespace SWP_template.Controllers
{
    [Route("[controller]")]
    public class SubmitRoomController : Controller
    {

        [HttpPost]
        public ActionResult Submit(string firstName, string lastName, string email, string phone, string country, string arrivalDate, string departureDate, string roomType, string quatityRoom, string bed, string adults, string childs, string payMethod)
        {
            var dbcontext = new Swp1Context();
            var room = dbcontext.Rooms.Where(r => r.RoomId == roomType).FirstOrDefault();
            ViewData["FirstName"] = firstName;
            ViewData["LastName"] = lastName;
            ViewData["Email"] = email;
            ViewData["Phone"] = phone;
            ViewData["Country"] = country;
            ViewData["ArrivalDate"] = arrivalDate;
            ViewData["DepartureDate"] = departureDate;
            ViewData["RoomType"] = room.RoomName;
            ViewData["QuatityRoom"] = quatityRoom;
            ViewData["Bed"] = bed;
            ViewData["Adults"] = adults;
            ViewData["Childs"] = childs;
            ViewData["PayMethod"] = payMethod;
            return View("SubmitRoom");
        }
        [HttpGet]
        public IActionResult Submit()
        {
            return View();
        }
    }
}
