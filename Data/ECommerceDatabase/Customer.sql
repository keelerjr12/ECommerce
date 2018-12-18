CREATE TABLE [dbo].[Customer]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [MiddleName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [Street] VARCHAR(MAX) NOT NULL,
    [City] VARCHAR(50) NOT NULL, 
    [State] VARCHAR(50) NOT NULL, 
    [Country] VARCHAR(200) NOT NULL,
    [ZipCode] INT NOT NULL, 
    [IsSubscribed] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Customer_ToUser] FOREIGN KEY ([Id]) REFERENCES [User]([Id])
)
