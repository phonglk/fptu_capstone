CREATE TABLE [dbo].[Category] (
    [CategoryId]       INT            IDENTITY (1, 1) NOT NULL,
    [CategoryName]     NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ParentCategoryId] INT            NULL,
    [Description]      NVARCHAR (MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
    CONSTRAINT [FK_Category_Category] FOREIGN KEY ([ParentCategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
);

