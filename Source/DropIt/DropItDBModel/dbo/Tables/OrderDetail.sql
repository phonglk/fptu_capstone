CREATE TABLE [dbo].[OrderDetail] (
    [OrderDetailId] INT IDENTITY (1, 1) NOT NULL,
    [OrderId]       INT NOT NULL,
    [TicketId]      INT NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([OrderDetailId] ASC),
    CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([OrderId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_OrderDetail_Ticket] FOREIGN KEY ([TicketId]) REFERENCES [dbo].[Ticket] ([TicketId])
);

