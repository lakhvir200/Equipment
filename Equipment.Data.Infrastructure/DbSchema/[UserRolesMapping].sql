USE [db_a7eaea_emsdb]
GO

/****** Object:  Table [dbo].[UserRolesMapping]    Script Date: 2/13/2022 5:24:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserRolesMapping](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppUserID] [int] NULL,
	[RoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserRolesMapping]  WITH CHECK ADD FOREIGN KEY([AppUserID])
REFERENCES [dbo].[AppUser] ([AppUserID])
GO


