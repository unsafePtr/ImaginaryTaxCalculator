using ImaginaryTaxCalculator.Filters;
using ImaginaryTaxCalculator.Models;
using ImaginaryTaxCalculator.Service;
using ImaginaryTaxCalculator.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImaginaryTaxCalculator.Controllers
{
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ILogger<CalculateController> _logger;
        private readonly ITaxCalculator _taxCalculator;

        public CalculateController(ILogger<CalculateController> logger, ITaxCalculator taxCalculator)
        {
            _logger = logger;
            _taxCalculator = taxCalculator;
        }

        [HttpPost]
        [Route("calculate")]
        [ServiceFilter(typeof(ValidateModelAttribute))]
        public ActionResult Get(
            [FromBody] TaxPayerRequest taxPayerRequest)
        {
            var taxPayer = new TaxPayer
            {
                CharitySpent = taxPayerRequest.CharitySpent,
                FullName = taxPayerRequest.FullName,
                GrossIncome = taxPayerRequest.GrossIncome,
                SSN = taxPayerRequest.SSN
            };

            var taxes = _taxCalculator.Calculate(taxPayer);

            return Ok(taxes);
        }
    }
}
