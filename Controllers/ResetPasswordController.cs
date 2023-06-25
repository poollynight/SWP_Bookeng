using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;

namespace SWP_template.Controllers
{
    public class ResetPasswordController : Controller
    {
        public IActionResult Index()
        {
            return View("/Views/ResetPassword/ResetPassword.cshtml");
        }
        [HttpPost]
        public IActionResult ResetPassword(string Password, string ConfirmPassword)
        {
            //id null
            if (Password != ConfirmPassword)
            {
                ViewBag.mess = "Confirm password not match";
                return View("/Views/ResetPassword/ResetPassword.cshtml");
            }
            else
            {
                IHttpContextAccessor Accessors = new HttpContextAccessor();
                string username = Accessors.HttpContext.Session.GetString("username");
                EFManage.ChangePassword(username, Password, "R003");
                Accessors.HttpContext.Session.Remove("username");
                return View("/Views/Login/Login.cshtml");
            }
        }
    }
}
