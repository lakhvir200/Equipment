using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Equipment.Command.Core
{
  public class RepairMaster
    {
        public int RID { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RDATE { get; set; }
        public string EQ_ID { get; set; }
        public string Specifications { get; set; }
        public string REPAIR_MAINT { get; set; }
        public string ACTION_TAKEN { get; set; }
        public string Used { get; set; }
        public string ATT_BY { get; set; }
        public bool STATUS { get; set; }
        public int RNO { get; set; }
        public string SPARES { get; set; }
        public string DEPT { get; set; }
    }
}
