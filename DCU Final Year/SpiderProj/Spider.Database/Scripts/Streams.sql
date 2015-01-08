USE [SpiderV1]
GO
/****** Object:  Table [dbo].[Streams]    Script Date: 04/15/2010 20:25:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Streams](
	[StreamsID] [int] IDENTITY(1,1) NOT NULL,
	[IPAddress] [nchar](10) COLLATE Latin1_General_CI_AS NOT NULL,
	[PortNumber] [nchar](10) COLLATE Latin1_General_CI_AS NOT NULL
) ON [PRIMARY]
