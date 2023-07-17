using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;

namespace SWP_template.Controllers.Admin
{
    public class AdminLoginController : Controller
    {
        public IActionResult AdminLogin()
        {
            return View("~/Views/Admin/AdminLogin.cshtml");
        }
        [HttpPost]
        public IActionResult Login(string account, string password, bool rememberme)
        {
            var data = EFManage.Login(account, password, "R001");
            if (data != null)
            {
                IHttpContextAccessor Accessors = new HttpContextAccessor();
                Accessors.HttpContext.Session.SetString("Username", account);
                Accessors.HttpContext.Session.SetString("ID", data.AccountId);
                return RedirectToAction("AdminHome", "AdminHome");
            }
            else
            {
                ViewBag.LoginFail = "Wrong username or password!";
                return View("/Views/Admin/AdminLogin.cshtml");
            }
        }
    }
}
