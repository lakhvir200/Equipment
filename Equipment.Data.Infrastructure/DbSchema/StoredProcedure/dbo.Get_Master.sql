Create Proc Get_Master
@MasterID int
As
Begin
Select * From Master Where MasterID=@MasterID
End