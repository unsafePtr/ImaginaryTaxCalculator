using AutoFixture;
using FluentAssertions;
using ImaginaryTaxCalculator.Service.ImaginaryRules;
using ImaginaryTaxCalculator.Service.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImaginaryTaxCalculator.Tests
{
    [TestClass]
    public class IncomeTaxRuleShould
    {
        public Fixture _fixture;

        [TestInitialize]
        public void Init()
        {
            _fixture = new Fixture();
        }

        [TestMethod]
        [DataRow(3000, 300)]
        [DataRow(2000, 200)]
        [DataRow(1000, 0)]
        [DataRow(500, 0)]
        public void Apply(
            int taxableGrossIncome,
            int expectedIncomeTax)
        {
            var taxes = _fixture.Build<Taxes>()
                .OmitAutoProperties()
                .With(c => c.GrossIncome, taxableGrossIncome)
                .With(c => c.TaxableGrossIncome, taxableGrossIncome)
                .Create();

            var incomeTaxRule = new IncomeTaxRule();

            incomeTaxRule.Apply(taxes);

            taxes.IncomeTax.Should().Be(expectedIncomeTax);
        }

        [TestMethod]
        public void IsApplicable_Returns_Always_True()
        {
            var taxes = _fixture.Build<Taxes>()
                .Create();

            var incomeTaxRule = new IncomeTaxRule();

            incomeTaxRule.IsApplicable(taxes).Should().BeTrue();
        }
    }
}
