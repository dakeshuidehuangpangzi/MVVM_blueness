using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Goods")]

    public class GoodModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("g_ID")]
        public string GId { get; set; } = null!;
        [Column("g_Name")]

        public string GName { get; set; } = null!;
        [Column("t_ID")]

        public int? TId { get; set; }
        [Column("g_Price")]

        public double GPrice { get; set; }
        [Column("g_Discount")]

        public double GDiscount { get; set; }
        [Column("g_Number")]

        public short GNumber { get; set; }
        [Column("g_ProduceDate")]

        public DateTime GProduceDate { get; set; }
        [Column("g_Image")]

        public string? GImage { get; set; }
        [Column("g_Status")]

        public string GStatus { get; set; } = null!;
        [Column("g_Description")]

        public string? GDescription { get; set; }
    }
}
