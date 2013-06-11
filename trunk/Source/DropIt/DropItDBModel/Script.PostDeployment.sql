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

Declare @xml int

Declare @xmlData xml = N'
<categories>
	<category CategoryId="1" CategoryName="Giải Trí" Status="1" Description="Test"/>
	<category CategoryId="2" CategoryName="Ca nhạc" Status="1" Description="Test"/>
	<category CategoryId="3" CategoryName="Ca nhạc trong nước" Status="1" Description="Test"/>
	<category CategoryId="4" CategoryName="Ca nhạc nước ngoài" Status="1" Description="Test"/>
	<category CategoryId="5" CategoryName="Thể Thao" Status="1" Description="Test"/>
</categories>
'

EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE Category AS target Using (
	Select s.CategoryId, s.CategoryName, s.ParentCategoryId, s.Status, s.Description
	From OPENXML (@xml, '/categories/category', 1)
	With (CategoryId int, CategoryName nvarchar(50), ParentCategoryId int, Status int, Description nvarchar(MAX)) as s
) AS source (CategoryId, CategoryName, ParentCategoryId, Status, Description)
ON (source.CategoryId = target.CategoryId)
WHEN NOT MATCHED BY TARGET THEN
	Insert (CategoryName, ParentCategoryId, Status, Description) values (source.CategoryName, source.ParentCategoryId, source.Status, source.Description);


--------------Province-----------------------

SET @xmlData = N'
<provinces>
	<province ProvinceId="1" ProvinceName="An Giang"/>
	<province ProvinceId="1" ProvinceName="Bà Rịa - Vũng Tàu"/>
	<province ProvinceId="1" ProvinceName="Bắc Giang"/>
	<province ProvinceId="1" ProvinceName="Bắc Kạn"/>
	<province ProvinceId="1" ProvinceName="Bạc Liêu"/>
	<province ProvinceId="1" ProvinceName="Bắc Ninh"/>
	<province ProvinceId="1" ProvinceName="Bến Tre"/>
	<province ProvinceId="1" ProvinceName="Bình Định"/>
	<province ProvinceId="1" ProvinceName="Bình Dương"/>
	<province ProvinceId="1" ProvinceName="Bình Phước"/>
	<province ProvinceId="1" ProvinceName="Bình Thuận"/>
	<province ProvinceId="1" ProvinceName="Cà Mau"/>
	<province ProvinceId="1" ProvinceName="Cao Bằng"/>
	<province ProvinceId="1" ProvinceName="Đắk Lắk"/>
	<province ProvinceId="1" ProvinceName="Đắk Nông"/>
	<province ProvinceId="1" ProvinceName="Điện Biên"/>
	<province ProvinceId="1" ProvinceName="Đồng Nai"/>
	<province ProvinceId="1" ProvinceName="Đồng Tháp"/>
	<province ProvinceId="1" ProvinceName="Gia Lai"/>
	<province ProvinceId="1" ProvinceName="Hà Giang"/>
	<province ProvinceId="1" ProvinceName="Hà Nam"/>
	<province ProvinceId="1" ProvinceName="Hà Tĩnh"/>
	<province ProvinceId="1" ProvinceName="Hải Dương"/>
	<province ProvinceId="1" ProvinceName="Hậu Giang"/>
	<province ProvinceId="1" ProvinceName="Hòa Bình"/>
	<province ProvinceId="1" ProvinceName="Hưng Yên"/>
	<province ProvinceId="1" ProvinceName="Khánh Hòa"/>
	<province ProvinceId="1" ProvinceName="Kiên Giang"/>
	<province ProvinceId="1" ProvinceName="Kon Tum"/>
	<province ProvinceId="1" ProvinceName="Lai Châu"/>
	<province ProvinceId="1" ProvinceName="Lâm Đồng"/>
	<province ProvinceId="1" ProvinceName="Lạng Sơn"/>
	<province ProvinceId="1" ProvinceName="Lào Cai"/>
	<province ProvinceId="1" ProvinceName="Long An"/>
	<province ProvinceId="1" ProvinceName="Nam Định"/>
	<province ProvinceId="1" ProvinceName="Nghệ An"/>
	<province ProvinceId="1" ProvinceName="Ninh Bình"/>
	<province ProvinceId="1" ProvinceName="Ninh Thuận"/>
	<province ProvinceId="1" ProvinceName="Phú Thọ"/>
	<province ProvinceId="1" ProvinceName="Quảng Bình"/>
	<province ProvinceId="1" ProvinceName="Quảng Nam"/>
	<province ProvinceId="1" ProvinceName="Quảng Ngãi"/>
	<province ProvinceId="1" ProvinceName="Quảng Ninh"/>
	<province ProvinceId="1" ProvinceName="Quảng Trị"/>
	<province ProvinceId="1" ProvinceName="Sóc Trăng"/>
	<province ProvinceId="1" ProvinceName="Sơn La"/>
	<province ProvinceId="1" ProvinceName="Tây Ninh"/>
	<province ProvinceId="1" ProvinceName="Thái Bình"/>
	<province ProvinceId="1" ProvinceName="Thái Nguyên"/>
	<province ProvinceId="1" ProvinceName="Thanh Hóa"/>
	<province ProvinceId="1" ProvinceName="Thừa Thiên Huế"/>
	<province ProvinceId="1" ProvinceName="Tiền Giang"/>
	<province ProvinceId="1" ProvinceName="Trà Vinh"/>
	<province ProvinceId="1" ProvinceName="Tuyên Quang"/>
	<province ProvinceId="1" ProvinceName="Vĩnh Long"/>
	<province ProvinceId="1" ProvinceName="Vĩnh Phúc"/>
	<province ProvinceId="1" ProvinceName="Yên Bái"/>
	<province ProvinceId="1" ProvinceName="Phú Yên"/>
	<province ProvinceId="1" ProvinceName="Cần Thơ"/>
	<province ProvinceId="1" ProvinceName="Đà Nẵng"/>
	<province ProvinceId="1" ProvinceName="Hải Phòng"/>
	<province ProvinceId="1" ProvinceName="Hà Nội"/>
	<province ProvinceId="1" ProvinceName="TP HCM"/> 
