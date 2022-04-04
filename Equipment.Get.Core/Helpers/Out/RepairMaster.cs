using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Equipment.Get.Core.Helpers.Out
{
  public class RepairMaster
    {

        public int RID { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RDATE { get; set; }
        [Required]
        public string EQ_ID { get; set; }
        public int UnitLookupID { get; set; }
        public MasterLookup masterLookup { get; set; }

        public string Specifications { get; set; }
        [Required]
        public string REPAIR_MAINT { get; set; }
        [Required]
        public string ACTION_TAKEN { get; set; }
        
        public string Used { get; set; }
        [Required]
        public string ATT_BY { get; set; }
        [Required]
        public bool STATUS { get; set; }
        [Required]
        public int RNO { get; set; }
        [Required]
        public string SPARES { get; set; }
        [Required]   
        public string DEPT { get; set; }
        public string RDateEdit { get; set; }
        

    }
}
