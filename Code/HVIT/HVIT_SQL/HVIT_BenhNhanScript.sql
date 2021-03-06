USE [HVITBenhVien]
GO
/****** Object:  Table [dbo].[BacSi]    Script Date: 9/7/2020 6:50:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BacSi](
	[MaBacSi] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](30) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[DienThoai] [char](10) NULL,
	[ChuyenKhoaID] [int] NULL,
 CONSTRAINT [PK_BacSi] PRIMARY KEY CLUSTERED 
(
	[MaBacSi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BenhNhan]    Script Date: 9/7/2020 6:50:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BenhNhan](
	[MaBenhNhan] [int] IDENTITY(1,1) NOT NULL,
	[TenBenhNhan] [nvarchar](30) NULL,
	[DiaChi] [nvarchar](50) NULL,
 CONSTRAINT [PK_BenhNhan] PRIMARY KEY CLUSTERED 
(
	[MaBenhNhan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietBenhNhan]    Script Date: 9/7/2020 6:50:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietBenhNhan](
	[ChiTietBenhNhanID] [int] IDENTITY(1,1) NOT NULL,
	[MaBenhNhan] [int] NULL,
	[BacSiTheoDoiID] [int] NULL,
 CONSTRAINT [PK_ChiTietBenhNhan] PRIMARY KEY CLUSTERED 
(
	[ChiTietBenhNhanID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietDieuTri]    Script Date: 9/7/2020 6:50:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDieuTri](
	[ChiTietDieuTriID] [int] IDENTITY(1,1) NOT NULL,
	[MaBacSi] [int] NULL,
	[MaBenhNhan] [int] NULL,
	[ThoiGianDieuTri] [datetime] NULL,
	[LieuPhap] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChiTietDieuTri] PRIMARY KEY CLUSTERED 
(
	[ChiTietDieuTriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChuyenKhoa]    Script Date: 9/7/2020 6:50:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenKhoa](
	[ChuyenKhoaID] [int] IDENTITY(1,1) NOT NULL,
	[TenChuyenKhoa] [nvarchar](30) NULL,
 CONSTRAINT [PK_ChuyenKhoa] PRIMARY KEY CLUSTERED 
(
	[ChuyenKhoaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BacSi] ON 

INSERT [dbo].[BacSi] ([MaBacSi], [HoTen], [DiaChi], [DienThoai], [ChuyenKhoaID]) VALUES (1, N'Nguyễn Văn A', NULL, NULL, 1)
INSERT [dbo].[BacSi] ([MaBacSi], [HoTen], [DiaChi], [DienThoai], [ChuyenKhoaID]) VALUES (2, N'Trịnh Thị B', NULL, NULL, 1)
INSERT [dbo].[BacSi] ([MaBacSi], [HoTen], [DiaChi], [DienThoai], [ChuyenKhoaID]) VALUES (3, N'Trần C', NULL, NULL, 2)
INSERT [dbo].[BacSi] ([MaBacSi], [HoTen], [DiaChi], [DienThoai], [ChuyenKhoaID]) VALUES (4, N'Dương D', NULL, NULL, 2)
INSERT [dbo].[BacSi] ([MaBacSi], [HoTen], [DiaChi], [DienThoai], [ChuyenKhoaID]) VALUES (5, N'Lường E', NULL, NULL, 3)
INSERT [dbo].[BacSi] ([MaBacSi], [HoTen], [DiaChi], [DienThoai], [ChuyenKhoaID]) VALUES (6, N'Trương F', NULL, NULL, 3)
INSERT [dbo].[BacSi] ([MaBacSi], [HoTen], [DiaChi], [DienThoai], [ChuyenKhoaID]) VALUES (7, N'Lương Thị T', NULL, NULL, 4)
INSERT [dbo].[BacSi] ([MaBacSi], [HoTen], [DiaChi], [DienThoai], [ChuyenKhoaID]) VALUES (8, N'Trần Ngọc L', NULL, NULL, 4)
SET IDENTITY_INSERT [dbo].[BacSi] OFF
SET IDENTITY_INSERT [dbo].[BenhNhan] ON 

INSERT [dbo].[BenhNhan] ([MaBenhNhan], [TenBenhNhan], [DiaChi]) VALUES (1, N'Bệnh nhân 1', NULL)
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [TenBenhNhan], [DiaChi]) VALUES (2, N'Bênh nhân 2', NULL)
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [TenBenhNhan], [DiaChi]) VALUES (3, N'Bênh nhân 3', NULL)
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [TenBenhNhan], [DiaChi]) VALUES (4, N'Bênh nhân 4', NULL)
INSERT [dbo].[BenhNhan] ([MaBenhNhan], [TenBenhNhan], [DiaChi]) VALUES (5, N'Bênh nhân 5', NULL)
SET IDENTITY_INSERT [dbo].[BenhNhan] OFF
SET IDENTITY_INSERT [dbo].[ChiTietBenhNhan] ON 

INSERT [dbo].[ChiTietBenhNhan] ([ChiTietBenhNhanID], [MaBenhNhan], [BacSiTheoDoiID]) VALUES (1, 1, 1)
INSERT [dbo].[ChiTietBenhNhan] ([ChiTietBenhNhanID], [MaBenhNhan], [BacSiTheoDoiID]) VALUES (2, 2, 1)
INSERT [dbo].[ChiTietBenhNhan] ([ChiTietBenhNhanID], [MaBenhNhan], [BacSiTheoDoiID]) VALUES (3, 3, 2)
INSERT [dbo].[ChiTietBenhNhan] ([ChiTietBenhNhanID], [MaBenhNhan], [BacSiTheoDoiID]) VALUES (4, 4, 3)
INSERT [dbo].[ChiTietBenhNhan] ([ChiTietBenhNhanID], [MaBenhNhan], [BacSiTheoDoiID]) VALUES (5, 5, 4)
SET IDENTITY_INSERT [dbo].[ChiTietBenhNhan] OFF
SET IDENTITY_INSERT [dbo].[ChiTietDieuTri] ON 

INSERT [dbo].[ChiTietDieuTri] ([ChiTietDieuTriID], [MaBacSi], [MaBenhNhan], [ThoiGianDieuTri], [LieuPhap]) VALUES (1, 5, 1, NULL, NULL)
INSERT [dbo].[ChiTietDieuTri] ([ChiTietDieuTriID], [MaBacSi], [MaBenhNhan], [ThoiGianDieuTri], [LieuPhap]) VALUES (2, 6, 2, NULL, NULL)
INSERT [dbo].[ChiTietDieuTri] ([ChiTietDieuTriID], [MaBacSi], [MaBenhNhan], [ThoiGianDieuTri], [LieuPhap]) VALUES (3, 7, 3, NULL, NULL)
INSERT [dbo].[ChiTietDieuTri] ([ChiTietDieuTriID], [MaBacSi], [MaBenhNhan], [ThoiGianDieuTri], [LieuPhap]) VALUES (4, 8, 4, NULL, NULL)
INSERT [dbo].[ChiTietDieuTri] ([ChiTietDieuTriID], [MaBacSi], [MaBenhNhan], [ThoiGianDieuTri], [LieuPhap]) VALUES (5, 4, 5, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ChiTietDieuTri] OFF
SET IDENTITY_INSERT [dbo].[ChuyenKhoa] ON 

INSERT [dbo].[ChuyenKhoa] ([ChuyenKhoaID], [TenChuyenKhoa]) VALUES (1, N'Chuyên khoa 1')
INSERT [dbo].[ChuyenKhoa] ([ChuyenKhoaID], [TenChuyenKhoa]) VALUES (2, N'Chuyên khoa 2')
INSERT [dbo].[ChuyenKhoa] ([ChuyenKhoaID], [TenChuyenKhoa]) VALUES (3, N'Chuyên khoa 3')
INSERT [dbo].[ChuyenKhoa] ([ChuyenKhoaID], [TenChuyenKhoa]) VALUES (4, N'Chuyên khoa 4')
SET IDENTITY_INSERT [dbo].[ChuyenKhoa] OFF
ALTER TABLE [dbo].[BacSi]  WITH CHECK ADD  CONSTRAINT [FK_BacSi_ChuyenKhoa] FOREIGN KEY([ChuyenKhoaID])
REFERENCES [dbo].[ChuyenKhoa] ([ChuyenKhoaID])
GO
ALTER TABLE [dbo].[BacSi] CHECK CONSTRAINT [FK_BacSi_ChuyenKhoa]
GO
ALTER TABLE [dbo].[ChiTietBenhNhan]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietBenhNhan_BacSi] FOREIGN KEY([BacSiTheoDoiID])
REFERENCES [dbo].[BacSi] ([MaBacSi])
GO
ALTER TABLE [dbo].[ChiTietBenhNhan] CHECK CONSTRAINT [FK_ChiTietBenhNhan_BacSi]
GO
ALTER TABLE [dbo].[ChiTietBenhNhan]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietBenhNhan_BenhNhan] FOREIGN KEY([MaBenhNhan])
REFERENCES [dbo].[BenhNhan] ([MaBenhNhan])
GO
ALTER TABLE [dbo].[ChiTietBenhNhan] CHECK CONSTRAINT [FK_ChiTietBenhNhan_BenhNhan]
GO
ALTER TABLE [dbo].[ChiTietDieuTri]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDieuTri_BacSi] FOREIGN KEY([MaBacSi])
REFERENCES [dbo].[BacSi] ([MaBacSi])
GO
ALTER TABLE [dbo].[ChiTietDieuTri] CHECK CONSTRAINT [FK_ChiTietDieuTri_BacSi]
GO
ALTER TABLE [dbo].[ChiTietDieuTri]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDieuTri_BenhNhan] FOREIGN KEY([MaBenhNhan])
REFERENCES [dbo].[BenhNhan] ([MaBenhNhan])
GO
ALTER TABLE [dbo].[ChiTietDieuTri] CHECK CONSTRAINT [FK_ChiTietDieuTri_BenhNhan]
GO
USE [master]
GO
ALTER DATABASE [HVITBenhVien] SET  READ_WRITE 
GO
