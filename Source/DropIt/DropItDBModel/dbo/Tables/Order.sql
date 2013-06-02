CREATE TABLE [dbo].[Order] (
    [OrderId]      INT            IDENTITY (1, 1) NOT NULL,
    [ShipDate]     DATETIME       NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [Status]       INT            NOT NULL,
    [TicketId]     INT            NOT NULL,
    [UserId]       INT            NOT NULL,
    [CreatedDate]  DATETIME       NULL,
    [ModifiedDate] DATETIME       NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderId] ASC),
    CONSTRAINT [FK_Order_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);



