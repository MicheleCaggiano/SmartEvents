CREATE TABLE [dbo].[Attivita] (
    [Id]                          INT              IDENTITY (1, 1) NOT NULL,
    [Tipo]                        INT              NOT NULL,
    [Nome]                        NVARCHAR (MAX)   NOT NULL,
    [Descrizione]                 NVARCHAR (MAX)   NULL,
    [DataInizio]                  DATETIME         NULL,
    [DataFine]                    DATETIME         NULL,
    [Luogo]                       NVARCHAR (300)   NOT NULL,
    [LimiteIscrizioni]            INT              NOT NULL,
    [Cancellato]                  BIT              NOT NULL,
    [AuthInfo_DataCreazione]      DATETIME         NOT NULL,
    [AuthInfo_CreatoDa]           NVARCHAR (255)   NOT NULL,
    [AuthInfo_DataUltimaModifica] DATETIME         NOT NULL,
    [AuthInfo_ModificatoDa]       NVARCHAR (255)   NOT NULL,
    [AuthInfo_UserId]             NVARCHAR (100)   NOT NULL,
    [EventoId]                    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Attivita] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EventoAttivita] FOREIGN KEY ([EventoId]) REFERENCES [dbo].[Evento] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_EventoAttivita]
    ON [dbo].[Attivita]([EventoId] ASC);

