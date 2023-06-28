using Microsoft.AspNetCore.Mvc;
using ServiceStack;
using SWP_template.Models;

namespace SWP_template.Controllers.Owner
{
    public class CRUDHotelController : Controller
    {
        CRUD crud = new CRUD();
        Swp1Context swp1Context = new Swp1Context();

        public ActionResult CreateHotel()
        {
            var provinces = new List<string>
    {
        "An Giang", "Bà Rịa - Vũng Tàu", "Bạc Liêu", "Bắc Kạn", "Bắc Giang",
        "Bắc Ninh", "Bến Tre", "Bình Dương", "Bình Định", "Bình Phước",
        "Bình Thuận", "Cà Mau", "Cao Bằng", "Cần Thơ", "Đà Nẵng","Đà Lạt",
        "Đắk Lắk", "Đắk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp",
        "Gia Lai", "Hà Giang", "Hà Nam", "Hà Nội", "Hà Tĩnh",
        "Hải Dương", "Hải Phòng", "Hậu Giang", "Hòa Bình", "Hồ Chí Minh",
        "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu",
        "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định",
        "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên",
        "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị",
        "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên",
        "Thanh Hóa", "Thừa Thiên Huế", "Tiền Giang", "Trà Vinh", "Tuyên Quang",
        "Vĩnh Long", "Vĩnh Phúc", "Yên Bái"
    };

            ViewBag.Provinces = provinces;
            // Hiện form tạo hotel tại đây nhe -Thiện-
            return View("/Views/Owner/OwnerHotelCreate.cshtml");
        }

        [HttpPost]
        public ActionResult CreateHotel(Hotel model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("ok nè1");
                // Thực hiện xử lý tạo phòng trong DB -Thiện-
                crud.CreateHotel(model.AccountId, model.HotelName, model.HotelAddress, model.Province, model.StartPrice, model.HotelInfo, model.HotelImage);
                return RedirectToAction("OwnerHome", "OwnerHome");
            }

            // Nếu dữ liệu không hợp lệ, quay lại giao diện tạo phòng và hiển thị thông báo lỗi -Thiện-
            return RedirectToAction("OwnerHome", "OwnerHome");
        }

        public ActionResult EditHotel(string HotelId)
        {
            // Lấy thông tin phòng từ database dựa trên roomId
            var hotel = swp1Context.Hotels.FirstOrDefault(h => h.HotelId == HotelId);
            var provinces = new List<string>
    {
        "An Giang", "Bà Rịa - Vũng Tàu", "Bạc Liêu", "Bắc Kạn", "Bắc Giang",
        "Bắc Ninh", "Bến Tre", "Bình Dương", "Bình Định", "Bình Phước",
        "Bình Thuận", "Cà Mau", "Cao Bằng", "Cần Thơ", "Đà Nẵng","Đà Lạt",
        "Đắk Lắk", "Đắk Nông", "Điện Biên", "Đồng Nai", "Đồng Tháp",
        "Gia Lai", "Hà Giang", "Hà Nam", "Hà Nội", "Hà Tĩnh",
        "Hải Dương", "Hải Phòng", "Hậu Giang", "Hòa Bình", "Hồ Chí Minh",
        "Hưng Yên", "Khánh Hòa", "Kiên Giang", "Kon Tum", "Lai Châu",
        "Lâm Đồng", "Lạng Sơn", "Lào Cai", "Long An", "Nam Định",
        "Nghệ An", "Ninh Bình", "Ninh Thuận", "Phú Thọ", "Phú Yên",
        "Quảng Bình", "Quảng Nam", "Quảng Ngãi", "Quảng Ninh", "Quảng Trị",
        "Sóc Trăng", "Sơn La", "Tây Ninh", "Thái Bình", "Thái Nguyên",
        "Thanh Hóa", "Thừa Thiên Huế", "Tiền Giang", "Trà Vinh", "Tuyên Quang",
        "Vĩnh Long", "Vĩnh Phúc", "Yên Bái"
    };
            ViewBag.Provinces = provinces;
            if (hotel != null)
            {
                return View("/Views/Owner/OwnerHotelUpdate.cshtml", hotel);
            }


            // Nếu không tìm thấy phòng, điều hướng về trang danh sách phòng hoặc hiển thị thông báo lỗi
            return RedirectToAction("OwnerHome", "OwnerHome");
        }

        [HttpPost]
        public ActionResult UpdateHotel(Hotel model, string hotelID)
        {
            string mess = null;
            if (ModelState.IsValid)
            {
                var hotel = (from h in swp1Context.Hotels where h.HotelId.Equals(hotelID) select h).FirstOrDefault();
                // Lấy khách sạn từ CSDL dựa trên ID

                // Cập nhật thông tin khách sạn với dữ liệu mới
                //System.IO.File.Move($"~/wwwroot/img/{hotel.Province}/{hotel.HotelName}", model.HotelName);
                hotel.HotelName = model.HotelName;
                hotel.HotelAddress = model.HotelAddress;
                hotel.Province = model.Province;
                hotel.StartPrice = model.StartPrice;
                hotel.HotelInfo = model.HotelInfo;
                hotel.HotelImage = model.HotelImage;
                // Cập nhật các trường thông tin khác

                // Lưu thay đổi vào CSDL
                if (swp1Context.SaveChanges() > 0) mess = "Hotel Updated";

                return RedirectToAction("OwnerHome", "OwnerHome", mess);
            }

            // Xử lý khi không tìm thấy khách sạn
            return RedirectToAction("OwnerHome", "OwnerHome");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHotelConfirmed(string HotelId)
        {
            if (HotelId == null)
            {
                Console.WriteLine("Xoá nè1");
                return RedirectToAction("OwnerHome", "OwnerHome");
            }

            var hotel = swp1Context.Hotels.FirstOrDefault(h => h.HotelId == HotelId);
            if (hotel == null)
            {
                Console.WriteLine("Xoá nè2");
                return RedirectToAction("OwnerHome", "OwnerHome");
            }
            var rooms = swp1Context.Rooms.Where(r => r.HotelId == HotelId);
            swp1Context.Rooms.RemoveRange(rooms);
            Console.WriteLine("Xoá nè");

            // Thực hiện xóa phòng trong database
            swp1Context.Hotels.Remove(hotel);
            swp1Context.SaveChanges();
            //Thông báo xoá phòng thành công
            TempData["DeleteSuccess"] = "Hotel Deleted successfully";
            return RedirectToAction("OwnerHome", "OwnerHome");
        }
    }
}