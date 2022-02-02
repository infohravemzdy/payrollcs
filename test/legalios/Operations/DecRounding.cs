using System;
using HraveMzdy.Legalios.Factories;
using HraveMzdy.Legalios.Providers;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Interfaces;
using Xunit;
using HraveMzdy.Legalios.Props;
using FluentAssertions;
using HraveMzdy.Legalios.Service.Types;

namespace LegaliosTests.Operations
{
    public class DecRounding
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
        public void DecRoundUp_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundUp(decimalTarget);

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
        public void DecRoundDown_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundDown(decimalTarget);

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
        public void DecRoundNorm_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundNorm(decimalTarget);

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
        public void DecNearRoundUp_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecNearRoundUp(decimalTarget, 100);

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
        public void DecNearRoundDown_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecNearRoundDown(decimalTarget, 100);

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
        public void DecRoundUp50_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundUp50(decimalTarget);

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
        public void DecRoundUp25_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundUp25(decimalTarget);

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
        public void DecRoundUp01_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundUp01(decimalTarget);

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
        public void DecRoundDown50_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundDown50(decimalTarget);

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
        public void DecRoundDown25_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundDown25(decimalTarget);

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
        public void DecRoundDown01_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundDown01(decimalTarget);

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
        public void DecRoundNorm50_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundNorm50(decimalTarget);

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
        public void DecRoundNorm25_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundNorm25(decimalTarget);

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
        public void DecRoundNorm01_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundNorm01(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
    }
}
