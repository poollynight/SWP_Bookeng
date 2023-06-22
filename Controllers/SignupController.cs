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

        public IActionResult Signup()
        {
            // Models.SwpContext.insertAccount(Models.Accountss.UserAccountIdGenerate(), account, email,password);
            return View("Signup");
        }


        [HttpPost]
        public IActionResult UserSignup(string account, string email, string password, string confirmPassword)
        {
            if (account.IsEmpty() || email.IsEmpty() || password.IsEmpty() || confirmPassword.IsEmpty())
            {
                ViewBag.fail = "Please fill required fields";
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
                EFManage.SinupAccount(account,email,password, "R003");
                return View("/Views/Login/Login.cshtml");
            }
        }

        //[HttpGet]
        //public IActionResult OwnerSignup()
        //{
        //    return View("/Views/Signup/Signup.cshtml");
        //}
        //[HttpPost]
        //public IActionResult OwnerSignup(string account, string email, string password, string confirmPassword)
        //{
        //    if (account.IsEmpty() || email.IsEmpty() || password.IsEmpty() || confirmPassword.IsEmpty())
        //    {
        //        ViewBag.fail = "Please fill required fields";
        //        return View("Signup");
        //    }
        //    else
        //    if (!password.Equals(confirmPassword))
        //    {
        //        ViewBag.fail = "Password and Repeat password is not the same!";
        //        return View("Signup");
        //    }
        //    else
        //    {
        //        ManageAccount.SinupAccount(account, email, password, "R002");
        //        return View("/Views/Login/Login.cshtml");
        //    }
        //}
    }
}
