CREATE TABLE [dbo].[Evento] (
    [Id]                          UNIQUEIDENTIFIER NOT NULL,
    [Nome]                        NVARCHAR (255)   NOT NULL,
    [Descrizione]                 NVARCHAR (MAX)   NULL,
    [DataInizio]                  DATETIME         NULL,
    [DataFine]                    DATETIME         NULL,
    [Luogo]                       NVARCHAR (300)   NOT NULL,
    [Cancellato]                  BIT              NOT NULL,
    [AuthInfo_DataCreazione]      DATETIME         NOT NULL,
    [AuthInfo_CreatoDa]           NVARCHAR (255)   NOT NULL,
    [AuthInfo_DataUltimaModifica] DATETIME         NOT NULL,
    [AuthInfo_ModificatoDa]       NVARCHAR (255)   NOT NULL,
    [AuthInfo_UserId]             NVARCHAR (100)   NULL,
    CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED ([Id] ASC)
);



