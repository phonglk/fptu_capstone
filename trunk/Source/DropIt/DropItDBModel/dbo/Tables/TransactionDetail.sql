CREATE TABLE [dbo].[TransactionDetail] (
    [TransactionDetailId] INT IDENTITY (1, 1) NOT NULL,
    [TransactionId]       INT NOT NULL,
    [TicketId]            INT NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([TransactionDetailId] ASC),
    CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY ([TransactionId]) REFERENCES [dbo].[Transaction] ([TransactionId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_OrderDetail_Ticket] FOREIGN KEY ([TicketId]) REFERENCES [dbo].[Ticket] ([TicketId])
);

