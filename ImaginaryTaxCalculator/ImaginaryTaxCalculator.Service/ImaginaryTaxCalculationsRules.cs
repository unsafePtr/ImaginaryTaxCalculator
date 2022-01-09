using ImaginaryTaxCalculator.Service.ImaginaryRules;
using System.Collections.Generic;

namespace ImaginaryTaxCalculator.Service
{
    public class ImaginaryTaxCalculationsRules : ITaxCalculationRules
    {
        private static readonly IReadOnlyList<IRule> Rules = new List<IRule>()
        {
            // order does matter
            new SetTaxableGrossIncomeRule(),
            new CharityRule(),
            new SocialContributionRule(),
            new IncomeTaxRule(),
            new NetIncomeRule()
        }.AsReadOnly();

        IReadOnlyList<IRule> ITaxCalculationRules.Rules => Rules;
    }
}
