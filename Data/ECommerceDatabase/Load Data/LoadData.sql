
--Load UserInfo Data
DELETE FROM dbo.userInfo

BULK
INSERT userInfo
FROM 'C:\Users\rz9fxj\Downloads\0 Code\ECommerce\Data\ECommerceDatabase\ExcelData\userInfo.csv'
WITH
(
FIELDTERMINATOR = ',',
ROWTERMINATOR = '\n'
)
GO

