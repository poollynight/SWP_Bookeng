using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceStack;
using SWP_template.Models;
namespace SWP_template.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class SignupController : Controller
    {
        private readonly ILogger<SignupController> _logger;
        public SignupController(ILogger<SignupController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View("Signup");
        }
        [HttpPost]
        public IActionResult CheckInputUserSignup(string account, string email, string password, string confirmPassword)
        {
            if (ModelState.IsValid)
            {
                Swp1Context context = new Swp1Context();
                if (account.IsEmpty() || email.IsEmpty() || password.IsEmpty() || confirmPassword.IsEmpty())
                {
                    ViewBag.fail = "Please fill required fields";
                    return View("Signup");
                }
                else
                if (context.Accountsses.Where(a => a.Username.Equals(account) && a.RoleId.Equals("R003")).FirstOrDefault() != null)
                {
                    ViewBag.fail = "Account existed";
                    return View("Signup");
                }
                else if (context.Accountsses.Where(a => a.Email.Equals(email) && a.RoleId.Equals("R003")).FirstOrDefault() != null)
                {
                    ViewBag.fail = "Email existed";
                    return View("Signup");
                }
                else
                if (!password.Equals(confirmPassword))
                {
                    ViewBag.fail = "Password and Repeat password is not the same!";
                    return View("Signup");
                }
                else
                {
                    var confirmEmailController = new ConfirmEmailController();
                    ViewBag.verifiCode = confirmEmailController.SendConfirmEmail(email);
                    ViewBag.succeed = "An verifi code has been sent to your mail. Check for verifi code";
                    ViewBag.account = account;
                    ViewBag.email = email;
                    ViewBag.password = password;
                    ViewBag.roleID = "R003";
                    return View("~/Views/Signup/ConfirmEmail.cshtml");
                }
            }
            else return View("Signup");
        }
        
        public ViewResult UserSignup(string acc, string mail, string pass)
        {
            return View("/Views/Login/Login.cshtml");

        }
    }
}
