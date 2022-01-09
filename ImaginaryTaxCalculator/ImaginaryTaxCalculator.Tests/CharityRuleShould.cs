using AutoFixture;
using FluentAssertions;
using ImaginaryTaxCalculator.Service.ImaginaryRules;
using ImaginaryTaxCalculator.Service.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImaginaryTaxCalculator.Tests
{
    [TestClass]
    public class CharityRuleShould
    {
        public Fixture _fixture;

        [TestInitialize]
        public void Init()
        {
            _fixture = new Fixture();
        }

        [TestMethod]
        [DataRow(4000, 3000, 500, 2600)]
        [DataRow(4000, 3000, 300, 2700)]
        [DataRow(4000, 3000, 150, 2850)]
        [DataRow(4000, 3000, 0, 3000)]
        public void Apply(
            int grossIncome,
            int taxableGrossIncome,
            int charitySpent,
            int expectedTaxableGrossIncome)
        {
            var taxes = _fixture.Build<Taxes>()
                .OmitAutoProperties()
                .With(c => c.GrossIncome, grossIncome)
                .With(c => c.TaxableGrossIncome, taxableGrossIncome)
                .With(c => c.CharitySpent, charitySpent)
                .Create();

            var charityRule = new CharityRule();

            charityRule.Apply(taxes);

            taxes.TaxableGrossIncome.Should().Be(expectedTaxableGrossIncome);
        }

        [TestMethod]
        public void IsApplicable_Returns_True_When_Charity_Is_Spent()
        {
            var taxes = _fixture.Create<Taxes>();

            var charityRule = new CharityRule();

            charityRule.IsApplicable(taxes).Should().BeTrue();
        }

        [TestMethod]
        public void IsApplicable_Returns_False_When_Charity_Is_Spent()
        {
            var taxes = _fixture.Build<Taxes>()
                .With(c => c.CharitySpent, 0)
                .Create();

            var charityRule = new CharityRule();

            charityRule.IsApplicable(taxes).Should().BeFalse();
        }
    }
}