</provinces>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE Province AS target USING (
    SELECT s.ProvinceId, s.ProvinceName
    FROM OPENXML(@xml, '/provinces/province', 1)
    WITH (ProvinceId int, ProvinceName nvarchar(50)) as s) 
	AS source (ProvinceId, ProvinceName)
ON (source.ProvinceId = target.ProvinceId)
--WHEN MATCHED THEN
--    UPDATE SET ProvinceName = source.ProvinceName
WHEN NOT MATCHED BY TARGET THEN
    INSERT (ProvinceName) values (source.ProvinceName)
;


	-------------Venue--------------
SET @xmlData = N'
<venues>
  <venue VenueId="1" VenueName="Bằng Lăng Tím" Address="123" ProvinceId="1" Status="1" Description="Có bãi gửi xe"/>
  <venue VenueId="2" VenueName="Bò cạp vàng" Address="123" ProvinceId="2" Status="1" Description="Có bãi gửi xe"/>
  <venue VenueId="3" VenueName="Quân Khu 7" Address="123" ProvinceId="3" Status="1" Description="Có bãi gửi xe"/>
  <venue VenueId="4" VenueName="SVĐ Mỹ Đình" Address="123" ProvinceId="4" Status="1" Description="Có bãi gửi xe"/>
</venues>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE Venue AS target USING (
    SELECT s.VenueId, s.VenueName, s.Address, s.ProvinceId, s.Status, s.Description
    FROM OPENXML(@xml, '/venues/venue', 1)
    WITH (VenueId int, VenueName nvarchar(50), Address nvarchar(MAX), ProvinceId int, Status int, Description nvarchar(MAX)) as s) 
	AS source (VenueId, VenueName, Address, ProvinceId, Status, Description)
ON (source.VenueId = target.VenueId)
--WHEN MATCHED THEN
    --UPDATE SET Name = source.Name
WHEN NOT MATCHED BY TARGET THEN
    INSERT (VenueName, Address, ProvinceId, Status, Description) values ( source.VenueName, source.Address, source.ProvinceId, source.Status, source.Description)
;


-----------Event------------------
SET @xmlData = N'
<events>
  <event EventId="1" EventName="Sự kiện 1" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="1" CategoryId="1"  VenueId="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <event EventId="2" EventName="Sự kiện 2" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="1" CategoryId="2"  VenueId="2" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <event EventId="3" EventName="Sự kiện 3" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="1" CategoryId="3"  VenueId="3" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <event EventId="4" EventName="Sự kiện 4" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="1" CategoryId="4"  VenueId="4" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <event EventId="5" EventName="Sự kiện 5" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="0" CategoryId="1"  VenueId="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <event EventId="6" EventName="Sự kiện 6" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="1" CategoryId="2"  VenueId="2" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <event EventId="7" EventName="Sự kiện 7" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="0" CategoryId="3"  VenueId="3" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>	
  <event EventId="8" EventName="Sự kiện 8" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="0" CategoryId="4"  VenueId="4" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <event EventId="9" EventName="Sự kiện 9" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="1" CategoryId="1"  VenueId="2" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
