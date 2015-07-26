CREATE TABLE [dbo].[Evento] (
    [Id]                          UNIQUEIDENTIFIER CONSTRAINT [DF_Evento_Id] DEFAULT (newid()) NOT NULL,
    [Nome]                        NVARCHAR (255)   NOT NULL,
    [Descrizione]                 NVARCHAR (MAX)   NULL,
    [Cancellato]                  BIT              CONSTRAINT [DF_Evento_Cancellato] DEFAULT ((0)) NOT NULL,
    [DataInizio]                  DATETIME         NOT NULL,
    [DataFine]                    DATETIME         NOT NULL,
    [Luogo]                       NVARCHAR (255)   NULL,
    [AuthInfo_DataCreazione]      DATETIME         CONSTRAINT [DF_Evento_AuthInfo_DataCreazione] DEFAULT (getdate()) NOT NULL,
    [AuthInfo_CreatoDa]           NVARCHAR (100)   NOT NULL,
    [AuthInfo_DataUltimaModifica] DATETIME         NOT NULL,
    [AuthInfo_ModificatoDa]       NVARCHAR (100)   NOT NULL,
    [AuthInfo_UserId]             NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED ([Id] ASC)
);

