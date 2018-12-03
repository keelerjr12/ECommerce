--Load UserInfo Data
DELETE FROM ECommerceDatabase.dbo.UserInfo

BULK
INSERT UserInfo
FROM 'C:\Users\rz9fxj\Downloads\0 Code\ECommerce\Data\ECommerceDatabase\Load Data\UserInfo.csv'
WITH
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
GO

