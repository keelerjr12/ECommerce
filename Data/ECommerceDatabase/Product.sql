CREATE TABLE [dbo].[Product]
(
    [Id] INT NOT NULL IDENTITY,
    [SKU] VARCHAR(50) NOT NULL ,
    [Name] VARCHAR(150) NOT NULL,
    [Manufacturer] VARCHAR(MAX) NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [ImageFileName] VARCHAR(150) NOT NULL,
    PRIMARY KEY ([Id]), 
	CONSTRAINT [FK_Product_ToProductCategory] FOREIGN KEY ([CategoryId]) REFERENCES [ProductCategory]([Id])
)
