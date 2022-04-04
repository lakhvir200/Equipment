Alter proc Sp_Get_RepairMasterByID

@RID int

As 



Begin



Select RDATE,EQ_ID,DEPT,REPAIR_MAINT,ACTION_TAKEN,SPARES,ATT_BY,STATUS,RNO From RepairMaster Where RID=@RID



End