using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;
using System.Collections;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;

namespace SWP_template.Controllers.Owner
{
    public class OwnerHomeController : Controller
    {
        public IActionResult OwnerHome()
        {
            IHttpContextAccessor Accessors = new HttpContextAccessor();
            string OwnerID = Accessors.HttpContext.Session.GetString("ID");
            var context = new Swp1Context();

            int stayer = 0;
            int orders = 0;
            SqlMoney total = 0, monthlyTotal = 0;

            var result = from o in context.Orders
                         where o.CheckOut.Year == DateTime.Now.Year && o.CheckOut < DateTime.Now || 
                         o.CheckOut.Year == DateTime.Now.Year&& o.CheckOut.Month == DateTime.Now.Month&& o.CheckOut.Day == DateTime.Now.Day && o.CheckOut.Hour + 14 < DateTime.Now.Hour
                         join r in context.Rooms on o.RoomId equals r.RoomId
                         join h in context.Hotels on r.HotelId equals h.HotelId
                         where h.AccountId == OwnerID
                         select new { adult = o.Adult, child = o.Child, checkout = o.CheckOut };


            var monthIncome = from o in context.Orders
                              where o.CheckOut.Year == DateTime.Now.Year && o.CheckOut.Month == DateTime.Now.Month && o.CheckOut.Day < DateTime.Now.Day
                              || o.CheckOut == DateTime.Now && o.CheckOut.Hour + 14 < DateTime.Now.Hour
                              join r in context.Rooms on o.RoomId equals r.RoomId
                              join h in context.Hotels on r.HotelId equals h.HotelId
                              where h.AccountId == OwnerID
                              select new { monthTotal = o.TotalPrice };

            var Income = from o in context.Orders
                         where o.CheckOut.Year == DateTime.Now.Year && o.CheckOut.Month <= DateTime.Now.Month && o.CheckOut < DateTime.Now 
                         join r in context.Rooms on o.RoomId equals r.RoomId
                         join h in context.Hotels on r.HotelId equals h.HotelId
                         where h.AccountId == OwnerID
                         select new { total = o.TotalPrice };
            
            foreach (var o in result)
            {
                orders++;
                stayer += o.adult + o.child;
            }
            
            foreach (var o in Income)
            {
                total += o.total;
            }
            foreach (var o in monthIncome)
            {
                monthlyTotal += o.monthTotal;
            }

            //Dashboard
            ArrayList list = EFManage.SelectOrdersByMonth(OwnerID);

            ViewBag.booker = stayer/orders;
            ViewBag.totalIncome = total;
            ViewBag.monthlyIncome = monthlyTotal;
            ViewBag.thang1 = list[0];
            ViewBag.thang2 = list[1];
            ViewBag.thang3 = list[2];
            ViewBag.thang4 = list[3];
            ViewBag.thang5 = list[4];
            ViewBag.thang6 = list[5];
            ViewBag.thang7 = list[6];
            ViewBag.thang8 = list[7];
            ViewBag.thang9 = list[8];
            ViewBag.thang10 = list[9];
            ViewBag.thang11 = list[10];
            ViewBag.thang12 = list[11];
            ViewBag.datediff = EFManage.DateDiff(OwnerID);
            return View("/Views/Owner/OwnerHome.cshtml");
        }
        public IActionResult Properties()//List ra từng hotel
        {

            using var context = new Swp1Context();
            IHttpContextAccessor Accessors = new HttpContextAccessor();
            string OwnerID = Accessors.HttpContext.Session.GetString("ID");
            var hotels = context.Hotels.Where(h => h.AccountId.Equals(OwnerID)).ToList();
            return View("/Views/Owner/Properties.cshtml", hotels);

        }
        //[HttpPost]
        public IActionResult OwnerHomeRoom(string HotelId)//List ra từng room
        {

            ViewData["HotelId"] = HotelId;
            using var context = new Swp1Context();
            //IHttpContextAccessor Accessors = new HttpContextAccessor();
            var hoteldetail = context.Rooms.Where(h => h.HotelId == HotelId).ToList();
            return View("/Views/Owner/OwnerHome_Room.cshtml", hoteldetail);
        }


        public IActionResult OwnerProfile(string id)
        {
            var dbcontext = new Swp1Context();
            var user = dbcontext.Accountsses.Where(a => a.AccountId == id).FirstOrDefault();
            return View("~/Views/Owner/OwnerProfile.cshtml", user);
        }
        [HttpPost]
        public IActionResult EditUserProfile(string userID, string name, string DOB, string email, string phone, string nation, string gender, string identitycard)
        {
            EFManage.EditProfile(userID, name, DOB, email, phone, nation, gender, identitycard);
            return RedirectToAction("UserProfile", "UserProfile", new { id = userID });

        }

        public JsonResult SelectOrdersByMonth(string OwnerID)
        {
            ArrayList countList = new ArrayList();
            var context = new Swp1Context();
            int orderNumber = 0;
            for(int month = 1; month <= 12; month++)
            {
            var orders = (from o in context.Orders
                         where o.CheckIn == DateTime.Now && o.CheckOut.Month == month && o.CheckOut.Day == DateTime.Now.Day && o.CheckOut.Hour + 14 <= DateTime.Now.Hour
                         || o.CheckOut.Year == DateTime.Now.Year && o.CheckOut.Month == month && o.CheckOut.Day < DateTime.Now.Day

                         join r in context.Rooms on o.RoomId equals r.RoomId
                         join h in context.Hotels on r.HotelId equals h.HotelId
                         where h.AccountId == OwnerID
                         select new { month =  o.CheckIn.Month }).Count();
                countList.Add(orders);
            }
            
            return Json(countList, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }
        public JsonResult SelectOrdersByMonth1()
        {
            return Json(1, System.Web.Mvc.JsonRequestBehavior.AllowGet);

        }
    }
}