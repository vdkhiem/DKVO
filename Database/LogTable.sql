USE [TestDB]
GO

/****** Object:  Table [Connection].[Log]    Script Date: 06/20/2016 18:01:04 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Connection].[Log]') AND type in (N'U'))
DROP TABLE [Connection].[Log]
GO

USE [TestDB]
GO

/****** Object:  Table [Connection].[Log]    Script Date: 06/20/2016 18:01:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [Connection].[Log](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Thread] [varchar](255) NOT NULL,
	[Level] [varchar](50) NOT NULL,
	[Logger] [varchar](255) NOT NULL,
	[Message] [varchar](4000) NOT NULL,
	[Exception] [varchar](2000) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


