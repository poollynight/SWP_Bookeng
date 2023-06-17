using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;

namespace SWP_template.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult UserProfile(string id)
        {
            var dbcontext = new SwpContext();
            var user = dbcontext.InfoAccounts.Where(a => a.AccountId == id).FirstOrDefault();
            return View(user);
        }
    }
}
