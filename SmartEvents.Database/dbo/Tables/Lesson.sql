CREATE TABLE [dbo].[Lesson] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [Name]                NVARCHAR (MAX) NOT NULL,
    [Description]         NVARCHAR (MAX) NULL,
    [AuthInfo_Created]    DATETIME       NOT NULL,
    [AuthInfo_CreatedBy]  NVARCHAR (255) NOT NULL,
    [AuthInfo_Modified]   DATETIME       NOT NULL,
    [AuthInfo_ModifiedBy] NVARCHAR (255) NOT NULL,
    [IsDeleted]           BIT            NOT NULL,
    CONSTRAINT [PK_Lesson] PRIMARY KEY CLUSTERED ([Id] ASC)
);

