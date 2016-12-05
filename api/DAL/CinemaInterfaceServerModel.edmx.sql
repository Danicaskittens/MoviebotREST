
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/05/2016 18:17:55
-- Generated from EDMX file: D:\projects\MoviebotREST\api\DAL\CinemaInterfaceServerModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MovieBotContext];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProjectionMovie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectionSet] DROP CONSTRAINT [FK_ProjectionMovie];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectionCinema]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectionSet] DROP CONSTRAINT [FK_ProjectionCinema];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MovieSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovieSet];
GO
IF OBJECT_ID(N'[dbo].[CinemaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CinemaSet];
GO
IF OBJECT_ID(N'[dbo].[ProjectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectionSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MovieSet'
CREATE TABLE [dbo].[MovieSet] (
    [MovieId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Year] nvarchar(max)  NOT NULL,
    [Rated] nvarchar(max)  NOT NULL,
    [Released] nvarchar(max)  NOT NULL,
    [Runtime] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NOT NULL,
    [Director] nvarchar(max)  NOT NULL,
    [Writer] nvarchar(max)  NOT NULL,
    [Actors] nvarchar(max)  NOT NULL,
    [Plot] nvarchar(max)  NOT NULL,
    [Language] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [Awards] nvarchar(max)  NOT NULL,
    [Poster] nvarchar(max)  NOT NULL,
    [Metascore] nvarchar(max)  NOT NULL,
    [imdbRating] nvarchar(max)  NOT NULL,
    [imdbVotes] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Response] nvarchar(max)  NOT NULL,
    [inTheaters] nvarchar(max)  NOT NULL,
    [ImdbId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CinemaSet'
CREATE TABLE [dbo].[CinemaSet] (
    [CinemaId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Latitude] float  NOT NULL,
    [Longitude] float  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [Region] nvarchar(max)  NOT NULL,
    [Province] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [State] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProjectionSet'
CREATE TABLE [dbo].[ProjectionSet] (
    [ProjectionId] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [FreeSeats] int  NOT NULL,
    [CinemaId] nvarchar(max)  NOT NULL,
    [ImdbId] nvarchar(max)  NOT NULL,
    [Movie_MovieId] int  NOT NULL,
    [Cinema_CinemaId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MovieId] in table 'MovieSet'
ALTER TABLE [dbo].[MovieSet]
ADD CONSTRAINT [PK_MovieSet]
    PRIMARY KEY CLUSTERED ([MovieId] ASC);
GO

-- Creating primary key on [CinemaId] in table 'CinemaSet'
ALTER TABLE [dbo].[CinemaSet]
ADD CONSTRAINT [PK_CinemaSet]
    PRIMARY KEY CLUSTERED ([CinemaId] ASC);
GO

-- Creating primary key on [ProjectionId] in table 'ProjectionSet'
ALTER TABLE [dbo].[ProjectionSet]
ADD CONSTRAINT [PK_ProjectionSet]
    PRIMARY KEY CLUSTERED ([ProjectionId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Movie_MovieId] in table 'ProjectionSet'
ALTER TABLE [dbo].[ProjectionSet]
ADD CONSTRAINT [FK_ProjectionMovie]
    FOREIGN KEY ([Movie_MovieId])
    REFERENCES [dbo].[MovieSet]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectionMovie'
CREATE INDEX [IX_FK_ProjectionMovie]
ON [dbo].[ProjectionSet]
    ([Movie_MovieId]);
GO

-- Creating foreign key on [Cinema_CinemaId] in table 'ProjectionSet'
ALTER TABLE [dbo].[ProjectionSet]
ADD CONSTRAINT [FK_ProjectionCinema]
    FOREIGN KEY ([Cinema_CinemaId])
    REFERENCES [dbo].[CinemaSet]
        ([CinemaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectionCinema'
CREATE INDEX [IX_FK_ProjectionCinema]
ON [dbo].[ProjectionSet]
    ([Cinema_CinemaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------