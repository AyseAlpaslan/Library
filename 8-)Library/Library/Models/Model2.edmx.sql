
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/25/2022 13:37:37
-- Generated from EDMX file: C:\Users\Dell\Desktop\son\Library\Library\Models\Model2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Kutuphane];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
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

-- Creating table 'KitaplarSet'
CREATE TABLE [dbo].[KitaplarSet] (
    [KitaplarId] int IDENTITY(1,1) NOT NULL,
    [KitapTuru] nvarchar(max)  NOT NULL,
    [KitapAdi] nvarchar(max)  NOT NULL,
    [YazarAdSoyad] nvarchar(max)  NOT NULL,
    [SayfaSayisi] int  NOT NULL
);
GO

-- Creating table 'OkurSet'
CREATE TABLE [dbo].[OkurSet] (
    [OkurId] int IDENTITY(1,1) NOT NULL,
    [OkurAdSoyad] nvarchar(max)  NOT NULL,
    [OkurTelefonu] nvarchar(max)  NOT NULL,
    [OkurDogumTarihi] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AdminSet'
CREATE TABLE [dbo].[AdminSet] (
    [Uid1] int IDENTITY(1,1) NOT NULL,
    [Name1] nvarchar(max)  NOT NULL,
    [UserId] nvarchar(max)  NOT NULL,
    [Password1] nvarchar(max)  NOT NULL,
    [isActive] tinyint  NOT NULL,
    [Role] int  NOT NULL,
    [createdon] datetime  NOT NULL
);
GO

-- Creating table 'OduncSet'
CREATE TABLE [dbo].[OduncSet] (
    [OduncId] int IDENTITY(1,1) NOT NULL,
    [AldigiTarih] nvarchar(max)  NOT NULL,
    [VerecegiTarih] nvarchar(max)  NOT NULL,
    [KitaplarId] int  NOT NULL,
    [OkurId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [KitaplarId] in table 'KitaplarSet'
ALTER TABLE [dbo].[KitaplarSet]
ADD CONSTRAINT [PK_KitaplarSet]
    PRIMARY KEY CLUSTERED ([KitaplarId] ASC);
GO

-- Creating primary key on [OkurId] in table 'OkurSet'
ALTER TABLE [dbo].[OkurSet]
ADD CONSTRAINT [PK_OkurSet]
    PRIMARY KEY CLUSTERED ([OkurId] ASC);
GO

-- Creating primary key on [Uid1] in table 'AdminSet'
ALTER TABLE [dbo].[AdminSet]
ADD CONSTRAINT [PK_AdminSet]
    PRIMARY KEY CLUSTERED ([Uid1] ASC);
GO

-- Creating primary key on [OduncId] in table 'OduncSet'
ALTER TABLE [dbo].[OduncSet]
ADD CONSTRAINT [PK_OduncSet]
    PRIMARY KEY CLUSTERED ([OduncId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KitaplarId] in table 'OduncSet'
ALTER TABLE [dbo].[OduncSet]
ADD CONSTRAINT [FK_KitaplarOdunc]
    FOREIGN KEY ([KitaplarId])
    REFERENCES [dbo].[KitaplarSet]
        ([KitaplarId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KitaplarOdunc'
CREATE INDEX [IX_FK_KitaplarOdunc]
ON [dbo].[OduncSet]
    ([KitaplarId]);
GO

-- Creating foreign key on [OkurId] in table 'OduncSet'
ALTER TABLE [dbo].[OduncSet]
ADD CONSTRAINT [FK_OkurOdunc]
    FOREIGN KEY ([OkurId])
    REFERENCES [dbo].[OkurSet]
        ([OkurId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OkurOdunc'
CREATE INDEX [IX_FK_OkurOdunc]
ON [dbo].[OduncSet]
    ([OkurId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------