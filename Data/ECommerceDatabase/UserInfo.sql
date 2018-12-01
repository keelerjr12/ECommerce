CREATE TABLE [dbo].[UserInfo]
(
	[username] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [password] NCHAR(10) NOT NULL, 
    [firstName] NCHAR(10) NOT NULL, 
    [lastName] NCHAR(10) NOT NULL, 
    [email] NCHAR(10) NOT NULL, 
    [userType] NCHAR(10) NOT NULL 
)
