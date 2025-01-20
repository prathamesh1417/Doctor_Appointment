using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication7.Models
{
    public class LoginCredential
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
       
        public String Image { get; set; }




        //public AppBooking AppBooking { get; set; }
    }
}
