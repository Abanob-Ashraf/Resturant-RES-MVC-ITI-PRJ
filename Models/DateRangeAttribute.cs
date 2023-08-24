using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Resturant_RES_MVC_ITI_PRJ.Models
{
    public class DateRangeAttribute : ValidationAttribute
    {
        DateTime Minimum;
        DateTime Maximum;

        public DateRangeAttribute(string dateTime)
        {
            Minimum = DateTime.Parse(dateTime);
            Maximum = DateTime.Today.AddDays(15);
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue)
            {
                if (dateValue >= Minimum && dateValue <= Maximum)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    ErrorMessage = $"Min Value {Minimum.ToShortDateString()} and Max Value {Maximum.ToShortDateString()}";
                    return new ValidationResult(ErrorMessage);
                }
            }
            return new ValidationResult("The value must be a valid date.");
        }
    }
}
