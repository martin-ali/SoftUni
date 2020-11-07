DROP DATABASE IF EXISTS [SoftUni]
GO

CREATE DATABASE [SoftUni]
GO

USE [SoftUni]

CREATE TABLE [Towns]
(
    [Id] INT IDENTITY(1, 1),
    [Name] NVARCHAR(50) NOT NULL,

    CONSTRAINT PK_Towns PRIMARY KEY(Id)
)

-- CREATE TABLE [Addresses]
-- (
--     [Id] INT IDENTITY(1, 1),
--     [AddressText] NVARCHAR(200) NOT NULL,
--     [TownId] INT NOT NULL,

--     CONSTRAINT FK_TownId_Towns FOREIGN KEY(TownId) REFERENCES [Towns](Id),
--     CONSTRAINT PK_Addresses PRIMARY KEY(Id)
-- )

CREATE TABLE [Departments]
(
    [Id] INT IDENTITY(1, 1),
    [Name] NVARCHAR(50) NOT NULL,

    CONSTRAINT PK_Departments PRIMARY KEY(Id)
)

CREATE TABLE [Employees]
(
    [Id] INT IDENTITY(1, 1),
    [FirstName] NVARCHAR(20) NOT NULL,
    [MiddleName] NVARCHAR(20),
    [LastName] NVARCHAR(20) NOT NULL,
    [JobTitle] NVARCHAR(50) NOT NULL,
    [DepartmentId] INT NOT NULL,
    [HireDate] DATETIME NOT NULL,
    [Salary] REAL NOT NULL,

    CONSTRAINT FK_DepartmentId_Departments FOREIGN KEY(DepartmentId) REFERENCES [Departments](Id),
    CONSTRAINT PK_Employees PRIMARY KEY(Id)
)