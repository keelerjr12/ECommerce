DECLARE @Path VARCHAR(MAX)
DECLARE @FileName VARCHAR(50)
DECLARE @Stmt VARCHAR(MAX)
DECLARE @Comma VARCHAR(3)
DECLARE @SingleQuotation VARCHAR(3)

SET @Comma = ','
SET @SingleQuotation = ''''

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- CHANGE THIS BASED ON YOUR LOCAL PATH
--SET @Path = 'C:\Users\Leann Chen\Documents\Visual Studio 2017\projects\ECommerce\Data\ECommerceDatabase\LoadData'
SET @Path = 'C:\Users\Joshua\Documents\Visual Studio 2017\Projects\ECommerce\Data\ECommerceDatabase\LoadData'
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

PRINT 'Load CartItem Data'
SET @FileName = 'CartItem'

SET @Stmt = 
'BULK
INSERT [CartItem]
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

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

PRINT 'Load InventoryItem Data'
SET @FileName = 'InventoryItem'

SET @Stmt = 
'BULK
INSERT [InventoryItem]
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

SET @Stmt = 
'BULK
INSERT [InventoryItemEntry]
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

PRINT 'Load Product Data'
SET @FileName = 'Product'

SET @Stmt = 
'BULK
INSERT [Product]
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

PRINT 'Load Product Category Data'
SET @FileName = 'ProductCategory'

SET @Stmt = 
'BULK
INSERT [ProductCategory]
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)


--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

PRINT 'Load Product Option Data'
SET @FileName = 'ProductOption'

SET @Stmt = 
'BULK
INSERT [ProductOption]
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

PRINT 'Load Product Option Value Data'
SET @FileName = 'ProductOptionValue'

SET @Stmt = 
'BULK
INSERT [ProductOptionValue]
FROM ' + (@SingleQuotation) + (@Path) + '\' + (@FileName) + '.csv' + (@SingleQuotation) + '
WITH
(
FIELDTERMINATOR = ' + (@SingleQuotation) + (@Comma) + (@SingleQuotation) + (@Comma) +'
ROWTERMINATOR = ''\n''
)'
--PRINT @Stmt
EXEC (@Stmt)

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
PRINT 'Load Shipping Distance Data'
SET @FileName = 'ShippingDistance'

SET @Stmt = 
'BULK
INSERT [ShippingDistance]
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