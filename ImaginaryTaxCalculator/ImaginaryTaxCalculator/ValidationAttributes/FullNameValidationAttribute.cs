using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ImaginaryTaxCalculator.ValidationAttributes
{
    public class FullNameAttribute : ValidationAttribute
    {
        private static Regex _fullnameRegex = new Regex(@"(?=^.{0,40}$)^[a-zA-Z-]+\s[a-zA-Z-]+$", RegexOptions.Compiled);

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var str = value as string;
            if (string.IsNullOrEmpty(str))
                return new ValidationResult($"Property can't be null or empty");

            if (!_fullnameRegex.IsMatch(str))
                return new ValidationResult($"Property should contain only letters and spaces");

            return ValidationResult.Success;
        }
    }
}
