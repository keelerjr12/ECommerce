CREATE TABLE [dbo].[Order]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Created] DATETIME2 NOT NULL, 
    [CustomerId] UNIQUEIDENTIFIER NOT NULL, 
    [Street] VARCHAR(MAX) NULL, 
    [City] VARCHAR(MAX) NULL, 
    [State] VARCHAR(50) NULL, 
    [Zipcode] INT NULL,
    [Country] VARCHAR(50) NULL, 
    [ShippingCost] MONEY NOT NULL, 
    CONSTRAINT [FK_Order_ToCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id])
)
