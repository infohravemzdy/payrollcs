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

        [Fact]
        public void ServiceExamplesTest()
        {
            var testPeriod = new Period(2013, 1);
            testPeriod.Code.Should().Be(201301);

            var testLegalResult = _leg.GetBundle(testPeriod);
            testLegalResult.IsSuccess.Should().Be(true);

            var testRuleset = testLegalResult.Value;

            var examples = ExampleSpec.GetExamples2013(testPeriod, _leg, testRuleset);
            foreach (var (ex, index) in examples.Select((item, index) => (item, index)))
            {
                output.WriteLine(ex.exampleString());
            }
        }
    }
}
