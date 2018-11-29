CREATE TABLE [dbo].[Product]
(
    [Id] INT NOT NULL IDENTITY,
    [SKU] VARCHAR(50) NOT NULL , 
    [Manufacturer] VARCHAR(MAX) NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [Price] MONEY NULL, 
    [Category] VARCHAR(50) NULL, 
    PRIMARY KEY ([Id]) 
)
