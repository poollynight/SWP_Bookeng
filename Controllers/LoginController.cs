using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;
using Microsoft.AspNetCore.Authorization;
namespace SWP_template.Controllers;

[Route("[controller]")]
public class LoginController : Controller
{
    private readonly ILogger<LoginController> _logger;

    public LoginController(ILogger<LoginController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }


    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string account, string password, bool rememberme)
    {
        var dbcontext = new SwpContext();

        var data = dbcontext.Accountsses.Where(a => a.Username.Equals(account) && a.Password.Equals(password) && a.Role.Equals("R003")).ToList();
        if (data.Count() > 0)
        {
           
            HttpContext.Session.SetString("Username", data.FirstOrDefault().Username);
            HttpContext.Session.SetString("Password", data.FirstOrDefault().Password);
            ViewBag.Succeed = account;
            object session = HttpContext.Session;
            return View("/Views/Home/Index.cshtml", session);
        }
        else
        {
            ViewBag.LoginFail = "Wrong username or password!";
            return View();
        }


    }


    //Logout
    public ActionResult Logout()
    {
        HttpContext.Session.Clear();//remove session
        return View("/Views/Home/Index.cshtml");
    }
}