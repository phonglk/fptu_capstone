CREATE TABLE [dbo].[User] (
    [UserId]       INT            IDENTITY (1, 1) NOT NULL,
    [UserName]     NVARCHAR (50)  NOT NULL,
    [FullName]     NVARCHAR (50)  NULL,
    [Email]        NVARCHAR (50)  NOT NULL,
    [Phone]        NVARCHAR (50)  NOT NULL,
    [Address]      NVARCHAR (MAX) NOT NULL,
    [Active]       BIT            CONSTRAINT [DF_User_Active] DEFAULT ((1)) NOT NULL,
    [IsVerified]   BIT            CONSTRAINT [DF_User_IsVerified] DEFAULT ((0)) NOT NULL,
    [BankName]     NVARCHAR (50)  NULL,
    [BankAccount]  NVARCHAR (50)  NULL,
    [CMND]         NVARCHAR (10)  NULL,
    [Sellable]     BIT            CONSTRAINT [DF_User_Sellable] DEFAULT ((0)) NOT NULL,
    [CreatedDate]  DATETIME       NULL,
    [ModifiedDate] DATETIME       NULL,
    [ProvinceId]   INT            NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_User_Province] FOREIGN KEY ([ProvinceId]) REFERENCES [dbo].[Province] ([ProvinceId])
);













