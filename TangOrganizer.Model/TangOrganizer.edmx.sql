
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/05/2015 17:18:47
-- Generated from EDMX file: C:\Users\Caggiano\Source\Repos\SmartEvents\TangOrganizer.Model\TangOrganizer.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TangOrganizer];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EventoAttivita]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Attivita] DROP CONSTRAINT [FK_EventoAttivita];
GO
IF OBJECT_ID(N'[dbo].[FK_EventoPacchetto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pacchetto] DROP CONSTRAINT [FK_EventoPacchetto];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Attivita]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Attivita];
GO
IF OBJECT_ID(N'[dbo].[Evento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Evento];
GO
IF OBJECT_ID(N'[dbo].[Pacchetto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pacchetto];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Evento'
CREATE TABLE [dbo].[Evento] (
    [Id] uniqueidentifier  NOT NULL,
    [Nome] nvarchar(255)  NOT NULL,
    [Descrizione] nvarchar(max)  NULL,
    [DataInizio] datetime  NULL,
    [DataFine] datetime  NULL,
    [Luogo] nvarchar(300)  NOT NULL,
    [BaseInfo_DataCreazione] datetime  NULL,
    [BaseInfo_CreatoDa] nvarchar(255)  NULL,
    [BaseInfo_DataUltimaModifica] datetime  NULL,
    [BaseInfo_ModificatoDa] nvarchar(255)  NULL,
    [BaseInfo_Eliminato] bit  NOT NULL
);
GO

-- Creating table 'Attivita'
CREATE TABLE [dbo].[Attivita] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Tipo] int  NOT NULL,
    [Nome] nvarchar(100)  NOT NULL,
    [Maestri] nvarchar(100)  NULL,
    [Descrizione] nvarchar(max)  NULL,
    [DataInizio] datetime  NULL,
    [DataFine] datetime  NULL,
    [Luogo] nvarchar(300)  NULL,
    [LimiteIscrizioni] int  NULL,
    [BaseInfo_DataCreazione] datetime  NULL,
    [BaseInfo_CreatoDa] nvarchar(255)  NULL,
    [BaseInfo_DataUltimaModifica] datetime  NULL,
    [BaseInfo_ModificatoDa] nvarchar(255)  NULL,
    [BaseInfo_Eliminato] bit  NOT NULL,
    [EventoId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Pacchetto'
CREATE TABLE [dbo].[Pacchetto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(200)  NOT NULL,
    [Descrizione] nvarchar(max)  NULL,
    [Prezzo] decimal(18,2)  NULL,
    [BaseInfo_DataCreazione] datetime  NULL,
    [BaseInfo_CreatoDa] nvarchar(255)  NULL,
    [BaseInfo_DataUltimaModifica] datetime  NULL,
    [BaseInfo_ModificatoDa] nvarchar(255)  NULL,
    [BaseInfo_Eliminato] bit  NOT NULL,
    [EventoId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Evento'
ALTER TABLE [dbo].[Evento]
ADD CONSTRAINT [PK_Evento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Attivita'
ALTER TABLE [dbo].[Attivita]
ADD CONSTRAINT [PK_Attivita]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pacchetto'
ALTER TABLE [dbo].[Pacchetto]
ADD CONSTRAINT [PK_Pacchetto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EventoId] in table 'Attivita'
ALTER TABLE [dbo].[Attivita]
ADD CONSTRAINT [FK_EventoAttivita]
    FOREIGN KEY ([EventoId])
    REFERENCES [dbo].[Evento]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventoAttivita'
CREATE INDEX [IX_FK_EventoAttivita]
ON [dbo].[Attivita]
    ([EventoId]);
GO

-- Creating foreign key on [EventoId] in table 'Pacchetto'
ALTER TABLE [dbo].[Pacchetto]
ADD CONSTRAINT [FK_EventoPacchetto]
    FOREIGN KEY ([EventoId])
    REFERENCES [dbo].[Evento]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventoPacchetto'
CREATE INDEX [IX_FK_EventoPacchetto]
ON [dbo].[Pacchetto]
    ([EventoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------