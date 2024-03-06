using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Types")]

    public class TypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("t_ID")] 
        public int Id { get; set; }
        [Column("t_Name")]
        public string Name { get; set; }
        [Column("t_Description")]
        public string? Description { get; set; }
    }
}
