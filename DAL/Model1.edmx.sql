
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/05/2016 23:57:32
-- Generated from EDMX file: C:\Users\Heber\documents\visual studio 2013\Projects\GamerBacklog\DAL\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GamerBacklogDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[GameSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameSet];
GO
IF OBJECT_ID(N'[dbo].[PlatformSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlatformSet];
GO
IF OBJECT_ID(N'[dbo].[GamePlatformSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GamePlatformSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'GameSet'
CREATE TABLE [dbo].[GameSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Platform] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PlatformSet'
CREATE TABLE [dbo].[PlatformSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [GameId] int  NOT NULL
);
GO

-- Creating table 'GamePlatformSet'
CREATE TABLE [dbo].[GamePlatformSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GameId] int  NOT NULL,
    [PlatformId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'GameSet'
ALTER TABLE [dbo].[GameSet]
ADD CONSTRAINT [PK_GameSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlatformSet'
ALTER TABLE [dbo].[PlatformSet]
ADD CONSTRAINT [PK_PlatformSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'GamePlatformSet'
ALTER TABLE [dbo].[GamePlatformSet]
ADD CONSTRAINT [PK_GamePlatformSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [GameId] in table 'GamePlatformSet'
ALTER TABLE [dbo].[GamePlatformSet]
ADD CONSTRAINT [FK_GameGamePlatform]
    FOREIGN KEY ([GameId])
    REFERENCES [dbo].[GameSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GameGamePlatform'
CREATE INDEX [IX_FK_GameGamePlatform]
ON [dbo].[GamePlatformSet]
    ([GameId]);
GO

-- Creating foreign key on [PlatformId] in table 'GamePlatformSet'
ALTER TABLE [dbo].[GamePlatformSet]
ADD CONSTRAINT [FK_PlatformGamePlatform]
    FOREIGN KEY ([PlatformId])
    REFERENCES [dbo].[PlatformSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlatformGamePlatform'
CREATE INDEX [IX_FK_PlatformGamePlatform]
ON [dbo].[GamePlatformSet]
    ([PlatformId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------