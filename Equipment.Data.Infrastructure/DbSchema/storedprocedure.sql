USE [db_a7eaea_emsdb]
GO
/****** Object:  StoredProcedure [dbo].[Get_Master]    Script Date: 2/13/2022 1:50:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Get_Master]
@MasterID int
As
Begin
Select * From Master Where MasterID=@MasterID
End
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_Category]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sp_Delete_Category]
@CategoryID int,
@IsActive bit,
@IsPermanentDelete bit
As
Update CategoryLookup
Set IsActive=@IsActive
Where CategoryID=@CategoryID if @IsPermanentDelete=1

Begin
Delete from Master Where MasterID=@CategoryID
End

GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_EquipmentNameLookup]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Delete_EquipmentNameLookup]
@EquipNameID  int,
@IsActive Bit,
@IsPermanentDelete bit

As 
Update EquipmentNameLookup
Set IsActive=@IsActive
where EquipNameID=@EquipNameID if @IsPermanentDelete=1
Begin
Delete from  EquipmentNameLookup Where EquipNameID=@EquipNameID
End
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_Master]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Sp_Delete_Master]
@MasterID int
As
Begin
Delete From Master Where MasterID=@MasterID
End
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_RepairMaster]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Delete_RepairMaster]  
@RID int,  
@STATUS bit,  
@IsPermanentDelete bit  
As  
update RepairMaster  
Set STATUS=@STATUS  
Where RID=@RID if @IsPermanentDelete=1  
  
Begin  
Delete from RepairMaster Where RID=@RID  
End
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_All_AppUser]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Get_All_AppUser]
 
 
As
Begin
Select  AppUserID,FirstName,LastName,Address,Designation,UserID,Password,IsActive,CreatedDate,UpdatedDate 
from AppUser 


END



GO
/****** Object:  StoredProcedure [dbo].[sp_Get_All_Category]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Get_All_Category]

As
Begin
SELECT 
c.CategoryID,c.CategoryName,c.CreatedBy,c.CreatedDate,c.IsActive
,c.UpdateDate,app.FirstName	
      
FROM CategoryLookups c

INNER JOIN AppUsers as app on c.CreatedBy=app.AppUserID
 
end



GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_All_CategoryLookup]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Sp_Get_All_CategoryLookup]
AS
Begin
Select CategoryID,CategoryName,IsActive,CreatedDate,UpdateDate,CreatedBy,UpdatedBy from CategoryLookup

End
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_All_Department]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Get_All_Department]
--- @Depart int
As
Begin
SELECT DepartmentID,DepartmentName,CreatedDate,CreatedBy,UpdateDate,UpdatedBy,IsActive  FROM DepartmentLookups

end



GO
/****** Object:  StoredProcedure [dbo].[sp_Get_All_Equipment_Details]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Get_All_Equipment_Details]
AS
BEGIN
   Select 
     p.ID,
	 UnitName,	 	
     EquipmentID,
	 EquipmentName,
	 DepartmentName,
	 EquipmentStatus,
	 CategoryName,
	 Specifications,
	 BillDate,
	 DateOfInstallation,
	 CostOfEquipment,	
	 SubCategoryName,
	 Periodicity,	
SupplierName

	

    FROM 
	[ElectronicsDev].[dbo].[Equipment]p
  
	   
 JOIN [ElectronicsDev].[dbo].[UnitLookup]u
   ON p.UnitLookupID=u.UnitLookupID

   JOIN [ElectronicsDev].[dbo].[EquipmentNameLookUp]e
   ON p.EquipNameID=e.EquipNameID

   JOIN [ElectronicsDev].[dbo].[DepartmentLookup]d
   ON p.DepartmentID=d.DepartmentID

   JOIN [ElectronicsDev].[dbo].[StatusLookup]t
   ON p.StatusID=t.StatusID

  Join [ElectronicsDev].[dbo].[CategoryLookup]s
  on p.CategoryID=s.CategoryID


    JOIN [ElectronicsDev].[dbo].[SubCategoryLookup] sc  

   ON p.SubCategoryID=sc.SubCategoryID

 JOIN [ElectronicsDev].[dbo].[MaintenancePeriodLookup]m
   On p.MaintPeriodicityID=m.MaintPerodicityID
    
JOIN [ElectronicsDev].[dbo].[SupplierLookup]n
   ON p.SupplierID=n.SupplierID
     
       
END;



GO
/****** Object:  StoredProcedure [dbo].[sp_Get_All_Equipment_Detailsold]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Get_All_Equipment_Detailsold]
AS
BEGIN
    SELECT top 5
	 UnitName,
     EquipmentID,
	 EquipmentName,
	 DepartmentName,
	 EquipmentStatus,
	 Specifications,
	 BillDate,
	 DateOfInstallation,
	 CostOfEquipment,
	 CategoryName,
	 SubCategoryName,
	 Periodicity,	
	 PT_NM

	

    FROM 
	[Electronics].[dbo].[Equipments]p

	   
INNER JOIN [Electronics].[dbo].[UnitLookups]u
   ON p.UnitLookupID=u.UnitLookupID

    INNER JOIN [Electronics].[dbo].[EquipmentNameLookUps]e
   ON p.EquipNameID=e.EquipNameID

    INNER JOIN [Electronics].[dbo].[DepartmentLookups]d
   ON p.DepartmentID=d.DepartmentID

    INNER JOIN [Electronics].[dbo].[StatusLookups]s
   ON p.StatusID=s.StatusID


	 INNER JOIN [Electronics].[dbo].[CategoryLookups]c
   ON p.CategoryID=c.CategoryID 

    INNER JOIN [Electronics].[dbo].[SubCategoryLookups]sc
   ON p.SubCategoryID=sc.SubCategoryID



  INNER JOIN [Electronics].[dbo].[MaintenancePeriodLookups]m
   On p.MaintPeriodicityID=m.MaintPerodicityID
    
	INNER JOIN [Electronics].[dbo].[SupplierLookups]sp
   ON p.SupplierID=sp.PT_CD
     
       
END;



GO
/****** Object:  StoredProcedure [dbo].[sp_Get_All_EquipmentModel_Details]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_Get_All_EquipmentModel_Details]
AS
BEGIN
   Select 
     p.ID,
	 p.EquipModelName,
     e.EquipmentName

	

    FROM 
	[Electronics].[dbo].[EquipmentModelLookups]p   
 

   JOIN [Electronics].[dbo].[EquipmentNamelookUps]e
   ON p.EquipNameID=e.EquipNameID

   
     
       
END;



GO
/****** Object:  StoredProcedure [dbo].[sp_Get_All_EquipmentName]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Get_All_EquipmentName]

As
Begin
SELECT 
c.EquipNameID,c.EquipmentName,c.CreatedBy,c.CreatedDate,c.IsActive
,c.UpdatedBy,app.FirstName	
      
FROM EquipmentNamelookUps c

INNER JOIN AppUsers as app on c.CreatedBy=app.AppUserID
 
end



GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_All_EquipmentNameLookup]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Get_All_EquipmentNameLookup]  
@MasterId int
As  
Begin  
if(@MasterId=1)
	BEGIN
		Select EquipNameID ID,EquipmentName Name ,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy  
		From EquipmentNameLookup  
	End
END



GO
/****** Object:  StoredProcedure [dbo].[sp_Get_All_Equipments]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC [sp_Get_All_Equipments] 10,20

CREATE proc [dbo].[sp_Get_All_Equipments]  
@StartIndex int=1,
@EndIndex int=10
As  
Begin
SELECT ID EquipmentID,	EquipmentID EquipmentCode	,EquipNameID,	EquipModelID,	
CategoryID	,SubCategoryID,	MaintPeriodicityID	,
UnitLookupID,	Specifications,	DepartmentID,	
BillDate DateOfPurchase,	DateOfInstallation,	CostOfEquipment	,
SupplierID,	StatusID,	IsActive,UpdatedDate,	Remarks FROM (SELECT  ROW_NUMBER() OVER ( ORDER BY ID DESC) AS RowNum, *  FROM  Equipments) AS RowConstrainedResult
WHERE RowNum >= @StartIndex
    AND RowNum < @EndIndex
ORDER BY RowNum
end  



GO
/****** Object:  StoredProcedure [dbo].[sp_Get_All_Maintenance]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Get_All_Maintenance] 

As
SELECT  MaintPerodicityID,Periodicity,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy
FROM MaintenancePeriodLookup 



GO
/****** Object:  StoredProcedure [dbo].[sp_Get_All_Repair_Details]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Get_All_Repair_Details]
AS
BEGIN
      Select 
	  RID,         
      RDate,
      EQ_ID, 
	  0 as EquipmentID,
      '' Specifications,       
      '' DepartmentName,
	  REPAIR_MAINT,        
      Action_Taken,        
      Spares Used,	         
      STATUS   FROM [dbo].[RepairMaster] p 
	  --Left JOIN [dbo].[Equipments] e
	  --ON p.EQ_ID=e.EquipmentID
	  --Left JOIN [dbo].[DepartmentLookup]d
   --   ON p.EQ_ID=e.EquipmentID

END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_All_Status]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_Get_All_Status]

As
Begin
SELECT StatusID,EquipmentStatus,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy
FROM StatusLookup

end



GO
/****** Object:  StoredProcedure [dbo].[sp_Get_All_SubCategoryLookup]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Get_All_SubCategoryLookup]
 
As
Begin
Select  c.SubCategoryID, c.SubCategoryName, c.IsActive, c.CreatedDate,
c.UpdatedDate,CreatedBy,UpdatedBy, app.FirstName	

from SubCategoryLookups c
inner join 
AppUsers as app on c.CreatedBy=app.AppUserID

END



GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_All_SubMaster]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Get_All_SubMaster]
@MasterId int
As  
Begin  
if(@MasterId=1)
	BEGIN
		Select EquipNameID ID,EquipmentName Name ,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy  
		From EquipmentNameLookup  
	End
	if(@MasterId=2)
	BEGIN
		Select StatusID ID,EquipmentStatus Name ,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy  
		From StatusLookup  
	End
	if(@MasterId=3)
	BEGIN
		Select CategoryID ID,CategoryName Name ,IsActive,CreatedDate,CreatedBy,UpdatedBy  
		From CategoryLookup  
	End
	if(@MasterId=4)
	BEGIN
		Select SubCategoryID ID,SubCategoryName Name ,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy  
		From SubCategoryLookup  
	End
	if(@MasterId=5)
	BEGIN
		Select DepartmentID ID,DepartmentName Name  
		From DepartmentLookup  
	End
	if(@MasterId=6)
	BEGIN
		Select MaintPerodicityID ID,Periodicity Name ,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy  
		From MaintenancePeriodLookup  
	End
	if(@MasterId=7)
	BEGIN
		Select BudgetID ID,BudgetName Name ,IsActive,CreatedDate,CreatedBy,UpdatedBy  
		From BudgetLookup  
	End
	if(@MasterId=8)
	BEGIN
		Select SupplierID ID,SupplierName Name 
		From [SupplierLookup]
	End
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_All_UnitLookup]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Get_All_UnitLookup]
 
As
Begin
Select UnitLookupID,UnitName
from UnitLookups where IsActive=1


END



GO
/****** Object:  StoredProcedure [dbo].[sp_Get_AppUserById]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Get_AppUserById]
 @AppUserID int
 
As
Begin
Select  AppUserID,FirstName,LastName,Address,Designation,UserID,Password,IsActive,CreatedDate,UpdatedDate 
from AppUser where  AppUserID=@AppUserID 


END



GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_AppUserLogin]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Sp_Get_AppUserLogin]
@UserID nvarchar(255),
@Password nvarchar(255)
As
Begin

Select * From AppUser Where UserID=@UserID and Password=@Password

End
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_CategoryById]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[sp_Get_CategoryById]
@CategoryID int
As
Begin
SELECT CategoryID,CategoryName,CreatedDate,CreatedBy,UpdateDate,UpdatedBy,IsActive 
FROM CategoryLookup where @CategoryID=@CategoryID

end




GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Dashboard_Count]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Get_Dashboard_Count]

As

Begin



declare @totalEquip int,@totalRepair int,@totalPurchase int,@totalmaintenance int

set @totalEquip=(Select Count (*) TotalEquipments From Equipments)

set @totalRepair=(Select Count (*) TotalRepair From RepairMaster)

set @totalPurchase=0

set @totalmaintenance=0

SELECT @totalEquip  TotalEquipment,@totalRepair TotalRepair,@totalPurchase TotalPurchase,@totalmaintenance TotalMaintenance

Select top 3 *,e.id as Equipmentid,e.IsActive as Status  from Equipments e inner join [EquipmentNamelookUp] el 
on el.equipnameid=e.equipnameid Order by 1 desc

Select top 3 *  from RepairMaster Order by 1 desc



End

GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_DocumentsByParamID]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Get_DocumentsByParamID]
@ModuleParamID int
As
Begin
Select * from Documents where ModuleParamID=@ModuleParamID

End
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_EquipmentsByID]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Get_EquipmentsByID]
@ID int
As

Begin
Select distinct e.ID EquipmentID,e.Specifications,e.EquipmentID EquipmentCode	,e.EquipNameID,	e.EquipModelID,	
e.CategoryID	,e.SubCategoryID,	e.MaintPeriodicityID,e.UnitLookupID,	e.DepartmentID,	
e.BillDate DateOfPurchase,	e.DateOfInstallation,	e.CostOfEquipment,e.SupplierID,	e.StatusID,	e.IsActive,e.UpdatedDate,	e.Remarks,
el.EquipmentName,C.CategoryName,Sc.SubCategoryName,d.DepartmentName,s.SupplierName,sl.EquipmentStatus,mp.Periodicity From Equipments
e left join EquipmentNamelookUp el on e.EquipNameID=el.EquipNameID
 left join CategoryLookup C on e.CategoryID=C.CategoryID
 left join SubCategoryLookup Sc on e.SubCategoryID=Sc.SubCategoryID
 left join DepartmentLookup d on e.DepartmentID=d.DepartmentID
 left join SupplierLookup s on e.SupplierID=s.SupplierID
 left join StatusLookup sl on e.StatusID=sl.StatusID
 left join MaintenancePeriodLookup mp on e.MaintPeriodicityID=mp.MaintPerodicityID
  
Where e.ID=@ID 

End
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_MaintenanceById]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Get_MaintenanceById] 
@MaintPerodicityID int
As
SELECT  MaintPerodicityID,Periodicity,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy
FROM MaintenancePeriodLookup where MaintPerodicityID=@MaintPerodicityID



GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_Master]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Get_Master]
@MasterID int
As
Begin
Select * From Master Where MasterID=@MasterID
End
GO
/****** Object:  StoredProcedure [dbo].[Sp_Get_MasterLookup]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Get_MasterLookup]

@MasterId int=0

As

Begin

if @MasterId=0

	Begin

		Select  EquipNameID,EquipmentName From EquipmentNamelookUp order by 1 desc

		Select  StatusID,EquipmentStatus From StatusLookup

		Select  CategoryID,CategoryName From CategoryLookup order by 1 desc

		Select  SubCategoryID,SubCategoryName From SubCategoryLookup order by 1 desc

		Select  SupplierID,SupplierName From SupplierLookup order by 1 desc

		Select  BudgetID,BudgetName From BudgetLookup order by 1 desc

		Select DepartmentID,DepartmentName From DepartmentLookup order by 1 desc

		Select MaintPerodicityID,Periodicity From MaintenancePeriodLookup order by 1 desc

		Select [UnitLookupID] HospitalID,[UnitName] HospitalName From Unitlookup order by 1 desc

	END

if @MasterId=1

	Begin

		Select  EquipNameID,EquipmentName From EquipmentNamelookUp order by 1 desc		

	END



End

GO
/****** Object:  StoredProcedure [dbo].[sp_Get_StatusById]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Get_StatusById]
@StatusID int
As
Begin
SELECT StatusID,EquipmentStatus,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy
FROM StatusLookup where StatusID =@StatusID 

end



GO
/****** Object:  StoredProcedure [dbo].[sp_Get_SubCategoryLookupById]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Get_SubCategoryLookupById]
 @SubCategoryID int
As
Begin
Select  SubCategoryName,IsActive,CreatedDate,
UpdatedDate,CreatedBy,UpdatedBy 
from SubCategoryLookup where  SubCategoryID= @SubCategoryID


END




GO
/****** Object:  StoredProcedure [dbo].[sp_Get_UnitLookupByID]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[sp_Get_UnitLookupByID]
 @UnitLookupID int
As
Begin
Select  UnitLookupID,UnitName,IsActive,CreatedDate,
UpdatedDate,CreatedBy,UpdatedBy 
from UnitLookup where  UnitLookupID= @UnitLookupID


END





GO
/****** Object:  StoredProcedure [dbo].[Sp_GetAll_Master]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_GetAll_Master]  
As  
Begin  
Select MasterID,Name,ModuleUrl,IsActive,Position  from  Master  order by position asc
End  
  
GO
/****** Object:  StoredProcedure [dbo].[sp_GetRepairs]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetRepairs]
@DisplayLength int,
@DisplayStart int,
@SortCol int,
@SortDir nvarchar(10),
@search nvarchar (255)=NULL
as
begin
Declare @FirstRec int, @LastRec int
Set @FirstRec=@DisplayStart;
Set @LastRec=@DisplayStart+@DisplayLength;

with CTE_RepairMasters as
(
Select ROW_NUMBER() over (order by
case when (@SortCol=0 and @SortDir ='asc')
then RID
end asc,
case when (@SortCol =0 and @SortDir='desc')
then RID
end desc,
case when (@SortCol=1 and @SortDir ='asc')
then RDATE
end asc,
case when (@SortCol =1 and @SortDir='desc')
then RDATE
end desc,
case when (@SortCol=2 and @SortDir ='asc')
then EQ_ID
end asc,
case when (@SortCol =2 and @SortDir='desc')
then EQ_ID
end desc,
case when (@SortCol=3 and @SortDir ='asc')
then DEPT
end asc,
case when (@SortCol =3 and @SortDir='desc')
then DEPT
end desc,
case when (@SortCol=4 and @SortDir ='asc')
then REPAIR_MAINT
end asc,
case when (@SortCol =4 and @SortDir='desc')
then REPAIR_MAINT
end desc,
case when (@SortCol=5 and @SortDir ='asc')
then ACTION_TAKEN
end asc,
case when (@SortCol =5 and @SortDir='desc')
then ACTION_TAKEN
end desc,
case when (@SortCol=6 and @SortDir ='asc')
then SPARES
end asc,
case when (@SortCol =6 and @SortDir='desc')
then SPARES
end desc,
case when (@SortCol=7 and @SortDir ='asc')
then ATT_BY
end asc,
case when (@SortCol =7 and @SortDir='desc')
then ATT_BY
end desc,
case when (@SortCol=8 and @SortDir ='asc')
then STATUS
end asc,
case when (@SortCol =8 and @SortDir='desc')
then STATUS
end desc,
case when (@SortCol=9 and @SortDir ='asc')
then RNO
end asc,
case when (@SortCol =9 and @SortDir='desc')
then RNO
end desc
)
as RowNum,
COUNT (*) over ()as TotalCount,
RID,
Rdate,
EQ_ID,
DEPT,
REPAIR_MAINT,
ACTION_TAKEN,
SPARES,
ATT_BY,
STATUS,
RNO
from RepairMasters
where (@search is NULL
or RID like '%' +@search+'%'
or Rdate like '%' +@search+'%'
or EQ_ID like '%' +@search+'%'
or DEPT like '%' +@search+'%'
or REPAIR_MAINT like '%' +@search+'%'
or ACTION_TAKEN like '%' +@search+'%'
or SPARES like '%' +@search+'%'
or STATUS like '%' +@search+'%'
or RNO like '%' +@search+'%')

)
Select *
from CTE_RepairMasters
where RowNum > @FirstRec and RowNum <= @LastRec

end



GO
/****** Object:  StoredProcedure [dbo].[Sp_GetStudent]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_GetStudent]
As
Begin
Select StudentID,Name,RollNo,Class,Section,FathersName,MothersName,DOB,Email,MobileNo,Address From Student
End
GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_AppUser]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Insert_AppUser]

 @FirstName nvarchar(255),
 @LastName nvarchar(255),
 @Address nvarchar(500),
 @Designation nvarchar(255),
 @UserID nvarchar(255),
 @Password nvarchar(255),
 @IsActive bit,
 @CreatedDate date, 
 @UpdatedDate date 
 
As
Begin
insert into AppUser (FirstName,LastName,Address,Designation,UserID,Password,IsActive,
 CreatedDate,UpdatedDate) values (@FirstName,@LastName,@Address,@Designation,@UserID,@Password,
 @IsActive,@CreatedDate,@UpdatedDate)


END



GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_Category]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Insert_Category]

@CategoryName varchar(255),
@IsActive bit,
@CreatedDate date,
@UpdateDate date,
@CreatedBy int,
@UpdatedBy int

As
Begin
insert into CategoryLookup (CategoryName,CreatedDate,CreatedBy,UpdateDate,UpdatedBy,IsActive) 
values (@CategoryName,@CreatedDate,@CreatedBy,@UpdateDate,@UpdatedBy,@IsActive)

SELECT SCOPE_IDENTITY()

end



GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_DocumentsByParamID]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Insert_DocumentsByParamID]  
@DocumentTypeID int,  
@DocumentName varchar(255),  
@Location varchar(255),  
@ModuleTypeID int,  
@ModuleParamID int,  
@CreatedDate date,  
@UpdatedDate date  
  
As  
Begin  
Insert into Documents  
(DocumentTypeID,DocumentName,Location,ModuleTypeID,ModuleParamID,CreatedDate,UpdatedDate)  
values  
(@DocumentTypeID,@DocumentName,@Location,@ModuleTypeID,@ModuleParamID,@CreatedDate,@UpdatedDate)  
  
SELECT SCOPE_IDENTITY()  
  
End



GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_EquipmentNamelookup]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Sp_Insert_EquipmentNamelookup]
@EquipmentName varchar(255),
@IsActive Bit,
@CreatedDate date,
@UpdatedDate date,
@CreatedBy int,
@UpdatedBy int
As
Begin
Insert into EquipmentNamelookUp
(EquipmentName, IsActive, CreatedDate, UpdatedDate, CreatedBy, Updatedby)
Values
(@EquipmentName,@IsActive,@CreatedDate,@UpdatedDate,@CreatedBy,@UpdatedBy)

SELECT SCOPE_IDENTITY()


End




GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_Equipments]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Insert_Equipments]
@EquipmentID varchar(255),
@EquipNameID int,
@EquipModelID int,
@CategoryID int,
@SubCategoryID int,
@MaintPeriodicityID int,
@UnitLookupID int,
@Specifications varchar(255),
@DepartmentID int,
@BillDate date,
@DateOfInstallation date,
@CostOfEquipment decimal(18,2),
@SupplierID int,
@StatusID int,
@IsActive bit,
@Remarks nvarchar(max),
@UpdatedDate date,
@BillDetail varchar(500),
@BudgetYearID int

As
Begin
Insert into Equipments
(EquipmentID,EquipNameID,EquipModelID,CategoryID,SubCategoryID,MaintPeriodicityID,UnitLookupID,Specifications,DepartmentID,BillDate,DateOfInstallation,
CostOfEquipment,SupplierID,StatusID,IsActive,Remarks,UpdatedDate,BillDetail,BudgetYearID)
Values
(@EquipmentID,@EquipNameID,@EquipModelID,@CategoryID,@SubCategoryID,@MaintPeriodicityID,@UnitLookupID,@Specifications,@DepartmentID,@BillDate,@DateOfInstallation,
@CostOfEquipment,@SupplierID,@StatusID,@IsActive,@Remarks,@UpdatedDate,@BillDetail,@BudgetYearID)

SELECT SCOPE_IDENTITY()

End

GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_Maintenance]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Insert_Maintenance]
 
 @Periodicity nvarchar(50),
 @IsActive bit,
 @CreatedDate date,
 @CreatedBy int,
 @UpdatedDate date,
 @UpdatedBy int

 As
Begin

Insert into MaintenancePeriodLookup(Periodicity,IsActive,CreatedDate,UpdatedDate,CreatedBy,
UpdatedBy) values (@Periodicity,@IsActive,@CreatedDate,@UpdatedDate,@CreatedBy,@UpdatedBy)

end



GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_Master]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Insert_Master]
@Name varchar(255),
@ModuleUrl nvarchar(max),
@IsActive bit,
@Position int
As
Begin
Insert into Master
(Name,ModuleUrl,IsActive,Position)
Values
(@Name,@ModuleUrl,@IsActive,@Position)

SELECT SCOPE_IDENTITY()


End
GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_Register_RepairMaster]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Insert_Register_RepairMaster]
@RDATE datetime,
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
Insert into RepairMaster
(RDATE,EQ_ID,DEPT,REPAIR_MAINT,ACTION_TAKEN,SPARES,ATT_BY,STATUS,RNO)
Values
(@RDATE,@EQ_ID,@DEPT,@REPAIR_MAINT,@ACTION_TAKEN,@SPARES,@ATT_BY,@STATUS,@RNO)

End



GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_status]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Insert_status] 

 @EquipmentStatus nchar(50),
 @IsActive bit,
 @CreatedDate date,
 @UpdatedDate date,
 @CreatedBy int, 
 @UpdatedBy int
As
Begin
insert into StatusLookup (EquipmentStatus,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy) 
values (@EquipmentStatus,@IsActive,@CreatedDate,@UpdatedDate,@CreatedBy,@UpdatedBy)


END



GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_SubCategoryLookup]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Insert_SubCategoryLookup]

 @SubCategoryName nchar(50),
 @IsActive bit,
 @CreatedDate date,
 @UpdatedDate date,
 @CreatedBy int, 
 @UpdatedBy int
As
Begin
insert into SubCategoryLookup (SubCategoryName,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy) 
values (@SubCategoryName,@IsActive,@CreatedDate,@UpdatedDate,@CreatedBy,@UpdatedBy)


END



GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_SubMaster]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Insert_SubMaster]



@Name varchar(255),



@MasterId int,



@IsActive bit,



@CreatedDate date,



@UpdatedDate date,



@CreatedBy int,



@UpdatedBy int



As



Begin



 IF(@MasterId=1)



  Begin



   Insert into EquipmentNamelookUp

   (EquipmentName,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy)

   Values

   (@Name,@IsActive,@CreatedDate,@UpdatedDate,@CreatedBy,@UpdatedBy)



  End



  IF(@MasterId=2)



  Begin



   Insert into Status

   (EquipmentSatus,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy)

   Values

   (@Name,@IsActive,@CreatedDate,@UpdatedDate,@CreatedBy,@UpdatedBy)



  End



  IF(@MasterId=3)



  Begin



   Insert into Category

   (CategoryName,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy)

   Values

   (@Name,@IsActive,@CreatedDate,@UpdatedDate,@CreatedBy,@UpdatedBy)



  End



  IF(@MasterId=4)



  Begin



   Insert into SubCategory

   (SubCategoryName,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy)

   Values

   (@Name,@IsActive,@CreatedDate,@UpdatedDate,@CreatedBy,@UpdatedBy)


  End



  IF(@MasterId=5)



  Begin

 Insert into Department

   (DepartmentName,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy)

   Values

   (@Name,@IsActive,@CreatedDate,@UpdatedDate,@CreatedBy,@UpdatedBy)



  End



  IF(@MasterId=6)



  Begin



   Insert into MaintenancePeriodLookup

   (Periodicity,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy)

   Values

   (@Name,@IsActive,@CreatedDate,@UpdatedDate,@CreatedBy,@UpdatedBy)





  End



  IF(@MasterId=7)



  Begin



   select 'Equipment'



  End



  IF(@MasterId=8)



  Begin



   select 'Equipment'



  End



End

GO
/****** Object:  StoredProcedure [dbo].[sp_Insert_UnitLookup]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Insert_UnitLookup]
 @UnitName varchar(50),
 @IsActive bit,
 @CreatedDate date,
 @UpdatedDate date,
 @CreatedBy int, 
 @UpdatedBy int
As
Begin
insert into UnitLookup (UnitName,IsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy) 
values (@UnitName,@IsActive,@CreatedDate,@UpdatedDate,@CreatedBy,@UpdatedBy)


END



GO
/****** Object:  StoredProcedure [dbo].[Sp_InsertStudent]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_InsertStudent]
	@Name varchar(255),
	@RollNo varchar(255),
	@Class varchar(255),
	@Section varchar(255),
	@FathersName varchar(255),
	@MothersName varchar(255),
	@DOB varchar(255),
	@Email varchar(255),
	@MobileNo varchar(255),
	@Address varchar(255)
As
Begin

Insert into Student(Name,RollNo,Class,Section,FathersName,MothersName,DOB,Email,MobileNo,Address) Values 
(@Name,@RollNo,@Class,@Section,@FathersName,@MothersName,@DOB,@Email,@MobileNo,@Address)

SELECT SCOPE_IDENTITY()

End

GO
/****** Object:  StoredProcedure [dbo].[Sp_StatusUpdate_Equipments]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_StatusUpdate_Equipments]
@ID int,
@IsActive bit,
@IsPermanentDelete bit
As
Update Equipments	
Set IsActive=@IsActive
Where ID=@ID if @IsPermanentDelete=1

Begin
Delete from Equipments Where ID=@ID
End

GO
/****** Object:  StoredProcedure [dbo].[Sp_StatusUpdate_Master]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_StatusUpdate_Master]
@MasterID int,
@IsActive bit,
@IsPermanentDelete bit
As
Update Master
Set IsActive=@IsActive
Where MasterID=@MasterID if @IsPermanentDelete=1

Begin
Delete from Master Where MasterID=@MasterID
End

GO
/****** Object:  StoredProcedure [dbo].[sp_Update_AppUser]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Update_AppUser]
 @AppUserID int,
 @FirstName nvarchar(255),
 @LastName nvarchar(255),
 @Address nvarchar(500),
 @Designation nvarchar(255),
 @UserID nvarchar(255),
 @Password nvarchar(255),
 @IsActive bit,
 @CreatedDate date, 
 @UpdatedDate date 
 
As
Begin
Update  AppUser set FirstName=@FirstName,LastName=@LastName,Address=@Address,Designation=@Designation,
UserID=@UserID,Password=@Password,IsActive=@IsActive,CreatedDate=@CreatedDate,UpdatedDate=@UpdatedDate 
Where AppUserID=@AppUserID


END



GO
/****** Object:  StoredProcedure [dbo].[sp_Update_Category]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_Update_Category]
@CategoryID int,
@CategoryName varchar(255),
@IsActive bit,
@CreatedDate date,
@UpdateDate date,
@CreatedBy int,
@UpdatedBy int

As
Begin
Update CategoryLookup set CategoryName=@CategoryName,CreatedDate=@CreatedDate,CreatedBy=@CreatedBy,
UpdateDate=@UpdateDate,UpdatedBy=@UpdatedBy ,IsActive=@IsActive 
Where CategoryID= @CategoryID

end



GO
/****** Object:  StoredProcedure [dbo].[Sp_update_EquipmentNameLookup]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_update_EquipmentNameLookup]
@EquipNameID int,
@EquipmentName varchar(255),
@IsActive Bit,
@CreatedDate date,
@UpdatedDate date,
@CreatedBy int,
@UpdatedBy int

As

Begin
Update EquipmentNameLookup
set EquipmentName=@EquipmentName,IsActive=@IsActive,CreatedDate=@CreatedDate,UpdatedDate=@UpdatedDate,CreatedBy=@CreatedBy,UpdatedBy=@UpdatedBy
Where EquipNameID=@EquipNameID
End



GO
/****** Object:  StoredProcedure [dbo].[Sp_Update_Equipments]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[Sp_Update_Equipments]
@ID int,
@EquipmentID varchar(255),
@EquipNameID int,
@EquipModelID int,
@CategoryID int,
@SubCategoryID int,
@MaintPeriodicityID int,
@UnitLookupID int,
@Specifications varchar(255),
@DepartmentID int,
@BillDate Date,
@DateOfInstallation Date,
@CostOfEquipment decimal(18,2),
@SupplierID int,
@StatusID int,
@IsActive bit,
@Remarks nvarchar(255),
@UpdatedDate date,
@BillDetail varchar(500),
@BudgetYearID int
As
Begin
--update Equipments
Update Equipments
Set EquipmentID=@EquipmentID,EquipNameID=@EquipNameID,EquipModelID=@EquipModelID,CategoryID=@CategoryID,SubCategoryID=@SubCategoryID,MaintPeriodicityID=@MaintPeriodicityID,
UnitLookupID=@UnitLookupID,Specifications=@Specifications,DepartmentID=@DepartmentID,BillDate=@BillDate,DateOfInstallation=@DateOfInstallation,CostOfEquipment=@CostOfEquipment,
SupplierID=@SupplierID,StatusID=@StatusID,IsActive=@IsActive,Remarks=@Remarks,UpdatedDate=@UpdatedDate,BillDetail=@BillDetail,BudgetYearID=@BudgetYearID

--Select Equipments

Select * from Equipments where ID=@ID

End
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_Maintenance]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Update_Maintenance]
 
 @MaintPerodicityID int,
 @Periodicity nvarchar(50),
 @IsActive bit,
 @CreatedDate date,
 @CreatedBy int,
 @UpdatedDate date,
 @UpdatedBy int

 As
Begin

Update MaintenancePeriodLookup Set Periodicity=@Periodicity,IsActive= @IsActive,CreatedDate=@CreatedDate,
UpdatedDate=@UpdatedDate,CreatedBy=@CreatedBy,UpdatedBy=@UpdatedBy
Where MaintPerodicityID=@MaintPerodicityID
end



GO
/****** Object:  StoredProcedure [dbo].[Sp_Update_Master]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Update_Master]
@MasterID int,
@Name varchar(255),
@ModuleUrl nvarchar(max),
@IsActive bit,
@Position int
As
Begin
Update Master
Set Name=@Name,ModuleUrl=@ModuleUrl,IsActive=@IsActive,Position=@Position
where MasterID=@MasterID
End
GO
/****** Object:  StoredProcedure [dbo].[Sp_update_RepairMaster]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_update_RepairMaster]
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
Set RDATE=@RDATE,EQ_ID=@EQ_ID,DEPT=@DEPT,REPAIR_MAINT=@REPAIR_MAINT,ACTION_TAKEN=@ACTION_TAKEN,SPARES=@SPARES,ATT_BY=@ATT_BY,STATUS=@STATUS,RNO=@RNO
where RID=@RID
End
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_status]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Update_status] 

@StatusID int,
@EquipmentStatus nchar(50),
 @IsActive bit,
 @CreatedDate date,
 @UpdatedDate date,
 @CreatedBy int, 
 @UpdatedBy int
 
As
Begin
Update  StatusLookup Set EquipmentStatus=@EquipmentStatus,IsActive=@IsActive,CreatedDate=@CreatedDate,
UpdatedDate=@UpdatedDate,CreatedBy=@CreatedBy,UpdatedBy=@UpdatedBy 
Where StatusID=@StatusID


END



GO
/****** Object:  StoredProcedure [dbo].[sp_Update_SubCategoryLookup]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Update_SubCategoryLookup]

 @SubCategoryID int,
 @SubCategoryName nchar(50),
 @IsActive bit,
 @CreatedDate date,
 @UpdatedDate date,
 @CreatedBy int, 
 @UpdatedBy int
 
As
Begin
Update  SubCategoryLookup Set SubCategoryName=@SubCategoryName,IsActive=@IsActive,CreatedDate=@CreatedDate,
UpdatedDate=@UpdatedDate,CreatedBy=@CreatedBy,UpdatedBy=@UpdatedBy 
Where SubCategoryID=@SubCategoryID


END



GO
/****** Object:  StoredProcedure [dbo].[sp_Update_UnitLookup]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_Update_UnitLookup]

 @UnitLookupID int,
 @UnitName nchar(50),
 @IsActive bit,
 @CreatedDate date,
 @UpdatedDate date,
 @CreatedBy int, 
 @UpdatedBy int
 
As
Begin
Update  UnitLookup Set UnitName=@UnitName,IsActive=@IsActive,CreatedDate=@CreatedDate,
UpdatedDate=@UpdatedDate,CreatedBy=@CreatedBy,UpdatedBy=@UpdatedBy 
Where UnitLookupID=@UnitLookupID


END



GO
/****** Object:  StoredProcedure [dbo].[Sp_UpdateStudent]    Script Date: 2/13/2022 1:50:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_UpdateStudent]
@StudentID Int,
@Name varchar(255),
@RollNo varchar(255),
@Class varchar(255),
@Section varchar(255),
@FathersName varchar(255),
@MothersName varchar(255),
@DOB varchar(255),
@Email varchar(255),
@MobileNo varchar(255),
@Address varchar(255)
As
Begin
--Update Student
Update Student Set DOB=@DOB,Name=@Name,RollNo=@RollNo,Class=@Class,Section=@Section,FathersName=@FathersName,
MothersName=@MothersName,Email=@Email,MobileNo=@MobileNo,Address=@Address Where StudentID=@StudentID
--Select Student
Select * from Student where StudentID=@StudentID
End


GO
