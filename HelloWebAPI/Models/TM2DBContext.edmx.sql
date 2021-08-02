
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/29/2021 18:31:30
-- Generated from EDMX file: C:\Users\saito\source\repos\TM2WEB\TM2WEB\Models\TM2DBContext.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TM2DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[M_GROUP]', 'U') IS NOT NULL
    DROP TABLE [dbo].[M_GROUP];
GO
IF OBJECT_ID(N'[dbo].[M_SHAIN]', 'U') IS NOT NULL
    DROP TABLE [dbo].[M_SHAIN];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'M_SHAIN'
CREATE TABLE [dbo].[M_SHAIN] (
    [EmpID] nvarchar(10)  NOT NULL,
    [NameKJ1] nvarchar(50)  NULL,
    [NameKJ2] nvarchar(50)  NULL,
    [NameKN] nvarchar(50)  NULL,
    [StartDate] nchar(8)  NULL,
    [EndDate] nchar(8)  NULL,
    [EmployeeKbn] nchar(1)  NULL,
    [BaseDate] nchar(8)  NULL,
    [AdYear] int  NULL,
    [BaseAge] int  NULL,
    [AdCareerYear] int  NULL,
    [CareerYear] int  NULL,
    [Mail] nvarchar(50)  NULL,
    [Station] nvarchar(50)  NULL,
    [Phone] nvarchar(20)  NULL,
    [Sex] nchar(1)  NULL,
    [BreakNum] int  NULL,
    [DaysWorked] int  NULL,
    [College] nvarchar(100)  NULL,
    [Department1] nvarchar(100)  NULL,
    [Department2] nvarchar(100)  NULL,
    [InsMark] nvarchar(10)  NULL,
    [InsNum] nvarchar(10)  NULL,
    [Job] nvarchar(30)  NULL,
    [GroupID] nvarchar(30)  NULL,
    [TraGroup] nvarchar(30)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'M_GROUP'
CREATE TABLE [dbo].[M_GROUP] (
    [GroupID] nvarchar(10)  NOT NULL,
    [GroupName] nvarchar(30)  NULL,
    [GLEmpID] nvarchar(10)  NOT NULL,
    [UpdateDate] datetime  NULL,
    [Token] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EmpID] in table 'M_SHAIN'
ALTER TABLE [dbo].[M_SHAIN]
ADD CONSTRAINT [PK_M_SHAIN]
    PRIMARY KEY CLUSTERED ([EmpID] ASC);
GO

-- Creating primary key on [GroupID] in table 'M_GROUP'
ALTER TABLE [dbo].[M_GROUP]
ADD CONSTRAINT [PK_M_GROUP]
    PRIMARY KEY CLUSTERED ([GroupID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------