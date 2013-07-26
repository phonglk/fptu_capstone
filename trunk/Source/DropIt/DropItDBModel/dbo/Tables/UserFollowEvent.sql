CREATE TABLE [dbo].[UserFollowEvent] (
    [UserFollowEventId] INT IDENTITY (1, 1) NOT NULL,
    [UserId]        INT NOT NULL,
    [EventId]       INT NOT NULL,
	[FollowType] INT NOT NULL DEFAULT 2, 
    CONSTRAINT [PK_UserFollowEvent] PRIMARY KEY CLUSTERED ([UserFollowEventId] ASC),
    CONSTRAINT [FK_UserFollowEvent_Event] FOREIGN KEY ([EventId]) REFERENCES [dbo].[Event] ([EventId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_UserFollowEvent_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);

