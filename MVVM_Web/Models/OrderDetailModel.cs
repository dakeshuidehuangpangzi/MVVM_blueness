using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("OrderDetails")]

    public class OrderDetailModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("d_ID")]
        public int DId { get; set; }
        [Column("o_ID")]

        public string OId { get; set; } = null!;
        [Column("g_ID")]

        public string GId { get; set; } = null!;
        [Column("d_Price")]

        public double DPrice { get; set; }
        [Column("d_Number")]

        public short DNumber { get; set; }
    }
}
