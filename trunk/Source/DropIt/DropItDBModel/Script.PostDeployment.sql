/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

 --- Category
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT INTO [dbo].[Category] ([CategoryId], [CategoryName], [ParentCategoryId], [Status], [Description]) VALUES (1, N'Giải Trí', NULL, 1, N'Test')
INSERT INTO [dbo].[Category] ([CategoryId], [CategoryName], [ParentCategoryId], [Status], [Description]) VALUES (2, N'Ca nhạc', NULL, 1, N'Test')
INSERT INTO [dbo].[Category] ([CategoryId], [CategoryName], [ParentCategoryId], [Status], [Description]) VALUES (3, N'Ca nhạc trong nước', NULL, 1, N'Test')
INSERT INTO [dbo].[Category] ([CategoryId], [CategoryName], [ParentCategoryId], [Status], [Description]) VALUES (4, N'Ca nhạc nước ngoài', NULL, 1, N'Test')
INSERT INTO [dbo].[Category] ([CategoryId], [CategoryName], [ParentCategoryId], [Status], [Description]) VALUES (5, N'Thể Thao', NULL, 1, N'Test')
SET IDENTITY_INSERT [dbo].[Category] OFF


--------------Province-----------------------

SET IDENTITY_INSERT [dbo].[Province] ON
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (1, N'An Giang')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (2, N'Bà Rịa - Vũng Tàu')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (3, N'Bắc Giang')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (4, N'Bắc Kạn')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (5, N'Bạc Liêu')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (6, N'Bắc Ninh')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (7, N'Bến Tre')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (8, N'Bình Định')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (9, N'Bình Dương')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (10, N'Bình Phước')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (11, N'Bình Thuận')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (12, N'Cà Mau')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (13, N'Cao Bằng')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (14, N'Đắk Lắk')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (15, N'Đắk Nông')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (16, N'Điện Biên')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (17, N'Đồng Nai')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (18, N'Đồng Tháp')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (19, N'Gia Lai')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (20, N'Hà Giang')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (21, N'Hà Nam')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (22, N'Hà Tĩnh')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (23, N'Hải Dương')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (24, N'Hậu Giang')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (25, N'Hòa Bình')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (26, N'Hưng Yên')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (27, N'Khánh Hòa')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (28, N'Kiên Giang')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (29, N'Kon Tum')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (30, N'Lai Châu')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (31, N'Lâm Đồng')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (32, N'Lạng Sơn')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (33, N'Lào Cai')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (34, N'Long An')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (35, N'Nam Định')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (36, N'Nghệ An')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (37, N'Ninh Bình')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (38, N'Ninh Thuận')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (39, N'Phú Thọ')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (40, N'Quảng Bình')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (41, N'Quảng Nam')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (42, N'Quảng Ngãi')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (43, N'Quảng Ninh')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (44, N'Quảng Trị')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (45, N'Sóc Trăng')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (46, N'Sơn La')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (47, N'Tây Ninh')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (48, N'Thái Bình')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (49, N'Thái Nguyên')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (50, N'Thanh Hóa')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (51, N'Thừa Thiên Huế')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (52, N'Tiền Giang')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (53, N'Trà Vinh')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (54, N'Tuyên Quang')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (55, N'Vĩnh Long')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (56, N'Vĩnh Phúc')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (57, N'Yên Bái')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (58, N'Phú Yên')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (59, N'Cần Thơ')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (60, N'Đà Nẵng')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (61, N'Hải Phòng')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (62, N'Hà Nội')
INSERT INTO [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (63, N'TP HCM')
SET IDENTITY_INSERT [dbo].[Province] OFF


-------------Venue--------------
SET IDENTITY_INSERT [dbo].[Venue] ON
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (1, N'Bằng Lăng Tím', N'123', 1, 2, N'Có bãi gửi xe')
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (2, N'Bò cạp vàng', N'123', 2, 2, N'Có bãi gửi xe')
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (3, N'Quân Khu 7', N'123', 3, 2, N'Có bãi gửi xe')
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (4, N'SVĐ Mỹ Đình', N'123', 4, 2, N'Có bãi gửi xe')
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (5, N'Phòng Trà Tiếng Xưa', N'442 Cao Thắng, Phường 12, Quận 10', 63, 1, N'<p>S&agrave;i G&ograve;n vẫn d&agrave;nh một kh&ocirc;ng gian vốn rất ồn ả cho những nốt nhạc v&agrave;ng, N&oacute;i nhạc &ldquo;v&agrave;ng&rdquo; dễ khiến ta li&ecirc;n tưởng đến c&aacute;i t&ecirc;n một thời &aacute;p đặt oan uổng cho loại nhạc trữ t&igrave;nh n&agrave;y, nhưng b&acirc;y giờ thưởng thức lại, quả đ&acirc;y l&agrave; &acirc;m nhạc như v&agrave;ng r&ograve;ng thật v&igrave; sau tr&ecirc;n dưới nửa thế kỷ những nốt nhạc ấy cứ l&agrave;m ng&acirc;y ngất l&ograve;ng.người! &lsquo;<br />
G&oacute;c phố S&agrave;i G&ograve;n n&agrave;y như vẫn cứ ung dung tự tại một nơi chốn b&iacute;nh y&ecirc;n , mặc cho những rock, những hip-hop&hellip; tr&ocirc;i qua ngo&agrave;i cửa! Đ&acirc;yl&agrave; nơi chốn thật sự b&igrave;nh y&ecirc;n để chị &ldquo;sống&rdquo; với &acirc;m nhạc v&agrave; kh&aacute;n giả của chị. Kim anh n&oacute;i<br />
Để t&acirc;m hồn được tĩnh lặng, c&oacute; thể n&oacute;i Ph&ograve;ng tr&agrave; l&agrave; &ldquo;dấu lặng&rdquo; c&oacute; uy t&iacute;n với c&aacute;c nhạc phẩm vượt thời gian. Ở đ&acirc;y dễ d&agrave;ng bắt gặp những kh&aacute;n giả trung ni&ecirc;n đắm ch&igrave;m theo d&ograve;ng nhạc như bắt gặp lại kỷ niệm xa xưa. Qu&aacute; khứ như chợt &ugrave;a về với họ theo từng nốt nhạc rơi xuống ngọn nến lung linh tr&ecirc;n b&agrave;n. Khi ấy, nhạc l&agrave;m kh&aacute;n giả sống bằng t&acirc;m thức gi&agrave;u c&oacute; chứ kh&ocirc;ng phải bằng l&yacute; tr&iacute; bươn chải ngh&egrave;o n&agrave;n nữa&hellip;Cứ thế, nhạc sĩ Vũ Xu&acirc;n H&ugrave;ng Nhọc nhằn gom g&oacute;p mật ngọt cho kh&aacute;n giả: những đ&ecirc;m đầu tuần l&agrave; show nhạc tiền chiến (kh&ocirc;ng phụ thu) với những giọng ca trẻ của ph&ograve;ng tr&agrave; như nh&oacute;m M&acirc;y Lang Thang, Đồng Xanh&hellip; Bốn đ&ecirc;m cuối tuần lu&ocirc;n l&agrave; điểm nhấn với c&aacute;c chương tr&igrave;nh chủ đề như Y Lan &ndash; Tuấn Ngọc Elvis Phương Lệ Thu, Thanh Tuyền , Hương Lan, Nhật Hạ Kim Anh.</p>

<p>Những ngọn nến lung linh thắp tr&ecirc;n b&agrave;n l&agrave;m kh&ocirc;ng gian kh&aacute; vu&ocirc;ng vức của ph&ograve;ng tr&agrave; th&ecirc;m ấm c&uacute;ng. Kh&aacute;n giả trung ni&ecirc;n, lịch sự v&agrave;..ho&agrave;i cổ . Khuất sau quầy nước, nhạc sĩ Vũ Xu&acirc;n H&ugrave;ng rỉ rả từng lời dẫn chương tr&igrave;nh bằng thứ giọng Bắc như r&oacute;t mật v&agrave;o tai&hellip;Kh&aacute;n giả lặng nghe h&agrave;ng chục ca kh&uacute;c, li&ecirc;n kh&uacute;c Nửa hồn thương đau, Chuyện phim buồn, Ri&ecirc;ng một g&oacute;c trời...<br />
Tr&ecirc;n hai m&agrave;n h&igrave;nh rộng 350 inch : hi&ecirc;n di&ecirc;n h&igrave;nh ảnh những chương tr&igrave;nh sắp đến như như NSUT Lệ Thủy &ndash; NSUT Thanh Ng&acirc;n, Đ&igrave;nh Tr&iacute; &ndash; &Yacute; Lan NSTU Thanh T&ograve;ng &ndash; Quế Tr&acirc;n v&agrave; những chương tr&igrave;nh xa hơn như Danh Ca Thanh Tuyền - L&ecirc; Uy&ecirc;n Phương v..v</p>

<p>Khởi đầu từ 4 năm trước với t&ecirc;n hiệu Ph&ograve;ng Tr&agrave; Văn Nghệ 14 Lam Sơn &ndash; B&igrave;nh Thạnh . Một nơi chốn để những nguời y&ecirc;u &acirc;m nhạc xưa hằng đ&ecirc;m t&igrave;m đến để&nbsp; thư gi&atilde;n t&acirc;m hồn . Một nơi chốn để ho&agrave;i niệm những kỷ niệm t&igrave;nh y&ecirc;u một thời tuổi trẻ qua những ca kh&uacute;c mang đậm b&oacute;ng d&aacute;ng thời gian . Một nơi chốn để gặp lại những thần tượng ca h&aacute;t thuở n&agrave;o ta đ&atilde; từng y&ecirc;u q&uacute;y . C&aacute;c thần tuơng trở về từ Hải Ngoại cũng như trong nước . V&agrave; ph&ograve;ng tr&agrave; Văn Nghệ đ&atilde; đ&aacute;p ứng được nhu cầu Nghe v&agrave; thoả m&atilde;n được c&aacute;i chất ho&agrave;i niệm l&atilde;ng mạn , phi&ecirc;u bồng con tim của những người y&ecirc;u &acirc;m nhạc xưa cũ .</p>

<p>&nbsp;</p>

<p>V&agrave; đến nay ph&ograve;ng tr&agrave; đ&atilde; tiến th&ecirc;m một bước d&agrave;i , một bước lớn , một bước cao hơn khi chuyển đến địa điểm mới 442 Cao Thắng nối d&agrave;i F 12 Quận 10 HCMc . Đến nơi mới r&ocirc;ng r&atilde;i hơn, sang trọng hơn , trung t&acirc;m hơn n&ecirc;n Ph&ograve;ng tr&agrave; Văn Nghệ cũng c&oacute; th&ecirc;m một t&ecirc;n mới l&agrave; Ph&ograve;ng tr&aacute; &ndash; Ca Vũ , Nhạc Kịch Tiếng Xưa . D&ugrave; thay đổi t&ecirc;n nhưng n&oacute; vẫn giữ phong c&aacute;ch cũ : Vẫn l&agrave; một c&otilde;i ho&agrave;i niệm của những người y&ecirc;u d&ograve;ng &acirc;m nhạc l&atilde;ng mạn , trữ t&igrave;nh xưa, cũng như vẫn lu&ocirc;n mang n&eacute;t v&agrave;ng son cổ điển th&acirc;n thiết cũ . Nhưng v&igrave; nhận thấy rằng trước đ&acirc;y ph&ograve;ng tr&agrave; chỉ mới đ&aacute;p ứng được&nbsp;<strong><em>Nhu Cầu Nghe</em></strong>&nbsp;m&agrave; chưa đ&aacute;p ứng đuợc&nbsp;<strong><em>Nhu cầu</em></strong>&nbsp;<strong><em>Nh&igrave;n &ndash; Nhu Cầu Xem</em></strong>&nbsp;của kh&aacute;n giả n&ecirc;n Tiếng Xưa đ&atilde; mạnh dạn tạo th&ecirc;m m&ocirc;t phong c&aacute;ch mới . Đ&oacute; l&agrave; trong những chương tr&igrave;nh ca nhạc hằng đ&ecirc;m ch&uacute;ng t&ocirc;i c&oacute; tr&igrave;nh diễn xen kẽ những vở nhạc kịch dựa tr&ecirc;n những huyền thoại những t&iacute;ch truyện d&acirc;n gian nổi tiếng của Việt Nam va Thế Giới.</p>
')
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (6, N'abc', N'sdsa', 1, 2, NULL)
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (7, N'Phòng Trà We', N'8 Lê Quý Đôn, Phường 06, Quận 3, TP Hồ Chí Minh', 63, 1, N'<p>Ph&ograve;ng tr&agrave; WE nằm ở g&oacute;c ng&atilde; tư Nguyễn Đ&igrave;nh Chiểu v&agrave; L&ecirc; Qu&yacute; Đ&ocirc;n. Kh&ocirc;ng gian được chia l&agrave;m 3 khu vực kh&aacute;c nhau: Tầng 1 l&agrave; Nh&agrave; H&agrave;ng, Cafe; Tầng 2 l&agrave; Lounge, v&agrave; Tầng 3 l&agrave; Ph&ograve;ng Tr&agrave;. Mỗi đ&ecirc;m đều c&oacute; nhạc live ở khu vực tầng 3, với mức phụ thu tương đối. Kh&ocirc;ng gian được thiết kế tho&aacute;ng mở ở tầng 1, ấm c&uacute;ng nhẹ nh&agrave;ng ở tầng 2, v&agrave; lảng mạn ở tầng ba. Đ&acirc;y l&agrave; địa điểm l&yacute; tưởng để tổ chức c&aacute;c sự kiện quan trọng.</p>

<p><img src="http://vntic.vn/images/stories/diadiem/w4.jpg" style="border:none; height:412px; max-width:600px; width:620px" /></p>

<p>Bạn c&oacute; thể thưởng thức c&aacute;c m&oacute;n ăn ngon tại Nh&agrave; h&agrave;ng ở tầng một. Thưởng thức cooktail v&agrave; rượu vang hảo hạng tại Lounge ở tầng 2, hoặc thư gi&atilde;n trong Ph&ograve;ng tr&agrave; l&atilde;ng mạn ở tầng 3 với d&agrave;n nhạc sống v&agrave; ca sĩ tr&igrave;nh diễn live v&agrave;o mỗi cuối tuần.</p>

<p><img src="http://vntic.vn/images/stories/diadiem/w3.jpg" style="border:none; max-width:600px" /></p>

<p><img src="http://vntic.vn/images/stories/diadiem/w1.jpg" style="border:none; max-width:600px" /></p>
')
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (8, N'Phòng Trà Nam Quang', N'147 Cách Mạng Tháng 8,Phường 5,Quận 3', 63, 1, N'<p><strong>PH&Ograve;NG TR&Agrave;&nbsp;</strong><strong>NAM QUANG</strong></p>

<p><strong>Kh&ocirc;ng gian &acirc;m nhạc HOT</strong></p>

<p><strong>ĐC : 147 C&aacute;ch Mạng Th&aacute;ng 8,Phường 5,Quận 3,Tp HCM</strong></p>

<p><strong>Tell : 0915863636 - 0838344617</strong><br />
&nbsp;</p>

<p><strong><em>L&agrave; một sự lột x&aacute;c ho&agrave;n to&agrave;n từ nh&agrave; h&aacute;t kịch Nam Quang,ph&ograve;ng tr&agrave; Nam Quang đ&atilde; được đầu tư v&agrave; x&acirc;y dựng trở th&agrave;nh một địa điểm l&yacute; tưởng cho giới trẻ y&ecirc;u nhạc.</em></strong></p>

<p><img alt="phong tra nam quang " src="http://vntic.vn/images/HinhAnh/Lichphongtra/NamQuang/new/phong-tra-nam-quang-li-hai.png" style="border:none; height:289px; max-width:600px; width:458px" title="phong tra nam quang " /></p>

<p>&Acirc;m nhạc mang nhiều th&ocirc;ng điệp cho cuộc sống, sự sẻ chia, niềm hạnh ph&uacute;c, nỗi c&ocirc; đơn hay thất vọng,... &Acirc;m nhạc xoa dịu t&acirc;m hồn con người v&agrave; gi&uacute;p h&agrave;n gắn những vết thương l&ograve;ng. Quan trọng hơn, &acirc;m nhạc kết nối mọi tấm l&ograve;ng, cho ch&uacute;ng ta những gi&acirc;y ph&uacute;t lắng đọng trong thế giới ri&ecirc;ng của m&igrave;nh, ch&iacute;nh v&igrave; những điều đ&oacute; m&agrave; ph&ograve;ng tr&agrave; Nam Quang ra đời để mang lại những khoảnh khắc &acirc;m nhạc sống động.</p>

<p>Với vị tr&iacute; giao th&ocirc;ng thuận lợi, nằm ngay g&oacute;c ng&atilde; tư, với bốn l&agrave;n đường hai chiều, chỗ đậu xe &ocirc;t&ocirc; v&agrave; xe m&aacute;y rộng r&atilde;i, ph&ograve;ng tr&agrave; Nam Quang lu&ocirc;n tạo được sự thoải m&aacute;i cho kh&aacute;ch nghe nhạc.</p>

<p><img alt="phong tra nam quang " src="http://vntic.vn/images/HinhAnh/Lichphongtra/NamQuang/img_0018.jpg" style="border:none; height:375px; max-width:600px; width:500px" title="phong tra nam quang " /></p>

<p>&nbsp;</p>

<p>Nam Quang kh&ocirc;ng chỉ l&agrave; nơi thư gi&atilde;n, giao lưu thuần t&uacute;y giữa kh&aacute;n giả - ca sĩ m&agrave; c&ograve;n l&agrave; c&otilde;i ri&ecirc;ng của rất nhiều văn nghệ sĩ qua những đ&ecirc;m nhạc ri&ecirc;ng.</p>

<p><img alt="phong tra nam quang" src="http://vntic.vn/images/HinhAnh/Lichphongtra/NamQuang/HinhPhongTra/phong-tra-nam-quang-l3123.png" style="border:none; height:318px; max-width:600px; width:504px" title="phong tra nam quang" /></p>

<p><span style="line-height:1.6em">Hiện nay, ph&ograve;ng tr&agrave; Nam Quang đang ng&agrave;y c&agrave;ng thu h&uacute;t được nhiều kh&aacute;n giả trẻ tuổi, với kh&ocirc;ng gian nội thất sang trọng v&agrave; hơn 450 chỗ ngồi.</span></p>

<p>Sự ấm c&uacute;ng, c&aacute;ch phục vụ chu đ&aacute;o c&ugrave;ng với hệ thống kỹ thuật &acirc;m thanh, &aacute;nh s&aacute;ng hiện đại v&agrave; chuy&ecirc;n nghiệp nhất Tp. HCM, ph&ograve;ng tr&agrave; Nam Quang c&oacute; thể l&agrave;m h&agrave;i l&ograve;ng cả những vị kh&aacute;ch rất kh&oacute; t&iacute;nh ngay lần đầu gh&eacute; thăm.</p>

<p><img alt="phong tra nam quang" src="http://vntic.vn/images/HinhAnh/Lichphongtra/NamQuang/new/phong-tra-nam-quang-IMG_0020.JPG" style="border:none; height:375px; max-width:600px; width:500px" title="phong tra nam quang" /></p>

<p>B&ecirc;n cạnh đ&oacute;, nội dung chương tr&igrave;nh ca nhạc hằng đ&ecirc;m được bi&ecirc;n tập kỹ lưỡng v&agrave; d&agrave;n dựng theo từng chủ đề kh&aacute;c nhau, dưới sự s&aacute;ng tạo kh&ocirc;ng ngừng của một &ecirc;kip bi&ecirc;n tập năng động. Ngo&agrave;i ra, ph&ograve;ng tr&agrave; Nam Quang cũng thường xuy&ecirc;n tổ chức c&aacute;c buổi họp Fan club,họp b&aacute;o ra mắt CD,c&aacute;c mini liveshow cho nhiều ca sĩ như Đ&agrave;m Vĩnh Hưng, Thanh Thảo,Đan Trường ,Noo Phước Thịnh,Cẩm ly,ca sĩ hải ngoại Hương Lan,Minh tuyết......</p>

<p><img src="http://vntic.vn/images/HinhAnh/Lichphongtra/NamQuang/new/phong-tra-nam-quang-IMG_0014.JPG" style="border:none; height:375px; max-width:600px; width:500px" /></p>

<p><span style="line-height:1.6em">Đến với ph&ograve;ng tr&agrave; Nam Quang, bạn như đựợc đắm m&igrave;nh trong một kh&ocirc;ng gian &acirc;m nhạc để qu&ecirc;n đi những muộn phiền, lo &acirc;u của cuộc sống h&agrave;ng ng&agrave;y b&ecirc;n những người th&acirc;n y&ecirc;u.</span></p>
')
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (9, N'aaa', N'sssss', 1, 2, NULL)
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (10, N'Phòng Trà Điểm Hẹn Sài Gòn', N'230 đường 3-2, P12 Q10', 63, 1, N'<p>Đi v&agrave;o hoạt động đầu năm 2005, nh&agrave; h&agrave;ng - c&agrave; ph&ecirc; ca nhạc Điểm hẹn S&agrave;i G&ograve;n ngay lập tức thu h&uacute;t được một lượng kh&aacute;ch đ&ocirc;ng đảo. Kh&aacute;ch đến đ&acirc;y kh&ocirc;ng chỉ để uống c&agrave; ph&ecirc;, thưởng thức c&aacute;c m&oacute;n ăn c&ugrave;ng với những chương tr&igrave;nh ca nhạc đặc sắc m&agrave; c&ograve;n được chi&ecirc;m ngưỡng một lối kiến tr&uacute;c độc đ&aacute;o, thư gi&atilde;n với kh&ocirc;ng gian kho&aacute;ng đ&atilde;ng.</p>

<p><img src="http://vntic.vn/images/stories/diadiem/tang-2.jpg" style="border:none; max-width:600px" /></p>

<p>Được x&acirc;y dựng ngay vị tr&iacute; trung t&acirc;m th&agrave;nh phố, g&oacute;c ng&atilde; tư đường 3-2 (230 đường 3-2, P12 Q10 - Cao Thắng v&agrave; đầu chợ đ&ecirc;m Kỳ H&ograve;a n&ecirc;n Điểm hẹn S&agrave;i G&ograve;n rất thuận tiện, dễ thu h&uacute;t kh&aacute;ch. Ngay từ khi bước v&agrave;o Điểm hẹn S&agrave;i G&ograve;n, bạn sẽ bị cuốn h&uacute;t bởi phong c&aacute;ch ấn tượng trong việc thiết kế với nhiều m&agrave;u sắc được kết hợp h&agrave;i h&ograve;a mang phong c&aacute;ch hiện đại. D&agrave;n &acirc;m thanh, &aacute;nh s&aacute;ng được thiết kế, lắp đặt bởi những chuy&ecirc;n vi&ecirc;n Singapore, n&ecirc;n Điểm hẹn S&agrave;i G&ograve;n đ&atilde; định h&igrave;nh cho m&igrave;nh một phong c&aacute;ch rất ri&ecirc;ng biệt, kh&ocirc;ng trộn lẫn với những qu&aacute;n c&agrave; ph&ecirc; kh&aacute;c. Tầng trệt v&agrave; tầng thượng với kh&ocirc;ng gian kho&aacute;ng đ&atilde;ng th&iacute;ch hợp với giới trẻ. Tầng một c&oacute; nhiều khu ri&ecirc;ng biệt, chia cắt bởi những tấm gỗ trang tr&iacute; xinh xắn được trang bị to&agrave;n bộ m&aacute;y lạnh n&ecirc;n đ&acirc;y l&agrave; nơi thực kh&aacute;ch c&oacute; thể t&igrave;m cho m&igrave;nh một vị tr&iacute; để thư gi&atilde;n sau những giờ&nbsp;l&agrave;m việc mệt mỏi, căng thẳng. Ph&ograve;ng tr&agrave; ca nhạc tại lầu hai h&agrave;ng đ&ecirc;m c&oacute; chương tr&igrave;nh chọn lọc với sự g&oacute;p mặt của c&aacute;c ng&ocirc;i sao ca nhạc, nh&oacute;m nhạc, nh&oacute;m h&agrave;i nổi tiếng c&ugrave;ng ban nhạc Saigon Boys.</p>

<p>Một thế mạnh kh&aacute;c của Điểm hẹn S&agrave;i G&ograve;n l&agrave; phục vụ c&aacute;c m&oacute;n ăn &Acirc;u, &Aacute;, Hoa với gi&aacute; cả tương đối mềm. D&ugrave; bạn đến qu&aacute;n v&agrave;o l&uacute;c n&agrave;o vẫn c&oacute; thể chọn ri&ecirc;ng cho m&igrave;nh những m&oacute;n ăn vừa &yacute; hợp khẩu vị, được chế biến bởi những đầu bếp chuy&ecirc;n nghiệp từng đoạt giải cao trong c&aacute;c cuộc thi nấu ăn.</p>

<p>Với h&agrave;ng trăm nh&acirc;n vi&ecirc;n được đ&agrave;o tạo chuy&ecirc;n nghiệp qua trường lớp, l&agrave; cơ sở để ch&uacute;ng t&ocirc;i x&aacute;c định mục ti&ecirc;u của m&igrave;nh l&agrave; phong c&aacute;ch phục vụ v&agrave; cũng ch&iacute;nh l&agrave; thế mạnh để mỗi ng&agrave;y kh&aacute;ch đến với Điểm hẹn S&agrave;i G&ograve;n đ&ocirc;ng hơn.</p>

<p>Với ban quản l&yacute; v&agrave; đội ngũ nh&acirc;n vi&ecirc;n phục vụ nhiệt t&igrave;nh v&agrave; tận t&acirc;m, đến với Điểm Hẹn S&agrave;i G&ograve;n, qu&yacute; kh&aacute;ch sẽ được thưởng thức c&aacute;c m&oacute;n ăn ngon v&agrave; thức uống hay c&oacute; thể ho&agrave; v&agrave;o thế giới &acirc;m nhạc. D&ugrave; kh&oacute; t&iacute;nh đến mấy, nhưng khi đến Điểm hẹn S&agrave;i G&ograve;n bạn sẽ cảm thấy h&agrave;i l&ograve;ng.</p>
')
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (11, N'MTV Bar Ca Nhạc', N'Lầu 1-65 Võ Văn Tần, Phường 6, Quận 3', 63, 1, N'<p>-Tầng trệt m&ocirc; h&igrave;nh Cafe Bar m&aacute;y lạnh, ph&ugrave; hợp với Kh&aacute;ch h&agrave;ng trẻ tuổi đến đ&acirc;y c&ugrave;ng ho&agrave; m&igrave;nh v&agrave;o những d&ograve;ng nhạc s&ocirc;i động do c&aacute;c DJ của MTV thể hiện với nhiều thể loại nhạc VN, nhạc trẻ Quốc tế đang được giới trẻ y&ecirc;u th&iacute;ch. Với c&aacute;c m&oacute;n ăn đa dạng, đội ngũ nh&acirc;n vi&ecirc;n vui vẻ, th&acirc;n thiện h&acirc;n hạnh phục vụ qu&yacute; Kh&aacute;ch h&agrave;ng từ 7h đến 24h mỗi ng&agrave;y.</p>

<p><img src="http://vntic.vn/components/com_itidiadiem/images/1321797826_mtv1.jpg" style="border:1px solid rgb(204, 204, 204); line-height:1.6em; width:235px" /></p>

<p>-Tầng một Ph&ograve;ng tr&agrave;&nbsp;Ca nhac với sức chứa 600 Kh&aacute;ch với chương tr&igrave;nh biểu diễn h&agrave;ng đ&ecirc;m từ 20h45 tr&ecirc;n s&acirc;n khấu lớn ho&agrave;nh tr&aacute;ng, chuy&ecirc;n nghiệp, hệ thống &acirc;m thanh, &aacute;nh s&aacute;ng hiện đại. Thứ hai v&agrave; thứ ba h&agrave;ng tuần l&agrave; chương tr&igrave;nh &ldquo;đ&ecirc;m hội danh h&agrave;i&rdquo; biểu diễn những tiết mục h&agrave;i của c&aacute;c nh&oacute;m h&agrave;i, danh h&agrave;i c&oacute; tiếng của Th&agrave;nh Phố.Những ng&agrave;y c&ograve;n lại l&agrave; đ&ecirc;m nhạc trẻ, live show, party, sinh nhật với sự g&oacute;p mặt của c&aacute;c ca sĩ đ&atilde; v&agrave; đang được mọi người y&ecirc;u mến như: Đ&agrave;m Vĩnh Hưng, Tuấn Hưng, Quang H&agrave;, Hiền Thục, Thanh Thảo, Phạm Thanh Thảo, M&acirc;y Trắng...Ngo&agrave;i ra c&ograve;n c&oacute; sự g&oacute;p mặt của c&aacute;c ca sĩ đang được giới trẻ y&ecirc;u th&iacute;ch như: Noo Phước Thịnh, Quang Vinh, Minh Hằng, Ng&acirc;n Kh&aacute;nh, Lệ Quy&ecirc;n, Đ&ocirc;ng Nhi, Bảo Thy, WanBi Tuấn Anh, Qu&aacute;ch An An...</p>
')
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (12, N'Phòng Trà Không Tên', N'32 Cách Mạng Tháng Tám, Q.10', 63, 1, N'<p><img src="http://vntic.vn/components/com_itidiadiem/images/1321802164_khongten.jpg" style="border:1px solid #cccccc; width:235px" /></p>

<p>Đi v<span style="line-height:1.6em">&agrave;o hoạt động từ th&aacute;ng 4-2005, ph&ograve;ng tr&agrave; Kh&ocirc;ng T&ecirc;n gắn liền thương hiệu nhạc sĩ L&ecirc; Quang - bi&ecirc;n tập ch&iacute;nh của c&aacute;c chương tr&igrave;nh ca nhạc tại đ&acirc;y.</span></p>

<p>Kh&ocirc;ng T&ecirc;n kh&ocirc;ng chỉ l&agrave; nơi thư gi&atilde;n, giao lưu thuần t&uacute;y giữa kh&aacute;n giả - ca sĩ m&agrave; c&ograve;n l&agrave; c&otilde;i ri&ecirc;ng của rất nhiều văn nghệ sĩ hải ngoại về biểu diễn tại qu&ecirc; nh&agrave; như: Elvis Phương, Duy Quang, Th&aacute;i Ch&acirc;u, Tommy Ng&ocirc;, Linda Trang Đ&agrave;i, Mạnh Đ&igrave;nh, Tuấn Ngọc, Kh&aacute;nh H&agrave;, Kim Anh, Ngọc B&iacute;ch, Hương Lan, Ho&agrave;i Linh, Ch&iacute; T&agrave;i, Phi Nhung, Đức Huy... Đ&acirc;y cũng l&agrave; nơi hội ngộ của nhiều ca sĩ t&ecirc;n tuổi trong nước: Mỹ T&acirc;m, Đ&agrave;m Vĩnh Hưng, Quang Dũng, Hồng Ngọc, Hồ Ngọc H&agrave;, Đức Tuấn, Phương Thanh, Thanh Thảo, Duy Mạnh, Kasim... qua những đ&ecirc;m nhạc tạo được nhiều ấn tượng như Khoảnh khắc v&agrave;ng, Thương ho&agrave;i ng&agrave;n năm, Đ&ecirc;m truyện ca, Dạ kh&uacute;c cho t&igrave;nh nh&acirc;n, Trương Chi, c&aacute;c đ&ecirc;m nhạc mừng Gi&aacute;ng sinh, mừng năm mới, Singer&rsquo;s Day..., bắt nguồn từ &yacute; tưởng của đ&ocirc;i vợ chồng nhạc sĩ - ca sĩ L&ecirc; Quang - Cam Thơ.</p>

<p>Kh&ocirc;ng chỉ mời c&aacute;c ca sĩ hải ngoại, nhạc sĩ L&ecirc; Quang c&ograve;n tận t&igrave;nh hướng dẫn phong c&aacute;ch biểu diễn, gợi &yacute; chọn ca kh&uacute;c ph&ugrave; hợp chất giọng, g&oacute;p &yacute; về phục trang, đạo cụ cho c&aacute;c ca sĩ trẻ như một người thầy, người đ&agrave;n anh đi trước.</p>

<p>NS L&ecirc; Quang cho biết: &ldquo;L&uacute;c đầu t&ocirc;i t&iacute;nh mở ra để c&oacute; nơi anh em hội ngộ, giao lưu. Hơn 2 năm hoạt động, Kh&ocirc;ng T&ecirc;n kh&ocirc;ng những trụ được m&agrave; ng&agrave;y c&agrave;ng c&oacute; nhiều kh&aacute;n giả trong nước v&agrave; Việt kiều t&igrave;m đến, nhất l&agrave; sau khi kh&aacute;n ph&ograve;ng n&acirc;ng cấp nội thất với tr&ecirc;n 700 chỗ ngồi v&agrave; một lầu&rdquo;. Sự ấm c&uacute;ng, phục vụ chu đ&aacute;o v&agrave; nhiều chương tr&igrave;nh hay đ&atilde; nhanh ch&oacute;ng gi&uacute;p Kh&ocirc;ng T&ecirc;n trở th&agrave;nh &ldquo;c&otilde;i v&ocirc; thường&rdquo; của những người Việt xa qu&ecirc; hương, đến đ&acirc;y sẽ c&oacute; cảm gi&aacute;c như đang ở ch&iacute;nh &ldquo;ng&ocirc;i nh&agrave; &acirc;m nhạc&rdquo; của m&igrave;nh. Đặc biệt với cung c&aacute;ch phục vụ tận t&igrave;nh, niềm nở của 40 nh&acirc;n vi&ecirc;n v&agrave; c&aacute;c th&agrave;nh vi&ecirc;n ban nhạc Kh&ocirc;ng T&ecirc;n: Tấn Phong - cựu th&agrave;nh vi&ecirc;n ban nhạc New Friend (guitar), Đức Bảo (guitar bass), NS Trương L&ecirc; Sơn (organ), A D&igrave;n (trống), Thanh Nh&atilde; (piano)... C&oacute; những l&uacute;c &ocirc;ng chủ L&ecirc; Quang cũng l&ecirc;n s&acirc;n khấu đệm guitar th&ugrave;ng h&aacute;t c&ugrave;ng Mỹ T&acirc;m, Cam Thơ, Hồng Ngọc...</p>

<p>Gần 5 năm hoạt động, Kh&ocirc;ng T&ecirc;n kh&ocirc;ng những trụ được m&agrave; ng&agrave;y c&agrave;ng c&oacute; nhiều kh&aacute;n giả trong nước v&agrave; Việt kiều t&igrave;m đến, nhất l&agrave; sau khi kh&aacute;n ph&ograve;ng n&acirc;ng cấp nội thất với tr&ecirc;n 400 chỗ ngồi v&agrave; một lầu&rdquo;. Sự ấm c&uacute;ng, phục vụ chu đ&aacute;o v&agrave; nhiều chương tr&igrave;nh hay đ&atilde; nhanh ch&oacute;ng gi&uacute;p Kh&ocirc;ng T&ecirc;n trở th&agrave;nh &ldquo;c&otilde;i v&ocirc; thường&rdquo; của những người Việt xa qu&ecirc; hương, đến đ&acirc;y sẽ c&oacute; cảm gi&aacute;c như đang ở ch&iacute;nh &ldquo;ng&ocirc;i nh&agrave; &acirc;m nhạc&rdquo; của m&igrave;nh. Đặc biệt với cung c&aacute;ch phục vụ tận t&igrave;nh, niềm nở của 40 nh&acirc;n vi&ecirc;n v&agrave; c&aacute;c th&agrave;nh vi&ecirc;n ban nhạc Kh&ocirc;ng T&ecirc;n: Tấn Phong - cựu th&agrave;nh vi&ecirc;n ban nhạc New Friend (guitar), Đức Bảo (guitar bass), NS Trương L&ecirc; Sơn (organ), A D&igrave;n (trống), Thanh Nh&atilde; (piano)...</p>
')
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (13, N'Sân Khấu Ca Nhạc Cầu Vồng 126', N'126 Cách Mạng Tháng Tám, Q10', 63, 1, N'<p>S&acirc;n khấu Cầu Vồng toạ lạc tại đường C&aacute;ch Mạng Th&aacute;ng T&aacute;m c&ograve;n được gọi s&acirc;n khấu 126, tuy kh&ocirc;ng phải ở v&agrave;o top s&acirc;n khấu lớn nhưng cũng từng bước khẳng định vị thế trong h&agrave;ng loạt chương tr&igrave;nh ca nhạc trong c&aacute;c ng&agrave;y nghỉ lễ &amp; cuối tuần... cho kh&aacute;n giả y&ecirc;u nhạc tại S&agrave;i G&ograve;n.</p>

<p><img src="http://vntic.vn/images/HinhAnh/Diadiem/SaiGon/SanKhau126/sankhau126_2.jpg" style="border:none; height:375px; max-width:600px; width:500px" /></p>

<p>C&aacute;c chương tr&igrave;nh ca m&uacute;a nhạc đặc biệt được d&agrave;n dựng c&ocirc;ng phu v&agrave; thiết kế, trang tr&iacute; s&acirc;n khấu theo đ&uacute;ng chủ đề với nhiều tiết mục phong ph&uacute;, đa dạng. Đặc biệt nơi qui tụ rất đ&ocirc;ng đảo ca sĩ, nghệ sĩ t&ecirc;n tuổi của Th&agrave;nh phố.</p>
')
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (14, N'Nhà Hát Thành Phố', N'7 Công Trường Lam Sơn, Phường Bến Nghé, Quận 1', 63, 1, N'<p>B&ecirc;n cạnh những n&eacute;t đẹp tự nhi&ecirc;n về cảnh quan, kh&iacute; hậu v&agrave; con người th&igrave; những c&ocirc;ng tr&igrave;nh kiến tr&uacute;c cũng thể hiện n&eacute;t độc đ&aacute;o về lịch sử v&agrave; văn h&oacute;a của một địa danh. Nếu đ&atilde; quyết t&acirc;m d&agrave;nh trọn một chuyến thăm quan&nbsp; th&agrave;nh phố Hồ Ch&iacute; Minh th&igrave; ngo&agrave;i nh&agrave; thờ Đức B&agrave;, Dinh Độc Lập, chơ Bến Th&agrave;nh, Nh&agrave; H&aacute;t lớn Th&agrave;nh tọa lạc tr&ecirc;n&nbsp; đường Đồng Khởi , giữa trung t&acirc;m th&agrave;nh phố xứng đ&aacute;ng l&agrave; điểm đến kế tiếp trong h&agrave;nh tr&igrave;nh tham quan th&agrave;nh phố mang t&ecirc;n B&aacute;c.<br />
<br />
Lịch sử về nguồn gốc của nh&agrave; h&aacute;t n&agrave;y bắt đầu v&agrave;o năm 1863 khi chiếm lĩnh được&nbsp; Nam Kỳ,&nbsp; ch&iacute;nh quyền Ph&aacute;p đ&atilde; mời một đo&agrave;n h&aacute;t sang biểu diễn tại S&agrave;i G&ograve;n để mua vui cho l&iacute;nh viễn chinh Ph&aacute;p.V&agrave; trải qua một số buổi biểu diễn tại nh&agrave; h&aacute;t dựng tạm ngay g&oacute;c đường Nguyễn Du, ng&agrave;y 1 th&aacute;ng 1 năm 1900, nh&agrave; h&aacute;t mới đ&atilde; được kh&aacute;nh th&agrave;nh.Đ&oacute; ch&iacute;nh l&agrave; nh&agrave; h&aacute;t lớn S&agrave;i G&ograve;n.<br />
<br />
Kiến tr&uacute;c của nh&agrave; h&aacute;t được dựng theo phong c&aacute;ch đế quốc&nbsp; m&agrave; l&uacute;c bấy giờ l&agrave; kiến tr&uacute;c Gothique thịnh h&agrave;nh tại Ph&aacute;p thế kỷ XIX, đầu thế kỷ XX do nh&oacute;m kiến tr&uacute;c sư người Ph&aacute;p F&eacute;lix Olivier, Eug&egrave;ne Ferret, Ernest Guichard thiết kế. Đặc trưng của lối kiến tr&uacute;c n&agrave;y l&agrave; sự phối hợp kh&eacute;o l&eacute;o giữa kiến tr&uacute;c v&agrave; đi&ecirc;u khắc. Trang tr&iacute; đi&ecirc;u khắc được coi trọng, từ h&igrave;nh thức kiến tr&uacute;c mặt ngo&agrave;i đến nội thất đều đắp nhiều ph&ugrave; đi&ecirc;u v&agrave; tượng nổi.<br />
<br />
Kỉ niệm 300 năm S&agrave;i G&ograve;n, th&agrave;nh phố Hồ Ch&iacute; Minh th&agrave;nh lập v&agrave;o năm 1998, ch&iacute;nh quyền th&agrave;nh phố đ&atilde; đầu tư 25 tỉ để nấng cấp lại nh&agrave; h&aacute;t v&agrave; phục hồi trang tr&iacute; 2 nữ thần nghệ thuật, c&aacute;c d&acirc;y hoa, hai c&acirc;y đ&egrave;n để t&aacute;i tạo lại n&eacute;t kiến tr&uacute;c ban đầu cũng như chức năng của nh&agrave; h&aacute;t đ&atilde; bi thay đổi&nbsp; khi&nbsp; được ch&iacute;nh quyền S&agrave;i G&ograve;n cho tu bổ, cải tạo l&agrave;m trụ sở Hạ nghị viện sau năm 1954.</p>

<p><img src="http://vntic.vn/images/stories/diadiem/hcm-city_oper1.jpg" style="border:none; max-width:600px" /></p>

<p>Nh&agrave; h&aacute;t lớn Th&agrave;nh phố Hồ Ch&iacute; Minh với&nbsp; 559 chỗ ngồi l&agrave; nh&agrave; h&aacute;t trung t&acirc;m, đa năng chuy&ecirc;n tổ chức biểu diễn s&acirc;n khấu nghệ thuật đồng thời cũng được sử dụng để tổ chức những sự kiện lớn. Đ&acirc;y cũng l&agrave; nh&agrave; h&aacute;t thuộc loại l&acirc;u đời thể hiện một gi&aacute; trị thăng trầm của lịch sử th&agrave;nh phố v&agrave; được xem như một địa điểm du lịch của th&agrave;nh phố n&agrave;y</p>
')
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (15, N'Trung tâm Ca nhạc Lan Anh', N'291 Cách Mạng Tháng Tám, Phường 12, Quận 10', 63, 1, N'<p><a href="http://lananhclub.vn/uploads/page/photo/2011/October/mo-hinh-CLB-LanAnh.jpg" rel="prettyPhoto" style="color: rgb(253, 249, 213); outline: none; text-decoration: none;"><img alt="" class="fadeOver" src="http://lananhclub.vn/uploads/page/photo/2011/October/mo-hinh-CLB-LanAnh-small.jpg" style="border:0px; height:275px; opacity:0.7874419087635876; vertical-align:bottom; width:405px" />​</a></p>

<p>Trung t&acirc;m Ca nhạc Lan Anh&nbsp;tọa lạc tại C&acirc;u Lạc Bộ Lan Anh - 291 C&aacute;ch Mạng Th&aacute;ng T&aacute;m, Phường 12, Quận 10. Ngo&agrave;i lợi thế nằm trong khu&ocirc;n vi&ecirc;n rộng lớn của khu li&ecirc;n hợp Thể dục Thể thao &ndash; Giải tr&iacute; lớn của TPHCM,&nbsp;Trung t&acirc;m Ca nhạc Lan Anh&nbsp;c&ograve;n l&agrave; điểm đến thuận tiện v&agrave; l&yacute; tưởng cho kh&aacute;n giả cũng như những đơn vị tổ chức sự kiện, chương tr&igrave;nh ca nhạc.</p>

<p>Hệ thống trang thiết bị &Acirc;m thanh &ndash; &Aacute;nh s&aacute;ng hiện đại c&ugrave;ng với cơ sở vật chất lu&ocirc;n được tu bổ một c&aacute;ch chỉnh chu, s&acirc;n khấu rộng v&agrave; s&acirc;u gi&uacute;p cho TTCN đ&aacute;p ứng được tất cả c&aacute;c y&ecirc;u cầu về thực hiện s&acirc;n khấu, &yacute; tưởng nghệ thuật của chương tr&igrave;nh.</p>

<p>Trung t&acirc;m Ca nhạc Lan Anh&nbsp;với hơn 10 năm hoạt động v&agrave; ng&agrave;y c&agrave;ng trở n&ecirc;n quen thuộc v&agrave; gần gũi với kh&aacute;n giả TPHCM n&oacute;i ri&ecirc;ng v&agrave; kh&aacute;n giả cả nước n&oacute;i chung th&ocirc;ng qua h&agrave;ng loạt c&aacute;c chương tr&igrave;nh truyền h&igrave;nh trực tiếp.</p>

<p>Ch&uacute;ng t&ocirc;i rất tự h&agrave;o l&agrave; một trong những địa điểm tổ chức biểu diễn bậc nhất của TP.HCM c&ugrave;ng với những chương tr&igrave;nh mang t&iacute;nh qui m&ocirc;, sang trọng, ho&agrave;nh tr&aacute;ng v&agrave; s&ocirc;i nổi như Duy&ecirc;n D&aacute;ng Việt Nam 13, X&uacute;c cảm M&ugrave;a Hạ &ndash; Cổ Thi&ecirc;n Lạc, DJ Ferry Corsten Show, Việt Nam Idol, &hellip; b&ecirc;n cạnh những chương tr&igrave;nh đ&aacute;nh dấu cột mốc th&agrave;nh c&ocirc;ng của c&aacute;c ca sỹ như live show Đ&agrave;m Vĩnh Hưng, Đan Trường, Hồ Quỳnh Hương, Tuấn Hưng, Dương Triệu Vũ, &hellip; Ngo&agrave;i ra, c&ograve;n c&oacute; rất nhiều những Chương Tr&igrave;nh Hội Nghị Kh&aacute;ch H&agrave;ng, Chương Tr&igrave;nh Ra Mắt Sản Phẩm Mới, Lễ Trao Giải Thưởng, &hellip;</p>
')
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (16, N'Nhà Hát Lớn', N'Số 1 Tràng Tiền, Hoàn Kiếm', 62, 0, NULL)
INSERT INTO [dbo].[Venue] ([VenueId], [VenueName], [Address], [ProvinceId], [Status], [Description]) VALUES (17, N'Crescent Resident', N' Khu dân cư crescent residence, quận 7', 1, 1, N'<p>Tọa lạc tại Ph&uacute; Mỹ Hưng, Quận 7, crescent residence được xem như l&agrave; một biểu tượng&nbsp; của sự ph&aacute;t triển một phong c&aacute;ch sống mới tại Việt Nam. Tọa lạc dọc bờ hồ tuyệt đẹp, khu căn hộ đ&atilde; trở th&agrave;nh tổ ấm của nhiều gia đ&igrave;nh, mang đến một kh&ocirc;ng gian y&ecirc;n tĩnh, an to&agrave;n v&agrave; tiện lợi</p>
')
SET IDENTITY_INSERT [dbo].[Venue] OFF


-----------Event------------------
SET IDENTITY_INSERT [dbo].[Event] ON
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (1, N'Đêm nhạc Phạm Duy-Phạm Đình Chương-Trịnh Công Sơn', N'~/Content/Upload/t7-500.png', N'Nhiều nghệ sỹ', N'2013-07-20 20:00:00', N'<p>Ng&agrave;y 20/07/2013, tại ph&ograve;ng tr&agrave; Tiếng Xưa sẽ diễn ra Đ&ecirc;m nhạc Phạm Duy - Phạm Đ&igrave;nh Chương - Trần Ho&agrave;n - L&ecirc; Uy&ecirc;n Phương - Trịnh C&ocirc;ng Sơn&nbsp;với sự tham gia của c&aacute;c Ca sĩ: Nguyễn Huỳnh, Ana Long, Thanh Tr&uacute;c, Thanh Vinh, Lina Nguyễn, Quang Trường, V&acirc;n Anh, Y&ecirc;n Chi, Vũ Xu&acirc;n H&ugrave;ng, Nhật Nam, Hồng V&acirc;n, trong một kh&ocirc;ng gian ấm &aacute;p, sang trọng v&agrave; sự phục vụ chu đ&aacute;o.</p>
', 1, 3, 5, NULL, N'2013-07-19 14:46:16')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (2, N'Sự kiện 2', NULL, N'Mỹ Tâm', N'2013-02-21 08:00:00', NULL, 2, 2, 5, NULL, N'2013-07-19 15:01:59')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (3, N'Sự kiện 3', NULL, N'Mỹ Tâm', N'2013-02-15 00:00:00', NULL, 2, 3, 3, N'2013-02-15 00:00:00', N'2013-07-19 15:02:13')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (4, N'Sự kiện 4', NULL, N'Mỹ Tâm', N'2013-02-15 00:00:00', NULL, 2, 4, 4, N'2013-02-15 00:00:00', N'2013-07-19 15:02:15')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (5, N'Sự kiện 5', NULL, N'Mỹ Tâm', N'2013-02-15 00:00:00', NULL, 2, 1, 1, N'2013-02-15 00:00:00', N'2013-07-19 15:02:16')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (6, N'Sự kiện 6', NULL, N'Mỹ Tâm', N'2013-02-15 00:00:00', NULL, 2, 2, 2, N'2013-02-15 00:00:00', N'2013-07-19 15:02:18')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (7, N'Sự kiện 7', NULL, N'Mỹ Tâm', N'2013-02-15 00:00:00', NULL, 2, 3, 3, N'2013-02-15 00:00:00', N'2013-07-19 15:02:20')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (8, N'Sự kiện 8', NULL, N'Mỹ Tâm', N'2013-02-15 00:00:00', NULL, 2, 4, 4, N'2013-02-15 00:00:00', N'2013-07-19 15:02:23')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (9, N'Sự kiện 9', NULL, N'Mỹ Tâm', N'2013-02-15 00:00:00', NULL, 2, 1, 2, N'2013-02-15 00:00:00', N'2013-07-19 15:02:22')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (10, N'Đêm nhạc Quang Lê', N'~/Content/Upload/29e94_le1.jpg', N'Quang Lê', N'2013-07-20 20:00:00', N'<p><strong>Đến với Ph&ograve;ng tr&agrave; We tối 20/07 để thưởng thức đ&ecirc;m nhạc Quang l&ecirc; trong kh&ocirc;ng gian ấm &aacute;p, sang trọng v&agrave; sự phục vụ chu đ&aacute;o.</strong></p>

<p><strong>Quang L&ecirc;</strong>&nbsp;sinh ra tại Huế, trong gia đ&igrave;nh gồm 6 anh em v&agrave; một người chị nu&ocirc;i, Quang L&ecirc; l&agrave; con thứ 3 trong gia đ&igrave;nh.</p>

<p>Đầu những năm 1990, Quang L&ecirc; theo gia đ&igrave;nh sang định cư tại bang Missouri, Mỹ. hiện nay Quang L&ecirc; sống c&ugrave;ng gia đ&igrave;nh ở Los Angeles, nhưng vẫn thường xuy&ecirc;n về Việt Nam biểu diễn.</p>
', 1, 3, 7, NULL, N'2013-07-19 12:44:08')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (11, N'Đêm nhạc Nữ danh ca Ý Lan', N'~/Content/Upload/y-lan-61.jpg', N'Ý Lan', N'2013-07-26 20:00:00', N'<p><strong>&Yacute; Lan</strong>&nbsp;t&ecirc;n thật l&agrave; L&ecirc; Thị &Yacute; Lan, sinh ng&agrave;y 1/1/1958 tại S&agrave;i G&ograve;n. Do sinh trưởng trong một gia đ&igrave;nh nghệ thuật, bố l&agrave; t&agrave;i tử L&ecirc; Quỳnh, mẹ l&agrave; danh ca Th&aacute;i Thanh, n&ecirc;n niềm đam m&ecirc; ca h&aacute;t của &Yacute; Lan được h&igrave;nh th&agrave;nh từ nhỏ.</p>

<p>Gần 20 năm ca h&aacute;t, &Yacute; Lan chinh phục được nhiều đối tượng người nghe kh&ocirc;ng chỉ bằng chất giọng truyền cảm m&agrave; c&ograve;n ở phong c&aacute;ch điệu nghệ tr&ecirc;n s&acirc;n khấu. Chị được đ&aacute;nh gi&aacute; l&agrave; một trong những t&ecirc;n tuổi lớn của l&agrave;ng nhạc hải ngoại hiện nay.</p>

<p>Trong album Khi t&ocirc;i về h&aacute;t nhạc Phạm Duy, &Yacute; Lan được t&aacute;c giả khen ngợi l&agrave; thế hệ tiếp nối thể hiện th&agrave;nh c&ocirc;ng c&aacute;c s&aacute;ng t&aacute;c của &ocirc;ng, sau nữ danh ca Th&aacute;i Thanh.</p>

<p>Ngo&agrave;i Phạm Duy, t&ecirc;n &Yacute; Lan c&ograve;n gắn liền với d&ograve;ng nhạc của c&aacute;c t&aacute;c giả: Trịnh C&ocirc;ng Sơn, Ng&ocirc; Thụy Mi&ecirc;n, Vũ Th&agrave;nh An, Đức Huy, Từ C&ocirc;ng Phụng, Diệu Hương... Chị đ&atilde; ph&aacute;t h&agrave;nh được 60 album trong sự nghiệp ca h&aacute;t của m&igrave;nh.</p>

<p><strong>Đặc biệt tối 26 -27/07/2013 tại Ph&ograve;ng Tr&agrave; We sẽ tổ chức Đ&ecirc;m nhạc &Yacute; Lan v&agrave;o l&uacute;c 20h30 trong kh&ocirc;ng gian tho&aacute;ng m&aacute;t, sang trọng v&agrave; sự phục vụ chu đ&aacute;o.</strong></p>
', 1, 3, 7, NULL, N'2013-07-19 12:44:00')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (12, N'Đêm Ca nhạc đặc biệt "Xoa dịu nổi đau"', N'~/Content/Upload/27-07-500.png', N'Nhiều nghệ sỹ', N'2013-07-27 20:00:00', N'<p>&nbsp;</p>

<p>&Acirc;m nhạc mang nhiều th&ocirc;ng điệp cho cuộc sống, sự sẻ chia, niềm hạnh ph&uacute;c, nỗi c&ocirc; đơn hay thất vọng,... &Acirc;m nhạc xoa dịu t&acirc;m hồn con người v&agrave; gi&uacute;p h&agrave;n gắn những vết thương l&ograve;ng. Quan trọng hơn, &acirc;m nhạc kết nối mọi tấm l&ograve;ng, cho ch&uacute;ng ta những gi&acirc;y ph&uacute;t lắng đọng trong thế giới ri&ecirc;ng của m&igrave;nh. V&igrave; những điều đ&oacute; m&agrave; ph&ograve;ng tr&agrave; Nam Quang ra đời để mang lại những khoảnh khắc &acirc;m nhạc sống động.</p>

<p><strong>Đến với Ph&ograve;ng tr&agrave; Nam Quang tối 27/07 để thưởng thức Đ&ecirc;m Ca nhạc đặc biệt &quot; Xoa dịu nổi đau &quot;&nbsp;c&ugrave;ng với sự tham gia đặc biệt c&aacute;c ca sĩ: Lệ Quy&ecirc;n, Văn Mai Hương, Th&uacute;</strong><strong>y Trang, L&ecirc; Hiếu, Nguyễn Minh Sang, Noo Phước Thịnh, Song Lu&acirc;n, Hồ Kim, Xu&acirc;n Nghi, Nguyễn Hồng &Acirc;n,&nbsp;trong kh&ocirc;ng gian ấm &aacute;p, sang trọng v&agrave; sự phục vụ chu đ&aacute;o.</strong></p>
', 1, 3, 8, NULL, N'2013-07-19 12:48:14')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (13, N'Đêm liveshow Đàm Vĩnh Hưng', N'~/Content/Upload/02-08.png', N'Nhiều nghệ sỹ', N'2013-08-02 20:00:00', NULL, 1, 3, 8, N'2013-07-19 12:46:06', N'2013-07-19 12:46:06')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (14, N'Đêm nhạc Uyên Linh', N'~/Content/Upload/15186f86f5665c.img.jpg', N'Uyên Linh', N'2013-08-03 20:00:00', N'<p><strong>Trần Nguyễn Uy&ecirc;n Linh</strong>&nbsp;(sinh năm 1988) l&agrave; một nữ ca sĩ người Việt Nam, người chiến thắng danh hiệu Vietnam Idol 2010 trước Văn Mai Hương v&agrave;o ng&agrave;y 25 th&aacute;ng 12 năm 2010.</p>

<p>Thế mạnh của Uy&ecirc;n Linh l&agrave; những ca kh&uacute;c pop tr&agrave;n đầy cảm x&uacute;c v&agrave; trải nghiệm s&acirc;u lắng. Với thẩm mỹ v&agrave; t&acirc;m hồn &acirc;m nhạc ri&ecirc;ng của m&igrave;nh, Uy&ecirc;n Linh đ&atilde; l&agrave;m sống lại nhiều ca kh&uacute;c cũ, từng đ&oacute;ng đinh với những t&ecirc;n tuổi gạo cội, theo c&aacute;ch rất ri&ecirc;ng.</p>

<p>C&ocirc; từng l&agrave; học sinh của trường THPT chuy&ecirc;n L&ecirc; Hồng Phong Th&agrave;nh phố Hồ Ch&iacute; Minh v&agrave; l&agrave; sinh vi&ecirc;n Học viện Ngoại giao H&agrave; Nội. Năm 2008, c&ocirc; đ&atilde; dự thi Vietnam Idol m&ugrave;a thứ 2 nhưng kh&ocirc;ng v&agrave;o được top 100. Uy&ecirc;n Linh cũng từng lọt v&agrave;o v&ograve;ng chung kết Sao Mai 2009 khu vực miền Bắc nhưng bị loại v&agrave; gi&agrave;nh được một số giải thưởng lớn nhỏ d&agrave;nh cho sinh vi&ecirc;n.</p>

<p>Uy&ecirc;n Linh từng đại diện Học viện quan hệ quốc tế (nay l&agrave; Học viện ngoại giao) dự thi chương tr&igrave;nh &ldquo;Giọng h&aacute;t v&agrave;ng - Soul of Melody 2008&rdquo; v&agrave; gi&agrave;nh giải đặc biệt. Uy&ecirc;n Linh chiến thằng nhờ giọng h&aacute;t trong trẻo, xử l&yacute; kỹ thuật tốt v&agrave; phong c&aacute;ch biểu diễn rất tự nhi&ecirc;n với ca kh&uacute;c Dệt tầm gai v&agrave; A woman&rsquo;s worth, c&ocirc; cũng l&agrave; th&iacute; sinh duy nhất trong đ&ecirc;m chung kết tr&igrave;nh b&agrave;y ca kh&uacute;c nước ngo&agrave;i. Uy&ecirc;n Linh cũng đoạt giải đặc biệt cuộc thi Let&#39;s Get Loud 2008 với ca kh&uacute;c Saving all my love for you.</p>

<p>Sau cuộc thi Vietnam Idol 2010, qu&aacute;n qu&acirc;n Uy&ecirc;n Linh chỉ mới ph&aacute;t h&agrave;nh single ca kh&uacute;c C&aacute;m ơn t&igrave;nh y&ecirc;u v&agrave; đ&atilde; im hơi lặng tiếng trong một thời gian d&agrave;i.</p>
', 1, 3, 7, N'2013-07-19 12:49:23', N'2013-07-19 12:49:23')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (15, N'Chương trình ca nhạc CÂU CHUYỆN TÌNH YÊU', N'~/Content/Upload/03-08-500-2.png', N'Nhiều nghệ sỹ', N'2013-03-08 20:00:00', N'<p><strong><strong>Đến với Ph&ograve;ng tr&agrave; Nam Quang để thưởng thức Chương tr&igrave;nh ca nhạc C&Acirc;U CHUYỆN T&Igrave;NH Y&Ecirc;U chủ đề th&aacute;ng 8 &quot; Elvis Phương - Anh c&ograve;n nợ em&quot;. C&ugrave;ng tham gia chương tr&igrave;nh l&agrave; nam ca sĩ hải ngoại Anh Khoa.</strong></strong></p>

<p><strong>Ngo&agrave;i ra Đ&ecirc;m nhạc c&ograve;n c&oacute; sự g&oacute;p mặt đặc biệt của c&aacute;c ngh&ecirc; sĩ: Thanh Quốc, Thu Trang, Ban nhạc L&yacute; Được....</strong></p>
', 1, 3, 8, N'2013-07-19 12:51:56', N'2013-07-19 12:51:56')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (16, N'Đêm nhạc Lam Phương-Ngô Thụy Miên-Từ Công Phụng', N'~/Content/Upload/abc.jpg', N'Lam Phương-Ngô Thụy Miên-Từ Công Phụng', N'2013-07-21 20:00:00', N'<p><strong>Đến với Ph&ograve;ng tr&agrave; WE tối 21/07 để thưởng thức Đ&ecirc;m nhạc Lam Phương - Ng&ocirc; Thụy Mi&ecirc;n - Từ C&ocirc;ng Phụng với sự tham gia của c&aacute;c ca sĩ ph&ograve;ng tr&agrave;: Trọng Bắc, Hương Giang, Đức Minh, H&agrave; V&acirc;n, Phạm Phương, Vũ Đức Phước, Tiến Vinh, Ho&agrave;ng Nguy&ecirc;n, Minh Thảo, trong kh&ocirc;ng gian tho&aacute;ng m&aacute;t, sang trọng v&agrave; sự phục vụ chu đ&aacute;o.</strong></p>

<p><strong>Nhạc Sĩ Lam Phương</strong></p>

<p>Trong nền &acirc;m nhạc Việt Nam, c&oacute; lẽ hiếm nhạc sĩ n&agrave;o c&oacute; phong c&aacute;ch s&aacute;ng t&aacute;c đa dạng như Nhạc sĩ Lam Phương, từ những ca kh&uacute;c &ldquo;b&igrave;nh d&acirc;n&rdquo; cho đến nhạc l&iacute;nh, t&igrave;nh ca, qu&ecirc; hương cho đến d&ograve;ng nhạc c&oacute; t&iacute;nh sang cả như c&aacute;c ca kh&uacute;c: Cỏ &Uacute;a, Ph&uacute;t Cuối, Mưa Lệ&hellip;</p>

<p>Nếu d&ograve;ng nhạc Lam Phương dễ d&agrave;ng h&ograve;a nhập v&agrave;o l&ograve;ng người bởi những ng&ocirc;n từ đơn sơ, đầy cảm x&uacute;c v&agrave; những giai điệu &ecirc;m &aacute;i trữ t&igrave;nh th&igrave; c&aacute; nh&acirc;n người nhạc sĩ t&agrave;i hoa n&agrave;y cũng dễ d&agrave;ng chiếm trọn cảm t&igrave;nh mọi giới bằng một nụ cười đ&ocirc;n hậu v&agrave; một giọng n&oacute;i nhỏ nhẹ ch&acirc;n t&igrave;nh. R&otilde; r&agrave;ng l&agrave; c&oacute; một sự tương đồng nhất định giữa c&aacute;c ca kh&uacute;c v&agrave; nhạc sĩ. Mỗi ca kh&uacute;c đ&atilde; chiếu rọi v&agrave;o một phần nhỏ trong đời sống của ch&iacute;nh t&aacute;c giả.</p>

<p>Đời sống của Lam Phương trải qua nhiều nỗi cơ cực v&agrave; l&agrave; một tấm gương phấn đấu kh&ocirc;ng mỏi mệt. V&agrave; c&oacute; lẽ v&igrave; đ&atilde; nếm nhiều gian nan n&ecirc;n nhạc sĩ đ&atilde; th&agrave;nh c&ocirc;ng rất vinh quang trong sự nghiệp &acirc;m nhạc với tr&ecirc;n 200 nhạc phẩm thời danh trải d&agrave;i suốt hơn 50 năm s&aacute;ng t&aacute;c.</p>

<p><img src="http://vntic.vn/images/HinhAnh/Lichphongtra/DaVang/LamPhuong/nhacsilamphuong-thuy-nga-paris-102.jpg" style="border:none; height:348px; max-width:600px; width:450px" /></p>

<p><strong>Nhạc Sĩ Ng&ocirc; Thụy Mi&ecirc;n&nbsp;</strong>(1948 ) l&agrave; một nhạc sĩ Việt Nam nổi tiếng. L&agrave; t&aacute;c giả của những ca kh&uacute;c l&atilde;ng mạn &Aacute;o lụa H&agrave; Đ&ocirc;ng, Ri&ecirc;ng một g&oacute;c trời, Niệm kh&uacute;c cuối... Ng&ocirc; Thụy Mi&ecirc;n được xem như một trong những nhạc sĩ lớn của miền Nam trước 1975 v&agrave; ở hải ngoại về sau.</p>

<p><img src="http://2.bp.blogspot.com/-CS4Q3k5v6iU/UH1HARF2vbI/AAAAAAAAGBA/g9FKv5rdHbc/s1600/dsc_0010.jpg" style="border:none; height:336px; max-width:600px; width:500px" /></p>
', 1, 3, 7, NULL, N'2013-07-19 13:17:13')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (17, N'Đêm nhạc Văn Cao - Phạm Duy - Trịnh Công Sơn', NULL, N'Nhiều nghệ sỹ', N'2013-07-21 19:00:00', N'<p><strong>Ng&agrave;y 21/07/2013, tại ph&ograve;ng tr&agrave; Tiếng Xưa sẽ diễn ra Đ&ecirc;m nhạc Văn Cao - Phạm Duy - Trịnh C&ocirc;ng Sơn - Đỗ Lệ - Ng&ocirc; Thụy Mi&ecirc;n</strong><strong>&nbsp;với sự tham gia của c&aacute;c Ca sĩ: Nguyễn Huỳnh, Ana Long, Thanh Tr&uacute;c, Thanh Vinh, Lina Nguyễn, Quang Trường, V&acirc;n Anh, Y&ecirc;n Chi, Vũ Xu&acirc;n H&ugrave;ng, Nhật Nam, Hồng V&acirc;n, trong một kh&ocirc;ng gian ấm &aacute;p, sang trọng v&agrave; sự phục vụ chu đ&aacute;o.</strong></p>
', 1, 3, 5, N'2013-07-19 13:25:31', N'2013-07-19 13:25:31')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (18, N'Đêm nhạc Live show Cẩm Vân - Khắc Triệu', N'~/Content/Upload/20-07.png', N'Cẩm Vân - Khắc Triệu', N'2013-07-20 20:00:00', N'<p>&Acirc;m nhạc mang nhiều th&ocirc;ng điệp cho cuộc sống, sự sẻ chia, niềm hạnh ph&uacute;c, nỗi c&ocirc; đơn hay thất vọng,... &Acirc;m nhạc xoa dịu t&acirc;m hồn con người v&agrave; gi&uacute;p h&agrave;n gắn những vết thương l&ograve;ng. Quan trọng hơn, &acirc;m nhạc kết nối mọi tấm l&ograve;ng, cho ch&uacute;ng ta những gi&acirc;y ph&uacute;t lắng đọng trong thế giới ri&ecirc;ng của m&igrave;nh. V&igrave; những điều đ&oacute; m&agrave; ph&ograve;ng tr&agrave; Nam Quang ra đời để mang lại những khoảnh khắc &acirc;m nhạc sống động.</p>

<p><strong>Đến với ph&ograve;ng tr&agrave; Nam Quang tối 20/07 để thưởng thức Đ&ecirc;m nhạc Cẩm V&acirc;n - Khắc Triệu trong kh&ocirc;ng gian tho&aacute;ng m&aacute;t, sang trọng v&agrave; sự phục vụ chu đ&aacute;o.</strong></p>
', 1, 3, 8, N'2013-07-19 13:27:03', N'2013-07-19 13:27:03')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (19, N'Đêm nhac Lam Trường', N'~/Content/Upload/1372049457----5-.jpg', N'Nhiều nghệ sỹ', N'2013-07-20 20:00:00', N'<p><strong>Đến với Ph&ograve;ng tr&agrave; Điểm hẹn S&agrave;i G&ograve;n để thưởng thức Đ&ecirc;m nhạc Lam Trường trong kh&ocirc;ng gian tho&aacute;ng m&aacute;t, sang trọng v&agrave; sự phục vụ chu đ&aacute;o.</strong></p>

<p>Lam Trường y&ecirc;u th&iacute;ch ca h&aacute;t từ nhỏ. Được anh trai Lam Th&ocirc;ng, một sinh vi&ecirc;n thanh nhạc Nhạc viện TPHCM khuyến kh&iacute;ch, Lam Trường t&iacute;ch cực tham gia c&aacute;c hoạt động văn nghệ ở trường phổ th&ocirc;ng v&agrave; sau khi tốt nghiệp cấp III, anh thi v&agrave;o trường Cao đẳng Văn ho&aacute; Nghệ thuật TPHCM.</p>

<p><em>Ngo&agrave;i ra đ&ecirc;m diễn c&ograve;n c&oacute; sự g&oacute;p mặt của c&aacute;c ca sĩ: Nh&oacute;m Apo, Trần Phương, Thu Trang, H&agrave;i Thanh T&ugrave;ng, Như Quỳnh The Voice, Minh Thư.</em></p>
', 1, 3, 5, N'2013-07-19 13:33:45', N'2013-07-19 13:33:45')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (20, N'Đêm nhạc Lệ Quyên', N'~/Content/Upload/LeQuyen.jpg', N'Lệ Quyên, DJ Nữ & Người mẫu xinh đẹp', N'2013-07-20 20:00:00', N'<p>hịp sống th&igrave; vội v&atilde; &aacute;p lực c&ocirc;ng việc h&agrave;ng ng&agrave;y cứ đ&egrave; nặng, đến đ&acirc;y bạn kh&ocirc;ng những đ&aacute;nh tan cảm gi&aacute;c mệt m&otilde;i, căng thẳng m&agrave; c&ograve;n xoa dịu đi l&ograve;ng người lo toan bộn bề của cuộc sống để nhận sự tuyệt vời kh&ocirc;ng đ&acirc;u s&aacute;nh được.</p>

<p>MTV caf&eacute; c&oacute; nhiều kh&ocirc;ng gian cho bạn nhiều cơ hội lựa chọn vị tr&iacute; ph&ugrave; hợp, đ&acirc;y l&agrave; điểm đến ph&ugrave; hợp cho mọi tầng lớp, k&egrave;m với kh&ocirc;ng gian sang trọng đ&oacute; ch&iacute;nh l&agrave; sự nhiệt t&igrave;nh của đội ngũ nh&acirc;n vi&ecirc;n đ&atilde; qua huấn luyện chu đ&aacute;o sẽ lu&ocirc;n mang lại sự h&agrave;i l&ograve;ng cho bạn.</p>

<p><strong>Đến Với tối 20/07/2013 Đ&ecirc;m nhạc Lệ Quy&ecirc;n Ph&ograve;ng Tr&agrave; MTV qu&yacute; kh&aacute;ch sẽ được thưởng thức &acirc;m nhạc trong một kh&ocirc;ng gian sang trọng.</strong></p>
', 1, 3, 5, N'2013-07-19 13:35:22', N'2013-07-19 13:35:22')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (21, N'Đêm Gala Hài 19/07', N'~/Content/Upload/kimhoang-116.jpg', N'Nhiều nghệ sỹ', N'2013-07-20 20:00:00', N'<p>Được x&acirc;y dựng ngay vị tr&iacute; trung t&acirc;m th&agrave;nh phố, g&oacute;c ng&atilde; tư đường 3-2 (230 đường 3-2, P12 Q10 - Cao Thắng v&agrave; đầu chợ đ&ecirc;m Kỳ H&ograve;a n&ecirc;n Điểm hẹn S&agrave;i G&ograve;n rất thuận tiện, dễ thu h&uacute;t kh&aacute;ch. Ngay từ khi bước v&agrave;o Điểm hẹn S&agrave;i G&ograve;n, bạn sẽ bị cuốn h&uacute;t bởi phong c&aacute;ch ấn tượng trong việc thiết kế với nhiều m&agrave;u sắc được kết hợp h&agrave;i h&ograve;a mang phong c&aacute;ch hiện đại. D&agrave;n &acirc;m thanh, &aacute;nh s&aacute;ng được thiết kế, lắp đặt bởi những chuy&ecirc;n vi&ecirc;n Singapore, n&ecirc;n Điểm hẹn S&agrave;i G&ograve;n đ&atilde; định h&igrave;nh cho m&igrave;nh một phong c&aacute;ch rất ri&ecirc;ng biệt, kh&ocirc;ng trộn lẫn với những qu&aacute;n c&agrave; ph&ecirc; kh&aacute;c. Tầng trệt v&agrave; tầng thượng với kh&ocirc;ng gian kho&aacute;ng đ&atilde;ng th&iacute;ch hợp với giới trẻ. Tầng một c&oacute; nhiều khu ri&ecirc;ng biệt, chia cắt bởi những tấm gỗ trang tr&iacute; xinh xắn được trang bị to&agrave;n bộ m&aacute;y lạnh n&ecirc;n đ&acirc;y l&agrave; nơi thực kh&aacute;ch c&oacute; thể t&igrave;m cho m&igrave;nh một vị tr&iacute; để thư gi&atilde;n sau những giờ l&agrave;m việc mệt mỏi, căng thẳng. Ph&ograve;ng tr&agrave; ca nhạc tại lầu hai h&agrave;ng đ&ecirc;m c&oacute; chương tr&igrave;nh chọn lọc với sự g&oacute;p mặt của c&aacute;c ng&ocirc;i sao ca nhạc, nh&oacute;m nhạc, nh&oacute;m h&agrave;i nổi tiếng c&ugrave;ng ban nhạc Saigon Boys.</p>

<p><strong>Đến với Ph&ograve;ng Tr&agrave; Điểm hẹn S&agrave;i G&ograve;n tối 19/07 để thưởng thức Đ&ecirc;m Gala H&agrave;i với sự tham gia của c&aacute;c nghệ sĩ: Nh&oacute;m Kitikids, H&agrave;i Hữu Phước, H&agrave;i Mai Sơn - Kiều Linh, H&agrave;i T&ugrave;ng Linh, H&agrave;i Vũ Thanh, Nh&oacute;m K3, H&agrave;i Bảo Khương, H&agrave;i Nguyễn Ch&iacute;nh - Dũng Nh&iacute;,</strong><strong>&nbsp;trong một kh&ocirc;ng gian tho&aacute;ng m&aacute;t, sang trọng v&agrave; sự phục vụ chu đ&aacute;o.</strong></p>

<p><img src="http://ngoisao.net/Files/Subject/3b/9d/2c/35/kieu-linh-mai-son-2.jpg" style="border:none; font-style:italic; height:394px; line-height:1.3em; max-width:600px; width:500px" /></p>

<p><em>H&agrave;i Mai Sơn - Kiều Linh</em></p>

<p><em><img src="http://tapchithoitrangtre.com.vn/wp-content/uploads/2012/06/kimhoang-116.jpg" style="border:none; height:340px; max-width:600px; width:500px" /></em></p>

<p><em>Nh&oacute;m Titikids</em></p>

<p><em>Ngo&agrave;i ra đ&ecirc;m nhạc c&ograve;n c&oacute; sự g&oacute;p mặt đặc biệt của c&aacute;c ngh&ecirc; sĩ: H&agrave;i Hữu Phước, H&agrave;i T&ugrave;ng Linh, H&agrave;i Vũ Thanh, Nh&oacute;m K3, H&agrave;i Bảo Khương, H&agrave;i Nguyễn Ch&iacute;nh - Dũng Nh&iacute;.</em></p>
', 1, 1, 10, N'2013-07-19 13:38:06', N'2013-07-19 13:38:06')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (22, N'Đêm nhạc Thần tượng', N'~/Content/Upload/timthumb.jpg', N'Nhiều nghệ sỹ', N'2013-07-19 20:00:00', N'<p><strong>Đến với Ph&ograve;ng tr&agrave; We để thưởng thức Đ&ecirc;m nhạc Thần tượng Khởi My - Đ&ocirc;ng Nhi - &Ocirc;ng Cao Thắng - Ho&agrave;ng Quy&ecirc;n - Tr&uacute;c Nh&acirc;n - Đ&agrave;o B&aacute; Lộc &amp; Dustin MC&nbsp;trong kh&ocirc;ng gian tho&aacute;ng m&aacute;t, sang trọng.</strong></p>

<p><strong><img src="http://img2.news.zing.vn/2013/04/17/1-20.jpg" style="border:none; height:333px; max-width:600px; width:500px" /></strong></p>

<p><em>Đ&ocirc;ng Nhi - &Ocirc;ng Cao Thắng</em></p>

<p><em><img src="http://www.netlife.vn/images/2012/12/27034008-Hoang-Quyen-Idol.jpg" style="border:none; height:750px; max-width:600px; width:500px" /></em></p>

<p><em>Ho&agrave;ng Quy&ecirc;n</em></p>

<p><em><img src="http://img.webphunu.net/sites/default/files/top-8-the-voice-7.JPG" style="border:none; height:751px; max-width:600px; width:500px" /></em></p>

<p><em>Tr&uacute;c Nh&acirc;n</em></p>

<p><em><img src="http://img2.news.zing.vn/2013/04/18/foto-duy-england-64.jpg" style="border:none; height:750px; max-width:600px; width:500px" /></em></p>

<p><em>Khởi My</em></p>
', 1, 3, 7, N'2013-07-19 13:39:52', N'2013-07-19 13:39:52')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (23, N'Đêm nhạc Hiền Thục', N'~/Content/Upload/timthumb (1).jpg', N'Nhiều nghệ sỹ', N'2013-07-19 20:00:00', N'<p><strong>Hiền Thục</strong>&nbsp;sinh ra trong một gia đ&igrave;nh lao động nhưng v&igrave; l&agrave; con g&aacute;i &uacute;t n&ecirc;n được mọi người cưng chiều. Bắt đầu h&aacute;t l&uacute;c 8 tuổi ở Đội Sơn Ca Nh&agrave; Thiếu Nhi Quận 1. Thi đậu v&agrave;o lớp trung cấp thanh nhạc Nhạc viện Tp.HCM, từng cộng t&aacute;c với Trung t&acirc;m Nhạc nhẹ Th&agrave;nh phố Hồ Ch&iacute; Minh.</p>

<p><img src="http://l1.yimg.com/bt/api/res/1.2/r5NeZPGpV2_AJSwqmk_O4w--/YXBwaWQ9eW5ld3M7cT04NTt3PTQwMA--/http://media.zenfs.com/vi_VN/News/ngoisao/Hi%e1%bb%81n_Th%e1%bb%a5c_m%e1%ba%b7c_%c3%a1o_d%c3%a0i-ee75b94f448060908263beb684ef0695" style="border:none; height:750px; max-width:600px; width:500px" /></p>

<p>Khả năng của Hiền Thục được ghi nhận bắt đầu từ khi c&ocirc; đoạt giải Giọng ca trẻ Ch&acirc;u &Aacute; v&agrave; Ca sĩ biểu diễn c&oacute; h&igrave;nh tượng đẹp nhất trong cuộc thi Giọng Ca Trẻ Ch&acirc;u &Aacute; tại Thượng Hải năm 1999.Sau CD Email T&igrave;nh Y&ecirc;u kh&aacute; th&agrave;nh c&ocirc;ng, Hiền Thục c&oacute; một khoảng thời gian tạm ngưng hoạt động &acirc;m nhạc. V&agrave;i năm sau đ&oacute;, c&ocirc; quay trở lại với một phong c&aacute;ch mới chững chạc v&agrave; trưởng th&agrave;nh hơn qua album VCD Hiền Thục vol.2 v&agrave; CD vol.3 Bảo. Giọng ca tốt, truyền cảm, cộng với phong c&aacute;ch trẻ trung, Hiền Thục l&agrave; một trong những ca sĩ được giới trẻ đặc biệt &aacute;i mộ</p>
', 1, 3, 11, N'2013-07-19 13:47:13', N'2013-07-19 13:47:13')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (24, N'Đêm nhạc Duy Mạnh', N'~/Content/Upload/DuyManh.jpg', N'Duy Mạnh', N'2013-07-19 14:00:00', N'<p>&Acirc;m nhạc mang nhiều th&ocirc;ng điệp cho cuộc sống của ch&uacute;ng ta. Sự chia sẻ, niềm hạnh ph&uacute;c, sự c&ocirc; đơn, thất vọng, khổ đau ... &Acirc;m nhạc xoa dịu t&acirc;m hồn ch&ugrave;ng ta. &Acirc;m nhạc h&agrave;n gắn những vết thương, ấm nhạc kết nối những tấm l&ograve;ng, &Acirc;m nhạc cho ch&uacute;ng ta những gi&acirc;y ph&uacute;t lắng đọng trong thế giới ri&ecirc;ng của m&igrave;nh, ch&iacute;nh v&igrave; những điều đ&oacute; m&agrave; ph&ograve;ng tr&agrave; ca nhạc KH&Ocirc;NG T&Ecirc;N đ&atilde; ra đời để mang lại cho qu&yacute; vị những khoảnh khắc &acirc;m nhạc.</p>

<p>Thật đặc biệt, h&atilde;y đến với ch&uacute;ng t&ocirc;i để c&ugrave;ng chia sẻ, c&ugrave;ng đắm m&igrave;nh trong kh&ocirc;ng gian &acirc;m nhạc để qu&ecirc;n đi những muộn phiền, lo &acirc;u của Cuộc sống h&agrave;ng ng&agrave;y b&ecirc;n những người th&acirc;n y&ecirc;u của m&igrave;nh.</p>

<p>Một lần nữa h&atilde;y đến với ph&ograve;nh tr&agrave; KH&Ocirc;NG T&Ecirc;N v&agrave; ra về với những giai điệu thật đẹp đẽ sẽ đi v&agrave;o giấc ngủ của qu&yacute; vị, để bắt đầu một ng&agrave;y mới, Một t&igrave;nh y&ecirc;u mới v&agrave; ch&uacute;ng t&ocirc;i tạm gọi khoảnh khắc đ&oacute; l&agrave; khoảnh khắc KH&Ocirc;NG T&Ecirc;N.</p>

<p><strong>Đến với Ph&ograve;ng Tr&agrave; Kh&ocirc;ng T&ecirc;n đ&ecirc;m 19/07/2013, qu&yacute; vị sẽ được thưởng thức Đ&ecirc;m nhạc Duy Mạnh trong kh&ocirc;ng gian ấm &aacute;p, sang trọng v&agrave; sự phục vụ chu đ&aacute;o.</strong></p>
', 1, 3, 12, NULL, N'2013-07-19 14:38:13')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (25, N'Liveshow Sương Thu: Sự trở lại của Hồ Quỳnh Hương', N'~/Content/Upload/liveshow-suong-thu-ho-quynh-huong.jpg', N'Hồ Quỳnh Hương', N'2013-08-09 20:00:00', N'<p>2 năm tĩnh lặng trong &acirc;m nhạc, nữ ca sỹ Hồ Quỳnh Hương trở lại với một phong c&aacute;ch mới, &ldquo;quyến rũ v&agrave; nhẹ nh&agrave;ng&rdquo;.</p>

<p>Xuất hiện trong liveshow Sương thu, Hồ Quỳnh Hương tiếp tục mang lại cho kh&aacute;n giả những b&agrave;i h&aacute;t một thời l&agrave;m n&ecirc;n t&ecirc;n tuổi nữ ca sỹ. Kh&aacute;n giả thưởng thức sự da diết, nồng ấm của &ldquo;Anh&rdquo;, t&igrave;nh cảm thổn thức của c&ocirc; g&aacute;i đang y&ecirc;u trong &ldquo;Em nhớ anh v&ocirc; c&ugrave;ng&rdquo;, sự s&ocirc;i động, hoang d&atilde; của &ldquo;Vũ điệu hoang d&atilde;&rdquo;,&hellip;</p>

<p>Trong đ&ecirc;m nhạc Sương thu, sự g&oacute;p mặt của ca sĩ Hồ Trung Dũng với ca kh&uacute;c &ldquo;C&ograve;n lại g&igrave; khi anh vắng em, Lại gần h&ocirc;n anh, Nếu c&oacute; y&ecirc;u t&ocirc;i, xin gọi t&ecirc;n nhau, Cry me a river&rdquo;,&hellip;đem lại m&agrave;u sắc &acirc;m nhạc mới.</p>

<p>&nbsp;</p>

<p>Sở hữu chất giọng kh&agrave;n ấm, Đinh Mạnh Ninh lu&ocirc;n h&uacute;t được kh&aacute;n gải trẻ bởi vẻ ph&oacute;ng kho&aacute;ng, th&acirc;n thiện, h&ograve;a đồng của m&igrave;nh. C&aacute;c ca kh&uacute;c Đinh Mạnh Ninh sẽ mang tới kh&aacute;n giả một đ&ecirc;m nhạc s&ocirc;i động, trẻ trung.</p>

<p>&nbsp;</p>

<p>Đ&ecirc;m Sương thu, kh&aacute;n giả được gặp lại c&ocirc; n&agrave;ng Bảo Tr&acirc;m Idol &ndash; người được Quốc Trung đ&aacute;nh gi&aacute; c&oacute; khả năng xử l&yacute; &acirc;m nhạc th&ocirc;ng minh.</p>

<p>&nbsp;</p>

<p><strong>Liveshow Sương thu</strong>&nbsp;sẽ diễn ra v&agrave;o 20h, ng&agrave;y 9 th&aacute;ng 8 tại Nh&agrave; h&aacute;t Lớn.</p>
', 0, 3, 14, NULL, N'2013-07-19 15:02:33')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (26, N'Đêm nhạc - Ca sỹ hải ngoại Nguyễn Hưng', N'~/Content/Upload/csnguyenhung.jpg', N'Nguyễn Hưng', N'2013-08-24 20:00:00', N'<p><strong>Đến với ph&ograve;ng tr&agrave; WE ng&agrave;y 24/08</strong>, c&aacute;c bạn sẽ được thưởng thức giọng ca của nam ca sỹ nổi tiếng Nguyễn Hưng.</p>

<p><strong>Nguyễn Hưng&nbsp;</strong>l&agrave; con của vũ sư &Aacute;nh Tuyết, nổi tiếng từ đầu thập ni&ecirc;n 60 tại Việt Nam với lớp huấn luyện khi&ecirc;u vũ v&agrave; vũ d&acirc;n tộc. B&agrave; đ&atilde; c&oacute; c&ocirc;ng đ&agrave;o tạo nhiều vũ sư t&agrave;i giỏi cho đến những ng&agrave;y cuối th&aacute;ng 4 năm 1975. Trong số đ&oacute; c&oacute; người con trai &uacute;t của b&agrave; l&agrave; Nguyễn Hưng, từng đoạt giải Kim Kh&aacute;nh về khi&ecirc;u vũ do nhật b&aacute;o Trắng Đen tổ chức v&agrave;o năm 1972 với thể điệu Cha Cha Cha khi mới l&ecirc;n 17 tuổi. Nguyễn Hưng đến với ca nhạc kh&ocirc;ng bằng giọng h&aacute;t của m&igrave;nh m&agrave; với bộ trống, một nhạc cụ anh rất m&ecirc; th&iacute;ch được mẹ anh mua cho. Với bộ trống đầu ti&ecirc;n trong đời, Nguyễn Hưng với t&ecirc;n thật l&agrave; Nguyễn Từ Hưng đ&atilde; gia nhập ban nhạc trẻ The Radiations đi tr&igrave;nh diễn nhiều nơi trong suốt 2 năm.</p>

<p>Trong biến cố th&aacute;ng 4 năm 1975, Nguyễn Hưng từng cộng t&aacute;c với một số đo&agrave;n h&aacute;t như đo&agrave;n xiếc Độc Lập, B&ocirc;ng Sen... c&ugrave;ng với một số vũ trường ở S&agrave;ig&ograve;n v&igrave; chưa hề c&oacute; một căn bản n&agrave;o về thanh nhạc. Một thời gian ngắn sau anh được gi&aacute;o sư Duy T&acirc;n chỉ dẫn v&agrave; khi qua đo&agrave;n B&ocirc;ng Sen 2, anh cũng như tất cả diễn vi&ecirc;n kh&aacute;c đ&atilde; được theo học những kh&oacute;a luyện thanh v&agrave; nhạc l&yacute;. Nhờ v&agrave;o đ&oacute; anh đ&atilde; c&oacute; được một mớ h&agrave;nh trang để đến với sinh hoạt ca nhạc sau n&agrave;y. Cho đến khoảng năm 1982 - 1983, Nguyễn Hưng trở lại với nghề dạy khi&ecirc;u vũ.</p>

<p>Nguyễn Hưng đặt ch&acirc;n đến Toronto, Canada v&agrave;o năm 1992 do sự bảo l&atilde;nh của người vợ sang đ&acirc;y từ trước l&agrave; Thục Hiền. V&agrave;o năm 1994, trong một dịp sang Toronto tr&igrave;nh diễn, nữ ca sĩ Phương Hồng Quế m&agrave; anh từng quen biết trước kia, đ&atilde; khuyến kh&iacute;ch Nguyễn Hưng sang Cali thăm d&ograve; t&igrave;nh h&igrave;nh v&igrave; đ&acirc;y c&oacute; nhiều cơ hội để ph&aacute;t triển ng&agrave;nh ca h&aacute;t. C&ugrave;ng với Phương Hồng Quế, Nguyễn Hưng sang Cali v&agrave; tham dự đ&ecirc;m ra mắt CD của nữ ca sĩ Phi Phi tại vũ trường Đ&ecirc;m M&agrave;u Hồng ở Nam Cali v&agrave;o th&aacute;ng 3 năm 1994. Đ&ecirc;m đ&oacute; anh đ&atilde; l&ecirc;n s&acirc;n khấu h&aacute;t gi&uacute;p vui 2 nhạc phẩm: &quot;Vết Th&ugrave; Tr&ecirc;n Lưng Ngựa Hoang&quot; v&agrave; &quot;Đưa Em v&agrave;o C&otilde;i Chết&quot; l&agrave; những nhạc phẩm từng được tr&igrave;nh b&agrave;y qua tiếng h&aacute;t Elvis Phương v&agrave; Th&aacute;i Ch&acirc;u cũng l&agrave; hai giọng anh rất ưa th&iacute;ch v&agrave; c&ocirc;ng nhận l&agrave; c&oacute; chịu phần n&agrave;o ảnh hưởng. Đ&ecirc;m đ&oacute; cũng c&oacute; mặt c&ocirc; T&ocirc; Thủy của trung t&acirc;m Th&uacute;y Nga v&agrave; c&ocirc; đ&atilde; mời anh hợp t&aacute;c, một điều anh kh&ocirc;ng ngờ tới. Hiện nay Nguyễn Hưng đang đầu tư thật nhiều v&agrave;o người con trai t&ecirc;n Nguyễn Hưng Long, cũng c&oacute; năng khiếu ca h&aacute;t v&agrave; khi&ecirc;u vũ giống như anh. V&agrave; anh cũng rất biết ơn người vợ của anh l&agrave; Thục Hiền, hiện đang điều h&agrave;nh một tiệm ăn ở Toronto.</p>
', 1, 3, 7, N'2013-07-19 14:44:10', N'2013-07-19 14:44:10')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (27, N'Đêm nhạc song ca Khánh Hà - Tuấn Ngọc', N'~/Content/Upload/tuanngoc.jpg', N'Khánh Hà - Tuấn Ngọc', N'2013-09-18 19:00:00', N'<p><strong>Đến với Ph&ograve;ng Tr&agrave; WE ng&agrave;y 10 &amp; 11/08/2013, bạn sẽ được thưởng thức những t&igrave;nh kh&uacute;c qua Đ&ecirc;m nhạc song ca Kh&aacute;nh H&agrave; - Tuấn Ngọc trong kh&ocirc;ng gian ấm &aacute;p, sang trọng tại ph&ograve;ng tr&agrave;.</strong></p>

<p>Ca sĩ Kh&aacute;nh H&agrave; t&ecirc;n thật l&agrave; L&atilde; Thị Kh&aacute;nh H&agrave;, sinh ng&agrave;y 28/3 tại Đ&agrave; Lạt. Kh&aacute;nh H&agrave; sở hữu giọng h&aacute;t sang trọng với kỹ thuật đi&ecirc;u luyện v&agrave; nhanh ch&oacute;ng trở th&agrave;nh t&ecirc;n tuổi được y&ecirc;u mến từ thập ni&ecirc;n 60. Với hơn 40 năm ca h&aacute;t, chị đ&atilde; chiếm trọn tr&aacute;i tim của kh&aacute;n giả y&ecirc;u nhạc ở trong v&agrave; ngo&agrave;i nước. Trong l&agrave;ng nhạc Việt, gia đ&igrave;nh ca sĩ Kh&aacute;nh H&agrave; kh&aacute; đặc biệt v&igrave; hầu hết anh chị em đều l&agrave; ca sĩ nổi tiếng như B&iacute;ch Chi&ecirc;u, Tuấn Ngọc, Lưu B&iacute;ch&hellip; &Ocirc;ng x&atilde; chị - ca sĩ T&ocirc; Chấn Phong cũng l&agrave; c&aacute;i t&ecirc;n gặt h&aacute;i kh&ocirc;ng &iacute;t th&agrave;nh c&ocirc;ng ở hải ngoại.</p>

<p>Kh&aacute;nh H&agrave; lập ban nhạc The Uptight khi chưa tr&ograve;n 20 tuổi c&ugrave;ng với B&iacute;ch Chi&ecirc;u, Lưu B&iacute;ch. Chị nổi tiếng với c&aacute;c ca kh&uacute;c nhạc nước ngo&agrave;i v&agrave; khi chuyển sang h&aacute;t nhạc Việt cũng mau ch&oacute;ng tạo tiếng vang.</p>

<p><img src="http://l.f9.img.vnexpress.net/2012/12/20/khanh-ha-3-jpg-1355971347_500x0.jpg" style="border:none; height:348px; max-width:600px; width:500px" /></p>

<p><em>Kh&aacute;nh H&agrave;</em></p>

<p>Tuấn Ngọc sinh ra trong một gia đ&igrave;nh nghệ sĩ. Cha của Tuấn Ngọc l&agrave; nghệ sĩ Lữ Li&ecirc;n, th&agrave;nh vi&ecirc;n ban nhạc h&agrave;i hước ATV. C&aacute;c anh chị em của Tuấn Ngọc đều l&agrave; những ca sĩ t&ecirc;n tuổi: B&iacute;ch Chi&ecirc;u, Anh T&uacute;, Kh&aacute;nh H&agrave;, Th&uacute;y Anh, Lan Anh, Lưu B&iacute;ch.Tuấn Ngọc đi h&aacute;t từ rất sớm. Từ khi l&ecirc;n 4 tuổi, anh đ&atilde; h&aacute;t trong những chương tr&igrave;nh thiếu nhi tr&ecirc;n đ&agrave;i ph&aacute;t thanh, c&ugrave;ng thời với những &quot;thần đồng&quot; Quốc Thắng v&agrave; Kim Chi. Thời gian sau đ&oacute; anh cộng t&aacute;c với chương tr&igrave;nh d&agrave;nh ri&ecirc;ng cho thiếu nhi của cặp nghệ sĩ Kiều Hạnh v&agrave; Phạm Đ&igrave;nh Sỹ. Năm 13 tuổi anh đ&atilde; theo ch&acirc;n c&aacute;c nghệ sĩ lớn tuổi đi h&aacute;t tại những c&acirc;u lạc bộ Mỹ, khi c&ograve;n trong thời k&igrave; thưa thớt tại S&agrave;i G&ograve;n.Tuấn Ngọc nổi tiếng qua những nhạc phẩm trữ t&igrave;nh. Với giọng ca v&agrave; c&aacute;ch diễn tả đặc biệt, anh gi&agrave;nh được sự đ&aacute;nh gi&aacute; cao của giới chuy&ecirc;n m&ocirc;n cũng như sự h&acirc;m mộ của c&ocirc;ng ch&uacute;ng y&ecirc;u nhạc. Những nhạc sĩ Ng&ocirc; Thụy Mi&ecirc;n, Vũ Th&agrave;nh An, Từ C&ocirc;ng Phụng... nhận x&eacute;t rằng giọng ca Tuấn Ngọc rất th&iacute;ch hợp với những s&aacute;ng t&aacute;c của họ. Trịnh C&ocirc;ng Sơn cũng xem Tuấn Ngọc l&agrave; giọng ca nam h&aacute;t những nhạc phẩm của &ocirc;ng th&agrave;nh c&ocirc;ng nhất.Tuấn Ngọc được nhiều người xem như một giọng ca nam &quot;tượng đ&agrave;i&quot; của nền t&acirc;n nhạc Việt Nam. &quot;Trường ph&aacute;i Tuấn Ngọc&quot; đ&atilde; ảnh hưởng tới nhiều ca sĩ thế hệ sau cả ở hải ngoại cũng như trong nước như Nguy&ecirc;n Khang, Trần Th&aacute;i H&ograve;a, Quang Dũng, Xu&acirc;n Ph&uacute;...Tuấn Ngọc th&agrave;nh h&ocirc;n với ca sĩ Th&aacute;i Thảo, con g&aacute;i nhạc sĩ Phạm Duy.</p>

<p><img src="http://vntic.vn/images/HinhAnh/Lichphongtra/WE/tuanngoc.jpg" style="border:none; height:600px; max-width:600px; width:435px" /></p>

<p><em>Ca sĩ Tuấn Ngọc</em></p>
', 1, 1, 7, N'2013-07-19 14:45:40', N'2013-07-19 14:45:40')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (28, N'Chương trình: Tiger International Event 2013', N'~/Content/Upload/247614_652514594775884_1462976379_n.jpg', N'Nhiều nghệ sỹ', N'2013-08-22 14:00:00', N'<p>Nối tiếp chuỗi&nbsp;<strong>sự kiện&nbsp;Tiger Translate &ndash; Battle of the Band 2013&nbsp;</strong>l&agrave; sự xuất hiện của&nbsp;<strong>Lacuna Coil,</strong>&nbsp;một những ban nhac Gothic Metal h&agrave;ng đầu thế giới hiện nay.&nbsp;Chắc hẳn người h&acirc;m mộ Rock tại th&agrave;nh phố Hồ Ch&iacute; Minh n&oacute;i ri&ecirc;ng v&agrave; khắp mọi miền tr&ecirc;n đất nước n&oacute;i chung đều đang rất h&aacute;o hức chờ ng&agrave;y cơn gi&oacute;<strong>&nbsp;Lacuna Coil từ nước &Yacute;&nbsp;</strong>xa x&ocirc;i cập bến Việt Nam.</p>

<p>Sự xuất hiện của<strong>&nbsp;Lacuna Coil tại Việt Nam&nbsp;</strong>lần n&agrave;y hứa hẹn sẽ đem lại nhiều trải nghiệm th&uacute; vị cho người h&acirc;m mộ nhạc rock nước nh&agrave;. H&atilde;y chuẩn bị sẵn tinh thần thưởng thức ở một đẳng cấp kh&aacute;c, đẳng cấp thế giới, tại khu&ocirc;n vi&ecirc;n Crescent Residence, Ph&uacute; Mỹ Hưng, Quận 7, TP HCM, ng&agrave;y 22&nbsp;th&aacute;ng 8&nbsp;tới.</p>

<p>&nbsp;</p>

<p><strong>Tiger International&nbsp;Event</strong>&nbsp;- Chương tr&igrave;nh quy tụ nhiều loại h&igrave;nh nghệ thuật đa dạng của c&aacute;c nghệ sỹ nổi tiếng sẽ diễn ra v&agrave;o l&uacute;c 17h00 ng&agrave;y 22/8&nbsp;tại khu&ocirc;n vi&ecirc;n Crescent Resident, quận 7, TP HCM. Lần đầu ti&ecirc;n một Rock Concert được tổ chức tại địa điểm n&agrave;y, c&oacute; sức chứa hơn 20.000 người</p>
', 1, 1, 17, N'2013-07-19 14:52:13', N'2013-07-19 14:52:13')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (29, N'Đêm nhạc ca sĩ Tuấn Hưng', N'~/Content/Upload/TuanHung.jpg', N'Tuấn Hưng', N'2013-07-28 20:00:00', N'<p>Với kh&iacute; trời gay gắt bạn cần một nơi để xả stress h&atilde;y đến với MTV caf&eacute; bạn sẽ cảm nhận được sự trong l&agrave;nh, dịu m&aacute;t tức khắc với kh&ocirc;ng gian kho&aacute;ng đ&atilde;ng h&ograve;a quyện b&ecirc;n những thức uống m&aacute;t lạnh đầy bổ dưỡng,nh&acirc;m nhi ly caf&eacute; v&agrave; c&ugrave;ng người y&ecirc;u thưởng thức những điệu nhạc &ecirc;m đềm b&ecirc;n cạnh người y&ecirc;u_MTV caf&eacute; thật sự l&agrave; điểm hẹn l&atilde;ng mạn.</p>

<p>Nhịp sống th&igrave; vội v&atilde; &aacute;p lực c&ocirc;ng việc h&agrave;ng ng&agrave;y cứ đ&egrave; nặng, đến đ&acirc;y bạn kh&ocirc;ng những đ&aacute;nh tan cảm gi&aacute;c mệt m&otilde;i, căng thẳng m&agrave; c&ograve;n xoa dịu đi l&ograve;ng người lo toan bộn bề của cuộc sống để nhận sự tuyệt vời kh&ocirc;ng đ&acirc;u s&aacute;nh được.</p>

<p><strong>Đến với ph&ograve;ng tr&agrave; MTV tối 28/07 để thưởng thức Đ&ecirc;m nhạc Tuấn Hưng trong kh&ocirc;ng gian tho&aacute;ng m&aacute;t, sang trọng v&agrave; sự phục vụ chu đ&aacute;o</strong></p>
', 1, 3, 11, N'2013-07-19 14:54:44', N'2013-07-19 14:54:44')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (30, N'Đêm nhạc Trả lại thời gian', N'~/Content/Upload/19-07-500.png', N'Nhiều nghệ sỹ', N'2013-07-19 14:00:00', N'<p>&Acirc;m nhạc mang nhiều th&ocirc;ng điệp cho cuộc sống, sự sẻ chia, niềm hạnh ph&uacute;c, nỗi c&ocirc; đơn hay thất vọng,... &Acirc;m nhạc xoa dịu t&acirc;m hồn con người v&agrave; gi&uacute;p h&agrave;n gắn những vết thương l&ograve;ng. Quan trọng hơn, &acirc;m nhạc kết nối mọi tấm l&ograve;ng, cho ch&uacute;ng ta những gi&acirc;y ph&uacute;t lắng đọng trong thế giới ri&ecirc;ng của m&igrave;nh. V&igrave; những điều đ&oacute; m&agrave; ph&ograve;ng tr&agrave; Nam Quang ra đời để mang lại những khoảnh khắc &acirc;m nhạc sống động.</p>

<p><strong>Đến với ph&ograve;ng tr&agrave; Nam Quang tối 19/07 để thưởng thức Đ&ecirc;m nhạc Trả lại thời gian&nbsp;với sự tham gia đặc biệt của c&aacute;c ngh&ecirc; sĩ: Ho&agrave;ng Đăng Khoa, H&agrave; V&acirc;n, Đo&agrave;n Thanh Sơn, H&agrave;i Thanh T&ugrave;ng - Phi Phụng - Thụy Mười, NSUT - Ca sĩ V&acirc;n Kh&aacute;nh, V&acirc;n Quang Long, Đ&ocirc;ng Đ&agrave;o,&nbsp;trong kh&ocirc;ng gian tho&aacute;ng m&aacute;t, sang trọng v&agrave; sự phục vụ chu đ&aacute;o.</strong></p>
', 1, 3, 8, N'2013-07-19 15:00:13', N'2013-07-19 15:00:13')
INSERT INTO [dbo].[Event] ([EventId], [EventName], [EventImage], [Artist], [HoldDate], [Description], [Status], [CategoryId], [VenueId], [CreatedDate], [ModifiedDate]) VALUES (31, N'Đêm nhạc "Như vẫn còn đây"', N'~/Content/Upload/21-07-500.png', N'Nhiều nghệ sỹ', N'2013-07-21 15:00:00', N'<p>&Acirc;m nhạc mang nhiều th&ocirc;ng điệp cho cuộc sống, sự sẻ chia, niềm hạnh ph&uacute;c, nỗi c&ocirc; đơn hay thất vọng,... &Acirc;m nhạc xoa dịu t&acirc;m hồn con người v&agrave; gi&uacute;p h&agrave;n gắn những vết thương l&ograve;ng. Quan trọng hơn, &acirc;m nhạc kết nối mọi tấm l&ograve;ng, cho ch&uacute;ng ta những gi&acirc;y ph&uacute;t lắng đọng trong thế giới ri&ecirc;ng của m&igrave;nh. V&igrave; những điều đ&oacute; m&agrave; ph&ograve;ng tr&agrave; Nam Quang ra đời để mang lại những khoảnh khắc &acirc;m nhạc sống động.</p>

<p><strong>Đến với ph&ograve;ng tr&agrave; Nam Quang tối 21/07 để thưởng thức Đ&ecirc;m nhạc &quot; Như vẫn c&ograve;n đ&acirc;y &quot;&nbsp;với sự tham gia đặc biệt của c&aacute;c ngh&ecirc; sĩ: Trường Sơn, Kim Thư, Nh&oacute;m Pha L&ecirc;, H&agrave;i Long Đẹp trai, Trường Giang, L&ecirc; Ho&agrave;ng, Tr&agrave; My Idol, Nam Cường, Hiền Thục,&nbsp;trong kh&ocirc;ng gian tho&aacute;ng m&aacute;t, sang trọng v&agrave; sự phục vụ chu đ&aacute;o.</strong></p>
', 1, 3, 8, N'2013-07-19 15:06:10', N'2013-07-19 15:06:10')
SET IDENTITY_INSERT [dbo].[Event] OFF

-----------user------------------
SET IDENTITY_INSERT [dbo].[User] ON
INSERT INTO [dbo].[User] ([UserId], [UserName], [FullName], [Email], [Phone], [Address], [Active], [IsVerified], [BankName], [BankAccount], [IdentityCard], [Sellable], [CreatedDate], [ModifiedDate], [ProvinceId]) VALUES (1, N'user1', NULL, N'user@gmail.com', N'0909999999', N'242 Tô ký', 1, 0, NULL, NULL, NULL, 1, N'2013-02-15 00:00:00', N'2013-02-15 00:00:00', 1)
INSERT INTO [dbo].[User] ([UserId], [UserName], [FullName], [Email], [Phone], [Address], [Active], [IsVerified], [BankName], [BankAccount], [IdentityCard], [Sellable], [CreatedDate], [ModifiedDate], [ProvinceId]) VALUES (2, N'user2', NULL, N'user@gmail.com', N'0909999999', N'242 Tô ký', 1, 0, NULL, NULL, NULL, 1, N'2013-02-15 00:00:00', N'2013-02-15 00:00:00', 2)
INSERT INTO [dbo].[User] ([UserId], [UserName], [FullName], [Email], [Phone], [Address], [Active], [IsVerified], [BankName], [BankAccount], [IdentityCard], [Sellable], [CreatedDate], [ModifiedDate], [ProvinceId]) VALUES (3, N'user3', NULL, N'user@gmail.com', N'0909999999', N'242 Tô ký', 1, 0, NULL, NULL, NULL, 0, N'2013-02-15 00:00:00', N'2013-02-15 00:00:00', 3)
INSERT INTO [dbo].[User] ([UserId], [UserName], [FullName], [Email], [Phone], [Address], [Active], [IsVerified], [BankName], [BankAccount], [IdentityCard], [Sellable], [CreatedDate], [ModifiedDate], [ProvinceId]) VALUES (4, N'user4', NULL, N'user@gmail.com', N'0909999999', N'242 Tô ký', 1, 0, NULL, NULL, NULL, 1, N'2013-02-15 00:00:00', N'2013-02-15 00:00:00', 4)
INSERT INTO [dbo].[User] ([UserId], [UserName], [FullName], [Email], [Phone], [Address], [Active], [IsVerified], [BankName], [BankAccount], [IdentityCard], [Sellable], [CreatedDate], [ModifiedDate], [ProvinceId]) VALUES (5, N'user5', NULL, N'user@gmail.com', N'0909999999', N'242 Tô ký', 1, 0, NULL, NULL, NULL, 0, N'2013-02-15 00:00:00', N'2013-02-15 00:00:00', 1)
INSERT INTO [dbo].[User] ([UserId], [UserName], [FullName], [Email], [Phone], [Address], [Active], [IsVerified], [BankName], [BankAccount], [IdentityCard], [Sellable], [CreatedDate], [ModifiedDate], [ProvinceId]) VALUES (6, N'user6', NULL, N'user@gmail.com', N'0909999999', N'242 Tô ký', 1, 0, NULL, NULL, NULL, 1, N'2013-02-15 00:00:00', N'2013-02-15 00:00:00', 2)
INSERT INTO [dbo].[User] ([UserId], [UserName], [FullName], [Email], [Phone], [Address], [Active], [IsVerified], [BankName], [BankAccount], [IdentityCard], [Sellable], [CreatedDate], [ModifiedDate], [ProvinceId]) VALUES (7, N'user7', NULL, N'user@gmail.com', N'0909999999', N'242 Tô ký', 1, 0, NULL, NULL, NULL, 1, N'2013-02-15 00:00:00', N'2013-02-15 00:00:00', 3)
INSERT INTO [dbo].[User] ([UserId], [UserName], [FullName], [Email], [Phone], [Address], [Active], [IsVerified], [BankName], [BankAccount], [IdentityCard], [Sellable], [CreatedDate], [ModifiedDate], [ProvinceId]) VALUES (8, N'user8', NULL, N'user@gmail.com', N'0909999999', N'242 Tô ký', 1, 0, NULL, NULL, NULL, 1, N'2013-02-15 00:00:00', N'2013-02-15 00:00:00', 4)
INSERT INTO [dbo].[User] ([UserId], [UserName], [FullName], [Email], [Phone], [Address], [Active], [IsVerified], [BankName], [BankAccount], [IdentityCard], [Sellable], [CreatedDate], [ModifiedDate], [ProvinceId]) VALUES (9, N'admin', NULL, N'admin@gmail.com', N'0909777777', N'123 To Ky', 0, 0, NULL, NULL, NULL, 0, N'2013-07-19 11:50:02', N'2013-07-19 11:50:02', 1)
INSERT INTO [dbo].[User] ([UserId], [UserName], [FullName], [Email], [Phone], [Address], [Active], [IsVerified], [BankName], [BankAccount], [IdentityCard], [Sellable], [CreatedDate], [ModifiedDate], [ProvinceId]) VALUES (10, N'Tuanbui', N'Tuan bui', N'tuanbui12@yahoo.com', N'0934889877', N'65 Quang Trung', 1, 0, N'Dong A Bank', N'2425676891', N'241099867', 0, N'2013-07-19 15:11:17', N'2013-07-19 15:11:17', 63)
INSERT INTO [dbo].[User] ([UserId], [UserName], [FullName], [Email], [Phone], [Address], [Active], [IsVerified], [BankName], [BankAccount], [IdentityCard], [Sellable], [CreatedDate], [ModifiedDate], [ProvinceId]) VALUES (11, N'hieutran', N'Trần Hiếu', N'hieuhieu@yahoo.com', N'0914005007', N'go vap', 1, 0, NULL, NULL, NULL, 0, N'2013-07-19 15:31:28', N'2013-07-19 15:31:28', 63)
INSERT INTO [dbo].[User] ([UserId], [UserName], [FullName], [Email], [Phone], [Address], [Active], [IsVerified], [BankName], [BankAccount], [IdentityCard], [Sellable], [CreatedDate], [ModifiedDate], [ProvinceId]) VALUES (12, N'huytuan', N'Huy Tuấn', N'tuanhuy123@yahoo.com', N'0942153264', N'Bình thạnh', 1, 0, NULL, NULL, NULL, 0, N'2013-07-19 15:41:12', N'2013-07-19 15:41:12', 63)
INSERT INTO [dbo].[User] ([UserId], [UserName], [FullName], [Email], [Phone], [Address], [Active], [IsVerified], [BankName], [BankAccount], [IdentityCard], [Sellable], [CreatedDate], [ModifiedDate], [ProvinceId]) VALUES (13, N'thanhhoang', N'Thanh Hoàng', N'hoangthanh@yahoo.com', N'094521687', N'quận 12', 1, 0, NULL, NULL, NULL, 0, N'2013-07-19 15:45:49', N'2013-07-19 15:45:49', 63)
INSERT INTO [dbo].[User] ([UserId], [UserName], [FullName], [Email], [Phone], [Address], [Active], [IsVerified], [BankName], [BankAccount], [IdentityCard], [Sellable], [CreatedDate], [ModifiedDate], [ProvinceId]) VALUES (14, N'vuviet', N'Vũ Quốc Viêt', N'quocviet15@yahoo.com', N'0986145253', N'Hồ Văn Huê', 1, 0, NULL, NULL, NULL, 0, N'2013-07-19 15:51:09', N'2013-07-19 15:51:09', 63)
SET IDENTITY_INSERT [dbo].[User] OFF

--

CREATE TABLE [dbo].[webpages_Membership] (
    [UserId]                                  INT            NOT NULL,
    [CreateDate]                              DATETIME       NULL,
    [ConfirmationToken]                       NVARCHAR (128) NULL,
    [IsConfirmed]                             BIT            DEFAULT ((0)) NULL,
    [LastPasswordFailureDate]                 DATETIME       NULL,
    [PasswordFailuresSinceLastSuccess]        INT            DEFAULT ((0)) NOT NULL,
    [Password]                                NVARCHAR (128) NOT NULL,
    [PasswordChangedDate]                     DATETIME       NULL,
    [PasswordSalt]                            NVARCHAR (128) NOT NULL,
    [PasswordVerificationToken]               NVARCHAR (128) NULL,
    [PasswordVerificationTokenExpirationDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);

CREATE TABLE [dbo].[webpages_OAuthMembership] (
    [Provider]       NVARCHAR (30)  NOT NULL,
    [ProviderUserId] NVARCHAR (100) NOT NULL,
    [UserId]         INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Provider] ASC, [ProviderUserId] ASC)
);

CREATE TABLE [dbo].[webpages_Roles] (
    [RoleId]   INT            IDENTITY (1, 1) NOT NULL,
    [RoleName] NVARCHAR (256) NOT NULL,
    PRIMARY KEY CLUSTERED ([RoleId] ASC),
    UNIQUE NONCLUSTERED ([RoleName] ASC)
);


CREATE TABLE [dbo].[webpages_UsersInRoles] (
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [fk_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [fk_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[webpages_Roles] ([RoleId])
);



INSERT INTO [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (9, N'2013-07-19 04:50:02', NULL, 1, NULL, 0, N'ANG24drn6WmLAtm5ucdsGAOAmWrpGtbuKrlhnrh8qAxliGh06tCTFM6zJcXvD/ZRCQ==', N'2013-07-19 04:50:02', N'', NULL, NULL)
INSERT INTO [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (10, N'2013-07-19 08:11:18', NULL, 1, NULL, 0, N'ACLMbeFXlCQzWqNCCgwW3TbcuFkBt/dzD/A1eWySCeNKyq1YTfirl+gu4/I7CitROQ==', N'2013-07-19 08:11:18', N'', NULL, NULL)
INSERT INTO [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (11, N'2013-07-19 08:31:29', NULL, 1, NULL, 0, N'AAt6O9JUlFClx1531UeoA36+J4n+TgIbDp8ykW14ixzBICDJmQHWhO6aKLtUN6pdNA==', N'2013-07-19 08:31:29', N'', NULL, NULL)
INSERT INTO [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (12, N'2013-07-19 08:41:12', NULL, 1, NULL, 0, N'AAFCxKRGeLloH4aZHA7TjxYlhckhHWvO418+uoOgOnFfpCiGD3PNfZ4VlVNATSKqJg==', N'2013-07-19 08:41:12', N'', NULL, NULL)
INSERT INTO [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (13, N'2013-07-19 08:45:49', NULL, 1, NULL, 0, N'AJyF+R5Iiik0xTStgPt0l/NkK3E43xiDx6FAvkS6Te8dujs3lSQR+TBdLiE3++Fq4A==', N'2013-07-19 08:45:49', N'', NULL, NULL)
INSERT INTO [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (14, N'2013-07-19 08:51:09', NULL, 1, NULL, 0, N'ALUONvO4XcZasQwBNUA3DRMKgSeLJGzE7dncbQkTA9p2WEEwkHXsn2K3fTLo0wGZ3w==', N'2013-07-19 08:51:09', N'', NULL, NULL)

GO

SET IDENTITY_INSERT [dbo].[webpages_Roles] ON
INSERT INTO [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (1, N'Administrator')
SET IDENTITY_INSERT [dbo].[webpages_Roles] OFF

GO

INSERT INTO [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (9, 1)


-----------Request------------------


-----------UserFollowEvent------------------


-----Ticket--------------

SET IDENTITY_INSERT [dbo].[Ticket] ON
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (9, N'25251325', 150000, 139500, N'16A', N'Khán đài A', 1, 10, 10, NULL, N'2013-07-19 15:12:19', N'2013-07-19 15:18:54', NULL, NULL, NULL, NULL, NULL, NULL, 10, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (10, N'25251326', 150000, 139500, N'17A', N'Khán đài A', 1, 10, 10, NULL, N'2013-07-19 15:14:25', N'2013-07-19 15:18:41', NULL, NULL, NULL, NULL, NULL, NULL, 10, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (11, N'25251328', 150000, 139500, N'18A', N'Khán đài A', 1, 10, 10, NULL, N'2013-07-19 15:27:36', N'2013-07-19 15:27:36', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (12, N'250000', 250000, 232499, N'tự do', N'miễn phí đồ uống', 1, 10, 14, NULL, N'2013-07-19 15:28:20', N'2013-07-22 12:36:56', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (13, N'000001', 100000, 93000, N'tự do', N'đồ uống miễn phí', 1, 10, 15, NULL, N'2013-07-19 15:29:52', N'2013-07-22 12:36:56', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (14, NULL, 200000, 186000, N'tự do', N'đồ uống miễn phí', 1, 11, 13, NULL, N'2013-07-19 15:32:59', N'2013-07-22 12:36:55', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (15, NULL, 100000, 93000, N'tự do', N'đồ uống miễn phí', 1, 11, 24, NULL, N'2013-07-19 15:33:35', N'2013-07-19 15:33:35', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (16, NULL, 100000, 93000, N'tự do', N'đồ uống miễn phí', 1, 11, 17, NULL, N'2013-07-19 15:34:16', N'2013-07-19 15:34:16', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (17, NULL, 150000, 139500, N'tự do', N'miễn phí đồ uống và thức ăn nhẹ', 4, 11, 13, NULL, N'2013-07-19 15:35:07', N'2013-07-22 12:24:44', N'Thanh Hoàng', 1, NULL, NULL, N'quận 12', 1, 13, N'2013-07-22 12:24:42', N'2013-07-22 12:24:44')
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (18, NULL, 100000, 93000, N'tự do', N'miễn phí đồ uống', 1, 11, 15, NULL, N'2013-07-19 15:39:33', N'2013-07-19 15:39:33', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (19, NULL, 400000, 372000, N'khán đài c - ghế vip', N'ghế vip', 4, 12, 1, NULL, N'2013-07-19 15:41:45', N'2013-07-22 12:24:26', N'Thanh Hoàng', 1, NULL, NULL, N'quận 12', 1, 13, N'2013-07-22 12:24:25', N'2013-07-22 12:24:26')
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (20, NULL, 400000, 372000, N'khán đài c - ghế vip', N'ghế vip', 1, 12, 1, NULL, N'2013-07-19 15:43:03', N'2013-07-22 11:36:04', NULL, NULL, NULL, NULL, NULL, NULL, 12, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (21, NULL, 150000, 139500, N'tự do', N'đồ uống và thức ăn nhẹ miễn phí', 1, 12, 19, NULL, N'2013-07-19 15:43:54', N'2013-07-19 15:43:54', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (22, NULL, 100000, 93000, N'tự do', N'phục vụ miễn phí đồ ăn nhẹ và đồ uống', 4, 12, 12, NULL, N'2013-07-19 15:44:42', N'2013-07-22 11:33:33', N'Trần Hiếu', 0, NULL, NULL, N'go vap', 1, 11, N'2013-07-22 11:33:31', N'2013-07-22 11:33:33')
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (23, NULL, 60000, 55799.999999999993, N'tự do', NULL, 1, 12, 1, NULL, N'2013-07-19 15:45:05', N'2013-07-22 11:58:14', NULL, NULL, NULL, NULL, NULL, NULL, 12, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (24, NULL, 200000, 186000, N'tự do', N'có tiệc buffet', 1, 13, 31, NULL, N'2013-07-19 15:46:51', N'2013-07-19 15:46:51', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (25, NULL, 150000, 139500, N'khán đài B, ghế 17', NULL, 4, 13, 11, NULL, N'2013-07-19 15:47:55', N'2013-07-22 11:24:29', N'Tuanbui', 1, NULL, NULL, N'65 Quang Trung', 1, 10, N'2013-07-22 11:24:28', N'2013-07-22 11:24:29')
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (26, NULL, 150000, 139500, N'tự do', N'nước uống miễn phí', 4, 14, 20, NULL, N'2013-07-19 15:51:51', N'2013-07-22 11:22:43', N'Tuanbui', 1, NULL, NULL, N'65 Quang Trung', 1, 10, N'2013-07-22 11:22:39', N'2013-07-22 11:22:43')
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (27, NULL, 150000, 139500, N'tự do', N'nước uống miễn phí', 1, 14, 20, NULL, N'2013-07-19 15:52:15', N'2013-07-19 15:52:15', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (28, NULL, 150000, 139500, N'tự do', N'nước uống miễn phí', 1, 14, 20, NULL, N'2013-07-19 15:53:12', N'2013-07-19 15:53:12', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (29, NULL, 150000, 139500, N'tự do', N'nước uống miễn phí', 1, 14, 20, NULL, N'2013-07-19 15:53:33', N'2013-07-19 15:53:33', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (1009, NULL, 600000, 558000, N'Ghế 1C - Khán đài C - hàng VIP', N'Bonus thức ăn nhẹ', 1, 10, 31, NULL, N'2013-07-22 11:31:22', N'2013-07-22 12:36:55', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (1010, NULL, 600000, 558000, N'Ghế 1C - Khán đài C - hàng VIP', N'bonus đồ uống free', 1, 10, 31, NULL, N'2013-07-22 11:32:21', N'2013-07-22 12:36:54', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (1011, NULL, 70000, 65099, N'Tự do', NULL, 1, 12, 31, NULL, N'2013-07-22 12:02:44', N'2013-07-22 12:36:57', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (1012, NULL, 150000, 139500, N'khán đài A - đối diện sân khấu', NULL, 1, 13, 31, NULL, N'2013-07-22 12:23:20', N'2013-07-22 12:36:57', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT INTO [dbo].[Ticket] ([TicketId], [SeriesNumber], [SellPrice], [ReceiveMoney], [Seat], [Description], [Status], [UserId], [EventId], [AdminModifiedDate], [CreatedDate], [ModifiedDate], [TranFullName], [TranType], [TranShipDate], [TranDescription], [TranAddress], [TranStatus], [TranUserId], [TranCreatedDate], [TranModifiedDate]) VALUES (1013, NULL, 150000, 139500, N'khán đài A - đối diện sân khấu', NULL, 1, 13, 31, NULL, N'2013-07-22 12:24:13', N'2013-07-22 12:37:00', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Ticket] OFF

-----------TicketResponse------------------

GO

SET IDENTITY_INSERT [dbo].[Setting] ON
INSERT INTO [dbo].[Setting] ([Id], [SettingName], [Value]) VALUES (1, N'ServiceFee', N'0.07')
INSERT INTO [dbo].[Setting] ([Id], [SettingName], [Value]) VALUES (2, N'ShippingCost', N'15000')
INSERT INTO [dbo].[Setting] ([Id], [SettingName], [Value]) VALUES (3, N'DollarRate', N'21233')
SET IDENTITY_INSERT [dbo].[Setting] OFF

GO
