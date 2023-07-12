using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;
using System.Diagnostics;

namespace SWP_template.Controllers
{
    public class HomeController : Controller
    {
        public ILogger<HomeController> Logger { get; }

        public HomeController(ILogger<HomeController> logger)
        {
            Logger = logger;
        }
        public IActionResult Index()
        {
            return View("./Views/Home/Index.cshtml");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Logout()
        {
            IHttpContextAccessor Accessors = new HttpContextAccessor();
            //Accessors.HttpContext.Session.Remove("Username");
            //Accessors.HttpContext.Session.Remove("ID");
            Accessors.HttpContext.Session.Clear();
            return View("/Views/Home/Index.cshtml");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}