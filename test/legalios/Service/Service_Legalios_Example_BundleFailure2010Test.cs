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
    public class Service_Legalios_Example_BundleFailure2009Test
    {
        private readonly IServiceLegalios _sut;

        public Service_Legalios_Example_BundleFailure2009Test()
        {
            _sut = new ServiceLegalios();
        }

        [Theory]
        [InlineData(2009, 1)]
        [InlineData(2009, 2)]
        [InlineData(2009, 3)]
        [InlineData(2009, 4)]
        [InlineData(2009, 5)]
        [InlineData(2009, 6)]
        [InlineData(2009, 7)]
        [InlineData(2009, 8)]
        [InlineData(2009, 9)]
        [InlineData(2009,10)]
        [InlineData(2009,11)]
        [InlineData(2009,12)]
        public void GetBundle_ShouldReturnError_ForYear2009(Int16 testYear, Int16 testMonth)
        {
            var testPeriod = new Period(testYear, testMonth);

            var testResult = _sut.GetBundle(testPeriod);

            testResult.IsFailure.Should().BeTrue();
        }
    }
}