</events>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE Event AS target USING (
    SELECT s.EventId, s.EventName, s.Artist, s.HoldDate, s.Description, s.Status, s.CategoryId, s.VenueId, s.CreatedDate, s.ModifiedDate
    FROM OPENXML(@xml, '/events/event', 1)
    WITH (EventId int, EventName nvarchar(50), Artist nvarchar(50), HoldDate datetime, Description nvarchar(MAX), Status int, CategoryId int, VenueId int, CreatedDate datetime, ModifiedDate datetime) as s) 
	AS source (EventId, EventName, Artist, HoldDate, Description, Status, CategoryId, VenueId, CreatedDate, ModifiedDate)
ON (source.EventId = target.EventId)
--WHEN MATCHED THEN
--    UPDATE SET ProvinceName = source.ProvinceName
WHEN NOT MATCHED BY TARGET THEN
    INSERT (EventName, Artist, HoldDate, Description, Status, CategoryId, VenueId, CreatedDate, ModifiedDate) values (source.EventName, source.Artist, source.HoldDate, source.Description, source.Status, source.CategoryId, source.VenueId, source.CreatedDate, source.ModifiedDate)
;

-----------user------------------
SET @xmlData = N'
<users>
  <user UserId="1" UserName="user1" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="1"/>
  <user UserId="2" UserName="user2" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="2"/>
  <user UserId="3" UserName="user3" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="0" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="3"/>
  <user UserId="4" UserName="user4" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="4"/>
  <user UserId="5" UserName="user5" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="0" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="1"/>
  <user UserId="6" UserName="user6" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="2"/>
  <user UserId="7" UserName="user7" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="3"/>
  <user UserId="8" UserName="user8" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="4"/>
  <user UserId="9" UserName="admin" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="1"/>
</users>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE [User] AS target USING (
    SELECT s.UserId, s.UserName, s.Email, s.Phone, s.Address, s.Active, s.Sellable, s.CreatedDate, s.ModifiedDate, s.ProvinceId
    FROM OPENXML(@xml, '/users/user', 1)
    WITH (UserId int, UserName nvarchar(50), Email nvarchar(50), Phone nvarchar (14), Address nvarchar(MAX), Active bit, Sellable bit, CreatedDate datetime, ModifiedDate datetime, ProvinceId int) as s) 
	AS source (UserId, UserName, Email, Phone, Address, Active, Sellable, CreatedDate, ModifiedDate, ProvinceId)
ON (source.UserId = target.UserId)
--WHEN MATCHED THEN
--    UPDATE SET ProvinceName = source.ProvinceName
WHEN NOT MATCHED BY TARGET THEN
    INSERT (UserName, Email, Phone, Address, Active, Sellable, CreatedDate, ModifiedDate, ProvinceId) values (source.UserName, source.Email, source.Phone, source.Address, source.Active, source.Sellable, source.CreatedDate, source.ModifiedDate, source.ProvinceId)
;
-----------Request------------------
SET @xmlData = N'
<requests>
  <request UserId="1" EventId="1" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <request UserId="2" EventId="2" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <request UserId="3" EventId="3" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <request UserId="4" EventId="4" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <request UserId="5" EventId="5" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <request UserId="6" EventId="6" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <request UserId="7" EventId="7" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <request UserId="8" EventId="8" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <request UserId="9" EventId="9" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
</requests>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE Request AS target USING (
    SELECT s.UserId, s.EventId, s.Description, s.CreatedDate, s.ModifiedDate
    FROM OPENXML(@xml, '/requests/request', 1)
    WITH (UserId int, EventId int, Description nvarchar(MAX), CreatedDate datetime, ModifiedDate datetime) as s) 
	AS source (UserId, EventId, Description, CreatedDate, ModifiedDate)
ON (source.UserId = target.UserId and source.EventId = target.EventId)
--WHEN MATCHED THEN
--    UPDATE SET ProvinceName = source.ProvinceName
WHEN NOT MATCHED BY TARGET THEN
    INSERT (UserId, EventId, Description, CreatedDate, ModifiedDate) values (source.UserId, source.EventId, source.Description, source.CreatedDate, source.ModifiedDate)
;

-----------UserFollowEvent------------------
SET @xmlData = N'
<userevents>
  <userevent FollowEventId="1" UserId="1" EventId="1"/>      
  <userevent FollowEventId="2" UserId="2" EventId="2"/>
  <userevent FollowEventId="3" UserId="3" EventId="3"/>
  <userevent FollowEventId="4" UserId="4" EventId="4"/>
