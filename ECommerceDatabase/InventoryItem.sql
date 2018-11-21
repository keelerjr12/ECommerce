CREATE TABLE [dbo].[InventoryItem]
(
    [InventoryID] INT NOT NULL , 
    [ProductSKU] VARCHAR(50) NOT NULL,
    [Description] VARCHAR(MAX) NULL,
    [Category] VARCHAR(50) NULL,
    [Stock] INT NULL, 
    [UnitCost] MONEY NULL, 
    PRIMARY KEY ([InventoryID], [ProductSKU]), 
    CONSTRAINT [FK_InventoryItem_ToInventory] FOREIGN KEY ([InventoryID]) REFERENCES [Inventory]([ID])
)
