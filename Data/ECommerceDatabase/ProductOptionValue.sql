CREATE TABLE [dbo].[ProductOptionValue]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductOptionId] INT NOT NULL, 
    [Name] VARCHAR(150) NOT NULL, 
    CONSTRAINT [FK_ProductOptionValue_ToProductOption] FOREIGN KEY ([ProductOptionId]) REFERENCES [ProductOption]([Id])
)
