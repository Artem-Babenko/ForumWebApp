--- Create Database ----------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Forum')
BEGIN
	CREATE DATABASE [Forum]
	PRINT 'Database created'
END
ELSE 
	PRINT 'Database Exist'
GO
	USE [Forum]
GO

--- Create [dbo].[User] ------------------------------------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = 'User')
BEGIN
	CREATE TABLE [dbo].[User](
		[Id] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
		[Name] NVARCHAR(50) NOT NULL,
		[Surname] NVARCHAR(50) NOT NULL,
		[Age] INT NULL,
		[CreateOn] DATETIME NOT NULL
	)
	PRINT 'Table User created'
END
ELSE
	PRINT 'Table User exists'

--- Create [dbo].[Chat] -----------------------------------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = 'Chat')
BEGIN 
	CREATE TABLE [dbo].[Chat](
		[Id] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
		[Name] NVARCHAR(100) NOT NULL,
		[Description] NVARCHAR(MAX) NULL,
		[CreateOn] DATETIME NOT NULL,
	)
	PRINT 'Table Chat created'
END
ELSE
	PRINT 'Table Chat exists'

--- Create [dbo].[Message] -----------------------------------------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = 'Message')
BEGIN
	CREATE TABLE [dbo].[Message] (
		[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
		[Text] NVARCHAR(MAX) NULL,
		[CreateOn] DATETIME NOT NULL
	)
	PRINT 'Table Message created'
END
ELSE
	PRINT 'Table Message exists'

--- Create Messages Relation to Chat -------------------------------
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS
	WHERE (TABLE_NAME = 'Message')
	AND (COLUMN_NAME = 'ChatId')
)
BEGIN
	ALTER TABLE [dbo].[Message]
	ADD [ChatId] INT NOT NULL,
		CONSTRAINT FK_ChatMessages
		FOREIGN KEY (ChatId) 
		REFERENCES [dbo].[Chat](Id)
		ON DELETE CASCADE
	PRINT 'Table Message column ChatId created'
END 
ELSE
	PRINT 'Table Message have column ChatId'

--- Create Messages Relation to User -------------------------------
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS
	WHERE (TABLE_NAME = 'Message')
	AND (COLUMN_NAME = 'AuthorId')
)
BEGIN 
	ALTER TABLE [dbo].[Message]
	ADD [AuthorId] INT NOT NULL,
		CONSTRAINT FK_UserMessages
		FOREIGN KEY (AuthorId)
		REFERENCES [dbo].[User](Id)
		ON DELETE NO ACTION
	PRINT 'Table Message column AuthorId created'
END
ELSE
	PRINT 'Table Message have column AuthorId'

--- Create Chat Relation to User -------------------------------
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS
	WHERE (TABLE_NAME = 'Chat')
	AND (COLUMN_NAME = 'AuthorId')
)
BEGIN 
	ALTER TABLE [dbo].[Chat]
	ADD [AuthorId] INT NOT NULL,
		CONSTRAINT FK_UserChats
		FOREIGN KEY (AuthorId)
		REFERENCES [dbo].[User](Id)
		ON DELETE CASCADE
	PRINT 'Table Chat column AuthorId created'
END
ELSE
	PRINT 'Table Chat have column AuthorId'