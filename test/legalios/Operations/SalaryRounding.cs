using System;
using HraveMzdy.Legalios.Factories;
using HraveMzdy.Legalios.Providers;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Interfaces;
using Xunit;
using HraveMzdy.Legalios.Props;
using FluentAssertions;

namespace LegaliosTests.Operations
{
    public class SalaryRounding
    {
        [Theory]
        [InlineData("5.5", "6")]
        [InlineData("2.5", "3")]
        [InlineData("1.6", "2")]
        [InlineData("1.1", "2")]
        [InlineData("1.0", "1")]
        [InlineData("-1.0", "-1")]
        [InlineData("-1.1", "-2")]
        [InlineData("-1.6", "-2")]
        [InlineData("-2.5", "-3")]
        [InlineData("-5.5", "-6")]
        public void HoursToHalfHoursUp_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var _sut = PropsSalary.Empty();
            var decimalRounds = _sut.HoursToHalfHoursUp(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5.5", "6")]
        [InlineData("2.5", "3")]
        [InlineData("1.6", "2")]
        [InlineData("1.1", "2")]
        [InlineData("1.0", "1")]
        [InlineData("-1.0", "-1")]
        [InlineData("-1.1", "-2")]
        [InlineData("-1.6", "-2")]
        [InlineData("-2.5", "-3")]
        [InlineData("-5.5", "-6")]
        public void HoursToQuartHoursUp_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var _sut = PropsSalary.Empty();
            var decimalRounds = _sut.HoursToQuartHoursUp(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5.5", "6")]
        [InlineData("2.5", "3")]
        [InlineData("1.6", "2")]
        [InlineData("1.1", "2")]
        [InlineData("1.0", "1")]
        [InlineData("-1.0", "-1")]
        [InlineData("-1.1", "-2")]
        [InlineData("-1.6", "-2")]
        [InlineData("-2.5", "-3")]
        [InlineData("-5.5", "-6")]
        public void HoursToHalfHoursDown_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var _sut = PropsSalary.Empty();
            var decimalRounds = _sut.HoursToHalfHoursDown(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5.5", "6")]
        [InlineData("2.5", "3")]
        [InlineData("1.6", "2")]
        [InlineData("1.1", "2")]
        [InlineData("1.0", "1")]
        [InlineData("-1.0", "-1")]
        [InlineData("-1.1", "-2")]
        [InlineData("-1.6", "-2")]
        [InlineData("-2.5", "-3")]
        [InlineData("-5.5", "-6")]
        public void HoursToQuartHoursDown_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var _sut = PropsSalary.Empty();
            var decimalRounds = _sut.HoursToQuartHoursDown(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5.5", "6")]
        [InlineData("2.5", "3")]
        [InlineData("1.6", "2")]
        [InlineData("1.1", "2")]
        [InlineData("1.0", "1")]
        [InlineData("-1.0", "-1")]
        [InlineData("-1.1", "-2")]
        [InlineData("-1.6", "-2")]
        [InlineData("-2.5", "-3")]
        [InlineData("-5.5", "-6")]
        public void HoursToHalfHoursNorm_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var _sut = PropsSalary.Empty();
            var decimalRounds = _sut.HoursToHalfHoursNorm(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5.5", "6")]
        [InlineData("2.5", "3")]
        [InlineData("1.6", "2")]
        [InlineData("1.1", "2")]
        [InlineData("1.0", "1")]
        [InlineData("-1.0", "-1")]
        [InlineData("-1.1", "-2")]
        [InlineData("-1.6", "-2")]
        [InlineData("-2.5", "-3")]
        [InlineData("-5.5", "-6")]
        public void HoursToQuartHoursNorm_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var _sut = PropsSalary.Empty();
            var decimalRounds = _sut.HoursToQuartHoursNorm(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5.5", "6")]
        [InlineData("2.5", "3")]
        [InlineData("1.6", "2")]
        [InlineData("1.1", "2")]
        [InlineData("1.0", "1")]
        [InlineData("-1.0", "-1")]
        [InlineData("-1.1", "-2")]
        [InlineData("-1.6", "-2")]
        [InlineData("-2.5", "-3")]
        [InlineData("-5.5", "-6")]
        public void MoneyToRoundDown_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var _sut = PropsSalary.Empty();
            var decimalRounds = _sut.MoneyToRoundDown(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5.5", "6")]
        [InlineData("2.5", "3")]
        [InlineData("1.6", "2")]
        [InlineData("1.1", "2")]
        [InlineData("1.0", "1")]
        [InlineData("-1.0", "-1")]
        [InlineData("-1.1", "-2")]
        [InlineData("-1.6", "-2")]
        [InlineData("-2.5", "-3")]
        [InlineData("-5.5", "-6")]
        public void MoneyToRoundUp_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var _sut = PropsSalary.Empty();
            var decimalRounds = _sut.MoneyToRoundUp(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5.5", "6")]
        [InlineData("2.5", "3")]
        [InlineData("1.6", "2")]
        [InlineData("1.1", "2")]
        [InlineData("1.0", "1")]
        [InlineData("-1.0", "-1")]
        [InlineData("-1.1", "-2")]
        [InlineData("-1.6", "-2")]
        [InlineData("-2.5", "-3")]
        [InlineData("-5.5", "-6")]
        public void MoneyToRoundNorm_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var _sut = PropsSalary.Empty();
            var decimalRounds = _sut.MoneyToRoundNorm(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
    }
}
