
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/21/2015 23:41:30
-- Generated from EDMX file: E:\Lavori\Repos\SmartEvents\SmartEvents.Model\SmartEvents.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SmartEvents];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[Lesson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lesson];
GO
IF OBJECT_ID(N'[dbo].[Teacher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teacher];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [AuthInfo_Created] datetime  NOT NULL,
    [AuthInfo_CreatedBy] nvarchar(255)  NOT NULL,
    [AuthInfo_Modified] datetime  NOT NULL,
    [AuthInfo_ModifiedBy] nvarchar(255)  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Lesson'
CREATE TABLE [dbo].[Lesson] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [AuthInfo_Created] datetime  NOT NULL,
    [AuthInfo_CreatedBy] nvarchar(255)  NOT NULL,
    [AuthInfo_Modified] datetime  NOT NULL,
    [AuthInfo_ModifiedBy] nvarchar(255)  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Teacher'
CREATE TABLE [dbo].[Teacher] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NULL,
    [LastName] nvarchar(255)  NULL,
    [FullName] nvarchar(max)  NULL,
    [Email] nvarchar(255)  NULL,
    [AuthInfo_Created] datetime  NOT NULL,
    [AuthInfo_CreatedBy] nvarchar(255)  NOT NULL,
    [AuthInfo_Modified] datetime  NOT NULL,
    [AuthInfo_ModifiedBy] nvarchar(255)  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lesson'
ALTER TABLE [dbo].[Lesson]
ADD CONSTRAINT [PK_Lesson]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Teacher'
ALTER TABLE [dbo].[Teacher]
ADD CONSTRAINT [PK_Teacher]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------