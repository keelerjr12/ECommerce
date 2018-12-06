CREATE TABLE [dbo].[Product]
(
    [Id] INT NOT NULL IDENTITY,
    [SKU] VARCHAR(50) NOT NULL , 
    [Manufacturer] VARCHAR(MAX) NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [Price] MONEY NULL, 
    [CategoryId] INT NULL, 
    PRIMARY KEY ([Id]), 
	CONSTRAINT [FK_Product_ToProductCategory] FOREIGN KEY ([CategoryId]) REFERENCES [ProductCategory]([Id])
)
