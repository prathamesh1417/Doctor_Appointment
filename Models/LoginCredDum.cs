using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class LoginCredDum
    {
        [Key]
        public int LoginId { get; set; }

        [Column("Username", TypeName = "varchar(100)")]
        public string Username { get; set; }


        [Column("Email", TypeName = "varchar(100)")]
        public String Email { get; set; }



        [Column("Password", TypeName = "varchar(100)")]
        public string Password { get; set; }


        [Column("Confirm Password", TypeName = "varchar(100)")]
        public String CPassword { get; set; }

        public IFormFile Image { get; set; }
    }
}
