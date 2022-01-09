using ImaginaryTaxCalculator.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImaginaryTaxCalculator.Service.ImaginaryRules
{
    public class SetTaxableGrossIncomeRule : IRule
    {
        internal const int Threshold = 1000;

        public void Apply(Taxes taxes)
        {
            taxes.TaxableGrossIncome = taxes.GrossIncome > Threshold
                ? taxes.GrossIncome - Threshold
                : 0;
        }

        public bool IsApplicable(Taxes taxes)
        {
            return true;
        }
    }
}