</userevents>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE UserFollowEvent AS target USING (
    SELECT s.FollowEventId, s.UserId, s.EventId
    FROM OPENXML(@xml, '/userevents/userevent', 1)
    WITH (FollowEventId int, UserId int, EventId int) as s) 
	AS source (FollowEventId, UserId, EventId)
ON (source.FollowEventId = target.FollowEventId)
--WHEN MATCHED THEN
--    UPDATE SET ProvinceName = source.ProvinceName
WHEN NOT MATCHED BY TARGET THEN
    INSERT (UserId, EventId) values (source.UserId, source.EventId)
;

-----Ticket--------------

SET @xmlData = N'
<tickets>
  <ticket TicketId="1" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="1"  Status="1" UserId="1" EventId="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <ticket TicketId="2" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="2"  Status="1" UserId="2" EventId="2" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <ticket TicketId="3" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="3"  Status="1" UserId="3" EventId="3" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <ticket TicketId="4" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="4"  Status="1" UserId="4" EventId="4" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <ticket TicketId="5" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="1"  Status="1" UserId="5" EventId="5" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <ticket TicketId="6" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="2"  Status="1" UserId="6" EventId="6" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <ticket TicketId="7" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="3"  Status="1" UserId="7" EventId="7" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <ticket TicketId="8" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="4"  Status="1" UserId="8" EventId="8" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <ticket TicketId="9" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="1"  Status="0" UserId="9" EventId="9" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/> 
</tickets>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE Ticket AS target USING (
    SELECT s.TicketId, s.SellPrice, s.ReceiveMoney, s.Seat, s.Description, s.Status, s.UserId, s.EventId, s.CreatedDate, s.ModifiedDate, s.TranShipDate, s.TranDescription, s.TranAddress, s.TranStatus, s.TranUserId, s.TranCreatedDate, s.TranModifiedDate
    FROM OPENXML(@xml, '/tickets/ticket', 1)
    WITH (TicketId int, SellPrice float, ReceiveMoney float, Seat nvarchar(MAX), Description nvarchar(MAX), Status int, UserId int, EventId int, CreatedDate datetime, ModifiedDate datetime, TranShipDate datetime, TranDescription nvarchar(MAX), TranAddress nvarchar(MAX), TranStatus int, TranUserId int, TranCreatedDate datetime, TranModifiedDate datetime) as s) 
	AS source (TicketId, SellPrice, ReceiveMoney, Seat, Description, Status, UserId, EventId, CreatedDate, ModifiedDate, TranShipDate, TranDescription, TranAddress, TranStatus, TranUserId, TranCreatedDate, TranModifiedDate)
ON (source.TicketId = target.TicketId)
--WHEN MATCHED THEN
--    UPDATE SET ProvinceName = source.ProvinceName
WHEN NOT MATCHED BY TARGET THEN
    INSERT (SellPrice, ReceiveMoney, Seat, Description, Status, UserId, EventId, CreatedDate, ModifiedDate, TranShipDate, TranDescription, TranAddress, TranStatus, TranUserId, TranCreatedDate, TranModifiedDate) values (source.SellPrice, source.ReceiveMoney, source.Seat, source.Description, source.Status, source.UserId, source.EventId, source.CreatedDate, source.ModifiedDate, source.TranShipDate, source.TranDescription, source.TranAddress, source.TranStatus, source.TranUserId, source.TranCreatedDate, source.TranModifiedDate)
;

-----------TicketResponse------------------
SET @xmlData = N'
<ticketresponses>
  <ticketresponse UserId="1" EventId="1" TicketId="1" Status="1" Description="Bán nhanh"/>    
  <ticketresponse UserId="2" EventId="2" TicketId="2" Status="1" Description="Bán nhanh"/>      
  <ticketresponse UserId="3" EventId="3" TicketId="3" Status="1" Description="Bán nhanh"/>    
  <ticketresponse UserId="4" EventId="4" TicketId="4" Status="0" Description="Bán nhanh"/>      
</ticketresponses>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE TicketResponse AS target USING (
    SELECT s.UserId, s.EventId, s.TicketId, s.Status, s.Description
    FROM OPENXML(@xml, '/ticketresponses/ticketresponse', 1)
    WITH (UserId int, EventId int, TicketId int, Status int, Description nvarchar(MAX)) as s) 
	AS source (UserId, EventId, TicketId, Status, Description)
ON (source.UserId = target.UserId and source.EventId = target.EventId and source.TicketId = target.TicketId)
--WHEN MATCHED THEN
--    UPDATE SET ProvinceName = source.ProvinceName
WHEN NOT MATCHED BY TARGET THEN
    INSERT (UserId, EventId, TicketId, Status, Description) values (source.UserId, source.EventId, source.TicketId, source.Status, source.Description)
;