USE [db_a7eaea_emsdb]
GO

/****** Object:  Table [dbo].[consumption]    Script Date: 2/13/2022 2:15:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[consumption](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DOC_NO] [nvarchar](7) NULL,
	[DOC_DT] [datetime] NULL,
	[DOC_TP] [nvarchar](2) NULL,
	[DRUG_SRNO] [nvarchar](5) NULL,
	[DRUG_NM] [nvarchar](100) NULL,
	[QTY] [float] NULL,
	[TAX_RT] [float] NULL,
	[TAX_AMT] [float] NULL,
	[B_E_CD] [nvarchar](6) NULL,
	[eqid] [nvarchar](50) NULL,
	[SUPP] [nvarchar](4) NULL,
	[SUPP_NAME] [nvarchar](48) NULL,
 CONSTRAINT [PK_consumptions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


