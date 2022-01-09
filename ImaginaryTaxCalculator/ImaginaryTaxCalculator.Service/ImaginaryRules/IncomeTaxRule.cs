using ImaginaryTaxCalculator.Service.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ImaginaryTaxCalculator.Tests")]

namespace ImaginaryTaxCalculator.Service.ImaginaryRules
{
    public class IncomeTaxRule : IRule
    {
        internal const int Threshold = 1000;
        internal const decimal IncomeTaxRate = 0.1m;

        public void Apply(Taxes taxes)
        {
            var incomeTax = taxes.GrossIncome > Threshold
                ? taxes.TaxableGrossIncome * IncomeTaxRate
                : 0;

            taxes.IncomeTax = incomeTax;
        }

        public bool IsApplicable(Taxes taxes)
        {
            return true;
        }
    }
}
