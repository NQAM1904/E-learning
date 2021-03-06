--USE [master]
--GO
--/****** Object:  Database [DATHINH]    Script Date: 1/8/2021 8:01:44 PM ******/
--CREATE DATABASE [DATHINH]

create function [dbo].[func_CryptData] (@Data varchar(100))
returns varchar(256)
as
begin
return convert(varchar(256),HASHBYTES('SHA2_256',@Data),2)
end


GO
/****** Object:  Table [dbo].[BUOIHOC]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BUOIHOC](
	[IDBUOIHOC] [int] IDENTITY(1,1) NOT NULL,
	[DAY] [nvarchar](255) NULL,
 CONSTRAINT [PK_BUOIHOC] PRIMARY KEY CLUSTERED 
(
	[IDBUOIHOC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CAHOC]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CAHOC](
	[IDCAHOC] [int] IDENTITY(1,1) NOT NULL,
	[SOCA] [nvarchar](250) NULL,
 CONSTRAINT [PK_CAHOC] PRIMARY KEY CLUSTERED 
(
	[IDCAHOC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[COSO]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COSO](
	[IDCOSO] [int] IDENTITY(1,1) NOT NULL,
	[TENCS] [nvarchar](255) NULL,
	[PHONGHOC] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCOSO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DANHMUCSK]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DANHMUCSK](
	[IDDANHMUC] [int] IDENTITY(1,1) NOT NULL,
	[TENDANHMUC] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDDANHMUC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DIEM]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DIEM](
	[IDSTUDENT] [int] NOT NULL,
	[DIEMTB] [float] NULL,
	[STCDAT] [int] NULL,
	[IDDIEM] [int] IDENTITY(1,1) NOT NULL,
	[TONGDIEM] [float] NULL,
	[IDMONHOC] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDDIEM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EVENTS]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EVENTS](
	[IDEVENTS] [int] IDENTITY(1,1) NOT NULL,
	[TENEVENT] [nvarchar](255) NULL,
	[THOIGIANEV] [datetime] NULL,
	[IDUSER] [int] NOT NULL,
	[IDDANHMUC] [int] NOT NULL,
	[HINH] [nvarchar](250) NULL,
	[MOTA] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDEVENTS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HOCKY]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOCKY](
	[IDHOCKY] [int] IDENTITY(1,1) NOT NULL,
	[TENHOCKY] [nvarchar](255) NULL,
	[IDNAM] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDHOCKY] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LICHHOCTUAN]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LICHHOCTUAN](
	[IDLICHHOC] [int] IDENTITY(1,1) NOT NULL,
	[SOBUOIHOC] [int] NOT NULL,
	[IDBUOIHOC1] [int] NOT NULL,
	[IDCAHOC1] [int] NOT NULL,
	[IDBUOIHOC2] [int] NULL,
	[IDCAHOC2] [int] NULL,
	[IDBUOIHOC3] [int] NULL,
	[IDCAHOC3] [int] NULL,
 CONSTRAINT [PK_LICHHOCTUAN] PRIMARY KEY CLUSTERED 
(
	[IDLICHHOC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MONHOC]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MONHOC](
	[IDMONHOC] [int] IDENTITY(1,1) NOT NULL,
	[TENMONHOC] [nvarchar](255) NULL,
	[IDMONTIENQUYET] [int] NULL,
	[TINCHI] [int] NULL,
	[IDHOCKY] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDMONHOC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NAMHOC]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NAMHOC](
	[IDNAM] [int] IDENTITY(1,1) NOT NULL,
	[TENNAM] [datetime] NULL,
	[IDNGANH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNAM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NGANH]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGANH](
	[IDNGANH] [int] IDENTITY(1,1) NOT NULL,
	[NAMENGANH] [nvarchar](255) NULL,
	[IDNIENKHOA] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNGANH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NIENKHOA]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NIENKHOA](
	[IDNIENKHOA] [int] IDENTITY(1,1) NOT NULL,
	[NAMENIENKHOA] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNIENKHOA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PERMISSION]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERMISSION](
	[IDPERMISSION] [int] IDENTITY(1,1) NOT NULL,
	[NAMEPERMISSION] [nvarchar](55) NULL,
	[STATUS] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPERMISSION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ROLE]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ROLE](
	[IDROLE] [int] IDENTITY(1,1) NOT NULL,
	[NAMEROLE] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDROLE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[STUDENT]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STUDENT](
	[IDSTUDENT] [int] IDENTITY(1,1) NOT NULL,
	[IDUSER] [int] NOT NULL,
	[MSSV] [int] NULL,
	[IDNGANH] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDSTUDENT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TIETHOC]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TIETHOC](
	[IDTIETHOC] [int] IDENTITY(1,1) NOT NULL,
	[SOTIETHOC] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDTIETHOC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TKB]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TKB](
	[IDTKB] [int] IDENTITY(1,1) NOT NULL,
	[IDSTUDENT] [int] NOT NULL,
	[THOIGIANBATDAU] [datetime] NULL,
	[THOIGIANKETTHUC] [datetime] NULL,
	[IDMONHOC] [int] NOT NULL,
	[IDCOSO] [int] NOT NULL,
	[IDTIETHOC] [int] NOT NULL,
	[IDLICHHOC] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDTKB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[USER]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USER](
	[IDUSER] [int] IDENTITY(1,1) NOT NULL,
	[USERNAME] [nvarchar](255) NULL,
	[PASSWORD] [nvarchar](300) NULL,
	[FULLNAME] [nvarchar](255) NULL,
	[PHONE] [nvarchar](12) NULL,
	[ADDRESS] [nvarchar](255) NULL,
	[IDROLE] [int] NOT NULL,
	[IDPERMISSION] [int] NOT NULL,
	[EMAIL] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDUSER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[BUOIHOC] ON 

INSERT [dbo].[BUOIHOC] ([IDBUOIHOC], [DAY]) VALUES (1, N'Thứ 2')
INSERT [dbo].[BUOIHOC] ([IDBUOIHOC], [DAY]) VALUES (2, N'Thứ 3')
INSERT [dbo].[BUOIHOC] ([IDBUOIHOC], [DAY]) VALUES (3, N'Thứ 4')
INSERT [dbo].[BUOIHOC] ([IDBUOIHOC], [DAY]) VALUES (4, N'Thứ 5')
INSERT [dbo].[BUOIHOC] ([IDBUOIHOC], [DAY]) VALUES (5, N'Thứ 6')
INSERT [dbo].[BUOIHOC] ([IDBUOIHOC], [DAY]) VALUES (6, N'Thứ 7')
INSERT [dbo].[BUOIHOC] ([IDBUOIHOC], [DAY]) VALUES (7, N'Chủ Nhật')
SET IDENTITY_INSERT [dbo].[BUOIHOC] OFF
SET IDENTITY_INSERT [dbo].[CAHOC] ON 

INSERT [dbo].[CAHOC] ([IDCAHOC], [SOCA]) VALUES (1, N'Ca 1 (tiết 1,2,3): từ 06g45'' đến 09g00'' ')
INSERT [dbo].[CAHOC] ([IDCAHOC], [SOCA]) VALUES (2, N'Ca 2 (tiết 4,5,6): từ 09g20'' đến 11g35''')
INSERT [dbo].[CAHOC] ([IDCAHOC], [SOCA]) VALUES (3, N'Ca 3 (tiết 7,8,9): từ 12g30'' đến 14g45''')
INSERT [dbo].[CAHOC] ([IDCAHOC], [SOCA]) VALUES (4, N'Ca 4 (tiết 10,11,12): từ 15g05'' đến 17g20''')
INSERT [dbo].[CAHOC] ([IDCAHOC], [SOCA]) VALUES (5, N'Ca 5 (tiết 13,14,15): từ 18g00'' đến 20g15''')
SET IDENTITY_INSERT [dbo].[CAHOC] OFF
SET IDENTITY_INSERT [dbo].[COSO] ON 

INSERT [dbo].[COSO] ([IDCOSO], [TENCS], [PHONGHOC]) VALUES (1, N'E', N'P.01.02')
SET IDENTITY_INSERT [dbo].[COSO] OFF
SET IDENTITY_INSERT [dbo].[DANHMUCSK] ON 

INSERT [dbo].[DANHMUCSK] ([IDDANHMUC], [TENDANHMUC]) VALUES (1, N'Tuyển Sinh')
INSERT [dbo].[DANHMUCSK] ([IDDANHMUC], [TENDANHMUC]) VALUES (2, N'Phòng cộng tác sinh viên')
INSERT [dbo].[DANHMUCSK] ([IDDANHMUC], [TENDANHMUC]) VALUES (3, N'Hoạt động sinh viên')
INSERT [dbo].[DANHMUCSK] ([IDDANHMUC], [TENDANHMUC]) VALUES (4, N'Tin hướng nghiệp')
SET IDENTITY_INSERT [dbo].[DANHMUCSK] OFF
SET IDENTITY_INSERT [dbo].[DIEM] ON 

INSERT [dbo].[DIEM] ([IDSTUDENT], [DIEMTB], [STCDAT], [IDDIEM], [TONGDIEM], [IDMONHOC]) VALUES (1, 5, 3, 1, 5, 1)
SET IDENTITY_INSERT [dbo].[DIEM] OFF
SET IDENTITY_INSERT [dbo].[EVENTS] ON 

INSERT [dbo].[EVENTS] ([IDEVENTS], [TENEVENT], [THOIGIANEV], [IDUSER], [IDDANHMUC], [HINH], [MOTA]) VALUES (1, N'05 sinh viên HUTECH được trao học bổng COLONEL-NESS với tổng trị giá 50 triệu đồng', CAST(N'2021-01-08 01:22:42.687' AS DateTime), 1, 3, N'no-img.jpg', N'<p><em>Theo th&ocirc;ng tin từ hội đồng b&igrave;nh x&eacute;t Học bổng COLONEL-NESS của c&ocirc;ng ty KFC Việt Nam, trường Đại học C&ocirc;ng nghệ TP.HCM (HUTECH) c&oacute; 05 sinh vi&ecirc;n được chọn trao học bổng với tổng gi&aacute; trị đến 50 triệu đồng.</em><br />
&nbsp;</p>

<p><img alt="" src="https://file1.hutech.edu.vn/file/editor/homepage1/HUTE8591.jpg" style="height:0px" /><br />
<em>Đại diện KFC Việt Nam (&aacute;o đỏ, h&agrave;ng ghế thứ nhất từ tr&aacute;i qua) tham dự chương tr&igrave;nh Kỷ niệm 71 năm Ng&agrave;y Truyền thống Học sinh, Sinh vi&ecirc;n Việt Nam v&agrave; 20 năm ng&agrave;y th&agrave;nh lập Hội Sinh vi&ecirc;n HUTECH</em></p>

<p>&nbsp;<br />
Hội đồng b&igrave;nh x&eacute;t đ&atilde; tiến h&agrave;nh trao 05 suất học bổng với cơ cấu 01 giải Nhất (20 triệu đồng), 02 giải Nh&igrave; (10 triệu đồng/giải) v&agrave; 02 giải Ba (05 triệu đồng/giải) tại chương tr&igrave;nh Kỷ niệm 71 năm Ng&agrave;y Truyền thống Học sinh, Sinh vi&ecirc;n Việt Nam (09/01/1950 - 09/01/2021); 20 năm ng&agrave;y th&agrave;nh lập Hội Sinh vi&ecirc;n HUTECH (06/01/2001 - 06/01/2021).<br />
&nbsp;<br />
Đại diện KFC Việt Nam tham dự chương tr&igrave;nh c&oacute; b&agrave; Nguyễn Thị Đinh Hương - Gi&aacute;m đốc T&agrave;i ch&iacute;nh kế to&aacute;n, &ocirc;ng Đỗ Tất Chiến - Gi&aacute;m đốc Marketing, b&agrave; Long Kim Oanh - Gi&aacute;m đốc Nh&acirc;n sự v&agrave; &ocirc;ng Trần Quốc Th&aacute;i - Trưởng bộ phận vận h&agrave;nh.<br />
&nbsp;</p>

<p><em><img alt="" src="https://file1.hutech.edu.vn/file/editor/homepage1/HUTE8656.jpg" style="height:0px" /><br />
TS. Kiều Tu&acirc;n - B&iacute; thư Đảng ủy, Chủ tịch Hội đồng Trường v&agrave; b&agrave; Long Kim Oanh - Gi&aacute;m đốc Nh&acirc;n sự KFC Việt Nam c&ugrave;ng trao học bổng cho 05 sinh vi&ecirc;n HUTECH với tổng gi&aacute; trị 50 triệu đồng</em></p>

<p>&nbsp;<br />
Với chủ đề &ldquo;Kh&ocirc;ng bao giờ từ bỏ, biến giấc mơ th&agrave;nh hiện thực&rdquo; (Never give up, make dream come true), học bổng COLONEL-NESS l&agrave; cơ hội để gi&uacute;p c&aacute;c bạn sinh vi&ecirc;n vượt qua thử th&aacute;ch, tiếp th&ecirc;m tinh thần v&agrave; nghị lực để gặt h&aacute;i nhiều kết quả tốt đẹp.<br />
&nbsp;<br />
Sau gần 02 th&aacute;ng ph&aacute;t động, chương tr&igrave;nh đ&atilde; thu h&uacute;t sự quan t&acirc;m của đ&ocirc;ng đảo c&aacute;c bạn sinh vi&ecirc;n c&ugrave;ng viết ước mơ, ho&agrave;i b&atilde;o của m&igrave;nh. Trải qua nhiều v&ograve;ng b&igrave;nh chọn v&agrave; x&eacute;t duyệt, 05 b&agrave;i dự thi xuất sắc nhất đ&atilde; gi&agrave;nh được học bổng gồm:<br />
&nbsp;</p>

<table border="1" cellpadding="0" cellspacing="0" style="width:620px">
	<tbody>
		<tr>
			<td><strong>GIẢI THƯỞNG</strong></td>
			<td><strong>HỌC V&Agrave; T&Ecirc;N</strong></td>
			<td><strong>SUẤT</strong><br />
			<strong>HỌC BỔNG</strong></td>
			<td><strong>LỚP</strong></td>
			<td><strong>KHOA/VIỆN</strong></td>
		</tr>
		<tr>
			<td>Nhất</td>
			<td>Nguyễn Mỹ Tr&acirc;n</td>
			<td>20.000.000</td>
			<td>19DTQA2</td>
			<td>Viện Khoa học X&atilde; hội v&agrave; Nh&acirc;n văn</td>
		</tr>
		<tr>
			<td>Nh&igrave;</td>
			<td>Nguyễn L&ecirc; Duy</td>
			<td>10.000.000</td>
			<td>18DQTC6</td>
			<td>Khoa Quản trị kinh doanh</td>
		</tr>
		<tr>
			<td>Nh&igrave;</td>
			<td>Phạm Xu&acirc;n Kh&aacute;nh</td>
			<td>10.000.000</td>
			<td>20DNTA2</td>
			<td>Khoa Kiến tr&uacute;c - Mỹ thuật</td>
		</tr>
		<tr>
			<td>Ba</td>
			<td>Li&ecirc;u Từ Luận</td>
			<td>5.000.000</td>
			<td>17DKQA3</td>
			<td>Khoa Quản trị kinh doanh</td>
		</tr>
		<tr>
			<td>Ba</td>
			<td>L&ecirc; Thảo Quỳnh</td>
			<td>5.000.000</td>
			<td>17DKSQA2</td>
			<td>Viện Đ&agrave;o tạo Quốc tế</td>
		</tr>
	</tbody>
</table>

<p>&nbsp;<br />
Được biết, 05 sinh vi&ecirc;n xuất sắc được chọn trao học bổng l&agrave; t&aacute;c giả của những b&agrave;i viết thể hiện sự quyết t&acirc;m chinh phục mục ti&ecirc;u, thực hiện ước mơ của m&igrave;nh. Song song đ&oacute;, c&aacute;c bạn cũng đ&atilde; c&oacute; phần thuyết tr&igrave;nh trước hội đồng b&igrave;nh x&eacute;t đầy ấn tượng, thuyết phục về ho&agrave;i b&atilde;o của bản th&acirc;n như: trở th&agrave;nh một phi&ecirc;n dịch vi&ecirc;n, thực hiện dự &aacute;n khởi nghiệp, mở lớp học hỗ trợ c&aacute;c em nhỏ kh&ocirc;ng c&oacute; cơ hội đến trường, trở th&agrave;nh Sinh vi&ecirc;n 5 tốt - ti&ecirc;u chuẩn phấn đấu trở th&agrave;nh c&ocirc;ng d&acirc;n thời đại mới, gi&agrave;nh giải thưởng trong lĩnh vực nghi&ecirc;n cứu khoa học, du học,&hellip;<br />
&nbsp;<br />
Ch&uacute;c mừng c&aacute;c bạn sinh vi&ecirc;n đ&atilde; gi&agrave;nh được những suất học bổng gi&aacute; trị từ KFC Việt Nam. Tin rằng, đ&acirc;y l&agrave; nguồn năng lượng to lớn để c&aacute;c bạn hiện thực h&oacute;a những dự định, những ho&agrave;i b&atilde;o m&agrave; m&igrave;nh đ&atilde; viết ra.</p>
')
INSERT [dbo].[EVENTS] ([IDEVENTS], [TENEVENT], [THOIGIANEV], [IDUSER], [IDDANHMUC], [HINH], [MOTA]) VALUES (2, N'Sinh viên HUTECH nộp học phí Học kỳ 2 năm học 2020 - 2021 từ ngày 11/01/2021 - 21/01/2021', CAST(N'2021-01-08 01:26:58.590' AS DateTime), 1, 2, N'no-img.jpg', N'<p><em>Theo th&ocirc;ng b&aacute;o từ Ph&ograve;ng T&agrave;i ch&iacute;nh trường Đại học C&ocirc;ng nghệ TP.HCM (HUTECH), Sinh vi&ecirc;n thuộc c&aacute;c hệ đ&agrave;o tạo: Đại học, Cao đẳng ch&iacute;nh quy, Đại học li&ecirc;n th&ocirc;ng, Đại học văn bằng 2 nộp học ph&iacute; Học kỳ 2 năm học 2020 - 2021 từ ng&agrave;y&nbsp;<strong>11/01/2021 - 21/01/2021</strong>.</em><br />
&nbsp;</p>

<p><em><img alt="" src="https://file1.hutech.edu.vn/file/editor/homepage1/nop-hoc-phi-hk-2-541.jpg" style="height:0px" /></em></p>

<p>&nbsp;</p>

<ul>
	<li>Sinh vi&ecirc;n&nbsp;<strong>xem học ph&iacute;</strong>&nbsp;phải đ&oacute;ng&nbsp;<strong>tại t&agrave;i khoản c&aacute; nh&acirc;n</strong>.</li>
</ul>

<p>​<img alt="" src="https://file1.hutech.edu.vn/file/editor/homepage1/nop-hoc-phi-hk-2-620.jpg" style="height:0px" /></p>

<ul>
	<li>Tất cả sinh vi&ecirc;n&nbsp;<strong>nộp học ph&iacute; qua ng&acirc;n h&agrave;ng</strong>. Sinh vi&ecirc;n thực hiện nộp tiền mặt v&agrave;o t&agrave;i khoản ng&acirc;n h&agrave;ng hoặc chuyển khoản v&agrave;o 1 trong 6 t&agrave;i khoản của trường mở tại ng&acirc;n h&agrave;ng theo chi tiết sau:</li>
</ul>

<p><img alt="" src="https://file1.hutech.edu.vn/file/editor/homepage1/sv-ht-dk-hphk2620-v2.png" style="height:0px" /><br />
<em>Tất cả sinh vi&ecirc;n&nbsp;nộp học ph&iacute; qua ng&acirc;n h&agrave;ng</em></p>

<p>&nbsp;</p>

<table border="1" cellpadding="1" cellspacing="1" style="width:620px">
	<tbody>
		<tr>
			<td>
			<ul>
				<li>Sinh vi&ecirc;n&nbsp;<strong>kh&ocirc;ng nộp học ph&iacute; đ&uacute;ng hạn sẽ kh&ocirc;ng c&oacute; t&ecirc;n trong Danh s&aacute;ch lớp</strong></li>
			</ul>
			(gồm&nbsp;<em>Danh s&aacute;ch giảng vi&ecirc;n d&ugrave;ng để điểm danh v&agrave; theo d&otilde;i t&igrave;nh h&igrave;nh học tập của sinh vi&ecirc;n</em>,&nbsp;<em>Danh s&aacute;ch chấm điểm qu&aacute; tr&igrave;nh, Danh s&aacute;ch thi kết th&uacute;c học phần</em>).

			<ul>
				<li>Trường hợp kh&ocirc;ng th&ecirc;̉ n&ocirc;̣p học phí đúng hạn vì lý do đặc bi&ecirc;̣t khó khăn, sinh vi&ecirc;n c&acirc;̀n làm đơn xin gia hạn đóng học phí có chữ ký của phụ huynh, xác nh&acirc;̣n của chính quy&ecirc;̀n địa phương (hoặc xác nh&acirc;̣n của cơ quan đ&ocirc;́i với sinh vi&ecirc;n Li&ecirc;n th&ocirc;ng, Văn bằng 2). Hạn nộp đơn từ ng&agrave;y&nbsp;<strong>11/01/2021 - 20/01/2021</strong>&nbsp;tại Ph&ograve;ng T&agrave;i ch&iacute;nh (S&acirc;n lửng Sảnh A).</li>
			</ul>
			</td>
		</tr>
	</tbody>
</table>

<p>&nbsp;</p>

<table border="1" cellpadding="1" cellspacing="1" style="width:620px">
	<tbody>
		<tr>
			<td>
			<p><strong>Thời gian hủy đăng k&yacute; học phần v&agrave; r&uacute;t đăng k&yacute; học phần</strong></p>

			<ul>
				<li><strong>Hủy đăng k&yacute; học phần:&nbsp;</strong>09/01/2021 - 20/01/2021</li>
			</ul>

			<p>Sinh vi&ecirc;n được quyền hủy đăng k&yacute; học phần&nbsp;<strong>th&ocirc;ng qua việc gửi email</strong>&nbsp;theo hướng dẫn tại trang đăng k&yacute; học phần. Sinh vi&ecirc;n kh&ocirc;ng phải đ&oacute;ng học ph&iacute; c&aacute;c học phần đ&atilde; được chấp nhận hủy đăng k&yacute;.&nbsp;<strong>Việc hủy học phần cần thực hiện trước khi đ&oacute;ng học ph&iacute;</strong>.</p>

			<ul>
				<li>&nbsp;<strong>R&uacute;t đăng k&yacute; học phần:</strong>&nbsp;01/3/2021 - 22/3/2021</li>
			</ul>

			<p>Sinh vi&ecirc;n gửi email theo hướng dẫn tại trang đăng k&yacute; học phần. Việc r&uacute;t học phần kh&ocirc;ng ảnh hưởng đến kết quả học tập của sinh vi&ecirc;n. Học ph&iacute; c&aacute;c học phần đ&atilde; r&uacute;t&nbsp;<strong>kh&ocirc;ng được ho&agrave;n lại</strong>.</p>
			</td>
		</tr>
	</tbody>
</table>

<p>&nbsp;</p>

<p><strong>Ph&ograve;ng C&ocirc;ng t&aacute;c Sinh vi&ecirc;n</strong></p>
')
INSERT [dbo].[EVENTS] ([IDEVENTS], [TENEVENT], [THOIGIANEV], [IDUSER], [IDDANHMUC], [HINH], [MOTA]) VALUES (3, N'HUTECH công bố Đề án tuyển sinh Đại học dự kiến năm 2021', CAST(N'2021-01-08 01:29:24.033' AS DateTime), 1, 1, N'no-img.jpg', N'<p>Ng&agrave;y 09/12/2020, Trường Đại học C&ocirc;ng nghệ TP.HCM (HUTECH) c&ocirc;ng bố Đề &aacute;n tuyển sinh Đại học ch&iacute;nh quy dự kiến năm 2021. Theo đ&oacute;, HUTECH x&eacute;t tuyển 6.600 chỉ ti&ecirc;u tr&igrave;nh độ Đại học ch&iacute;nh quy cho 50 ng&agrave;nh đ&agrave;o tạo theo 04 phương thức x&eacute;t tuyển độc lập, gồm:<br />
<br />
<strong>1. X&eacute;t tuyển kết quả kỳ thi tốt nghiệp THPT 2021</strong><br />
<strong>2. X&eacute;t tuyển kết quả kỳ thi Đ&aacute;nh gi&aacute; năng lực (ĐGNL) 2021 của ĐH Quốc gia TP.HCM</strong><br />
<strong>3. X&eacute;t tuyển học bạ theo tổng điểm trung b&igrave;nh 03 m&ocirc;n năm lớp 12</strong><br />
<strong>4. X&eacute;t tuyển học bạ theo tổng điểm trung b&igrave;nh 03 học kỳ (lớp 11 v&agrave; học kỳ 1 lớp 12)</strong><br />
<br />
Tất cả th&iacute; sinh tốt nghiệp THPT tr&ecirc;n cả nước đều c&oacute; thể x&eacute;t tuyển v&agrave;o HUTECH theo 04 phương thức n&agrave;y.<br />
&nbsp;</p>

<p><img alt="" src="https://file1.hutech.edu.vn/file/editor/homepage1/3N7A8756%282%29.jpg" style="height:0px" /><br />
<em>HUTECH &aacute;p dụng 04 phương thức x&eacute;t tuyển độc lập trong năm 2021</em><br />
&nbsp;</p>

<p>Đối với phương thức x&eacute;t tuyển kết quả kỳ thi tốt nghiệp THPT 2021 (chiếm 65% tổng chỉ ti&ecirc;u x&eacute;t tuyển), HUTECH thực hiện theo quy định của Bộ GD&amp;ĐT về thời gian x&eacute;t tuyển, lệ ph&iacute; x&eacute;t tuyển, c&aacute;ch thức đăng k&yacute;. Th&iacute; sinh cần tham dự kỳ thi tốt nghiệp THPT 2021 v&agrave; c&oacute; điểm thi đạt từ ngưỡng điểm đảm bảo chất lượng đầu v&agrave;o do HUTECH quy định.<br />
<br />
Đối với phương thức x&eacute;t tuyển kết quả kỳ thi ĐGNL 2021 của ĐH Quốc gia TP.HCM (chiếm 5% tổng chỉ ti&ecirc;u x&eacute;t tuyển), th&iacute; sinh cần tham dự kỳ thi v&agrave; c&oacute; điểm thi đạt từ ngưỡng điểm đảm bảo chất lượng đầu v&agrave;o do HUTECH quy định. Thời gian x&eacute;t tuyển theo kỳ thi ĐGNL do ĐH Quốc gia TP.HCM tổ chức sẽ được th&ocirc;ng b&aacute;o tại website&nbsp;<a href="http://www.hutech.edu.vn/">www.hutech.edu.vn</a>. Th&iacute; sinh theo d&otilde;i th&ocirc;ng tin v&agrave; đăng k&yacute; x&eacute;t tuyển bằng Phiếu đăng k&yacute; x&eacute;t tuyển theo mẫu của HUTECH.<br />
&nbsp;</p>

<p><img alt="" src="https://file1.hutech.edu.vn/file/editor/homepage1/_N7A0323%281%29.jpg" style="height:0px" /></p>

<p><em>Năm 2021, HUTECH dự kiến tuyển sinh 6.600 chỉ ti&ecirc;u cho 50 ng&agrave;nh đ&agrave;o tạo</em></p>

<p><br />
Đối với c&aacute;c phương thức x&eacute;t tuyển học bạ (phương thức 3 v&agrave; 4, chiếm 30% tổng chỉ ti&ecirc;u x&eacute;t tuyển), th&iacute; sinh cần c&oacute; điểm x&eacute;t tuyển đạt từ ngưỡng điểm đảm bảo chất lượng đầu v&agrave;o do HUTECH quy định. Cụ thể, với phương thức x&eacute;t học bạ lớp 12 theo tổ hợp 03 m&ocirc;n, th&iacute; sinh cần c&oacute; tổng điểm trung b&igrave;nh năm lớp 12 của 03 m&ocirc;n trong tổ hợp x&eacute;t tuyển đạt từ 18 điểm trở l&ecirc;n; với phương thức x&eacute;t tuyển học bạ 03 học kỳ, th&iacute; sinh cần c&oacute; tổng điểm trung b&igrave;nh 03 học kỳ x&eacute;t tuyển (gồm 2 học kỳ lớp 11 v&agrave; học kỳ 1 lớp 12) đạt từ 18 điểm trở l&ecirc;n. Ri&ecirc;ng với nh&oacute;m ng&agrave;nh Khoa học sức khỏe, điều kiện x&eacute;t tuyển &aacute;p dụng theo quy định của Bộ GD&amp;ĐT.<br />
<br />
Th&iacute; sinh đăng k&yacute; x&eacute;t tuyển học bạ theo 03 h&igrave;nh thức: nộp hồ sơ trực tiếp tại HUTECH, gửi hồ sơ qua đường bưu điện hoặc đăng k&yacute; trực tuyến tại website trường. HUTECH nhận hồ sơ học bạ theo từng đợt, dự kiến thời gian từng đợt như sau:<br />
&nbsp;</p>

<table align="center" border="1" cellpadding="1" cellspacing="1" style="width:620px">
	<tbody>
		<tr>
			<td><strong>Đợt 1</strong></td>
			<td>01/3 - 31/5/2021</td>
			<td><strong>Đợt 5</strong></td>
			<td>21/7 - 31/7/2021</td>
		</tr>
		<tr>
			<td><strong>Đợt 2</strong></td>
			<td>01/6 - 30/6/2021</td>
			<td><strong>Đợt 6</strong></td>
			<td>01/8 - 10/8/2021</td>
		</tr>
		<tr>
			<td><strong>Đợt 3</strong></td>
			<td>01/7 - 10/7/2021</td>
			<td><strong>Đợt 7</strong></td>
			<td>11/8 - 20/8/2021</td>
		</tr>
		<tr>
			<td><strong>Đợt 4</strong></td>
			<td>11/7 - 20/7/2021</td>
			<td><strong>Đợt 8</strong></td>
			<td>21/8 - 31/8/2021</td>
		</tr>
	</tbody>
</table>

<p><br />
Những th&iacute; sinh đang l&agrave; học sinh lớp 12 chưa c&oacute; kết quả x&eacute;t tốt nghiệp THPT năm 2021 c&oacute; thể đăng k&yacute; x&eacute;t tuyển học bạ ngay trong đợt đầu ti&ecirc;n (từ ng&agrave;y 01/3/2021) bằng c&aacute;ch nộp trước Phiếu đăng k&yacute; x&eacute;t tuyển v&agrave; bản photo c&ocirc;ng chứng học bạ THPT về HUTECH để được ưu ti&ecirc;n x&eacute;t tuyển.<br />
<br />
Danh mục c&aacute;c ng&agrave;nh, chuy&ecirc;n ng&agrave;nh x&eacute;t tuyển v&agrave; c&aacute;c tổ hợp x&eacute;t tuyển tương ứng cho từng ng&agrave;nh đ&agrave;o tạo tại HUTECH năm 2021 cụ thể như sau:<br />
&nbsp;</p>

<table align="center" border="1" cellpadding="0" cellspacing="0" style="width:620px">
	<tbody>
		<tr>
			<td><strong>STT</strong></td>
			<td><strong>Ng&agrave;nh, chuy&ecirc;n ng&agrave;nh</strong></td>
			<td><strong>M&atilde; ng&agrave;nh</strong></td>
			<td><strong>Tổ hợp x&eacute;t tuyển</strong></td>
		</tr>
		<tr>
			<td>1</td>
			<td>Dược học:<br />
			<em>- Sản xuất &amp; ph&aacute;t triển thuốc</em><br />
			<em>- Dược l&acirc;m s&agrave;ng, Quản l&yacute; &amp; cung ứng thuốc</em></td>
			<td>7720201</td>
			<td rowspan="7">A00 (To&aacute;n, L&yacute;, H&oacute;a)<br />
			B00 (To&aacute;n, H&oacute;a, Sinh)<br />
			C08 (Văn, H&oacute;a, Sinh)<br />
			D07 (To&aacute;n, H&oacute;a, Anh)</td>
		</tr>
		<tr>
			<td>2</td>
			<td>Kỹ thuật x&eacute;t nghiệm y học&nbsp;<em>(dự kiến)</em></td>
			<td>7720601</td>
		</tr>
		<tr>
			<td>3</td>
			<td>Điều dưỡng&nbsp;<em>(dự kiến)</em></td>
			<td>7720301</td>
		</tr>
		<tr>
			<td>4</td>
			<td>C&ocirc;ng nghệ thực phẩm:<br />
			<em>- Quản l&yacute; sản xuất &amp; cung ứng thực phẩm</em><br />
			<em>- Nghệ thuật ẩm thực &amp; dịch vụ</em><br />
			<em>- Dinh dưỡng &amp; thực phẩm</em></td>
			<td>7540101</td>
		</tr>
		<tr>
			<td>5</td>
			<td>Kỹ thuật m&ocirc;i trường:<br />
			<em>- Quản l&yacute; m&ocirc;i trường &amp; t&agrave;i nguy&ecirc;n</em><br />
			<em>- C&ocirc;ng nghệ kiểm so&aacute;t m&ocirc;i trường bền vững</em><br />
			<em>- Thẩm định &amp; quản l&yacute; dự &aacute;n m&ocirc;i trường</em></td>
			<td>7520320</td>
		</tr>
		<tr>
			<td>6</td>
			<td>C&ocirc;ng nghệ sinh học:<br />
			<em>- C&ocirc;ng nghệ sinh học n&ocirc;ng nghiệp</em><br />
			<em>- C&ocirc;ng nghệ sinh học thực phẩm &amp; sức khỏe</em><br />
			<em>- C&ocirc;ng nghệ sinh học dược</em></td>
			<td>7420201</td>
		</tr>
		<tr>
			<td>7</td>
			<td>Th&uacute; y</td>
			<td>7640101</td>
		</tr>
		<tr>
			<td>8</td>
			<td>Kỹ thuật y sinh</td>
			<td>7520212</td>
			<td rowspan="18">A00 (To&aacute;n, L&yacute;, H&oacute;a)<br />
			A01 (To&aacute;n, L&yacute;, Anh)<br />
			C01 (To&aacute;n, Văn, L&yacute;)<br />
			D01 (To&aacute;n, Văn, Anh)</td>
		</tr>
		<tr>
			<td>9</td>
			<td>Kỹ thuật điện tử - viễn th&ocirc;ng</td>
			<td>7520207</td>
		</tr>
		<tr>
			<td>10</td>
			<td>Kỹ thuật điện</td>
			<td>7520201</td>
		</tr>
		<tr>
			<td>11</td>
			<td>Kỹ thuật cơ điện tử</td>
			<td>7520114</td>
		</tr>
		<tr>
			<td>12</td>
			<td>Kỹ thuật cơ kh&iacute;</td>
			<td>7520103</td>
		</tr>
		<tr>
			<td>13</td>
			<td>Kỹ thuật điều khiển v&agrave; tự động h&oacute;a</td>
			<td>7520216</td>
		</tr>
		<tr>
			<td>14</td>
			<td>C&ocirc;ng nghệ kỹ thuật &ocirc; t&ocirc;</td>
			<td>7510205</td>
		</tr>
		<tr>
			<td>15</td>
			<td>C&ocirc;ng nghệ th&ocirc;ng tin:<br />
			<em>- Mạng m&aacute;y t&iacute;nh &amp; truyền th&ocirc;ng</em><br />
			<em>- C&ocirc;ng nghệ phần mềm</em><br />
			<em>- Hệ thống th&ocirc;ng tin</em></td>
			<td>7480201</td>
		</tr>
		<tr>
			<td>16</td>
			<td>An to&agrave;n th&ocirc;ng tin</td>
			<td>7480202</td>
		</tr>
		<tr>
			<td>17</td>
			<td>Robot &amp; tr&iacute; tuệ nh&acirc;n tạo</td>
			<td>7480207</td>
		</tr>
		<tr>
			<td>18</td>
			<td>Khoa học dữ liệu&nbsp;<em>(Data Science)</em></td>
			<td>7480109</td>
		</tr>
		<tr>
			<td>19</td>
			<td>Hệ thống th&ocirc;ng tin quản l&yacute;:<br />
			<em>- Khoa học dữ liệu (Data science)</em><br />
			<em>- Ph&acirc;n t&iacute;ch dữ liệu lớn (Big data)</em><br />
			<em>- Ph&acirc;n t&iacute;ch dữ liệu số trong ng&agrave;nh Dược</em></td>
			<td>7340405</td>
		</tr>
		<tr>
			<td>20</td>
			<td>Kỹ thuật x&acirc;y dựng</td>
			<td>7580201</td>
		</tr>
		<tr>
			<td>21</td>
			<td>Quản l&yacute; x&acirc;y dựng</td>
			<td>7580302</td>
		</tr>
		<tr>
			<td>22</td>
			<td>C&ocirc;ng nghệ dệt, may:<br />
			<em>- C&ocirc;ng nghệ dệt, may</em><br />
			<em>- Quản l&yacute; đơn h&agrave;ng</em></td>
			<td>7540204</td>
		</tr>
		<tr>
			<td>23</td>
			<td>Logistics &amp; quản l&yacute; chuỗi cung ứng</td>
			<td>7510605</td>
		</tr>
		<tr>
			<td>24</td>
			<td>Kế to&aacute;n:<br />
			<em>- Kế to&aacute;n Kiểm to&aacute;n</em><br />
			<em>- Kế to&aacute;n ng&acirc;n h&agrave;ng</em><br />
			<em>- Kế to&aacute;n - T&agrave;i ch&iacute;nh</em><br />
			<em>- Kế to&aacute;n tổng hợp</em><br />
			<em>- Kế to&aacute;n c&ocirc;ng</em></td>
			<td>7340301</td>
		</tr>
		<tr>
			<td>25</td>
			<td>T&agrave;i ch&iacute;nh - Ng&acirc;n h&agrave;ng:<br />
			<em>- T&agrave;i ch&iacute;nh doanh nghiệp</em><br />
			<em>- T&agrave;i ch&iacute;nh ng&acirc;n h&agrave;ng</em><br />
			<em>- Đầu tư t&agrave;i ch&iacute;nh</em><br />
			<em>- Thẩm định gi&aacute;</em></td>
			<td>7340201</td>
		</tr>
		<tr>
			<td>26</td>
			<td>Kinh doanh thương mại:<br />
			<em>- Kinh doanh thương mại</em><br />
			<em>- Quản l&yacute; chuỗi cung ứng</em></td>
			<td>7340121</td>
			<td rowspan="14">A00 (To&aacute;n, L&yacute;, H&oacute;a)<br />
			A01 (To&aacute;n, L&yacute;, Anh)<br />
			&nbsp;C00 (Văn, Sử, Địa)<br />
			D01 (To&aacute;n, Văn, Anh)</td>
		</tr>
		<tr>
			<td>27</td>
			<td>Thương mại điện tử</td>
			<td>7340122</td>
		</tr>
		<tr>
			<td>28</td>
			<td>T&acirc;m l&yacute; học:<br />
			<em>- Tham vấn t&acirc;m l&yacute;</em><br />
			<em>- Trị liệu t&acirc;m l&yacute;</em><br />
			<em>- Tổ chức nh&acirc;n sự</em></td>
			<td>7310401</td>
		</tr>
		<tr>
			<td>29</td>
			<td>Marketing:<br />
			<em>- Marketing tổng hợp</em><br />
			<em>- Marketing truyền th&ocirc;ng</em><br />
			<em>- Quản trị Marketing</em></td>
			<td>7340115</td>
		</tr>
		<tr>
			<td>30</td>
			<td>Quản trị kinh doanh:<br />
			<em>- Quản trị doanh nghiệp</em><br />
			<em>- Quản trị ngoại thương</em><br />
			<em>- Quản trị nh&acirc;n sự</em><br />
			<em>- Quản trị logistics</em><br />
			<em>- Quản trị h&agrave;ng kh&ocirc;ng</em></td>
			<td>7340101</td>
		</tr>
		<tr>
			<td>31</td>
			<td>Kinh doanh quốc tế:<br />
			<em>- Thương mại quốc tế</em><br />
			<em>- T&agrave;i ch&iacute;nh quốc tế</em><br />
			<em>- Kinh doanh điện tử</em></td>
			<td>7340120</td>
		</tr>
		<tr>
			<td>32</td>
			<td>Quản trị nh&acirc;n lực</td>
			<td>7340404</td>
		</tr>
		<tr>
			<td>33</td>
			<td>Quan hệ c&ocirc;ng ch&uacute;ng</td>
			<td>7320108</td>
		</tr>
		<tr>
			<td>34</td>
			<td>Quan hệ quốc tế</td>
			<td>7310206</td>
		</tr>
		<tr>
			<td>35</td>
			<td>Quản trị dịch vụ du lịch v&agrave; lữ h&agrave;nh</td>
			<td>7810103</td>
		</tr>
		<tr>
			<td>36</td>
			<td>Quản trị kh&aacute;ch sạn</td>
			<td>7810201</td>
		</tr>
		<tr>
			<td>37</td>
			<td>Quản trị nh&agrave; h&agrave;ng v&agrave; dịch vụ ăn uống</td>
			<td>7810202</td>
		</tr>
		<tr>
			<td>38</td>
			<td>Luật kinh tế</td>
			<td>7380107</td>
		</tr>
		<tr>
			<td>39</td>
			<td>Luật</td>
			<td>7380101</td>
		</tr>
		<tr>
			<td>40</td>
			<td>Kiến tr&uacute;c:<br />
			<em>- Kiến tr&uacute;c c&ocirc;ng tr&igrave;nh</em><br />
			<em>- Kiến tr&uacute;c xanh</em></td>
			<td>7580101</td>
			<td rowspan="2">A00 (To&aacute;n, L&yacute;, H&oacute;a)<br />
			D01 (To&aacute;n, Văn, Anh)<br />
			V00 (To&aacute;n, L&yacute;, Vẽ)<br />
			H01 (To&aacute;n, Văn, Vẽ)</td>
		</tr>
		<tr>
			<td>41</td>
			<td>Thiết kế nội thất:<br />
			<em>- Thiết kế nội thất</em><br />
			<em>- Trang tr&iacute; mỹ thuật nội thất</em></td>
			<td>7580108</td>
		</tr>
		<tr>
			<td>42</td>
			<td>Thiết kế thời trang:<br />
			<em>- Thiết kế thời trang</em><br />
			<em>- Quản l&yacute; thương hiệu &amp; kinh doanh thời trang</em><br />
			<em>- Thiết kế x&acirc;y dựng phong c&aacute;ch</em></td>
			<td>7210404</td>
			<td rowspan="2">V00 (To&aacute;n, L&yacute;, Vẽ)<br />
			H01 (To&aacute;n, Văn, Vẽ)<br />
			H02 (To&aacute;n, Anh, Vẽ)<br />
			H06 (Văn, Anh, Vẽ)</td>
		</tr>
		<tr>
			<td>43</td>
			<td>Thiết kế đồ họa:<br />
			<em>- Thiết kế đồ họa truyền th&ocirc;ng</em><br />
			<em>- Thiết kế đồ họa kỹ thuật số</em></td>
			<td>7210403</td>
		</tr>
		<tr>
			<td>44</td>
			<td>Truyền th&ocirc;ng đa phương tiện:<br />
			<em>- Sản xuất truyền h&igrave;nh</em><br />
			<em>- Sản xuất phim &amp; quảng c&aacute;o</em><br />
			<em>- Tổ chức sự kiện</em></td>
			<td>7320104</td>
			<td rowspan="5">A01 (To&aacute;n, L&yacute;, Anh)<br />
			C00 (Văn, Sử, Địa)<br />
			D01 (To&aacute;n, Văn, Anh)<br />
			D15 (Văn, Địa, Anh)</td>
		</tr>
		<tr>
			<td>45</td>
			<td>Đ&ocirc;ng phương học:<br />
			<em>- H&agrave;n Quốc học</em><br />
			<em>- Nhật Bản học</em><br />
			<em>- Trung Quốc học</em></td>
			<td>7310608</td>
		</tr>
		<tr>
			<td>46</td>
			<td>Việt Nam học:<br />
			<em>- Du lịch - lữ h&agrave;nh</em><br />
			<em>- B&aacute;o ch&iacute; - truyền th&ocirc;ng</em></td>
			<td>7310630</td>
		</tr>
		<tr>
			<td>47</td>
			<td>Ng&ocirc;n ngữ H&agrave;n Quốc<br />
			<em>- Bi&ecirc;n - phi&ecirc;n dịch tiếng H&agrave;n</em><br />
			<em>- Gi&aacute;o dục tiếng H&agrave;n</em></td>
			<td>7220210</td>
		</tr>
		<tr>
			<td>48</td>
			<td>Ng&ocirc;n ngữ Trung Quốc</td>
			<td>7220204</td>
		</tr>
		<tr>
			<td>49</td>
			<td>Ng&ocirc;n ngữ Anh:<br />
			<em>- Tiếng Anh thương mại</em><br />
			<em>- Tiếng Anh bi&ecirc;n, phi&ecirc;n dịch</em><br />
			<em>- Tiếng Anh du lịch &amp; kh&aacute;ch sạn</em><br />
			<em>- Phương ph&aacute;p giảng dạy tiếng Anh</em></td>
			<td>7220201</td>
			<td rowspan="2">A01 (To&aacute;n, L&yacute;, Anh)<br />
			D01 (To&aacute;n, Văn, Anh)<br />
			D14 (Văn, Sử, Anh)<br />
			D15 (Văn, Địa, Anh)</td>
		</tr>
		<tr>
			<td>50</td>
			<td>
			<p>Ng&ocirc;n ngữ Nhật:</p>

			<p>&shy;<em>- Bi&ecirc;n, phi&ecirc;n dịch tiếng Nhật</em></p>

			<p><em>- Tiếng Nhật thương mại</em></p>
			</td>
			<td>7220209</td>
		</tr>
	</tbody>
</table>

<p>&nbsp;</p>

<p>Được biết, 50 ng&agrave;nh đ&agrave;o tạo được HUTECH tuyển sinh năm 2021 thuộc c&aacute;c nh&oacute;m ng&agrave;nh Khoa học sức khỏe, Kỹ thuật - C&ocirc;ng nghệ, Kinh tế - Quản trị, Khoa học x&atilde; hội &amp; Nh&acirc;n văn, Kiến tr&uacute;c - Mỹ thuật ứng dụng, Sinh học - M&ocirc;i trường - N&ocirc;ng l&acirc;m, Ngoại ngữ, Luật. Trong đ&oacute;, c&oacute; 05 ng&agrave;nh mới thuộc c&aacute;c nh&oacute;m ng&agrave;nh Kỹ thuật - C&ocirc;ng nghệ (Robot &amp; tr&iacute; tuệ nh&acirc;n tạo, Khoa học dữ liệu), Kinh tế - Quản trị (Quản trị nh&acirc;n sự) v&agrave; Khoa học x&atilde; hội (Quan hệ c&ocirc;ng ch&uacute;ng, Quan hệ quốc tế); c&ugrave;ng 02 ng&agrave;nh Kỹ thuật x&eacute;t nghiệm y học, Điều dưỡng thuộc nh&oacute;m ng&agrave;nh Khoa học sức khỏe cũng dự kiến được tuyển sinh trong năm nay. Đ&acirc;y l&agrave; c&aacute;c nh&oacute;m ng&agrave;nh m&agrave; HUTECH c&oacute; truyền thống đ&agrave;o tạo v&agrave; thế mạnh hợp t&aacute;c doanh nghiệp đ&atilde; được ghi nhận trong nhiều năm qua.</p>

<p>&nbsp;</p>

<p><em>Đối với c&aacute;c ng&agrave;nh&nbsp;c&oacute; tổ hợp x&eacute;t tuyển bao gồm m&ocirc;n Năng khiếu Vẽ, th&iacute; sinh c&oacute; thể đăng k&yacute; tham dự kỳ thi Vẽ do HUTECH tổ chức hoặc nộp kết quả thi Vẽ c&aacute;c trường kh&aacute;c để tham gia x&eacute;t tuyển</em></p>

<p>&nbsp;</p>

<p>Về tổ hợp x&eacute;t tuyển, HUTECH &aacute;p dụng 04 tổ hợp m&ocirc;n cho mỗi ng&agrave;nh x&eacute;t tuyển. Ri&ecirc;ng đối với c&aacute;c ng&agrave;nh c&oacute; tổ hợp x&eacute;t tuyển bao gồm m&ocirc;n Năng khiếu Vẽ (Kiến tr&uacute;c, Thiết kế nội thất, Thiết kế đồ họa, Thiết kế thời trang), th&iacute; sinh c&oacute; thể tham dự kỳ thi Vẽ do HUTECH tổ chức hoặc lấy kết quả thi Vẽ từ trường đại học kh&aacute;c để tham gia x&eacute;t tuyển. HUTECH dự kiến tổ chức 04 kỳ thi Vẽ v&agrave;o c&aacute;c ng&agrave;y 26/6, 10/7, 24/7 v&agrave; 07/8/2021.</p>
')
SET IDENTITY_INSERT [dbo].[EVENTS] OFF
SET IDENTITY_INSERT [dbo].[HOCKY] ON 

INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (1, N'Học kỳ 1', 1)
INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (2, N'Học kỳ 2', 1)
INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (3, N'Học Kỳ 3', 1)
INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (4, N'Học kỳ 1', 2)
INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (5, N'Học kỳ 2', 2)
INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (6, N'Học Kỳ 3', 2)
INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (7, N'Học kỳ 1', 3)
INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (8, N'Học kỳ 2', 3)
INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (9, N'Học Kỳ 3', 3)
INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (10, N'Học kỳ 1', 4)
INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (11, N'Học kỳ 2', 4)
INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (12, N'Học Kỳ 3', 4)
INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (13, N'Học kỳ 1', 5)
INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (14, N'Học kỳ 2', 5)
INSERT [dbo].[HOCKY] ([IDHOCKY], [TENHOCKY], [IDNAM]) VALUES (15, N'Học Kỳ 3', 5)
SET IDENTITY_INSERT [dbo].[HOCKY] OFF
SET IDENTITY_INSERT [dbo].[LICHHOCTUAN] ON 

INSERT [dbo].[LICHHOCTUAN] ([IDLICHHOC], [SOBUOIHOC], [IDBUOIHOC1], [IDCAHOC1], [IDBUOIHOC2], [IDCAHOC2], [IDBUOIHOC3], [IDCAHOC3]) VALUES (1, 2, 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[LICHHOCTUAN] ([IDLICHHOC], [SOBUOIHOC], [IDBUOIHOC1], [IDCAHOC1], [IDBUOIHOC2], [IDCAHOC2], [IDBUOIHOC3], [IDCAHOC3]) VALUES (5, 3, 1, 2, 3, 3, 5, 1)
INSERT [dbo].[LICHHOCTUAN] ([IDLICHHOC], [SOBUOIHOC], [IDBUOIHOC1], [IDCAHOC1], [IDBUOIHOC2], [IDCAHOC2], [IDBUOIHOC3], [IDCAHOC3]) VALUES (6, 3, 3, 3, 3, 3, 3, 3)
INSERT [dbo].[LICHHOCTUAN] ([IDLICHHOC], [SOBUOIHOC], [IDBUOIHOC1], [IDCAHOC1], [IDBUOIHOC2], [IDCAHOC2], [IDBUOIHOC3], [IDCAHOC3]) VALUES (7, 1, 3, 3, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[LICHHOCTUAN] OFF
SET IDENTITY_INSERT [dbo].[MONHOC] ON 

INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (1, N'Lập Trình C', 0, 3, 1)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (2, N'Đại số tuyến tính', 0, 3, 1)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (3, N'Đường lối cách mạng của Đảng CSVN', 0, 3, 1)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (4, N'Tiếng Anh 1', 0, 3, 1)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (5, N'Nhập môn công nghệ thông tin', 0, 3, 1)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (6, N'Giải tích 1', 0, 3, 2)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (7, N'Tiếng Anh 2', 4, 3, 2)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (8, N'Kỹ thuật lập trình', 1, 3, 2)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (9, N'Quản trị học', 0, 3, 2)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (10, N'Kiến trúc máy tính', 0, 3, 2)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (11, N'Tiếng Anh 3', 7, 3, 4)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (12, N'Tâm lý học', 0, 3, 4)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (13, N'Môi trường', 0, 3, 4)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (14, N'Cơ Sở Dữ Liệu', 0, 3, 4)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (15, N'Tư Tưởng Hồ Chí Minh', 0, 3, 4)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (16, N'Cấu Trúc Dữ Liệu Và Giải Thuật', 8, 3, 4)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (17, N'Hệ Điều Hành', 10, 3, 4)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (18, N'Tiếng Anh 4', 11, 3, 5)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (19, N'Hệ Quản Trị CSDL', 14, 3, 5)
INSERT [dbo].[MONHOC] ([IDMONHOC], [TENMONHOC], [IDMONTIENQUYET], [TINCHI], [IDHOCKY]) VALUES (20, N'Lập Trình Hướng Đối Tượng', 16, 3, 5)
SET IDENTITY_INSERT [dbo].[MONHOC] OFF
SET IDENTITY_INSERT [dbo].[NAMHOC] ON 

INSERT [dbo].[NAMHOC] ([IDNAM], [TENNAM], [IDNGANH]) VALUES (1, CAST(N'2016-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[NAMHOC] ([IDNAM], [TENNAM], [IDNGANH]) VALUES (2, CAST(N'2017-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[NAMHOC] ([IDNAM], [TENNAM], [IDNGANH]) VALUES (3, CAST(N'2018-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[NAMHOC] ([IDNAM], [TENNAM], [IDNGANH]) VALUES (4, CAST(N'2019-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[NAMHOC] ([IDNAM], [TENNAM], [IDNGANH]) VALUES (5, CAST(N'2020-01-01 00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[NAMHOC] OFF
SET IDENTITY_INSERT [dbo].[NGANH] ON 

INSERT [dbo].[NGANH] ([IDNGANH], [NAMENGANH], [IDNIENKHOA]) VALUES (1, N'Công Nghệ Thông Tin', 1)
INSERT [dbo].[NGANH] ([IDNGANH], [NAMENGANH], [IDNIENKHOA]) VALUES (2, N'Quản Trị Kinh Doanh', 1)
INSERT [dbo].[NGANH] ([IDNGANH], [NAMENGANH], [IDNIENKHOA]) VALUES (3, N'Ngôn Ngữ Anh', 1)
SET IDENTITY_INSERT [dbo].[NGANH] OFF
SET IDENTITY_INSERT [dbo].[NIENKHOA] ON 

INSERT [dbo].[NIENKHOA] ([IDNIENKHOA], [NAMENIENKHOA]) VALUES (1, N'2016-2020')
INSERT [dbo].[NIENKHOA] ([IDNIENKHOA], [NAMENIENKHOA]) VALUES (2, N'2017-2021')
INSERT [dbo].[NIENKHOA] ([IDNIENKHOA], [NAMENIENKHOA]) VALUES (3, N'2018-2022')
INSERT [dbo].[NIENKHOA] ([IDNIENKHOA], [NAMENIENKHOA]) VALUES (4, N'2019-2023')
INSERT [dbo].[NIENKHOA] ([IDNIENKHOA], [NAMENIENKHOA]) VALUES (5, N'2020-2024')
SET IDENTITY_INSERT [dbo].[NIENKHOA] OFF
SET IDENTITY_INSERT [dbo].[PERMISSION] ON 

INSERT [dbo].[PERMISSION] ([IDPERMISSION], [NAMEPERMISSION], [STATUS]) VALUES (1, N'Tất cả', 1)
INSERT [dbo].[PERMISSION] ([IDPERMISSION], [NAMEPERMISSION], [STATUS]) VALUES (2, N'Thêm ', 1)
INSERT [dbo].[PERMISSION] ([IDPERMISSION], [NAMEPERMISSION], [STATUS]) VALUES (3, N'Xóa', 1)
INSERT [dbo].[PERMISSION] ([IDPERMISSION], [NAMEPERMISSION], [STATUS]) VALUES (4, N'Sửa', 1)
SET IDENTITY_INSERT [dbo].[PERMISSION] OFF
SET IDENTITY_INSERT [dbo].[ROLE] ON 

INSERT [dbo].[ROLE] ([IDROLE], [NAMEROLE]) VALUES (1, N'Quản lý ')
INSERT [dbo].[ROLE] ([IDROLE], [NAMEROLE]) VALUES (2, N'Nhân viên')
INSERT [dbo].[ROLE] ([IDROLE], [NAMEROLE]) VALUES (3, N'Sinh viên')
SET IDENTITY_INSERT [dbo].[ROLE] OFF
SET IDENTITY_INSERT [dbo].[STUDENT] ON 

INSERT [dbo].[STUDENT] ([IDSTUDENT], [IDUSER], [MSSV], [IDNGANH]) VALUES (1, 2, 1611060973, 1)
SET IDENTITY_INSERT [dbo].[STUDENT] OFF
SET IDENTITY_INSERT [dbo].[TIETHOC] ON 

INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (1, 1)
INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (2, 2)
INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (3, 3)
INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (4, 4)
INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (5, 5)
INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (6, 6)
INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (7, 7)
INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (8, 8)
INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (9, 9)
INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (10, 10)
INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (11, 11)
INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (12, 12)
INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (13, 13)
INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (14, 14)
INSERT [dbo].[TIETHOC] ([IDTIETHOC], [SOTIETHOC]) VALUES (15, 15)
SET IDENTITY_INSERT [dbo].[TIETHOC] OFF
SET IDENTITY_INSERT [dbo].[TKB] ON 

INSERT [dbo].[TKB] ([IDTKB], [IDSTUDENT], [THOIGIANBATDAU], [THOIGIANKETTHUC], [IDMONHOC], [IDCOSO], [IDTIETHOC], [IDLICHHOC]) VALUES (5, 1, CAST(N'2020-12-12 00:00:00.000' AS DateTime), CAST(N'2020-12-31 00:00:00.000' AS DateTime), 2, 1, 3, 1)
INSERT [dbo].[TKB] ([IDTKB], [IDSTUDENT], [THOIGIANBATDAU], [THOIGIANKETTHUC], [IDMONHOC], [IDCOSO], [IDTIETHOC], [IDLICHHOC]) VALUES (6, 1, CAST(N'2020-12-01 00:00:00.000' AS DateTime), CAST(N'2020-12-20 00:00:00.000' AS DateTime), 3, 1, 3, 1)
INSERT [dbo].[TKB] ([IDTKB], [IDSTUDENT], [THOIGIANBATDAU], [THOIGIANKETTHUC], [IDMONHOC], [IDCOSO], [IDTIETHOC], [IDLICHHOC]) VALUES (1009, 1, CAST(N'2021-01-01 00:00:00.000' AS DateTime), CAST(N'2021-01-20 00:00:00.000' AS DateTime), 4, 1, 3, 5)
INSERT [dbo].[TKB] ([IDTKB], [IDSTUDENT], [THOIGIANBATDAU], [THOIGIANKETTHUC], [IDMONHOC], [IDCOSO], [IDTIETHOC], [IDLICHHOC]) VALUES (1010, 1, CAST(N'2021-01-01 00:00:00.000' AS DateTime), CAST(N'2021-01-31 00:00:00.000' AS DateTime), 7, 1, 2, 6)
INSERT [dbo].[TKB] ([IDTKB], [IDSTUDENT], [THOIGIANBATDAU], [THOIGIANKETTHUC], [IDMONHOC], [IDCOSO], [IDTIETHOC], [IDLICHHOC]) VALUES (1011, 1, CAST(N'2021-01-01 00:00:00.000' AS DateTime), CAST(N'2021-01-31 00:00:00.000' AS DateTime), 8, 1, 2, 7)
SET IDENTITY_INSERT [dbo].[TKB] OFF
SET IDENTITY_INSERT [dbo].[USER] ON 

INSERT [dbo].[USER] ([IDUSER], [USERNAME], [PASSWORD], [FULLNAME], [PHONE], [ADDRESS], [IDROLE], [IDPERMISSION], [EMAIL]) VALUES (1, N'thinh', N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', N'Vòng Phước Thịnh', N'0123456789', N'Tân Bình', 1, 1, N'thinh@gmail.com')
INSERT [dbo].[USER] ([IDUSER], [USERNAME], [PASSWORD], [FULLNAME], [PHONE], [ADDRESS], [IDROLE], [IDPERMISSION], [EMAIL]) VALUES (2, N'sinhvien', N'A665A45920422F9D417E4867EFDC4FB8A04A1F3FFF1FA07E998E86F7F7A27AE3', N'sinhvien', N'0339895154', N'hcm', 3, 4, N'sinhvien1998@gmail.com')
SET IDENTITY_INSERT [dbo].[USER] OFF
ALTER TABLE [dbo].[DIEM]  WITH CHECK ADD FOREIGN KEY([IDMONHOC])
REFERENCES [dbo].[MONHOC] ([IDMONHOC])
GO
ALTER TABLE [dbo].[DIEM]  WITH CHECK ADD FOREIGN KEY([IDSTUDENT])
REFERENCES [dbo].[STUDENT] ([IDSTUDENT])
GO
ALTER TABLE [dbo].[EVENTS]  WITH CHECK ADD FOREIGN KEY([IDDANHMUC])
REFERENCES [dbo].[DANHMUCSK] ([IDDANHMUC])
GO
ALTER TABLE [dbo].[EVENTS]  WITH CHECK ADD FOREIGN KEY([IDUSER])
REFERENCES [dbo].[USER] ([IDUSER])
GO
ALTER TABLE [dbo].[HOCKY]  WITH CHECK ADD FOREIGN KEY([IDNAM])
REFERENCES [dbo].[NAMHOC] ([IDNAM])
GO
ALTER TABLE [dbo].[MONHOC]  WITH CHECK ADD FOREIGN KEY([IDHOCKY])
REFERENCES [dbo].[HOCKY] ([IDHOCKY])
GO
ALTER TABLE [dbo].[NAMHOC]  WITH CHECK ADD FOREIGN KEY([IDNGANH])
REFERENCES [dbo].[NGANH] ([IDNGANH])
GO
ALTER TABLE [dbo].[NGANH]  WITH CHECK ADD FOREIGN KEY([IDNIENKHOA])
REFERENCES [dbo].[NIENKHOA] ([IDNIENKHOA])
GO
ALTER TABLE [dbo].[STUDENT]  WITH CHECK ADD FOREIGN KEY([IDNGANH])
REFERENCES [dbo].[NGANH] ([IDNGANH])
GO
ALTER TABLE [dbo].[STUDENT]  WITH CHECK ADD FOREIGN KEY([IDUSER])
REFERENCES [dbo].[USER] ([IDUSER])
GO
ALTER TABLE [dbo].[TKB]  WITH CHECK ADD FOREIGN KEY([IDCOSO])
REFERENCES [dbo].[COSO] ([IDCOSO])
GO
ALTER TABLE [dbo].[TKB]  WITH CHECK ADD FOREIGN KEY([IDMONHOC])
REFERENCES [dbo].[MONHOC] ([IDMONHOC])
GO
ALTER TABLE [dbo].[TKB]  WITH CHECK ADD FOREIGN KEY([IDSTUDENT])
REFERENCES [dbo].[STUDENT] ([IDSTUDENT])
GO
ALTER TABLE [dbo].[TKB]  WITH CHECK ADD FOREIGN KEY([IDTIETHOC])
REFERENCES [dbo].[TIETHOC] ([IDTIETHOC])
GO
ALTER TABLE [dbo].[TKB]  WITH CHECK ADD  CONSTRAINT [FK_TKB_LICHHOCTUAN] FOREIGN KEY([IDLICHHOC])
REFERENCES [dbo].[LICHHOCTUAN] ([IDLICHHOC])
GO
ALTER TABLE [dbo].[TKB] CHECK CONSTRAINT [FK_TKB_LICHHOCTUAN]
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([IDPERMISSION])
REFERENCES [dbo].[PERMISSION] ([IDPERMISSION])
GO
ALTER TABLE [dbo].[USER]  WITH CHECK ADD FOREIGN KEY([IDROLE])
REFERENCES [dbo].[ROLE] ([IDROLE])
GO
/****** Object:  StoredProcedure [dbo].[proc_CryptData]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[proc_CryptData] (@Data varchar(255))
as
begin
declare @Result varchar(256)
set @Result = dbo.func_CryptData(@Data)
select top 1 @Result
end



GO
/****** Object:  Trigger [dbo].[trg_AutoCryptPassword]    Script Date: 1/8/2021 8:01:44 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[trg_AutoCryptPassword] on [dbo].[USER]
for insert, update
as
begin
	if UPDATE([password])
	begin
		declare @id int
		declare @Password varchar(256)
		select @Password = [PASSWORD], @id = IDUSER from inserted
		set @Password = dbo.func_CryptData(@Password)
		update [USER] set [PASSWORD] = @Password where IDUSER = @id
	end
end



GO
USE [master]
GO
ALTER DATABASE [DATHINH] SET  READ_WRITE 
GO
