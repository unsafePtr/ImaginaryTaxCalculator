using System.Collections.Generic;

namespace ImaginaryTaxCalculator.Service
{
    public interface ITaxCalculationRules
    {
        IReadOnlyList<IRule> Rules { get; }
    }
}