CREATE TABLE [dbo].[Notification] (
    [NotificationId] INT            NOT NULL,
	  [UserId]         INT            NULL,
    [SenderId] INT NULL, 
    [ActivityType] NVARCHAR(50) NULL, 
    [ObjectType] NVARCHAR(50) NULL, 
	[ObjectTitle] NVARCHAR(250) NULL, 
	[ObjectUrl] NVARCHAR(MAX) NULL, 
    [Content]        NVARCHAR (MAX) NULL,
    [IsUnread]         BIT            DEFAULT 1 NOT NULL,
    [CreatedDate]    DATETIME       NULL,
    [ModifiedDate]   DATETIME       NULL,
  
    
    
    CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED ([NotificationId] ASC),
    CONSTRAINT [FK_UserId_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

