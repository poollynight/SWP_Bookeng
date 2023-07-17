using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;
using System.Data.SqlClient;

namespace SWP_template.Controllers
{
    [Route("[controller]")]
    public class HotelDetailController : Controller
    {

        Swp1Context context = new Swp1Context();
        private readonly ILogger<HotelDetailController> _logger;
        public HotelDetailController(ILogger<HotelDetailController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult HotelDetail(string HotelID)
        {
            var currentTime = DateTime.Now;

            List<Room> room = context.Rooms.Where(r => r.HotelId == HotelID).ToList();
            string connectionString = "Data Source=localhost;Initial Catalog=SWP1;User ID=sa;Password=123456";


            foreach (var i in room)
            {

                List<Order> order = context.Orders.Where(o => o.RoomId == i.RoomId && o.CheckOut >= currentTime && o.CheckIn <= currentTime).ToList();
                List<Order> order1 = context.Orders.Where(o => o.RoomId == i.RoomId && o.CheckIn > currentTime).ToList();
                List<Order> order2 = context.Orders.Where(o => o.RoomId == i.RoomId && o.CheckOut < currentTime).ToList();
                if (order.Count != 0)
                {
                    foreach (var o in order)
                    {
                        List<OrderPassed> orderpassed = context.OrderPasseds.Where(p => p.OrderId.Equals(o.OrderId.ToString())).ToList();
                       
                        if (orderpassed != null) { Console.WriteLine("OkOk"); }
                        if (orderpassed.Count == 0)
                        {

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {

                                int roomAvailable = i.RoomAvailable - o.RoomQualtity;
                                connection.Open();
                                string query1 = "UPDATE Room SET RoomAvailable = @RoomAvailable WHERE RoomID = @RoomID";
                                using (SqlCommand command = new SqlCommand(query1, connection))
                                {

                                    command.Parameters.AddWithValue("@RoomID", i.RoomId);
                                    command.Parameters.AddWithValue("@RoomAvailable", roomAvailable);
                                    command.ExecuteNonQuery();
                                }
                                string query = "INSERT INTO [OrderPassed] (OrderId,roomQuantity) values (@OrderId, @RoomQuantity)";
                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    command.Parameters.AddWithValue("@OrderId", o.OrderId);
                                    command.Parameters.AddWithValue("@roomQuantity", o.RoomQualtity);
                                    command.ExecuteNonQuery();

                                }
                            }
                        }


                    }
                }
                if (order.Count == 0 && order2.Count == 0 && order1.Count != 0)
                {
                    if (order1.Count != 0)
                    {
                       

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {


                            int roomAvailable = i.RoomAvailable;
                          
                            connection.Open();
                            string query1 = "UPDATE Room SET RoomAvailable = @RoomAvailable WHERE RoomID = @RoomID";
                            using (SqlCommand command = new SqlCommand(query1, connection))
                            {
                                command.Parameters.AddWithValue("@RoomID", i.RoomId);
                                command.Parameters.AddWithValue("@RoomAvailable", roomAvailable);
                                command.ExecuteNonQuery();
                            }

                        }
                    }

                }
                if (order2.Count != 0)
                {
                    foreach (var o in order2)
                    {
                        List<OrderPassed> orderpasseds = context.OrderPasseds.Where(od => od.OrderId.Equals(o.OrderId.ToString())).ToList();
                        if (orderpasseds.Count != 0)
                        {
                            foreach (var l in orderpasseds)
                            {
                              

                                using (SqlConnection connection = new SqlConnection(connectionString))
                                {
                                    connection.Open();

                                    int roomAvailable = (int)(i.RoomAvailable + l.RoomQuantity);

                                    string query1 = "UPDATE Room SET RoomAvailable = @RoomAvailable WHERE RoomID = @RoomID";
                                    using (SqlCommand command = new SqlCommand(query1, connection))
                                    {
                                        command.Parameters.AddWithValue("@RoomID", i.RoomId);
                                        command.Parameters.AddWithValue("@RoomAvailable", roomAvailable);
                                        command.ExecuteNonQuery();
                                    }
                                    string query = "DELETE FROM [OrderPassed] WHERE OrderId = @OrderId";
                                    using (SqlCommand command = new SqlCommand(query, connection))
                                    {
                                        command.Parameters.AddWithValue("@OrderId", o.OrderId);
                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                }

            }


            var hotel = context.Hotels.Where(h => h.HotelId.Equals(HotelID)).FirstOrDefault();
            int fileCount = Directory.GetFiles($"wwwroot/img/{hotel.Province}/{hotel.HotelName}").Length;
            string imgURL = $"{hotel.Province}/{hotel.HotelName}";
            ViewBag.hotel_name = hotel.HotelName;
            ViewBag.img_Number = fileCount;
            ViewBag.img_URl = imgURL;
            ViewBag.id = HotelID;
            List<Room> rooms = context.Rooms.Where(r => r.HotelId.Equals(HotelID)).ToList();
            return View(rooms);
        }
    }
}