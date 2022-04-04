using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Equipment.Get.Core.Helpers.Out
{
    public class Master
    {
        public int MasterID { get; set; }
        public string Name { get; set; }
        public string ModuleUrl { get; set; }
        public bool IsActive { get; set; }
        public int Position { get; set; }
        public SubMaster subMaster { get; set; }
    }

    public class SubMaster
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime updatedtime { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public int MasterId { get; set; }
    }
}
