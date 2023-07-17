using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWP_template.Models;

namespace SWP_template.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        public ILogger<AdminHomeController> Logger { get; }

        public AdminHomeController(ILogger<AdminHomeController> logger)
        {
            Logger = logger;
        }
        public IActionResult AdminHome()
        {

            return View("~/Views/Admin/AdminHome.cshtml");
        }
        public IActionResult ManageUserAccount()
        {
            return View("~/Views/Admin/ManageUserAccount.cshtml", EFManage.GetAllUserAccount());
        }
        public IActionResult RemoveUserAccount(string UserID)
        {
            RemoveUserAccount(UserID);
            return View("~/Views/Admin/ManageUserAccount.cshtml", EFManage.GetAllUserAccount());
        }
    }
}
