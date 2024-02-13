using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusBookingApi.Models;
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int sno { get; set; }
    
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9_]", ErrorMessage = "Invalid username")]
    [StringLength(20, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 20 characters")]
    public string? userName { get; set; }

    [Required(ErrorMessage = "Bus Name is required")]
    [StringLength(20, ErrorMessage = "Bus Name must be at most 20 characters")]
    public string? busname { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]{2}-\d{2}-[A-Z]{1,2}-\d{4}$", ErrorMessage = "Invalid bus number")]
    public string? registrationno { get; set; }
    public string? seatno { get; set; }

    [Required(ErrorMessage = "Source is required")]
    [RegularExpression(@"^[A-Z]{1}[a-z]*&",ErrorMessage = "Source name first letter should be Capital")]
    public string? source { get; set; }

    [Required(ErrorMessage = "Destination is required")]
    [RegularExpression(@"^[A-Z]{1}[a-z]*&",ErrorMessage = "Destination name first letter should be Capital")]
    public string? destination { get; set; }

    [Required(ErrorMessage = "Pickup date cannot be empty")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)] 
    public DateTime pickupDate{get;set;}

    [Required(ErrorMessage = "Pickuptime cannot be empty")]
    [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
    [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d$", ErrorMessage = "Invalid time format")]
    public string? pickuptime { get; set; }

    [Required(ErrorMessage = "Droptime cannot be empty")]
    [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
    [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d$", ErrorMessage = "Invalid time format")]
    public string? droptime { get; set; }
}


