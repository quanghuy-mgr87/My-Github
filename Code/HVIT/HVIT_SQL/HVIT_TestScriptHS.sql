
USE test
GO
/****** Object:  Table [dbo].[HocSinh]    Script Date: 7/7/2020 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HocSinh](
	[HocSinhID] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[TenLop] [nvarchar](50) NULL,
	[Email] [char](20) NULL,
 CONSTRAINT [PK_HocSinh] PRIMARY KEY CLUSTERED 
(
	[HocSinhID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 7/7/2020 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MonHocID] [int] IDENTITY(1,1) NOT NULL,
	[TenMon] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](50) NULL,
 CONSTRAINT [PK_MonHoc] PRIMARY KEY CLUSTERED 
(
	[MonHocID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuanLyHS]    Script Date: 7/7/2020 2:47:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuanLyHS](
	[HocSinhID] [int] NULL,
	[MonHocID] [int] NULL,
	[DiemPhay] [float] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[HocSinh] ON 

INSERT [dbo].[HocSinh] ([HocSinhID], [HoTen], [DiaChi], [TenLop], [Email]) VALUES (1, N'Nguyễn Thị D', NULL, NULL, NULL)
INSERT [dbo].[HocSinh] ([HocSinhID], [HoTen], [DiaChi], [TenLop], [Email]) VALUES (4, N'Nguyễn Văn A', NULL, NULL, NULL)
INSERT [dbo].[HocSinh] ([HocSinhID], [HoTen], [DiaChi], [TenLop], [Email]) VALUES (5, N'Chu Quang D', NULL, NULL, NULL)
INSERT [dbo].[HocSinh] ([HocSinhID], [HoTen], [DiaChi], [TenLop], [Email]) VALUES (6, N'Trịnh Đình Dũng', NULL, NULL, NULL)
INSERT [dbo].[HocSinh] ([HocSinhID], [HoTen], [DiaChi], [TenLop], [Email]) VALUES (7, N'Lương Xuân Huy', NULL, NULL, NULL)
INSERT [dbo].[HocSinh] ([HocSinhID], [HoTen], [DiaChi], [TenLop], [Email]) VALUES (8, N'Trần Đức Long', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[HocSinh] OFF
SET IDENTITY_INSERT [dbo].[MonHoc] ON 

INSERT [dbo].[MonHoc] ([MonHocID], [TenMon], [GhiChu]) VALUES (1, N'Toán', NULL)
INSERT [dbo].[MonHoc] ([MonHocID], [TenMon], [GhiChu]) VALUES (2, N'Lý', NULL)
INSERT [dbo].[MonHoc] ([MonHocID], [TenMon], [GhiChu]) VALUES (3, N'Hóa', NULL)
INSERT [dbo].[MonHoc] ([MonHocID], [TenMon], [GhiChu]) VALUES (4, N'Sinh', NULL)
INSERT [dbo].[MonHoc] ([MonHocID], [TenMon], [GhiChu]) VALUES (5, N'Sử', NULL)
INSERT [dbo].[MonHoc] ([MonHocID], [TenMon], [GhiChu]) VALUES (6, N'Địa', NULL)
INSERT [dbo].[MonHoc] ([MonHocID], [TenMon], [GhiChu]) VALUES (7, N'Tin', NULL)
SET IDENTITY_INSERT [dbo].[MonHoc] OFF
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (1, 1, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (1, 2, 7.7)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (1, 3, 7.7)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (1, 4, 7.7)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (1, 5, 7.7)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (1, 6, 7.7)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (4, 1, 9)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (4, 2, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (5, 1, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (6, 1, 2.3)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (7, 1, 4.5)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (7, 7, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (6, 7, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (5, 7, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (4, 7, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (1, 7, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (1, 1, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (1, 2, 7.7)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (1, 3, 7.7)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (1, 4, 7.7)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (1, 5, 7.7)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (1, 6, 7.7)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (4, 1, 9)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (4, 2, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (5, 1, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (6, 1, 2.3)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (7, 1, 4.5)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (7, 7, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (6, 7, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (5, 7, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (4, 7, 8.8)
INSERT [dbo].[QuanLyHS] ([HocSinhID], [MonHocID], [DiemPhay]) VALUES (1, 7, 8.8)
ALTER TABLE [dbo].[QuanLyHS]  WITH CHECK ADD  CONSTRAINT [FK_QuanLyHS_HocSinh] FOREIGN KEY([HocSinhID])
REFERENCES [dbo].[HocSinh] ([HocSinhID])
GO
ALTER TABLE [dbo].[QuanLyHS] CHECK CONSTRAINT [FK_QuanLyHS_HocSinh]
GO
ALTER TABLE [dbo].[QuanLyHS]  WITH CHECK ADD  CONSTRAINT [FK_QuanLyHS_MonHoc] FOREIGN KEY([MonHocID])
REFERENCES [dbo].[MonHoc] ([MonHocID])
GO
ALTER TABLE [dbo].[QuanLyHS] CHECK CONSTRAINT [FK_QuanLyHS_MonHoc]
GO
USE [master]
GO
ALTER DATABASE [HocSinh] SET  READ_WRITE 
GO
