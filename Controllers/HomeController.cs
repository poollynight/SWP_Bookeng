using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;
using System.Diagnostics;

namespace SWP_template.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Logout()
        {
            IHttpContextAccessor Accessors = new HttpContextAccessor();
            Accessors.HttpContext.Session.Remove("Username");
            Accessors.HttpContext.Session.Remove("ID");

            return View("/Views/Home/Index.cshtml");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}