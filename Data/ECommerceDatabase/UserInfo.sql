CREATE TABLE [dbo].[UserInfo]
(
	[username] VARCHAR(50) NOT NULL PRIMARY KEY, 
    [password] NCHAR(10) NOT NULL, 
    [first_name] NCHAR(10) NOT NULL, 
    [last_name] NCHAR(10) NOT NULL 
)
