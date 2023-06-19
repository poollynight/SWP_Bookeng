
/****** Object:  Database [Bookeng]    Script Date: 6/17/2023 11:35:56 PM ******/
CREATE DATABASE [Bookeng]
 CONTAINMENT = NONE
 

GO
ALTER DATABASE [Bookeng] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Bookeng].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Bookeng] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Bookeng] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Bookeng] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Bookeng] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Bookeng] SET ARITHABORT OFF 
GO
ALTER DATABASE [Bookeng] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Bookeng] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Bookeng] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Bookeng] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Bookeng] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Bookeng] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Bookeng] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Bookeng] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Bookeng] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Bookeng] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Bookeng] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Bookeng] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Bookeng] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Bookeng] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Bookeng] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Bookeng] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Bookeng] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Bookeng] SET RECOVERY FULL 
GO
ALTER DATABASE [Bookeng] SET  MULTI_USER 
GO
ALTER DATABASE [Bookeng] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Bookeng] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Bookeng] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Bookeng] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Bookeng] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Bookeng] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SWP1', N'ON'
GO
ALTER DATABASE [Bookeng] SET QUERY_STORE = ON
GO
ALTER DATABASE [Bookeng] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Bookeng]
GO
/****** Object:  Table [dbo].[AccountRole]    Script Date: 6/17/2023 11:35:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountRole](
	[role] [varchar](10) NOT NULL,
	[roleID] [varchar](10) NOT NULL,
 CONSTRAINT [PK_AccountRole] PRIMARY KEY CLUSTERED 
(
	[roleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 6/17/2023 11:35:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account]( 
	[AccountID] [varchar](20) NOT NULL,
	[username] [varchar](255) NOT NULL,
	[password] [varchar](255) NOT NULL,
	[roleID] [varchar](10) NOT NULL,
	[email] [varchar](50) NULL,
	[name] [varchar](50) NULL,
	[phone] [varchar](20) NULL,
	[birthday] [varchar](50) NULL,
	[nation] [varchar](50) NULL,
	[gender] [varchar](10) NULL,
	[identitycard] [varchar](30) NULL,
 CONSTRAINT [PK_Accountss] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [username] UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 6/17/2023 11:35:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[AccountID] [varchar](20) NOT NULL,
	[HotelID] [varchar](20) NOT NULL,
	[HotelName] [varchar](50) NOT NULL,
	[HotelAddress] [varchar](255) NOT NULL,
	[HotelInfo] [varchar](255) NOT NULL,
	[Province] [varchar](50) NULL,
	[StartPrice] [varchar](20) NULL,
	[HotelImage] [varchar](255) NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [HotelID] UNIQUE NONCLUSTERED 
(
	[HotelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/17/2023 11:35:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE  [dbo].[Order] (
  RoomID VARCHAR(20) NOT NULL,
  RoomName VARCHAR(20) NOT NULL,
  AccountID VARCHAR(20) NOT NULL,
  CheckIn VARCHAR(20) NOT NULL,
  CheckOut VARCHAR(20) NOT NULL,
  NumberOrder INT NOT NULL,
  PRIMARY KEY (RoomID, AccountID),
  FOREIGN KEY (RoomID) REFERENCES Room(RoomID),
  FOREIGN KEY (AccountID) REFERENCES Accountss(AccountID)
);
GO
/****** Object:  Table [dbo].[Room]    Script Date: 6/17/2023 11:35:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[HotelID] [varchar](20) NOT NULL,
	[RoomID] [varchar](20) NOT NULL,
	[RoomName] [varchar](20) NOT NULL,
	[RoomInfo] [varchar](255) NOT NULL,
	[RoomPrice] [varchar](20) NOT NULL,
	[BedQuantity] [varchar](20) NOT NULL,
	[Wifi] [binary](1) NOT NULL,
	[Window] [binary](1) NOT NULL,
	[Smoking] [binary](1) NOT NULL,
	[RoomImage] [varchar](255) NULL,
	[RoomAvailable] [int] NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Accountss_AccountRole] FOREIGN KEY([roleID])
REFERENCES [dbo].[AccountRole] ([roleID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Accountss_AccountRole]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Accountss] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Account] ([AccountID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Accountss]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Room] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Room] ([RoomID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Room]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Hotel] FOREIGN KEY([HotelID])
REFERENCES [dbo].[Hotel] ([HotelID])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Hotel]
GO
USE [master]
GO
ALTER DATABASE [Bookeng] SET  READ_WRITE 
GO
INSERT [dbo].[AccountRole] ( [role], [roleID]) VALUES ( N'Admin', N'R001')
INSERT [dbo].[AccountRole] ( [role], [roleID]) VALUES ( N'Owner', N'R002')
INSERT [dbo].[AccountRole] ( [role], [roleID]) VALUES ( N'User', N'R003')
Go
INSERT [dbo].[Account] ([AccountID],[username],[password],[roleID],[email],[name],[phone],[birthday],[nation],[gender],[identitycard]) VALUES (N'A001', N'admin1', N'password1', N'R001', N'admin4@example.com',N'Admin1',  N'987654321', N'1991-07-15', N'USA', N'Female', N'5678904321')
INSERT [dbo].[Account] ([AccountID],[username],[password],[roleID],[email],[name],[phone],[birthday],[nation],[gender],[identitycard]) VALUES (N'A002', N'admin2', N'password1', N'R001', N'admin5@example.com',N'Admin2',  N'123456789',  N'1996-04-20', N'USA', N'Male', N'3456789012')
INSERT [dbo].[Account] ([AccountID],[username],[password],[roleID],[email],[name],[phone],[birthday],[nation],[gender],[identitycard]) VALUES (N'U001', N'user1', N'user123', N'R003', N'user1@example.com',N'User 1',  N'987654321',  N'1994-08-05', N'USA', N'Female', N'2345678901')
INSERT [dbo].[Account] ([AccountID],[username],[password],[roleID],[email],[name],[phone],[birthday],[nation],[gender],[identitycard]) VALUES (N'U002', N'user2', N'user123', N'R003', N'user2@example.com',N'User 2',  N'543216789',  N'1999-03-18', N'USA', N'Male', N'1234567890')
INSERT [dbo].[Account] ([AccountID],[username],[password],[roleID],[email],[name],[phone],[birthday],[nation],[gender],[identitycard]) VALUES (N'O001', N'Owner1', N'owner123', N'R002', N'owner1@example.com',N'Owner 1',  N'987654321',  N'1994-08-05', N'USA', N'Female', N'2345678901')
INSERT [dbo].[Account] ([AccountID],[username],[password],[roleID],[email],[name],[phone],[birthday],[nation],[gender],[identitycard]) VALUES (N'O002', N'Owner2', N'owner123', N'R002', N'owner2@example.com', N'Owner 2',  N'543216789',  N'1999-03-18', N'USA', N'Male', N'1234567890')
Go
Go
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O001', N'H001', N'Wink Hotel Danang Centre', N'178 Đư?ng Tr?n Phú', N'Da Nang', N'300,000   ', N'This is Hotel 1 in Da Nang', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O001', N'H002', N'Menora Premium Da Nang - Sea Corner Boutique', N'196 Tran Bach Dang Street, My An Ward, Ngu Hanh Son District', N'Da Nang', N'400,000   ', N'This is Hotel 2 in Da Nang', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O001', N'H003', N'Señorita Boutique Hotel', N'89 Tran Bach Dang', N'Da Nang', N'350,000   ', N'This is Hotel 3 in Da Nang', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O001', N'H004', N'Seashore Hotel & Apartment', N'Lot 15 - 16 Hoang Sa Opposite Man Thai Beach', N'Da Nang', N'600,000   ', N'This is Hotel 4 in Da Nang', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O001', N'H005', N'Star City Riverside Hotel By Haviland', N'147-149 Tran Hung Dao, Nai Hien Dong, Son Tra', N'Da Nang', N'700,000   ', N'This is Hotel 5 in Da Nang', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O001', N'H006', N'iHome Hoi An', N'54 Nguy?n Tri Phương, C?m Nam', N'Hoi An', N'380,000   ', N'This is Hotel 1 in Hoi An', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O001', N'H007', N'Blooms Boutique Village', N'85 Le Hong Phong Street, Tan An Ward, Tân An', N'Hoi An', N'400,000   ', N'This is Hotel 2 in Hoi An', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O001', N'H008', N'Nghê Prana Villa & Spa Hoi An', N'T? 7, kh?i Hà Trung, Phư?ng C?m Nam, C?m Nam', N'Hoi An', N'500,000   ', N'This is Hotel 3 in Hoi An', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O002', N'H009', N'Hoi An Golden Holiday Hotel & Spa', N'467 Hai Ba Trung, C?m Phô', N'Hoi An', N'270,000   ', N'This is Hotel 4 in Hoi An', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O002', N'H010', N'Hanoi Paradise Center Hotel & Spa', N'22/5 Hang Voi Street, Ly Thai To Ward, Hoan Kiem District, Vietnam, Qu?n Hoàn Ki?mt', N'Ha Noi', N'500,000   ', N'This is Hotel 1 in Ha Noi', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O002', N'H011', N'La Passion Hanoi Hotel & Spa', N'Hàng Thùng 26, Qu?n Hoàn Ki?m', N'Ha Noi', N'300,000   ', N'This is Hotel 2 in Ha Noi', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O002', N'H012', N'22Land Residence Hotel & Spa 52 Ngo Huyen', N'52 - 54 Ngo Huyen , Qu?n Hoàn Ki?m', N'Ha Noi', N'700,000   ', N'This is Hotel 3 in Ha Noi', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O002', N'H014', N'Icon Saigon - LifeStyle Design Hotel', N'65-67 Hai Ba Trung, Qu?n 1', N'Ho Chi Minh', N'700,000   ', N'This is Hotel 1 in Ho Chi Minh', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O002', N'H015', N'Triple E Hotel Metro Ben Thanh', N'Phư?ng Nguy?n Thái B?nh 146- 148 Đư?ng K? Con, Qu?n 1', N'Ho Chi Minh', N'500,000   ', N'This is Hotel 2 in Ho Chi Minh', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O002', N'H016', N'Calista Sai Gon Hotel', N'247-249, Ly Tu Trong, Ben Thanh Ward, Qu?n 1', N'Ho Chi Minh', N'800,000   ', N'This is Hotel 3 in Ho Chi Minh', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O002', N'H017', N'Jade Scene Hotel', N'30/42 Nguyen Cong Tru', N'Hue', N'275,000   ', N'This is Hotel 1 in Hue', N'avt.jpg')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress], [Province], [StartPrice], [HotelInfo], [HotelImage]) VALUES (N'O002', N'H018', N'Nana Homestay & Villa', N'26/1/147 Phan Đ?nh Phùng 3', N'Hue', N'320,000   ', N'This is Hotel 2 in Hue', N'avt.jpg')
GO
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H001', N'AB001', N'Room 1', N'Standard Room with city view', N'100.00', N'2', 0x01, 0x01, 0x00, N'room1.jpg', 10)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H001', N'AB002', N'Room 2', N'Deluxe Room with ocean view', N'150.00', N'2', 0x01, 0x01, 0x00, N'room2.jpg', 5)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H001', N'AB003', N'Room 1', N'Standard Room with mountain view', N'100.00', N'2', 0x01, 0x01, 0x00, N'room3.jpg', 8)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H001', N'AB004', N'Room 2', N'Deluxe Room with garden view', N'150.00', N'2', 0x01, 0x01, 0x00, N'room4.jpg', 3)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H001', N'AB005', N'Room 1', N'Standard Room with pool view', N'100.00', N'2', 0x01, 0x01, 0x00, N'room5.jpg', 12)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H001', N'AB006', N'Room 2', N'Deluxe Room with city view', N'150.00', N'2', 0x01, 0x01, 0x00, N'room6.jpg', 6)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H001', N'BM007', N'Room 1', N'Standard Room with ocean view', N'100.00', N'2', 0x01, 0x01, 0x00, N'room7.jpg', 9)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H001', N'BM008', N'Room 2', N'Deluxe Room with mountain view', N'150.00', N'2', 0x01, 0x01, 0x00, N'room8.jpg', 4)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H001', N'BM009', N'Room 1', N'Standard Room with garden view', N'100.00', N'2', 0x01, 0x01, 0x00, N'room9.jpg', 15)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H001', N'BM010', N'Room 2', N'Deluxe Room with pool view', N'150.00', N'2', 0x01, 0x01, 0x00, N'room10.jpg', 7)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H001', N'BM011', N'Room 1', N'Standard Room with city view', N'100.00', N'2', 0x01, 0x01, 0x00, N'room11.jpg', 11)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H001', N'BM012', N'Room 2', N'Deluxe Room with ocean view', N'150.00', N'2', 0x01, 0x01, 0x00, N'room12.jpg', 2)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H002', N'BM013', N'Room 1', N'Standard Room with mountain view', N'100.00', N'2', 0x01, 0x01, 0x00, N'room13.jpg', 6)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H002', N'BM014', N'Room 2', N'Deluxe Room with garden view', N'150.00', N'2', 0x01, 0x01, 0x00, N'room14.jpg', 1)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H002', N'BM015', N'Room 1', N'Standard Room with pool view', N'100.00', N'2', 0x01, 0x01, 0x00, N'room15.jpg', 9)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H002', N'BM016', N'Room 2', N'Deluxe Room with city view', N'150.00', N'2', 0x01, 0x01, 0x00, N'room16.jpg', 3)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H002', N'BM017', N'Room 1', N'Standard Room with ocean view', N'100.00', N'2', 0x01, 0x01, 0x00, N'room17.jpg', 12)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H002', N'BM018', N'Room 2', N'Deluxe Room with mountain view', N'150.00', N'2', 0x01, 0x01, 0x00, N'room18.jpg', 5)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H012', N'BM019', N'Room 1', N'Standard Room with garden view', N'100.00', N'2', 0x01, 0x01, 0x00, N'room19.jpg', 14)
INSERT [dbo].[Room] ([HotelID], [RoomID], [RoomName], [RoomInfo], [RoomPrice], [BedQuantity], [Wifi], [Window], [Smoking], [RoomImage], [RoomAvailable]) VALUES (N'H012', N'BM020', N'Room 2', N'Deluxe Room with pool view', N'150.00', N'2', 0x01, 0x01, 0x00, N'room20.jpg', 8)
Go
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'U001',  N'AB001', N'Room 1', N'2023-06-10', N'2023-06-12', 1)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'U001',  N'AB002', N'Room 2', N'2023-06-11', N'2023-06-14', 2)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'U001',  N'AB003', N'Room 3', N'2023-06-12', N'2023-06-15', 3)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'U001',  N'AB004', N'Room 4', N'2023-06-13', N'2023-06-16', 4)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'U001', N'AB005', N'Room 5', N'2023-06-14', N'2023-06-17', 5)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'U001',  N'AB006', N'Room 6', N'2023-06-15', N'2023-06-18', 6)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'U002',  N'BM007', N'Room 7', N'2023-06-16', N'2023-06-19', 7)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'U002',  N'BM008', N'Room 8', N'2023-06-17', N'2023-06-20', 8)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'U002',  N'BM009', N'Room 9', N'2023-06-18', N'2023-06-21', 9)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'U002',  N'BM010', N'Room 10', N'2023-06-19', N'2023-06-22', 10)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'U002',  N'BM011', N'Room 11', N'2023-06-20', N'2023-06-23', 11)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'U002',  N'BM012', N'Room 12', N'2023-06-21', N'2023-06-24', 12)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'U002',  N'BM013', N'Room 13', N'2023-06-22', N'2023-06-25', 13)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'U002',  N'BM014', N'Room 14', N'2023-06-23', N'2023-06-26', 14)
go
ALTER TABLE Account
ALTER COLUMN AccountID DROP IDENTITY;

