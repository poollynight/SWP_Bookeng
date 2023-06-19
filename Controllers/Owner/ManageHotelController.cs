using Microsoft.AspNetCore.Mvc;

namespace SWP_template.Controllers.Owner
{
    public class ManageHotelController : Controller
    {
        public IActionResult ManageHotel()
        {
            return View("/Views/Owner/ManageHotel.cshtml");
        }
    }
}
