CREATE TABLE [dbo].[CartItems]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CartID] INT NOT NULL, 
    [ProductSKU] VARCHAR(50) NOT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [FK_CartItems_ToTable] FOREIGN KEY ([CartID]) REFERENCES [Cart]([Id]), 
    CONSTRAINT [FK_CartItem_ToProduct] FOREIGN KEY (ProductSKU) REFERENCES [Product]([SKU])
)
