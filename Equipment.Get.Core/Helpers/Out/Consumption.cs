using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Equipment.Get.Core.Helpers.Out
{
   public class Consumption
    {
        public int ID { get; set; }

        public string DOC_NO { get; set; }
        public DateTime DOC_DT { get; set; }
        public string DOC_TP { get; set; }
        public string DRUG_SRNO { get; set; }
        public string DRUG_NM { get; set; }
        public decimal QTY { get; set; }
        public decimal TAX_RT { get; set; }
        public decimal TAX_AMT { get; set; }
        public string B_E_CD { get; set; }
        public string eqid { get; set; }
        public string SUPP { get; set; }
        public string SUPP_NAME { get; set; }        
    }
}
