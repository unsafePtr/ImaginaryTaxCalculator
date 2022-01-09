using ImaginaryTaxCalculator.Service.Models;

namespace ImaginaryTaxCalculator.Service.ImaginaryRules
{
    public class CharityRule : IRule
    {
        internal const decimal CharityRateToGrossIncomeMaxRatio = 0.1m;

        public void Apply(Taxes taxes)
        {
            var charityRatio = taxes.CharitySpent / taxes.GrossIncome;
            charityRatio = charityRatio > CharityRateToGrossIncomeMaxRatio
                ? CharityRateToGrossIncomeMaxRatio
                : charityRatio;

            taxes.TaxableGrossIncome = taxes.TaxableGrossIncome - (charityRatio * taxes.GrossIncome);
        }

        public bool IsApplicable(Taxes taxes)
        {
            return taxes.CharitySpent > 0;
        }
    }
}
