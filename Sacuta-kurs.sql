USE [master]
GO
/****** Object:  Database [Sacuta-kurs]    Script Date: 16.05.2023 19:23:37 ******/
CREATE DATABASE [Sacuta-kurs]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Sacuta-kurs', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Sacuta-kurs.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Sacuta-kurs_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Sacuta-kurs_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Sacuta-kurs] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sacuta-kurs].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sacuta-kurs] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET ARITHABORT OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Sacuta-kurs] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Sacuta-kurs] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Sacuta-kurs] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Sacuta-kurs] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET RECOVERY FULL 
GO
ALTER DATABASE [Sacuta-kurs] SET  MULTI_USER 
GO
ALTER DATABASE [Sacuta-kurs] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Sacuta-kurs] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Sacuta-kurs] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Sacuta-kurs] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Sacuta-kurs] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Sacuta-kurs] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Sacuta-kurs', N'ON'
GO
ALTER DATABASE [Sacuta-kurs] SET QUERY_STORE = ON
GO
ALTER DATABASE [Sacuta-kurs] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Sacuta-kurs]
GO
/****** Object:  Table [dbo].[BalanceUpdates]    Script Date: 16.05.2023 19:23:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BalanceUpdates](
	[AddId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Money] [float] NOT NULL,
	[Date] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Basket]    Script Date: 16.05.2023 19:23:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Basket](
	[IdOrd] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Brand] [nvarchar](30) NOT NULL,
	[Model] [nvarchar](30) NOT NULL,
	[Year] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[Date] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Car]    Script Date: 16.05.2023 19:23:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Car](
	[CarId] [int] IDENTITY(1,1) NOT NULL,
	[Brand] [nvarchar](30) NOT NULL,
	[Model] [nvarchar](30) NOT NULL,
	[Year] [int] NOT NULL,
	[Price] [float] NOT NULL,
	[EngineVolume] [nvarchar](30) NOT NULL,
	[EngineType] [nvarchar](30) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](30) NOT NULL,
	[DriveUnit] [nvarchar](30) NOT NULL,
	[Transmission] [nvarchar](30) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Models]    Script Date: 16.05.2023 19:23:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Models](
	[ModelId] [int] IDENTITY(1,1) NOT NULL,
	[Model] [nvarchar](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 16.05.2023 19:23:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Surname] [nvarchar](30) NOT NULL,
	[Login] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[Balance] [float] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BalanceUpdates]  WITH CHECK ADD  CONSTRAINT [FK_AddMoney_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[BalanceUpdates] CHECK CONSTRAINT [FK_AddMoney_Users]
GO
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Users]
GO
USE [master]
GO
ALTER DATABASE [Sacuta-kurs] SET  READ_WRITE 
GO
