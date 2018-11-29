CREATE TABLE [dbo].[InventoryItemEntry]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY NONCLUSTERED DEFAULT NEWID(),
    [InventoryId] INT NOT NULL,
    [SKU] VARCHAR(50) NOT NULL,
    [DateOccurred] DATE NOT NULL, 
    [Type] VARCHAR(50) NOT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [FK_InventoryItemEntry_ToInventory] FOREIGN KEY ([InventoryId]) REFERENCES [Inventory]([Id]),
    CONSTRAINT [FK_InventoryItemEntry_ToProduct] FOREIGN KEY ([SKU]) REFERENCES [Product]([SKU])
)
