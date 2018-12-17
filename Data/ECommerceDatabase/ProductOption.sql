CREATE TABLE [dbo].[ProductOption]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [Name] VARCHAR(150) NOT NULL, 
    CONSTRAINT [FK_ProductOption_ToProduct] FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id])
)
