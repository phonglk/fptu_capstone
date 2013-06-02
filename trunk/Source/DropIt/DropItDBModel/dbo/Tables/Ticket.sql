CREATE TABLE [dbo].[Ticket] (
    [TicketId]     INT            IDENTITY (1, 1) NOT NULL,
    [Price]        FLOAT (53)     NOT NULL,
    [Seat]         NVARCHAR (MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Description]  NVARCHAR (MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Status]       NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [UserId]       INT            NOT NULL,
    [EventId]      INT            NOT NULL,
    [CreatedDate]  DATETIME       NULL,
    [ModifiedDate] ROWVERSION     NULL,
    CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED ([TicketId] ASC),
    CONSTRAINT [FK_Ticket_Event] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Event] ([EventId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Ticket_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);



