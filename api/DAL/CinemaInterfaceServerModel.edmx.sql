
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/06/2016 16:46:29
-- Generated from EDMX file: D:\projects\MoviebotREST\api\DAL\CinemaInterfaceServerModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CinemaInterface ServerModelContext];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ProjectionMovie]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projections] DROP CONSTRAINT [FK_ProjectionMovie];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectionCinema]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projections] DROP CONSTRAINT [FK_ProjectionCinema];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Movies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movies];
GO
IF OBJECT_ID(N'[dbo].[Cinemas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cinemas];
GO
IF OBJECT_ID(N'[dbo].[Projections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projections];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Movies'
CREATE TABLE [dbo].[Movies] (
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

-- Creating table 'Cinemas'
CREATE TABLE [dbo].[Cinemas] (
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

-- Creating table 'Projections'
CREATE TABLE [dbo].[Projections] (
    [ProjectionId] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [FreeSeats] int  NOT NULL,
    [CinemaId] int  NOT NULL,
    [ImdbId] nvarchar(max)  NOT NULL,
    [Movie_MovieId] int  NOT NULL,
    [Cinema_CinemaId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MovieId] in table 'Movies'
ALTER TABLE [dbo].[Movies]
ADD CONSTRAINT [PK_Movies]
    PRIMARY KEY CLUSTERED ([MovieId] ASC);
GO

-- Creating primary key on [CinemaId] in table 'Cinemas'
ALTER TABLE [dbo].[Cinemas]
ADD CONSTRAINT [PK_Cinemas]
    PRIMARY KEY CLUSTERED ([CinemaId] ASC);
GO

-- Creating primary key on [ProjectionId] in table 'Projections'
ALTER TABLE [dbo].[Projections]
ADD CONSTRAINT [PK_Projections]
    PRIMARY KEY CLUSTERED ([ProjectionId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Movie_MovieId] in table 'Projections'
ALTER TABLE [dbo].[Projections]
ADD CONSTRAINT [FK_ProjectionMovie]
    FOREIGN KEY ([Movie_MovieId])
    REFERENCES [dbo].[Movies]
        ([MovieId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectionMovie'
CREATE INDEX [IX_FK_ProjectionMovie]
ON [dbo].[Projections]
    ([Movie_MovieId]);
GO

-- Creating foreign key on [Cinema_CinemaId] in table 'Projections'
ALTER TABLE [dbo].[Projections]
ADD CONSTRAINT [FK_ProjectionCinema]
    FOREIGN KEY ([Cinema_CinemaId])
    REFERENCES [dbo].[Cinemas]
        ([CinemaId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectionCinema'
CREATE INDEX [IX_FK_ProjectionCinema]
ON [dbo].[Projections]
    ([Cinema_CinemaId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------