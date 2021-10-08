using FluentAssertions;
using HraveMzdy.Legalios.Factories;
using HraveMzdy.Legalios.Providers;
using HraveMzdy.Legalios.Service.Types;
using System;
using System.IO;

namespace LegaliosUnitTest
{
    public class ProtokolBaseTest
    {
#if __MACOS__
        public const string PROTOKOL_TEST_FOLDER = "../../../test_values";
#else
        public const string PROTOKOL_TEST_FOLDER = "..\\..\\..\\test_values";
#endif

        protected string TestFolder {get;}
        public ProtokolBaseTest(string testFolder)
        {
            TestFolder = testFolder;
        }

        protected StreamWriter CreateProtokolFile(string fileName)
        {
            string filePath = Path.Combine(TestFolder, fileName);

            return File.CreateText(filePath);
        }

        protected void ExportPropsLine<B, P>(StreamWriter protokol, Int16 testYear, IProviderFactory<B, P> sut, Func<P, Int32> func) where B : IPropsProvider<P>
        {
            ExportPropsYear(protokol, testYear);

            for (Int16 testMonth = 1; testMonth <= 12; testMonth++)
            {
                var testPeriod = new Period(testYear, testMonth);

                var testResult = sut.GetProps(testPeriod);

                Int32 testValue = 0;
                if (testResult != null)
                {
                    testValue = func.Invoke(testResult);
                }
                ExportPropsValue(protokol, testValue);
            }
            
            ExportPropsEnd(protokol);
        }

        protected void ExportPropsValue(StreamWriter protokol, Int32 value)
        {
            protokol.Write("\t{0}", value);
        }

        protected void ExportPropsLine<B, P>(StreamWriter protokol, Int16 testYear, IProviderFactory<B, P> sut, Func<P, decimal> func) where B : IPropsProvider<P>
        {
            ExportPropsYear(protokol, testYear);

            for (Int16 testMonth = 1; testMonth <= 12; testMonth++)
            {
                var testPeriod = new Period(testYear, testMonth);

                var testResult = sut.GetProps(testPeriod);

                decimal testValue = 0;
                if (testResult != null)
                {
                    testValue = func.Invoke(testResult);
                }
                ExportPropsValue(protokol, testValue);
            }
            
            ExportPropsEnd(protokol);
        }

        protected void ExportPropsValue(StreamWriter protokol, decimal value)
        {
            Int32 intValue = Convert.ToInt32(value * 100);
            protokol.Write("\t{0}", intValue);
//            protokol.Write("\t{0}", value.ToString(CultureInfo.CreateSpecificCulture("en-US")));
        }

        protected void ExportPropsYear(StreamWriter protokol, Int16 value)
        {
            protokol.Write("{0}", value);
        }

        protected void ExportPropsStart(StreamWriter protokol)
        {
            protokol.Write("{0}", "YEAR");
            for (Int16 testMonth = 1; testMonth <= 12; testMonth++)
            {
                protokol.Write("\t{0}", testMonth);
            }
            protokol.WriteLine("");
        }

        protected void ExportPropsEnd(StreamWriter protokol)
        {
            protokol.WriteLine("");
        }

    }
}
