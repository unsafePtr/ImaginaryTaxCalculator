using AutoFixture;
using FluentAssertions;
using ImaginaryTaxCalculator.Service.ImaginaryRules;
using ImaginaryTaxCalculator.Service.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImaginaryTaxCalculator.Tests
{
    [TestClass]
    public class SocialContributionRuleShould
    {
        public Fixture _fixture;

        [TestInitialize]
        public void Init()
        {
            _fixture = new Fixture();
        }

        [TestMethod]
        [DataRow(10000, 300)]
        [DataRow(5000, 300)]
        [DataRow(2000, 300)]
        [DataRow(1400, 210)]
        [DataRow(100, 15)]
        public void Apply(
            int taxableGrossIncome,
            int expectedSocialTax)
        {
            var taxes = _fixture.Build<Taxes>()
                .OmitAutoProperties()
                .With(c => c.TaxableGrossIncome, taxableGrossIncome)
                .Create();

            var taxableGrossIncomeRule = new SocialContributionRule();

            taxableGrossIncomeRule.Apply(taxes);

            taxes.SocialTax.Should().Be(expectedSocialTax);
        }

        [TestMethod]
        public void IsApplicable_Returns_True_When_GrossIncome_Exceeds_MinGrossIncome()
        {
            var taxes = _fixture.Build<Taxes>()
                .With(c => c.GrossIncome, SocialContributionRule.MinGrossIncome + 1)
                .Create();

            var taxableGrossIncomeRule = new SocialContributionRule();

            taxableGrossIncomeRule.IsApplicable(taxes).Should().BeTrue();
        }

        [TestMethod]
        public void IsApplicable_Returns_False_When_GrossIncome_Less_MinGrossIncome()
        {
            var taxes = _fixture.Build<Taxes>()
                .With(c => c.GrossIncome, SocialContributionRule.MinGrossIncome - 1)
                .Create();

            var taxableGrossIncomeRule = new SocialContributionRule();

            taxableGrossIncomeRule.IsApplicable(taxes).Should().BeFalse();
        }
    }
}
