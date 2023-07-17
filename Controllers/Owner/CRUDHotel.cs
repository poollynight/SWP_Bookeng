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
"An Giang", "Ba Ria - Vung Tau", "Bac Lieu", "Bac Kan", "Bac Giang",
"Bac Ninh", "Ben Tre", "Binh Duong", "Binh Dinh", "Binh Phuoc",
"Binh Thuan", "Ca Mau", "Cao Bang", "Can Tho", "Da Nang", "Da Lat",
"Dak Lak", "Dak Nong", "Dien Bien", "Dong Nai", "Dong Thap",
"Gia Lai", "Ha Giang", "Ha Nam", "Ha Noi", "Ha Tinh",
"Hai Duong", "Hai Phong", "Hau Giang", "Hoa Binh", "Ho Chi Minh",
"Hung Yen", "Khanh Hoa", "Kien Giang", "Kon Tum", "Lai Chau",
"Lam Dong", "Lang Son", "Lao Cai", "Long An", "Nam Dinh",
"Nghe An", "Ninh Binh", "Ninh Thuan", "Phu Tho", "Phu Yen",
"Quang Binh", "Quang Nam", "Quang Ngai", "Quang Ninh", "Quang Tri",
"Soc Trang", "Son La", "Tay Ninh", "Thai Binh", "Thai Nguyen",
"Thanh Hoa", "Thua Thien Hue", "Tien Giang", "Tra Vinh", "Tuyen Quang",
"Vinh Long", "Vinh Phuc", "Yen Bai"
    };

            ViewBag.Provinces = provinces;
            // Hiện form tạo hotel tại đây nhe -Thiện-
            return View("/Views/Owner/CreateHotel.cshtml");
        }

        [HttpPost]
        public ActionResult CreateHotel(Hotel model)
        {
            if (ModelState.IsValid)
            {
               
                // Thực hiện xử lý tạo phòng trong DB -Thiện-
                crud.CreateHotel(model.AccountId, model.HotelName, model.HotelAddress, model.Province, model.StartPrice, model.HotelInfo, model.HotelImage);
                return RedirectToAction("Properties", "OwnerHome");
            }

            // Nếu dữ liệu không hợp lệ, quay lại giao diện tạo phòng và hiển thị thông báo lỗi -Thiện-
            return NotFound(); 
        }

        public ActionResult EditHotel(string HotelId)
        {
            // Lấy thông tin phòng từ database dựa trên roomId
            var hotel = swp1Context.Hotels.FirstOrDefault(h => h.HotelId == HotelId);
            var provinces = new List<string>
    {
"An Giang", "Ba Ria - Vung Tau", "Bac Lieu", "Bac Kan", "Bac Giang",
"Bac Ninh", "Ben Tre", "Binh Duong", "Binh Dinh", "Binh Phuoc",
"Binh Thuan", "Ca Mau", "Cao Bang", "Can Tho", "Da Nang", "Da Lat",
"Dak Lak", "Dak Nong", "Dien Bien", "Dong Nai", "Dong Thap",
"Gia Lai", "Ha Giang", "Ha Nam", "Ha Noi", "Ha Tinh",
"Hai Duong", "Hai Phong", "Hau Giang", "Hoa Binh", "Ho Chi Minh",
"Hung Yen", "Khanh Hoa", "Kien Giang", "Kon Tum", "Lai Chau",
"Lam Dong", "Lang Son", "Lao Cai", "Long An", "Nam Dinh",
"Nghe An", "Ninh Binh", "Ninh Thuan", "Phu Tho", "Phu Yen",
"Quang Binh", "Quang Nam", "Quang Ngai", "Quang Ninh", "Quang Tri",
"Soc Trang", "Son La", "Tay Ninh", "Thai Binh", "Thai Nguyen",
"Thanh Hoa", "Thua Thien Hue", "Tien Giang", "Tra Vinh", "Tuyen Quang",
"Vinh Long", "Vinh Phuc", "Yen Bai"
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

                return RedirectToAction("Properties", "OwnerHome", mess);
            }

            // Xử lý khi không tìm thấy khách sạn
            return RedirectToAction("Properties", "OwnerHome");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteHotelConfirmed(string HotelId)
        {
            // Nếu HotelId truyền về null thì trở lại trang load
            if (HotelId == null)
            {
                ViewBag.mess = "ID is null";
                return RedirectToAction("OwnerHome", "OwnerHome");
            }
            // =============================================
            // Nếu không có khách sạn nào thì sẽ load trở về
            var hotel = swp1Context.Hotels.FirstOrDefault(h => h.HotelId == HotelId);
            if (hotel == null)
            {
                ViewBag.mess = "Nothing found!";
                return RedirectToAction("OwnerHome", "OwnerHome");
            }
            // =============================================

            var rooms = swp1Context.Rooms.Where(r => r.HotelId == HotelId).ToList(); //lấy danh sách các phòng trong cùng hotel
            var hasOrder = swp1Context.Orders.AsEnumerable().Any(o => rooms.Any(r => r.RoomId == o.RoomId)); //Check có order hay không 
            if (hasOrder)
            {
                // Nếu có đơn order
                ViewBag.mess = "Hotel has orders. Action failed";
                return RedirectToAction("OwnerHome", "OwnerHome");
            }
            else
            {
                // Nếu không có đơn order
                foreach (var room in rooms)
                {
                    swp1Context.Rooms.Remove(room);  //Xoá phòng trong khách sạn
                }
                swp1Context.Hotels.Remove(hotel); //Xoá khách sạn 
                swp1Context.SaveChanges();
            }
            //Thông báo xoá khách sạn thành công
            ViewBag.mess = "Hotel Deleted successfully";
            return RedirectToAction("Properties", "OwnerHome");
        }
    }
}
