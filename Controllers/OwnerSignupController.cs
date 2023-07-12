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
        public IActionResult OwnerSignup(string name, string account, string email, string password, string confirmPassword)
        {
            if (ModelState.IsValid)
            {
                Swp1Context context = new Swp1Context();
                if (account.IsEmpty() || email.IsEmpty() || password.IsEmpty() || confirmPassword.IsEmpty())
                {
                    ViewBag.fail = "Please fill required fields";
                    return View("OwnerSignup");
                }
                else
                if (context.Accountsses.Where(a => a.Username.Equals(account) && a.RoleId.Equals("R002")).FirstOrDefault() != null)
                {
                    ViewBag.fail = "Account existed";
                    return View("OwnerSignup");
                }
                else if (context.Accountsses.Where(a => a.Email.Equals(email) && a.RoleId.Equals("R002")).FirstOrDefault() != null)
                {
                    ViewBag.fail = "Email existed";
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
                    var confirmEmailController = new ConfirmEmailController();
                    ViewBag.verifiCode = confirmEmailController.SendConfirmEmail(email, "R002");
                    ViewBag.succeed = "An verifi code has been sent to your mail. Check for verifi code";
                    ViewBag.name = name;
                    ViewBag.account = account;
                    ViewBag.email = email;
                    ViewBag.password = password;
                    ViewBag.roleID = "R002";
                    return View("~/Views/Signup/ConfirmEmail.cshtml");
                }
            }
            else return View("OwnerSignup");
        }
        //if (account.IsEmpty() || email.IsEmpty() || password.IsEmpty() || confirmPassword.IsEmpty())
        //{
        //    ViewBag.fail = "Please fill required fields";
        //    return View("OwnerSignup");
        //}
        //else
        //if (!password.Equals(confirmPassword))
        //{
        //    ViewBag.fail = "Password and Repeat password is not the same!";
        //    return View("OwnerSignup");
        //}
        //else
        //{
        //    EFManage.SinupAccount(name,account, email, password, "R002");
        //    return View("/Views/Owner/OwnerLogin.cshtml");
        //}
        public ViewResult OwnerLogin(string acc, string mail, string pass)
        {
            return View("/Views/Owner/OwnerLogin.cshtml");

        }
    }
}
