using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Orders")]

    public class OrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("o_ID")]
        public string OId { get; set; } = null!;
        [Column("c_ID")]
        public string CId { get; set; } = null!;
        [Column("o_Date")]
        public DateTime Date { get; set; }
        [Column("o_Sum")]
        public double Sum { get; set; }
        [Column("e_ID")]
        public string EId { get; set; } = null!;
        [Column("o_SendMode")]
        public string SendMode { get; set; } = null!;
        [Column("p_Id")]
        public string PId { get; set; } = null!;
        [Column("o_Status")]
        public bool Status { get; set; }
    }
}
