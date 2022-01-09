namespace ImaginaryTaxCalculator.Service.Models
{
    public class Taxes
    {
        public decimal GrossIncome { get; set; }
        public decimal CharitySpent { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal SocialTax { get; set; }
        public decimal TaxableGrossIncome { get; set; }
        public decimal NetIncome { get; set; }
    }
}
