
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/13/2022 21:27:36
-- Generated from EDMX file: C:\Users\maria\Desktop\Wepp2\ProjetDir\Models\KnapsackDbEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KnapSackDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_Armes_Items]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Armes] DROP CONSTRAINT [fk_Armes_Items];
GO
IF OBJECT_ID(N'[dbo].[fk_Armes_TypesArmes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Armes] DROP CONSTRAINT [fk_Armes_TypesArmes];
GO
IF OBJECT_ID(N'[dbo].[fk_Armures_Items]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Armures] DROP CONSTRAINT [fk_Armures_Items];
GO
IF OBJECT_ID(N'[dbo].[FK_Collections_Items]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Collections] DROP CONSTRAINT [FK_Collections_Items];
GO
IF OBJECT_ID(N'[dbo].[FK_Collections_Joueurs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Collections] DROP CONSTRAINT [FK_Collections_Joueurs];
GO
IF OBJECT_ID(N'[dbo].[fk_Items_TypesItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Items] DROP CONSTRAINT [fk_Items_TypesItems];
GO
IF OBJECT_ID(N'[dbo].[fk_Medicaments_Items]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Medicaments] DROP CONSTRAINT [fk_Medicaments_Items];
GO
IF OBJECT_ID(N'[dbo].[FK_Munitions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Items] DROP CONSTRAINT [FK_Munitions];
GO
IF OBJECT_ID(N'[dbo].[fk_Paniers_Items]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Paniers] DROP CONSTRAINT [fk_Paniers_Items];
GO
IF OBJECT_ID(N'[dbo].[fk_Paniers_Joueurs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Paniers] DROP CONSTRAINT [fk_Paniers_Joueurs];
GO
IF OBJECT_ID(N'[dbo].[fk_ratings_items]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ratings] DROP CONSTRAINT [fk_ratings_items];
GO
IF OBJECT_ID(N'[dbo].[fk_ratings_joueurs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ratings] DROP CONSTRAINT [fk_ratings_joueurs];
GO
IF OBJECT_ID(N'[dbo].[fk_Sacs_Items]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sacs] DROP CONSTRAINT [fk_Sacs_Items];
GO
IF OBJECT_ID(N'[dbo].[fk_Sacs_Joueurs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sacs] DROP CONSTRAINT [fk_Sacs_Joueurs];
GO
IF OBJECT_ID(N'[dbo].[fk_Transactions_Joueurs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [fk_Transactions_Joueurs];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Armes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Armes];
GO
IF OBJECT_ID(N'[dbo].[Armures]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Armures];
GO
IF OBJECT_ID(N'[dbo].[Collections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Collections];
GO
IF OBJECT_ID(N'[dbo].[Items]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Items];
GO
IF OBJECT_ID(N'[dbo].[Joueurs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Joueurs];
GO
IF OBJECT_ID(N'[dbo].[Medicaments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Medicaments];
GO
IF OBJECT_ID(N'[dbo].[Paniers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Paniers];
GO
IF OBJECT_ID(N'[dbo].[Ratings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ratings];
GO
IF OBJECT_ID(N'[dbo].[Sacs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sacs];
GO
IF OBJECT_ID(N'[dbo].[Transactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transactions];
GO
IF OBJECT_ID(N'[dbo].[TypesArmes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypesArmes];
GO
IF OBJECT_ID(N'[dbo].[TypesItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypesItems];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Armes'
CREATE TABLE [dbo].[Armes] (
    [idItem] int  NOT NULL,
    [efficacite] int  NOT NULL,
    [type] int  NOT NULL
);
GO

-- Creating table 'Armures'
CREATE TABLE [dbo].[Armures] (
    [idItem] int  NOT NULL,
    [matiere] varchar(50)  NOT NULL,
    [taille] int  NOT NULL
);
GO

-- Creating table 'Items'
CREATE TABLE [dbo].[Items] (
    [idItem] int IDENTITY(1,1) NOT NULL,
    [nom] varchar(50)  NOT NULL,
    [idType] int  NOT NULL,
    [prix] decimal(19,4)  NOT NULL,
    [poid] decimal(5,1)  NOT NULL,
    [urlImage] varchar(500)  NOT NULL,
    [qte] int  NOT NULL,
    [disponibilite] bit  NULL,
    [description] varchar(500)  NULL,
    [TypesArme_idType] int  NULL
);
GO

-- Creating table 'Joueurs'
CREATE TABLE [dbo].[Joueurs] (
    [idJoueur] int IDENTITY(1,1) NOT NULL,
    [password] varbinary(256)  NOT NULL,
    [alias] varchar(25)  NOT NULL,
    [dexterite] int  NOT NULL,
    [poidMaximale] int  NOT NULL,
    [montantCaps] decimal(19,4)  NOT NULL,
    [isAdmin] bit  NOT NULL
);
GO

-- Creating table 'Medicaments'
CREATE TABLE [dbo].[Medicaments] (
    [idItem] int  NOT NULL,
    [effetAttendu] varchar(50)  NOT NULL,
    [dureeEffet] int  NOT NULL
);
GO

-- Creating table 'Paniers'
CREATE TABLE [dbo].[Paniers] (
    [idJoueur] int  NOT NULL,
    [idItem] int  NOT NULL,
    [qteItem] int  NOT NULL
);
GO

-- Creating table 'Ratings'
CREATE TABLE [dbo].[Ratings] (
    [idJoueur] int  NOT NULL,
    [rating] int  NOT NULL,
    [idItem] int  NOT NULL,
    [commentaire] varchar(200)  NOT NULL
);
GO

-- Creating table 'Sacs'
CREATE TABLE [dbo].[Sacs] (
    [idJoueur] int  NOT NULL,
    [qteItem] int  NOT NULL,
    [idItem] int  NOT NULL
);
GO

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transactions] (
    [idJoueur] int  NOT NULL,
    [montant] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'TypesArmes'
CREATE TABLE [dbo].[TypesArmes] (
    [idType] int IDENTITY(1,1) NOT NULL,
    [nom] varchar(25)  NOT NULL
);
GO

-- Creating table 'TypesItems'
CREATE TABLE [dbo].[TypesItems] (
    [idType] int IDENTITY(1,1) NOT NULL,
    [nomType] varchar(20)  NOT NULL
);
GO

-- Creating table 'Collections'
CREATE TABLE [dbo].[Collections] (
    [Items_idItem] int  NOT NULL,
    [Joueurs_idJoueur] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idItem] in table 'Armes'
ALTER TABLE [dbo].[Armes]
ADD CONSTRAINT [PK_Armes]
    PRIMARY KEY CLUSTERED ([idItem] ASC);
GO

-- Creating primary key on [idItem] in table 'Armures'
ALTER TABLE [dbo].[Armures]
ADD CONSTRAINT [PK_Armures]
    PRIMARY KEY CLUSTERED ([idItem] ASC);
GO

-- Creating primary key on [idItem] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [PK_Items]
    PRIMARY KEY CLUSTERED ([idItem] ASC);
GO

-- Creating primary key on [idJoueur] in table 'Joueurs'
ALTER TABLE [dbo].[Joueurs]
ADD CONSTRAINT [PK_Joueurs]
    PRIMARY KEY CLUSTERED ([idJoueur] ASC);
GO

-- Creating primary key on [idItem] in table 'Medicaments'
ALTER TABLE [dbo].[Medicaments]
ADD CONSTRAINT [PK_Medicaments]
    PRIMARY KEY CLUSTERED ([idItem] ASC);
GO

-- Creating primary key on [idJoueur] in table 'Paniers'
ALTER TABLE [dbo].[Paniers]
ADD CONSTRAINT [PK_Paniers]
    PRIMARY KEY CLUSTERED ([idJoueur] ASC);
GO

-- Creating primary key on [idJoueur], [idItem] in table 'Ratings'
ALTER TABLE [dbo].[Ratings]
ADD CONSTRAINT [PK_Ratings]
    PRIMARY KEY CLUSTERED ([idJoueur], [idItem] ASC);
GO

-- Creating primary key on [idJoueur] in table 'Sacs'
ALTER TABLE [dbo].[Sacs]
ADD CONSTRAINT [PK_Sacs]
    PRIMARY KEY CLUSTERED ([idJoueur] ASC);
GO

-- Creating primary key on [idJoueur] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([idJoueur] ASC);
GO

-- Creating primary key on [idType] in table 'TypesArmes'
ALTER TABLE [dbo].[TypesArmes]
ADD CONSTRAINT [PK_TypesArmes]
    PRIMARY KEY CLUSTERED ([idType] ASC);
GO

-- Creating primary key on [idType] in table 'TypesItems'
ALTER TABLE [dbo].[TypesItems]
ADD CONSTRAINT [PK_TypesItems]
    PRIMARY KEY CLUSTERED ([idType] ASC);
GO

-- Creating primary key on [Items_idItem], [Joueurs_idJoueur] in table 'Collections'
ALTER TABLE [dbo].[Collections]
ADD CONSTRAINT [PK_Collections]
    PRIMARY KEY CLUSTERED ([Items_idItem], [Joueurs_idJoueur] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idItem] in table 'Armes'
ALTER TABLE [dbo].[Armes]
ADD CONSTRAINT [fk_Armes_Items]
    FOREIGN KEY ([idItem])
    REFERENCES [dbo].[Items]
        ([idItem])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [type] in table 'Armes'
ALTER TABLE [dbo].[Armes]
ADD CONSTRAINT [fk_Armes_TypesArmes]
    FOREIGN KEY ([type])
    REFERENCES [dbo].[TypesArmes]
        ([idType])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Armes_TypesArmes'
CREATE INDEX [IX_fk_Armes_TypesArmes]
ON [dbo].[Armes]
    ([type]);
GO

-- Creating foreign key on [idItem] in table 'Armures'
ALTER TABLE [dbo].[Armures]
ADD CONSTRAINT [fk_Armures_Items]
    FOREIGN KEY ([idItem])
    REFERENCES [dbo].[Items]
        ([idItem])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idItem] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [fk_Items_TypesItems]
    FOREIGN KEY ([idItem])
    REFERENCES [dbo].[TypesItems]
        ([idType])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idItem] in table 'Medicaments'
ALTER TABLE [dbo].[Medicaments]
ADD CONSTRAINT [fk_Medicaments_Items]
    FOREIGN KEY ([idItem])
    REFERENCES [dbo].[Items]
        ([idItem])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idItem] in table 'Paniers'
ALTER TABLE [dbo].[Paniers]
ADD CONSTRAINT [fk_Paniers_Items]
    FOREIGN KEY ([idItem])
    REFERENCES [dbo].[Items]
        ([idItem])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Paniers_Items'
CREATE INDEX [IX_fk_Paniers_Items]
ON [dbo].[Paniers]
    ([idItem]);
GO

-- Creating foreign key on [idItem] in table 'Sacs'
ALTER TABLE [dbo].[Sacs]
ADD CONSTRAINT [fk_Sacs_Items]
    FOREIGN KEY ([idItem])
    REFERENCES [dbo].[Items]
        ([idItem])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Sacs_Items'
CREATE INDEX [IX_fk_Sacs_Items]
ON [dbo].[Sacs]
    ([idItem]);
GO

-- Creating foreign key on [idJoueur] in table 'Paniers'
ALTER TABLE [dbo].[Paniers]
ADD CONSTRAINT [fk_Paniers_Joueurs]
    FOREIGN KEY ([idJoueur])
    REFERENCES [dbo].[Joueurs]
        ([idJoueur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idJoueur] in table 'Sacs'
ALTER TABLE [dbo].[Sacs]
ADD CONSTRAINT [fk_Sacs_Joueurs]
    FOREIGN KEY ([idJoueur])
    REFERENCES [dbo].[Joueurs]
        ([idJoueur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [idJoueur] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [fk_Transactions_Joueurs]
    FOREIGN KEY ([idJoueur])
    REFERENCES [dbo].[Joueurs]
        ([idJoueur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TypesArme_idType] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [FK_Munitions]
    FOREIGN KEY ([TypesArme_idType])
    REFERENCES [dbo].[TypesArmes]
        ([idType])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Munitions'
CREATE INDEX [IX_FK_Munitions]
ON [dbo].[Items]
    ([TypesArme_idType]);
GO

-- Creating foreign key on [idItem] in table 'Ratings'
ALTER TABLE [dbo].[Ratings]
ADD CONSTRAINT [fk_ratings_items]
    FOREIGN KEY ([idItem])
    REFERENCES [dbo].[Items]
        ([idItem])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_ratings_items'
CREATE INDEX [IX_fk_ratings_items]
ON [dbo].[Ratings]
    ([idItem]);
GO

-- Creating foreign key on [idJoueur] in table 'Ratings'
ALTER TABLE [dbo].[Ratings]
ADD CONSTRAINT [fk_ratings_joueurs]
    FOREIGN KEY ([idJoueur])
    REFERENCES [dbo].[Joueurs]
        ([idJoueur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Items_idItem] in table 'Collections'
ALTER TABLE [dbo].[Collections]
ADD CONSTRAINT [FK_Collections_Item]
    FOREIGN KEY ([Items_idItem])
    REFERENCES [dbo].[Items]
        ([idItem])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Joueurs_idJoueur] in table 'Collections'
ALTER TABLE [dbo].[Collections]
ADD CONSTRAINT [FK_Collections_Joueur]
    FOREIGN KEY ([Joueurs_idJoueur])
    REFERENCES [dbo].[Joueurs]
        ([idJoueur])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Collections_Joueur'
CREATE INDEX [IX_FK_Collections_Joueur]
ON [dbo].[Collections]
    ([Joueurs_idJoueur]);
GO

-- Creating foreign key on [idType] in table 'Items'
ALTER TABLE [dbo].[Items]
ADD CONSTRAINT [fk_Items_TypesItems1]
    FOREIGN KEY ([idType])
    REFERENCES [dbo].[TypesItems]
        ([idType])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Items_TypesItems1'
CREATE INDEX [IX_fk_Items_TypesItems1]
ON [dbo].[Items]
    ([idType]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------