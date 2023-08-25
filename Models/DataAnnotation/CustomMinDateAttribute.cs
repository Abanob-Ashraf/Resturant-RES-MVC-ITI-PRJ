using System.ComponentModel.DataAnnotations;

namespace Resturant_RES_MVC_ITI_PRJ.Models.DataAnnotation
{
    public class CustomMinDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime dateValue)
            {
                return dateValue >= DateTime.Today;
            }
            return false;
        }
    }
}
