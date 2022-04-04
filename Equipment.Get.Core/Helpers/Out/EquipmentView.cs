using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Equipment.Get.Core.Helpers.Out
{
    public class EquipmentView
    {
        public string EquipmentID { get; set; }
        public string EquipmentCode { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string Periodicity { get; set; }
        public string Specifications { get; set; }
        public string DepartmentName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfPurchase { get; set; }
        public decimal CostOfEquipment { get; set; }
        public string SupplierName { get; set; }
        public string EquipmentStatus { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string EquipmentName { get; set; }

        public int EquipNameID { get; set; }
        public int EquipModelID { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public int MaintPeriodicityID { get; set; }
        public int UnitLookupID { get; set; }
        public int DepartmentID { get; set; }
        public int SupplierID { get; set; }
        public int StatusID { get; set; }
        public string BillDeatils { get; set; }
        public int BudgetYearId { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfInstallation { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BillDate { get; set; }
    }
}
