USE [master]
GO
/****** Object:  Database [online_stationary]    Script Date: 31/01/2022 23:36:46 ******/
CREATE DATABASE [online_stationary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'online_stationary', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.ZAIN\MSSQL\DATA\online_stationary.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'online_stationary_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.ZAIN\MSSQL\DATA\online_stationary_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [online_stationary] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [online_stationary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [online_stationary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [online_stationary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [online_stationary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [online_stationary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [online_stationary] SET ARITHABORT OFF 
GO
ALTER DATABASE [online_stationary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [online_stationary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [online_stationary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [online_stationary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [online_stationary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [online_stationary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [online_stationary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [online_stationary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [online_stationary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [online_stationary] SET  ENABLE_BROKER 
GO
ALTER DATABASE [online_stationary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [online_stationary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [online_stationary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [online_stationary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [online_stationary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [online_stationary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [online_stationary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [online_stationary] SET RECOVERY FULL 
GO
ALTER DATABASE [online_stationary] SET  MULTI_USER 
GO
ALTER DATABASE [online_stationary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [online_stationary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [online_stationary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [online_stationary] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [online_stationary] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'online_stationary', N'ON'
GO
ALTER DATABASE [online_stationary] SET QUERY_STORE = OFF
GO
USE [online_stationary]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [online_stationary]
GO
/****** Object:  Table [dbo].[admin_table]    Script Date: 31/01/2022 23:36:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin_table](
	[adid] [int] IDENTITY(1,1) NOT NULL,
	[admin_Email] [varchar](100) NULL,
	[Pass] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[adid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Emp]    Script Date: 31/01/2022 23:36:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Emp](
	[empid] [int] IDENTITY(1,1) NOT NULL,
	[emp_name] [varchar](100) NULL,
	[emp_role] [varchar](100) NULL,
	[emp_contact] [bigint] NULL,
	[Email_Adress] [varchar](100) NULL,
	[Username] [varchar](100) NULL,
	[Pass] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[empid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order_table]    Script Date: 31/01/2022 23:36:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_table](
	[oid] [int] IDENTITY(1,1) NOT NULL,
	[Empid] [int] NULL,
	[Stationary_id] [int] NULL,
	[Statid] [int] NULL,
	[Date_Of_Order] [date] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[oid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stat]    Script Date: 31/01/2022 23:36:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stat](
	[stid] [int] IDENTITY(1,1) NOT NULL,
	[Status_name] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[stid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stationary]    Script Date: 31/01/2022 23:36:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stationary](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[Stationary_Name] [varchar](100) NULL,
	[Quantity] [int] NULL,
	[Price] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[admin_table] ON 

INSERT [dbo].[admin_table] ([adid], [admin_Email], [Pass]) VALUES (1, N'Admin@gmail.com', N'123')
SET IDENTITY_INSERT [dbo].[admin_table] OFF
SET IDENTITY_INSERT [dbo].[Emp] ON 

INSERT [dbo].[Emp] ([empid], [emp_name], [emp_role], [emp_contact], [Email_Adress], [Username], [Pass]) VALUES (1, N'Zain', N'Manager Director', 4444454444, N'zain@gmail.com', N'ZAIN', N'AKoE+FDABWV0drFvsU7OzOySx8gQLBWcXr8zgYU6DreYVBiOPxtGnEflkqdj9ye9gQ==')
INSERT [dbo].[Emp] ([empid], [emp_name], [emp_role], [emp_contact], [Email_Adress], [Username], [Pass]) VALUES (2, N'Ali', N'Manager', 341331411, N'ali@gmail.com', N'ali', N'AKCiMOHWyydNjzKKauA8T6PFyRQ7621XejUrDcKlv6jhNI6Xn7gJT1h6hd2uH2U/XQ==')
INSERT [dbo].[Emp] ([empid], [emp_name], [emp_role], [emp_contact], [Email_Adress], [Username], [Pass]) VALUES (3, N'saad', N'Business Director', 9876543211, N'saad@gmail.com', N'saad', N'AGUG6qQL7P+ID3hf+VI9y1ep/NWXFx0aBG+ktgy2Xa/+b6DfQzqXe2GBbYcpTBqy6Q==')
INSERT [dbo].[Emp] ([empid], [emp_name], [emp_role], [emp_contact], [Email_Adress], [Username], [Pass]) VALUES (4, N'saad', N'Business Director', 9876543211, N'saad@gmail.com', N'saad', N'APC23y4CwB6HOqq4SPC/V1MAK4Se9FRrzuwovitYsMWtImji59Qj5NSQfgGf0m6wkg==')
INSERT [dbo].[Emp] ([empid], [emp_name], [emp_role], [emp_contact], [Email_Adress], [Username], [Pass]) VALUES (5, N'Rayyan', N'Engineer', 9876543212, N'rayyan@gmail.com', N'rayyan', N'AIFf7p1kesSX6ok7xAfkJNHr2WjdUYnncomxZ5gZmB0ky0bhDPB+4ZzHrg9TAULZCw==')
INSERT [dbo].[Emp] ([empid], [emp_name], [emp_role], [emp_contact], [Email_Adress], [Username], [Pass]) VALUES (6, N'Faiz', N'Business Director', 3326812922, N'faiz@gmail.com', N'Faiz', N'AM+wbWBWJhleJYcbJzAooP1IAJUkOGgukl5iSiROoubxxuRTCksq966pOZ2llBONnw==')
INSERT [dbo].[Emp] ([empid], [emp_name], [emp_role], [emp_contact], [Email_Adress], [Username], [Pass]) VALUES (1002, N'Daud', N'Engineer', 342347727424, N'Daud@gmail.com', N'Daud >ngineer', N'AHRToLIHIfVDj+r3bf+pNiHBRJgB6sivUZTIiKniYTsPFniN899bEAZ/QSbq0QgyeQ==')
SET IDENTITY_INSERT [dbo].[Emp] OFF
SET IDENTITY_INSERT [dbo].[Order_table] ON 

INSERT [dbo].[Order_table] ([oid], [Empid], [Stationary_id], [Statid], [Date_Of_Order], [Quantity]) VALUES (1, 2, 1, 1, CAST(N'2022-01-31' AS Date), 2)
INSERT [dbo].[Order_table] ([oid], [Empid], [Stationary_id], [Statid], [Date_Of_Order], [Quantity]) VALUES (4, 5, 5, 2, CAST(N'2022-01-31' AS Date), 7)
INSERT [dbo].[Order_table] ([oid], [Empid], [Stationary_id], [Statid], [Date_Of_Order], [Quantity]) VALUES (6, 6, 1, 1, CAST(N'2022-01-31' AS Date), 2)
INSERT [dbo].[Order_table] ([oid], [Empid], [Stationary_id], [Statid], [Date_Of_Order], [Quantity]) VALUES (7, 6, 1, 1, CAST(N'2022-01-31' AS Date), 3)
INSERT [dbo].[Order_table] ([oid], [Empid], [Stationary_id], [Statid], [Date_Of_Order], [Quantity]) VALUES (2002, 1002, 1, 1, CAST(N'2022-01-31' AS Date), 6)
SET IDENTITY_INSERT [dbo].[Order_table] OFF
SET IDENTITY_INSERT [dbo].[Stat] ON 

INSERT [dbo].[Stat] ([stid], [Status_name]) VALUES (1, N'Pending')
INSERT [dbo].[Stat] ([stid], [Status_name]) VALUES (2, N'Reject')
INSERT [dbo].[Stat] ([stid], [Status_name]) VALUES (3, N'Approved')
SET IDENTITY_INSERT [dbo].[Stat] OFF
SET IDENTITY_INSERT [dbo].[Stationary] ON 

INSERT [dbo].[Stationary] ([s_id], [Stationary_Name], [Quantity], [Price]) VALUES (1, N'Pen', 700, 10)
INSERT [dbo].[Stationary] ([s_id], [Stationary_Name], [Quantity], [Price]) VALUES (2, N'Eraser', 702, 10)
INSERT [dbo].[Stationary] ([s_id], [Stationary_Name], [Quantity], [Price]) VALUES (3, N'Pencil', 702, 10)
INSERT [dbo].[Stationary] ([s_id], [Stationary_Name], [Quantity], [Price]) VALUES (4, N'Scale', 702, 10)
INSERT [dbo].[Stationary] ([s_id], [Stationary_Name], [Quantity], [Price]) VALUES (5, N'Sharpner', 702, 10)
INSERT [dbo].[Stationary] ([s_id], [Stationary_Name], [Quantity], [Price]) VALUES (6, N'Pointer', 300, 20)
INSERT [dbo].[Stationary] ([s_id], [Stationary_Name], [Quantity], [Price]) VALUES (7, N'Remover', 343, 12)
INSERT [dbo].[Stationary] ([s_id], [Stationary_Name], [Quantity], [Price]) VALUES (1002, N'Rubber Abc', 600, 29)
SET IDENTITY_INSERT [dbo].[Stationary] OFF
ALTER TABLE [dbo].[Order_table]  WITH CHECK ADD FOREIGN KEY([Empid])
REFERENCES [dbo].[Emp] ([empid])
GO
ALTER TABLE [dbo].[Order_table]  WITH CHECK ADD FOREIGN KEY([Stationary_id])
REFERENCES [dbo].[Stationary] ([s_id])
GO
ALTER TABLE [dbo].[Order_table]  WITH CHECK ADD FOREIGN KEY([Statid])
REFERENCES [dbo].[Stat] ([stid])
GO
USE [master]
GO
ALTER DATABASE [online_stationary] SET  READ_WRITE 
GO
