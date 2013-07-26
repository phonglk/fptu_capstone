CREATE TABLE [dbo].[UserFollowVenue] (
    [UserFollowVenueId] INT IDENTITY (1, 1) NOT NULL,
    [UserId]        INT NOT NULL,
    [VenueId]       INT NOT NULL,
	[FollowType] INT NOT NULL DEFAULT 2, 
    CONSTRAINT [PK_UserFollowVenue] PRIMARY KEY CLUSTERED ([UserFollowVenueId] ASC),
    CONSTRAINT [FK_UserFollowVenue_Venue] FOREIGN KEY ([VenueId]) REFERENCES [dbo].[Venue] ([VenueId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_UserFollowVenue_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE ON UPDATE CASCADE
);

