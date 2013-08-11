CREATE TABLE [dbo].[Ticket] (
    [TicketId]          INT            IDENTITY (1, 1) NOT NULL,
    [SeriesNumber]      NVARCHAR (50)  NULL,
    [SellPrice]         FLOAT (53)     NOT NULL,
    [ReceiveMoney]      FLOAT (53)     NOT NULL,
    [ShippingCost]      FLOAT (53)     NULL,
    [Seat]              NVARCHAR (MAX) NULL,
    [Description]       NVARCHAR (MAX) NULL,
    [Status]            INT            NOT NULL,
    [UserId]            INT            NOT NULL,
    [EventId]           INT            NOT NULL,
    [AdminModifiedDate] DATETIME       NULL,
    [CreatedDate]       DATETIME       NULL,
    [ModifiedDate]      DATETIME       NULL,
    [TranFullName]      NVARCHAR (50)  NULL,
    [TranType]          INT            NULL,
    [TranShipDate]      DATETIME       NULL,
    [TranDescription]   NVARCHAR (MAX) NULL,
    [TranAddress]       NVARCHAR (MAX) NULL,
    [TranStatus]        INT            NULL,
    [TranUserId]        INT            NULL,
    [TranCreatedDate]   DATETIME       NULL,
    [TranModifiedDate]  DATETIME       NULL,
    [TranShipCode]      NVARCHAR (50)  NULL,
    [TranPaymentStatus] INT            NULL,
    CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED ([TicketId] ASC),
    CONSTRAINT [FK_Ticket_Event] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Event] ([EventId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Ticket_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Ticket_User1] FOREIGN KEY ([TranUserId]) REFERENCES [dbo].[User] ([UserId])
);




































GO

CREATE TRIGGER Update_Ticket_When_Transaction
	ON [dbo].[Ticket]
	After UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		if not update(TranStatus)
		Return

		if exists(select * from inserted where TranStatus = 0 or TranStatus = 1)
		begin 
			update Ticket
			set [Status] = 4
			where TicketId = (select TicketId from inserted)
		end

	END
GO

CREATE TRIGGER Update_Event_When_Transaction
	ON [dbo].[Ticket]
	After UPDATE
	AS
	BEGIN
		SET NOCOUNT ON
		if not update([Status])
		Return

		if exists(select * from inserted where [Status] = 4)
		begin 
			update Event
			set [Status] = 3
			where EventId = (select EventId from inserted)
		end

	END