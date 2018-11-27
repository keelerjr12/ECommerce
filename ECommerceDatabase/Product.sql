CREATE TABLE [dbo].[Product]
(
    [SKU] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [Manufacturer] TEXT NULL, 
    [Description] TEXT NULL, 
    [Price] MONEY NULL,
	[Category] TEXT NULL
)
