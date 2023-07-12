using Microsoft.AspNetCore.Mvc;

namespace SWP_template.Controllers.Admin
{
    public class UserListController : Controller
    {
        public IActionResult UserList()
        {
            return View();
        }
    }
}
