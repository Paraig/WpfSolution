USE [master]
GO

/****** Object:  Database [KPMG]    Script Date: 02/11/2016 10:58:55 ******/
CREATE DATABASE [KPMG]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KPMG', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\KPMG.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KPMG_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\KPMG_log.ldf' , SIZE = 4096KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [KPMG] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KPMG].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [KPMG] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [KPMG] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [KPMG] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [KPMG] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [KPMG] SET ARITHABORT OFF 
GO

ALTER DATABASE [KPMG] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [KPMG] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [KPMG] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [KPMG] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [KPMG] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [KPMG] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [KPMG] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [KPMG] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [KPMG] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [KPMG] SET  DISABLE_BROKER 
GO

ALTER DATABASE [KPMG] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [KPMG] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [KPMG] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [KPMG] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [KPMG] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [KPMG] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [KPMG] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [KPMG] SET RECOVERY FULL 
GO

ALTER DATABASE [KPMG] SET  MULTI_USER 
GO

ALTER DATABASE [KPMG] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [KPMG] SET DB_CHAINING OFF 
GO

ALTER DATABASE [KPMG] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [KPMG] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [KPMG] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [KPMG] SET  READ_WRITE 
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TransactionData](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[Currency] [nvarchar](3) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_TransactionData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO