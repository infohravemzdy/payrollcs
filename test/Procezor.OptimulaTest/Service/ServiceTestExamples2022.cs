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
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service;
using HraveMzdy.Procezor.Optimula.Registry.Constants;
using HraveMzdy.Procezor.Optimula.Service;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Optimula.Registry.Providers;
using Procezor.OptimulaTest.Examples;
using System.IO;

namespace Procezor.OptimulaTest.Service
{
    public class ServiceTestExamples2022 : ServiceTestExampleTemplate
    {
        private static IPeriod TestPeriod = new Period(2022, 1);
        private static Int32 TestPeriodCode = 202201;
        private static Int32 PrevPeriodCode = 202101;

        public static IEnumerable<object[]> GenTestData => GetGenTestDecData(_genTests, TestPeriod, TestPeriodCode, PrevPeriodCode);

        public ServiceTestExamples2022(ITestOutputHelper output) : base(output)
        {
        }
        [Fact]
        public void ServiceExamples_101_OPTDppPremieZakladTest()
        {
            OptimulaGenerator example = Example_101_OPTDppPremieZaklad();

            ServiceExampleTest(example, TestPeriod, TestPeriodCode, PrevPeriodCode);
        }
        [Fact]
        public void ServiceExamples_101_FullTime_OverTimeZeroHolidaysZeroTest()
        {
            OptimulaGenerator example = Example_101_FullTime_OverTimeZeroHolidaysZero();

            ServiceExampleTest(example, TestPeriod, TestPeriodCode, PrevPeriodCode);
        }
        [Fact]
        public void ServiceExamples_CreateImport()
        {
            ServiceExamplesCreateImport(_genTests, TestPeriod, TestPeriodCode, PrevPeriodCode);
        }
        [Theory]
        [MemberData(nameof(GenTestData))]
        public void ServiceExamplesTest(OptimulaGenerator example)
        {
            ServiceTemplateExampleTest(example, TestPeriod, TestPeriodCode, PrevPeriodCode);
        }
    }

}
