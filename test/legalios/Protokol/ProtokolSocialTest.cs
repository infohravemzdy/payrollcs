using System;
using HraveMzdy.Legalios.Factories;
using HraveMzdy.Legalios.Providers;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Interfaces;
using Xunit;

namespace LegaliosUnitTest
{
    public class ProtokolSocialTest : ProtokolBaseTest
    {
        private readonly IProviderFactory<IProviderSocial, IPropsSocial> _sut;
        public ProtokolSocialTest() : base(PROTOKOL_TEST_FOLDER)
        {
            _sut = new FactorySocial();
        }

#if __PROTOKOL_TEST_FILE__
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_MaxAnnualsBasis(Int16 testMinYear, Int16 testMaxYear)
        {
            // 03_Social_01_MaxAnnualsBasis
            using (var testProtokol = CreateProtokolFile("03_Social_01_MaxAnnualsBasis.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MaxAnnualsBasis)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_FactorEmployer(Int16 testMinYear, Int16 testMaxYear)
        {
            // 03_Social_02_FactorEmployer
            using (var testProtokol = CreateProtokolFile("03_Social_02_FactorEmployer.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.FactorEmployer)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_FactorEmployerHigher(Int16 testMinYear, Int16 testMaxYear)
        {
            // 03_Social_03_FactorEmployerHigher
            using (var testProtokol = CreateProtokolFile("03_Social_03_FactorEmployerHigher.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.FactorEmployerHigher)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_FactorEmployee(Int16 testMinYear, Int16 testMaxYear)
        {
            // 03_Social_04_FactorEmployee
            using (var testProtokol = CreateProtokolFile("03_Social_04_FactorEmployee.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.FactorEmployee)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_FactorEmployeeGarant(Int16 testMinYear, Int16 testMaxYear)
        {
            // 03_Social_05_FactorEmployeeGarant
            using (var testProtokol = CreateProtokolFile("03_Social_05_FactorEmployeeGarant.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.FactorEmployeeGarant)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_FactorEmployeeReduce(Int16 testMinYear, Int16 testMaxYear)
        {
            // 03_Social_06_FactorEmployeeReduce
            using (var testProtokol = CreateProtokolFile("03_Social_06_FactorEmployeeReduce.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.FactorEmployeeReduce)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_MarginIncomeEmp(Int16 testMinYear, Int16 testMaxYear)
        {
            // 03_Social_07_MarginIncomeEmp
            using (var testProtokol = CreateProtokolFile("03_Social_07_MarginIncomeEmp.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MarginIncomeEmp)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_MarginIncomeAgr(Int16 testMinYear, Int16 testMaxYear)
        {
            // 03_Social_08_MarginIncomeAgr
            using (var testProtokol = CreateProtokolFile("03_Social_08_MarginIncomeAgr.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MarginIncomeAgr)));
                }
            }
        }
#endif
    }
}
