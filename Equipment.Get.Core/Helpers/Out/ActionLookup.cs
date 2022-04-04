using System;
using System.Collections.Generic;
using System.Text;

namespace Equipment.Get.Core.Helpers.Out
{
    public class ActionLookup
    {
        public int ActionID { get; set; }
        public string ActionName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
