using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Equipment.Get.Core.Helpers.Out
{
  public  class EquipmentNamelookup

    {
        public int EquipNameID { get; set; }
        public string EquipmentName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime updatedtime { get; set; }
        public int CreatedBy { get; set; }
        public int Updatedby { get; set; }

    }
}
