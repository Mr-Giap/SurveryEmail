USE [master]
GO
/****** Object:  Database [StatusSurvey]    Script Date: 18/06/2018 4:44:03 CH ******/
CREATE DATABASE [StatusSurvey]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StatusSurvey', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StatusSurvey.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StatusSurvey_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\StatusSurvey_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StatusSurvey] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StatusSurvey].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StatusSurvey] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StatusSurvey] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StatusSurvey] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StatusSurvey] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StatusSurvey] SET ARITHABORT OFF 
GO
ALTER DATABASE [StatusSurvey] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StatusSurvey] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StatusSurvey] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StatusSurvey] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StatusSurvey] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StatusSurvey] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StatusSurvey] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StatusSurvey] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StatusSurvey] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StatusSurvey] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StatusSurvey] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StatusSurvey] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StatusSurvey] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StatusSurvey] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StatusSurvey] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StatusSurvey] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StatusSurvey] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StatusSurvey] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StatusSurvey] SET  MULTI_USER 
GO
ALTER DATABASE [StatusSurvey] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StatusSurvey] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StatusSurvey] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StatusSurvey] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [StatusSurvey] SET DELAYED_DURABILITY = DISABLED 
GO
USE [StatusSurvey]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[IdGroup] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Group_IdGroup]  DEFAULT (newid()),
	[Name] [nvarchar](50) NOT NULL,
	[Contents] [nvarchar](500) NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[IdGroup] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[History]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[History](
	[IdHis] [uniqueidentifier] NOT NULL CONSTRAINT [DF_History_IdHis]  DEFAULT (newid()),
	[CreationDate] [datetime] NOT NULL,
	[IdStatus] [int] NOT NULL,
	[IdGroup] [uniqueidentifier] NOT NULL,
	[Amount] [int] NULL CONSTRAINT [DF_History_Amount]  DEFAULT ((0)),
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[IdHis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[IdRole] [int] NOT NULL CONSTRAINT [DF_Role_IdRole]  DEFAULT ((0)),
	[Name] [nvarchar](50) NOT NULL CONSTRAINT [DF_Role_Name]  DEFAULT ((0)),
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[IdRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Status]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[IdStatus] [int] NOT NULL CONSTRAINT [DF_Status_IdStatus]  DEFAULT ((0)),
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[IdStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[IdUser] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Users_IdUser]  DEFAULT (newid()),
	[UserName] [varchar](250) NOT NULL,
	[Password] [varchar](250) NOT NULL,
	[FullName] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Email] [varchar](250) NOT NULL,
	[Phone] [varchar](50) NULL,
	[IdRole] [int] NOT NULL,
	[IdGroup] [uniqueidentifier] NOT NULL,
	[CheckEmail] [bit] NULL CONSTRAINT [DF_Users_CheckEmail]  DEFAULT ((0)),
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Group] ([IdGroup], [Name], [Contents]) VALUES (N'55c85184-0c5b-4362-b4e4-22bde0814dfb', N'Java', N'Làm việc Java')
INSERT [dbo].[Group] ([IdGroup], [Name], [Contents]) VALUES (N'5ea58917-89f1-4ccf-8981-708673cd0db5', N'DotNet', N'Làm việc .net')
INSERT [dbo].[Group] ([IdGroup], [Name], [Contents]) VALUES (N'9dd3dd20-0583-410a-8d18-b47322a04dd9', N'Frontend', N'Làm việc Client')
INSERT [dbo].[Group] ([IdGroup], [Name], [Contents]) VALUES (N'19ff8c1d-6287-47c0-934e-f9431778bcf4', N'Tester', N'Làm việc Tester')
INSERT [dbo].[History] ([IdHis], [CreationDate], [IdStatus], [IdGroup], [Amount]) VALUES (N'aa4df5e3-3da4-4260-9eec-1cb01d240067', CAST(N'2018-06-14 00:00:00.000' AS DateTime), 2, N'9dd3dd20-0583-410a-8d18-b47322a04dd9', 1)
INSERT [dbo].[History] ([IdHis], [CreationDate], [IdStatus], [IdGroup], [Amount]) VALUES (N'687e2841-7579-4c0c-9472-2a66f6727bc8', CAST(N'2018-06-10 00:00:00.000' AS DateTime), 3, N'5ea58917-89f1-4ccf-8981-708673cd0db5', 1)
INSERT [dbo].[History] ([IdHis], [CreationDate], [IdStatus], [IdGroup], [Amount]) VALUES (N'1cdbfc47-0d99-409a-9423-2f42461221bb', CAST(N'2018-06-18 00:00:00.000' AS DateTime), 3, N'9dd3dd20-0583-410a-8d18-b47322a04dd9', 1)
INSERT [dbo].[History] ([IdHis], [CreationDate], [IdStatus], [IdGroup], [Amount]) VALUES (N'ebff185f-ea1a-41a7-9bdb-6edc7d1b71f4', CAST(N'2018-06-14 00:00:00.000' AS DateTime), 1, N'9dd3dd20-0583-410a-8d18-b47322a04dd9', 1)
INSERT [dbo].[History] ([IdHis], [CreationDate], [IdStatus], [IdGroup], [Amount]) VALUES (N'aa206e7b-ebae-4fbd-b6df-9cc08cbd48e2', CAST(N'2018-06-13 00:00:00.000' AS DateTime), 1, N'9dd3dd20-0583-410a-8d18-b47322a04dd9', 6)
INSERT [dbo].[History] ([IdHis], [CreationDate], [IdStatus], [IdGroup], [Amount]) VALUES (N'a092563f-02af-45db-a4d8-d12d118bb72e', CAST(N'2018-06-13 00:00:00.000' AS DateTime), 3, N'9dd3dd20-0583-410a-8d18-b47322a04dd9', 3)
INSERT [dbo].[History] ([IdHis], [CreationDate], [IdStatus], [IdGroup], [Amount]) VALUES (N'e5e33c1a-6e5a-4fe6-bb6b-fa62ef47b4db', CAST(N'2018-06-13 00:00:00.000' AS DateTime), 2, N'9dd3dd20-0583-410a-8d18-b47322a04dd9', 1)
INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (0, N'SysAdmin')
INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([IdRole], [Name]) VALUES (2, N'Normal')
INSERT [dbo].[Status] ([IdStatus], [Name]) VALUES (1, N'Sad')
INSERT [dbo].[Status] ([IdStatus], [Name]) VALUES (2, N'Fun')
INSERT [dbo].[Status] ([IdStatus], [Name]) VALUES (3, N'Angry')
INSERT [dbo].[Users] ([IdUser], [UserName], [Password], [FullName], [Address], [Email], [Phone], [IdRole], [IdGroup], [CheckEmail]) VALUES (N'f3a8465d-b8c1-4963-85ba-21ff4e700ac9', N'hue', N'qwertyuiop', N'Đỗ Thị Huệ', N'Nam Từ Liêm', N'dohue97yp1@gmail.com', N'0123456789', 2, N'5ea58917-89f1-4ccf-8981-708673cd0db5', 0)
INSERT [dbo].[Users] ([IdUser], [UserName], [Password], [FullName], [Address], [Email], [Phone], [IdRole], [IdGroup], [CheckEmail]) VALUES (N'17b88cec-3727-4364-824a-661aaa164f7f', N'admin', N'asdfghjkl', N'Nguyễn Thái Giáp', N'Đống đa', N'nguyenthaigiap95@gmail.com', N'0987654321', 0, N'9dd3dd20-0583-410a-8d18-b47322a04dd9', 1)
INSERT [dbo].[Users] ([IdUser], [UserName], [Password], [FullName], [Address], [Email], [Phone], [IdRole], [IdGroup], [CheckEmail]) VALUES (N'58f24c60-993d-414f-ba65-fcc8fbcd8bcd', N'1', N'6eea9b7ef19179a06954edd0f6c05ceb', N'snfjsf', N'jkafhkjsfh', N'sfsf@gmail.com', N'183813818018', 2, N'9dd3dd20-0583-410a-8d18-b47322a04dd9', 0)
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_Group] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Group] ([IdGroup])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_Group]
GO
ALTER TABLE [dbo].[History]  WITH CHECK ADD  CONSTRAINT [FK_History_Status] FOREIGN KEY([IdStatus])
REFERENCES [dbo].[Status] ([IdStatus])
GO
ALTER TABLE [dbo].[History] CHECK CONSTRAINT [FK_History_Status]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Group] FOREIGN KEY([IdGroup])
REFERENCES [dbo].[Group] ([IdGroup])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Group]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role] FOREIGN KEY([IdRole])
REFERENCES [dbo].[Role] ([IdRole])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role]
GO
/****** Object:  StoredProcedure [dbo].[Group_Delete]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_Delete]
@id UNIQUEIDENTIFIER
AS
BEGIN
	DELETE FROM dbo.[Group]
	WHERE IdGroup = @id 
END

GO
/****** Object:  StoredProcedure [dbo].[Group_Insert]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_Insert]
@id UNIQUEIDENTIFIER,
@name NVARCHAR(50),
@content NVARCHAR(500)
AS
BEGIN
	INSERT dbo.[Group]
	        ( IdGroup, Name,Contents )
	VALUES  (@id,@name,@content)
END

GO
/****** Object:  StoredProcedure [dbo].[Group_Select_All]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_Select_All]
as
BEGIN
	SELECT * 
	FROM dbo.[Group]
END

GO
/****** Object:  StoredProcedure [dbo].[Group_Update]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Group_Update]
@id UNIQUEIDENTIFIER,
@name NVARCHAR(50),
@content NVARCHAR(500)
AS
BEGIN
	UPDATE dbo.[Group]
	SET Name = @name, Contents = @content
	WHERE IdGroup = @id 
END

GO
/****** Object:  StoredProcedure [dbo].[History_Checkdate]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[History_Checkdate]
@date datetime,
@Idg uniqueidentifier

AS
BEGIN
declare @date1 datetime= DATEADD(dd,1,@date);

 select h.Amount,h.IdStatus from History h
 where (h.CreationDate BETWEEN @date AND @date1)and(h.IdGroup=@Idg)
 
END
GO
/****** Object:  StoredProcedure [dbo].[History_Delete]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[History_Delete]
@idhis UNIQUEIDENTIFIER
AS
BEGIN
	DELETE FROM dbo.History
	WHERE IdHis = @idhis
END

GO
/****** Object:  StoredProcedure [dbo].[History_Insert]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[History_Insert]
@idhis UNIQUEIDENTIFIER,
@date DATETIME,
@idstatus INT,
@idgroup UNIQUEIDENTIFIER
AS
BEGIN
	INSERT INTO dbo.History
	        ( IdHis ,
	          CreationDate ,
	          IdStatus ,
	          IdGroup,
			  Amount
	        )
	VALUES  ( @idhis,@date,@idstatus,@idgroup,1
	        )
END
GO
/****** Object:  StoredProcedure [dbo].[History_Select_All]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[History_Select_All]
AS
BEGIN
	SELECT * FROM dbo.History
END

GO
/****** Object:  StoredProcedure [dbo].[History_Update]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[History_Update]
@idhis UNIQUEIDENTIFIER
AS
BEGIN
	UPDATE dbo.History
	SET Amount = Amount + 1
	WHERE IdHis = @idhis
END
GO
/****** Object:  StoredProcedure [dbo].[Role_Delete]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_Delete]
@id INT
AS
BEGIN
	DELETE FROM dbo.Role
	WHERE IdRole = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Role_Insert]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_Insert]
@id INT,
@name NVARCHAR(50)
AS
BEGIN
	INSERT INTO dbo.Role
	        ( IdRole, Name )
	VALUES  ( @id,@name
	          )
END

GO
/****** Object:  StoredProcedure [dbo].[Role_Select_All]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_Select_All]
AS
BEGIN
	SELECT * FROM dbo.Role
END

GO
/****** Object:  StoredProcedure [dbo].[Role_Update]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_Update]
@id INT,
@name NVARCHAR(50)
AS
BEGIN
	UPDATE dbo.Role
	SET @name = @name
	WHERE IdRole = @id
END

GO
/****** Object:  StoredProcedure [dbo].[Status_Delete]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Status_Delete]
@id INT
AS
BEGIN
	DELETE FROM dbo.Status
	WHERE IdStatus = @id
    
END

GO
/****** Object:  StoredProcedure [dbo].[Status_Getname]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Status_Getname]
@ids int
AS
BEGIN
	SELECT s.Name from Status s
	where s.IdStatus=@ids 
END

GO
/****** Object:  StoredProcedure [dbo].[Status_Insert]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Status_Insert]
@id INT,
@Name NVARCHAR(50)
AS
BEGIN
	INSERT INTO dbo.Status
	        ( IdStatus, Name )
	VALUES  ( @id,@Name
	          )
END

GO
/****** Object:  StoredProcedure [dbo].[Status_Rename]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Status_Rename]
@id INT,
@Name NVARCHAR(50)
AS
BEGIN
	UPDATE dbo.Status
	SET Name = @Name
	WHERE IdStatus = @id
    
END
GO
/****** Object:  StoredProcedure [dbo].[Status_Select_All]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Status_Select_All]
AS
BEGIN
	SELECT * FROM dbo.Status
END

GO
/****** Object:  StoredProcedure [dbo].[User_Checklogin]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Checklogin]
@username VARCHAR(250),
@password VARCHAR(250)
AS
BEGIN
	SELECT * 
	FROM dbo.Users
	WHERE UserName = @username AND Password = @password
END

GO
/****** Object:  StoredProcedure [dbo].[User_Delete]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Delete]
@Id UNIQUEIDENTIFIER
AS
BEGIN
	DELETE FROM dbo.Users
	WHERE IdUser = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[User_getall_by_Sendmail]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_getall_by_Sendmail]
@check int
AS
BEGIN
	SELECT * FROM dbo.Users
	WHERE CheckEmail = @check
END
GO
/****** Object:  StoredProcedure [dbo].[User_Insert]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Insert]
@Id UNIQUEIDENTIFIER,
@username VARCHAR(250),
@pass VARCHAR(250),
@fullname NVARCHAR(250),
@address NVARCHAR(250),
@email NVARCHAR(250),
@phone VARCHAR(50),
@idrole INT,
@idgroup UNIQUEIDENTIFIER
AS
BEGIN
	INSERT INTO dbo.Users
	        ( IdUser ,
	          UserName ,
	          Password ,
	          FullName ,
	          Address ,
	          Email ,
	          Phone ,
	          IdRole ,
	          IdGroup,
			  CheckEmail
	        )
	VALUES  ( @Id,@username,@pass,@fullname,@address,@email,@phone,@idrole,@idgroup,0
	        )
	
END
GO
/****** Object:  StoredProcedure [dbo].[User_Select_All]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Select_All]
AS
BEGIN
	SELECT *
	FROM dbo.Users
	
END

GO
/****** Object:  StoredProcedure [dbo].[User_Update_Informatiom_Normal]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Update_Informatiom_Normal]
@Id UNIQUEIDENTIFIER,
@fullname NVARCHAR(250),
@address NVARCHAR(250),
@email NVARCHAR(250),
@phone VARCHAR(50)
AS
BEGIN
	UPDATE dbo.Users
	SET FullName = @fullname, Address = @address, Email = @email,Phone = @phone
	WHERE IdUser = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[User_Update_Password_Normal]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Update_Password_Normal]
@Id UNIQUEIDENTIFIER,
@pass VARCHAR(250)
AS
BEGIN
	UPDATE dbo.Users
	SET Password = @pass
	WHERE IdUser = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[User_Update_Permission]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Update_Permission]	
@Id UNIQUEIDENTIFIER,
@idrole INT
AS
BEGIN
	UPDATE dbo.Users
	SET IdRole = @idrole
	WHERE IdUser = @Id
END

GO
/****** Object:  StoredProcedure [dbo].[User_Update_Sendmail]    Script Date: 18/06/2018 4:44:04 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[User_Update_Sendmail]
@id UNIQUEIDENTIFIER,
@check int

AS
BEGIN
	UPDATE dbo.Users
	SET CheckEmail = @check
	WHERE IdUser = @id
END
GO
USE [master]
GO
ALTER DATABASE [StatusSurvey] SET  READ_WRITE 
GO
