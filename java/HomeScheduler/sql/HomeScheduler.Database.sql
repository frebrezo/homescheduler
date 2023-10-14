USE [master]
GO
/****** Object:  Database [HomeScheduler]    Script Date: 10/3/2023 8:22:36 PM ******/
CREATE DATABASE [HomeScheduler]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HomeScheduler', FILENAME = N'C:\Data\MSSQL16.MSSQLSERVER\MSSQL\DATA\HomeScheduler.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HomeScheduler_log', FILENAME = N'C:\Data\MSSQL16.MSSQLSERVER\MSSQL\DATA\HomeScheduler_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HomeScheduler] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HomeScheduler].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HomeScheduler] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HomeScheduler] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HomeScheduler] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HomeScheduler] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HomeScheduler] SET ARITHABORT OFF 
GO
ALTER DATABASE [HomeScheduler] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HomeScheduler] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HomeScheduler] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HomeScheduler] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HomeScheduler] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HomeScheduler] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HomeScheduler] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HomeScheduler] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HomeScheduler] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HomeScheduler] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HomeScheduler] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HomeScheduler] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HomeScheduler] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HomeScheduler] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HomeScheduler] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HomeScheduler] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HomeScheduler] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HomeScheduler] SET RECOVERY FULL 
GO
ALTER DATABASE [HomeScheduler] SET  MULTI_USER 
GO
ALTER DATABASE [HomeScheduler] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HomeScheduler] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HomeScheduler] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HomeScheduler] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HomeScheduler] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HomeScheduler] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HomeScheduler', N'ON'
GO
ALTER DATABASE [HomeScheduler] SET QUERY_STORE = OFF
GO
ALTER DATABASE [HomeScheduler] SET  READ_WRITE 
GO
