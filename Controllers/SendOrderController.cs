using Microsoft.AspNetCore.Mvc;
using SWP_template.Models;

namespace SWP_template.Controllers
{
    public class SendOrderController : Controller
    {
        Swp1Context context = new Swp1Context();
        private readonly ILogger<SendOrderController> _logger;
        public SendOrderController(ILogger<SendOrderController> logger)
        {
            _logger = logger;
        }
             //[HttpPost]
        public IActionResult SendOrder()
        {
            string account = HttpContext.Session.GetString("ID");
            List<Order> orders = (
            from Order in context.Orders
            join Room in context.Rooms on Order.RoomId equals Room.RoomId
            join Hotel in context.Hotels on Room.HotelId equals Hotel.HotelId
            where Hotel.AccountId == account
            select new Order
            {
                RoomId = Order.RoomId,
                RoomName = Order.RoomName,
                AccountId = Order.AccountId,
                CheckIn = Order.CheckIn,
                CheckOut = Order.CheckOut,
                Email = Order.Email,
                Name = Order.Name,
                Phone = Order.Phone,
                Nation = Order.Nation,
                RoomType = Order.RoomType,
                RoomQualtity = Order.RoomQualtity,
                BedQualtity = Order.BedQualtity,
                PayMethod = Order.PayMethod
            }
            ).ToList();
            Console.WriteLine(orders.Count);
            return View("/Views/Order/Order.cshtml", orders);
        }
    }
}