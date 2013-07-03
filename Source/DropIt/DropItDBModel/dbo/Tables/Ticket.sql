CREATE TABLE [dbo].[Ticket] (
    [TicketId]          INT            IDENTITY (1, 1) NOT NULL,
    [SellPrice]         FLOAT (53)     NOT NULL,
    [ReceiveMoney]      FLOAT (53)     NOT NULL,
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
    CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED ([TicketId] ASC),
    CONSTRAINT [FK_Ticket_Event] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Event] ([EventId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Ticket_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Ticket_User1] FOREIGN KEY ([TranUserId]) REFERENCES [dbo].[User] ([UserId])
);















