using AutoFixture;
using FluentAssertions;
using ImaginaryTaxCalculator.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImaginaryTaxCalculator.Tests
{
    [TestClass]
    public class TaxCalculatorShould
    {
        public Fixture _fixture;

        [TestInitialize]
        public void Init()
        {
            _fixture = new Fixture();
        }

        [TestMethod]
        [DataRow(980, 0, 0, 0, 0, 980)]
        [DataRow(3400, 0, 2400, 300, 240, 2860)]
        [DataRow(2500, 150, 1350, 202.5, 135, 2162.5)]
        [DataRow(3600, 520, 2240, 300, 224, 3076)]
        public void Apply(
            double grossIncome,
            double charitySpent,
            double expectedTaxableGrossIncome,
            double expectedSocialTax,
            double expectedIncomeTax,
            double expectedNetIncome)
        {
            var imaginaryRules = new ImaginaryTaxCalculationsRules();
            var taxCalculator = new TaxCalculator(imaginaryRules);

            var taxes = taxCalculator.Calculate(new Service.Models.TaxPayer()
            {
                GrossIncome = (decimal)grossIncome,
                CharitySpent = (decimal)charitySpent
            });

            taxes.TaxableGrossIncome.Should().Be((decimal)expectedTaxableGrossIncome);
            taxes.SocialTax.Should().Be((decimal)expectedSocialTax);
            taxes.IncomeTax.Should().Be((decimal)expectedIncomeTax);
            taxes.NetIncome.Should().Be((decimal)expectedNetIncome);
        }
    }
}
