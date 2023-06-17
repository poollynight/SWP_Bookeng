using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;

namespace SWP_template.Controllers
{
    
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class SubmitRoomController: Controller
    {

        [HttpPost]
        public ActionResult Submit(string firstName, string lastName, string email, string phone, string country, string arrivalDate, string departureDate, string quatityRoom, string bed, string adults, string childs, string payMethod)
        {
            ViewData["FirstName"] = firstName;
            ViewData["LastName"] = lastName;
            ViewData["Email"] = email;
            ViewData["Phone"] = phone;
            ViewData["Country"] = country;
            ViewData["ArrivalDate"] = arrivalDate;
            ViewData["DepartureDate"] = departureDate;
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
