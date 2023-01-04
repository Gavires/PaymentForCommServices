﻿CREATE TABLE [dbo].[Users]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [UserName] NVARCHAR(50) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [IsAdmin] BIT NOT NULL
)
