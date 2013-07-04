CREATE TABLE [dbo].[Setting] (
    [Id]          INT           NOT NULL,
    [SettingName] NVARCHAR (50) NOT NULL,
    [Value]       NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Setting] PRIMARY KEY CLUSTERED ([Id] ASC)
);

