using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;

namespace SWP_template.Controllers.Owner
{
    public class OwnerLoginController : Controller
    {
        public IActionResult OwnerLogin()
        {
            return View("/Views/Owner/OwnerLogin.cshtml");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult OwnerLogin(string account, string password, bool rememberme)
        {
            var dbcontext = new SwpContext();

            var data = dbcontext.Accountsses.Where(a => a.Username.Equals(account) && a.Password.Equals(password) && a.Role.Equals("R002")).FirstOrDefault();
            if (data != null)
            {
                var session = HttpContext.Session;

                session.SetString("Username", data.Username);
                session.SetString("ID", data.AccountId);
                return View("/Views/Owner/OwnerHome.cshtml");
            }
            else
            {
                ViewBag.LoginFail = "Wrong username or password!";
                return View("/Views/Owner/OwnerLogin.cshtml");
            }
        }
    }
}
