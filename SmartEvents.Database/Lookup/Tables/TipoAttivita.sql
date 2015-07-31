CREATE TABLE [Lookup].[TipoAttivita] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Descrizione] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_TipoAttivita] PRIMARY KEY CLUSTERED ([Id] ASC)
);

