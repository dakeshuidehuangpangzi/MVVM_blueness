using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Payments")]

    public class PaymentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("p_Id")]
        public string Id { get; set; }
        [Column("p_Mode")]
        public string Mode { get; set; }
        [Column("p_Remark")]
        public string? Remark { get; set; }
    }
}
