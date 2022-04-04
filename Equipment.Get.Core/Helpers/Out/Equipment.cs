using System;
using System.ComponentModel.DataAnnotations;

namespace Equipment.Get.Core.Helpers.Out
{
    public class Equipments
    {
        public int ID { get; set; }

        [Display(Name = "Equipment Code")]
        [Required]
        public string EquipmentID { get; set; }        
        public string EquipmentCode { get; set; }        
        public string EquipmentName { get; set; }
        [Display(Name = "Category")]
        [Required]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Display(Name = "Sub Category")]
        [Required]
        public int SubCategoryID { get; set; }
        public string SubCategoryName { get; set; }
        [Display(Name = "Maint Periodicity")]
        public int MaintPeriodicityID { get; set; }
        public string MaintPerodicity { get; set; }
        [Display(Name = "Hospital")]
        [Required]
        public int UnitLookupID { get; set; }
        public string UnitName { get; set; }
        [Required]
        public string Specifications { get; set; }
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }
        public string Department { get; set; }       
        public string DateOfPurchase { get; set; }
        [Required]
        public decimal CostOfEquipment { get; set; }
        [Display(Name = "Supplier")]
        public int SupplierID { get; set; }
        public string Supplier { get; set; }
        [Display(Name = "Status")]
        public int StatusID { get; set; }
        public string Status { get; set; }
        [Required]
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int EquipNameID { get; set; }
        public int EquipModelID { get; set; }
        [Required]       

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BillDate { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfInstallation { get; set; }
        [Display(Name = "Budget Year")]
        public int BudgetYearId { get; set; }
        [Required]
        public string BillDeatils { get; set; }
        public MasterLookup masterLookup { get; set; }

        public string BillDateEdit { get; set; }
        public string DateOfInstallationEdit { get; set; }
    }
   
}
