using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySociety.Common.Model
{   
    public class User
    { 
        public long UserID { get; set; }
        public int RoleID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ConactNumber { get; set; }
        public string AlternateContactNumber { get; set; }
        public string WhatsAppNumber { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public int FlatNumberID { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
