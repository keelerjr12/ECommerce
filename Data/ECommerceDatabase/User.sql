﻿CREATE TABLE [dbo].[User]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Username] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [UserType] VARCHAR(50) NOT NULL DEFAULT 'customer'
)
