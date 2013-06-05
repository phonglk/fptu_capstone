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
<statuses>
	<status CategoryId="1" CategoryName="Giải Trí" Status="1" Description="Test"/>
	<status CategoryId="2" CategoryName="Ca nhạc" Description="Test"/>
	<status CategoryId="3" CategoryName="Ca nhạc trong nước" ParentCategoryId="2" Status="1" Description="Test"/>
	<status CategoryId="4" CategoryName="Ca nhạc nước ngoài" ParentCategoryId="2" Status="1" Description="Test"/>
	<status CategoryId="5" CategoryName="Thể Thao" Status="1" Description="Test"/>

</statuses>
'

EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE Category AS target Using (
	Select s.CategoryId, s.CategoryName, s.ParentCategoryId, s.Status, s.Description
	From OPENXML (@xml, '/statuses/status', 1)
	With (CategoryId int, CategoryName nvarchar(50), ParentCategoryId int, Status int, Description nvarchar(MAX)) as s
) AS source (CategoryId, CategoryName, ParentCategoryId, Status, Description)
ON (source.CategoryId = target.CategoryId)
WHEN NOT MATCHED BY TARGET THEN
	Insert (CategoryName, ParentCategoryId, Status, Description) values (source.CategoryName, source.ParentCategoryId, source.Status, source.Description);
	-------------Venue--------------


SET @xmlData = N'
<statuses>
  <status VenueId="1" VenueName="Bằng Lăng Tím" Address="123" ProvinceId="1" Status="1" Description="Có bãi gửi xe"/>
  <status VenueId="2" VenueName="Bò cạp vàng" Address="123" ProvinceId="1" Status="1" Description="Có bãi gửi xe"/>
  <status VenueId="3" VenueName="Quân Khu 7" Address="123" ProvinceId="2" Status="1" Description="Có bãi gửi xe"/>
  <status VenueId="4" VenueName="SVĐ Mỹ Đình" Address="123" ProvinceId="3" Status="1" Description="Có bãi gửi xe"/>
</statuses>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE Venue AS target USING (
    SELECT s.VenueId, s.VenueName, s.Address, s.ProvinceId, s.Status, s.Description
    FROM OPENXML(@xml, '/statuses/status', 1)
    WITH (VenueId int, VenueName nvarchar(50), Address nvarchar(MAX), ProvinceId int, Status int, Description nvarchar(MAX)) as s) 
	AS source (VenueId, VenueName, Address, ProvinceId, Status, Description)
ON (source.VenueId = target.VenueId)
--WHEN MATCHED THEN
    --UPDATE SET Name = source.Name
WHEN NOT MATCHED BY TARGET THEN
    INSERT (VenueName, Address, ProvinceId, Status, Description) values ( source.VenueName, source.Address, source.ProvinceId, source.Status, source.Description)
;

--------------Province-----------------------

SET @xmlData = N'
<statuses>
  <status ProvinceId="1" ProvinceName="HCM"/>
  <status ProvinceId="2" ProvinceName="HN"/>
  <status ProvinceId="3" ProvinceName="TQ"/>
  <status ProvinceId="4" ProvinceName="HaiPhong"/>  
</statuses>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE Province AS target USING (
    SELECT s.ProvinceId, s.ProvinceName
    FROM OPENXML(@xml, '/statuses/status', 1)
    WITH (ProvinceId int, ProvinceName nvarchar(50)) as s) 
	AS source (ProvinceId, ProvinceName)
ON (source.ProvinceId = target.ProvinceId)
--WHEN MATCHED THEN
--    UPDATE SET ProvinceName = source.ProvinceName
WHEN NOT MATCHED BY TARGET THEN
    INSERT (ProvinceName) values (source.ProvinceName)
;

-----------Event------------------
SET @xmlData = N'
<statuses>
  <status EventId="1" EventName="Sự kiện 1" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="1" CategoryId="2"  VenueId="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status EventId="2" EventName="Sự kiện 2" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="1" CategoryId="2"  VenueId="2" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status EventId="3" EventName="Sự kiện 3" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="1" CategoryId="3"  VenueId="3" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status EventId="4" EventName="Sự kiện 4" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="1" CategoryId="15"  VenueId="4" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status EventId="5" EventName="Sự kiện 5" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="0" CategoryId="15"  VenueId="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status EventId="6" EventName="Sự kiện 6" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="1" CategoryId="16"  VenueId="2" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status EventId="7" EventName="Sự kiện 7" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="0" CategoryId="17"  VenueId="3" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>	
  <status EventId="8" EventName="Sự kiện 8" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="0" CategoryId="18"  VenueId="4" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status EventId="9" EventName="Sự kiện 9" Artist="Mỹ Tâm" HoldDate="02/15/2013" Status="1" CategoryId="14"  VenueId="2" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
