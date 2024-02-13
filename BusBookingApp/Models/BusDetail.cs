using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusBookingApp.Validation;
namespace BusBookingApp.bus
{
    public class BusDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int serialNo { get; set;}

        [Required(ErrorMessage = "Bus Name is required")]
        [StringLength(20,MinimumLength = 5, ErrorMessage = "Bus Name must be at most 20 characters")]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "Bus Number is required")]
        [RegularExpression(@"^[A-Z]{2}-\d{2}-[A-Z]{1,2}-\d{4}$", ErrorMessage = "Invalid bus number")]
        public string? registrationNo { get; set; }

        // [Required(ErrorMessage = "Busfare is required")]
        // public int busfare { get; set; }

        // [Required(ErrorMessage = "Bus Type is required")]
        // public string? bustype { get; set;}

        [Required(ErrorMessage = "Source is required")]
        [RegularExpression( @"^[A-Z][a-zA-Z]*$",ErrorMessage = "Source name first letter should be Capital")]
        public string? source { get; set; }

        [Required(ErrorMessage = "Destination is required")]
        [RegularExpression( @"^[A-Z][a-zA-Z]*$",ErrorMessage = "Destination name first letter should be Capital")]
        public string? destination { get; set; }

        [Required(ErrorMessage = "Pickup date cannot be empty")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)] 
        // [DateValidation(ErrorMessage = "Date must be Today or Greater than Today")]
        public DateTime pickupDate{get;set;}
        
        [Required(ErrorMessage = "Pickuptime cannot be empty")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d$", ErrorMessage = "Invalid time format")]
        public string? pickuptime { get; set; }

        // [Required(ErrorMessage = "Drop date cannot be empty")]
        // [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        // [DateValidation("pickupDate",ErrorMessage = "Drop date must be same as Pickup date")]
        // public DateTime dropDate{get;set;}
        
        [Required(ErrorMessage = "Droptime cannot be empty")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d$", ErrorMessage = "Invalid time format")]
        public string? droptime { get; set; }

    }
}