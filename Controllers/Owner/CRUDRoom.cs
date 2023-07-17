using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using SWP_template.Models;

namespace SWP_template.Controllers.Owner
{
    public class CRUDRoomController : Controller
    {
        CRUD crud = new CRUD();
        Swp1Context swp1Context = new Swp1Context();
        public ActionResult CreateRoom(string HotelId)
        {
            ViewData["HotelID"] = HotelId;

            // Hiện form tạo Room tại đây nhe -Thiện-
            return View("/Views/Owner/CreateRoom.cshtml");
        }

        [HttpPost]
        public ActionResult CreateRoom(Room model, string HotelId)
        {
            ViewBag.HotelId = HotelId;
            if (ModelState.IsValid)
            {
                Console.WriteLine("ok nè1");
                // Thực hiện xử lý tạo phòng trong DB -Thiện-
                crud.CreateRoom(model.HotelId, model.RoomName, model.RoomInfo, model.RoomPrice, model.BedQuantity, model.Wifi, model.Window, model.Smoking, model.RoomImage, model.RoomAvailable);
                var rooms = swp1Context.Rooms.Where(h => h.HotelId == HotelId).ToList();
                return View("/Views/Owner/OwnerHome_Room.cshtml", rooms);
            }

            // Nếu dữ liệu không hợp lệ, quay lại giao diện tạo phòng và hiển thị thông báo lỗi -Thiện-
            var hoteldetail = swp1Context.Rooms.Where(h => h.HotelId == HotelId).ToList();
            return View("/Views/Owner/OwnerHome_Room.cshtml", hoteldetail);
        }

        public ActionResult EditRoom(string roomId, string hotelId)
        {
            // Lấy thông tin phòng từ database dựa trên roomId
            var room = swp1Context.Rooms.FirstOrDefault(h => h.RoomId == roomId);
            if (room != null)
            {
                ViewData["HotelId"] = hotelId;
                return View("/Views/Owner/OwnerRoomUpdate.cshtml",room);
            }
            // Nếu không tìm thấy phòng, điều hướng về trang danh sách phòng hoặc hiển thị thông báo lỗi
            return RedirectToAction("OwnerHomeRoom", "OwnerHome");
        }

        [HttpPost]
        public ActionResult UpdateRoom(Room model, string roomId, string HotelId)
        {
            
            
            roomId = Request.Form["RoomId"];
            string wifivalue = Request.Form["Wifi"];
            model.Wifi = (wifivalue == "1") ? "1" : "0";
            string windowvalue = Request.Form["Window"];
            model.Window = (windowvalue == "1") ? "1" : "0";
            string smokingvalue = Request.Form["Smoking"];
            model.Smoking = (smokingvalue == "1") ? "1" : "0";
            if (ModelState.IsValid)
            {
                var room = (from r in swp1Context.Rooms where r.RoomId.Equals(roomId) select r).FirstOrDefault();
                room.RoomName = model.RoomName;
                room.RoomInfo = model.RoomInfo;
                room.RoomPrice = model.RoomPrice;
                room.BedQuantity = model.BedQuantity;
                room.Wifi = model.Wifi;
                room.Window = model.Window;
                room.Smoking = model.Smoking;
                room.RoomImage = model.RoomImage;
                room.RoomAvailable = model.RoomAvailable;
                swp1Context.SaveChanges();
            }
            string mess = "Room Updated!";
            ViewData["mess"] = mess;
            var hoteldetail = swp1Context.Rooms.Where(h => h.HotelId == HotelId).ToList();
            return RedirectToAction("OwnerHomeRoom", "OwnerHome", new { HotelId });

        }
        public ActionResult DeleteRoom(string roomId, string HotelId)
        {
            // Lấy thông tin phòng từ database dựa trên roomId
            crud.DeleteRoom(roomId);
            ViewBag.HotelId = HotelId;
            //IHttpContextAccessor Accessors = new HttpContextAccessor();
            var hoteldetail = swp1Context.Rooms.Where(h => h.HotelId == HotelId).ToList();
            return RedirectToAction("OwnerHomeRoom", "OwnerHome", new { HotelId });

            // Nếu không tìm thấy phòng, điều hướng về trang danh sách phòng hoặc hiển thị thông báo lỗi
            //return RedirectToAction("OwnerHomeRoom", "OwnerHome", new { HotelId });
        }
    }
}
