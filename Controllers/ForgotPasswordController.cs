using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SWP_template.Controllers
{
    [Route("[controller]")]
    public class ForgotPasswordController : Controller
    {
        private readonly ILogger<ForgotPasswordController> _logger;

        public ForgotPasswordController(ILogger<ForgotPasswordController> logger)
        {
            _logger = logger;
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

    }
}