CREATE TABLE [dbo].[UserFollowEvent] (
    [FollowEventId] INT IDENTITY (1, 1) NOT NULL,
    [UserId]        INT NOT NULL,
    [EventId]       INT NOT NULL,
    CONSTRAINT [PK_UserFollowEvent] PRIMARY KEY CLUSTERED ([FollowEventId] ASC),
    CONSTRAINT [FK_UserFollowEvent_Event] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Event] ([EventId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_UserFollowEvent_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);

