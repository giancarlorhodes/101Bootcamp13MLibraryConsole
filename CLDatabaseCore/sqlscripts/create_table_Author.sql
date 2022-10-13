USE [Library]
GO

/****** Object:  Table [dbo].[Author]    Script Date: 3/15/2021 7:57:11 PM ******/
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


