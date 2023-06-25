using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;
using System.Net.Mail;

namespace SWP_template.Controllers
{
    [Route("[controller]")]
    public class ForgotPasswordController : Controller
    {
        public ForgotPasswordController(ILogger<ForgotPasswordController> logger)
        {
            Logger = logger;
        }

        public ILogger<ForgotPasswordController> Logger { get; }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPasswordEmailSender(string account, string email)
        {
            var acc = EFManage.ForgotPassword(account, email);
            if (acc != null)
            {
                SendMailServices sendMailServices = new SendMailServices();
                var mailContent = new MailContent();
                mailContent.To = email;
                mailContent.Subject = "Reset your password";
                mailContent.Body = "<h1>It's seem like you forgot your password.</h1>" +
                    "<p>To reset your password. Click <a type=\"text/html\" href=\"https://localhost:7278/ResetPassword\">Here</a></p>";
                ViewBag.succeed = sendMailServices.SendMail(mailContent).Result;
                IHttpContextAccessor Accessors = new HttpContextAccessor();
                Accessors.HttpContext.Session.SetString("username", acc.Username);
                return View("~/Views/ForgotPassword/Succeed.cshtml");
            }
            ViewBag.error = "Wrong account or email";
            return View("~/Views/ForgotPassword/ForgotPassword.cshtml");

        }
    }
}