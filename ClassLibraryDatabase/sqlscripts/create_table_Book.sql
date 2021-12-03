USE [Library]
GO

/****** Object:  Table [dbo].[Book]    Script Date: 3/15/2021 7:56:09 PM ******/
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
	[AuthorID_FK] [int] NULL,
	[GenreID_FK] [int] NULL,
	[PublisherID_FK] [int] NULL,
 CONSTRAINT [PK__Book__3DE0C227F0DB5AC5] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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





