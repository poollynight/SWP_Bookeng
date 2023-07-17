-- OrderSelectByMonth 7

 CREATE PROCEDURE OrderSelectByMonth
    @MONTH INT
AS BEGIN 
    select MONTH(ord.CheckIn) as Months,  hotel.HotelName as Name, COUNT(hotel.HotelID) as Total
from [SWP1].[dbo].[Order] ord join [SWP1].[dbo].[Room] room on ord.RoomID = room.RoomID join [SWP1].[dbo].[Hotel] hotel on room.HotelID = hotel.HotelID
WHERE MONTH(ord.CheckIn) = @MONTH
 GROUP BY MONTH(ord.CheckIn) , hotel.HotelName
 ORDER BY MONTH(ord.CheckIn)
 END
