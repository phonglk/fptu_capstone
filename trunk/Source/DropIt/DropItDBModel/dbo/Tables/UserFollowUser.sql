CREATE TABLE [dbo].[UserFollowUser] (
    [UserFollowUserId] INT IDENTITY (1, 1) NOT NULL,
    [UserId]        INT NOT NULL,
    [UserFollowId]       INT NOT NULL,
    [FollowType] INT NOT NULL DEFAULT 2, 
    CONSTRAINT [PK_UserFollowUser] PRIMARY KEY CLUSTERED ([UserFollowUserId] ASC),
    CONSTRAINT [FK_UserFollowUser_UserFollow] FOREIGN KEY ([UserFollowId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE ON UPDATE NO ACTION,
    CONSTRAINT [FK_UserFollowUser_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE NO ACTION ON UPDATE NO ACTION
);

