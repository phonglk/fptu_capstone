CREATE TABLE [dbo].[User] (
    [UserId]       INT            IDENTITY (1, 1) NOT NULL,
    [UserName]     NVARCHAR (50)  NOT NULL,
    [Password]     NVARCHAR (50)  NOT NULL,
    [Email]        NVARCHAR (50)  NOT NULL,
    [Phone]        NVARCHAR (50)  NOT NULL,
    [Address]      NVARCHAR (MAX) NOT NULL,
    [Active]       BIT            NOT NULL,
    [Sellable]     BIT            NOT NULL,
    [Role]         INT            NOT NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedDate] ROWVERSION     NOT NULL,
    [ProvinceId]   INT            NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_User_Province] FOREIGN KEY ([ProvinceId]) REFERENCES [dbo].[Province] ([ProvinceId])
);



