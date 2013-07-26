CREATE TABLE [dbo].[Notification] (
    [NotificationId] INT            NOT NULL,
    [Content]        NVARCHAR (MAX) NOT NULL,
    [IsRead]         BIT            DEFAULT ((0)) NOT NULL,
    [CreatedDate]    DATETIME       NULL,
    [ModifiedDate]   DATETIME       NULL,
    [UserId]         INT            NULL,
    PRIMARY KEY CLUSTERED ([NotificationId] ASC),
    CONSTRAINT [FK_UserId_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

