CREATE TABLE [dbo].[CartItemOption]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CartItemId] INT NOT NULL, 
    [Name] VARCHAR(150) NOT NULL, 
    [Value] VARCHAR(150) NOT NULL, 
    CONSTRAINT [FK_CartItemOption_ToCartItem] FOREIGN KEY ([Id]) REFERENCES [CartItem]([Id])
)
