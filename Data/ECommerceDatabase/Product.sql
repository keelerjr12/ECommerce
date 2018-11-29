CREATE TABLE [dbo].[Product]
(
    [Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NewId(),
    [InventoryId] INT NOT NULL, 
    [SKU] VARCHAR(50) NOT NULL , 
    [Manufacturer] VARCHAR(MAX) NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [Price] MONEY NULL, 
    PRIMARY KEY ([Id]) 
)
