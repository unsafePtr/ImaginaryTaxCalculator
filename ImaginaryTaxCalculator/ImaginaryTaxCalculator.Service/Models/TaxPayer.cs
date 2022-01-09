namespace ImaginaryTaxCalculator.Service.Models
{
    public class TaxPayer
    {
        public string FullName { get; set; }
        public int SSN { get; set; }
        public decimal GrossIncome { get; set; }
        public decimal? CharitySpent { get; set; }

        // we will use this as key for caching
        public override string ToString()
        {
            return $"{FullName}.{SSN}.{GrossIncome}.{CharitySpent}";
        }
    }
}
