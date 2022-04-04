using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Equipment.Admin.MVC.UI.Models
{
    public class EquipmentViewModel
    {

        public int EquipmentID { get; set; }
        public string EquipmentCode { get; set; }
        public string Category { get; set; }

        public string CategoryID { get; set; }
        public int SubCategoryID { get; set; }

        public int MaintPerodicityID { get; set; }
        public int UnitLookupID { get; set; }
        public string Specifications { get; set; }
        public int DepartmentID { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public decimal CostOfEquipment { get; set; }
        public int SupplierID { get; set; }
        public int StatusID { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
    
}

