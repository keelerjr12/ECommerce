--Load UserInfo Data
DELETE FROM ECommerceDatabase.dbo.InventoryItemEntry

BULK
INSERT InventoryItemEntry
FROM 'C:\Users\Joshua\Documents\Visual Studio 2017\Projects\ECommerce\Data\ECommerceDatabase\Load Data\InventoryItemEntry.csv'
WITH
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
GO

