﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;

namespace SWP_template.Controllers.Owner
{
    public class OwnerLoginController : Controller
    {
        public IActionResult OwnerLogin()
        {
            return View("/Views/Owner/OwnerLogin.cshtml");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult OwnerLogin(string account, string password, bool rememberme)
        {
            var data = EFManage.Login(account, password, "R002");
            if (data != null)
            {
                IHttpContextAccessor Accessors = new HttpContextAccessor();
                Accessors.HttpContext.Session.SetString("Username", account);
                Accessors.HttpContext.Session.SetString("ID", data);
                return View("/Views/Owner/OwnerHome.cshtml");
            }
            else
            {
                ViewBag.LoginFail = "Wrong username or password!";
                return View("/Views/Owner/OwnerLogin.cshtml");
            }
        }
    }
}
