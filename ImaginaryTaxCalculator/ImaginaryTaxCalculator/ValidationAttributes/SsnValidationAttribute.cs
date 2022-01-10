using System;
using System.ComponentModel.DataAnnotations;

namespace ImaginaryTaxCalculator.ValidationAttributes
{
    public class SsnValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var val = (long)value;

                // we can't verify uniqueness from here unless we turn it to the filter and check always in the storage

                var ssnLen = val.ToString().Length;
                if (ssnLen > 5 && ssnLen < 10)
                    return ValidationResult.Success;

                return new ValidationResult($"SSN should be with length from 5 to 10 digits. Current length: {ssnLen}");
            }
            catch (Exception ex)
            {
                return new ValidationResult("Should be unique number");
            }
        }
    }
}
