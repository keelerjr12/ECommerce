CREATE TABLE [dbo].[OrderLine]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [OrderId] INT NOT NULL,
    [SKU] VARCHAR(50) NOT NULL, 
    [Quantity] INT NOT NULL, 
    [Price] MONEY NOT NULL, 
    CONSTRAINT [FK_OrderLine_ToOrder] FOREIGN KEY ([OrderId]) REFERENCES [Order]([Id])
)
