USE [db_a7eaea_emsdb]
GO

/****** Object:  Table [dbo].[SupplierLookup]    Script Date: 2/13/2022 5:24:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SupplierLookup](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NULL,
	[SupplierName] [nvarchar](255) NULL,
	[PT_TP] [nvarchar](255) NULL,
	[PT_ADR1] [nvarchar](255) NULL,
	[PT_ADR2] [nvarchar](255) NULL,
	[PT_ADR3] [nvarchar](255) NULL,
	[PINCODE] [nvarchar](255) NULL,
	[CONTACT] [nvarchar](255) NULL,
	[TELEPHONE] [nvarchar](255) NULL,
	[FAX] [nvarchar](255) NULL,
	[STATE] [nvarchar](255) NULL,
	[CITY] [nvarchar](255) NULL,
	[TAXNO] [nvarchar](255) NULL,
	[STATUS] [nvarchar](255) NULL,
	[GSTIN_NO] [nvarchar](255) NULL,
	[PAN_NO] [nvarchar](255) NULL,
 CONSTRAINT [PK__Supplier__3214EC27A528C0C4] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


