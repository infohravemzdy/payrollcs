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
    public class ServiceTestExampleTemplate
    {
#if __MACOS__
        public const string PROTOKOL_TEST_FOLDER = "../../../test_import";
#else
        public const string PROTOKOL_TEST_FOLDER = "..\\..\\..\\test_import";
#endif
        public const string PROTOKOL_FOLDER_NAME = "test_import";
        public const string PARENT_PROTOKOL_FOLDER_NAME = "Procezor.OptimulaTest";

        protected const string TestFolder = PROTOKOL_TEST_FOLDER;

        protected readonly ITestOutputHelper output;

        protected readonly IServiceProcezor _sut;
        protected readonly IServiceLegalios _leg;

        protected static readonly OptimulaGenerator[] _genTests = new OptimulaGenerator[] {
            OptimulaGenerator.Spec(101, "OPT-Dpp_Premie-Zaklad", "101")
                .WithFullSheetHrs(OptValue(0))
                .WithTimeSheetHrs(OptValue(0))
                .WithWorkSheetHrs(OptValue(0))
                .WithWorkSheetDay(OptValue(0))
                .WithAgrWorkRatio(OptValue(0))
                .WithAgrWorkTarif(OptValue(0))
                .WithClothesTarif(OptValue(0))
                .WithHomeOffTarif(OptValue(0))
                .WithHomeOffHours(OptValue(0))
                .WithFPremiumBase(OptValue(0)),
        };

        public static IEnumerable<object[]> GetGenTestDecData(IEnumerable<OptimulaGenerator> tests, IPeriod testPeriod, Int32 testPeriodCode, Int32 prevPeriodCode)
        {
            System.Text.EncodingProvider ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);

            return tests.Select((tt) => (new object[] { tt }));
        }

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
        protected static StreamWriter CreateProtokolFile(string fileName)
        {
            string filePath = Path.GetFullPath(Path.Combine(TestFolder, fileName));

            string currPath = Path.GetFullPath(".");
            int nameCount = currPath.Split(Path.DirectorySeparatorChar).Length;

            while (!currPath.EndsWith(PARENT_PROTOKOL_FOLDER_NAME) && nameCount != 1)
            {
                currPath = Path.GetDirectoryName(currPath);
            }
            string basePath = Path.Combine(currPath, PROTOKOL_FOLDER_NAME);
            if (nameCount <= 1)
            {
                basePath = Path.Combine(Path.GetFullPath("."), PROTOKOL_FOLDER_NAME);
            }
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            filePath = Path.Combine(basePath, fileName);
            FileStream fileStream = new FileInfo(filePath).Create();
            return new StreamWriter(fileStream, System.Text.Encoding.GetEncoding("windows-1250"));
        }
        protected static StreamWriter OpenProtokolFile(string fileName)
        {
            string filePath = Path.GetFullPath(Path.Combine(TestFolder, fileName));

            string currPath = Path.GetFullPath(".");
            int nameCount = currPath.Split(Path.DirectorySeparatorChar).Length;

            while (!currPath.EndsWith(PARENT_PROTOKOL_FOLDER_NAME) && nameCount != 1)
            {
                currPath = Path.GetDirectoryName(currPath);
            }
            string basePath = Path.Combine(currPath, PROTOKOL_FOLDER_NAME);
            if (nameCount <= 1)
            {
                basePath = Path.Combine(Path.GetFullPath("."), PROTOKOL_FOLDER_NAME);
            }
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            filePath = Path.Combine(basePath, fileName);
            FileStream fileStream = new FileInfo(filePath).Open(FileMode.Append, FileAccess.Write);
            return new StreamWriter(fileStream, System.Text.Encoding.GetEncoding("windows-1250"));
        }
        protected static void ExportPropsStart(StreamWriter protokol)
        {
            string[] headerList = new string[]
            {
                "EmployeeNumb", // A
                "EmployeeName", // B
                "AgrWorkTarif", // C
                "AgrWorkRatio", // D
                "AgrHourLimit", // E
                "AgrWorkLimit", // F
                "ClothesTarif", // G
                "HomeOffTarif", // H
                "HomeOffHours", // I
                "MSalaryBonus", // J
                "HHourlyBonus", // K
                "FPremiumBase", // L
                "FPremiumBoss", // M
                "FPremiumPers", // N
                "FullSheetHrs", // O  
                "TimeSheetHrs", // P  
                "HoliSheetHrs", // Q  
                "WorkSheetHrs", // R  
                "WorkSheetDay", // S   
                "OverSheetHrs", // T
                "VacaRecomHrs", // U
                "PaidRecomHrs", // V
                "HoliRecomHrs", // W  
                "", // X
                "", // Y
                "", // Z
                "OverAllowHrs", // AB
                "OverAllowRio", // AC
                "RestAllowHrs", // AD
                "RestAllowRio", // AE
                "WendAllowHrs", // AF
                "WendAllowRio", // AG
                "NighAllowHrs", // AH
                "NighAllowRio", // AI
                "HoliAllowHrs", // AJ
                "HoliAllowRio", // AK
            };
            protokol.WriteLine(string.Join('\t', headerList));
        }

        protected static void ExportPropsEnd(StreamWriter protokol)
        {
        }
        protected void ServiceExamplesCreateImport(IEnumerable<OptimulaGenerator> tests, IPeriod testPeriod, Int32 testPeriodCode, Int32 prevPeriodCode)
        {
            System.Text.EncodingProvider ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);

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

                using (var testProtokol = CreateProtokolFile($"OptimulaImport_{testPeriod.Year}.xls"))
                {
                    ExportPropsStart(testProtokol);

                    foreach (var example in tests)
                    {
                        foreach (var impLine in example.BuildImportString(testPeriod, testRuleset, prevRuleset))
                        {
                            testProtokol.WriteLine(impLine);
                        }
                    }
                    ExportPropsEnd(testProtokol);
                }
            }
            catch (Xunit.Sdk.XunitException e)
            {
                throw e;
            }
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
        protected void ServiceTemplateExampleTest(OptimulaGenerator example, IPeriod testPeriod, Int32 testPeriodCode, Int32 prevPeriodCode)
        {
            if (example.Id == 101)
            {
                string[] strHeaderRadkaPRAC = new string[] {
                    "EMPLOYEEID",
                };
                using (var testProtokol = CreateProtokolFile($"OPTIMIT_TEST_{testPeriod.Year}_{testPeriod.Code}.CSV"))
                {
                    testProtokol.WriteLine(string.Join(";", strHeaderRadkaPRAC));
                }
            }
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

                using (var testProtokol = OpenProtokolFile($"OPTIMIT_TEST_{testPeriod.Year}_{testPeriod.Code}.CSV"))
                {
                    var testResults = ""; // GetExamplePracResultsLine(example, testPeriod, restService);
                    testProtokol.WriteLine(testResults);
                }

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
            return OptimulaGenerator.Spec(101, "OPT-Dpp_Premie-Zaklad", "101")
                .WithFullSheetHrs(OptValue(0))
                .WithTimeSheetHrs(OptValue(0))
                .WithWorkSheetHrs(OptValue(0))
                .WithWorkSheetDay(OptValue(0))
                .WithAgrWorkRatio(OptValue(0))
                .WithAgrWorkTarif(OptValue(0))
                .WithClothesTarif(OptValue(0))
                .WithHomeOffTarif(OptValue(0))
                .WithHomeOffHours(OptValue(0))
                .WithFPremiumBase(OptValue(0));
        }
        protected static Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> OptValue(Int32 val)
        {
            return (OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => (val);
        }
    }
}
