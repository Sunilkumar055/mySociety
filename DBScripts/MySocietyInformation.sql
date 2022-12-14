USE [master]
GO
/****** Object:  Database [societyinformation]    Script Date: 12/7/2022 11:41:28 AM ******/
CREATE DATABASE [societyinformation]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'societyinformation', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\societyinformation.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'societyinformation_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\societyinformation_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [societyinformation] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [societyinformation].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [societyinformation] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [societyinformation] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [societyinformation] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [societyinformation] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [societyinformation] SET ARITHABORT OFF 
GO
ALTER DATABASE [societyinformation] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [societyinformation] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [societyinformation] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [societyinformation] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [societyinformation] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [societyinformation] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [societyinformation] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [societyinformation] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [societyinformation] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [societyinformation] SET  ENABLE_BROKER 
GO
ALTER DATABASE [societyinformation] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [societyinformation] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [societyinformation] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [societyinformation] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [societyinformation] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [societyinformation] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [societyinformation] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [societyinformation] SET RECOVERY FULL 
GO
ALTER DATABASE [societyinformation] SET  MULTI_USER 
GO
ALTER DATABASE [societyinformation] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [societyinformation] SET DB_CHAINING OFF 
GO
ALTER DATABASE [societyinformation] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [societyinformation] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [societyinformation] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'societyinformation', N'ON'
GO
ALTER DATABASE [societyinformation] SET QUERY_STORE = OFF
GO
USE [societyinformation]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/7/2022 11:41:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/7/2022 11:41:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Roles] [varchar](20) NOT NULL,
	[Description] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/7/2022 11:41:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[ConactNumber] [varchar](13) NOT NULL,
	[AlternateContactNumber] [varchar](13) NULL,
	[WhatsAppNumber] [varchar](13) NULL,
	[EmailID] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[FlatNumberID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spGetRole]    Script Date: 12/7/2022 11:41:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spGetRole]
	@RoleID int
AS
BEGIN
	set nocount on;
	if @RoleID <= 0
		begin 
			Select * from Role;
		end
	else
		begin 
			Select * from Role Where RoleID = @RoleID;
		end
END
GO
/****** Object:  StoredProcedure [dbo].[spGetUserMaster]    Script Date: 12/7/2022 11:41:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetUserMaster]	
	@UserID Int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @UserID = 0 
	begin
		SELECT * FROM [societyinformation].[dbo].[Users];
	end
		else
    begin
		SELECT * FROM [societyinformation].[dbo].[Users] where userId = @UserID;
	end	
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertUserMaster]    Script Date: 12/7/2022 11:41:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spInsertUserMaster]
	@RoleID int,
	@FirstName varchar(50),
	@LastName varchar(50),
	@ConactNumber varchar(13),
	@AlternateContactNumber varchar(13),
	@WhatsAppNumber varchar(13),
	@EmailID varchar(50),
	@Address varchar(50),
	@Password varchar(20),
	@FlatNumberID int,
	@IsActive bit,
	@CreatedDate Datetime
AS
BEGIN
	INSERT INTO [dbo].[Users]
	([RoleID],[UserName],[FirstName],[LastName],[ConactNumber],[AlternateContactNumber],[WhatsAppNumber],[EmailID],[Address],[Password],[FlatNumberID],[IsActive],[CreatedDate])
	VALUES
	(@RoleID,CONCAT(@FirstName,' ', @LastName), @FirstName, @LastName,@ConactNumber,@AlternateContactNumber,@WhatsAppNumber,@EmailID,@Address,@Password, @FlatNumberID,@IsActive,@CreatedDate);
END
GO
USE [master]
GO
ALTER DATABASE [societyinformation] SET  READ_WRITE 
GO
