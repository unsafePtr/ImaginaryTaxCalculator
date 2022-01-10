using System;
using System.ComponentModel.DataAnnotations;

namespace ImaginaryTaxCalculator.ValidationAttributes
{
    public class NonNegativeDecimalAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (value == null)
                    return ValidationResult.Success;

                var val = (decimal)value;
                if (val < 0)
                    return new ValidationResult("Number should be non-negative");

                return ValidationResult.Success;
            }
            catch (Exception ex)
            {
                return new ValidationResult("Should be a valid decimal number");
            }
        }
    }
}
