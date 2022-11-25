using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MySociety.DataAccessLayer.Model
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long userId { get; set; }
        public string username { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
}
