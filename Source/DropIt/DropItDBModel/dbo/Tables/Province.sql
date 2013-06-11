CREATE TABLE [dbo].[Province] (
    [ProvinceId]   INT           IDENTITY (1, 1) NOT NULL,
    [ProvinceName] NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    CONSTRAINT [PK_Province] PRIMARY KEY CLUSTERED ([ProvinceId] ASC)
);





