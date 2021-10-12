using System;
using AutoFixture;
using FluentAssertions;
using HraveMzdy.Legalios.Service;
using HraveMzdy.Legalios.Interfaces;
using HraveMzdy.Legalios.Service.Types;
using NSubstitute;
using Xunit;

namespace LegaliosTest.Service
{
    public class Service_Legalios_Example_BundleFailure2010Test
    {
        private readonly IServiceLegalios _sut;

        public Service_Legalios_Example_BundleFailure2010Test()
        {
            _sut = new ServiceLegalios();
        }

        [Theory]
        [InlineData(2010, 1)]
        [InlineData(2010, 2)]
        [InlineData(2010, 3)]
        [InlineData(2010, 4)]
        [InlineData(2010, 5)]
        [InlineData(2010, 6)]
        [InlineData(2010, 7)]
        [InlineData(2010, 8)]
        [InlineData(2010, 9)]
        [InlineData(2010,10)]
        [InlineData(2010,11)]
        [InlineData(2010,12)]
        public void GetBundle_ShouldReturnError_ForYear2010(Int16 testYear, Int16 testMonth)
        {
            var testPeriod = new Period(testYear, testMonth);

            var testResult = _sut.GetBundle(testPeriod);

            testResult.IsFailure.Should().BeTrue();
        }
    }
}
