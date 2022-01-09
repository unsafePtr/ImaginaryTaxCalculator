using ImaginaryTaxCalculator.Service.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImaginaryTaxCalculator.Service
{
    public class TaxCalculatorCacheDecorator : ITaxCalculator
    {
        private static readonly ConcurrentDictionary<string, Taxes> _cache
            = new ConcurrentDictionary<string, Taxes>();

        private readonly ITaxCalculator _taxCalculator;

        public TaxCalculatorCacheDecorator(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public Taxes Calculate(TaxPayer taxPayer)
        {
            return _cache.GetOrAdd(taxPayer.ToString(), c => _taxCalculator.Calculate(taxPayer));
        }
    }
}
