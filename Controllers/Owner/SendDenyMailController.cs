using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;

namespace SWP_template.Controllers.Owner
{
    public class SendDenyMailController : Controller
    {
        public IActionResult SendDenyMail(string email, string roomID)
        {
            Swp1Context context = new Swp1Context();
            string hotelID = context.Rooms.Where(r => r.RoomId.Equals(roomID)).FirstOrDefault().HotelId;
            string hotelName = context.Hotels.Where(h => h.HotelId.Equals(hotelID)).FirstOrDefault().HotelName;
            SendMailServices sendMailServices = new SendMailServices();
            var mailContent = new MailContent();
            mailContent.To = email;
            mailContent.Subject = $"Sorry! Your Bookeng in {hotelName} has been denied";
            mailContent.Body = "<h1>Thanks Thang! Your booking in Da Nang has been denied for some reason.</h1>" +
                $"<p>{hotelName} apologizes for this inconvenience </p>";
            ViewBag.succeed = sendMailServices.SendMail(mailContent).Result;
            //IHttpContextAccessor Accessors = new HttpContextAccessor();
            //Accessors.HttpContext.Session.SetString("username", acc.Username);
            return View("~/Views/Owner/OwnerHome.cshtml");
        }
    }
}
