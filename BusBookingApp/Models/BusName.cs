using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class BusName
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int serialno {get;set;}

    [Required(ErrorMessage = "Bus Name is required")]
    [StringLength(20,MinimumLength = 5, ErrorMessage = "Bus Name must be at most 20 characters")]
    public string? busName { get; set; }
        
    [Required]
    [RegularExpression(@"^[A-Z]{2}-\d{2}-[A-Z]{1,2}-\d{4}$", ErrorMessage = "Invalid bus number")]
    public string? busNumber{get;set;}

    [Required(ErrorMessage = "Source is required")]
    [RegularExpression(@"^[A-Z][a-z]*&",ErrorMessage = "Source name first letter should be Capital")]
    public string? pickupplace{get;set;}

    [Required(ErrorMessage = "Destination is required")]
    [RegularExpression(@"^[A-Z][a-z]*&",ErrorMessage = "Destination name first letter should be Capital")]
    public string? dropplace{get;set;}

    [Required(ErrorMessage = "Pickuptime cannot be empty")]
    [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
    [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d$", ErrorMessage = "Invalid time format")]
    public string? pickuptime { get; set; }

    [Required(ErrorMessage = "Droptime cannot be empty")]
    [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
    [RegularExpression(@"^(?:[01]\d|2[0-3]):[0-5]\d$", ErrorMessage = "Invalid time format")]
    public string? droptime { get; set; }

    [Required(ErrorMessage = "Pickup date cannot be empty")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime pickupDate{get;set;}
    
    // [Required(ErrorMessage = "Drop date cannot be empty")]
    // [DataType(DataType.Date)]
    // [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    // [DateValidation("pickupDate",ErrorMessage = "Drop date must be greater than Pickup date")]
    // public DateTime dropDate{get;set;}
    public string? _1 {get;set;}
    public string? _2 {get;set;}
    public string? _3 {get;set;}
    public string? _4 {get;set;}
    public string? _5 {get;set;}
    public string? _6 {get;set;}
    public string? _7 {get;set;}
    public string? _8 {get;set;}
    public string? _9 {get;set;}
    public string? _10 {get;set;}
    public string? _11 {get;set;}
    public string? _12 {get;set;}
    public string? _13 {get;set;}
    public string? _14 {get;set;}
    public string? _15 {get;set;}
    public string? _16 {get;set;}
    public string? _17 {get;set;}
    public string? _18 {get;set;}
    public string? _19 {get;set;}
    public string? _20 {get;set;}
    public string? _21 {get;set;}
    public string? _22 {get;set;}
    public string? _23 {get;set;}
    public string? _24 {get;set;}
    public string? _25 {get;set;}
    public string? _26 {get;set;}
    public string? _27 {get;set;}
    public string? _28 {get;set;}
    public string? _29 {get;set;}
    public string? _30 {get;set;}
    public string? _31 {get;set;}
    public string? _32 {get;set;}
    public string? _33 {get;set;}
    public string? _34 {get;set;}
    public string? _35 {get;set;}
    public string? _36 {get;set;}
    public string? _37 {get;set;}
    public string? _38 {get;set;}
    public string? _39 {get;set;}
    public string? _40 {get;set;}
    public string? _41 {get;set;}
    public string? _42 {get;set;}
    public string? _43 {get;set;}
    public string? _44 {get;set;}
}