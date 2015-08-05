CREATE TABLE [dbo].[Pacchetto] (
    [Id]                          INT              IDENTITY (1, 1) NOT NULL,
    [Nome]                        NVARCHAR (200)   NOT NULL,
    [Descrizione]                 NVARCHAR (MAX)   NULL,
    [Prezzo]                      DECIMAL (18, 2)  DEFAULT ((0)) NULL,
    [BaseInfo_DataCreazione]      DATETIME         DEFAULT (getdate()) NULL,
    [BaseInfo_CreatoDa]           NVARCHAR (255)   NULL,
    [BaseInfo_DataUltimaModifica] DATETIME         DEFAULT (getdate()) NULL,
    [BaseInfo_ModificatoDa]       NVARCHAR (255)   NULL,
    [EventoId]                    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Pacchetto] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EventoPacchetto] FOREIGN KEY ([EventoId]) REFERENCES [dbo].[Evento] ([Id])
);






GO
CREATE NONCLUSTERED INDEX [IX_FK_EventoPacchetto]
    ON [dbo].[Pacchetto]([EventoId] ASC);


GO
CREATE TRIGGER [dbo].[Pacchetto_After_Update] ON Pacchetto	AFTER Update AS 
					 BEGIN
						-- Recupero l'Id dell'ultima riga inserita
						declare @rowId as int;
						select @rowId= i.Id from inserted i; 
	
						-- Salvo data ultima modifica
						update Pacchetto
						set BaseInfo_DataUltimaModifica = GETDATE()
						where Id in (select Id from inserted i);    
						 END