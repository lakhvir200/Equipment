using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Equipment.Data.Infrastructure.Tables
{
   public class AppUser
    {
        [Key]
        public int AppUserID { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public string Address { get; set; }
        public int Designation { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }        
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
