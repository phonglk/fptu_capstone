CREATE TABLE [dbo].[Event] (
    [EventId]      INT            IDENTITY (1, 1) NOT NULL,
    [EventName]    NVARCHAR (50)  NOT NULL,
    [EventImage]   NVARCHAR (MAX) NULL,
    [Artist]       NVARCHAR (50)  NULL,
    [HoldDate]     DATETIME       NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [Status]       INT            NOT NULL,
    [CategoryId]   INT            NOT NULL,
    [VenueId]      INT            NOT NULL,
    [CreatedDate]  DATETIME       NULL,
    [ModifiedDate] DATETIME       NULL,
    CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([EventId] ASC),
    CONSTRAINT [FK_Event_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Event_Venue] FOREIGN KEY ([VenueId]) REFERENCES [dbo].[Venue] ([VenueId]) ON DELETE CASCADE ON UPDATE CASCADE
);










GO
CREATE TRIGGER Update_Other_When_EventOutDate
	ON [dbo].[Event]
	After UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		if not update([Status])
		Return

		if exists(select * from inserted where [Status] = 4)
		begin 
			--Event Status:
			---- Disapprove = 0, Approve = 1, Delete = 2, Trading = 3, Outdate = 4
			--Ticket Status:
			---- Pending = 0, Ready = 1, Delete = 2, UserApprove = 3, OnTransaction = 4, Invalid = 5
			--Transaction Status:
			---- Paid = 1, Delivered = 2, Received = 3, Canceled = 4

			declare @EventId int;
			set @EventId = (select DISTINCT EventId from inserted)

			--Delete ticket while not being traded
			update Ticket
			set [Status] = 2 -- Delete
			where EventId = @EventId
			and [Status] != 5 -- Invalid

			--Cancel transaction while user cannot received ticket
			update Ticket
			set [TranStatus] = 4 -- Cancel
			where EventId = @EventId
			and ([TranStatus]  = 1 or [TranStatus] = 2) -- Paid || Delivered

			--Close related request
			update Request
			set [Status] = 1 
			where EventId = @EventId

			----Delete related response
			--delete TicketResponse
			--where EventId = @EventId

		end

	END