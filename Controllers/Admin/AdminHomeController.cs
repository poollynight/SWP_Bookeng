using Microsoft.AspNetCore.Mvc;

namespace SWP_template.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        public IActionResult AdminHome()
        {
            return View();
        }
    }
}
