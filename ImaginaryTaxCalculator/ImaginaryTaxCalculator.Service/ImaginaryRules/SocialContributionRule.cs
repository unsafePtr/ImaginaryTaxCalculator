using ImaginaryTaxCalculator.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImaginaryTaxCalculator.Service.ImaginaryRules
{
    public class SocialContributionRule : IRule
    {
        internal const int MinGrossIncome = 1000;
        internal const int MaxChargableThreshold = 2000;
        internal const decimal SocialContributionRate = 0.15m;

        public void Apply(Taxes taxes)
        {
            decimal taxableSocialAmount = taxes.TaxableGrossIncome;

            if (taxes.TaxableGrossIncome > MaxChargableThreshold)
            {
                taxableSocialAmount = MaxChargableThreshold;
            }

            var socialContribution = taxableSocialAmount * SocialContributionRate;

            taxes.SocialTax = socialContribution;
        }

        public bool IsApplicable(Taxes taxes)
        {
            return MinGrossIncome < taxes.GrossIncome;
        }
    }
}
