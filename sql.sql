IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'User')
BEGIN
CREATE TABLE [dbo].[User](
	[UsersId] [int] IDENTITY(1,1) PRIMARY KEY,
	[UsersToken] [uniqueidentifier] NOT NULL,
	[RoleId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Loginname] [nvarchar](255) NULL,
	[LoginPassword] [nvarchar](255) NULL,
	[Firstname] [nvarchar](255) NULL,
	[Lastname] [nvarchar](255) NULL,
	[GenderId] [int] NOT NULL,
	[EmailAddress] [nvarchar](255) NULL,
	[CreatedDate] [datetime] NULL)
END 
GO

------------------------------------------------------------Role Table---------------------------------------------

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Role')
BEGIN
CREATE TABLE [dbo].[Role] (
	[RoleId] [int] IDENTITY(1,1) PRIMARY KEY,
	[RoleDescription] [nvarchar](255) NULL
	)
END 
GO

------------------------------------------------------------Product Table---------------------------------------------
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Product')
BEGIN
CREATE TABLE [dbo].[Product] (
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Supplier] [nvarchar](255) NULL,
	[quantity] [int] NULL,
	[price] [int] NULL,
	)
END 
GO