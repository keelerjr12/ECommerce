CREATE TABLE [dbo].[InventoryItem]
(
    [InventoryId] INT NOT NULL , 
    [SKU] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(MAX) NULL,
    [Category] VARCHAR(50) NULL,
    [UnitCost] MONEY NULL, 
    PRIMARY KEY ([InventoryId], [SKU]), 
    CONSTRAINT [FK_InventoryItem_ToInventory] FOREIGN KEY ([InventoryId]) REFERENCES [Inventory]([Id]),
    CONSTRAINT [FK_InventoryItem_ToProduct] FOREIGN KEY ([SKU]) REFERENCES [Product]([SKU])
)
