using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;

namespace SWP_template.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult UserProfile(string id)
        {
            var dbcontext = new Swp1Context();
            var user = dbcontext.Accountsses.Where(a => a.AccountId == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public IActionResult EditUserProfile(string userID, string name, string DOB, string email, string phone, string nation, string gender, string identitycard)
        {
            EFManage.EditProfile(userID, name, DOB, email, phone, nation, gender, identitycard);
            return RedirectToAction("UserProfile", "UserProfile", new { id = userID });

        }
        [HttpPost]
        public IActionResult ChangePassword(string userID, string OldPassword, string NewPassword, string ConfirmPassword)
        {
            var dbcontext = new Swp1Context();
            var user = dbcontext.Accountsses.Where(a => a.AccountId == userID).FirstOrDefault();
            if (user.Password.Equals(OldPassword))
            {
                ViewBag.mess = "Incorrect old password";
                return View("~/Views/UserProfile/UserProfile.cshtml");
            }
            else if (ConfirmPassword.Equals(NewPassword))
            {
                ViewBag.mess = "Repeat password not match New password";
                return View("~/Views/UserProfile/UserProfile.cshtml");
            }
            EFManage.ChangePassword(user.Username, NewPassword, "R003");
            return View("~/Views/UserProfile/UserProfile.cshtml");
        }
    }
}
