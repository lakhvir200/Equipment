﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Equipment.Get.Core.Helpers.Out
{
    public class MaintenancePeriodLookup
    {
        
        public int MaintPerodicityID { get; set; }
        public string Periodicity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
