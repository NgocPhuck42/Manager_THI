USE [master]
GO
/****** Object:  Database [Manager]    Script Date: 1/1/2022 3:08:54 PM ******/
CREATE DATABASE [Manager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Manager', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Manager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Manager_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Manager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Manager] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Manager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Manager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Manager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Manager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Manager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Manager] SET ARITHABORT OFF 
GO
ALTER DATABASE [Manager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Manager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Manager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Manager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Manager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Manager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Manager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Manager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Manager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Manager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Manager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Manager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Manager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Manager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Manager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Manager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Manager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Manager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Manager] SET  MULTI_USER 
GO
ALTER DATABASE [Manager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Manager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Manager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Manager] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Manager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Manager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Manager] SET QUERY_STORE = OFF
GO
USE [Manager]
GO
/****** Object:  UserDefinedFunction [dbo].[ufn_removeMark]    Script Date: 1/1/2022 3:08:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ufn_removeMark] (@text nvarchar(max))
RETURNS nvarchar(max)
AS
BEGIN
	SET @text = LOWER(@text)
	DECLARE @textLen int = LEN(@text)
	IF @textLen > 0
	BEGIN
		DECLARE @index int = 1
		DECLARE @lPos int
		DECLARE @SIGN_CHARS nvarchar(100) = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệếìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵýđð'
		DECLARE @UNSIGN_CHARS varchar(100) = 'aadeoouaaaaaaaaaaaaaaaeeeeeeeeeeiiiiiooooooooooooooouuuuuuuuuuyyyyydd'

		WHILE @index <= @textLen
		BEGIN
			SET @lPos = CHARINDEX(SUBSTRING(@text,@index,1),@SIGN_CHARS)
			IF @lPos > 0
			BEGIN
				SET @text = STUFF(@text,@index,1,SUBSTRING(@UNSIGN_CHARS,@lPos,1))
			END
			SET @index = @index + 1
		END
	END
	RETURN @text
END
GO
/****** Object:  Table [dbo].[Account]    Script Date: 1/1/2022 3:08:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NULL,
	[displayname] [nvarchar](50) NULL,
	[type] [int] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 1/1/2022 3:08:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 1/1/2022 3:08:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[idCategory] [int] NULL,
	[price] [int] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([username], [password], [displayname], [type]) VALUES (N'dung', N'123', N'Dũng', 1)
INSERT [dbo].[Account] ([username], [password], [displayname], [type]) VALUES (N'son', N'0', N'Sơn', 0)
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name]) VALUES (1, N'Sơn Ngu')
INSERT [dbo].[Category] ([id], [name]) VALUES (2, N'Dũng xì ke')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [name], [idCategory], [price]) VALUES (1, N'NGÁO', 1, 10000)
INSERT [dbo].[Product] ([id], [name], [idCategory], [price]) VALUES (3, N'Sơn óc loz', 1, 20000)
INSERT [dbo].[Product] ([id], [name], [idCategory], [price]) VALUES (4, N'Dũng', 2, 12000)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
/****** Object:  StoredProcedure [dbo].[USP_Login]    Script Date: 1/1/2022 3:08:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_Login] 
@username nvarchar(50), @password nvarchar(50)
as
begin
	select * from Account
	where username = @username and password = @password
end
GO
/****** Object:  StoredProcedure [dbo].[USP_UpdateAccount]    Script Date: 1/1/2022 3:08:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[USP_UpdateAccount]
@username nvarchar(50), @displayname nvarchar(50), @password nvarchar(50), @newpassword nvarchar(50)
as
begin
	declare @isRightPass int = 0

	select @isRightPass = COUNT(*) from Account where username = @username and password = @password

	if(@isRightPass = 1)
	begin
		if(@newpassword = null or @newpassword ='')
		begin
			update Account set displayname = @displayname where username = @username
		end
		else
			update Account set displayname = @displayname , password = @newpassword where username = @username
	end
end
GO
USE [master]
GO
ALTER DATABASE [Manager] SET  READ_WRITE 
GO
