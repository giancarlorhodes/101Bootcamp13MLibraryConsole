USE [Book]
GO

/****** Object:  Table [dbo].[Book]    Script Date: 2/5/2021 2:10:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Book](
	[Book_ID_ISBN] [uniqueidentifier] NOT NULL,
	[Title] [nchar](100) NOT NULL,
	[Description] [nchar](100) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[IsPaperback] [bit] NOT NULL,
	[PublishDate] [datetime] NOT NULL,
	[Author_FK] [int] NOT NULL,
	[Genre_FK] [int] NOT NULL,
	[Publisher_FK] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[Book_ID_ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, 
ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Book] ADD  CONSTRAINT [DF_Book_Book_ID_ISBN]  DEFAULT (newid()) FOR [Book_ID_ISBN]
GO

ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author] FOREIGN KEY([Author_FK])
REFERENCES [dbo].[Author] ([Author_ID])
GO

ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Author]
GO


