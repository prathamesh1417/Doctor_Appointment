using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication7.Models
{
    public class Booki
    {
        [Key]
        public int aid { get; set; }

        [Column("Name", TypeName = "varchar(100)")]
        public string pname { get; set; }

        [Column("Patient_Address", TypeName = "varchar(100)")]
        public string padd { get; set; }

        [Column("Patient_mobileNo", TypeName = "varchar(100)")]
        public string pmob { get; set; }

        [Column("Patient_Aadhar", TypeName = "varchar(100)")]
        public string paadhar { get; set; }

        [Column("Patient_Message", TypeName = "varchar(100)")]
        public string pmsg { get; set; }

        [Column("Date", TypeName = "varchar(100)")]
        public string pdate { get; set; }

        [Column("Doctor_Name", TypeName = "varchar(100)")]
        public string DoctorName { get; set; }

        // Foreign key property
        [ForeignKey("did")]
        public int did { get; set; }

        // Navigation property
        public doct doc { get; set; }
    }
}