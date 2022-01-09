using ImaginaryTaxCalculator.Service.ImaginaryRules;
using ImaginaryTaxCalculator.Service.Models;
using System.Collections.Generic;

namespace ImaginaryTaxCalculator.Service
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly ITaxCalculationRules _taxCalculationRules;

        public TaxCalculator(ITaxCalculationRules taxCalculationRules)
        {
            _taxCalculationRules = taxCalculationRules;
        }

        public Taxes Calculate(TaxPayer taxPayer)
        {
            var taxes = new Taxes()
            {
                GrossIncome = taxPayer.GrossIncome,
                CharitySpent = taxPayer.CharitySpent ?? decimal.Zero,
            };

            foreach (var rule in _taxCalculationRules.Rules)
            {
                if (rule.IsApplicable(taxes))
                {
                    rule.Apply(taxes);
                }
            }

            return taxes;
        }
    }
}
