using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;
using HraveMzdy.Legalios.Service;
using HraveMzdy.Legalios.Service.Types;
using Procezor.Payrolex.Service;
using Procezor.PayrolexTest.Examples;
using HraveMzdy.Legalios.Service.Interfaces;

namespace Procezor.PayrolexTest.Service
{
    public class ServiceTestExamples
    {
        private readonly ITestOutputHelper output;

        private readonly IServiceLegalios _leg;

        public ServiceTestExamples(ITestOutputHelper output)
        {
            this.output = output;

            this._leg = new ServiceLegalios();
        }
        public static IPeriod LastYear(IPeriod period)
        {
            return new Period(period.Year - 1, period.Month);
        }
        public static IBundleProps LastYearBundle(IServiceLegalios legSvc, IPeriod period)
        {
            var legResult = legSvc.GetBundle(LastYear(period));
            return legResult.Value;
        }

        [Fact]
        public void ServiceExamplesTest()
        {
            var testPeriod = new Period(2013, 1);
            testPeriod.Code.Should().Be(201301);

            var prevPeriod = LastYear(testPeriod);
            prevPeriod.Code.Should().Be(201201);

            var testLegalResult = _leg.GetBundle(testPeriod);
            testLegalResult.IsSuccess.Should().Be(true);

            var testRuleset = testLegalResult.Value;

            var prevLegalResult = _leg.GetBundle(prevPeriod);
            prevLegalResult.IsSuccess.Should().Be(true);

            var prevRuleset = prevLegalResult.Value;

            var examples = ExampleSpec.GetExamples2013(testPeriod, testRuleset, prevRuleset);
            //foreach (var (ex, index) in examples.Select((item, index) => (item, index)))
            //{
            //    output.WriteLine(ex.exampleString());
            //}
            foreach (var (ex, index) in examples.Select((item, index) => (item, index)))
            {
                foreach (var imp in ex.importString(testPeriod))
                {
                    output.WriteLine(imp);
                }
            }
        }
    }
}
