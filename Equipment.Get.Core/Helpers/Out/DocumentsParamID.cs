using System;
using System.Collections.Generic;
using System.Text;

namespace Equipment.Get.Core.Helpers.Out
{
   public class DocumentsParamID
    {
        public int DocumentID { get; set; }
        public int DocumentTypeID { get; set; }
        public string DocumentName { get; set; }
        public string Location { get; set; }
        public int ModuleTypeID { get; set; }
        public int ModuleParamID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Updatedtime { get; set; }
    }
}
