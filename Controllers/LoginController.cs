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
   
    public IActionResult Login()
    {
        return View();
    }

    //Logout
    


    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string account, string password, bool rememberme)
    {
        var dbcontext = new SwpContext();

        var data = dbcontext.Accountsses.Where(a => a.Username.Equals(account) && a.Password.Equals(password) && a.Role.Equals("R003")).FirstOrDefault();
        if (data != null)
        {
            var session = HttpContext.Session;

            session.SetString("Username", data.Username);
            session.SetString("ID", data.AccountId);
            return View("/Views/Home/Index.cshtml");
        }
        else
        {
            ViewBag.LoginFail = "Wrong username or password!";
            return View();
        }


    }



}