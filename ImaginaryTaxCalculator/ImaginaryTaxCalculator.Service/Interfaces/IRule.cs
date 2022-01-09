using ImaginaryTaxCalculator.Service.Models;

namespace ImaginaryTaxCalculator.Service
{
    public interface IRule
    {
        bool IsApplicable(Taxes taxes);
        void Apply(Taxes taxes);
    }
}
