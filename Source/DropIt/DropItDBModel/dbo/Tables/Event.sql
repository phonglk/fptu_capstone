CREATE TABLE [dbo].[Event] (
    [EventId]      INT            IDENTITY (1, 1) NOT NULL,
    [EventName]    NVARCHAR (50)  NOT NULL,
    [HoldDate]     DATETIME       NOT NULL,
    [Description]  NVARCHAR (MAX) NULL,
    [Status]       INT            NOT NULL,
    [CategoryId]   INT            NOT NULL,
    [VenueId]      INT            NOT NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedDate] DATETIME       NOT NULL,
    CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([EventId] ASC),
    CONSTRAINT [FK_Event_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Event_Venue] FOREIGN KEY ([VenueId]) REFERENCES [dbo].[Venue] ([VenueId]) ON DELETE CASCADE ON UPDATE CASCADE
);

