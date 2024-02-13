using System;
using System.ComponentModel.DataAnnotations;

namespace BusBookingApp.Validation;

public class DateValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dateValue)
        {
            DateTime currentDate = DateTime.Today;
            
            if (dateValue >= currentDate)
            {
                return ValidationResult.Success;
            }
        }

        return new ValidationResult(ErrorMessage ?? "Date must be Today or Greater than Today.");
    }
    // private readonly string _pickupDate;

    // public DateValidationAttribute(string pickupDate)
    // {
    //     _pickupDate = pickupDate;
    // }

    // protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    // {
    //     var pickupDateProperty = validationContext.ObjectType.GetProperty(_pickupDate);
    //     var pickupDateValue = (DateTime)pickupDateProperty.GetValue(validationContext.ObjectInstance, null);

    //     if ((DateTime)value == pickupDateValue)
    //     {
    //         return ValidationResult.Success;
    //     }

    //     return new ValidationResult(ErrorMessage);
    // }
}