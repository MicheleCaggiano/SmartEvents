CREATE TABLE [dbo].[Attivita] (
    [Id]                          INT              IDENTITY (1, 1) NOT NULL,
    [Tipo]                        INT              NOT NULL,
    [Nome]                        NVARCHAR (100)   NOT NULL,
    [Maestri]                     NVARCHAR (100)   NULL,
    [Descrizione]                 NVARCHAR (MAX)   NULL,
    [DataInizio]                  DATETIME         NULL,
    [DataFine]                    DATETIME         NULL,
    [Luogo]                       NVARCHAR (300)   NULL,
    [LimiteIscrizioni]            INT              DEFAULT ((0)) NULL,
    [Cancellato]                  BIT              NOT NULL,
    [BaseInfo_DataCreazione]      DATETIME         DEFAULT (getdate()) NULL,
    [BaseInfo_CreatoDa]           NVARCHAR (255)   NULL,
    [BaseInfo_DataUltimaModifica] DATETIME         DEFAULT (getdate()) NULL,
    [BaseInfo_ModificatoDa]       NVARCHAR (255)   NULL,
    [EventoId]                    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Attivita] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EventoAttivita] FOREIGN KEY ([EventoId]) REFERENCES [dbo].[Evento] ([Id])
);






GO
CREATE NONCLUSTERED INDEX [IX_FK_EventoAttivita]
    ON [dbo].[Attivita]([EventoId] ASC);


GO
CREATE TRIGGER [dbo].[Attivita_After_Update] ON Attivita	AFTER Update AS 
					 BEGIN
						-- Recupero l'Id dell'ultima riga inserita
						declare @rowId as int;
						select @rowId= i.Id from inserted i; 
	
						-- Salvo data ultima modifica
						update Attivita
						set BaseInfo_DataUltimaModifica = GETDATE()
						where Id in (select Id from inserted i);    
						 END