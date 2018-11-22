CREATE TABLE [dbo].[InventoryItem]
(
    [Id] INT NOT NULL,
    [InventoryId] INT NOT NULL , 
    [ProductSKU] VARCHAR(50) NULL,
    [Description] VARCHAR(MAX) NULL,
    [Category] VARCHAR(50) NULL,
    [Stock] INT NULL, 
    [UnitCost] MONEY NULL, 
    PRIMARY KEY ([Id], [InventoryId]), 
    CONSTRAINT [FK_InventoryItem_ToInventory] FOREIGN KEY ([InventoryId]) REFERENCES [Inventory]([Id])
)
