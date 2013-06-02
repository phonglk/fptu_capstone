CREATE TABLE [dbo].[Ticket] (
    [TicketId]     INT            IDENTITY (1, 1) NOT NULL,
    [SellPrice]    FLOAT (53)     NOT NULL,
    [ReceiveMoney] FLOAT (53)     NOT NULL,
    [Seat]         NVARCHAR (MAX) NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [Status]       NVARCHAR (50)  NOT NULL,
    [UserId]       INT            NOT NULL,
    [EventId]      INT            NOT NULL,
    [CreatedDate]  DATETIME       NULL,
    [ModifiedDate] ROWVERSION     NULL,
    CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED ([TicketId] ASC),
    CONSTRAINT [FK_Ticket_Event] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Event] ([EventId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Ticket_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);





