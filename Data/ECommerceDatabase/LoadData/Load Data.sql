DECLARE @Path VARCHAR(MAX)
DECLARE @FileName VARCHAR(50)
DECLARE @Stmt VARCHAR(MAX)
DECLARE @Comma VARCHAR(3)
DECLARE @SingleQuotation VARCHAR(3)

SET @Comma = ','
SET @SingleQuotation = ''''
SET @Path = 'C:\Users\Joshua\Documents\Visual Studio 2017\Projects\ECommerce\Data\ECommerceDatabase\LoadData'

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

PRINT 'Load CartItems Data'
SET @FileName = 'CartItems'

SET @Stmt = 
'BULK
INSERT [CartItems]
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

SET @Stmt = 
'BULK
INSERT [Customer]
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)
/*
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
*/
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

PRINT 'Load Order Data'
SET @FileName = 'Order'

SET @Stmt = 
'BULK
INSERT [Order]
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

SET @Stmt = 
'BULK
INSERT [OrderLine]
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

SET @Stmt = 
'BULK
INSERT [User]
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)