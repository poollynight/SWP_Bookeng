using Microsoft.AspNetCore.Mvc;
namespace SWP_template.Controllers
{
    public class BecomeOwnerController : Controller
    {
        public IActionResult OwnerSignup()
        {
            return View("/Views/Signup/Signup.cshtml");
        }
    }
}
