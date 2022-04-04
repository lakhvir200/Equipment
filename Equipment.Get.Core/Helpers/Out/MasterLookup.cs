using System;
using System.Collections.Generic;
using System.Text;

namespace Equipment.Get.Core.Helpers.Out
{
    public class MasterLookup
    {

        public IEnumerable<ActionLookup> ActionLookup { get; set; }
        public IEnumerable<EquipNameLookup> EquipNameLookup { get; set; }
        public IEnumerable<CategoryLookup> CategoryLookup { get; set; }
        public IEnumerable<StatusLookup> StatusLookup { get; set; }
        public IEnumerable<MaintenancePeriodLookup> MaintenancePeriodLookup { get; set; }
        public IEnumerable<SubCategoryLookup> SubCategoryLookup { get; set; }
        public IEnumerable<BudgetLookup> BudgetLookup { get; set; }
        public IEnumerable<SupplierLookup> SupplierLookup { get; set; }
        public IEnumerable<DepartmentLookup> DepartmentLookup{ get; set; }
        public IEnumerable<HospitalLookup> HospitalLookup { get; set; }


    }

    public class EquipNameLookup
    {
        public int EquipNameID { get; set; }
        public string EquipmentName { get; set; }

    }

 public class HospitalLookup
    {
        public int HospitalID { get; set; }
        public string HospitalName { get; set; }
    }
    
    public class BudgetLookup
    {

        public int BudgetID { get; set; }
        public string BudgetName { get; set; }


    }
    
    

}
