DECLARE @Path VARCHAR(MAX)
DECLARE @FileName VARCHAR(50)
DECLARE @Stmt VARCHAR(MAX)
DECLARE @Comma VARCHAR(3)
DECLARE @SingleQuotation VARCHAR(3)

SET @Comma = ','
SET @SingleQuotation = ''''
SET @Path = 'C:\Users\rz9fxj\Downloads\0 Code\ECommerce\Data\ECommerceDatabase\LoadData'


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--Load Cart Data
SET @FileName = 'Cart'

EXEC('DELETE FROM ' + @FileName)

SET @Stmt = 
'BULK
INSERT ECommerceDatabase.dbo.' + (@FileName) + '
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--Load CartItems Data
SET @FileName = 'CartItems'

EXEC('DELETE FROM ' + @FileName)

SET @Stmt = 
'BULK
INSERT ECommerceDatabase.dbo.' + (@FileName) + '
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--Load Customer Data
SET @FileName = 'Customer'

EXEC('DELETE FROM ' + @FileName)

SET @Stmt = 
'BULK
INSERT ECommerceDatabase.dbo.' + (@FileName) + '
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--Load Inventory Data
SET @FileName = 'Inventory'

EXEC('DELETE FROM ' + @FileName)

SET @Stmt = 
'BULK
INSERT ECommerceDatabase.dbo.' + (@FileName) + '
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--Load InventoryItem Data
SET @FileName = 'InventoryItem'

EXEC('DELETE FROM ' + @FileName)

SET @Stmt = 
'BULK
INSERT ECommerceDatabase.dbo.' + (@FileName) + '
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--Load InventoryItemEntry Data
SET @FileName = 'InventoryItemEntry'

EXEC('DELETE FROM ' + @FileName)

SET @Stmt = 
'BULK
INSERT ECommerceDatabase.dbo.' + (@FileName) + '
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--Load InventoryItemProduct Data
SET @FileName = 'InventoryItemProduct'

EXEC('DELETE FROM ' + @FileName)

SET @Stmt = 
'BULK
INSERT ECommerceDatabase.dbo.' + (@FileName) + '
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--Load Order Data
SET @FileName = 'Order'

EXEC('DELETE FROM ' + @FileName)

SET @Stmt = 
'BULK
INSERT ECommerceDatabase.dbo.' + (@FileName) + '
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--Load Product Data
SET @FileName = 'Product'

EXEC('DELETE FROM ' + @FileName)

SET @Stmt = 
'BULK
INSERT ECommerceDatabase.dbo.' + (@FileName) + '
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--Load UserInfo Data
SET @FileName = 'UserInfo'

EXEC('DELETE FROM ' + @FileName)

SET @Stmt = 
'BULK
INSERT ECommerceDatabase.dbo.' + (@FileName) + '
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)