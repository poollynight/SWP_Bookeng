using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using SWP_template.Models;

namespace SWP_template.Controllers.Admin
{
    public class AdminSignupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminSignup()
        {
            return View("~/Views/Admin/AdminSignup.cshtml");
        }
        [HttpPost]
        public IActionResult AdminSignup(string name, string account, string email, string password, string confirmPassword)
        {
            if (ModelState.IsValid)
            {
                Swp1Context context = new Swp1Context();
                if (account.IsEmpty() || email.IsEmpty() || password.IsEmpty() || confirmPassword.IsEmpty())
                {
                    ViewBag.fail = "Please fill required fields";
                    return View("~/Views/Admin/AdminSignup.cshtml");
                }
                else
                if (context.Accountsses.Where(a => a.Username.Equals(account) && a.RoleId.Equals("R001")).FirstOrDefault() != null)
                {
                    ViewBag.fail = "Account existed";
                    return View("~/Views/Admin/AdminSignup.cshtml");
                }
                else if (context.Accountsses.Where(a => a.Email.Equals(email) && a.RoleId.Equals("R001")).FirstOrDefault() != null)
                {
                    ViewBag.fail = "Email existed";
                    return View("~/Views/Admin/AdminSignup.cshtml");
                }
                else
                if (!password.Equals(confirmPassword))
                {
                    ViewBag.fail = "Password and Repeat password is not the same!";
                    return View("~/Views/Admin/AdminSignup.cshtml");
                }
                else
                {
                    EFManage.SinupAccount(name, account, email, password, "R001");
                    return View("~/Views/Admin/AdminLogin.cshtml");
                }
            }
            else return View("~/Views/Admin/AdminSignup.cshtml");
        }

    }
}
