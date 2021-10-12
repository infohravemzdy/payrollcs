using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog;
using NLog.Config;
using NLog.Targets;
using Xunit;
using LegaliosTests;

namespace LegaliosTest.Service
{
    [CollectionDefinition("TestEngine")]
    public class Service_Legalios_Example_BaseTest : LegaliosBaseTest
    {
#if __MACOS__
        public const string EXAMPLE_TEST_FOLDER = "../../../test_expected";
#else
        public const string EXAMPLE_TEST_FOLDER = "..\\..\\..\\test_expected";
#endif

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
}
