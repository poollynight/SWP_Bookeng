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
    }
}
