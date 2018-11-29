CREATE TABLE [dbo].[CartItems]
(
    [CartID] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [FK_CartItem_ToTable] FOREIGN KEY ([CartID]) REFERENCES [Cart]([Id]), 
    CONSTRAINT [FK_CartItem_ToProduct] FOREIGN KEY (ProductId) REFERENCES [Product]([Id]), 
    CONSTRAINT [PK_CartItems] PRIMARY KEY ([CartID], [ProductId]) 
)
