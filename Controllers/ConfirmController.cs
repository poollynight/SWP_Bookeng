using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;
using System.Data.SqlClient;

namespace SWP_template.Controllers
{
    [Route("[controller]")]
    public class ConfirmController : Controller
    {
        Swp1Context context = new Swp1Context();

        private readonly ILogger<ConfirmController> _logger;

        public ConfirmController(ILogger<ConfirmController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public ActionResult Confirm(IFormCollection form, string Hotelid, string roomType, string firstName, string lastName, string email, string phone, string country, string arrivalDate, string departureDate, string quatityRoom, int bed, string adults, string childs, string payMethod)
        {   //cần thay đổi khi có id của room//

            string account = HttpContext.Session.GetString("ID");

            if (account != null)
            {
                var room = context.Rooms.Where(r => r.RoomId == roomType).FirstOrDefault();
                var hotel = context.Hotels
                          .First(r => r.HotelId == Hotelid);
                string accountID = hotel.AccountId;
                string roomName = room.RoomName;
                string id = room.RoomId;
                decimal total = decimal.Parse(quatityRoom) * decimal.Parse(room.RoomPrice);
       
                string connectionString = "Data Source=localhost;Initial Catalog=SWP1;User ID=sa;Password=123456";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO [Order] (RoomID,RoomName,AccountID,CheckIn,CheckOut,email,name,phone,nation,RoomType,RoomQualtity,BedQualtity,Adult,Child,PayMethod,TotalPrice ) VALUES (@RoomID, @RoomName,@AccountID,@ArrivalDate,@DepartureDate,@Email,@Name,@Phone,@Country,@RoomType,@RoomQualtity,@BedQualtity,@Adult,@Child,@Paymethod,@Total)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("RoomID", id);
                        command.Parameters.AddWithValue("RoomName", roomName);
                        command.Parameters.AddWithValue("AccountID", account);
                        command.Parameters.AddWithValue("ArrivalDate", arrivalDate);
                        command.Parameters.AddWithValue("DepartureDate", departureDate);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Name", firstName + " " + lastName);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Country", country);
                        command.Parameters.AddWithValue("@RoomType", roomType);
                        command.Parameters.AddWithValue("@RoomQualtity", quatityRoom);
                        command.Parameters.AddWithValue("@BedQualtity", bed);
                        command.Parameters.AddWithValue("@Adult", adults);
                        command.Parameters.AddWithValue("@Child", childs);
                        command.Parameters.AddWithValue("@PayMethod", payMethod);
                        command.Parameters.AddWithValue("@Total", total);
                        command.ExecuteNonQuery();
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        
    }
}