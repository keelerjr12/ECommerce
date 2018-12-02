CREATE TABLE [dbo].[UserInfo]
(
	[username] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [password] NVARCHAR(50) NOT NULL, 
    [firstName] VARCHAR(50) NOT NULL, 
    [lastName] VARCHAR(50) NOT NULL, 
    [email] NVARCHAR(50) NOT NULL, 
    [userType] VARCHAR(10) NULL DEFAULT 'customer' 
)
