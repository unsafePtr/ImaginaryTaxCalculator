using ImaginaryTaxCalculator.Service.Models;

namespace ImaginaryTaxCalculator.Service.ImaginaryRules
{
    public class NetIncomeRule : IRule
    {
        internal const int NontaxableAmount = 1000;

        public void Apply(Taxes taxes)
        {
            taxes.NetIncome = taxes.TaxableGrossIncome > 0
                ? taxes.GrossIncome - taxes.SocialTax - taxes.IncomeTax
                : taxes.GrossIncome;
        }

        public bool IsApplicable(Taxes taxes)
        {
            return true;
        }
    }
}
