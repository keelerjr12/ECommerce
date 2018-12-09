CREATE TABLE [dbo].[InventoryItem]
(
    [Id] INT NOT NULL , 
    [UnitCost] MONEY NULL, 
    CONSTRAINT [PK_InventoryItem] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_InventoryItem_ToInventoryProduct] FOREIGN KEY ([Id]) REFERENCES [InventoryProduct]([Id])
)
