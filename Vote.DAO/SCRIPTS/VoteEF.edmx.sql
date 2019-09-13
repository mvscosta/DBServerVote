
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/15/2017 03:07:35
-- Generated from EDMX file: C:\Users\vinic\documents\visual studio 2017\Projects\Vote\Vote.DAO\VoteEF.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [vote];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Restaurantes_Categorias]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Restaurantes] DROP CONSTRAINT [FK_Restaurantes_Categorias];
GO
IF OBJECT_ID(N'[dbo].[FK_Restaurantes_Modalidades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Restaurantes] DROP CONSTRAINT [FK_Restaurantes_Modalidades];
GO
IF OBJECT_ID(N'[dbo].[FK_Votos_Funcionarios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Votos] DROP CONSTRAINT [FK_Votos_Funcionarios];
GO
IF OBJECT_ID(N'[dbo].[FK_Votos_Restaurantes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Votos] DROP CONSTRAINT [FK_Votos_Restaurantes];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categorias];
GO
IF OBJECT_ID(N'[dbo].[Funcionarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Funcionarios];
GO
IF OBJECT_ID(N'[dbo].[Modalidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Modalidades];
GO
IF OBJECT_ID(N'[dbo].[Restaurantes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Restaurantes];
GO
IF OBJECT_ID(N'[dbo].[Votos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Votos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Restaurantes'
CREATE TABLE [dbo].[Restaurantes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdCategoria] int  NOT NULL,
    [IdModalidade] int  NOT NULL,
    [DistanciaMedia] decimal(8,2)  NULL,
    [Endereco] nvarchar(500)  NULL,
    [Nome] nvarchar(500)  NOT NULL,
    [ValorMedio] decimal(18,9)  NULL,
	[Ativo] bit NOT NULL DEFAULT(1)
);
GO

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Modalidades'
CREATE TABLE [dbo].[Modalidades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descricao] nvarchar(max)  NOT NULL,
    [Titulo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Funcionarios'
CREATE TABLE [dbo].[Funcionarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ativo] bit  NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Administrador] bit  NOT NULL
);
GO

-- Creating table 'Votos'
CREATE TABLE [dbo].[Votos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdRestaurante] int  NOT NULL,
    [IdFuncionario] int  NOT NULL,
    [DataVoto] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Restaurantes'
ALTER TABLE [dbo].[Restaurantes]
ADD CONSTRAINT [PK_Restaurantes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Modalidades'
ALTER TABLE [dbo].[Modalidades]
ADD CONSTRAINT [PK_Modalidades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Funcionarios'
ALTER TABLE [dbo].[Funcionarios]
ADD CONSTRAINT [PK_Funcionarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Votos'
ALTER TABLE [dbo].[Votos]
ADD CONSTRAINT [PK_Votos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdCategoria] in table 'Restaurantes'
ALTER TABLE [dbo].[Restaurantes]
ADD CONSTRAINT [FK_Restaurantes_Categorias]
    FOREIGN KEY ([IdCategoria])
    REFERENCES [dbo].[Categorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Restaurantes_Categorias'
CREATE INDEX [IX_FK_Restaurantes_Categorias]
ON [dbo].[Restaurantes]
    ([IdCategoria]);
GO

-- Creating foreign key on [IdFuncionario] in table 'Votos'
ALTER TABLE [dbo].[Votos]
ADD CONSTRAINT [FK_Votos_Funcionarios]
    FOREIGN KEY ([IdFuncionario])
    REFERENCES [dbo].[Funcionarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Votos_Funcionarios'
CREATE INDEX [IX_FK_Votos_Funcionarios]
ON [dbo].[Votos]
    ([IdFuncionario]);
GO

-- Creating foreign key on [IdModalidade] in table 'Restaurantes'
ALTER TABLE [dbo].[Restaurantes]
ADD CONSTRAINT [FK_Restaurantes_Modalidades]
    FOREIGN KEY ([IdModalidade])
    REFERENCES [dbo].[Modalidades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Restaurantes_Modalidades'
CREATE INDEX [IX_FK_Restaurantes_Modalidades]
ON [dbo].[Restaurantes]
    ([IdModalidade]);
GO

-- Creating foreign key on [IdRestaurante] in table 'Votos'
ALTER TABLE [dbo].[Votos]
ADD CONSTRAINT [FK_Votos_Restaurantes]
    FOREIGN KEY ([IdRestaurante])
    REFERENCES [dbo].[Restaurantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Votos_Restaurantes'
CREATE INDEX [IX_FK_Votos_Restaurantes]
ON [dbo].[Votos]
    ([IdRestaurante]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------