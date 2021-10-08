using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog;
using NLog.Config;
using NLog.Targets;
using Xunit;

namespace LegaliosUnitTest
{
    [CollectionDefinition("TestEngine")]
    public class Service_Legalios_Example_BaseTest
    {
#if __MACOS__
        public const string EXAMPLE_TEST_FOLDER = "../../../test_expected";
#else
        public const string EXAMPLE_TEST_FOLDER = "..\\..\\..\\test_expected";
#endif

        public static IEnumerable<object[]> GetTestData(TestScenario[] tests) =>
            tests.SelectMany((tt) => tt.tests.Select((tx) => (new object[] { tt.testTitle, tx.testName, tx.testYear, tx.testMonth, tx.resultYear })));
        public static IEnumerable<object[]> GetTestIntData(TestIntScenario[] tests) =>
            tests.SelectMany((tt) => tt.tests.Select((tx) => (new object[] { tt.testTitle, tx.testName, tx.testYear, tx.testMonth, tx.resultYear, tx.resultMonth, tx.resultValue })));
        public static IEnumerable<object[]> GetTestDecData(TestDecScenario[] tests) =>
            tests.SelectMany((tt) => tt.tests.Select((tx) => (new object[] { tt.testTitle, tx.testName, tx.testYear, tx.testMonth, tx.resultYear, tx.resultMonth, tx.resultValue })));
        public Service_Legalios_Example_BaseTest()
        {
        }

        protected StreamWriter CreateLoggerFile(string fileName)
        {
            string filePath = Path.Combine(Path.GetFullPath(EXAMPLE_TEST_FOLDER), fileName);

            return File.CreateText(filePath);
        }
        protected void LogExampleYear(StreamWriter protokol, string value)
        {
            protokol.Write("{0}", value);
        }

        protected void LogExampleStart(StreamWriter protokol)
        {
            protokol.Write("{0}", "YEAR");
            for (Int16 testMonth = 1; testMonth <= 12; testMonth++)
            {
                protokol.Write("\t{0}", testMonth);
            }
            protokol.WriteLine("");
        }

        protected void LogExampleEnd(StreamWriter protokol)
        {
            protokol.WriteLine("");
        }

        protected void LogTestExamples(string fileName, TestIntScenario[] tests)
        {
            using (var testLogger = CreateLoggerFile(fileName))
            {
                LogExampleStart(testLogger);

                foreach (var tx in tests)
                {
                    LogExampleYear(testLogger, tx.testTitle);

                    foreach (var tt in tx.tests)
                    {
                        LogExampleValue(testLogger, tt.resultValue);
                    }
                    LogExampleEnd(testLogger);
                }
            }
        }
        protected void LogExampleValue(StreamWriter protokol, Int32 resultValue)
        {
            protokol.Write("\t{0}", resultValue);
        }
        protected void LogTestExamples(string fileName, TestDecScenario[] tests)
        {
            using (var testLogger = CreateLoggerFile(fileName))
            {
                LogExampleStart(testLogger);

                foreach (var tx in tests)
                {
                    LogExampleYear(testLogger, tx.testTitle);

                    foreach (var tt in tx.tests)
                    {
                        LogExampleValue(testLogger, tt.resultValue);
                    }
                    LogExampleEnd(testLogger);
                }
            }
        }
        protected void LogExampleValue(StreamWriter protokol, decimal resultValue)
        {
            Int32 intValue = Convert.ToInt32(resultValue * 100);
            protokol.Write("\t{0}", intValue);
        }
    }

    public record TestScenario(string testTitle, TestParams[] tests);
    public record TestParams(string testName, Int16 testYear, Int16 testMonth, Int16 resultYear);
    public record TestData(string testTitle, TestParams test);
    public record TestIntScenario(string testTitle, TestIntParams[] tests);
    public record TestIntParams(string testName, Int16 testYear, Int16 testMonth, Int16 resultYear, Int16 resultMonth, Int32 resultValue);
    public record TestIntData(string testTitle, TestIntParams test);
    public record TestDecScenario(string testTitle, TestDecParams[] tests);
    public record TestDecParams(string testName, Int16 testYear, Int16 testMonth, Int16 resultYear, Int16 resultMonth, Decimal resultValue);
    public record TestDecData(string testTitle, TestDecParams test);
}
