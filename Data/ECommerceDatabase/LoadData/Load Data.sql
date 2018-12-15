DECLARE @Path VARCHAR(MAX)
DECLARE @FileName VARCHAR(50)
DECLARE @Stmt VARCHAR(MAX)
DECLARE @Comma VARCHAR(3)
DECLARE @SingleQuotation VARCHAR(3)

SET @Comma = ','
SET @SingleQuotation = ''''
SET @Path = 'C:\Users\Joshua\Documents\Visual Studio 2017\Projects\ECommerce\Data\ECommerceDatabase\LoadData'

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------S

PRINT 'Load CartItems Data'
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

PRINT 'Load Customer Data'
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

PRINT 'Load InventoryItem Data'
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

PRINT 'Load InventoryItemEntry Data'
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

PRINT 'Load InventoryProduct Data'
SET @FileName = 'InventoryProduct'

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

PRINT 'Load Order Data'
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

PRINT 'Load OrderLine Data'
SET @FileName = 'OrderLine'

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

PRINT 'Load Product Data'
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

PRINT 'Load Product Category Data'
SET @FileName = 'ProductCategory'

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

PRINT 'Load User Data'
SET @FileName = 'User'

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