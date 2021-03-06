USE [SpiderV1]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04/15/2010 20:26:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[Password] [varchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[isAdvanced] [bit] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF