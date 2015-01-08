USE [SpiderV1]
GO
/****** Object:  Table [dbo].[MasterSyntaxFile]    Script Date: 04/15/2010 20:24:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MasterSyntaxFile](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[MessageTitle] [varchar](50) COLLATE Latin1_General_CI_AS NULL,
	[XML] [xml] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF