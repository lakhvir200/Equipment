USE [db_a7eaea_emsdb]
GO

/****** Object:  Table [dbo].[Equipments]    Script Date: 2/13/2022 5:19:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Equipments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EquipmentID] [varchar](max) NULL,
	[EquipNameID] [int] NULL,
	[EquipModelID] [int] NULL,
	[CategoryID] [int] NULL,
	[SubCategoryID] [int] NULL,
	[MaintPeriodicityID] [int] NULL,
	[UnitLookupID] [int] NULL,
	[Specifications] [varchar](max) NULL,
	[DepartmentID] [int] NULL,
	[BillDate] [date] NULL,
	[DateOfInstallation] [date] NULL,
	[CostOfEquipment] [decimal](18, 2) NULL,
	[SupplierID] [int] NULL,
	[StatusID] [int] NULL,
	[IsActive] [bit] NULL,
	[Remarks] [nvarchar](255) NULL,
	[UpdatedDate] [date] NULL,
	[BillDetail] [varchar](500) NULL,
	[BudgetYearID] [int] NULL,
 CONSTRAINT [PK_Equipments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


