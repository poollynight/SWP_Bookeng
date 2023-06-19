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
        var dbcontext = new Swp1Context();
        var check = ManageAccount.Login(account, password, "R002");
        if (check != null)
        {
            IHttpContextAccessor Accessors = new HttpContextAccessor();
            Accessors.HttpContext.Session.SetString("Username", account);
            Accessors.HttpContext.Session.SetString("ID", check);
            return View("/Views/Home/Index.cshtml");
        }
        else
        {
            ViewBag.LoginFail = "Wrong username or password!";
            return View();
        }


    }



}