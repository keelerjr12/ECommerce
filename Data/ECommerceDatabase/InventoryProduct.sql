﻿CREATE TABLE [dbo].[InventoryProduct]
(
    [Id] INT NOT NULL, 
    [InventoryId] INT NOT NULL,
    [Description] VARCHAR(MAX) NULL, 
    [Category] VARCHAR(50) NULL, 
    CONSTRAINT [PK_InventoryProduct] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_InventoryProduct_ToProduct] FOREIGN KEY ([Id]) REFERENCES [Product]([Id]), 
    CONSTRAINT [FK_InventoryProduct_ToInventory] FOREIGN KEY ([InventoryId]) REFERENCES [Inventory]([Id])
)
