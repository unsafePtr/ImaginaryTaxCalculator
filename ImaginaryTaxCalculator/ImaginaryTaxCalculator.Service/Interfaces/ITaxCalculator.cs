using ImaginaryTaxCalculator.Service.Models;

namespace ImaginaryTaxCalculator.Service
{
    public interface ITaxCalculator
    {
        Taxes Calculate(TaxPayer taxPayer);
    }
}