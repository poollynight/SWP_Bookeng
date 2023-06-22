using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using SWP_template.Models;

namespace SWP_template.Controllers
{
    public class OwnerSignupController : Controller
    {
        public IActionResult OwnerSignup()
        {
            return View("/Views/Signup/OwnerSignup.cshtml");
        }

        [HttpPost]
        public IActionResult OwnerSignup(string account, string email, string password, string confirmPassword)
        {
            if (account.IsEmpty() || email.IsEmpty() || password.IsEmpty() || confirmPassword.IsEmpty())
            {
                ViewBag.fail = "Please fill required fields";
                return View("OwnerSignup");
            }
            else
            if (!password.Equals(confirmPassword))
            {
                ViewBag.fail = "Password and Repeat password is not the same!";
                return View("OwnerSignup");
            }
            else
            {
                EFManage.SinupAccount(account, email, password, "R002");
                return View("/Views/Owner/OwnerLogin.cshtml");
            }
        }
    }
}
