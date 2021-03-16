USE [master]
GO
/****** Object:  Database [Library]    Script Date: 3/16/2021 4:00:58 PM ******/
CREATE DATABASE [Library]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Library', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Library.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Library_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Library_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Library] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Library] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Library] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Library] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Library] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Library] SET ARITHABORT OFF 
GO
ALTER DATABASE [Library] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Library] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Library] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Library] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Library] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Library] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Library] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Library] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Library] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Library] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Library] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Library] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Library] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Library] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Library] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Library] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Library] SET  MULTI_USER 
GO
ALTER DATABASE [Library] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Library] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Library] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Library] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Library] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Library', N'ON'
GO
ALTER DATABASE [Library] SET QUERY_STORE = OFF
GO
USE [Library]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 3/16/2021 4:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[Bio] [nvarchar](500) NULL,
	[DateOfBirth] [datetime] NULL,
	[BirthLocation] [nvarchar](100) NULL,
 CONSTRAINT [PK__Author__70DAFC14BD13ADF0] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 3/16/2021 4:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[IsFiction] [bit] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK__Genre__0385055E592E8FE6] PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 3/16/2021 4:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](1000) NULL,
	[Price] [money] NOT NULL,
	[IsPaperBack] [bit] NOT NULL,
	[PublishDate] [datetime] NOT NULL,
	[AuthorID_FK] [int] NOT NULL,
	[GenreID_FK] [int] NOT NULL,
	[PublisherID_FK] [int] NOT NULL,
 CONSTRAINT [PK__Book__3DE0C227F0DB5AC5] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_Book_Genre_Author]    Script Date: 3/16/2021 4:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vw_Book_Genre_Author] AS
