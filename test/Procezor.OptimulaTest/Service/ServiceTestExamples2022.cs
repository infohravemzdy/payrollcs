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

namespace Procezor.OptimulaTest.Service
{
    public class ServiceTestExamples2022 : ServiceTestExampleTemplate
    {
        private static IPeriod TestPeriod = new Period(2022, 1);
        private static Int32 TestPeriodCode = 202201;
        private static Int32 PrevPeriodCode = 202101;

        public ServiceTestExamples2022(ITestOutputHelper output) : base(output)
        {
        }
        [Fact]
        public void ServiceExamples_101_OPTDppPremieZakladTest()
        {
            OptimulaGenerator example = Example_101_OPTDppPremieZaklad();

            ServiceExampleTest(example, TestPeriod, TestPeriodCode, PrevPeriodCode);
        }
    }

    public class ServiceTestExampleTemplate
    {
#if __MACOS__
        public const string PROTOKOL_TEST_FOLDER = "../../../test_import";
#else
        public const string PROTOKOL_TEST_FOLDER = "..\\..\\..\\test_import";
#endif
        public const string PROTOKOL_FOLDER_NAME = "test_import";
        public const string PARENT_PROTOKOL_FOLDER_NAME = "Procezor.PayrolexTest";

        protected const string TestFolder = PROTOKOL_TEST_FOLDER;

        protected readonly ITestOutputHelper output;

        protected readonly IServiceProcezor _sut;
        protected readonly IServiceLegalios _leg;

        public ServiceTestExampleTemplate(ITestOutputHelper output)
        {
            this.output = output;

            this._sut = new ServiceOptimula();
            this._leg = new ServiceLegalios();
        }
        public static IPeriod PrevYear(IPeriod period)
        {
            return new Period(Math.Max(2010, period.Year - 1), period.Month);
        }
        public static IBundleProps CurrYearBundle(IServiceLegalios legSvc, IPeriod period)
        {
            var legResult = legSvc.GetBundle(period);
            return legResult.Value;
        }
        public static IBundleProps PrevYearBundle(IServiceLegalios legSvc, IPeriod period)
        {
            var legResult = legSvc.GetBundle(PrevYear(period));
            return legResult.Value;
        }
        protected void ServiceExampleTest(OptimulaGenerator example, IPeriod testPeriod, Int32 testPeriodCode, Int32 prevPeriodCode)
        {
            output.WriteLine($"Test: {example.Name}, Number: {example.Number}");
            try
            {
                testPeriod.Code.Should().Be(testPeriodCode);

                var prevPeriod = PrevYear(testPeriod);
                prevPeriod.Code.Should().Be(prevPeriodCode);

                var testLegalResult = _leg.GetBundle(testPeriod);
                testLegalResult.IsSuccess.Should().Be(true);

                var testRuleset = testLegalResult.Value;

                var prevLegalResult = _leg.GetBundle(prevPeriod);
                prevLegalResult.IsSuccess.Should().Be(true);

                var prevRuleset = prevLegalResult.Value;

                var targets = example.BuildSpecTargets(testPeriod, testRuleset, prevRuleset);
                foreach (var (target, index) in targets.Select((item, index) => (item, index)))
                {
                    var articleSymbol = target.ArticleDescr();
                    var conceptSymbol = target.ConceptDescr();
                    output.WriteLine("Index: {0}, ART: {1}, CON: {2}, con: {3}, pos: {4}, var: {5}", index, articleSymbol, conceptSymbol, target.Contract.Value, target.Position.Value, target.Variant.Value);
                }

                var initService = _sut.InitWithPeriod(testPeriod);
                initService.Should().BeTrue();

                var restService = _sut.GetResults(testPeriod, testRuleset, targets);
                restService.Count().Should().NotBe(0);

                output.WriteLine($"Result Test: {example.Name}, Number: {example.Number}");

                foreach (var (result, index) in restService.Select((item, index) => (item, index)))
                {
                    if (result.IsSuccess)
                    {
                        var resultValue = result.Value;
                        var articleSymbol = resultValue.ArticleDescr();
                        var conceptSymbol = resultValue.ConceptDescr();
                        output.WriteLine("Index: {0}, ART: {1}, CON: {2}, Result: {3}", index, articleSymbol, conceptSymbol, resultValue.ResultMessage());
                    }
                    else if (result.IsFailure)
                    {
                        var errorValue = result.Error;
                        var articleSymbol = errorValue.ArticleDescr();
                        var conceptSymbol = errorValue.ConceptDescr();
                        output.WriteLine("Index: {0}, ART: {1}, CON: {2}, Error: {3}", index, articleSymbol, conceptSymbol, errorValue.Description());
                    }
                }
            }
            catch (Xunit.Sdk.XunitException e)
            {
                throw e;
            }
        }
        public OptimulaGenerator Example_101_OPTDppPremieZaklad()
        {
            return OptimulaGenerator.Spec(101, "OPT-Dpp_Premie-Zaklad", "101");
        }
    }
}
