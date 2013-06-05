CREATE TABLE [dbo].[TicketResponse] (
    [UserId]      INT            NOT NULL,
    [EventId]     INT            NOT NULL,
    [TicketId]    INT            NOT NULL,
    [Status]      INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_RespondRequest] PRIMARY KEY CLUSTERED ([UserId] ASC, [EventId] ASC, [TicketId] ASC),
    CONSTRAINT [FK_RespondRequest_Request] FOREIGN KEY ([UserId], [EventId]) REFERENCES [dbo].[Request] ([UserId], [EventId]),
    CONSTRAINT [FK_RespondRequest_Ticket] FOREIGN KEY ([TicketId]) REFERENCES [dbo].[Ticket] ([TicketId]) ON DELETE CASCADE ON UPDATE CASCADE
);



