USE [TimeKeeping]
GO
/****** Object:  Table [dbo].[CaLamViec]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaLamViec](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenCaLamViec] [nvarchar](50) NULL,
	[TGBatDau] [time](7) NULL,
	[TGKetThuc] [time](7) NULL,
 CONSTRAINT [PK_CaLamViec] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChamCong]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamCong](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IDNhanVien] [bigint] NULL,
	[DauThoiGian] [datetime] NULL,
	[IDCaLamViec] [int] NULL,
	[XinNghiPhep] [bit] NULL,
	[IDTinhTrang] [int] NULL,
	[MoTa] [nvarchar](50) NULL,
	[Ngay] [datetime] NULL,
	[PheDuyet] [bit] NULL,
	[NguoiDuyet] [bigint] NULL,
 CONSTRAINT [PK_ChamCong] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenChucVu] [nvarchar](50) NULL,
 CONSTRAINT [PK_ChucVu] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Luong]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Luong](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HeSoLuong] [decimal](18, 2) NOT NULL,
	[LuongCoBan] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Luong] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NhanVien](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Ho] [nvarchar](50) NULL,
	[Ten] [nvarchar](50) NULL,
	[GioiTinh] [bit] NULL,
	[NgayVaoLam] [datetime] NULL,
	[NgaySinh] [datetime] NULL,
	[CMND] [varchar](20) NULL,
	[Email] [varchar](50) NULL,
	[DienThoai] [varchar](50) NULL,
	[AnhDaiDien] [varchar](500) NULL,
	[IDChucVu] [int] NULL,
	[IDPhongBan] [int] NULL,
	[IDHeSoLuong] [int] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenPhongBan] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhongBan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhuCap]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhuCap](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IDNhanVien] [bigint] NULL,
	[MoTaPhuCap] [nvarchar](200) NULL,
	[SoTien] [decimal](18, 2) NULL,
	[TuNgay] [datetime] NULL,
	[DenNgay] [datetime] NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_PhuCap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [nvarchar](50) NULL,
	[MoTa] [nvarchar](500) NULL,
 CONSTRAINT [PK_Quyen] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IDNhanVien] [bigint] NULL,
	[TenDangNhap] [varchar](50) NOT NULL,
	[MatKhau] [varchar](32) NULL,
	[IDQuyen] [int] NULL,
	[NgayTao] [datetime] NULL,
	[TinhTrang] [bit] NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThuongPhat]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuongPhat](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IDNhanVien] [bigint] NULL,
	[MoTa] [nvarchar](500) NULL,
	[SoTien] [decimal](18, 2) NULL,
	[DauThoiGian] [datetime] NULL,
 CONSTRAINT [PK_ThuongPhat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TinhTrang]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TinhTrang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KiHieu] [varchar](10) NULL,
	[MoTa] [nvarchar](500) NULL,
 CONSTRAINT [PK_TinhTrang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TraLuong]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TraLuong](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[IDNhanVien] [bigint] NULL,
	[DauThoiGian] [datetime] NULL,
	[LuongCuaThang] [int] NULL,
	[TongSoCong] [int] NULL,
	[ThuongPhat] [decimal](18, 2) NULL,
	[PhuCap] [decimal](18, 2) NULL,
	[ThanhTien] [decimal](18, 2) NULL,
	[DaTra] [decimal](18, 2) NULL,
	[ConNo] [decimal](18, 2) NULL,
	[NguoiTra] [bigint] NULL,
 CONSTRAINT [PK_TraLuong] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ViewChamCong]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[ViewChamCong] As
Select ChamCong.*,CaLamViec.TenCaLamViec,TinhTrang.KiHieu,
(select NhanVien.Ho Where NhanVien.ID = IDNhanVien) as 'HoNV',
(select NhanVien.Ten Where NhanVien.ID = IDNhanVien) as 'TenNV',
(select NhanVien.Ho Where NhanVien.ID = NguoiDuyet) as 'HoND',
(select NhanVien.Ten Where NhanVien.ID = NguoiDuyet) as 'TenND'
From ChamCong, NhanVien, CaLamViec,TinhTrang
GO
/****** Object:  View [dbo].[ViewNhanVien]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[ViewNhanVien] As
Select NhanVien.*, ChucVu.TenChucVu, PhongBan.TenPhongBan, Luong.HeSoLuong
From NhanVien, ChucVu,PhongBan,Luong
Where NhanVien.IDChucVu = ChucVu.ID
And NhanVien.IDHeSoLuong = Luong.ID
And NhanVien.IDPhongBan = PhongBan.ID
GO
/****** Object:  View [dbo].[ViewPhuCap]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[ViewPhuCap] As
Select PhuCap.*, NhanVien.Ho,NhanVien.Ten
From PhuCap, NhanVien
Where PhuCap.IDNhanVien = NhanVien.ID
GO
/****** Object:  View [dbo].[ViewTaiKhoan]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[ViewTaiKhoan] As
Select TaiKhoan.*,NhanVien.Ho, NhanVien.Ten, Quyen.TenQuyen
From TaiKhoan, NhanVien, Quyen
Where TaiKhoan.IDNhanVien = NhanVien.ID
And Quyen.ID = TaiKhoan.IDQuyen
GO
/****** Object:  View [dbo].[ViewThuongPhat]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[ViewThuongPhat] As
Select ThuongPhat.*, NhanVien.Ho,NhanVien.Ten
From ThuongPhat, NhanVien
Where ThuongPhat.IDNhanVien = NhanVien.ID
GO
/****** Object:  View [dbo].[ViewTraLuong]    Script Date: 5/18/2017 12:39:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[ViewTraLuong] As
Select TraLuong.*,
(select NhanVien.Ho Where NhanVien.ID = IDNhanVien) as 'HoNV',
(select NhanVien.Ten Where NhanVien.ID = IDNhanVien) as 'TenNV',
(select NhanVien.Ho Where NhanVien.ID = NguoiTra) as 'HoNT',
(select NhanVien.Ten Where NhanVien.ID = NguoiTra) as 'TenNT'
From TraLuong, NhanVien
GO
SET IDENTITY_INSERT [dbo].[CaLamViec] ON 

INSERT [dbo].[CaLamViec] ([ID], [TenCaLamViec], [TGBatDau], [TGKetThuc]) VALUES (1, N'Sáng', CAST(0x070040230E430000 AS Time), CAST(0x0700E03495640000 AS Time))
INSERT [dbo].[CaLamViec] ([ID], [TenCaLamViec], [TGBatDau], [TGKetThuc]) VALUES (2, N'Chiều', CAST(0x07007CDB27710000 AS Time), CAST(0x07001CEDAE920000 AS Time))
INSERT [dbo].[CaLamViec] ([ID], [TenCaLamViec], [TGBatDau], [TGKetThuc]) VALUES (3, N'Tối', CAST(0x070084B1109B0000 AS Time), CAST(0x07008C87F9C40000 AS Time))
SET IDENTITY_INSERT [dbo].[CaLamViec] OFF
SET IDENTITY_INSERT [dbo].[ChucVu] ON 

INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (1, N'Giám đốc')
INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (2, N'Phó Giám đốc')
INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (3, N'Trưởng phòng')
INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (4, N'Phó phòng')
INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (5, N'Kế toán trưởng')
INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (6, N'Trợ lí giám đốc')
INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (7, N'Trưởng bộ phận')
INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (8, N'Thư ký')
INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (9, N'Trưởng nhóm')
INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (10, N'Quản lý')
INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (11, N'Nhân viên')
INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (12, N'Thực tập viên')
INSERT [dbo].[ChucVu] ([ID], [TenChucVu]) VALUES (13, N'Kỹ sư')
SET IDENTITY_INSERT [dbo].[ChucVu] OFF
SET IDENTITY_INSERT [dbo].[Luong] ON 

INSERT [dbo].[Luong] ([ID], [HeSoLuong], [LuongCoBan]) VALUES (1, CAST(1.00 AS Decimal(18, 2)), CAST(1000000.00 AS Decimal(18, 2)))
INSERT [dbo].[Luong] ([ID], [HeSoLuong], [LuongCoBan]) VALUES (2, CAST(2.00 AS Decimal(18, 2)), CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[Luong] ([ID], [HeSoLuong], [LuongCoBan]) VALUES (4, CAST(3.00 AS Decimal(18, 2)), CAST(3000000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Luong] OFF
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([ID], [Ho], [Ten], [GioiTinh], [NgayVaoLam], [NgaySinh], [CMND], [Email], [DienThoai], [AnhDaiDien], [IDChucVu], [IDPhongBan], [IDHeSoLuong]) VALUES (1, N'Nguyễn Văn', N'Hiếu', 1, CAST(0x0000A6D600000000 AS DateTime), CAST(0x00008A2500000000 AS DateTime), N'0174340003', N'hieult_d8cnpm@epu.edu.vn', N'01649346164', N'/Data/images/2017-04-29_222142.png', 1, 1, 2)
INSERT [dbo].[NhanVien] ([ID], [Ho], [Ten], [GioiTinh], [NgayVaoLam], [NgaySinh], [CMND], [Email], [DienThoai], [AnhDaiDien], [IDChucVu], [IDPhongBan], [IDHeSoLuong]) VALUES (9, N'Nguyễn Đức', N'Huy', 0, CAST(0x0000A76F00000000 AS DateTime), CAST(0x0000A77000000000 AS DateTime), N'8888888', N'hieult_d8cnpm@epu.edu.vn', N'01649346164', N'/Data/images/2017-04-29_222142.png', 13, 6, 1)
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
SET IDENTITY_INSERT [dbo].[PhongBan] ON 

INSERT [dbo].[PhongBan] ([ID], [TenPhongBan]) VALUES (1, N'Giám đốc')
INSERT [dbo].[PhongBan] ([ID], [TenPhongBan]) VALUES (2, N'Tổng hợp')
INSERT [dbo].[PhongBan] ([ID], [TenPhongBan]) VALUES (3, N'Hành chính')
INSERT [dbo].[PhongBan] ([ID], [TenPhongBan]) VALUES (4, N'Nhân sự')
INSERT [dbo].[PhongBan] ([ID], [TenPhongBan]) VALUES (5, N'Hệ thống')
INSERT [dbo].[PhongBan] ([ID], [TenPhongBan]) VALUES (6, N'Ý tưởng')
INSERT [dbo].[PhongBan] ([ID], [TenPhongBan]) VALUES (7, N'Quảng cáo')
INSERT [dbo].[PhongBan] ([ID], [TenPhongBan]) VALUES (8, N'Data Moinitor')
INSERT [dbo].[PhongBan] ([ID], [TenPhongBan]) VALUES (9, N'R&D')
INSERT [dbo].[PhongBan] ([ID], [TenPhongBan]) VALUES (10, N'Phát triển sản phẩm')
SET IDENTITY_INSERT [dbo].[PhongBan] OFF
SET IDENTITY_INSERT [dbo].[Quyen] ON 

INSERT [dbo].[Quyen] ([ID], [TenQuyen], [MoTa]) VALUES (1, N'Super Administrator ', N'Super Administrator ')
INSERT [dbo].[Quyen] ([ID], [TenQuyen], [MoTa]) VALUES (2, N'Administrator', N'Administrator')
INSERT [dbo].[Quyen] ([ID], [TenQuyen], [MoTa]) VALUES (3, N'Manager', N'Manager')
INSERT [dbo].[Quyen] ([ID], [TenQuyen], [MoTa]) VALUES (4, N'User', N'User')
SET IDENTITY_INSERT [dbo].[Quyen] OFF
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([ID], [IDNhanVien], [TenDangNhap], [MatKhau], [IDQuyen], [NgayTao], [TinhTrang]) VALUES (1, 1, N'admin', N'21232f297a57a5a743894a0e4a801fc3', 1, CAST(0x0000A75F01062883 AS DateTime), 1)
INSERT [dbo].[TaiKhoan] ([ID], [IDNhanVien], [TenDangNhap], [MatKhau], [IDQuyen], [NgayTao], [TinhTrang]) VALUES (15, 1, N'admin1', N'admin', 1, CAST(0x0000A7670107E749 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
SET IDENTITY_INSERT [dbo].[TinhTrang] ON 

INSERT [dbo].[TinhTrang] ([ID], [KiHieu], [MoTa]) VALUES (1, N'X', N'Đi làm đúng giờ')
INSERT [dbo].[TinhTrang] ([ID], [KiHieu], [MoTa]) VALUES (2, N'P', N'Có phép')
INSERT [dbo].[TinhTrang] ([ID], [KiHieu], [MoTa]) VALUES (3, N'K', N'Không phép')
INSERT [dbo].[TinhTrang] ([ID], [KiHieu], [MoTa]) VALUES (4, N'L', N'Đi làm muộn')
SET IDENTITY_INSERT [dbo].[TinhTrang] OFF
SET IDENTITY_INSERT [dbo].[TraLuong] ON 

INSERT [dbo].[TraLuong] ([ID], [IDNhanVien], [DauThoiGian], [LuongCuaThang], [TongSoCong], [ThuongPhat], [PhuCap], [ThanhTien], [DaTra], [ConNo], [NguoiTra]) VALUES (1, 1, NULL, 1, 20, NULL, NULL, CAST(500000.00 AS Decimal(18, 2)), CAST(500000.00 AS Decimal(18, 2)), NULL, 1)
SET IDENTITY_INSERT [dbo].[TraLuong] OFF
/****** Object:  Index [IX_Luong]    Script Date: 5/18/2017 12:39:00 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Luong] ON [dbo].[Luong]
(
	[HeSoLuong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Account]    Script Date: 5/18/2017 12:39:00 AM ******/
ALTER TABLE [dbo].[TaiKhoan] ADD  CONSTRAINT [IX_Account] UNIQUE NONCLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_TinhTrang]    Script Date: 5/18/2017 12:39:00 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TinhTrang] ON [dbo].[TinhTrang]
(
	[KiHieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChamCong] ADD  CONSTRAINT [DF_ChamCong_DauThoiGian]  DEFAULT (getdate()) FOR [DauThoiGian]
GO
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [DF_NhanVien_NgayVaoLam]  DEFAULT (getdate()) FOR [NgayVaoLam]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  CONSTRAINT [DF_TaiKhoan_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  CONSTRAINT [DF_Account_TinhTrang]  DEFAULT ((1)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[ThuongPhat] ADD  CONSTRAINT [DF_ThuongPhat_DauThoiGian]  DEFAULT (getdate()) FOR [DauThoiGian]
GO
