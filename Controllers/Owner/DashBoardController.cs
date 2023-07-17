using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;
using System.Collections;
using System.Data.SqlTypes;

namespace SWP_template.Controllers.Owner
{
    public class DashBoardController : Controller
    {
        public IActionResult IncomeDashboard()
        {
            IHttpContextAccessor Accessors = new HttpContextAccessor();
            string OwnerID = Accessors.HttpContext.Session.GetString("ID");
            ArrayList Income = new ArrayList();
            for (int month = 1; month <= 12; month++)
            {
                Income.Add(EFManage.IncomeForDashboard(OwnerID, month));
            }
            ViewBag.thang1 = Income[0];
            ViewBag.thang2 = Income[1];
            ViewBag.thang3 = Income[2];
            ViewBag.thang4 = Income[3];
            ViewBag.thang5 = Income[4];
            ViewBag.thang6 = Income[5];
            ViewBag.thang7 = Income[6];
            ViewBag.thang8 = Income[7];
            ViewBag.thang9 = Income[8];
            ViewBag.thang10 = Income[9];
            ViewBag.thang11 = Income[10];
            ViewBag.thang12 = Income[11];
            return View("~/Views/Owner/Dashboard_Income.cshtml");
        }
    }
}
