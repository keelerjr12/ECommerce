CREATE TABLE [dbo].[InventoryItem]
(
    [Id] INT NOT NULL, 
    [Description] VARCHAR(150) NOT NULL,
    [Category] VARCHAR(150) NOT NULL,
    [UnitCost] MONEY NOT NULL, 
    CONSTRAINT [PK_InventoryItem] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_InventoryItem_ToProduct] FOREIGN KEY ([Id]) REFERENCES Product([Id])
)