</statuses>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE Event AS target USING (
    SELECT s.EventId, s.EventName, s.Artist, s.HoldDate, s.Description, s.Status, s.CategoryId, s.VenueId, s.CreatedDate, s.ModifiedDate
    FROM OPENXML(@xml, '/statuses/status', 1)
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
<statuses>
  <status UserId="1" UserName="user1" Password="1234567" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" Role="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="1"/>
  <status UserId="2" UserName="user2" Password="1234567" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" Role="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="1"/>
  <status UserId="3" UserName="user3" Password="1234567" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" Role="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="2"/>
  <status UserId="4" UserName="user4" Password="1234567" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" Role="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="2"/>
  <status UserId="5" UserName="user5" Password="1234567" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" Role="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="3"/>
  <status UserId="6" UserName="user6" Password="1234567" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" Role="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="4"/>
  <status UserId="7" UserName="user7" Password="1234567" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" Role="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="2"/>
  <status UserId="8" UserName="user8" Password="1234567" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" Role="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="4"/>
  <status UserId="9" UserName="user9" Password="1234567" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" Role="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="3"/>
  <status UserId="10" UserName="admin" Password="1234567" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" Role="0" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="1"/>
  <status UserId="11" UserName="user10" Password="1234567" Email="user@gmail.com" Phone="0909999999" Address="242 Tô ký"  Active="1" Sellable="1" Role="1" CreatedDate="02/15/2013" ModifiedDate="02/15/2013" ProvinceId="4"/>
</statuses>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE [User] AS target USING (
    SELECT s.UserId, s.UserName, s.Password, s.Email, s.Phone, s.Address, s.Active, s.Sellable, s.Role, s.CreatedDate, s.ModifiedDate, s.ProvinceId
    FROM OPENXML(@xml, '/statuses/status', 1)
    WITH (UserId int, UserName nvarchar(50), Password nvarchar(50), Email nvarchar(50), Phone int, Address nvarchar(MAX), Active bit, Sellable bit, Role int, CreatedDate datetime, ModifiedDate datetime, ProvinceId int) as s) 
	AS source (UserId, UserName, Password, Email, Phone, Address, Active, Sellable, Role, CreatedDate, ModifiedDate, ProvinceId)
ON (source.UserId = target.UserId)
--WHEN MATCHED THEN
--    UPDATE SET ProvinceName = source.ProvinceName
WHEN NOT MATCHED BY TARGET THEN
    INSERT (UserName, Password, Email, Phone, Address, Active, Sellable, Role, CreatedDate, ModifiedDate, ProvinceId) values (source.UserName, source.Password, source.Email, source.Phone, source.Address, source.Active, source.Sellable, source.Role, source.CreatedDate, source.ModifiedDate, source.ProvinceId)
;

-----------Request------------------
SET @xmlData = N'
<statuses>
  <status UserId="1" EventId="10" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <status UserId="2" EventId="11" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <status UserId="3" EventId="12" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <status UserId="4" EventId="4" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <status UserId="5" EventId="5" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <status UserId="6" EventId="6" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <status UserId="7" EventId="7" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <status UserId="8" EventId="8" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <status UserId="9" EventId="9" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
  <status UserId="10" EventId="15" Description="Mua vé gấp" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>  
</statuses>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE Request AS target USING (
    SELECT s.UserId, s.EventId, s.Description, s.CreatedDate, s.ModifiedDate
    FROM OPENXML(@xml, '/statuses/status', 1)
    WITH (UserId int, EventId int, Description nvarchar(MAX), CreatedDate datetime, ModifiedDate datetime) as s) 
	AS source (UserId, EventId, Description, CreatedDate, ModifiedDate)
ON (source.UserId = target.UserId and source.EventId = target.EventId)
--WHEN MATCHED THEN
--    UPDATE SET ProvinceName = source.ProvinceName
WHEN NOT MATCHED BY TARGET THEN
    INSERT (UserId, EventId, Description, CreatedDate, ModifiedDate) values (source.UserId, source.EventId, source.Description, source.CreatedDate, source.ModifiedDate)
;

-----------TicketResponse------------------
SET @xmlData = N'
<statuses>
  <status UserId="10" EventId="15" TicketId="81" Status="1" Description="Bán nhanh"/>    
  <status UserId="3" EventId="12" TicketId="82" Status="1" Description="Bán nhanh"/>      
  <status UserId="4" EventId="4" TicketId="84" Status="1" Description="Bán nhanh"/>    
  <status UserId="5" EventId="5" TicketId="85" Status="0" Description="Bán nhanh"/>    
  <status UserId="6" EventId="6" TicketId="86" Status="0" Description="Bán nhanh"/>      
</statuses>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE TicketResponse AS target USING (
    SELECT s.UserId, s.EventId, s.TicketId, s.Status, s.Description
    FROM OPENXML(@xml, '/statuses/status', 1)
    WITH (UserId int, EventId int, TicketId int, Status int, Description nvarchar(MAX)) as s) 
	AS source (UserId, EventId, TicketId, Status, Description)
ON (source.UserId = target.UserId and source.EventId = target.EventId and source.TicketId = target.TicketId)
--WHEN MATCHED THEN
--    UPDATE SET ProvinceName = source.ProvinceName
WHEN NOT MATCHED BY TARGET THEN
    INSERT (UserId, EventId, TicketId, Status, Description) values (source.UserId, source.EventId, source.TicketId, source.Status, source.Description)
;

-----------UserFollowEvent------------------
SET @xmlData = N'
<statuses>
  <status FollowEventId="1" UserId="1" EventId="11"/>      
  <status FollowEventId="2" UserId="2" EventId="12"/>
  <status FollowEventId="3" UserId="3" EventId="13"/>
  <status FollowEventId="4" UserId="4" EventId="4"/>
  <status FollowEventId="5" UserId="5" EventId="5"/>

</statuses>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE UserFollowEvent AS target USING (
    SELECT s.FollowEventId, s.UserId, s.EventId
    FROM OPENXML(@xml, '/statuses/status', 1)
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
<statuses>
  <status TicketId="1" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="2"  Status="1" UserId="1" EventId="11" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status TicketId="2" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="1"  Status="1" UserId="1" EventId="11" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status TicketId="3" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="2"  Status="1" UserId="2" EventId="12" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status TicketId="4" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="2"  Status="1" UserId="3" EventId="12" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status TicketId="5" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="3"  Status="1" UserId="4" EventId="4" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status TicketId="6" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="5"  Status="1" UserId="5" EventId="5" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status TicketId="7" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="4"  Status="1" UserId="6" EventId="6" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status TicketId="8" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="1"  Status="1" UserId="7" EventId="7" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status TicketId="9" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="5"  Status="1" UserId="8" EventId="8" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>
  <status TicketId="10" SellPrice="10" ReceiveMoney="9.7" Seat="ghe ngoi 2A dãy M" Description="Bán gấp cần tiền" CategoryId="4"  Status="1" UserId="9" EventId="9" CreatedDate="02/15/2013" ModifiedDate="02/15/2013"/>

</statuses>
'
EXEC sp_xml_preparedocument @xml OUTPUT, @xmlData

MERGE Ticket AS target USING (
    SELECT s.TicketId, s.SellPrice, s.ReceiveMoney, s.Seat, s.Description, s.Status, s.UserId, s.EventId, s.CreatedDate, s.ModifiedDate, s.TranShipDate, s.TranDescription, s.TranAddress, s.TranStatus, s.TranUserId, s.TranCreatedDate, s.TranModifiedDate
    FROM OPENXML(@xml, '/statuses/status', 1)
    WITH (TicketId int, SellPrice float, ReceiveMoney float, Seat nvarchar(MAX), Description nvarchar(MAX), Status int, UserId int, EventId int, CreatedDate datetime, ModifiedDate datetime, TranShipDate datetime, TranDescription nvarchar(MAX), TranAddress nvarchar(MAX), TranStatus int, TranUserId int, TranCreatedDate datetime, TranModifiedDate datetime) as s) 
	AS source (TicketId, SellPrice, ReceiveMoney, Seat, Description, Status, UserId, EventId, CreatedDate, ModifiedDate, TranShipDate, TranDescription, TranAddress, TranStatus, TranUserId, TranCreatedDate, TranModifiedDate)
ON (source.TicketId = target.TicketId)
--WHEN MATCHED THEN
--    UPDATE SET ProvinceName = source.ProvinceName
WHEN NOT MATCHED BY TARGET THEN
    INSERT (SellPrice, ReceiveMoney, Seat, Description, Status, UserId, EventId, CreatedDate, ModifiedDate, TranShipDate, TranDescription, TranAddress, TranStatus, TranUserId, TranCreatedDate, TranModifiedDate) values (source.SellPrice, source.ReceiveMoney, source.Seat, source.Description, source.Status, source.UserId, source.EventId, source.CreatedDate, source.ModifiedDate, source.TranShipDate, source.TranDescription, source.TranAddress, source.TranStatus, source.TranUserId, source.TranCreatedDate, source.TranModifiedDate)
;
