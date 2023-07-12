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
            Swp1Context swp = new Swp1Context();
            var data = EFManage.Login(account, password, "R002");
            if (data != null)
            {
                var owner = swp.Accountsses.Where(a => a.Username.Equals(account) && a.RoleId.Equals("R002")).FirstOrDefault();
                IHttpContextAccessor Accessors = new HttpContextAccessor();
                Accessors.HttpContext.Session.SetString("Username", owner.Name);
                Accessors.HttpContext.Session.SetString("ID", data.AccountId);
                return RedirectToAction("OwnerHome", "OwnerHome");
            }
            else
            {
                ViewBag.LoginFail = "Wrong username or password!";
                return View("/Views/Owner/OwnerLogin.cshtml");
            }
        }
    }
}
