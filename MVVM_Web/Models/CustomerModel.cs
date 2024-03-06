using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Customers")]
    public class CustomerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("c_ID")]
        public string CId { get; set; } = null!;
        [Column("c_Name")]

        public string CName { get; set; } = null!;
        [Column("c_TrueName")]

        public string CTrueName { get; set; } = null!;
        [Column("c_Gender")]

        public string CGender { get; set; } = null!;
        [Column("c_Birth ")]

        public DateTime CBirth { get; set; }
        [Column("c_CardId")]

        public string CCardId { get; set; } = null!;
        [Column("c_Address")]

        public string? CAddress { get; set; }
        [Column("c_Postcode")]

        public string? CPostcode { get; set; }
        [Column("c_Mobile")]

        public string? CMobile { get; set; }
        [Column("c_Phone")]

        public string? CPhone { get; set; }
        [Column("c_E_mail")]

        public string? CEMail { get; set; }
        [Column("c_Password")]

        public string CPassword { get; set; } = null!;
        [Column("c_SafeCode")]

        public string CSafeCode { get; set; } = null!;
        [Column("c_Question")]

        public string CQuestion { get; set; } = null!;
        [Column("c_Answer")]

        public string CAnswer { get; set; } = null!;
        [Column("c_Type")]

        public string CType { get; set; } = null!;

    }
}
