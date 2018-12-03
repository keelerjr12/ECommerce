CREATE TABLE [dbo].[OrderInfo]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DateTime] DATETIME2 NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [Street] VARCHAR(MAX) NULL, 
    [City] VARCHAR(MAX) NULL, 
    [State] VARCHAR(50) NULL, 
    [Zipcode] INT NULL,
    [Country] VARCHAR(50) NULL, 
    CONSTRAINT [FK_Order_ToCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id])
)
