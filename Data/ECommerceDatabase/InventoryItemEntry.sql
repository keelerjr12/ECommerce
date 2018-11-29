CREATE TABLE [dbo].[InventoryItemEntry]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [InventoryId] INT NOT NULL,
    [ProductId] INT NOT NULL,
    [DateOccurred] DATE NOT NULL, 
    [Type] VARCHAR(50) NOT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [FK_InventoryItemEntry_ToInventory] FOREIGN KEY ([InventoryId]) REFERENCES [Inventory]([Id]),
    CONSTRAINT [FK_InventoryItemEntry_ToInventoryProduct] FOREIGN KEY ([ProductId]) REFERENCES [InventoryProduct]([Id])
)
