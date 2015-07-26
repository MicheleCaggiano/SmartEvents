
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/25/2015 15:14:57
-- Generated from EDMX file: E:\Lavori\Repos\SmartEvents\SmartEvents.Model\TangOrganizer.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Evento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Evento];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Evento'
CREATE TABLE [dbo].[Evento] (
    [Id] uniqueidentifier  NOT NULL,
    [Nome] nvarchar(255)  NOT NULL,
    [Descrizione] nvarchar(max)  NULL,
    [Cancellato] bit  NOT NULL,
    [DataInizio] datetime  NULL,
    [DataFine] datetime  NULL,
    [Luogo] nvarchar(300)  NOT NULL,
    [AuthInfo_DataCreazione] datetime  NOT NULL,
    [AuthInfo_CreatoDa] nvarchar(255)  NOT NULL,
    [AuthInfo_DataUltimaModifica] datetime  NOT NULL,
    [AuthInfo_ModificatoDa] nvarchar(255)  NOT NULL,
    [AuthInfo_UserId] nvarchar(100)  NOT NULL
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

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------