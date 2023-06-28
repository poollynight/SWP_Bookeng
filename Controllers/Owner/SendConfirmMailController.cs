using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;

namespace SWP_template.Controllers.Owner
{
    public class SendConfirmMailController : Controller
    {
        public IActionResult SendConfirmMail(string email, string roomID, string checkin)
        {
            Swp1Context context = new Swp1Context();
            string hotelID = context.Rooms.Where(r => r.RoomId.Equals(roomID)).FirstOrDefault().HotelId;
            string hotelName = context.Hotels.Where(h => h.HotelId.Equals(hotelID)).FirstOrDefault().HotelName;
            SendMailServices sendMailServices = new SendMailServices();
            var mailContent = new MailContent();
            mailContent.To = email;
            mailContent.Subject = $"Thank you! Your Bookeng in {hotelName} has been confirmed";
            mailContent.Body = "<h1>Thanks Thang! Your booking in Da Nang has been confirmed.</h1>" +
                $"<p>{hotelName} awaits you on {checkin}</p>";
            ViewBag.succeed = sendMailServices.SendMail(mailContent).Result;
            //IHttpContextAccessor Accessors = new HttpContextAccessor();
            //Accessors.HttpContext.Session.SetString("username", acc.Username);
            return View("~/Views/Owner/OwnerHome.cshtml");
        }
    }
}
