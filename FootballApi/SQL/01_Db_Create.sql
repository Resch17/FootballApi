USE [master]
GO

IF db_id('Football') IS NULL
	CREATE DATABASE [Football]
GO

USE [Football]
GO

DROP TABLE IF EXISTS [Team];

CREATE TABLE [Team] (
	[Id] int PRIMARY KEY IDENTITY NOT NULL,
	[Location] nvarchar(255) NOT NULL,
	[Abbreviation] nvarchar(255) NOT NULL,
	[DisplayName] nvarchar(255) NOT NULL,
	[Name] nvarchar(255) NOT NULL,
	[Logo] nvarchar(MAX) NOT NULL
)
GO