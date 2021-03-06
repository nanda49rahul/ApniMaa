USE [master]
GO
/****** Object:  Database [ApniMaaDB]    Script Date: 31-Mar-19 4:40:37 PM ******/
CREATE DATABASE [ApniMaaDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ApniMaaDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ApniMaaDB.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ApniMaaDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ApniMaaDB_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ApniMaaDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ApniMaaDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ApniMaaDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ApniMaaDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ApniMaaDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ApniMaaDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ApniMaaDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ApniMaaDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ApniMaaDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ApniMaaDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ApniMaaDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ApniMaaDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ApniMaaDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ApniMaaDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ApniMaaDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ApniMaaDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ApniMaaDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ApniMaaDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ApniMaaDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ApniMaaDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ApniMaaDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ApniMaaDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ApniMaaDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ApniMaaDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ApniMaaDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ApniMaaDB] SET  MULTI_USER 
GO
ALTER DATABASE [ApniMaaDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ApniMaaDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ApniMaaDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ApniMaaDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ApniMaaDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ApniMaaDB', N'ON'
GO
USE [ApniMaaDB]
GO
/****** Object:  Table [dbo].[Achievements]    Script Date: 31-Mar-19 4:40:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Achievements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Points] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AdminUsers]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminUsers](
	[AdminUserId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](50) NULL,
	[Password] [nvarchar](max) NOT NULL,
	[RoleId] [int] NOT NULL CONSTRAINT [DF__Users__IsAdmin__4AB81AF0]  DEFAULT ((0)),
	[Description] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NULL,
	[UpdatedDate] [datetime2](0) NULL,
	[UpdatedBy] [int] NULL,
	[IsSuperAdmin] [bit] NULL,
	[IsActive] [bit] NOT NULL DEFAULT ((1)),
	[IsDeleted] [bit] NULL DEFAULT ((1)),
	[Token] [nvarchar](100) NULL,
	[ForgotPassword] [nvarchar](100) NULL,
	[IsPermissonUpdated] [bit] NULL,
 CONSTRAINT [PK_Users_UserI] PRIMARY KEY CLUSTERED 
(
	[AdminUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cart]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[GuestId] [int] NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
	[Tax] [decimal](18, 2) NOT NULL,
	[Packing] [decimal](18, 2) NOT NULL,
	[Delivery] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[OrderStatus] [int] NOT NULL,
	[CouponId] [int] NULL,
	[DiscountAmount] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1) NOT NULL,
	[Description] [nvarchar](1) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[City]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProvinceId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedDate] [datetime] NOT NULL,
	[lastModified] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CMSPages]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CMSPages](
	[PageId] [int] IDENTITY(1,1) NOT NULL,
	[PageName] [varchar](250) NOT NULL,
	[PageTitle] [varchar](250) NULL,
	[PageContent] [nvarchar](max) NULL,
	[MetaTitle] [varchar](500) NULL,
	[MetaKeywords] [varchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_CMSPages_PageId] PRIMARY KEY CLUSTERED 
(
	[PageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Country]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](200) NULL,
	[CountryShortCode] [varchar](50) NULL,
 CONSTRAINT [PK_Country_CountryID] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Coupons]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coupons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](1) NOT NULL,
	[Discount] [int] NOT NULL,
	[CouponType] [int] NOT NULL,
	[MinOrderValue] [int] NOT NULL,
	[IsAvailableForAll] [bit] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[Enddate] [datetime] NOT NULL,
	[AvailType] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Dishes]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dishes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmailTemplates]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmailTemplates](
	[TemplateId] [int] IDENTITY(1,1) NOT NULL,
	[TemplateName] [varchar](50) NULL,
	[EmailSubject] [nvarchar](500) NULL,
	[TemplateContent] [nvarchar](max) NULL,
	[TemplateStatus] [bit] NOT NULL DEFAULT ((1)),
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
	[TemplateType] [int] NOT NULL,
 CONSTRAINT [PK_EmailTemplates_TemplateId] PRIMARY KEY CLUSTERED 
(
	[TemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[ErrorLogID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [varchar](500) NULL,
	[StackTrace] [varchar](max) NULL,
	[InnerException] [varchar](max) NULL,
	[LoggedInDetails] [varchar](max) NULL,
	[QueryData] [varchar](max) NULL,
	[FormData] [varchar](max) NULL,
	[RouteData] [varchar](max) NULL,
	[LoggedAt] [datetime] NULL,
 CONSTRAINT [PK_ErrorLog_ErrorLogID] PRIMARY KEY CLUSTERED 
(
	[ErrorLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Favourites]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favourites](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[MotherId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Guest]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[City] [int] NULL,
	[Province] [int] NULL,
	[Address] [nvarchar](max) NULL,
	[Longitute] [nvarchar](max) NULL,
	[Latitute] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Levels]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Levels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Points] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Modules]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modules](
	[ModuleId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleName] [nvarchar](500) NULL,
	[ControllerName] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[IsAdmin] [bit] NULL,
	[IsSubUser] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_Modules] PRIMARY KEY CLUSTERED 
(
	[ModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MortherOrders]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MortherOrders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MotherId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
	[Tax] [decimal](18, 2) NOT NULL,
	[Packing] [decimal](18, 2) NOT NULL,
	[Delivery] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[OrderStatus] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotherAnswers]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherAnswers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MotherId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[Answer] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotherBankDetails]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherBankDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MotherId] [int] NOT NULL,
	[AccountNo] [nvarchar](max) NOT NULL,
	[BankName] [nvarchar](max) NOT NULL,
	[AccountHolderName] [nvarchar](max) NOT NULL,
	[IFSC_Code] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotherCart]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherCart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MotherId] [int] NOT NULL,
	[CartId] [int] NOT NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
	[Tax] [decimal](18, 2) NOT NULL,
	[Packing] [decimal](18, 2) NOT NULL,
	[Delivery] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[OrderStatus] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotherCartDetails]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherCartDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MotherCartId] [int] NOT NULL,
	[MotherDishId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotherCoupons]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherCoupons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MotherId] [int] NOT NULL,
	[CouponId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotherDailySchedule]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherDailySchedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MotherId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Type] [int] NOT NULL,
	[Availabilty] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotherDish]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherDish](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MotherId] [int] NOT NULL,
	[DishId] [int] NOT NULL,
	[Limit] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsMainDish] [bit] NOT NULL,
	[IsSignatureDish] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotherDishDailySchedule]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherDishDailySchedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MotherDishId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[Availabilty] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotherDishReviews]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherDishReviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MotherDishId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Review] [nvarchar](max) NOT NULL,
	[Image1] [nvarchar](max) NOT NULL,
	[Image2] [nvarchar](max) NOT NULL,
	[Image3] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotherGallery]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherGallery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MotherId] [int] NOT NULL,
	[Caption] [nvarchar](max) NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotherOrderDetails]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherOrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MotherOrderId] [int] NOT NULL,
	[MotherDishId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotherQuestions]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherQuestions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](max) NOT NULL,
	[Answertype] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotherStatement]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherStatement](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MotherId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[TransactionNo] [nvarchar](max) NOT NULL,
	[AmountReceived] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotherTbl]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotherTbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ApplicationNo] [nvarchar](max) NOT NULL,
	[Ratings] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[LOfflineTime] [nvarchar](max) NOT NULL,
	[DOfflineTime] [nvarchar](max) NOT NULL,
	[LDeliveryTime] [nvarchar](max) NOT NULL,
	[DDeliveryTime] [nvarchar](max) NOT NULL,
	[ProfilePhoto] [nvarchar](max) NULL,
	[CoverPhoto] [nvarchar](max) NULL,
	[Commision] [decimal](18, 2) NOT NULL,
	[WalletAmount] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Notificationss]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notificationss](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[NotificationType] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[GuestId] [int] NULL,
	[Subtotal] [decimal](18, 2) NOT NULL,
	[Tax] [decimal](18, 2) NOT NULL,
	[Packing] [decimal](18, 2) NOT NULL,
	[Delivery] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[OrderStatus] [int] NOT NULL,
	[CouponId] [int] NULL,
	[DiscountAmount] [decimal](18, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OTP]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OTP](
	[OTPId] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[OTPCode] [nvarchar](50) NOT NULL,
	[MobileNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_OTP] PRIMARY KEY CLUSTERED 
(
	[OTPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentDetails]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[TransactionId] [int] NOT NULL,
	[Mode] [int] NOT NULL,
	[InvoiceNo] [nvarchar](max) NOT NULL,
	[InvoiceLink] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Province]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedDate] [datetime] NOT NULL,
	[lastModified] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PushNotificationsMessageLogs]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PushNotificationsMessageLogs](
	[PushNotificationsMessageLogsId] [int] IDENTITY(1,1) NOT NULL,
	[DeviceToken] [nvarchar](200) NOT NULL,
	[DeviceType] [int] NOT NULL,
	[DeviceID] [nvarchar](200) NULL,
	[Status] [int] NOT NULL,
	[DateProcessed] [datetime] NOT NULL,
	[FKReceiverUserId] [int] NULL,
	[FKQueuedPushNotificationsId] [int] NULL,
	[ErrorMessage] [nvarchar](max) NULL,
	[JsonData] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_PushNotificationsMessageLogs] PRIMARY KEY CLUSTERED 
(
	[PushNotificationsMessageLogsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QueuedPushNotifications]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QueuedPushNotifications](
	[QueuedPushNotificationsId] [int] IDENTITY(1,1) NOT NULL,
	[NotificationType] [int] NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Badge] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateProcessed] [datetime] NULL,
	[JsonData] [nvarchar](max) NULL,
	[FKSenderUserId] [int] NULL,
	[FKReceiverUserId] [int] NOT NULL,
 CONSTRAINT [PK_QueuedPushNotifications] PRIMARY KEY CLUSTERED 
(
	[QueuedPushNotificationsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserAchievements]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAchievements](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[AchievementId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserAddressTbl]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAddressTbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[City] [int] NOT NULL,
	[Province] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Longitute] [nvarchar](max) NOT NULL,
	[Latitute] [nvarchar](max) NOT NULL,
	[NickName] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserAssignedModules]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAssignedModules](
	[UserAssignedModuleId] [int] IDENTITY(1,1) NOT NULL,
	[AdminUserID] [int] NULL,
	[ModuleId] [int] NULL,
	[CreatedDate] [datetime2](0) NULL,
	[CreatedBy] [int] NULL,
	[UpdatedDate] [datetime2](0) NULL,
	[UpdatedBy] [int] NULL,
	[IsDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserAssignedModuleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserEnquiry]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserEnquiry](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Reply] [nvarchar](max) NULL,
	[IsReplied] [bit] NOT NULL,
	[IsResolved] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserLoginSessions]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLoginSessions](
	[UserLoginSessionID] [uniqueidentifier] NOT NULL,
	[UserId] [int] NOT NULL,
	[LoggedInTime] [datetime] NOT NULL,
	[LoggedOutTime] [datetime] NULL,
	[SessionExpired] [bit] NOT NULL,
	[LastActivityTime] [datetime] NULL,
	[IsActive] [bit] NULL,
	[UniqueDeviceId] [nvarchar](200) NOT NULL,
	[DeviceToken] [nvarchar](200) NULL,
	[DeviceType] [int] NULL,
	[TokenVOIP] [nvarchar](200) NULL,
 CONSTRAINT [PK_UserLoginSessions] PRIMARY KEY CLUSTERED 
(
	[UserLoginSessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[UserType] [int] NOT NULL,
	[LastLogin] [datetime] NULL,
	[LastLogout] [datetime] NULL,
	[CreatedAt] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[DeletedOn] [datetime] NULL,
 CONSTRAINT [PK_Users_UserID] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserTbl]    Script Date: 31-Mar-19 4:40:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTbl](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Phone] [nvarchar](max) NOT NULL,
	[OTP] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[City] [int] NOT NULL,
	[Province] [int] NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[Longitute] [nvarchar](max) NOT NULL,
	[Latitute] [nvarchar](max) NOT NULL,
	[RoleId] [int] NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AdminUsers] ON 

INSERT [dbo].[AdminUsers] ([AdminUserId], [Email], [FirstName], [LastName], [Address], [Phone], [Password], [RoleId], [Description], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsSuperAdmin], [IsActive], [IsDeleted], [Token], [ForgotPassword], [IsPermissonUpdated]) VALUES (1, N'admin@xicom.biz', N'Super', N'Admin', NULL, NULL, N'QZbmASg8Utw=', 2, NULL, CAST(N'2018-04-16 11:14:35.000' AS DateTime), NULL, CAST(N'2018-04-16 11:14:35.0000000' AS DateTime2), NULL, 1, 1, 0, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[AdminUsers] OFF
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([Id], [ProvinceId], [Name], [IsDeleted], [CreatedDate], [lastModified]) VALUES (3, 1, N'Delhi', 0, CAST(N'2013-11-09 17:54:57.173' AS DateTime), CAST(N'2013-11-09 17:54:57.173' AS DateTime))
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[CMSPages] ON 

INSERT [dbo].[CMSPages] ([PageId], [PageName], [PageTitle], [PageContent], [MetaTitle], [MetaKeywords], [MetaDescription], [CreatedOn], [UpdatedOn]) VALUES (1, N'AboutUs123', N'About Us', N'<h1>About Us Updated</h1>
', N'About Us', N'About Us,Demo', N'About Us Demo', CAST(N'2015-05-27 00:00:00.000' AS DateTime), CAST(N'2015-05-28 11:24:27.090' AS DateTime))
INSERT [dbo].[CMSPages] ([PageId], [PageName], [PageTitle], [PageContent], [MetaTitle], [MetaKeywords], [MetaDescription], [CreatedOn], [UpdatedOn]) VALUES (2, N'TermsAndConditions', N'Terms and Conditions', N'<h1>Terms and Conditions</h1>', N'Terms and Conditions', N'Terms', NULL, CAST(N'2015-05-27 00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[CMSPages] ([PageId], [PageName], [PageTitle], [PageContent], [MetaTitle], [MetaKeywords], [MetaDescription], [CreatedOn], [UpdatedOn]) VALUES (3, N'Privacy Policy', N'Privacy Policy', N'<h1>Privacy</h1>', NULL, NULL, NULL, CAST(N'2015-05-27 00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[CMSPages] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (1, N'United States', N'US')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (2, N'India', N'IN')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (3, N'Afghanistan', N'AF')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (4, N'Albania', N'AL')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (5, N'Algeria', N'DZ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (6, N'Andorra', N'AD')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (7, N'Angola', N'AO')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (8, N'Antigua and Barbuda', N'AG')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (9, N'Argentina', N'AR')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (10, N'Armenia', N'AM')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (11, N'Australia', N'AU')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (12, N'Austria', N'AT')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (13, N'Azerbaijan', N'AZ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (14, N'Bahamas', N'BS')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (15, N'Bahrain', N'BH')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (16, N'Bangladesh', N'BD')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (17, N'Barbados', N'BB')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (18, N'Belarus', N'BY')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (19, N'Belgium', N'BE')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (20, N'Belize', N'BZ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (21, N'Benin', N'BJ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (22, N'Bermuda', N'BM')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (23, N'Bhutan', N'BT')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (24, N'Bolivia', N'BO')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (25, N'Bosnia and Herzegovina', N'BA')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (26, N'Botswana', N'BW')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (27, N'Brazil', N'BR')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (28, N'Bulgaria', N'BG')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (29, N'Burkina Faso', N'BF')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (30, N'Burundi', N'BI')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (31, N'Cambodia', N'KH')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (32, N'Cameroon', N'CM')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (33, N'Canada', N'CA')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (34, N'Cape Verde', N'CV')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (35, N'Central African Republic', N'CF')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (36, N'Chad', N'TD')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (37, N'Chile', N'CL')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (38, N'China', N'CN')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (39, N'Colombia', N'CO')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (40, N'Comoros', N'KM')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (41, N'Congo', N'CG')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (42, N'Congo  The Democratic Republic of the', N'CD')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (43, N'Costa Rica', N'CR')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (44, N'Cote d''Ivoire', N'CI')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (45, N'Croatia', N'HR')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (46, N'Cuba', N'CU')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (47, N'Cyprus', N'CY')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (48, N'Czech Republic', N'CZ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (49, N'Denmark', N'DK')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (50, N'Dominica', N'DM')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (51, N'Dominican Republic', N'DO')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (52, N'Ecuador', N'EC')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (53, N'Egypt', N'EG')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (54, N'El Salvador', N'SV')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (55, N'Equatorial Guinea', N'GQ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (56, N'Estonia', N'EE')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (57, N'Ethiopia', N'ET')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (58, N'Fiji', N'FJ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (59, N'Finland', N'FI')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (60, N'France', N'FR')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (61, N'Gabon', N'GA')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (62, N'Gambia', N'GM')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (63, N'Georgia', N'GE')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (64, N'Germany', N'DE')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (65, N'Ghana', N'GH')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (66, N'Greece', N'GR')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (67, N'Greenland', N'GL')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (68, N'Grenada', N'GD')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (69, N'Guatemala', N'GT')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (70, N'Guinea', N'GN')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (71, N'Guinea-Bissau', N'GW')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (72, N'Guyana', N'GY')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (73, N'Haiti', N'HT')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (74, N'Honduras', N'HN')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (75, N'Hungary', N'HU')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (76, N'Iceland', N'IS')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (77, N'Indonesia', N'ID')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (78, N'Iran  Islamic Republic of', N'IR')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (79, N'Iraq', N'IQ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (80, N'Ireland', N'IE')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (81, N'Israel', N'IL')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (82, N'Italy', N'IT')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (83, N'Jamaica', N'JM')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (84, N'Japan', N'JP')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (85, N'Jordan', N'JO')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (86, N'Kazakhstan', N'KZ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (87, N'Kenya', N'KE')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (88, N'Korea  Republic of', N'KR')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (89, N'Kuwait', N'KW')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (90, N'Kyrgyzstan', N'KG')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (91, N'Lao People''s Democratic Republic', N'LA')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (92, N'Latvia', N'LV')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (93, N'Lebanon', N'LB')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (94, N'Lesotho', N'LS')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (95, N'Liberia', N'LR')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (96, N'Libyan Arab Jamahiriya', N'LY')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (97, N'Liechtenstein', N'LI')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (98, N'Lithuania', N'LT')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (99, N'Luxembourg', N'LU')
GO
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (100, N'Macao', N'MO')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (101, N'Macedonia', N'MK')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (102, N'Madagascar', N'MG')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (103, N'Malawi', N'MW')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (104, N'Malaysia', N'MY')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (105, N'Maldives', N'MV')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (106, N'Mali', N'ML')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (107, N'Mauritania', N'MR')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (108, N'Mauritius', N'MU')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (109, N'Mexico', N'MX')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (110, N'Moldova  Republic of', N'MD')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (111, N'Mongolia', N'MN')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (112, N'Montserrat', N'MS')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (113, N'Morocco', N'MA')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (114, N'Mozambique', N'MZ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (115, N'Myanmar', N'MM')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (116, N'Namibia', N'NA')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (117, N'Netherlands', N'NL')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (118, N'New Zealand', N'NZ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (119, N'Nicaragua', N'NI')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (120, N'Niger', N'NE')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (121, N'Nigeria', N'NG')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (122, N'Norway', N'NO')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (123, N'Oman', N'OM')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (124, N'Pakistan', N'PK')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (125, N'Panama', N'PA')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (126, N'Papua New Guinea', N'PG')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (127, N'Paraguay', N'PY')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (128, N'Peru', N'PE')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (129, N'Philippines', N'PH')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (130, N'Poland', N'PL')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (131, N'Portugal', N'PT')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (132, N'Qatar', N'QA')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (133, N'Romania', N'RO')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (134, N'Russian Federation', N'RU')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (135, N'Rwanda', N'RW')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (136, N'Saint Kitts and Nevis', N'KN')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (137, N'Saint Lucia', N'LC')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (138, N'Saint Vincent and the Grenadines', N'VC')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (139, N'San Marino', N'SM')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (140, N'Sao Tome and Principe', N'ST')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (141, N'Saudi Arabia', N'SA')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (142, N'Senegal', N'SN')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (143, N'Serbia', N'RS')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (144, N'Seychelles', N'SC')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (145, N'Sierra Leone', N'SL')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (146, N'Slovakia', N'SK')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (147, N'Slovenia', N'SI')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (148, N'Solomon Islands', N'SB')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (149, N'Somalia', N'SO')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (150, N'South Africa', N'ZA')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (151, N'Spain', N'ES')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (152, N'Sri Lanka', N'LK')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (153, N'Sudan', N'SD')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (154, N'Suriname', N'SR')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (155, N'Swaziland', N'SZ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (156, N'Sweden', N'SE')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (157, N'Switzerland', N'CH')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (158, N'Syrian Arab Republic', N'SY')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (159, N'Taiwan', N'TW')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (160, N'Tajikistan', N'TJ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (161, N'Tanzania  United Republic of', N'TZ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (162, N'Thailand', N'TH')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (163, N'Togo', N'TG')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (164, N'Trinidad and Tobago', N'TT')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (165, N'Tunisia', N'TN')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (166, N'Turkey', N'TR')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (167, N'Turkmenistan', N'TM')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (168, N'Uganda', N'UG')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (169, N'Ukraine', N'UA')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (170, N'United Arab Emirates', N'AE')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (171, N'United Kingdom', N'GB')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (172, N'Uruguay', N'UY')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (173, N'Uzbekistan', N'UZ')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (174, N'Vanuatu', N'VU')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (175, N'Venezuela', N'VE')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (176, N'Vietnam', N'VN')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (177, N'Yemen', N'YE')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (178, N'Zambia', N'ZM')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (179, N'Zimbabwe', N'ZW')
INSERT [dbo].[Country] ([CountryID], [CountryName], [CountryShortCode]) VALUES (180, N'Everywhere Else', N'EF')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[EmailTemplates] ON 

INSERT [dbo].[EmailTemplates] ([TemplateId], [TemplateName], [EmailSubject], [TemplateContent], [TemplateStatus], [CreatedOn], [UpdatedOn], [TemplateType]) VALUES (1, N'Sign Up', N'Welcome to Demo Template', N'<p>Hello this is a demo template.</p>
', 1, CAST(N'2015-05-27 10:29:58.420' AS DateTime), CAST(N'2015-06-09 10:59:38.257' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[EmailTemplates] OFF
SET IDENTITY_INSERT [dbo].[ErrorLog] ON 

INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (3, N'String reference not set to an instance of a String.
Parameter name: s', N'   at System.Text.Encoding.GetBytes(String s)
   at Mvc4BaseProject.BLL.Classes.Extensions.Encrypt(String str) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Extensions.cs:line 29
   at Mvc4BaseProject.BLL.Repositories.ApplicationRepository.Login(String email, String password, Boolean checkAdmin) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Repositories\ApplicationRepository.cs:line 115
   at Mvc4BaseProject.Areas.Admin.Controllers.HomeController.Login(AdminLoginModel obj) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Controllers\HomeController.cs:line 29
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass42.<BeginInvokeSynchronousActionMethod>b__41()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass8`1.<BeginSynchronous>b__7(IAsyncResult _)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<>c__DisplayClass39.<BeginInvokeActionMethodWithFilters>b__33()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass4f.<InvokeActionMethodFilterAsynchronously>b__49()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeActionMethodWithFilters>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[{"Name":"Email","Value":"sudeep@xicom.biz"},{"Name":"Password","Value":"1"},{"Name":"RememberMe","Value":"false"}]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"Login"}]', CAST(N'2013-11-09 17:30:00.107' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (5, N'The layout page "~Areas/Admin/Views/Shared/_Layout.cshtml" could not be found at the following path: "~/Areas/Admin/Views/Home/~Areas/Admin/Views/Shared/_Layout.cshtml".', N'   at System.Web.WebPages.WebPageExecutingBase.NormalizeLayoutPagePath(String layoutPagePath)
   at System.Web.WebPages.WebPageBase.PopContext()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<InvokeActionResultWithFilters>b__17()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilter(IResultFilter filter, ResultExecutingContext preContext, Func`1 continuation)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<>c__DisplayClass1c.<InvokeActionResultWithFilters>b__19()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"Dashboard"}]', CAST(N'2013-11-09 17:49:33.723' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (6, N'The query syntax is not valid. Near line 6, column 5.', N'   at System.Data.Common.EntitySql.CqlParser.yyerror(String s)
   at System.Data.Common.EntitySql.CqlParser.yyparse()
   at System.Data.Common.EntitySql.CqlParser.internalParseEntryPoint()
   at System.Data.Common.EntitySql.CqlParser.Parse(String query)
   at System.Data.Common.EntitySql.CqlQuery.Parse(String commandText, ParserOptions parserOptions)
   at System.Data.Common.EntitySql.CqlQuery.CompileCommon[TResult](String commandText, Perspective perspective, ParserOptions parserOptions, Func`3 compilationFunction)
   at System.Data.Common.EntitySql.CqlQuery.CompileQueryCommandLambda(String queryCommandText, Perspective perspective, ParserOptions parserOptions, IEnumerable`1 parameters, IEnumerable`1 variables)
   at System.Data.Objects.EntitySqlQueryState.Parse()
   at System.Data.Objects.ELinq.ExpressionConverter.TranslateInlineQueryOfT(ObjectQuery inlineQuery)
   at System.Data.Objects.ELinq.ExpressionConverter.ConstantTranslator.TypedTranslate(ExpressionConverter parent, ConstantExpression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.TypedTranslator`1.Translate(ExpressionConverter parent, Expression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.TranslateExpression(Expression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.MethodCallTranslator.ObjectQueryMergeAsTranslator.Translate(ExpressionConverter parent, MethodCallExpression call)
   at System.Data.Objects.ELinq.ExpressionConverter.MethodCallTranslator.TypedTranslate(ExpressionConverter parent, MethodCallExpression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.TypedTranslator`1.Translate(ExpressionConverter parent, Expression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.TranslateExpression(Expression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.MethodCallTranslator.ObjectQueryMergeAsTranslator.Translate(ExpressionConverter parent, MethodCallExpression call)
   at System.Data.Objects.ELinq.ExpressionConverter.MethodCallTranslator.TypedTranslate(ExpressionConverter parent, MethodCallExpression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.TypedTranslator`1.Translate(ExpressionConverter parent, Expression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.TranslateExpression(Expression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.MethodCallTranslator.OneLambdaTranslator.Translate(ExpressionConverter parent, MethodCallExpression call, DbExpression& source, DbExpressionBinding& sourceBinding, DbExpression& lambda)
   at System.Data.Objects.ELinq.ExpressionConverter.MethodCallTranslator.OneLambdaTranslator.Translate(ExpressionConverter parent, MethodCallExpression call)
   at System.Data.Objects.ELinq.ExpressionConverter.MethodCallTranslator.SequenceMethodTranslator.Translate(ExpressionConverter parent, MethodCallExpression call, SequenceMethod sequenceMethod)
   at System.Data.Objects.ELinq.ExpressionConverter.MethodCallTranslator.TypedTranslate(ExpressionConverter parent, MethodCallExpression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.TypedTranslator`1.Translate(ExpressionConverter parent, Expression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.TranslateExpression(Expression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.MethodCallTranslator.AggregateTranslator.Translate(ExpressionConverter parent, MethodCallExpression call)
   at System.Data.Objects.ELinq.ExpressionConverter.MethodCallTranslator.SequenceMethodTranslator.Translate(ExpressionConverter parent, MethodCallExpression call, SequenceMethod sequenceMethod)
   at System.Data.Objects.ELinq.ExpressionConverter.MethodCallTranslator.TypedTranslate(ExpressionConverter parent, MethodCallExpression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.TypedTranslator`1.Translate(ExpressionConverter parent, Expression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.TranslateExpression(Expression linq)
   at System.Data.Objects.ELinq.ExpressionConverter.Convert()
   at System.Data.Objects.ELinq.ELinqQueryState.GetExecutionPlan(Nullable`1 forMergeOption)
   at System.Data.Objects.ObjectQuery`1.GetResults(Nullable`1 forMergeOption)
   at System.Data.Objects.ObjectQuery`1.System.Collections.Generic.IEnumerable<T>.GetEnumerator()
   at System.Linq.Enumerable.Single[TSource](IEnumerable`1 source)
   at System.Data.Objects.ELinq.ObjectQueryProvider.<GetElementFunction>b__3[TResult](IEnumerable`1 sequence)
   at System.Data.Objects.ELinq.ObjectQueryProvider.ExecuteSingle[TResult](IEnumerable`1 query, Expression queryRoot)
   at System.Data.Objects.ELinq.ObjectQueryProvider.System.Linq.IQueryProvider.Execute[S](Expression expression)
   at System.Linq.Queryable.Count[TSource](IQueryable`1 source)
   at Mvc4BaseProject.BLL.Repositories.UserRepository.Get(ManageUserSearchInfo searchInfo, GridInfo gridInfo) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Repositories\UserRepository.cs:line 32
   at Mvc4BaseProject.Areas.Admin.Controllers.HomeController.ManageUsers(ManageUserSearchInfo searchInfo, GridInfo gridInfo) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Controllers\HomeController.cs:line 63
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass42.<BeginInvokeSynchronousActionMethod>b__41()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass8`1.<BeginSynchronous>b__7(IAsyncResult _)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<>c__DisplayClass39.<BeginInvokeActionMethodWithFilters>b__33()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass4f.<InvokeActionMethodFilterAsynchronously>b__49()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeActionMethodWithFilters>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUsers"}]', CAST(N'2013-11-11 18:05:16.827' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (7, N'c:\Users\xicom\AppData\Local\Temp\Temporary ASP.NET Files\root\ff0fdb4f\deaeba80\App_Web_manageusers.cshtml.7befced2.wy31pwvv.0.cs(40): error CS0012: The type ''System.Data.Objects.DataClasses.EntityObject'' is defined in an assembly that is not referenced. You must add a reference to assembly ''System.Data.Entity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089''.', N'   at System.Web.Compilation.AssemblyBuilder.Compile()
   at System.Web.Compilation.BuildProvidersCompiler.PerformBuild()
   at System.Web.Compilation.BuildManager.CompileWebFile(VirtualPath virtualPath)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultInternal(VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultWithNoAssert(HttpContext context, VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVirtualPathObjectFactory(VirtualPath virtualPath, HttpContext context, Boolean allowCrossApp, Boolean throwIfNotFound)
   at System.Web.Compilation.BuildManager.GetObjectFactory(String virtualPath, Boolean throwIfNotFound)
   at System.Web.Mvc.BuildManagerWrapper.System.Web.Mvc.IBuildManager.FileExists(String virtualPath)
   at System.Web.Mvc.BuildManagerViewEngine.FileExists(ControllerContext controllerContext, String virtualPath)
   at System.Web.Mvc.VirtualPathProviderViewEngine.<>c__DisplayClass4.<GetPathFromGeneralName>b__0(String path)
   at System.Web.WebPages.DefaultDisplayMode.GetDisplayInfo(HttpContextBase httpContext, String virtualPath, Func`2 virtualPathExists)
   at System.Web.WebPages.DisplayModeProvider.<>c__DisplayClassb.<GetDisplayInfoForVirtualPath>b__8(IDisplayMode mode)
   at System.Linq.Enumerable.WhereSelectListIterator`2.MoveNext()
   at System.Linq.Enumerable.FirstOrDefault[TSource](IEnumerable`1 source, Func`2 predicate)
   at System.Web.WebPages.DisplayModeProvider.GetDisplayInfoForVirtualPath(String virtualPath, HttpContextBase httpContext, Func`2 virtualPathExists, IDisplayMode currentDisplayMode, Boolean requireConsistentDisplayMode)
   at System.Web.Mvc.VirtualPathProviderViewEngine.GetPathFromGeneralName(ControllerContext controllerContext, List`1 locations, String name, String controllerName, String areaName, String cacheKey, String[]& searchedLocations)
   at System.Web.Mvc.VirtualPathProviderViewEngine.GetPath(ControllerContext controllerContext, String[] locations, String[] areaLocations, String locationsPropertyName, String name, String controllerName, String cacheKeyPrefix, Boolean useCache, String[]& searchedLocations)
   at System.Web.Mvc.VirtualPathProviderViewEngine.FindView(ControllerContext controllerContext, String viewName, String masterName, Boolean useCache)
   at System.Web.Mvc.ViewEngineCollection.<>c__DisplayClassc.<FindView>b__b(IViewEngine e)
   at System.Web.Mvc.ViewEngineCollection.Find(Func`2 lookup, Boolean trackSearchedPaths)
   at System.Web.Mvc.ViewEngineCollection.FindView(ControllerContext controllerContext, String viewName, String masterName)
   at System.Web.Mvc.ViewResult.FindView(ControllerContext context)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<InvokeActionResultWithFilters>b__17()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilter(IResultFilter filter, ResultExecutingContext preContext, Func`1 continuation)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<>c__DisplayClass1c.<InvokeActionResultWithFilters>b__19()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUsers"}]', CAST(N'2013-11-11 18:06:07.977' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (8, N'c:\Users\xicom\AppData\Local\Temp\Temporary ASP.NET Files\root\ff0fdb4f\deaeba80\App_Web_manageusers.cshtml.7befced2.ppw8yh9a.0.cs(40): error CS0012: The type ''System.Data.Objects.DataClasses.EntityObject'' is defined in an assembly that is not referenced. You must add a reference to assembly ''System.Data.Entity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089''.', N'   at System.Web.Compilation.AssemblyBuilder.Compile()
   at System.Web.Compilation.BuildProvidersCompiler.PerformBuild()
   at System.Web.Compilation.BuildManager.CompileWebFile(VirtualPath virtualPath)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultInternal(VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultWithNoAssert(HttpContext context, VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVirtualPathObjectFactory(VirtualPath virtualPath, HttpContext context, Boolean allowCrossApp, Boolean throwIfNotFound)
   at System.Web.Compilation.BuildManager.GetObjectFactory(String virtualPath, Boolean throwIfNotFound)
   at System.Web.Mvc.BuildManagerWrapper.System.Web.Mvc.IBuildManager.FileExists(String virtualPath)
   at System.Web.Mvc.BuildManagerViewEngine.FileExists(ControllerContext controllerContext, String virtualPath)
   at System.Web.Mvc.VirtualPathProviderViewEngine.<>c__DisplayClass4.<GetPathFromGeneralName>b__0(String path)
   at System.Web.WebPages.DefaultDisplayMode.GetDisplayInfo(HttpContextBase httpContext, String virtualPath, Func`2 virtualPathExists)
   at System.Web.WebPages.DisplayModeProvider.<>c__DisplayClassb.<GetDisplayInfoForVirtualPath>b__8(IDisplayMode mode)
   at System.Linq.Enumerable.WhereSelectListIterator`2.MoveNext()
   at System.Linq.Enumerable.FirstOrDefault[TSource](IEnumerable`1 source, Func`2 predicate)
   at System.Web.WebPages.DisplayModeProvider.GetDisplayInfoForVirtualPath(String virtualPath, HttpContextBase httpContext, Func`2 virtualPathExists, IDisplayMode currentDisplayMode, Boolean requireConsistentDisplayMode)
   at System.Web.Mvc.VirtualPathProviderViewEngine.GetPathFromGeneralName(ControllerContext controllerContext, List`1 locations, String name, String controllerName, String areaName, String cacheKey, String[]& searchedLocations)
   at System.Web.Mvc.VirtualPathProviderViewEngine.GetPath(ControllerContext controllerContext, String[] locations, String[] areaLocations, String locationsPropertyName, String name, String controllerName, String cacheKeyPrefix, Boolean useCache, String[]& searchedLocations)
   at System.Web.Mvc.VirtualPathProviderViewEngine.FindView(ControllerContext controllerContext, String viewName, String masterName, Boolean useCache)
   at System.Web.Mvc.ViewEngineCollection.<>c__DisplayClassc.<FindView>b__b(IViewEngine e)
   at System.Web.Mvc.ViewEngineCollection.Find(Func`2 lookup, Boolean trackSearchedPaths)
   at System.Web.Mvc.ViewEngineCollection.FindView(ControllerContext controllerContext, String viewName, String masterName)
   at System.Web.Mvc.ViewResult.FindView(ControllerContext context)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<InvokeActionResultWithFilters>b__17()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilter(IResultFilter filter, ResultExecutingContext preContext, Func`1 continuation)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<>c__DisplayClass1c.<InvokeActionResultWithFilters>b__19()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUsers"}]', CAST(N'2013-11-11 18:08:03.553' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (9, N'Attempted to divide by zero.', N'   at Mvc4BaseProject.BLL.Classes.PagingModal.get_SelectedPagerPage() in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Pager.cs:line 66
   at Mvc4BaseProject.BLL.Classes.PagingModal.get_FirstItemOnSelectedPagerPage() in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Pager.cs:line 70
   at Mvc4BaseProject.BLL.Classes.PagingModal..ctor(GridInfo gridInfo) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Pager.cs:line 34
   at ASP._Page_Areas_Admin_Views_Home_ManageUsers_cshtml.Execute() in d:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Views\Home\ManageUsers.cshtml:line 41
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<InvokeActionResultWithFilters>b__17()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilter(IResultFilter filter, ResultExecutingContext preContext, Func`1 continuation)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<>c__DisplayClass1c.<InvokeActionResultWithFilters>b__19()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUsers"}]', CAST(N'2013-11-11 18:08:26.160' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (10, N'Object reference not set to an instance of an object.', N'   at Mvc4BaseProject.BLL.Classes.Grid.GenerateLink(HtmlHelper helper, PagingModal pager, Object routeValues) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Grid.cs:line 93
   at Mvc4BaseProject.BLL.Classes.Grid.ColumnHeader(HtmlHelper helper, PagingModal pager, String title, Object routeValues, Object htmlAttributes) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Grid.cs:line 107
   at Mvc4BaseProject.Helpers.Helpers.ColumnHeader(HtmlHelper helper, PagingModal pager, String title, Object routeValues, Object htmlAttributes) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Helpers\Helpers.cs:line 32
   at ASP._Page_Areas_Admin_Views_Home_Partials__ManageUsers_cshtml.Execute() in d:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Views\Home\Partials\_ManageUsers.cshtml:line 7
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at Mvc4BaseProject.Controllers.BaseController.RenderRazorViewToString(String view_name, Object model) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Controllers\BaseController.cs:line 262
   at Mvc4BaseProject.Areas.Admin.Controllers.HomeController.ManageUsers(ManageUserSearchInfo searchInfo, GridInfo gridInfo) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Controllers\HomeController.cs:line 65
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass42.<BeginInvokeSynchronousActionMethod>b__41()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass8`1.<BeginSynchronous>b__7(IAsyncResult _)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<>c__DisplayClass39.<BeginInvokeActionMethodWithFilters>b__33()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass4f.<InvokeActionMethodFilterAsynchronously>b__49()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeActionMethodWithFilters>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[{"Name":"SortBy","Value":"LastLogin"},{"Name":"PageNo","Value":"3"},{"Name":"SortField","Value":"FirstName"}]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUsers"}]', CAST(N'2013-11-18 19:52:43.783' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (11, N'Object reference not set to an instance of an object.', N'   at Mvc4BaseProject.BLL.Classes.Grid.GenerateLink(HtmlHelper helper, PagingModal pager, Object routeValues) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Grid.cs:line 93
   at Mvc4BaseProject.BLL.Classes.Grid.ColumnHeader(HtmlHelper helper, PagingModal pager, String title, Object routeValues, Object htmlAttributes) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Grid.cs:line 107
   at Mvc4BaseProject.Helpers.Helpers.ColumnHeader(HtmlHelper helper, PagingModal pager, String title, Object routeValues, Object htmlAttributes) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Helpers\Helpers.cs:line 32
   at ASP._Page_Areas_Admin_Views_Home_Partials__ManageUsers_cshtml.Execute() in d:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Views\Home\Partials\_ManageUsers.cshtml:line 7
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at Mvc4BaseProject.Controllers.BaseController.RenderRazorViewToString(String view_name, Object model) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Controllers\BaseController.cs:line 262
   at Mvc4BaseProject.Areas.Admin.Controllers.HomeController.ManageUsers(ManageUserSearchInfo searchInfo, GridInfo gridInfo) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Controllers\HomeController.cs:line 65
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass42.<BeginInvokeSynchronousActionMethod>b__41()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass8`1.<BeginSynchronous>b__7(IAsyncResult _)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<>c__DisplayClass39.<BeginInvokeActionMethodWithFilters>b__33()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass4f.<InvokeActionMethodFilterAsynchronously>b__49()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeActionMethodWithFilters>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[{"Name":"SortBy","Value":"LastName"},{"Name":"PageNo","Value":"3"},{"Name":"SortField","Value":"FirstName"}]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUsers"}]', CAST(N'2013-11-18 19:52:55.400' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (12, N'Object reference not set to an instance of an object.', N'   at Mvc4BaseProject.BLL.Classes.Grid.GenerateLink(HtmlHelper helper, PagingModal pager, Object routeValues) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Grid.cs:line 93
   at Mvc4BaseProject.BLL.Classes.Grid.ColumnHeader(HtmlHelper helper, PagingModal pager, String title, Object routeValues, Object htmlAttributes) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Grid.cs:line 107
   at Mvc4BaseProject.Helpers.Helpers.ColumnHeader(HtmlHelper helper, PagingModal pager, String title, Object routeValues, Object htmlAttributes) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Helpers\Helpers.cs:line 32
   at ASP._Page_Areas_Admin_Views_Home_Partials__ManageUsers_cshtml.Execute() in d:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Views\Home\Partials\_ManageUsers.cshtml:line 7
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at Mvc4BaseProject.Controllers.BaseController.RenderRazorViewToString(String view_name, Object model) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Controllers\BaseController.cs:line 262
   at Mvc4BaseProject.Areas.Admin.Controllers.HomeController.ManageUsers(ManageUserSearchInfo searchInfo, GridInfo gridInfo) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Controllers\HomeController.cs:line 65
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass42.<BeginInvokeSynchronousActionMethod>b__41()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass8`1.<BeginSynchronous>b__7(IAsyncResult _)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<>c__DisplayClass39.<BeginInvokeActionMethodWithFilters>b__33()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass4f.<InvokeActionMethodFilterAsynchronously>b__49()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeActionMethodWithFilters>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[{"Name":"SortBy","Value":"LastName"},{"Name":"PageNo","Value":"3"},{"Name":"SortField","Value":"FirstName"}]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUsers"}]', CAST(N'2013-11-18 19:53:19.573' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (13, N'Exception has been thrown by the target of an invocation.', N'   at Mvc4BaseProject.BLL.Classes.Utilities.MergeObjects(Object sourceObj, Object targetObj, String[] ignoreProperties, Boolean updateNullValues) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Utilities.cs:line 63
   at Mvc4BaseProject.BLL.Classes.Utilities.MergeObjects(Object originalObj, Object modifiedObj) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Utilities.cs:line 24
   at Mvc4BaseProject.BLL.Repositories.UserRepository.<>c__DisplayClass4.<Get>b__3(User o) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Repositories\UserRepository.cs:line 45
   at System.Collections.Generic.List`1.ForEach(Action`1 action)
   at Mvc4BaseProject.BLL.Repositories.UserRepository.Get(ManageUserSearchInfo searchInfo, GridInfo gridInfo) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Repositories\UserRepository.cs:line 42
   at Mvc4BaseProject.Areas.Admin.Controllers.HomeController.ManageUsers(ManageUserSearchInfo searchInfo, GridInfo gridInfo) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Controllers\HomeController.cs:line 61
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass42.<BeginInvokeSynchronousActionMethod>b__41()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass8`1.<BeginSynchronous>b__7(IAsyncResult _)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<>c__DisplayClass39.<BeginInvokeActionMethodWithFilters>b__33()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass4f.<InvokeActionMethodFilterAsynchronously>b__49()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeActionMethodWithFilters>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'The property ''UserID'' is part of the object''s key information and cannot be modified. ', N'null', N'[]', N'[]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUsers"}]', CAST(N'2013-11-20 19:27:38.887' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (14, N'The model item passed into the dictionary is of type ''Mvc4BaseProject.BLL.ViewModel.PagingInfo`2[Mvc4BaseProject.BLL.ViewModel.UserModal,Mvc4BaseProject.BLL.ViewModel.ManageUserSearchInfo]'', but this dictionary requires a model item of type ''Mvc4BaseProject.BLL.ViewModel.PagingInfo`2[Mvc4BaseProject.DAL.DataModel.User,Mvc4BaseProject.BLL.ViewModel.ManageUserSearchInfo]''.', N'   at System.Web.Mvc.ViewDataDictionary`1.SetModel(Object value)
   at System.Web.Mvc.ViewDataDictionary..ctor(ViewDataDictionary dictionary)
   at System.Web.Mvc.WebViewPage`1.SetViewData(ViewDataDictionary viewData)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<InvokeActionResultWithFilters>b__17()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilter(IResultFilter filter, ResultExecutingContext preContext, Func`1 continuation)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<>c__DisplayClass1c.<InvokeActionResultWithFilters>b__19()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUsers"}]', CAST(N'2013-11-20 19:33:24.603' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (15, N'Object reference not set to an instance of an object.', N'   at Mvc4BaseProject.BLL.Classes.Utilities.EnumToList(Type en) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Utilities.cs:line 77
   at Mvc4BaseProject.BLL.ViewModel.UserModal..ctor() in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\ViewModel\Common.cs:line 120
   at Mvc4BaseProject.BLL.Repositories.UserRepository.<>c__DisplayClass4.<Get>b__3(User o) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Repositories\UserRepository.cs:line 44
   at System.Collections.Generic.List`1.ForEach(Action`1 action)
   at Mvc4BaseProject.BLL.Repositories.UserRepository.Get(ManageUserSearchInfo searchInfo, GridInfo gridInfo) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Repositories\UserRepository.cs:line 42
   at Mvc4BaseProject.Areas.Admin.Controllers.HomeController.ManageUsers(ManageUserSearchInfo searchInfo, GridInfo gridInfo) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Controllers\HomeController.cs:line 63
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass42.<BeginInvokeSynchronousActionMethod>b__41()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass8`1.<BeginSynchronous>b__7(IAsyncResult _)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<>c__DisplayClass39.<BeginInvokeActionMethodWithFilters>b__33()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass4f.<InvokeActionMethodFilterAsynchronously>b__49()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeActionMethodWithFilters>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUsers"}]', CAST(N'2013-11-21 20:19:27.920' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (16, N'Object reference not set to an instance of an object.', N'   at Mvc4BaseProject.BLL.Classes.Utilities.EnumToList(Type en) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Utilities.cs:line 77
   at Mvc4BaseProject.BLL.ViewModel.UserModal..ctor() in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\ViewModel\Common.cs:line 120
   at Mvc4BaseProject.BLL.Repositories.UserRepository.<>c__DisplayClass4.<Get>b__3(User o) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Repositories\UserRepository.cs:line 44
   at System.Collections.Generic.List`1.ForEach(Action`1 action)
   at Mvc4BaseProject.BLL.Repositories.UserRepository.Get(ManageUserSearchInfo searchInfo, GridInfo gridInfo) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Repositories\UserRepository.cs:line 42
   at Mvc4BaseProject.Areas.Admin.Controllers.HomeController.ManageUsers(ManageUserSearchInfo searchInfo, GridInfo gridInfo) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Controllers\HomeController.cs:line 63
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass42.<BeginInvokeSynchronousActionMethod>b__41()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass8`1.<BeginSynchronous>b__7(IAsyncResult _)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<>c__DisplayClass39.<BeginInvokeActionMethodWithFilters>b__33()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass4f.<InvokeActionMethodFilterAsynchronously>b__49()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeActionMethodWithFilters>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUsers"}]', CAST(N'2013-11-21 20:20:41.083' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (17, N'Object reference not set to an instance of an object.', N'   at Mvc4BaseProject.BLL.Classes.Utilities.MergeObjects(Object sourceObj, Object targetObj, String[] ignoreProperties, Boolean updateNullValues) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Utilities.cs:line 65
   at Mvc4BaseProject.BLL.Classes.Utilities.MergeObjects(Object sourceObj, Object targetObj) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Utilities.cs:line 26
   at Mvc4BaseProject.BLL.Repositories.UserRepository.Get(Nullable`1 userID) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Repositories\UserRepository.cs:line 61
   at Mvc4BaseProject.Areas.Admin.Controllers.HomeController.ManageUser(Nullable`1 userID) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Controllers\HomeController.cs:line 77
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass42.<BeginInvokeSynchronousActionMethod>b__41()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass8`1.<BeginSynchronous>b__7(IAsyncResult _)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<>c__DisplayClass39.<BeginInvokeActionMethodWithFilters>b__33()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass4f.<InvokeActionMethodFilterAsynchronously>b__49()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeActionMethodWithFilters>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUser"}]', CAST(N'2013-11-21 20:21:39.343' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (18, N'Object reference not set to an instance of an object.', N'   at Mvc4BaseProject.BLL.Classes.Utilities.MergeObjects(Object sourceObj, Object targetObj, String[] ignoreProperties, Boolean updateNullValues) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Utilities.cs:line 65
   at Mvc4BaseProject.BLL.Classes.Utilities.MergeObjects(Object sourceObj, Object targetObj) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Classes\Utilities.cs:line 26
   at Mvc4BaseProject.BLL.Repositories.UserRepository.Get(Nullable`1 userID) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Repositories\UserRepository.cs:line 61
   at Mvc4BaseProject.Areas.Admin.Controllers.HomeController.ManageUser(Nullable`1 userID) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Controllers\HomeController.cs:line 77
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass42.<BeginInvokeSynchronousActionMethod>b__41()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass8`1.<BeginSynchronous>b__7(IAsyncResult _)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<>c__DisplayClass39.<BeginInvokeActionMethodWithFilters>b__33()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass4f.<InvokeActionMethodFilterAsynchronously>b__49()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeActionMethodWithFilters>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUser"}]', CAST(N'2013-11-21 20:22:02.893' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (19, N'd:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Views\Home\ManageUser.cshtml(73): error CS1061: ''Mvc4BaseProject.BLL.ViewModel.UserModal'' does not contain a definition for ''PictureSavedName'' and no extension method ''PictureSavedName'' accepting a first argument of type ''Mvc4BaseProject.BLL.ViewModel.UserModal'' could be found (are you missing a using directive or an assembly reference?)', N'   at System.Web.Compilation.AssemblyBuilder.Compile()
   at System.Web.Compilation.BuildProvidersCompiler.PerformBuild()
   at System.Web.Compilation.BuildManager.CompileWebFile(VirtualPath virtualPath)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultInternal(VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultWithNoAssert(HttpContext context, VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVirtualPathObjectFactory(VirtualPath virtualPath, HttpContext context, Boolean allowCrossApp, Boolean throwIfNotFound)
   at System.Web.Compilation.BuildManager.GetObjectFactory(String virtualPath, Boolean throwIfNotFound)
   at System.Web.Mvc.BuildManagerWrapper.System.Web.Mvc.IBuildManager.FileExists(String virtualPath)
   at System.Web.Mvc.BuildManagerViewEngine.FileExists(ControllerContext controllerContext, String virtualPath)
   at System.Web.Mvc.VirtualPathProviderViewEngine.<>c__DisplayClass4.<GetPathFromGeneralName>b__0(String path)
   at System.Web.WebPages.DefaultDisplayMode.GetDisplayInfo(HttpContextBase httpContext, String virtualPath, Func`2 virtualPathExists)
   at System.Web.WebPages.DisplayModeProvider.<>c__DisplayClassb.<GetDisplayInfoForVirtualPath>b__8(IDisplayMode mode)
   at System.Linq.Enumerable.WhereSelectListIterator`2.MoveNext()
   at System.Linq.Enumerable.FirstOrDefault[TSource](IEnumerable`1 source, Func`2 predicate)
   at System.Web.WebPages.DisplayModeProvider.GetDisplayInfoForVirtualPath(String virtualPath, HttpContextBase httpContext, Func`2 virtualPathExists, IDisplayMode currentDisplayMode, Boolean requireConsistentDisplayMode)
   at System.Web.Mvc.VirtualPathProviderViewEngine.GetPathFromGeneralName(ControllerContext controllerContext, List`1 locations, String name, String controllerName, String areaName, String cacheKey, String[]& searchedLocations)
   at System.Web.Mvc.VirtualPathProviderViewEngine.GetPath(ControllerContext controllerContext, String[] locations, String[] areaLocations, String locationsPropertyName, String name, String controllerName, String cacheKeyPrefix, Boolean useCache, String[]& searchedLocations)
   at System.Web.Mvc.VirtualPathProviderViewEngine.FindView(ControllerContext controllerContext, String viewName, String masterName, Boolean useCache)
   at System.Web.Mvc.ViewEngineCollection.<>c__DisplayClassc.<FindView>b__b(IViewEngine e)
   at System.Web.Mvc.ViewEngineCollection.Find(Func`2 lookup, Boolean trackSearchedPaths)
   at System.Web.Mvc.ViewEngineCollection.FindView(ControllerContext controllerContext, String viewName, String masterName)
   at System.Web.Mvc.ViewResult.FindView(ControllerContext context)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<InvokeActionResultWithFilters>b__17()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilter(IResultFilter filter, ResultExecutingContext preContext, Func`1 continuation)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<>c__DisplayClass1c.<InvokeActionResultWithFilters>b__19()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUser"}]', CAST(N'2013-11-22 18:36:02.930' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (20, N'Unexpected "{" character after section keyword.  Section names must start with an "_" or alphabetic character, and the remaining characters must be either "_" or alphanumeric.
', N'   at System.Web.WebPages.Razor.RazorBuildProvider.EnsureGeneratedCode()
   at System.Web.WebPages.Razor.RazorBuildProvider.get_CodeCompilerType()
   at System.Web.Compilation.BuildProvider.GetCompilerTypeFromBuildProvider(BuildProvider buildProvider)
   at System.Web.Compilation.BuildProvidersCompiler.ProcessBuildProviders()
   at System.Web.Compilation.BuildProvidersCompiler.PerformBuild()
   at System.Web.Compilation.BuildManager.CompileWebFile(VirtualPath virtualPath)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultInternal(VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultWithNoAssert(HttpContext context, VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVirtualPathObjectFactory(VirtualPath virtualPath, HttpContext context, Boolean allowCrossApp, Boolean throwIfNotFound)
   at System.Web.Compilation.BuildManager.GetObjectFactory(String virtualPath, Boolean throwIfNotFound)
   at System.Web.Mvc.BuildManagerWrapper.System.Web.Mvc.IBuildManager.FileExists(String virtualPath)
   at System.Web.Mvc.BuildManagerViewEngine.FileExists(ControllerContext controllerContext, String virtualPath)
   at System.Web.Mvc.VirtualPathProviderViewEngine.<>c__DisplayClass4.<GetPathFromGeneralName>b__0(String path)
   at System.Web.WebPages.DefaultDisplayMode.GetDisplayInfo(HttpContextBase httpContext, String virtualPath, Func`2 virtualPathExists)
   at System.Web.WebPages.DisplayModeProvider.<>c__DisplayClassb.<GetDisplayInfoForVirtualPath>b__8(IDisplayMode mode)
   at System.Linq.Enumerable.WhereSelectListIterator`2.MoveNext()
   at System.Linq.Enumerable.FirstOrDefault[TSource](IEnumerable`1 source, Func`2 predicate)
   at System.Web.WebPages.DisplayModeProvider.GetDisplayInfoForVirtualPath(String virtualPath, HttpContextBase httpContext, Func`2 virtualPathExists, IDisplayMode currentDisplayMode, Boolean requireConsistentDisplayMode)
   at System.Web.Mvc.VirtualPathProviderViewEngine.GetPathFromGeneralName(ControllerContext controllerContext, List`1 locations, String name, String controllerName, String areaName, String cacheKey, String[]& searchedLocations)
   at System.Web.Mvc.VirtualPathProviderViewEngine.GetPath(ControllerContext controllerContext, String[] locations, String[] areaLocations, String locationsPropertyName, String name, String controllerName, String cacheKeyPrefix, Boolean useCache, String[]& searchedLocations)
   at System.Web.Mvc.VirtualPathProviderViewEngine.FindView(ControllerContext controllerContext, String viewName, String masterName, Boolean useCache)
   at System.Web.Mvc.ViewEngineCollection.<>c__DisplayClassc.<FindView>b__b(IViewEngine e)
   at System.Web.Mvc.ViewEngineCollection.Find(Func`2 lookup, Boolean trackSearchedPaths)
   at System.Web.Mvc.ViewEngineCollection.FindView(ControllerContext controllerContext, String viewName, String masterName)
   at System.Web.Mvc.ViewResult.FindView(ControllerContext context)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<InvokeActionResultWithFilters>b__17()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilter(IResultFilter filter, ResultExecutingContext preContext, Func`1 continuation)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<>c__DisplayClass1c.<InvokeActionResultWithFilters>b__19()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUser"}]', CAST(N'2013-11-25 18:59:03.633' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (21, N'The property Mvc4BaseProject.BLL.ViewModel.UserModal.NewPassword could not be found.', N'   at System.Web.Mvc.AssociatedMetadataProvider.GetMetadataForProperty(Func`1 modelAccessor, Type containerType, String propertyName)
   at System.Web.Mvc.CachedAssociatedMetadataProvider`1.GetMetadataForProperty(Func`1 modelAccessor, Type containerType, String propertyName)
   at System.Web.Mvc.CompareAttribute.<GetClientValidationRules>d__8.MoveNext()
   at System.Linq.Enumerable.<ConcatIterator>d__71`1.MoveNext()
   at System.Linq.Enumerable.<SelectManyIterator>d__14`2.MoveNext()
   at System.Web.Mvc.UnobtrusiveValidationAttributesGenerator.GetValidationAttributes(IEnumerable`1 clientRules, IDictionary`2 results)
   at System.Web.Mvc.HtmlHelper.GetUnobtrusiveValidationAttributes(String name, ModelMetadata metadata)
   at System.Web.Mvc.Html.InputExtensions.InputHelper(HtmlHelper htmlHelper, InputType inputType, ModelMetadata metadata, String name, Object value, Boolean useViewData, Boolean isChecked, Boolean setId, Boolean isExplicitValue, String format, IDictionary`2 htmlAttributes)
   at System.Web.Mvc.Html.InputExtensions.PasswordFor[TModel,TProperty](HtmlHelper`1 htmlHelper, Expression`1 expression, IDictionary`2 htmlAttributes)
   at System.Web.Mvc.Html.InputExtensions.PasswordFor[TModel,TProperty](HtmlHelper`1 htmlHelper, Expression`1 expression, Object htmlAttributes)
   at ASP._Page_Areas_Admin_Views_Home_ManageUser_cshtml.Execute() in d:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Views\Home\ManageUser.cshtml:line 124
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy()
   at System.Web.Mvc.WebViewPage.ExecutePageHierarchy()
   at System.Web.WebPages.WebPageBase.ExecutePageHierarchy(WebPageContext pageContext, TextWriter writer, WebPageRenderingBase startPage)
   at System.Web.Mvc.RazorView.RenderView(ViewContext viewContext, TextWriter writer, Object instance)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<InvokeActionResultWithFilters>b__17()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilter(IResultFilter filter, ResultExecutingContext preContext, Func`1 continuation)
   at System.Web.Mvc.ControllerActionInvoker.<>c__DisplayClass1a.<>c__DisplayClass1c.<InvokeActionResultWithFilters>b__19()
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"ManageUser"}]', CAST(N'2013-11-25 19:01:00.020' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (22, N'Object reference not set to an instance of an object.', N'   at Mvc4BaseProject.BLL.Repositories.RepositoryBase..ctor(ApplicationRepository appContext, Type type) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Repositories\BaseRepository.cs:line 48
   at Mvc4BaseProject.BLL.Repositories.RepositoryBase`1..ctor(ApplicationRepository appContext) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Repositories\BaseRepository.cs:line 77
   at Mvc4BaseProject.BLL.Repositories.UserRepository..ctor(ApplicationRepository applicationContext) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Repositories\UserRepository.cs:line 19
   at Mvc4BaseProject.BLL.Repositories.ApplicationRepository.get_Users() in D:\Projects\Mvc4BaseProject\Mvc4BaseProject.BLL\Repositories\ApplicationRepository.cs:line 39
   at Mvc4BaseProject.Areas.Admin.Controllers.HomeController.Login(AdminLoginModel obj) in D:\Projects\Mvc4BaseProject\Mvc4BaseProject\Areas\Admin\Controllers\HomeController.cs:line 30
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass42.<BeginInvokeSynchronousActionMethod>b__41()
   at System.Web.Mvc.Async.AsyncResultWrapper.<>c__DisplayClass8`1.<BeginSynchronous>b__7(IAsyncResult _)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<>c__DisplayClass39.<BeginInvokeActionMethodWithFilters>b__33()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass4f.<InvokeActionMethodFilterAsynchronously>b__49()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass37.<BeginInvokeActionMethodWithFilters>b__36(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<>c__DisplayClass2a.<BeginInvokeAction>b__20()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass25.<BeginInvokeAction>b__22(IAsyncResult asyncResult)', N'', N'null', N'[]', N'[{"Name":"Email","Value":"sudeep@xicom.biz"},{"Name":"Password","Value":"12345678"},{"Name":"RememberMe","Value":"false"}]', N'[{"Name":"controller","Value":"Home"},{"Name":"action","Value":"Login"}]', CAST(N'2013-11-26 19:37:12.757' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (24, N'Exception of type ''System.Exception'' was thrown.', N'   at BaseProject.Controllers.HomeController.Index() in d:\GL\BaseProject\BaseProject\Controllers\HomeController.cs:line 39
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.ActionInvocation.InvokeSynchronousActionMethod()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)', N'', N'', NULL, NULL, NULL, CAST(N'2015-04-17 05:53:36.990' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (25, N'Exception of type ''System.Exception'' was thrown.', N'   at BaseProject.Controllers.HomeController.Index() in d:\GL\BaseProject\BaseProject\Controllers\HomeController.cs:line 39
   at lambda_method(Closure , ControllerBase , Object[] )
   at System.Web.Mvc.ActionMethodDispatcher.Execute(ControllerBase controller, Object[] parameters)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.ActionInvocation.InvokeSynchronousActionMethod()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<BeginInvokeSynchronousActionMethod>b__39(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3d()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass46.<InvokeActionMethodFilterAsynchronouslyRecursive>b__3f()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass33.<BeginInvokeActionMethodWithFilters>b__32(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncResultWrapper.End[TResult](IAsyncResult asyncResult, Object tag)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)', N'', N'', NULL, NULL, NULL, CAST(N'2015-04-17 05:56:20.767' AS DateTime))
INSERT [dbo].[ErrorLog] ([ErrorLogID], [Message], [StackTrace], [InnerException], [LoggedInDetails], [QueryData], [FormData], [RouteData], [LoggedAt]) VALUES (26, N'c:\Windows\Microsoft.NET\Framework\v4.0.30319\Temporary ASP.NET Files\root\a9761a11\7577a8d3\App_Web_index.cshtml.7befced2.x8otybls.0.cs(29): error CS0234: The type or namespace name ''Models'' does not exist in the namespace ''BaseProject'' (are you missing an assembly reference?)', N'   at System.Web.Compilation.AssemblyBuilder.Compile()
   at System.Web.Compilation.BuildProvidersCompiler.PerformBuild()
   at System.Web.Compilation.BuildManager.CompileWebFile(VirtualPath virtualPath)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultInternal(VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVPathBuildResultWithNoAssert(HttpContext context, VirtualPath virtualPath, Boolean noBuild, Boolean allowCrossApp, Boolean allowBuildInPrecompile, Boolean throwIfNotFound, Boolean ensureIsUpToDate)
   at System.Web.Compilation.BuildManager.GetVirtualPathObjectFactory(VirtualPath virtualPath, HttpContext context, Boolean allowCrossApp, Boolean throwIfNotFound)
   at System.Web.Compilation.BuildManager.GetCompiledType(VirtualPath virtualPath)
   at System.Web.Compilation.BuildManager.GetCompiledType(String virtualPath)
   at System.Web.Mvc.BuildManagerWrapper.System.Web.Mvc.IBuildManager.GetCompiledType(String virtualPath)
   at System.Web.Mvc.BuildManagerCompiledView.Render(ViewContext viewContext, TextWriter writer)
   at System.Web.Mvc.ViewResultBase.ExecuteResult(ControllerContext context)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultFilterRecursive(IList`1 filters, Int32 filterIndex, ResultExecutingContext preContext, ControllerContext controllerContext, ActionResult actionResult)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionResultWithFilters(ControllerContext controllerContext, IList`1 filters, ActionResult actionResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<>c__DisplayClass2b.<BeginInvokeAction>b__1c()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass21.<BeginInvokeAction>b__1e(IAsyncResult asyncResult)', N'', N'', NULL, NULL, NULL, CAST(N'2015-04-17 05:57:51.187' AS DateTime))
SET IDENTITY_INSERT [dbo].[ErrorLog] OFF
SET IDENTITY_INSERT [dbo].[Modules] ON 

INSERT [dbo].[Modules] ([ModuleId], [ModuleName], [ControllerName], [Description], [IsAdmin], [IsSubUser]) VALUES (1, N'Customer Management', N'Customer', N'Listing/Add/Edit/Delete', 0, 1)
INSERT [dbo].[Modules] ([ModuleId], [ModuleName], [ControllerName], [Description], [IsAdmin], [IsSubUser]) VALUES (2, N'Email Template Management', N'EmailTemplate', N'Listing/Add/Edit/Delete', 0, 1)
INSERT [dbo].[Modules] ([ModuleId], [ModuleName], [ControllerName], [Description], [IsAdmin], [IsSubUser]) VALUES (3, N'CMS Management', N'CMS', N'Listing/Add/Edit/Delete', 0, 1)
SET IDENTITY_INSERT [dbo].[Modules] OFF
SET IDENTITY_INSERT [dbo].[Province] ON 

INSERT [dbo].[Province] ([Id], [Name], [IsDeleted], [CreatedDate], [lastModified]) VALUES (1, N'Pr 1', 0, CAST(N'2013-11-09 17:54:57.173' AS DateTime), CAST(N'2013-11-09 17:54:57.173' AS DateTime))
SET IDENTITY_INSERT [dbo].[Province] OFF
SET IDENTITY_INSERT [dbo].[UserAssignedModules] ON 

INSERT [dbo].[UserAssignedModules] ([UserAssignedModuleId], [AdminUserID], [ModuleId], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (1, 1, 1, CAST(N'2019-02-14 06:33:53.0000000' AS DateTime2), NULL, CAST(N'2019-02-14 06:33:53.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[UserAssignedModules] ([UserAssignedModuleId], [AdminUserID], [ModuleId], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (2, 1, 2, CAST(N'2019-02-20 07:08:33.0000000' AS DateTime2), NULL, CAST(N'2019-02-20 07:08:33.0000000' AS DateTime2), NULL, 0)
INSERT [dbo].[UserAssignedModules] ([UserAssignedModuleId], [AdminUserID], [ModuleId], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy], [IsDeleted]) VALUES (3, 1, 3, CAST(N'2019-02-20 07:08:44.0000000' AS DateTime2), NULL, CAST(N'2019-02-20 07:08:44.0000000' AS DateTime2), NULL, 0)
SET IDENTITY_INSERT [dbo].[UserAssignedModules] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (2, N'87F1034567', N'850E1C', N'b669eb@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:54:57.173' AS DateTime), CAST(N'2013-11-09 17:54:57.173' AS DateTime), CAST(N'2013-11-09 17:54:57.173' AS DateTime), 1, CAST(N'2015-06-08 16:34:14.163' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (4, N'E7CA54', N'3F484F', N'8E6DE6@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:54:58.023' AS DateTime), CAST(N'2013-11-09 17:54:58.023' AS DateTime), CAST(N'2013-11-09 17:54:58.023' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (5, N'A7720F', N'158729', N'92FAE5@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:54:58.213' AS DateTime), CAST(N'2013-11-09 17:54:58.213' AS DateTime), CAST(N'2013-11-09 17:54:58.213' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (7, N'7E4537', N'070934', N'6BEEB8@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:54:58.590' AS DateTime), CAST(N'2013-11-09 17:54:58.590' AS DateTime), CAST(N'2013-11-09 17:54:58.590' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (8, N'FADA76', N'648C34', N'C48063@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:54:58.767' AS DateTime), CAST(N'2013-11-09 17:54:58.767' AS DateTime), CAST(N'2013-11-09 17:54:58.767' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (9, N'55CC0D', N'C342ED', N'58ba8c@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:54:58.930' AS DateTime), CAST(N'2013-11-09 17:54:58.930' AS DateTime), CAST(N'2013-11-09 17:54:58.930' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (10, N'3D4FE1', N'C945C8', N'28E0E9@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:54:59.090' AS DateTime), CAST(N'2013-11-09 17:54:59.090' AS DateTime), CAST(N'2013-11-09 17:54:59.090' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (11, N'EDA99F', N'10560F', N'78B882@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:54:59.253' AS DateTime), CAST(N'2013-11-09 17:54:59.253' AS DateTime), CAST(N'2013-11-09 17:54:59.253' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (13, N'EA8574', N'C82F5C', N'72DCCA@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:54:59.587' AS DateTime), CAST(N'2013-11-09 17:54:59.587' AS DateTime), CAST(N'2013-11-09 17:54:59.587' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (14, N'7C17A8', N'E00A1D', N'66C899@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:54:59.757' AS DateTime), CAST(N'2013-11-09 17:54:59.757' AS DateTime), CAST(N'2013-11-09 17:54:59.757' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (15, N'F6414B', N'87D7F3', N'A4AE82@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:54:59.937' AS DateTime), CAST(N'2013-11-09 17:54:59.937' AS DateTime), CAST(N'2013-11-27 19:43:21.683' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (17, N'CDB481', N'151252', N'D47764@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:00.280' AS DateTime), CAST(N'2013-11-09 17:55:00.280' AS DateTime), CAST(N'2013-11-09 17:55:00.280' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (18, N'D47B3C', N'FDB549', N'9BAF1F@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:00.467' AS DateTime), CAST(N'2013-11-09 17:55:00.467' AS DateTime), CAST(N'2013-11-09 17:55:00.467' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (20, N'F732C7', N'74084F', N'9DF5EC@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:00.797' AS DateTime), CAST(N'2013-11-09 17:55:00.797' AS DateTime), CAST(N'2013-11-09 17:55:00.797' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (22, N'9008BC', N'AEA2AE', N'3DEB2D@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:01.150' AS DateTime), CAST(N'2013-11-09 17:55:01.150' AS DateTime), CAST(N'2013-11-09 17:55:01.150' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (23, N'AE840F', N'D925F3', N'60609E@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:01.350' AS DateTime), CAST(N'2013-11-09 17:55:01.350' AS DateTime), CAST(N'2013-11-09 17:55:01.350' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (24, N'915ECF', N'7E97BA', N'B24631@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:01.520' AS DateTime), CAST(N'2013-11-09 17:55:01.520' AS DateTime), CAST(N'2013-11-09 17:55:01.520' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (25, N'FFBA06', N'141E24', N'8BB82B@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:01.710' AS DateTime), CAST(N'2013-11-09 17:55:01.710' AS DateTime), CAST(N'2013-11-09 17:55:01.710' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (26, N'940FED', N'A14039', N'866DD2@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:01.893' AS DateTime), CAST(N'2013-11-09 17:55:01.893' AS DateTime), CAST(N'2013-11-09 17:55:01.893' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (27, N'3DA86E', N'3B3FFC', N'2893AA@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:02.080' AS DateTime), CAST(N'2013-11-09 17:55:02.080' AS DateTime), CAST(N'2013-11-09 17:55:02.080' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (28, N'FE71F1', N'34ED20', N'15C075@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:02.263' AS DateTime), CAST(N'2013-11-09 17:55:02.263' AS DateTime), CAST(N'2013-11-09 17:55:02.263' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (29, N'294368', N'2B4563', N'CA0D22@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:02.437' AS DateTime), CAST(N'2013-11-09 17:55:02.437' AS DateTime), CAST(N'2013-11-09 17:55:02.437' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (30, N'795616', N'6707D4', N'262F70@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:02.620' AS DateTime), CAST(N'2013-11-09 17:55:02.620' AS DateTime), CAST(N'2013-11-09 17:55:02.620' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (31, N'E5B638', N'87796A', N'57719C@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:02.947' AS DateTime), CAST(N'2013-11-09 17:55:02.947' AS DateTime), CAST(N'2013-11-09 17:55:02.947' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (32, N'E66DA2', N'370C10', N'F42250@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:03.530' AS DateTime), CAST(N'2013-11-09 17:55:03.530' AS DateTime), CAST(N'2013-11-09 17:55:03.530' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (33, N'A87A99', N'0F4DD1', N'6CFF48@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:03.713' AS DateTime), CAST(N'2013-11-09 17:55:03.713' AS DateTime), CAST(N'2013-11-09 17:55:03.713' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (34, N'F46B87', N'90D351', N'2DB45A@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:03.877' AS DateTime), CAST(N'2013-11-09 17:55:03.877' AS DateTime), CAST(N'2013-11-09 17:55:03.877' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (35, N'B0C025', N'A91DE8', N'8F37CF@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:04.050' AS DateTime), CAST(N'2013-11-09 17:55:04.050' AS DateTime), CAST(N'2013-11-09 17:55:04.050' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (36, N'F5EBD6', N'F6BB8D', N'14803A@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:04.250' AS DateTime), CAST(N'2013-11-09 17:55:04.250' AS DateTime), CAST(N'2013-11-09 17:55:04.250' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (37, N'4086CB', N'12EE1D', N'9C1B25@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:04.680' AS DateTime), CAST(N'2013-11-09 17:55:04.680' AS DateTime), CAST(N'2013-11-09 17:55:04.680' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (38, N'1FF329', N'3CFD14', N'F7B8BE@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:04.953' AS DateTime), CAST(N'2013-11-09 17:55:04.953' AS DateTime), CAST(N'2013-12-16 13:14:58.747' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (39, N'C8D99C', N'D7F119', N'202E32@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:05.047' AS DateTime), CAST(N'2013-11-09 17:55:05.047' AS DateTime), CAST(N'2013-11-09 17:55:05.047' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (40, N'5A82A8', N'58B366', N'F407F2@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:05.120' AS DateTime), CAST(N'2013-11-09 17:55:05.120' AS DateTime), CAST(N'2013-11-09 17:55:05.120' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (41, N'E990D1', N'92594A', N'724CBC@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:05.177' AS DateTime), CAST(N'2013-11-09 17:55:05.177' AS DateTime), CAST(N'2013-11-09 17:55:05.177' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (43, N'E2D57D', N'0C5D71', N'B0BE2A@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:05.303' AS DateTime), CAST(N'2013-11-09 17:55:05.303' AS DateTime), CAST(N'2013-11-09 17:55:05.303' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (44, N'8698D4', N'F841BF', N'279544@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:05.400' AS DateTime), CAST(N'2013-11-09 17:55:05.400' AS DateTime), CAST(N'2013-11-09 17:55:05.400' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (45, N'362C3C', N'155238', N'79CDB7@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:05.460' AS DateTime), CAST(N'2013-11-09 17:55:05.460' AS DateTime), CAST(N'2013-11-09 17:55:05.460' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (47, N'BB22E6', N'148004', N'00ACA6@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:05.590' AS DateTime), CAST(N'2013-11-09 17:55:05.590' AS DateTime), CAST(N'2013-11-09 17:55:05.590' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (48, N'693B3B', N'3FF1B5', N'3AE6BA@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:05.650' AS DateTime), CAST(N'2013-11-09 17:55:05.650' AS DateTime), CAST(N'2013-11-09 17:55:05.650' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (49, N'836824', N'AD53ED', N'B9F9A5@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:05.733' AS DateTime), CAST(N'2013-11-09 17:55:05.733' AS DateTime), CAST(N'2013-11-09 17:55:05.733' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (50, N'E77A8E', N'A3788E', N'774F95@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:05.790' AS DateTime), CAST(N'2013-11-09 17:55:05.790' AS DateTime), CAST(N'2013-11-09 17:55:05.790' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (51, N'932786', N'E7E8CB', N'AAFC73@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:05.900' AS DateTime), CAST(N'2013-11-09 17:55:05.900' AS DateTime), CAST(N'2013-11-09 17:55:05.900' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (52, N'E11BD1', N'7D8696', N'280DC4@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:06.057' AS DateTime), CAST(N'2013-11-09 17:55:06.057' AS DateTime), CAST(N'2013-11-09 17:55:06.057' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (53, N'B92A63', N'DD41AD', N'CEB559@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:06.123' AS DateTime), CAST(N'2013-11-09 17:55:06.123' AS DateTime), CAST(N'2013-11-09 17:55:06.123' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (55, N'426FBC', N'8E5F06', N'4BA6A8@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:06.267' AS DateTime), CAST(N'2013-11-09 17:55:06.270' AS DateTime), CAST(N'2013-11-09 17:55:06.270' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (56, N'B3BD22', N'A2D7CA', N'6DCBC3@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:06.367' AS DateTime), CAST(N'2013-11-09 17:55:06.367' AS DateTime), CAST(N'2013-11-09 17:55:06.367' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (57, N'B9D1CC', N'63961E', N'5412A5@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:06.450' AS DateTime), CAST(N'2013-11-09 17:55:06.450' AS DateTime), CAST(N'2013-11-09 17:55:06.450' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (58, N'4699A1', N'19A8DC', N'FAF15A@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:06.507' AS DateTime), CAST(N'2013-11-09 17:55:06.507' AS DateTime), CAST(N'2013-11-09 17:55:06.507' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (59, N'97D483', N'610D19', N'B0E4B9@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:06.567' AS DateTime), CAST(N'2013-11-09 17:55:06.567' AS DateTime), CAST(N'2013-11-09 17:55:06.567' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (61, N'CAF0B3', N'E08A03', N'AE4096@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:06.700' AS DateTime), CAST(N'2013-11-09 17:55:06.700' AS DateTime), CAST(N'2013-11-09 17:55:06.700' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (62, N'87316B', N'7F2F90', N'CAF948@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:06.760' AS DateTime), CAST(N'2013-11-09 17:55:06.760' AS DateTime), CAST(N'2013-11-09 17:55:06.760' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (63, N'7D5CE4', N'B7DC74', N'1770E4@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:06.947' AS DateTime), CAST(N'2013-11-09 17:55:06.947' AS DateTime), CAST(N'2013-11-09 17:55:06.947' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (64, N'7A6AB0', N'2CBDB4', N'C14D4C@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:07.040' AS DateTime), CAST(N'2013-11-09 17:55:07.040' AS DateTime), CAST(N'2013-11-09 17:55:07.040' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (65, N'738368', N'08C6E7', N'5E91E0@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:07.127' AS DateTime), CAST(N'2013-11-09 17:55:07.127' AS DateTime), CAST(N'2013-11-09 17:55:07.127' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (66, N'92827D', N'283DDC', N'DD1B92@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:07.183' AS DateTime), CAST(N'2013-11-09 17:55:07.183' AS DateTime), CAST(N'2013-11-09 17:55:07.183' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (68, N'FB461B', N'DCBF7E', N'7892DF@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:07.320' AS DateTime), CAST(N'2013-11-09 17:55:07.320' AS DateTime), CAST(N'2013-11-09 17:55:07.320' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (69, N'6A8388', N'5F23CA', N'606289@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:07.413' AS DateTime), CAST(N'2013-11-09 17:55:07.413' AS DateTime), CAST(N'2013-11-09 17:55:07.413' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (71, N'68CDF1', N'9D2AD5', N'DE2A56@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:07.533' AS DateTime), CAST(N'2013-11-09 17:55:07.533' AS DateTime), CAST(N'2013-11-09 17:55:07.533' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (73, N'670CFA', N'9AE936', N'C12346@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:07.650' AS DateTime), CAST(N'2013-11-09 17:55:07.650' AS DateTime), CAST(N'2013-11-09 17:55:07.650' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (74, N'C4FC7A', N'450E60', N'046D0C@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:07.707' AS DateTime), CAST(N'2013-11-09 17:55:07.707' AS DateTime), CAST(N'2013-11-09 17:55:07.707' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (75, N'EDD57C', N'067391', N'690707@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:07.760' AS DateTime), CAST(N'2013-11-09 17:55:07.760' AS DateTime), CAST(N'2013-11-09 17:55:07.760' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (76, N'635DED', N'0439E7', N'48F5C4@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:07.820' AS DateTime), CAST(N'2013-11-09 17:55:07.820' AS DateTime), CAST(N'2013-11-09 17:55:07.820' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (77, N'8A8A73', N'8B5CCA', N'0190ff@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:07.880' AS DateTime), CAST(N'2013-11-09 17:55:07.880' AS DateTime), CAST(N'2013-11-09 17:55:07.880' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (78, N'9D67FD', N'DC99C1', N'29A399@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:07.940' AS DateTime), CAST(N'2013-11-09 17:55:07.940' AS DateTime), CAST(N'2013-11-09 17:55:07.940' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (80, N'FB17C0', N'B0533B', N'1A2009@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:08.123' AS DateTime), CAST(N'2013-11-09 17:55:08.123' AS DateTime), CAST(N'2013-11-09 17:55:08.123' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (81, N'6A5EB8', N'C33259', N'EDD4DC@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:08.177' AS DateTime), CAST(N'2013-11-09 17:55:08.177' AS DateTime), CAST(N'2013-11-09 17:55:08.177' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (82, N'8EFC9B', N'53C81C', N'B43932@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:08.233' AS DateTime), CAST(N'2013-11-09 17:55:08.233' AS DateTime), CAST(N'2013-11-09 17:55:08.233' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (83, N'5CD789', N'0C4AB3', N'069151@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:08.287' AS DateTime), CAST(N'2013-11-09 17:55:08.287' AS DateTime), CAST(N'2013-11-09 17:55:08.287' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (84, N'52CD11', N'7C1E4E', N'E6C5F0@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:08.357' AS DateTime), CAST(N'2013-11-09 17:55:08.357' AS DateTime), CAST(N'2013-11-09 17:55:08.357' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (85, N'9EC131', N'55B809', N'F2871A@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:08.413' AS DateTime), CAST(N'2013-11-09 17:55:08.413' AS DateTime), CAST(N'2013-11-09 17:55:08.413' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (86, N'9D2CDB', N'E2B93A', N'3B1C96@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:08.470' AS DateTime), CAST(N'2013-11-09 17:55:08.470' AS DateTime), CAST(N'2013-11-09 17:55:08.470' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (87, N'38E183', N'6450AE', N'A345FE@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:08.553' AS DateTime), CAST(N'2013-11-09 17:55:08.553' AS DateTime), CAST(N'2013-11-09 17:55:08.553' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (88, N'B27FFF', N'3DC3B1', N'769D55@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:08.617' AS DateTime), CAST(N'2013-11-09 17:55:08.617' AS DateTime), CAST(N'2013-11-09 17:55:08.617' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (90, N'FA5141', N'7E85F5', N'9E2409@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:08.730' AS DateTime), CAST(N'2013-11-09 17:55:08.730' AS DateTime), CAST(N'2013-11-09 17:55:08.730' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (91, N'B391C0', N'55F1EA', N'304F48@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:08.790' AS DateTime), CAST(N'2013-11-09 17:55:08.790' AS DateTime), CAST(N'2013-11-09 17:55:08.790' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (92, N'ED9C74', N'82B1B7', N'A68DC2@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:08.843' AS DateTime), CAST(N'2013-11-09 17:55:08.843' AS DateTime), CAST(N'2013-11-09 17:55:08.843' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (95, N'CC20A9', N'FADC29', N'1A95F3@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:09.020' AS DateTime), CAST(N'2013-11-09 17:55:09.020' AS DateTime), CAST(N'2013-11-09 17:55:09.020' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (97, N'5BDB87', N'B3A29D', N'937717@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 2, CAST(N'2013-11-09 17:55:09.160' AS DateTime), CAST(N'2013-11-09 17:55:09.160' AS DateTime), CAST(N'2013-11-09 17:55:09.160' AS DateTime), 0, NULL)
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (98, N'first', N'name', N'name@xicom.biz', N'E10ADC3949BA59ABBE56E057F20F883E', 1, NULL, NULL, CAST(N'2013-11-25 20:29:48.123' AS DateTime), 1, CAST(N'2015-06-08 16:34:25.840' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (99, N'jhjhgfjhg', N'jhgfjhgf', N'jgfjhg@as.com', N'E10ADC3949BA59ABBE56E057F20F883E', 1, NULL, NULL, CAST(N'2013-12-18 14:04:12.763' AS DateTime), 1, CAST(N'2015-06-08 16:34:47.550' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (100, N'Test', N'User', N'test@xcbv.com', N'E10ADC3949BA59ABBE56E057F20F883E', 2, NULL, NULL, CAST(N'2015-06-08 13:26:23.700' AS DateTime), 1, CAST(N'2015-06-08 13:30:01.353' AS DateTime))
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Password], [UserType], [LastLogin], [LastLogout], [CreatedAt], [IsDeleted], [DeletedOn]) VALUES (101, N'Test', N'Test', N'tyest@fgh.com', N'E10ADC3949BA59ABBE56E057F20F883E', 2, NULL, NULL, CAST(N'2015-06-08 16:35:53.780' AS DateTime), 1, CAST(N'2015-06-08 16:36:07.503' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[UserTbl] ON 

INSERT [dbo].[UserTbl] ([Id], [FirstName], [LastName], [Email], [Phone], [OTP], [Password], [City], [Province], [Address], [Longitute], [Latitute], [RoleId], [Status], [CreatedOn]) VALUES (1, N'Mohit', N'Sharma', N'mohit@gmail.com', N'8285543503', N'2356', N'QZbmASg8Utw=', 1, 1, N'test', N'454', N'454545', 1, 1, CAST(N'2013-11-09 17:54:57.173' AS DateTime))
SET IDENTITY_INSERT [dbo].[UserTbl] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UK_Users_Email]    Script Date: 31-Mar-19 4:40:38 PM ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [UK_Users_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cart] ADD  DEFAULT ((0)) FOR [DiscountAmount]
GO
ALTER TABLE [dbo].[Category] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Coupons] ADD  DEFAULT ((0)) FOR [IsAvailableForAll]
GO
ALTER TABLE [dbo].[Dishes] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[MotherDailySchedule] ADD  DEFAULT ((0)) FOR [Availabilty]
GO
ALTER TABLE [dbo].[MotherDish] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[MotherDish] ADD  DEFAULT ((0)) FOR [IsMainDish]
GO
ALTER TABLE [dbo].[MotherDish] ADD  DEFAULT ((0)) FOR [IsSignatureDish]
GO
ALTER TABLE [dbo].[MotherDishDailySchedule] ADD  DEFAULT ((0)) FOR [Availabilty]
GO
ALTER TABLE [dbo].[MotherQuestions] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[MotherTbl] ADD  DEFAULT ((0)) FOR [Commision]
GO
ALTER TABLE [dbo].[MotherTbl] ADD  DEFAULT ((0)) FOR [WalletAmount]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT ((0)) FOR [DiscountAmount]
GO
ALTER TABLE [dbo].[UserEnquiry] ADD  DEFAULT ((0)) FOR [IsReplied]
GO
ALTER TABLE [dbo].[UserEnquiry] ADD  DEFAULT ((0)) FOR [IsResolved]
GO
ALTER TABLE [dbo].[UserLoginSessions] ADD  CONSTRAINT [DF_UserLoginSessions_SessionExpired]  DEFAULT ((0)) FOR [SessionExpired]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cart_dbo.Guests_GuestId] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Guest] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_dbo.Cart_dbo.Guests_GuestId]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Cart_dbo.UserTbl_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_dbo.Cart_dbo.UserTbl_UserId]
GO
ALTER TABLE [dbo].[City]  WITH CHECK ADD  CONSTRAINT [FK_dbo.City_dbo.Province_ProvinceId] FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Province] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[City] CHECK CONSTRAINT [FK_dbo.City_dbo.Province_ProvinceId]
GO
ALTER TABLE [dbo].[Dishes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Dishes_dbo.Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Dishes] CHECK CONSTRAINT [FK_dbo.Dishes_dbo.Category_CategoryId]
GO
ALTER TABLE [dbo].[Favourites]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Favourites_dbo._UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Favourites] CHECK CONSTRAINT [FK_dbo.Favourites_dbo._UserId]
GO
ALTER TABLE [dbo].[MortherOrders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherOrders_dbo.MotherTbl_MotherId] FOREIGN KEY([MotherId])
REFERENCES [dbo].[MotherTbl] ([Id])
GO
ALTER TABLE [dbo].[MortherOrders] CHECK CONSTRAINT [FK_dbo.MotherOrders_dbo.MotherTbl_MotherId]
GO
ALTER TABLE [dbo].[MortherOrders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherOrders_dbo.Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MortherOrders] CHECK CONSTRAINT [FK_dbo.MotherOrders_dbo.Orders_OrderId]
GO
ALTER TABLE [dbo].[MotherAnswers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherAnswers_dbo.Mother_MotherId] FOREIGN KEY([MotherId])
REFERENCES [dbo].[MotherTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherAnswers] CHECK CONSTRAINT [FK_dbo.MotherAnswers_dbo.Mother_MotherId]
GO
ALTER TABLE [dbo].[MotherAnswers]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherAnswers_dbo.MotherQuestions_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[MotherQuestions] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherAnswers] CHECK CONSTRAINT [FK_dbo.MotherAnswers_dbo.MotherQuestions_QuestionId]
GO
ALTER TABLE [dbo].[MotherBankDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherBankDetails_dbo.Mother_MotherId] FOREIGN KEY([MotherId])
REFERENCES [dbo].[MotherTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherBankDetails] CHECK CONSTRAINT [FK_dbo.MotherBankDetails_dbo.Mother_MotherId]
GO
ALTER TABLE [dbo].[MotherCart]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherCart_dbo.MotherTbl_MotherId] FOREIGN KEY([MotherId])
REFERENCES [dbo].[MotherTbl] ([Id])
GO
ALTER TABLE [dbo].[MotherCart] CHECK CONSTRAINT [FK_dbo.MotherCart_dbo.MotherTbl_MotherId]
GO
ALTER TABLE [dbo].[MotherCart]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherCart_dbo.Orders_OrderId] FOREIGN KEY([CartId])
REFERENCES [dbo].[Cart] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherCart] CHECK CONSTRAINT [FK_dbo.MotherCart_dbo.Orders_OrderId]
GO
ALTER TABLE [dbo].[MotherCartDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherCartDetails_dbo.MotherCart_MothercartId] FOREIGN KEY([MotherCartId])
REFERENCES [dbo].[MotherCart] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherCartDetails] CHECK CONSTRAINT [FK_dbo.MotherCartDetails_dbo.MotherCart_MothercartId]
GO
ALTER TABLE [dbo].[MotherCartDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherCartDetails_dbo.MotherDish_MotherDishId] FOREIGN KEY([MotherDishId])
REFERENCES [dbo].[MotherDish] ([Id])
GO
ALTER TABLE [dbo].[MotherCartDetails] CHECK CONSTRAINT [FK_dbo.MotherCartDetails_dbo.MotherDish_MotherDishId]
GO
ALTER TABLE [dbo].[MotherCoupons]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherCoupons_dbo.Coupons_CouponId] FOREIGN KEY([CouponId])
REFERENCES [dbo].[Coupons] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherCoupons] CHECK CONSTRAINT [FK_dbo.MotherCoupons_dbo.Coupons_CouponId]
GO
ALTER TABLE [dbo].[MotherCoupons]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherCoupons_dbo.MotherTbl_MotherId] FOREIGN KEY([MotherId])
REFERENCES [dbo].[MotherTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherCoupons] CHECK CONSTRAINT [FK_dbo.MotherCoupons_dbo.MotherTbl_MotherId]
GO
ALTER TABLE [dbo].[MotherDailySchedule]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Favourites_dbo._MotherId] FOREIGN KEY([MotherId])
REFERENCES [dbo].[MotherTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherDailySchedule] CHECK CONSTRAINT [FK_dbo.Favourites_dbo._MotherId]
GO
ALTER TABLE [dbo].[MotherDish]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherDishes_dbo.DishesTbl_DishId] FOREIGN KEY([DishId])
REFERENCES [dbo].[Dishes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherDish] CHECK CONSTRAINT [FK_dbo.MotherDishes_dbo.DishesTbl_DishId]
GO
ALTER TABLE [dbo].[MotherDish]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherDishes_dbo.MotherTbl_MotherId] FOREIGN KEY([MotherId])
REFERENCES [dbo].[MotherTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherDish] CHECK CONSTRAINT [FK_dbo.MotherDishes_dbo.MotherTbl_MotherId]
GO
ALTER TABLE [dbo].[MotherDishDailySchedule]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherDish_dbo._MotherDishId] FOREIGN KEY([MotherDishId])
REFERENCES [dbo].[MotherDish] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherDishDailySchedule] CHECK CONSTRAINT [FK_dbo.MotherDish_dbo._MotherDishId]
GO
ALTER TABLE [dbo].[MotherDishReviews]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherDishReviews_dbo.MotherDish_MotherDishId] FOREIGN KEY([MotherDishId])
REFERENCES [dbo].[MotherDish] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherDishReviews] CHECK CONSTRAINT [FK_dbo.MotherDishReviews_dbo.MotherDish_MotherDishId]
GO
ALTER TABLE [dbo].[MotherDishReviews]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherDishReviews_dbo.UserTbl_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserTbl] ([Id])
GO
ALTER TABLE [dbo].[MotherDishReviews] CHECK CONSTRAINT [FK_dbo.MotherDishReviews_dbo.UserTbl_UserId]
GO
ALTER TABLE [dbo].[MotherGallery]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherGallery_dbo.MotherTbl_MotherId] FOREIGN KEY([MotherId])
REFERENCES [dbo].[MotherTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherGallery] CHECK CONSTRAINT [FK_dbo.MotherGallery_dbo.MotherTbl_MotherId]
GO
ALTER TABLE [dbo].[MotherOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherOrderDetails_dbo.MotherDish_MotherDishId] FOREIGN KEY([MotherDishId])
REFERENCES [dbo].[MotherDish] ([Id])
GO
ALTER TABLE [dbo].[MotherOrderDetails] CHECK CONSTRAINT [FK_dbo.MotherOrderDetails_dbo.MotherDish_MotherDishId]
GO
ALTER TABLE [dbo].[MotherOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherOrderDetails_dbo.Orders_MotherOrderId] FOREIGN KEY([MotherOrderId])
REFERENCES [dbo].[MortherOrders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherOrderDetails] CHECK CONSTRAINT [FK_dbo.MotherOrderDetails_dbo.Orders_MotherOrderId]
GO
ALTER TABLE [dbo].[MotherStatement]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherStatement_dbo.MotherTbl_MotherId] FOREIGN KEY([MotherId])
REFERENCES [dbo].[MotherTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherStatement] CHECK CONSTRAINT [FK_dbo.MotherStatement_dbo.MotherTbl_MotherId]
GO
ALTER TABLE [dbo].[MotherTbl]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MotherTbl_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MotherTbl] CHECK CONSTRAINT [FK_dbo.MotherTbl_dbo.User_UserId]
GO
ALTER TABLE [dbo].[Notificationss]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Notifications_dbo.UserTbl_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notificationss] CHECK CONSTRAINT [FK_dbo.Notifications_dbo.UserTbl_UserId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.Guests_GuestId] FOREIGN KEY([GuestId])
REFERENCES [dbo].[Guest] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.Guests_GuestId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Orders_dbo.UserTbl_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_dbo.Orders_dbo.UserTbl_UserId]
GO
ALTER TABLE [dbo].[PaymentDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PaymentDetails_dbo.Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PaymentDetails] CHECK CONSTRAINT [FK_dbo.PaymentDetails_dbo.Orders_OrderId]
GO
ALTER TABLE [dbo].[QueuedPushNotifications]  WITH CHECK ADD  CONSTRAINT [FK_QueuedPushNotifications_ID] FOREIGN KEY([FKReceiverUserId])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[QueuedPushNotifications] CHECK CONSTRAINT [FK_QueuedPushNotifications_ID]
GO
ALTER TABLE [dbo].[UserAchievements]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserAchievements_dbo._AchievementId] FOREIGN KEY([AchievementId])
REFERENCES [dbo].[Achievements] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAchievements] CHECK CONSTRAINT [FK_dbo.UserAchievements_dbo._AchievementId]
GO
ALTER TABLE [dbo].[UserAchievements]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserAchievements_dbo._UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAchievements] CHECK CONSTRAINT [FK_dbo.UserAchievements_dbo._UserId]
GO
ALTER TABLE [dbo].[UserAddressTbl]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserAddress_dbo.User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAddressTbl] CHECK CONSTRAINT [FK_dbo.UserAddress_dbo.User_UserId]
GO
ALTER TABLE [dbo].[UserAssignedModules]  WITH CHECK ADD  CONSTRAINT [FK__UserAssig__Admin__4CA06362] FOREIGN KEY([AdminUserID])
REFERENCES [dbo].[AdminUsers] ([AdminUserId])
GO
ALTER TABLE [dbo].[UserAssignedModules] CHECK CONSTRAINT [FK__UserAssig__Admin__4CA06362]
GO
ALTER TABLE [dbo].[UserEnquiry]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserEnquiry_dbo.UserTbl_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserEnquiry] CHECK CONSTRAINT [FK_dbo.UserEnquiry_dbo.UserTbl_UserId]
GO
ALTER TABLE [dbo].[UserLoginSessions]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserLogginSessions_dbo.UserTbl_MotherId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserTbl] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLoginSessions] CHECK CONSTRAINT [FK_dbo.UserLogginSessions_dbo.UserTbl_MotherId]
GO
ALTER TABLE [dbo].[UserLoginSessions]  WITH CHECK ADD  CONSTRAINT [FK_UserLoginSessions_UserId_UserLoginSessions_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UserLoginSessions] CHECK CONSTRAINT [FK_UserLoginSessions_UserId_UserLoginSessions_UserId]
GO
USE [master]
GO
ALTER DATABASE [ApniMaaDB] SET  READ_WRITE 
GO
