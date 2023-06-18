
/****** Object:  Database [SWP]    Script Date: 6/17/2023 11:35:56 PM ******/
CREATE DATABASE [SWP]
 CONTAINMENT = NONE
 

GO
ALTER DATABASE [SWP] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SWP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SWP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SWP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SWP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SWP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SWP] SET ARITHABORT OFF 
GO
ALTER DATABASE [SWP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SWP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SWP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SWP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SWP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SWP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SWP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SWP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SWP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SWP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SWP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SWP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SWP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SWP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SWP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SWP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SWP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SWP] SET RECOVERY FULL 
GO
ALTER DATABASE [SWP] SET  MULTI_USER 
GO
ALTER DATABASE [SWP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SWP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SWP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SWP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SWP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SWP] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'SWP', N'ON'
GO
ALTER DATABASE [SWP] SET QUERY_STORE = ON
GO
ALTER DATABASE [SWP] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SWP]
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
/****** Object:  Table [dbo].[Accountss]    Script Date: 6/17/2023 11:35:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accountss](
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
	[HotelProvince] [varchar](50) NULL,
	[HotelPrice] [varchar](20) NULL,
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
CREATE TABLE [dbo].[Order](
	[AccountID] [varchar](20) NOT NULL,
	[RoomID] [varchar](20) NOT NULL,
	[RoomName] [varchar](20) NOT NULL,
	[CheckIn] [varchar](20) NOT NULL,
	[CheckOut] [varchar](20) NOT NULL,
	[NumberOrder] [int] NULL
) ON [PRIMARY]
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
ALTER TABLE [dbo].[Accountss]  WITH CHECK ADD  CONSTRAINT [FK_Accountss_AccountRole] FOREIGN KEY([role])
REFERENCES [dbo].[AccountRole] ([roleID])
GO
ALTER TABLE [dbo].[Accountss] CHECK CONSTRAINT [FK_Accountss_AccountRole]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Accountss] FOREIGN KEY([AccountID])
REFERENCES [dbo].[Accountss] ([AccountID])
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
ALTER DATABASE [SWP] SET  READ_WRITE 
GO
INSERT [dbo].[AccountRole] ( [role], [roleID]) VALUES ( N'Admin', N'R001')
INSERT [dbo].[AccountRole] ( [role], [roleID]) VALUES ( N'Owner', N'R002')
INSERT [dbo].[AccountRole] ( [role], [roleID]) VALUES ( N'User', N'R003')
Go
INSERT [dbo].[Accountss] ([AccountID], [username], [password], [roleID], [email]) VALUES (N'A004', N'admin1', N'password1', N'R001', N'admin4@example.com')
INSERT [dbo].[Accountss] ([AccountID], [username], [password], [roleID], [email]) VALUES (N'A005', N'admin2', N'password1', N'R001', N'admin5@example.com')
INSERT [dbo].[Accountss] ([AccountID], [username], [password], [roleID], [email]) VALUES (N'A006', N'user1', N'user123', N'R003', N'user1@example.com')
INSERT [dbo].[Accountss] ([AccountID], [username], [password], [roleID], [email]) VALUES (N'A007', N'user2', N'user123', N'R003', N'user2@example.com')
INSERT [dbo].[Accountss] ([AccountID], [username], [password], [roleID], [email]) VALUES (N'O008', N'Owner1', N'owner123', N'R002', N'owner1@example.com')
INSERT [dbo].[Accountss] ([AccountID], [username], [password], [roleID], [email]) VALUES (N'O009', N'Owner2', N'owner123', N'R002', N'owner2@example.com')
GO
INSERT [dbo].[InfoAccount] ([AccountID], [name], [age], [phone], [email], [birthday], [nation], [gender], [identitycard]) VALUES (N'A004', N'Admin1', N'32', N'987654321', N'admin1@example.com', N'1991-07-15', N'USA', N'Female', N'5678904321')
INSERT [dbo].[InfoAccount] ([AccountID], [name], [age], [phone], [email], [birthday], [nation], [gender], [identitycard]) VALUES (N'A005', N'Admin2', N'27', N'123456789', N'admin2@example.com', N'1996-04-20', N'USA', N'Male', N'3456789012')
INSERT [dbo].[InfoAccount] ([AccountID], [name], [age], [phone], [email], [birthday], [nation], [gender], [identitycard]) VALUES (N'A006', N'User 1', N'29', N'987654321', N'user1@example.com', N'1994-08-05', N'USA', N'Female', N'2345678901')
INSERT [dbo].[InfoAccount] ([AccountID], [name], [age], [phone], [email], [birthday], [nation], [gender], [identitycard]) VALUES (N'A007', N'User 2', N'24', N'543216789', N'user2@example.com', N'1999-03-18', N'USA', N'Male', N'1234567890')
INSERT [dbo].[InfoAccount] ([AccountID], [name], [age], [phone], [email], [birthday], [nation], [gender], [identitycard]) VALUES (N'O008', N'Owner 1', N'29', N'987654321', N'Owner1@example.com', N'1994-08-05', N'USA', N'Female', N'2345678901')
INSERT [dbo].[InfoAccount] ([AccountID], [name], [age], [phone], [email], [birthday], [nation], [gender], [identitycard]) VALUES (N'O009', N'Owner 2', N'24', N'543216789', N'Owner2@example.com', N'1999-03-18', N'USA', N'Male', N'1234567890')

Go
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O008', N'H001', N'Hotel 1', N'123 ABC Street',N'Da Nang', N'300,000', N'This is Hotel 1 in Da Nang','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O008', N'H002', N'Hotel 2', N'456 XYZ Street',N'Da Nang', N'400,000', N'This is Hotel 2 in Da Nang','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O008', N'H003', N'Hotel 3', N'789 DEF Street',N'Da Nang', N'350,000', N'This is Hotel 3 in Da Nang','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O008', N'H004', N'Hotel 4', N'321 GHI Street',N'Da Nang', N'600,000', N'This is Hotel 4 in Da Nang','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O008', N'H005', N'Hotel 5', N'654 JKL Street',N'Da Nang', N'700,000', N'This is Hotel 5 in Da Nang','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O008', N'H006', N'Hotel 1', N'987 MNO Street',N'Hoi An', N'380,000', N'This is Hotel 1 in Hoi An','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O008', N'H007', N'Hotel 2', N'123 PQR Street',N'Hoi An', N'400,000', N'This is Hotel 2 in Hoi An','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O008', N'H008', N'Hotel 3', N'456 STU Street',N'Hoi An', N'500,000', N'This is Hotel 3 in Hoi An','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O008', N'H009', N'Hotel 4', N'789 VWX Street',N'Hoi An', N'270,000', N'This is Hotel 4 in Hoi An','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O008', N'H010', N'Hotel 1', N'321 YZA Street',N'Ha Noi', N'500,000', N'This is Hotel 1 in Ha Noi','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O009', N'H011', N'Hotel 2', N'654 BCD Street',N'Ha Noi', N'300,000', N'This is Hotel 2 in Ha Noi','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O009', N'H012', N'Hotel 3', N'987 EFG Street',N'Ha Noi', N'700,000', N'This is Hotel 3 in Ha Noi','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O009', N'H013', N'Hotel 4', N'123 HIJ Street',N'Ha Noi', N'400,000', N'This is Hotel 4 in Ha Noi','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O009', N'H014', N'Hotel 1', N'456 KLM Street',N'Ho Chi Minh', N'700,000', N'This is Hotel 1 in Ho Chi Minh','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O009', N'H015', N'Hotel 2', N'789 NOP Street',N'Ho Chi Minh', N'500,000', N'This is Hotel 2 in Ho Chi Minh','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O009', N'H016', N'Hotel 3', N'321 QRS Street',N'Ho Chi Minh', N'800,000', N'This is Hotel 3 in Ho Chi Minh','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O009', N'H017', N'Hotel 1', N'654 TUV Street',N'Hue', N'275,000', N'This is Hotel 1 in Hue','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'O009', N'H018', N'Hotel 2', N'987 WXY Street',N'Hue', N'320,000', N'This is Hotel 2 in Hue','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'A002', N'H019', N'Hotel 3', N'123 ZAB Street',N'Hue', N'460,000', N'This is Hotel 3 in Hue','avt')
INSERT [dbo].[Hotel] ([AccountID], [HotelID], [HotelName], [HotelAddress],[Province], [StartPrice], [HotelInfo],[Avartar]) VALUES (N'A002', N'H020', N'Hotel 4', N'456 CDE Street',N'Hue', N'500,000', N'This is Hotel 4 in Hue','avt')
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
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'A006',  N'AB001', N'Room 1', N'2023-06-10', N'2023-06-12', 1)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'A006',  N'AB002', N'Room 2', N'2023-06-11', N'2023-06-14', 2)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'A006',  N'AB003', N'Room 3', N'2023-06-12', N'2023-06-15', 3)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'A006',  N'AB004', N'Room 4', N'2023-06-13', N'2023-06-16', 4)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'A006', N'AB005', N'Room 5', N'2023-06-14', N'2023-06-17', 5)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'A006',  N'AB006', N'Room 6', N'2023-06-15', N'2023-06-18', 6)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'A007',  N'BM007', N'Room 7', N'2023-06-16', N'2023-06-19', 7)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'A007',  N'BM008', N'Room 8', N'2023-06-17', N'2023-06-20', 8)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'A007',  N'BM009', N'Room 9', N'2023-06-18', N'2023-06-21', 9)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'A007',  N'BM010', N'Room 10', N'2023-06-19', N'2023-06-22', 10)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'A007',  N'BM011', N'Room 11', N'2023-06-20', N'2023-06-23', 11)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'A007',  N'BM012', N'Room 12', N'2023-06-21', N'2023-06-24', 12)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'A007',  N'BM013', N'Room 13', N'2023-06-22', N'2023-06-25', 13)
INSERT [dbo].[Order] ([AccountID],  [RoomID], [RoomName], [CheckIn], [CheckOut], [NumberOrder]) VALUES (N'A007',  N'BM014', N'Room 14', N'2023-06-23', N'2023-06-26', 14)

