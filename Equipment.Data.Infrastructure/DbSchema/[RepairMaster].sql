USE [db_a7eaea_emsdb]
GO

/****** Object:  Table [dbo].[RepairMaster]    Script Date: 2/13/2022 5:22:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RepairMaster](
	[RID] [int] IDENTITY(1,1) NOT NULL,
	[RDATE] [datetime] NULL,
	[EQ_ID] [nvarchar](255) NULL,
	[DEPT] [nvarchar](255) NULL,
	[REPAIR_MAINT] [nvarchar](255) NULL,
	[ACTION_TAKEN] [nvarchar](255) NULL,
	[SPARES] [nvarchar](255) NULL,
	[ATT_BY] [nvarchar](255) NULL,
	[STATUS] [bit] NULL,
	[RNO] [int] NULL,
 CONSTRAINT [PK_RepairMaster] PRIMARY KEY CLUSTERED 
(
	[RID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


