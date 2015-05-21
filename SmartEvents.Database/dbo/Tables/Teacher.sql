CREATE TABLE [dbo].[Teacher] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (255) NULL,
    [LastName]            NVARCHAR (255) NULL,
    [FullName]            NVARCHAR (MAX) NULL,
    [Email]               NVARCHAR (255) NULL,
    [AuthInfo_Created]    DATETIME       NOT NULL,
    [AuthInfo_CreatedBy]  NVARCHAR (255) NOT NULL,
    [AuthInfo_Modified]   DATETIME       NOT NULL,
    [AuthInfo_ModifiedBy] NVARCHAR (255) NOT NULL,
    [IsDeleted]           BIT            NOT NULL,
    CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED ([Id] ASC)
);

