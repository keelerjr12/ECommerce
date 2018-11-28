CREATE TABLE [dbo].[Customer]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [MiddleName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [StreetAddress] VARCHAR(MAX) NOT NULL,
    [City] VARCHAR(50) NOT NULL, 
    [State] VARCHAR(50) NOT NULL, 
    [ZipCode] INT NOT NULL
)
