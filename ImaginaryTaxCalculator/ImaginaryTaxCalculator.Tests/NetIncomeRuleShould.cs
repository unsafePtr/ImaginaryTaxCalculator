using AutoFixture;
using FluentAssertions;
using ImaginaryTaxCalculator.Service.ImaginaryRules;
using ImaginaryTaxCalculator.Service.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImaginaryTaxCalculator.Tests
{
    [TestClass]
    public class NetIncomeRuleShould
    {
        public Fixture _fixture;

        [TestInitialize]
        public void Init()
        {
            _fixture = new Fixture();
        }

        [TestMethod]
        public void Apply_When_TaxableGrossIncome_Is_Non_Zero()
        {
            var socialTax = _fixture.Create<decimal>();
            var incomeTax = socialTax + _fixture.Create<decimal>();
            var grossIncome = socialTax + incomeTax + _fixture.Create<decimal>(); // this is just to make sure that grossIncome is with highest value

            var expected = grossIncome - socialTax - incomeTax;

            var taxes = _fixture.Build<Taxes>()
                .OmitAutoProperties()
                .With(c => c.GrossIncome, grossIncome)
                .With(c => c.TaxableGrossIncome, grossIncome)
                .With(c => c.SocialTax, socialTax)
                .With(c => c.IncomeTax, incomeTax)
                .Create();

            var netIncomeRule = new NetIncomeRule();

            netIncomeRule.Apply(taxes);

            taxes.NetIncome.Should().Be(expected);
        }

        [TestMethod]
        public void Apply_When_TaxableGrossIncome_Is_Zero()
        {
            var grossIncome = _fixture.Create<decimal>();

            var taxes = _fixture.Build<Taxes>()
                .OmitAutoProperties()
                .With(c => c.GrossIncome, grossIncome)
                .With(c => c.TaxableGrossIncome, 0)
                .Create();

            var netIncomeRule = new NetIncomeRule();

            netIncomeRule.Apply(taxes);

            taxes.NetIncome.Should().Be(grossIncome);
        }

        [TestMethod]
        public void IsApplicable_Always_Returns_True()
        {
            var taxes = _fixture.Build<Taxes>()
                .Create();

            var NetIncomeRule = new NetIncomeRule();

            NetIncomeRule.IsApplicable(taxes).Should().BeTrue();
        }
    }
}
