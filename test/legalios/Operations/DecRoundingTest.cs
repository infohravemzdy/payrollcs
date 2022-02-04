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
    public class DecRoundingTest
    {
        [Theory]
        [InlineData("5,5", "6")]
        [InlineData("2,5", "3")]
        [InlineData("1,6", "2")]
        [InlineData("1,1", "2")]
        [InlineData("1,0", "1")]
        [InlineData("-1,0", "-1")]
        [InlineData("-1,1", "-2")]
        [InlineData("-1,6", "-2")]
        [InlineData("-2,5", "-3")]
        [InlineData("-5,5", "-6")]
        public void DecRoundUp_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundUp(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5,5", "5")]
        [InlineData("2,5", "2")]
        [InlineData("1,6", "1")]
        [InlineData("1,1", "1")]
        [InlineData("1,0", "1")]
        [InlineData("-1,0", "-1")]
        [InlineData("-1,1", "-1")]
        [InlineData("-1,6", "-1")]
        [InlineData("-2,5", "-2")]
        [InlineData("-5,5", "-5")]
        public void DecRoundDown_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundDown(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5,5", "6")]
        [InlineData("2,5", "3")]
        [InlineData("1,6", "2")]
        [InlineData("1,1", "1")]
        [InlineData("1,0", "1")]
        [InlineData("-1,0", "-1")]
        [InlineData("-1,1", "-1")]
        [InlineData("-1,6", "-2")]
        [InlineData("-2,5", "-3")]
        [InlineData("-5,5", "-6")]
        public void DecRoundNorm_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundNorm(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("550", "600")]
        [InlineData("250", "300")]
        [InlineData("160", "200")]
        [InlineData("110", "200")]
        [InlineData("100", "100")]
        [InlineData("-100", "-100")]
        [InlineData("-110", "-200")]
        [InlineData("-160", "-200")]
        [InlineData("-250", "-300")]
        [InlineData("-550", "-600")]
        public void DecNearRoundUp_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecNearRoundUp(decimalTarget, 100);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("550", "500")]
        [InlineData("250", "200")]
        [InlineData("160", "100")]
        [InlineData("110", "100")]
        [InlineData("100", "100")]
        [InlineData("-100", "-100")]
        [InlineData("-110", "-100")]
        [InlineData("-160", "-100")]
        [InlineData("-250", "-200")]
        [InlineData("-550", "-500")]
        public void DecNearRoundDown_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecNearRoundDown(decimalTarget, 100);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5,125", "5,50")]
        [InlineData("2,125", "2,50")]
        [InlineData("1,126", "1,50")]
        [InlineData("1,121", "1,50")]
        [InlineData("1,120", "1,50")]
        [InlineData("-1,120", "-1,50")]
        [InlineData("-1,121", "-1,50")]
        [InlineData("-1,126", "-1,50")]
        [InlineData("-2,125", "-2,50")]
        [InlineData("-5,125", "-5,50")]
        [InlineData("5,375", "5,50")]
        [InlineData("2,375", "2,50")]
        [InlineData("1,376", "1,50")]
        [InlineData("1,371", "1,50")]
        [InlineData("1,370", "1,50")]
        [InlineData("-1,370", "-1,50")]
        [InlineData("-1,371", "-1,50")]
        [InlineData("-1,376", "-1,50")]
        [InlineData("-2,375", "-2,50")]
        [InlineData("-5,375", "-5,50")]
        [InlineData("5,625", "6,00")]
        [InlineData("2,625", "3,00")]
        [InlineData("1,626", "2,00")]
        [InlineData("1,621", "2,00")]
        [InlineData("1,620", "2,00")]
        [InlineData("-1,620", "-2,00")]
        [InlineData("-1,621", "-2,00")]
        [InlineData("-1,626", "-2,00")]
        [InlineData("-2,625", "-3,00")]
        [InlineData("-5,625", "-6,00")]
        [InlineData("5,875", "6,00")]
        [InlineData("2,875", "3,00")]
        [InlineData("1,876", "2,00")]
        [InlineData("1,871", "2,00")]
        [InlineData("1,870", "2,00")]
        [InlineData("-1,870", "-2,00")]
        [InlineData("-1,871", "-2,00")]
        [InlineData("-1,876", "-2,00")]
        [InlineData("-2,875", "-3,00")]
        [InlineData("-5,875", "-6,00")]
        [InlineData("5,55", "6")]
        [InlineData("2,55", "3")]
        [InlineData("1,56", "2")]
        [InlineData("1,51", "2")]
        [InlineData("1,50", "1,50")]
        [InlineData("-1,50", "-1,50")]
        [InlineData("-1,51", "-2")]
        [InlineData("-1,56", "-2")]
        [InlineData("-2,55", "-3")]
        [InlineData("-5,55", "-6")]
        [InlineData("5,05", "5,50")]
        [InlineData("2,05", "2,50")]
        [InlineData("1,06", "1,50")]
        [InlineData("1,01", "1,50")]
        [InlineData("1,00", "1,00")]
        [InlineData("-1,00", "-1,00")]
        [InlineData("-1,01", "-1,50")]
        [InlineData("-1,06", "-1,50")]
        [InlineData("-2,05", "-2,50")]
        [InlineData("-5,05", "-5,50")]
        public void DecRoundUp50_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundUp50(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5,125", "5,25")]
        [InlineData("2,125", "2,25")]
        [InlineData("1,126", "1,25")]
        [InlineData("1,121", "1,25")]
        [InlineData("1,120", "1,25")]
        [InlineData("-1,120", "-1,25")]
        [InlineData("-1,121", "-1,25")]
        [InlineData("-1,126", "-1,25")]
        [InlineData("-2,125", "-2,25")]
        [InlineData("-5,125", "-5,25")]
        [InlineData("5,375", "5,50")]
        [InlineData("2,375", "2,50")]
        [InlineData("1,376", "1,50")]
        [InlineData("1,371", "1,50")]
        [InlineData("1,370", "1,50")]
        [InlineData("-1,370", "-1,50")]
        [InlineData("-1,371", "-1,50")]
        [InlineData("-1,376", "-1,50")]
        [InlineData("-2,375", "-2,50")]
        [InlineData("-5,375", "-5,50")]
        [InlineData("5,625", "5,75")]
        [InlineData("2,625", "2,75")]
        [InlineData("1,626", "1,75")]
        [InlineData("1,621", "1,75")]
        [InlineData("1,620", "1,75")]
        [InlineData("-1,620", "-1,75")]
        [InlineData("-1,621", "-1,75")]
        [InlineData("-1,626", "-1,75")]
        [InlineData("-2,625", "-2,75")]
        [InlineData("-5,625", "-5,75")]
        [InlineData("5,875", "6,00")]
        [InlineData("2,875", "3,00")]
        [InlineData("1,876", "2,00")]
        [InlineData("1,871", "2,00")]
        [InlineData("1,870", "2,00")]
        [InlineData("-1,870", "-2,00")]
        [InlineData("-1,871", "-2,00")]
        [InlineData("-1,876", "-2,00")]
        [InlineData("-2,875", "-3,00")]
        [InlineData("-5,875", "-6,00")]
        [InlineData("5,255", "5,50")]
        [InlineData("2,255", "2,50")]
        [InlineData("1,256", "1,50")]
        [InlineData("1,251", "1,50")]
        [InlineData("1,250", "1,25")]
        [InlineData("-1,250", "-1,25")]
        [InlineData("-1,251", "-1,50")]
        [InlineData("-1,256", "-1,50")]
        [InlineData("-2,255", "-2,50")]
        [InlineData("-5,255", "-5,50")]
        [InlineData("5,555", "5,75")]
        [InlineData("2,555", "2,75")]
        [InlineData("1,556", "1,75")]
        [InlineData("1,551", "1,75")]
        [InlineData("1,500", "1,50")]
        [InlineData("-1,500", "-1,50")]
        [InlineData("-1,551", "-1,75")]
        [InlineData("-1,556", "-1,75")]
        [InlineData("-2,555", "-2,75")]
        [InlineData("-5,555", "-5,75")]
        [InlineData("5,755", "6,00")]
        [InlineData("2,755", "3,00")]
        [InlineData("1,756", "2,00")]
        [InlineData("1,751", "2,00")]
        [InlineData("1,750", "1,75")]
        [InlineData("-1,750", "-1,75")]
        [InlineData("-1,751", "-2,00")]
        [InlineData("-1,756", "-2,00")]
        [InlineData("-2,755", "-3,00")]
        [InlineData("-5,755", "-6,00")]
        [InlineData("5,050", "5,25")]
        [InlineData("2,050", "2,25")]
        [InlineData("1,060", "1,25")]
        [InlineData("1,010", "1,25")]
        [InlineData("1,000", "1,00")]
        [InlineData("-1,000", "-1,00")]
        [InlineData("-1,010", "-1,25")]
        [InlineData("-1,060", "-1,25")]
        [InlineData("-2,050", "-2,25")]
        [InlineData("-5,050", "-5,25")]
        public void DecRoundUp25_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundUp25(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5,555", "5,56")]
        [InlineData("2,555", "2,56")]
        [InlineData("1,556", "1,56")]
        [InlineData("1,551", "1,56")]
        [InlineData("1,550", "1,55")]
        [InlineData("-1,550", "-1,55")]
        [InlineData("-1,551", "-1,56")]
        [InlineData("-1,556", "-1,56")]
        [InlineData("-2,555", "-2,56")]
        [InlineData("-5,555", "-5,56")]
        [InlineData("5,005", "5,01")]
        [InlineData("2,005", "2,01")]
        [InlineData("1,006", "1,01")]
        [InlineData("1,001", "1,01")]
        [InlineData("1,000", "1,00")]
        [InlineData("-1,000", "-1,00")]
        [InlineData("-1,001", "-1,01")]
        [InlineData("-1,006", "-1,01")]
        [InlineData("-2,005", "-2,01")]
        [InlineData("-5,005", "-5,01")]
        public void DecRoundUp01_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundUp01(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5,125", "5,00")]
        [InlineData("2,125", "2,00")]
        [InlineData("1,126", "1,00")]
        [InlineData("1,121", "1,00")]
        [InlineData("1,120", "1,00")]
        [InlineData("-1,120", "-1,00")]
        [InlineData("-1,121", "-1,00")]
        [InlineData("-1,126", "-1,00")]
        [InlineData("-2,125", "-2,00")]
        [InlineData("-5,125", "-5,00")]
        [InlineData("5,375", "5,00")]
        [InlineData("2,375", "2,00")]
        [InlineData("1,376", "1,00")]
        [InlineData("1,371", "1,00")]
        [InlineData("1,370", "1,00")]
        [InlineData("-1,370", "-1,00")]
        [InlineData("-1,371", "-1,00")]
        [InlineData("-1,376", "-1,00")]
        [InlineData("-2,375", "-2,00")]
        [InlineData("-5,375", "-5,00")]
        [InlineData("5,625", "5,50")]
        [InlineData("2,625", "2,50")]
        [InlineData("1,626", "1,50")]
        [InlineData("1,621", "1,50")]
        [InlineData("1,620", "1,50")]
        [InlineData("-1,620", "-1,50")]
        [InlineData("-1,621", "-1,50")]
        [InlineData("-1,626", "-1,50")]
        [InlineData("-2,625", "-2,50")]
        [InlineData("-5,625", "-5,50")]
        [InlineData("5,875", "5,50")]
        [InlineData("2,875", "2,50")]
        [InlineData("1,876", "1,50")]
        [InlineData("1,871", "1,50")]
        [InlineData("1,870", "1,50")]
        [InlineData("-1,870", "-1,50")]
        [InlineData("-1,871", "-1,50")]
        [InlineData("-1,876", "-1,50")]
        [InlineData("-2,875", "-2,50")]
        [InlineData("-5,875", "-5,50")]
        [InlineData("5,55", "5,50")]
        [InlineData("2,55", "2,50")]
        [InlineData("1,56", "1,50")]
        [InlineData("1,51", "1,50")]
        [InlineData("1,50", "1,50")]
        [InlineData("-1,50", "-1,50")]
        [InlineData("-1,51", "-1,50")]
        [InlineData("-1,56", "-1,50")]
        [InlineData("-2,55", "-2,50")]
        [InlineData("-5,55", "-5,50")]
        [InlineData("5,05", "5,00")]
        [InlineData("2,05", "2,00")]
        [InlineData("1,06", "1,00")]
        [InlineData("1,01", "1,00")]
        [InlineData("1,00", "1,00")]
        [InlineData("-1,00", "-1,00")]
        [InlineData("-1,01", "-1,00")]
        [InlineData("-1,06", "-1,00")]
        [InlineData("-2,05", "-2,00")]
        [InlineData("-5,05", "-5,00")]
        public void DecRoundDown50_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundDown50(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5,125", "5,00")]
        [InlineData("2,125", "2,00")]
        [InlineData("1,126", "1,00")]
        [InlineData("1,121", "1,00")]
        [InlineData("1,120", "1,00")]
        [InlineData("-1,120", "-1,00")]
        [InlineData("-1,121", "-1,00")]
        [InlineData("-1,126", "-1,00")]
        [InlineData("-2,125", "-2,00")]
        [InlineData("-5,125", "-5,00")]
        [InlineData("5,375", "5,25")]
        [InlineData("2,375", "2,25")]
        [InlineData("1,376", "1,25")]
        [InlineData("1,371", "1,25")]
        [InlineData("1,370", "1,25")]
        [InlineData("-1,370", "-1,25")]
        [InlineData("-1,371", "-1,25")]
        [InlineData("-1,376", "-1,25")]
        [InlineData("-2,375", "-2,25")]
        [InlineData("-5,375", "-5,25")]
        [InlineData("5,625", "5,50")]
        [InlineData("2,625", "2,50")]
        [InlineData("1,626", "1,50")]
        [InlineData("1,621", "1,50")]
        [InlineData("1,620", "1,50")]
        [InlineData("-1,620", "-1,50")]
        [InlineData("-1,621", "-1,50")]
        [InlineData("-1,626", "-1,50")]
        [InlineData("-2,625", "-2,50")]
        [InlineData("-5,625", "-5,50")]
        [InlineData("5,875", "5,75")]
        [InlineData("2,875", "2,75")]
        [InlineData("1,876", "1,75")]
        [InlineData("1,871", "1,75")]
        [InlineData("1,870", "1,75")]
        [InlineData("-1,870", "-1,75")]
        [InlineData("-1,871", "-1,75")]
        [InlineData("-1,876", "-1,75")]
        [InlineData("-2,875", "-2,75")]
        [InlineData("-5,875", "-5,75")]
        [InlineData("5,255", "5,25")]
        [InlineData("2,255", "2,25")]
        [InlineData("1,256", "1,25")]
        [InlineData("1,251", "1,25")]
        [InlineData("1,250", "1,25")]
        [InlineData("-1,250", "-1,25")]
        [InlineData("-1,251", "-1,25")]
        [InlineData("-1,256", "-1,25")]
        [InlineData("-2,255", "-2,25")]
        [InlineData("-5,255", "-5,25")]
        [InlineData("5,555", "5,50")]
        [InlineData("2,555", "2,50")]
        [InlineData("1,556", "1,50")]
        [InlineData("1,551", "1,50")]
        [InlineData("1,500", "1,50")]
        [InlineData("-1,500", "-1,50")]
        [InlineData("-1,551", "-1,50")]
        [InlineData("-1,556", "-1,50")]
        [InlineData("-2,555", "-2,50")]
        [InlineData("-5,555", "-5,50")]
        [InlineData("5,755", "5,75")]
        [InlineData("2,755", "2,75")]
        [InlineData("1,756", "1,75")]
        [InlineData("1,751", "1,75")]
        [InlineData("1,750", "1,75")]
        [InlineData("-1,750", "-1,75")]
        [InlineData("-1,751", "-1,75")]
        [InlineData("-1,756", "-1,75")]
        [InlineData("-2,755", "-2,75")]
        [InlineData("-5,755", "-5,75")]
        [InlineData("5,050", "5,00")]
        [InlineData("2,050", "2,00")]
        [InlineData("1,060", "1,00")]
        [InlineData("1,010", "1,00")]
        [InlineData("1,000", "1,00")]
        [InlineData("-1,000", "-1,00")]
        [InlineData("-1,010", "-1,00")]
        [InlineData("-1,060", "-1,00")]
        [InlineData("-2,050", "-2,00")]
        [InlineData("-5,050", "-5,00")]
        public void DecRoundDown25_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundDown25(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5,555", "5,55")]
        [InlineData("2,555", "2,55")]
        [InlineData("1,556", "1,55")]
        [InlineData("1,551", "1,55")]
        [InlineData("1,550", "1,55")]
        [InlineData("-1,550", "-1,55")]
        [InlineData("-1,551", "-1,55")]
        [InlineData("-1,556", "-1,55")]
        [InlineData("-2,555", "-2,55")]
        [InlineData("-5,555", "-5,55")]
        [InlineData("5,005", "5,00")]
        [InlineData("2,005", "2,00")]
        [InlineData("1,006", "1,00")]
        [InlineData("1,001", "1,00")]
        [InlineData("1,000", "1,00")]
        [InlineData("-1,000", "-1,00")]
        [InlineData("-1,001", "-1,00")]
        [InlineData("-1,006", "-1,00")]
        [InlineData("-2,005", "-2,00")]
        [InlineData("-5,005", "-5,00")]
        public void DecRoundDown01_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundDown01(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5,125", "5,00")]
        [InlineData("2,125", "2,00")]
        [InlineData("1,126", "1,00")]
        [InlineData("1,121", "1,00")]
        [InlineData("1,120", "1,00")]
        [InlineData("-1,120", "-1,00")]
        [InlineData("-1,121", "-1,00")]
        [InlineData("-1,126", "-1,00")]
        [InlineData("-2,125", "-2,00")]
        [InlineData("-5,125", "-5,00")]
        [InlineData("5,375", "5,50")]
        [InlineData("2,375", "2,50")]
        [InlineData("1,376", "1,50")]
        [InlineData("1,371", "1,50")]
        [InlineData("1,370", "1,50")]
        [InlineData("-1,370", "-1,50")]
        [InlineData("-1,371", "-1,50")]
        [InlineData("-1,376", "-1,50")]
        [InlineData("-2,375", "-2,50")]
        [InlineData("-5,375", "-5,50")]
        [InlineData("5,625", "5,50")]
        [InlineData("2,625", "2,50")]
        [InlineData("1,626", "1,50")]
        [InlineData("1,621", "1,50")]
        [InlineData("1,620", "1,50")]
        [InlineData("-1,620", "-1,50")]
        [InlineData("-1,621", "-1,50")]
        [InlineData("-1,626", "-1,50")]
        [InlineData("-2,625", "-2,50")]
        [InlineData("-5,625", "-5,50")]
        [InlineData("5,875", "6,00")]
        [InlineData("2,875", "3,00")]
        [InlineData("1,876", "2,00")]
        [InlineData("1,871", "2,00")]
        [InlineData("1,870", "2,00")]
        [InlineData("-1,870", "-2,00")]
        [InlineData("-1,871", "-2,00")]
        [InlineData("-1,876", "-2,00")]
        [InlineData("-2,875", "-3,00")]
        [InlineData("-5,875", "-6,00")]
        [InlineData("5,55", "5,50")]
        [InlineData("2,55", "2,50")]
        [InlineData("1,56", "1,50")]
        [InlineData("1,51", "1,50")]
        [InlineData("1,50", "1,50")]
        [InlineData("-1,50", "-1,50")]
        [InlineData("-1,51", "-1,50")]
        [InlineData("-1,56", "-1,50")]
        [InlineData("-2,55", "-2,50")]
        [InlineData("-5,55", "-5,50")]
        [InlineData("5,05", "5,00")]
        [InlineData("2,05", "2,00")]
        [InlineData("1,06", "1,00")]
        [InlineData("1,01", "1,00")]
        [InlineData("1,00", "1,00")]
        [InlineData("-1,00", "-1,00")]
        [InlineData("-1,01", "-1,00")]
        [InlineData("-1,06", "-1,00")]
        [InlineData("-2,05", "-2,00")]
        [InlineData("-5,05", "-5,00")]
        public void DecRoundNorm50_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundNorm50(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5,125", "5,25")]
        [InlineData("2,125", "2,25")]
        [InlineData("1,126", "1,25")]
        [InlineData("1,121", "1,00")]
        [InlineData("1,120", "1,00")]
        [InlineData("-1,120", "-1,00")]
        [InlineData("-1,121", "-1,00")]
        [InlineData("-1,126", "-1,25")]
        [InlineData("-2,125", "-2,25")]
        [InlineData("-5,125", "-5,25")]
        [InlineData("5,375", "5,50")]
        [InlineData("2,375", "2,50")]
        [InlineData("1,376", "1,50")]
        [InlineData("1,371", "1,25")]
        [InlineData("1,370", "1,25")]
        [InlineData("-1,370", "-1,25")]
        [InlineData("-1,371", "-1,25")]
        [InlineData("-1,376", "-1,50")]
        [InlineData("-2,375", "-2,50")]
        [InlineData("-5,375", "-5,50")]
        [InlineData("5,625", "5,75")]
        [InlineData("2,625", "2,75")]
        [InlineData("1,626", "1,75")]
        [InlineData("1,621", "1,50")]
        [InlineData("1,620", "1,50")]
        [InlineData("-1,620", "-1,50")]
        [InlineData("-1,621", "-1,50")]
        [InlineData("-1,626", "-1,75")]
        [InlineData("-2,625", "-2,75")]
        [InlineData("-5,625", "-5,75")]
        [InlineData("5,875", "6,00")]
        [InlineData("2,875", "3,00")]
        [InlineData("1,876", "2,00")]
        [InlineData("1,871", "1,75")]
        [InlineData("1,870", "1,75")]
        [InlineData("-1,870", "-1,75")]
        [InlineData("-1,871", "-1,75")]
        [InlineData("-1,876", "-2,00")]
        [InlineData("-2,875", "-3,00")]
        [InlineData("-5,875", "-6,00")]
        [InlineData("5,255", "5,25")]
        [InlineData("2,255", "2,25")]
        [InlineData("1,256", "1,25")]
        [InlineData("1,251", "1,25")]
        [InlineData("1,250", "1,25")]
        [InlineData("-1,250", "-1,25")]
        [InlineData("-1,251", "-1,25")]
        [InlineData("-1,256", "-1,25")]
        [InlineData("-2,255", "-2,25")]
        [InlineData("-5,255", "-5,25")]
        [InlineData("5,555", "5,50")]
        [InlineData("2,555", "2,50")]
        [InlineData("1,556", "1,50")]
        [InlineData("1,551", "1,50")]
        [InlineData("1,500", "1,50")]
        [InlineData("-1,500", "-1,50")]
        [InlineData("-1,551", "-1,50")]
        [InlineData("-1,556", "-1,50")]
        [InlineData("-2,555", "-2,50")]
        [InlineData("-5,555", "-5,50")]
        [InlineData("5,755", "5,75")]
        [InlineData("2,755", "2,75")]
        [InlineData("1,756", "1,75")]
        [InlineData("1,751", "1,75")]
        [InlineData("1,750", "1,75")]
        [InlineData("-1,750", "-1,75")]
        [InlineData("-1,751", "-1,75")]
        [InlineData("-1,756", "-1,75")]
        [InlineData("-2,755", "-2,75")]
        [InlineData("-5,755", "-5,75")]
        [InlineData("5,050", "5,00")]
        [InlineData("2,050", "2,00")]
        [InlineData("1,060", "1,00")]
        [InlineData("1,010", "1,00")]
        [InlineData("1,000", "1,00")]
        [InlineData("-1,000", "-1,00")]
        [InlineData("-1,010", "-1,00")]
        [InlineData("-1,060", "-1,00")]
        [InlineData("-2,050", "-2,00")]
        [InlineData("-5,050", "-5,00")]
        public void DecRoundNorm25_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundNorm25(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
        [Theory]
        [InlineData("5,555", "5,56")]
        [InlineData("2,555", "2,56")]
        [InlineData("1,556", "1,56")]
        [InlineData("1,551", "1,55")]
        [InlineData("1,550", "1,55")]
        [InlineData("-1,550", "-1,55")]
        [InlineData("-1,551", "-1,55")]
        [InlineData("-1,556", "-1,56")]
        [InlineData("-2,555", "-2,56")]
        [InlineData("-5,555", "-5,56")]
        [InlineData("5,005", "5,01")]
        [InlineData("2,005", "2,01")]
        [InlineData("1,006", "1,01")]
        [InlineData("1,001", "1,00")]
        [InlineData("1,000", "1,00")]
        [InlineData("-1,000", "-1,00")]
        [InlineData("-1,001", "-1,00")]
        [InlineData("-1,006", "-1,01")]
        [InlineData("-2,005", "-2,01")]
        [InlineData("-5,005", "-5,01")]
        public void DecRoundNorm01_ShouldReturn_RoundedDecimal(string testTarget, string testResult)
        {
            var decimalTarget = decimal.Parse(testTarget);
            var decimalResult = decimal.Parse(testResult);

            var decimalRounds = OperationsRound.DecRoundNorm01(decimalTarget);

            decimalRounds.Should().Be(decimalResult);
        }
    }
}
