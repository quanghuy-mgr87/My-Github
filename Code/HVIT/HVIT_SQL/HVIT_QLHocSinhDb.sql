USE [QLHocSinhDb]
GO
/****** Object:  Table [dbo].[HocSinhs]    Script Date: 01-Nov-20 4:56:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocSinhs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](max) NULL,
	[NgaySinh] [datetime2](7) NOT NULL,
	[LopId] [int] NULL,
	[QueQuan] [nvarchar](max) NULL,
	[GioiTinh] [nvarchar](max) NULL,
 CONSTRAINT [PK_HocSinhs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiKhoaHocs]    Script Date: 01-Nov-20 4:56:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiKhoaHocs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChuDe] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoaiKhoaHocs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lops]    Script Date: 01-Nov-20 4:56:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lops](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenLop] [nvarchar](max) NULL,
	[LinkAnh] [nvarchar](max) NULL,
	[HinhThuc] [nvarchar](max) NULL,
	[Gia] [int] NULL,
	[KhuyenMai] [int] NULL,
	[SiSo] [int] NULL,
	[LoaiKhoaHocId] [int] NULL,
 CONSTRAINT [PK_Lops] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 01-Nov-20 4:56:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [nvarchar](max) NULL,
	[MatKhau] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[SoDienThoai] [nvarchar](max) NULL,
	[QuyenAdmin] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[LoaiKhoaHocs] ON 

INSERT [dbo].[LoaiKhoaHocs] ([Id], [ChuDe]) VALUES (1, N'Web frontend')
INSERT [dbo].[LoaiKhoaHocs] ([Id], [ChuDe]) VALUES (2, N'Di động')
INSERT [dbo].[LoaiKhoaHocs] ([Id], [ChuDe]) VALUES (3, N'Web backend')
INSERT [dbo].[LoaiKhoaHocs] ([Id], [ChuDe]) VALUES (4, N'Big Data, AI')
INSERT [dbo].[LoaiKhoaHocs] ([Id], [ChuDe]) VALUES (5, N'Kiểm thử')
INSERT [dbo].[LoaiKhoaHocs] ([Id], [ChuDe]) VALUES (6, N'Web fullstack')
SET IDENTITY_INSERT [dbo].[LoaiKhoaHocs] OFF
SET IDENTITY_INSERT [dbo].[Lops] ON 

INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (1, N'Học Angular 8+ qua các ví dụ thực tế', N'https://techmaster.vn/media/static/8028/bqa38fk51cocm3n1ubqg', N'Trực tuyến', 500000, NULL, NULL, 1)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (2, N'Khoá học SQL nâng cao', N'https://techmaster.vn/media/static/6734/bo5caps51coco9d0vu80', N'Trực tuyến', 600000, NULL, NULL, 3)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (3, N'Web cơ bản HTML5, CSS3 và Javascript Online', N'https://techmaster.vn/media/fileman/Uploads/web-thumnail.png', N'Trực tuyến', 500000, NULL, NULL, 1)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (4, N'Khoá học Lập trình đa nền tảng với Flutter', N'https://techmaster.vn/media/static/6734/bscggh451cob9t3q7meg', N'Trực tuyến', 600000, NULL, NULL, 2)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (5, N'Thành thạo React Native qua 3 ứng dụng thực tế', N'https://techmaster.vn/media/fileman/Uploads/ReactNative/reactnativelogo.jpg', N'Trực tuyến', 500000, NULL, NULL, 2)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (6, N'Lập trình di động IOS Swift online', N'https://techmaster.vn/media/static/8028/bqa348s51cocm3n1ubq0', N'Trực tuyến', 500000, NULL, NULL, 2)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (7, N'Full Stack Node.js 2019 (step by step project base training)', N'https://techmaster.vn/media/fileman/Uploads/logo/FullStackNode.jpg', N'Trực tuyến', 500000, NULL, NULL, 3)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (8, N'Lập trình web với Spring Boot online', N'https://techmaster.vn/media/static/8028/bpfneoc51co8tcg6lek0', N'Trực tuyến', 500000, NULL, NULL, 3)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (9, N'Nhập môn Machine Learning', N'https://techmaster.vn/media/fileman/Uploads/MachineLearning/MachineLearning.jpg', N'Trực tuyến', 500000, NULL, NULL, 4)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (10, N'PYTHON cơ bản cho nghề PHÂN TÍCH DỮ LIỆU', N'https://techmaster.vn/media/static/8028/bqeg1qs51co5pe1n46j0', N'Trực tuyến', 500000, NULL, NULL, 4)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (14, N'Fullstack .NET Web Developer', N'data:image/png;base64,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', N'Phòng Lab', 5000000, NULL, NULL, 6)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (15, N'Fullstack Java Web Developer ', N'https://topdev.vn/blog/wp-content/uploads/2017/06/java-1.jpg', N'Phòng Lab', 5000000, NULL, NULL, 6)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (17, N'Web Frontend nâng cao với React', N'https://techmaster.vn/media/fileman/Uploads/HTML/React.jpg', N'Phòng Lab', 4500000, NULL, NULL, 1)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (18, N'Lập trình ReactJS dành cho doanh nghiệp', N'https://techmaster.vn/media/static/10194/bntg0gs51co0rgshmhb0', N'Phòng Lab', 2000000, NULL, NULL, 1)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (19, N'Lập trình Angular dành cho doanh nghiệp', N'https://techmaster.vn/media/static/53/bo04nhs51co0rgshmibg', N'Phòng Lab', 2000000, NULL, NULL, 1)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (20, N'Lập trình Games 2D HTML5 Canvas Javascript', N'https://techmaster.vn/media/static/36/bqojclc51co0sqthsfcg', N'Phòng Lab', 3500000, NULL, NULL, 1)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (21, N'Lập trình di động Flutter cho IOS - Android', N'https://techmaster.vn/media/static/36/bu7vm6s51co5836g4l6g', N'Phòng Lab', 3500000, NULL, NULL, 2)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (22, N'Lập trình iOS Swift căn bản cập nhật 2020', N'https://techmaster.vn/media/fileman/Uploads/users/5463/ios2.jpg', N'Phòng Lab', 3900000, NULL, NULL, 2)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (23, N'Lập trình di động đa nền tảng React Native cập nhật 2020', N'https://techmaster.vn/media/static/53/bplfi8s51cocb90sm8ag', N'Phòng Lab', 3500000, NULL, NULL, 2)
INSERT [dbo].[Lops] ([Id], [TenLop], [LinkAnh], [HinhThuc], [Gia], [KhuyenMai], [SiSo], [LoaiKhoaHocId]) VALUES (24, N'Lập trình Web - API - Microservice bằng Golang', N'https://techmaster.vn/media/static/36/bu803kc51co41h2qctug', N'Phòng Lab', 4500000, NULL, NULL, 3)
SET IDENTITY_INSERT [dbo].[Lops] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [TaiKhoan], [MatKhau], [Email], [SoDienThoai], [QuyenAdmin]) VALUES (1, N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'admin@gmail.com', N'0945907510', 1)
INSERT [dbo].[Users] ([Id], [TaiKhoan], [MatKhau], [Email], [SoDienThoai], [QuyenAdmin]) VALUES (2, N'quanghuymgr', N'76de0cc866c995e6b78e83870ec360b4', N'quanghuynguyenba@gmail.com', N'0945907510', NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[HocSinhs]  WITH CHECK ADD  CONSTRAINT [FK_HocSinhs_Lops_LopId] FOREIGN KEY([LopId])
REFERENCES [dbo].[Lops] ([Id])
GO
ALTER TABLE [dbo].[HocSinhs] CHECK CONSTRAINT [FK_HocSinhs_Lops_LopId]
GO
ALTER TABLE [dbo].[Lops]  WITH CHECK ADD  CONSTRAINT [FK_Lops_LoaiKhoaHocs_LoaiKhoaHocId] FOREIGN KEY([LoaiKhoaHocId])
REFERENCES [dbo].[LoaiKhoaHocs] ([Id])
GO
ALTER TABLE [dbo].[Lops] CHECK CONSTRAINT [FK_Lops_LoaiKhoaHocs_LoaiKhoaHocId]
GO
