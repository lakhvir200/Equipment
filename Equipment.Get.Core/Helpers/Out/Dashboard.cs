using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Equipment.Get.Core.Helpers.Out
{
   public class Dashboard
    {
        public int TotalEquipment { get; set; }
        public int TotalRepair{ get; set; }
        public int TotalPurchase { get; set; }
        public int TotalMaintenance { get; set; }
        public IEnumerable<Equipments> Equipments { get; set; }
        public IEnumerable<RepairMaster> RepairOrders { get; set; }

    }
}
