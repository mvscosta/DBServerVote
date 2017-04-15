
-- --------------------------------------------------
-- DML Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/15/2017 03:07:35
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [vote];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- CLEANING TABLES
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Categorias]', 'U') IS NOT NULL
    DELETE [dbo].[Categorias];
GO
IF OBJECT_ID(N'[dbo].[Funcionarios]', 'U') IS NOT NULL
    DELETE [dbo].[Funcionarios];
GO
IF OBJECT_ID(N'[dbo].[Modalidades]', 'U') IS NOT NULL
    DELETE [dbo].[Modalidades];
GO
IF OBJECT_ID(N'[dbo].[Restaurantes]', 'U') IS NOT NULL
    DELETE [dbo].[Restaurantes];
GO
IF OBJECT_ID(N'[dbo].[Votos]', 'U') IS NOT NULL
    DELETE [dbo].[Votos];
GO

-- --------------------------------------------------
-- INSERTING START DATA
-- --------------------------------------------------

-- Table 'Categorias'
SET IDENTITY_INSERT [dbo].[Categorias] ON;  
GO
INSERT INTO [dbo].[Categorias] ([Id],[Descricao], [Titulo])
VALUES (1,'SUSHI','SUSHI')
,(2,'PIZZA','PIZZA')
,(3,'CASEIRA','CASEIRA')
GO
SET IDENTITY_INSERT [dbo].[Categorias] OFF;  
GO

-- Table 'Modalidades'
SET IDENTITY_INSERT [dbo].[Modalidades] ON;  
GO
INSERT INTO [dbo].[Modalidades] ([Id], [Descricao], [Titulo])
VALUES (1, 'BUFFET','BUFFET')
,(2, 'RODIZIO','RODIZIO')
,(3, 'A-LA-CARTE','A-LA-CARTE')
GO
SET IDENTITY_INSERT [dbo].[Modalidades] OFF;  
GO

-- Table 'Restaurantes'
SET IDENTITY_INSERT [dbo].[Restaurantes] ON;  
GO
INSERT INTO [dbo].[Restaurantes] ([Id], [IdCategoria], [IdModalidade], [DistanciaMedia], [Endereco], [Nome],[ValorMedio])
VALUES(1, 1,1,1.0,'Bento Gonçalves 7888', 'Shushi Bom',60.0)
,(2, 3,3,0.5,'Bento Gonçalves 7000', 'CASA DA VÓ',35.0)
,(3, 3,3,0.3,'Bento Gonçalves 6700', 'SILVA BAR',20.0)
GO
SET IDENTITY_INSERT [dbo].[Restaurantes] OFF;  
GO


-- Creating table 'Funcionarios'
SET IDENTITY_INSERT [dbo].[Funcionarios] ON;  
GO
INSERT INTO [dbo].[Funcionarios] ([Id], [Ativo],[Nome],[Username],[Administrador])
VALUES (1, 1,'Bruna', 'Bruna',1)
,(2, 1,'Cristina', 'Cristina', 0)
,(3, 1, 'Vinicius', 'Vinicius',1)
GO
SET IDENTITY_INSERT [dbo].[Funcionarios] OFF;  
GO

-- Creating table 'Votos'
INSERT INTO [dbo].[Votos] ([IdRestaurante],[IdFuncionario],[DataVoto])
VALUES (1,3,'2017-04-13')
,(1,3,'2017-04-17')
,(2,3,'2017-04-18')
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------