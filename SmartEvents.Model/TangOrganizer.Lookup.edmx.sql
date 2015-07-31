
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/31/2015 15:32:06
-- Generated from EDMX file: C:\Users\Caggiano\Source\Repos\SmartEvents\SmartEvents.Model\TangOrganizer.Lookup.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TangOrganizer];
GO
IF SCHEMA_ID(N'Lookup') IS NULL EXECUTE(N'CREATE SCHEMA [Lookup]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TipoAttivita'
CREATE TABLE [Lookup].[TipoAttivita] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descrizione] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TipoAttivita'
ALTER TABLE [Lookup].[TipoAttivita]
ADD CONSTRAINT [PK_TipoAttivita]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------