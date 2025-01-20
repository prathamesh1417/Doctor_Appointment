using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace WebApplication7.Models
{
    public class doct
    {
        [Key]
        public int did { get; set; }

        [Column("Doctor_Username", TypeName = "varchar(100)")]
        public string dname { get; set; }

        [Column("Doctor_Email", TypeName = "varchar(100)")]
        public string demail { get; set; }

        [Column("Doctor_Pass", TypeName = "varchar(100)")]
        public string dpass { get; set; }

        [Column("Doctor_CPASS", TypeName = "varchar(100)")]
        public string dcpass { get; set; }

        [Column("Doctor_Certificate", TypeName = "varchar(100)")]
        public string CertificateID { get; set; }

        [ForeignKey("aid")]
        public int aid { get; set; }
        public ICollection<Booki> book { get; set; }
        public string Certi { get; set; }

        // This property is not mapped to the database.
        [NotMapped]
        public IFormFile Cert { get; set; }

        // Optional: Add related navigation property.
       
    }
}
