using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusBookingApp.bus;
public class Ratting
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int sno{get;set;}

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9_]{4,20}$", ErrorMessage = "Invalid username")]
    [StringLength(20, MinimumLength = 4, ErrorMessage = "Username must be between 4 and 20 characters")]
    public string? username{get;set;}

    public int rattings{get;set;}
    public string? command{get;set;}

    [Required(ErrorMessage = "Bus Name is required")]
    [StringLength(20, ErrorMessage = "Bus Name must be at most 50 characters")]
    public string? busname{get;set;}
}