using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using SWP_template.Models;

namespace SWP_template.Controllers.Owner
{
    public class CRUDRoomController : Controller
    {
        CRUD crud = new CRUD();
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            // Hiện form tạo phòng tại đây nhe -Thiện-
            return View();
        }

        [HttpPost]
        public ActionResult Create(Room model)
        {
            if (ModelState.IsValid)
            {
                // Thực hiện xử lý tạo phòng trong DB -Thiện-
                crud.CreateRoom(model.HotelId, model.RoomId, model.RoomName, model.RoomInfo, model.RoomPrice, model.BedQuantity, model.Wifi, model.Window, model.Smoking, model.RoomImage, model.RoomAvailable);

                return RedirectToAction("Index");
            }

            // Nếu dữ liệu không hợp lệ, quay lại giao diện tạo phòng và hiển thị thông báo lỗi -Thiện-
            return View(model);
        }

        public ActionResult Edit(string roomId)
        {
            // Lấy thông tin phòng từ database dựa trên roomId
            var room = CRUD.GetRoomById(roomId);

            if (room != null)
            {
                // Mã logic để hiển thị giao diện chỉnh sửa phòng (View) với thông tin phòng hiện tại
                var model = new Room //Giao diện chỉnh sửa phòng -Thiện-
                {
                    HotelId = room.HotelId,
                    RoomId = room.RoomId,
                    RoomName = room.RoomName,
                    RoomInfo = room.RoomInfo,
                    RoomPrice = room.RoomPrice,
                    BedQuantity = room.BedQuantity,
                    Wifi = room.Wifi,
                    Window = room.Window,
                    Smoking = room.Smoking,
                    RoomImage = room.RoomImage,
                    RoomAvailable = room.RoomAvailable
                };

                return View(model);
            }

            // Nếu không tìm thấy phòng, điều hướng về trang danh sách phòng hoặc hiển thị thông báo lỗi
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Room model)
        {
            if (ModelState.IsValid)
            {
                // Thực hiện xử lý cập nhật phòng trong database
                crud.UpdateRoom(model.RoomId, model.RoomName, model.RoomInfo, model.RoomPrice, model.BedQuantity, model.Wifi, model.Window, model.Smoking, model.RoomImage, model.RoomAvailable);

                return RedirectToAction("Index");
            }
            return View(model);

        }
        public ActionResult Delete(string roomId)
        {
            // Lấy thông tin phòng từ database dựa trên roomId
            crud.DeleteRoom(roomId);

            if (roomId != null)
            {
                //Hiển thị FE xoá phòng thành công -Thiện-
                return View();
            }

            // Nếu không tìm thấy phòng, điều hướng về trang danh sách phòng hoặc hiển thị thông báo lỗi
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string roomId)
        {
            // Lấy thông tin phòng từ database dựa trên roomId
            crud.DeleteRoom(roomId);

            if (roomId != null)
            {
                // Thực hiện xóa phòng trong database
                crud.DeleteRoom(roomId);

                return RedirectToAction("Index");
            }

            // Nếu không tìm thấy phòng, điều hướng về trang danh sách phòng hoặc hiển thị thông báo lỗi
            return RedirectToAction("Index");
        }
    }
}
