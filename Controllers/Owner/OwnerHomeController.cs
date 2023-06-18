using Microsoft.AspNetCore.Mvc;

namespace SWP_template.Areas.Admin.Controllers
{
    public class OwnerHomeController : Controller
    {
        public IActionResult OwnerHome()
        {
            return View("/Views/Owner/OwnerHome.cshtml");
        }
    }
}
