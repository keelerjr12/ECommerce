CREATE TABLE [dbo].[InventoryItemEntry]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [InventoryItemId] INT NOT NULL,
    [DateOccurred] DATE NOT NULL, 
    [Type] VARCHAR(50) NOT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [FK_InventoryItemEntry_ToInventoryItem] FOREIGN KEY ([InventoryItemId]) REFERENCES [InventoryItem]([Id])
)
