USE [db_a7eaea_emsdb]
GO

/****** Object:  Table [dbo].[EquipmentModelLookup]    Script Date: 2/13/2022 5:16:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[EquipmentModelLookup](
	[EquipModelID] [int] IDENTITY(1,1) NOT NULL,
	[EquipNameID] [int] NULL,
	[EquipModelName] [varchar](50) NULL,
	[IsActive] [nchar](10) NULL,
	[CreatedDate] [nchar](10) NULL,
	[UpdatedDate] [nchar](10) NULL,
	[CreatedBy] [nchar](10) NULL,
	[UpdatedBy] [nchar](10) NULL,
 CONSTRAINT [PK_EquipmentModelLookups] PRIMARY KEY CLUSTERED 
(
	[EquipModelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


