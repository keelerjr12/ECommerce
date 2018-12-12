CREATE TABLE [dbo].[User]
(
    [Id] Int NOT NULL PRIMARY KEY IDENTITY,
	[Username] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [UserType] VARCHAR(50) NOT NULL
)
