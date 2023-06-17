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
        var acc = ManageAccount.UserLogin(account, password, "R003");
        if (acc != null)
        {
            var session = HttpContext.Session;
            session.SetString("Username", account);
            session.SetString("ID", acc.AccountId);
            return View("/Views/Home/Index.cshtml");
        }
        else
        {
            ViewBag.LoginFail = "Wrong username or password!";
            return View();
        }
    }



}