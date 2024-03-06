using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("u_ID")]
        public string Id { get; set; }
        [Column("u_Name")]
        public string Name { get; set; }
        [Column("u_Type")]
        public string Type { get; set; }
        [Column("u_Password")]
        public string? Password { get; set; }
    }
}
