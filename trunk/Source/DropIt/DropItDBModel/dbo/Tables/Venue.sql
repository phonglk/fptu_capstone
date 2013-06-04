CREATE TABLE [dbo].[Venue] (
    [VenueId]     INT            IDENTITY (1, 1) NOT NULL,
    [VenueName]   NVARCHAR (50)  NOT NULL,
    [Address]     NVARCHAR (MAX) NOT NULL,
    [ProvinceId]  INT            NOT NULL,
    [Status]      INT            NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Venue] PRIMARY KEY CLUSTERED ([VenueId] ASC),
    CONSTRAINT [FK_Venue_Province] FOREIGN KEY ([ProvinceId]) REFERENCES [dbo].[Province] ([ProvinceId])
);



