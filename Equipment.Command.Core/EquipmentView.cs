using System;
using System.Collections.Generic;
using System.Text;

namespace Equipment.Command.Core
{
    public class EquipmentView
    {
        public int EquipmentID { get; set; }
        public string EquipmentCode { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string Periodicity { get; set; }
        public string Specifications { get; set; }
        public string DepartmentName { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public decimal CostOfEquipment { get; set; }
        public string SupplierName { get; set; }
        public string EquipmentStatus { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
