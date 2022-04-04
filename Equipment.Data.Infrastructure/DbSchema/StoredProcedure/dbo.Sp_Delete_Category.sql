create proc Sp_Delete_Category
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