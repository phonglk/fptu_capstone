CREATE TABLE [dbo].[Request] (
    [UserId]       INT            NOT NULL,
    [EventId]      INT            NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedDate] DATETIME       NOT NULL,
    CONSTRAINT [PK_Request_1] PRIMARY KEY CLUSTERED ([UserId] ASC, [EventId] ASC),
    CONSTRAINT [FK_Request_Event] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Event] ([EventId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Request_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);

