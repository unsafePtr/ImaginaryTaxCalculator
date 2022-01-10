using ImaginaryTaxCalculator.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ImaginaryTaxCalculator.Models
{
    public class TaxPayerRequest
    {
        [FullName]
        [Required]
        public string FullName { get; set; }
        [SsnValidation]
        [Required]
        public long SSN { get; set; }
        [NonNegativeDecimal]
        [Required]
        public decimal GrossIncome { get; set; }
        [NonNegativeDecimal]
        public decimal? CharitySpent { get; set; }
    }
}