SELECT Title, Genre_Name, 
First_Name + ' ' + Last_Name AS AuthorName FROM Book b
INNER JOIN Genre g ON g.GenreID = b.GenreID_FK
INNER JOIN Author a ON a.AuthorID = b.Book_AuthorID_FK;
GO
/****** Object:  View [dbo].[vw_Users_Role]    Script Date: 3/16/2021 4:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[vw_Users_Role] AS
SELECT	UserId, 
		FirstName, 
		LastName, UserName, Password, RolesID, RoleName from Users u
INNER JOIN Roles r ON r.RolesID = u.RoleID_FK;
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 3/16/2021 4:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[PublisherID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[State] [nvarchar](100) NOT NULL,
	[Zip] [int] NOT NULL,
 CONSTRAINT [PK__Publisher__70DAFC14BD13ADF0] PRIMARY KEY CLUSTERED 
(
	[PublisherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/16/2021 4:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](255) NULL,
 CONSTRAINT [PKRolesC4B278203D96CD14] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/16/2021 4:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[FirstName] [varchar](255) NOT NULL,
	[UserName] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[RoleID_FK] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Bio], [DateOfBirth], [BirthLocation]) VALUES (1, N'Sam', N'Stall', N'Sam Stall is an author, freelance writer, and former editor of Indianapolis Monthly magazine. He has', NULL, NULL)
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Bio], [DateOfBirth], [BirthLocation]) VALUES (2, N'Kevin', N'Won', N'Wrote - Climbing Craftsmanship: Mastering Mental and Technical Skills', CAST(N'1984-06-24T00:00:00.000' AS DateTime), N'Saint Louis, Misssouri')
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Bio], [DateOfBirth], [BirthLocation]) VALUES (3, N'Roald', N'Dahl', N'Roald Dahl, was a spy, ace fighter-pilot, chocolate historian and medical inventor. He was also author of Charlie and Chocolate Factory.', CAST(N'1966-10-01T00:00:00.000' AS DateTime), N'Groveland, California')
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Bio], [DateOfBirth], [BirthLocation]) VALUES (4, N'Henry David', N'Thoreau', N'American author, naturalist, transcendentalist, pacifist, tax resister and philosopher.', CAST(N'1817-07-12T00:00:00.000' AS DateTime), N'Concord, MA')
INSERT [dbo].[Author] ([AuthorID], [FirstName], [LastName], [Bio], [DateOfBirth], [BirthLocation]) VALUES (5, N'Mark', N'Twain', N'Samuel Langhorne Clemens, known by his pen name Mark Twain, was an American writer, humorist, entrepreneur, publisher, and lecturer.', CAST(N'1835-11-30T00:00:00.000' AS DateTime), N'Florida, MO')
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([BookID], [Title], [Description], [Price], [IsPaperBack], [PublishDate], [AuthorID_FK], [GenreID_FK], [PublisherID_FK]) VALUES (1, N'Dancing with Jesus: Featuring a Host of Miraculous Moves', N'Are you cursed with two left feet? Are your dance moves unrighteous? Do you refrain from getting down lest others judge you cruelly? Fear not. Salvation is at hand.', 12.9500, 0, CAST(N'1986-12-01T00:00:00.000' AS DateTime), 1, 1, 4)
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Price], [IsPaperBack], [PublishDate], [AuthorID_FK], [GenreID_FK], [PublisherID_FK]) VALUES (2, N'Roughing It', N'Roughing It (1872) is Twain’s second book, a comedic romp through the Wild West with hilarious sketches of the author’s misadventures. The book recounts Twain’s flight from Hannibal to the silver mines of Nevada at the outset of the Civil War. ', 21.0000, 1, CAST(N'1865-04-15T00:00:00.000' AS DateTime), 5, 1, 2)
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Genre] ON 

INSERT [dbo].[Genre] ([GenreID], [Description], [IsFiction], [Name]) VALUES (1, N'A comic novel is usually a work of fiction in which the writer seeks to amuse the reader, sometimes with subtlety and as part of a carefully woven narrative, sometimes above all other considerations. It could indeed be said that comedy fiction is literary work that aims primarily to provoke laughter, but this is not always as obvious as it first may seem.', 1, N'Humor')
INSERT [dbo].[Genre] ([GenreID], [Description], [IsFiction], [Name]) VALUES (2, N'An account of someone''s life written by someone else.', 0, N'Biography')
INSERT [dbo].[Genre] ([GenreID], [Description], [IsFiction], [Name]) VALUES (4, N'How to improvement yourself', 0, N'Self Improvement')
INSERT [dbo].[Genre] ([GenreID], [Description], [IsFiction], [Name]) VALUES (5, N'Literature in the form of prose, especially short stories and novels, that describes imaginary events and people.', 1, N'Fiction')
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
SET IDENTITY_INSERT [dbo].[Publisher] ON 

INSERT [dbo].[Publisher] ([PublisherID], [Name], [Address], [City], [State], [Zip]) VALUES (1, N'Penguin Random House', N'89348 Market Ave.', N'New York', N'NY', 19123)
INSERT [dbo].[Publisher] ([PublisherID], [Name], [Address], [City], [State], [Zip]) VALUES (2, N'HarperCollins', N'43rd Roseland St.', N'Chicago', N'IL', 64452)
INSERT [dbo].[Publisher] ([PublisherID], [Name], [Address], [City], [State], [Zip]) VALUES (4, N'Macmillan Publishers', N'120 McCallin Ave.', N'New York', N'NY', 19045)
INSERT [dbo].[Publisher] ([PublisherID], [Name], [Address], [City], [State], [Zip]) VALUES (5, N'Simon & Schuster', N'9349 35th Ave.', N'Kansas City', N'MO', 10564)
SET IDENTITY_INSERT [dbo].[Publisher] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'Administrator')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Librarian')
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'Patron')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK]) VALUES (1, N'Rhodes', N'Giancarlo', N'grhodes29', N'password123', 1)
INSERT [dbo].[User] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK]) VALUES (2, N'Adams', N'Dillan', N'dillan.adams', N'password123', 3)
INSERT [dbo].[User] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK]) VALUES (3, N'Wells', N'Heather', N'heather.wells', N'password123', 3)
INSERT [dbo].[User] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK]) VALUES (4, N'Colton', N'Nichols', N'colton.nichols', N'password123', 3)
INSERT [dbo].[User] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK]) VALUES (5, N'Teter', N'Derek', N'derek.teter', N'password123', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author] FOREIGN KEY([AuthorID_FK])
REFERENCES [dbo].[Author] ([AuthorID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Author]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Genre] FOREIGN KEY([GenreID_FK])
REFERENCES [dbo].[Genre] ([GenreID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Genre]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Publisher] FOREIGN KEY([PublisherID_FK])
REFERENCES [dbo].[Publisher] ([PublisherID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Publisher]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_Users_Roles] FOREIGN KEY([RoleID_FK])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_Users_Roles]
GO
/****** Object:  StoredProcedure [dbo].[sp_get_users]    Script Date: 3/16/2021 4:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_get_users] 
	-- Add the parameters for the stored procedure here
	@parm_userid int= 0, @parm_username varchar(255) = ''
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF (@parm_userid = 0 AND @parm_username = '')
	BEGIN
		SELECT [UserID]
		  ,[LastName]
		  ,[FirstName]
		  ,[UserName]
		  ,[Password]
		  ,[RoleID_FK]
		FROM [Library].[dbo].[Users];
	END
	ELSE IF (@parm_userid <> 0)
	BEGIN
		SELECT 
			[UserID]
		   ,[LastName]
		   ,[FirstName]
		   ,[UserName]
		   ,[Password]
		   ,[RoleID_FK]
		FROM [Library].[dbo].[Users]
		WHERE UserID = @parm_userid;
	END
	ELSE IF (@parm_username <> '')
	BEGIN
		SELECT 
			[UserID]
		   ,[LastName]
		   ,[FirstName]
		   ,[UserName]
		   ,[Password]
		   ,[RoleID_FK]
		FROM [Library].[dbo].[Users]
		WHERE [UserName] = @parm_username;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_register_user]    Script Date: 3/16/2021 4:00:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_register_user] 
	-- Add the parameters for the stored procedure here
	@parm_FirstName varchar(255),
	@parm_LastName varchar(255),
	@parm_UserName varchar(255),
	@parm_Password varchar(255),
	@parm_RoleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Users 
		(
			[FirstName],
			[LastName],
			[UserName],
			[Password], 
			[RoleID_FK]
		) 
	VALUES 
		(
			@parm_FirstName, 
			@parm_LastName, 
			@parm_UserName, 
			@parm_Password, 
			@parm_RoleID
		);

END
GO
USE [master]
GO
ALTER DATABASE [Library] SET  READ_WRITE 
GO
