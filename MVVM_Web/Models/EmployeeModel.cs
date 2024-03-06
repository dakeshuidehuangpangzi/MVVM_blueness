using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Employees")]

    public class EmployeeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("e_ID")]
        public string EId { get; set; } = null!;
        [Column("e_Name")]

        public string EName { get; set; } = null!;
        [Column("e_Gender")]

        public string EGender { get; set; } = null!;
        [Column("e_Birth")]

        public DateTime EBirth { get; set; }
        [Column("e_Address")]

        public string? EAddress { get; set; }
        [Column("e_Postcode")]

        public string? EPostcode { get; set; }
        [Column("e_Mobile")]

        public string? EMobile { get; set; }
        [Column("e_Phone")]

        public string EPhone { get; set; } = null!;
        [Column("e_E_mail")]

        public string EEMail { get; set; } = null!;
    }
}
