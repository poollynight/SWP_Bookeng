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
        return View("~/Views/Login/Login.cshtml");
    }
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string account, string password, bool rememberme)
    {
        Swp1Context context = new Swp1Context();
        string role = "R003";
        var acc = EFManage.Login(account, password,role );
        if (acc != null)
        {
            var user = context.Accountsses.Where(a => a.Username.Equals(account) && a.RoleId.Equals("R003")).FirstOrDefault();
            IHttpContextAccessor Accessors = new HttpContextAccessor();
            Accessors.HttpContext.Session.SetString("Username", user.Name);
            Accessors.HttpContext.Session.SetString("ID", acc.AccountId);
            
            return View("/Views/Home/Index.cshtml");
        }
        else
        {
            ViewBag.LoginFail = "Wrong username or password!";
            return View();
        }
    }
}