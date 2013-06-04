CREATE TABLE [dbo].[Category] (
    [CategoryId]       INT            IDENTITY (1, 1) NOT NULL,
    [CategoryName]     NVARCHAR (50)  NOT NULL,
    [ParentCategoryId] INT            NULL,
    [Status]           INT            NOT NULL,
    [Description]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
    CONSTRAINT [FK_Category_Category] FOREIGN KEY ([ParentCategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
);



