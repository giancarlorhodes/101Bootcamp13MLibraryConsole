USE [master]
GO
/****** Object:  Database [Library]    Script Date: 12/3/2021 2:15:46 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 12/3/2021 2:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[FirstName] [nvarchar](100) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[RoleID_FK] [int] NOT NULL,
	[Salt] [nvarchar](100) NULL,
	[Comment] [nvarchar](100) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/3/2021 2:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
	[Comment] [varchar](50) NULL,
 CONSTRAINT [PKRolesC4B278203D96CD14] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vwUserAndRole]    Script Date: 12/3/2021 2:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  CREATE view [dbo].[vwUserAndRole] AS
  SELECT UserId, FirstName, LastName, u.UserName, u.Password, r.RoleID,
  r.RoleName
  FROM [User] u 
  INNER JOIN [Role] r ON r.RoleID = u.RoleID_FK;
GO
/****** Object:  Table [dbo].[Book]    Script Date: 12/3/2021 2:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
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
/****** Object:  Table [dbo].[Genre]    Script Date: 12/3/2021 2:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[IsFiction] [bit] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Genre__0385055E592E8FE6] PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 12/3/2021 2:15:46 PM ******/
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
/****** Object:  Table [dbo].[Publisher]    Script Date: 12/3/2021 2:15:46 PM ******/
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
/****** Object:  View [dbo].[vwBookGenreAuthorPublisher]    Script Date: 12/3/2021 2:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[vwBookGenreAuthorPublisher] AS
SELECT 
	b.BookID, 
	b.Title, 
	b.Description,
	b.Price, 
	b.IsPaperBack,
	b.PublishDate,
	g.GenreID,
	g.Name AS GenreName,
	a.AuthorID,
	a.FirstName,
	a.LastName,
	p.PublisherID,
	p.Name AS PublisherName
FROM Book b
INNER JOIN Genre g ON g.GenreID = b.GenreID_FK
INNER JOIN Author a ON a.AuthorID = b.AuthorID_FK
INNER JOIN Publisher p on p.PublisherID = b.PublisherID_FK;
GO
/****** Object:  Table [dbo].[ExceptionLogging]    Script Date: 12/3/2021 2:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExceptionLogging](
	[ExeceptionLoggingID] [int] IDENTITY(1,1) NOT NULL,
	[StackTrace] [nvarchar](1000) NULL,
	[Message] [nvarchar](100) NOT NULL,
	[Source] [nvarchar](100) NULL,
	[Url] [nvarchar](100) NULL,
	[LogDate] [datetime] NOT NULL,
 CONSTRAINT [PK__ExeceptionLogging] PRIMARY KEY CLUSTERED 
(
	[ExeceptionLoggingID] ASC
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

INSERT [dbo].[Book] ([BookID], [Title], [Description], [Price], [IsPaperBack], [PublishDate], [AuthorID_FK], [GenreID_FK], [PublisherID_FK]) VALUES (1, N'Dancing with Jesus: Featuring a Host of Miraculous Moves', N'Are you cursed with two left feet? Are your dance moves unrighteous? Do you refrain from getting dow', 12.9500, 0, CAST(N'1986-12-01T00:00:00.000' AS DateTime), 1, 1, 4)
INSERT [dbo].[Book] ([BookID], [Title], [Description], [Price], [IsPaperBack], [PublishDate], [AuthorID_FK], [GenreID_FK], [PublisherID_FK]) VALUES (2, N'Roughing It', N'Roughing It (1872) is Twain’s second book, a comedic romp through the Wild West with hilarious sketc', 21.0000, 1, CAST(N'1865-04-15T00:00:00.000' AS DateTime), 5, 1, 2)
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Genre] ON 

INSERT [dbo].[Genre] ([GenreID], [Description], [IsFiction], [Name]) VALUES (1, N'A comic novel is usually a work of fiction in which the writer seeks to amuse the reader, sometimes ', 1, N'Humor')
INSERT [dbo].[Genre] ([GenreID], [Description], [IsFiction], [Name]) VALUES (2, N'An account of someone''s life written by someone else.', 0, N'Biography')
INSERT [dbo].[Genre] ([GenreID], [Description], [IsFiction], [Name]) VALUES (4, N'How to improvement yourself', 0, N'Self Improvement')
INSERT [dbo].[Genre] ([GenreID], [Description], [IsFiction], [Name]) VALUES (5, N'Literature in the form of prose, especially short stories and novels, that describes imaginary event', 1, N'Fiction')
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
SET IDENTITY_INSERT [dbo].[Publisher] ON 

INSERT [dbo].[Publisher] ([PublisherID], [Name], [Address], [City], [State], [Zip]) VALUES (1, N'Penguin Random House', N'89348 Market Ave.', N'New York', N'NY', 19123)
INSERT [dbo].[Publisher] ([PublisherID], [Name], [Address], [City], [State], [Zip]) VALUES (2, N'HarperCollins', N'43rd Roseland St.', N'Chicago', N'IL', 64452)
INSERT [dbo].[Publisher] ([PublisherID], [Name], [Address], [City], [State], [Zip]) VALUES (4, N'Macmillan Publishers', N'120 McCallin Ave.', N'New York', N'NY', 19045)
INSERT [dbo].[Publisher] ([PublisherID], [Name], [Address], [City], [State], [Zip]) VALUES (5, N'Simon & Schuster', N'9349 35th Ave.', N'Kansas City', N'MO', 10564)
INSERT [dbo].[Publisher] ([PublisherID], [Name], [Address], [City], [State], [Zip]) VALUES (6, N'Special Publishing Company', N'1 N Rangeline Rd.', N'Columbia', N'MO', 65201)
SET IDENTITY_INSERT [dbo].[Publisher] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [RoleName], [Comment]) VALUES (1, N'Administrator', NULL)
INSERT [dbo].[Role] ([RoleID], [RoleName], [Comment]) VALUES (2, N'Librarian', NULL)
INSERT [dbo].[Role] ([RoleID], [RoleName], [Comment]) VALUES (3, N'Patron', NULL)
INSERT [dbo].[Role] ([RoleID], [RoleName], [Comment]) VALUES (43, N'Guest', NULL)
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK], [Salt], [Comment]) VALUES (1, N'Rhodes', N'Giancarlo', N'grhodes29', N'0e71137e7a547a776a4d09457ad442ef1688e00a1ef5c1a26fea06858a76ec0a', 1, N'0d5344bd-1c04-47a9-8894-c27660a6cb74', N'password123')
INSERT [dbo].[User] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK], [Salt], [Comment]) VALUES (2, N'Adams', N'Dillan', N'dillan.adams', N'0e71137e7a547a776a4d09457ad442ef1688e00a1ef5c1a26fea06858a76ec0a', 3, N'0d5344bd-1c04-47a9-8894-c27660a6cb74', N'password123')
INSERT [dbo].[User] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK], [Salt], [Comment]) VALUES (4, N'Colton', N'Nichols', N'colton.nichols', N'0e71137e7a547a776a4d09457ad442ef1688e00a1ef5c1a26fea06858a76ec0a', 3, N'0d5344bd-1c04-47a9-8894-c27660a6cb74', N'password123')
INSERT [dbo].[User] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK], [Salt], [Comment]) VALUES (5, N'Teter', N'Derek', N'derek.teter', N'0e71137e7a547a776a4d09457ad442ef1688e00a1ef5c1a26fea06858a76ec0a', 2, N'0d5344bd-1c04-47a9-8894-c27660a6cb74', N'password123')
INSERT [dbo].[User] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK], [Salt], [Comment]) VALUES (6, N'Tester', N'Joe', N'patron', N'0e71137e7a547a776a4d09457ad442ef1688e00a1ef5c1a26fea06858a76ec0a', 3, N'0d5344bd-1c04-47a9-8894-c27660a6cb74', N'password123')
INSERT [dbo].[User] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK], [Salt], [Comment]) VALUES (7, N'Tester', N'Sally', N'librarian', N'0e71137e7a547a776a4d09457ad442ef1688e00a1ef5c1a26fea06858a76ec0a', 3, N'0d5344bd-1c04-47a9-8894-c27660a6cb74', N'password123')
INSERT [dbo].[User] ([UserID], [LastName], [FirstName], [UserName], [Password], [RoleID_FK], [Salt], [Comment]) VALUES (8, N'Patron', N'Joe', N'Patron123456', N'a03d367adc43bb9e5c69caa4a562cfdb298dfdeef77dca8d863067a38c58807e', 3, N'b39610e1-1c5c-4384-9507-1b98b5838509', N'password123')
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
/****** Object:  StoredProcedure [dbo].[sp_Delete_Role]    Script Date: 12/3/2021 2:15:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Delete_Role](@parm_role_id int) 
AS 

BEGIN

  DELETE  FROM Role
  WHERE RoleID = @parm_role_id

 END
GO
/****** Object:  StoredProcedure [dbo].[spCreateAuthor]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:        <Author,,Name>
-- Create date: <Create Date,,>
-- Description:    <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spCreateAuthor]  
    -- Add the parameters for the stored procedure here   
    (@ParamFirstName nvarchar(100), 
	@ParamLastName nvarchar(100), 
	@ParamBio nvarchar(500),
	@ParamDateOfBirth datetime, 
	@ParamBirthLocation nvarchar(100))
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    --SELECT <@Param1, sysname, @p1>, <@Param2, sysname, @p2>

    INSERT INTO Author 
		( 
			FirstName, 
			LastName, 
			Bio, 
			DateOfBirth, 
			BirthLocation
		) VALUES 
		(
			@ParamFirstName, 
			@ParamLastName, 
			@ParamBio, 
			@ParamDateOfBirth, 
			@ParamBirthLocation
		);

END
GO
/****** Object:  StoredProcedure [dbo].[spCreateBook]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spCreateBook]
	-- Add the parameters for the stored procedure here
	 @ParamTitle nvarchar(100),
	 @ParamDescription nvarchar(1000),
	 @ParamPrice money,
	 @ParamIsPaperBack bit,
	 @ParamPublishDate datetime,
	 @ParamAuthorID_FK int,
	 @ParamGenreID_FK int,
	 @ParamPublisherID_FK int,
	 @ParamOutBookID int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Book]
           ([Title]
           ,[Description]
           ,[Price]
           ,[IsPaperBack]
           ,[PublishDate]
           ,[AuthorID_FK]
           ,[GenreID_FK]
           ,[PublisherID_FK])
     VALUES
           (@ParamTitle
           ,@ParamDescription
           ,@ParamPrice
           ,@ParamIsPaperBack
           ,@ParamPublishDate
           ,@ParamAuthorID_FK
           ,@ParamGenreID_FK
           ,@ParamPublisherID_FK)

	SELECT @ParamOutBookID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spCreateGenre]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spCreateGenre]  
(@ParamName nvarchar(100),  
@ParamDescription nvarchar(100), 
@ParamIsFiction bit)
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

 INSERT INTO Genre([Name], [Description], IsFiction)
 VALUES(@ParamName, @ParamDescription, @ParamIsfiction);


END
GO
/****** Object:  StoredProcedure [dbo].[spCreateLogException]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spCreateLogException] 
-- Add the parameters for the stored procedure here
@parmStackTrace nvarchar(100),
@parmMessage nvarchar(100),
@parmSource nvarchar(100),
@parmURL nvarchar(100),
@parmLogdate datetime
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

INSERT INTO [dbo].[ExceptionLogging]
           ([StackTrace]
           ,[Message]
           ,[Source]
           ,[Url]
           ,[LogDate])
     VALUES
           (@parmStackTrace
           ,@parmMessage
           ,@parmSource
           ,@parmURL
           ,@parmLogdate
		   )

END
GO
/****** Object:  StoredProcedure [dbo].[spCreatePublisher]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spCreatePublisher] 
-- Add the parameters for the stored procedure here
@ParamPublisherName nvarchar(100),
@ParamPublisherCity nvarchar(100),
@ParamPublisherState nvarchar(100),
@ParamPublisherAddress nvarchar(100),
@ParamPublisherZip int
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;


    -- Insert statements for procedure here
Insert into Publisher ( [Name],City,[State],[Address],Zip)
Values (@ParamPublisherName,@ParamPublisherCity,@ParamPublisherState,@ParamPublisherAddress, @ParamPublisherZip);


END
GO
/****** Object:  StoredProcedure [dbo].[spCreateRole]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spCreateRole]
	-- Add the parameters for the stored procedure here	
	 @ParamRoleName nvarchar(100), 
	 @ParamOutRoleID int out
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Role (RoleName) VALUES (@ParamRoleName);
		-- make an actual **assignment** here...
    SELECT @ParamOutRoleID = SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[spCreateUser]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spCreateUser] 
(
@ParamLastName nvarchar(100), 
@ParamFirstName nvarchar(100), 
@ParamUserName nvarchar(100), 
@ParamPassword nvarchar(100), 
@ParamRoleID int,
@ParamSalt nvarchar(100)
)
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;


    -- Insert statements for procedure here
INSERT INTO [User]
(
	LastName, 
	FirstName, 
	UserName, 
	[Password], 
	RoleID_FK,
	Salt
)
VALUES 
(
	@ParamLastName,
	@ParamFirstName, 
	@ParamUserName, 
	@ParamPassword, 
	@ParamRoleID,
	@ParamSalt
)
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteAuthor]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:        <Austin>
-- Create date: <4-14-21>
-- Description:    <Delete Author>
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteAuthor]
    -- Add the parameters for the stored procedure here
    @ParamAuthorID int




AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;


    -- Insert statements for procedure here
    DELETE FROM Author WHERE AuthorID = @ParamAuthorID;
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteBook]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteBook]
	-- Add the parameters for the stored procedure here
	 @ParamBookID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Book WHERE BookID = @ParamBookID;

END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteGenre]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteGenre]  
   
@ParamGenreID int

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

 DELETE FROM Genre Where GenreID = @ParamGenreID


 END
GO
/****** Object:  StoredProcedure [dbo].[spDeletePublisher]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDeletePublisher]
-- Add the parameters for the stored procedure here
@ParamPublisherID int

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;


    -- Insert statements for procedure here
Delete From Publisher where PublisherID = @ParamPublisherID;
END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteRole]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteRole]
	-- Add the parameters for the stored procedure here
	 @ParamRoleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Role WHERE RoleID = @ParamRoleID;

END
GO
/****** Object:  StoredProcedure [dbo].[spDeleteUser]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
Create PROCEDURE [dbo].[spDeleteUser] 
(@ParamUserID int)
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;




    -- Insert statements for procedure here
DELETE FROM [User] WHERE UserID = @ParamUserID
END
GO
/****** Object:  StoredProcedure [dbo].[spGetAuthor]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:        <Austin>
-- Create date: <4-14-21>
-- Description:    <Read/Get Author>
-- =============================================
CREATE PROCEDURE [dbo].[spGetAuthor]
    -- Add the parameters for the stored procedure here
    
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    -- Insert statements for procedure here
    Select * FROM Author
END
GO
/****** Object:  StoredProcedure [dbo].[spGetBook]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetBook]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	  [BookID]
      ,[Title]
      ,[Description]
      ,[Price]
      ,[IsPaperBack]
      ,[PublishDate]
      ,[AuthorID_FK]
      ,[GenreID_FK]
      ,[PublisherID_FK]
  FROM [Book];
END
GO
/****** Object:  StoredProcedure [dbo].[spGetGenre]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
 CREATE PROCEDURE [dbo].[spGetGenre]


AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    -- Insert statements for procedure here
SELECT * FROM [Genre]
END
GO
/****** Object:  StoredProcedure [dbo].[spGetPublisher]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetPublisher] 
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT * From Publisher;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetRole]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetRole] 
	-- Add the parameters for the stored procedure here
	--<@Param1, sysname, @p1> <Datatype_For_Param1, , int> = <Default_Value_For_Param1, , 0>, 
	---<@Param2, sysname, @p2> <Datatype_For_Param2, , int> = <Default_Value_For_Param2, , 0>
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT RoleID, RoleName FROM Role;
END
GO
/****** Object:  StoredProcedure [dbo].[spGetUser]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spGetUser] 

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT * FROM [User];
--SELECT * FROM vwUserAndRole;

END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateAuthor]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateAuthor] 
(@ParamAuthorID int, 
@ParamLastName nvarchar(100), 
@ParamFirstName nvarchar(100), 
@ParamBio nvarchar(500), 
@ParamDateOfBirth datetime, 
@ParamBirthLocation nvarchar(100))
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;


    -- Insert statements for procedure here
Update [Author] 
SET LastName = @ParamLastName, 
FirstName = @ParamFirstName, 
Bio = @ParamBio, 
DateOfBirth = @ParamDateOfBirth
WHERE AuthorID = @ParamAuthorID
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateBook]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateBook]
	-- Add the parameters for the stored proceure here
	 @ParamBookID int,
	 @ParamTitle nvarchar(100),
	 @ParamDescription nvarchar(1000),
	 @ParamPrice money,
	 @ParamIsPaperBack bit,
	 @ParamPublishDate datetime,
	 @ParamAuthorID_FK int,
	 @ParamGenreID_FK int,
	 @ParamPublisherID_FK int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[Book]
           SET [Title] = @ParamTitle
           ,[Description] = @ParamDescription
           ,[Price] = @ParamPrice
           ,[IsPaperBack] = @ParamIsPaperBack
           ,[PublishDate] = @ParamPublishDate
           ,[AuthorID_FK] = @ParamAuthorID_FK
           ,[GenreID_FK] = @ParamGenreID_FK
           ,[PublisherID_FK] = @ParamPublisherID_FK
	WHERE [BookID] = @ParamBookID;
END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateGenre]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
Create PROCEDURE [dbo].[spUpdateGenre]
-- Add the parameters for the stored procedure here
@ParamGenreID int,
@ParamName nvarchar(50),
@ParamDescription nvarchar(100),
@ParamIsFiction bit


AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;


    -- Insert statements for procedure here
UPDATE Genre
SET [Name] = @ParamName,
[Description] = @ParamDescription,
IsFiction = @ParamIsFiction
WHERE GenreID = @ParamGenreID


END
GO
/****** Object:  StoredProcedure [dbo].[spUpdatePublisher]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================

CREATE PROCEDURE [dbo].[spUpdatePublisher] 
-- Add the parameters for the stored procedure here
@ParamPublisherID int,
@ParamPublisherName nvarchar(100),
@ParamPublisherCity nvarchar(100),
@ParamPublisherState nvarchar(100),
@ParamPublisherAddress nvarchar(100),
@ParamPublisherZip int
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;


    -- Insert statements for procedure here
Update Publisher 
Set 
	[Name] = @ParamPublisherName, 
	City = @ParamPublisherCity ,
	[State] = @ParamPublisherState, 
	[Address] = @ParamPublisherAddress, 
	[Zip] = @ParamPublisherZip
Where PublisherID = @ParamPublisherID


END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateRole]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateRole]
	-- Add the parameters for the stored procedure here
	 @ParamRoleName nvarchar(100),
	 @ParamRoleID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Role SET RoleName = @ParamRoleName WHERE RoleID = @ParamRoleID;

END
GO
/****** Object:  StoredProcedure [dbo].[spUpdateUser]    Script Date: 12/3/2021 2:15:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: <Author,,Name>
-- Create date: <Create Date,,>
-- Description: <Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spUpdateUser] 
(
@ParamUserID int, 
@ParamLastName nvarchar(100), 
@ParamFirstName nvarchar(100), 
@ParamUserName nvarchar(100), 
@ParamPassword nvarchar(100), 
@ParamRoleID int,
@ParamSalt nvarchar(100)
)
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;


    -- Insert statements for procedure here
Update [User] 
SET LastName = @ParamLastName, 
FirstName = @ParamFirstName, 
UserName = @ParamUserName, 
[Password] = @ParamPassword, 
RoleID_FK = @ParamRoleID,
Salt = @ParamSalt
WHERE UserID = @ParamUserID;



END
GO
USE [master]
GO
ALTER DATABASE [Library] SET  READ_WRITE 
GO
