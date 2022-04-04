USE [db_a7eaea_emsdb]
GO

/****** Object:  Table [dbo].[MaintenancePeriodLookup]    Script Date: 2/13/2022 5:19:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MaintenancePeriodLookup](
	[MaintPerodicityID] [int] IDENTITY(1,1) NOT NULL,
	[Periodicity] [nchar](10) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[UpdatedBy] [int] NULL,
 CONSTRAINT [PK_MaintenancePeriodLookups] PRIMARY KEY CLUSTERED 
(
	[MaintPerodicityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


