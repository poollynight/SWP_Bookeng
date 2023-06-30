using System.Data.SqlClient;

namespace SWP_template.Models
{
    public class CRUD
    {
        Random random = new Random();

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void CreateHotel(string accountId, string hotelName, string hotelAddress, string province, string startPrice, string hotelInfo, string avatar)
        {
            using (var dbContext = new Swp1Context())
            {
                int randomNumber = random.Next(1, 1000);
                // Tạo ngẫu nhiên HotelId
                string provinceinput = new(province.Split(' ').Select(word => char.ToUpper(word[0])).ToArray());
                string hotelId = $"H{provinceinput}{randomNumber:D3}";
                var hotel = new Hotel()
                {
                    AccountId = accountId,
                    HotelId = hotelId,
                    HotelName = hotelName,
                    HotelAddress = hotelAddress,
                    Province = province,
                    StartPrice = startPrice,
                    HotelInfo = hotelInfo,
                    HotelImage = avatar
                };

                dbContext.Hotels.Add(hotel);
                dbContext.SaveChanges();
            }
        }

        //cập nhật hotel -Thiện-
        public void UpdateHotel(string AccountId, string HotelId, string HotelName, string HotelAddress, string Province, string StartPrice, string HotelInfo, string HotelImage)
        {
            using var dbContext = new Swp1Context();
            var hotel = dbContext.Hotels.FirstOrDefault(r => r.HotelId == HotelId);
            if (hotel != null)
            {
                hotel.HotelName = HotelName;
                hotel.HotelAddress = HotelAddress;
                hotel.Province = Province;
                hotel.StartPrice = StartPrice;
                hotel.HotelInfo = HotelInfo;
                hotel.HotelImage = HotelImage;
                dbContext.SaveChanges();
            }
        }
        //Xoá hotel -Thiện-
        public void DeleteHotel(string HotelId)
        {
            using var dbContext = new Swp1Context();
            var hotel = dbContext.Rooms.FirstOrDefault(r => r.HotelId == HotelId);
            if (hotel != null)
            {
                dbContext.Rooms.Remove(hotel);
                dbContext.SaveChanges();
            }
        }
        //tạo phòng -Thiện-
        public void CreateRoom(string HotelId, string RoomName, string RoomInfo, string RoomPrice, string BedQuantity, string Wifi, string Window, string Smoking, string RoomImage, int RoomAvailable)
        {
            var RoomId = $"{RandomString(2)}{random.Next(10, 100):D2}";
            using var dbContext = new Swp1Context();
            var room = new Room()
            {
                HotelId = HotelId,
                RoomId = RoomId,
                RoomName = RoomName,
                RoomInfo = RoomInfo,
                RoomPrice = RoomPrice,
                BedQuantity = BedQuantity,
                Wifi = Wifi,
                Window = Window,
                Smoking = Smoking,
                RoomImage = RoomImage,
                RoomAvailable = RoomAvailable
            };
            dbContext.Add(room);
            dbContext.SaveChanges();
        }
        //cập nhật phòng -Thiện-

        public void UpdateRoom(string RoomId, string RoomName, string RoomInfo, string RoomPrice, string BedQuantity, string Wifi, string Window, string Smoking, string RoomImage, int RoomAvailable)
        {
            using var dbContext = new Swp1Context();
            var room = dbContext.Rooms.FirstOrDefault(r => r.RoomId == RoomId);
            if (room != null)
            {
                room.RoomName = RoomName;
                room.RoomInfo = RoomInfo;
                room.RoomPrice = RoomPrice;
                room.BedQuantity = BedQuantity;
                room.Wifi = Wifi;
                room.Window = Window;
                room.Smoking = Smoking;
                room.RoomImage = RoomImage;
                room.RoomAvailable = RoomAvailable;
                dbContext.SaveChanges();
            }
        }
        //Xoá phòng -Thiện-
        public void DeleteRoom(string RoomId)
        {
            using var dbContext = new Swp1Context();
            var room = dbContext.Rooms.FirstOrDefault(r => r.RoomId == RoomId);
            if (room != null)
            {
                dbContext.Rooms.Remove(room);
                dbContext.SaveChanges();
            }
        }
        //Lấy ID của phòng để chọn phòng - Thiện-
        public static Room GetRoomById(string roomId)
        {
            using (var dbContext = new Swp1Context())
            {
                return dbContext.Rooms.FirstOrDefault(r => r.RoomId == roomId);
            }
        }
        //Lấy ID của phòng để chọn ksan -Thiện-
        public static Hotel GetHotelById(string HotelId)
        {
            using (var dbContext = new Swp1Context())
            {
                return dbContext.Hotels.FirstOrDefault(r => r.HotelId == HotelId);
            }
        }
    }
}