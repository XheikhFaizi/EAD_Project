using System.ComponentModel.DataAnnotations;

namespace NET_QR.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(20)]
        public string name { get; set; }

        [Required(ErrorMessage = "Please Enter Username")]
        [StringLength(20)]
        public string username { get; set; }


        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string email { get; set; }


        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string pass { get; set; }


        [Compare("pass", ErrorMessage = "Confirm password doesn't match, Type again!")]
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string confpass { get; set; }
    }
}
