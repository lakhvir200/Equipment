USE [db_a7eaea_emsdb]
GO

/****** Object:  Table [dbo].[BudgetLookup]    Script Date: 2/13/2022 2:14:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BudgetLookup](
	[BudgetId] [int] IDENTITY(1,1) NOT NULL,
	[BudgetName] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [date] NULL,
	[UpdateDate] [date] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_BudgetLookups] PRIMARY KEY CLUSTERED 
(
	[BudgetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


