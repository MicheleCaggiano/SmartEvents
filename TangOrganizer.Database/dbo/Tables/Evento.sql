CREATE TABLE [dbo].[Evento] (
    [Id]                          UNIQUEIDENTIFIER NOT NULL DEFAULT newid(),
    [Nome]                        NVARCHAR (255)   NOT NULL,
    [Descrizione]                 NVARCHAR (MAX)   NULL,
    [DataInizio]                  DATETIME         NULL,
    [DataFine]                    DATETIME         NULL,
    [Luogo]                       NVARCHAR (300)   NOT NULL,
    [Cancellato]                  BIT              DEFAULT ((0)) NULL,
    [BaseInfo_DataCreazione]      DATETIME         DEFAULT (getdate()) NULL,
    [BaseInfo_CreatoDa]           NVARCHAR (255)   NULL,
    [BaseInfo_DataUltimaModifica] DATETIME         DEFAULT (getdate()) NULL,
    [BaseInfo_ModificatoDa]       NVARCHAR (255)   NULL,
    CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED ([Id] ASC)
);






GO
CREATE TRIGGER [dbo].[Evento_After_Update] ON Evento	AFTER Update AS 
					 BEGIN
						-- Recupero l'Id dell'ultima riga inserita
						declare @rowId as uniqueidentifier;
						select @rowId= i.Id from inserted i; 
	
						-- Salvo data ultima modifica
						update Evento
						set BaseInfo_DataUltimaModifica = GETDATE()
						where Id in (select Id from inserted i);    
						 END