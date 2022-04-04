USE [db_a7eaea_emsdb]
GO

/****** Object:  Table [dbo].[UnitLookup]    Script Date: 2/13/2022 5:24:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[UnitLookup](
	[UnitLookupID] [int] IDENTITY(1,1) NOT NULL,
	[UnitName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [date] NULL,
	[UpdatedDate] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_UnitLookups] PRIMARY KEY CLUSTERED 
(
	[UnitLookupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


