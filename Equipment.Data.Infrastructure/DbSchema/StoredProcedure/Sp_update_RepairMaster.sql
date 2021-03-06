USE [db_a7eaea_emsdb]
GO
/****** Object:  StoredProcedure [dbo].[Sp_update_RepairMaster]    Script Date: 2/20/2022 8:28:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[Sp_update_RepairMaster]
@RID int,
@RDATE date,
@EQ_ID nvarchar(255),
@DEPT nvarchar(255),
@REPAIR_MAINT nvarchar(255),
@ACTION_TAKEN nvarchar(255),
@SPARES nvarchar(255),
@ATT_BY nvarchar(255),
@STATUS bit,
@RNO int

As
Begin
Update RepairMaster
Set RDATE=IsNull(@RDATE,RDATE),
EQ_ID=IsNull(@EQ_ID,EQ_ID),
DEPT=IsNull(@DEPT,DEPT),
REPAIR_MAINT=IsNull(@REPAIR_MAINT,REPAIR_MAINT),
ACTION_TAKEN=IsNull(@ACTION_TAKEN,ACTION_TAKEN),
SPARES=IsNull(@SPARES,SPARES),
ATT_BY=IsNull(@ATT_BY,ATT_BY),
STATUS=IsNull(@STATUS,STATUS),
RNO=IsNull(@RNO,RNO)
where RID=@RID
End