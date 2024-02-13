using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusBookingApp.bus.Dto
{
    public class LoginDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int serialNo { get; set; }

        [Required (ErrorMessage ="This field is required")]
        [RegularExpression(@"^[A-Z\s]{1}[a-z\s]+$", ErrorMessage = "Invalid username")]
        public string? userName { get; set; }
        
        [Required (ErrorMessage ="This field is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string? password { get; set; }
    
    }
}