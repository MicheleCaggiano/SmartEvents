CREATE TABLE [dbo].[Pacchetto] (
    [Id]          INT              IDENTITY (1, 1) NOT NULL,
    [Nome]        NVARCHAR (200)   NOT NULL,
    [Descrizione] NVARCHAR (MAX)   NULL,
    [Prezzo]      DECIMAL (18, 2)  NULL,
    [EventoId]    UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Pacchetto] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EventoPacchetto] FOREIGN KEY ([EventoId]) REFERENCES [dbo].[Evento] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_EventoPacchetto]
    ON [dbo].[Pacchetto]([EventoId] ASC);

