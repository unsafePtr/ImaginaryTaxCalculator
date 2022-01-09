using AutoFixture;
using FluentAssertions;
using ImaginaryTaxCalculator.Service.ImaginaryRules;
using ImaginaryTaxCalculator.Service.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImaginaryTaxCalculator.Tests
{
    [TestClass]
    public class SetTaxableGrossIncomeRuleShould
    {
        public Fixture _fixture;

        [TestInitialize]
        public void Init()
        {
            _fixture = new Fixture();
        }

        [TestMethod]
        [DataRow(2000, 1000)]
        [DataRow(1000, 0)]
        [DataRow(500, 0)]
        public void Apply(
            int grossIncome,
            int expectedTaxableGrossIncome)
        {
            var taxes = _fixture.Build<Taxes>()
                .OmitAutoProperties()
                .With(c => c.GrossIncome, grossIncome)
                .Create();

            var taxableGrossIncomeRule = new SetTaxableGrossIncomeRule();

            taxableGrossIncomeRule.Apply(taxes);

            taxes.TaxableGrossIncome.Should().Be(expectedTaxableGrossIncome);
        }

        [TestMethod]
        public void IsApplicable_Always_Returns_True()
        {
            var taxes = _fixture.Build<Taxes>()
                .Create();

            var taxableGrossIncomeRule = new SetTaxableGrossIncomeRule();

            taxableGrossIncomeRule.IsApplicable(taxes).Should().BeTrue();
        }
    }
}
