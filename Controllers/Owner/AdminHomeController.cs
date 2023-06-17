using Microsoft.AspNetCore.Mvc;

namespace SWP_template.Areas.Admin.Controllers
{
    public class AdminHomesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
