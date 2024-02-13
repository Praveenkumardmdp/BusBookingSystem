using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusBookingApi.Models
{
    public class Login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int serialNo { get; set; }

        [Required (ErrorMessage ="This field is required")]
        [RegularExpression(@"^[A-Z\s]{1}[a-z\s]+$", ErrorMessage = "Invalid username")]
        public string? userName { get; set; }

        [Required (ErrorMessage ="This field is required")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid phone number")]
        public string? phonenumber { get; set; }

        [Required (ErrorMessage ="This field is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [RegularExpression(@"^(?!\.)[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-z]{2,3}$")]
        public string? email { get; set; }
        
        [Required (ErrorMessage ="This field is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string? password { get; set; }
    
    }
}