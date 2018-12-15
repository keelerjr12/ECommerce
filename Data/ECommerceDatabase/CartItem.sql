CREATE TABLE [dbo].[CartItem]
(
    [CustomerID] UNIQUEIDENTIFIER NOT NULL, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    CONSTRAINT [FK_CartItem_ToCustomer] FOREIGN KEY ([CustomerID]) REFERENCES [Customer]([Id]), 
    CONSTRAINT [FK_CartItem_ToProduct] FOREIGN KEY (ProductId) REFERENCES [Product]([Id]), 
    CONSTRAINT [PK_CartItems] PRIMARY KEY ([CustomerID], [ProductId]) 
)
