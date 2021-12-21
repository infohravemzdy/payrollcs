using System;
using HraveMzdy.Legalios.Factories;
using HraveMzdy.Legalios.Providers;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Interfaces;
using Xunit;

namespace LegaliosTest.Protokol
{
    public class ProtokolHealthTest : ProtokolBaseTest
    {
        private readonly IProviderFactory<IProviderHealth, IPropsHealth> _sut;
        public ProtokolHealthTest() : base(PROTOKOL_TEST_FOLDER)
        {
            _sut = new FactoryHealth();
        }

#if __PROTOKOL_TEST_FILE__
        [Theory]
        [InlineData(2010, 2022)]
        public void GetProps_ShouldExport_MinMonthlyBasis(Int16 testMinYear, Int16 testMaxYear)
        {
            // 01_Health_01_MinMonthlyBasis
            using (var testProtokol = CreateProtokolFile("01_Health_01_MinMonthlyBasis.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MinMonthlyBasis)));
                }
            }
        }

        [Theory]
        [InlineData(2010, 2022)]
        public void GetProps_ShouldExport_MaxAnnualsBasis(Int16 testMinYear, Int16 testMaxYear)
        {
            // 01_Health_02_MaxAnnualsBasis
            using (var testProtokol = CreateProtokolFile("01_Health_02_MaxAnnualsBasis.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MaxAnnualsBasis)));
                }
            }
        }

        [Theory]
        [InlineData(2010, 2022)]
        public void GetProps_ShouldExport_LimMonthlyState(Int16 testMinYear, Int16 testMaxYear)
        {
            // 01_Health_03_LimMonthlyState
            using (var testProtokol = CreateProtokolFile("01_Health_03_LimMonthlyState.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.LimMonthlyState)));
                }
            }
        }

        [Theory]
        [InlineData(2010, 2022)]
        public void GetProps_ShouldExport_LimMonthlyDis50(Int16 testMinYear, Int16 testMaxYear)
        {
            // 01_Health_04_LimMonthlyDis50
            using (var testProtokol = CreateProtokolFile("01_Health_04_LimMonthlyDis50.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.LimMonthlyDis50)));
                }
            }
        }

        [Theory]
        [InlineData(2010, 2022)]
        public void GetProps_ShouldExport_FactorCompound(Int16 testMinYear, Int16 testMaxYear)
        {
            // 01_Health_05_FactorCompound
            using (var testProtokol = CreateProtokolFile("01_Health_05_FactorCompound.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.FactorCompound)));
                }
            }
        }

        [Theory]
        [InlineData(2010, 2022)]
        public void GetProps_ShouldExport_FactorEmployee(Int16 testMinYear, Int16 testMaxYear)
        {
            // 01_Health_06_FactorEmployee
            using (var testProtokol = CreateProtokolFile("01_Health_06_FactorEmployee.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.FactorEmployee)));
                }
            }
        }

        [Theory]
        [InlineData(2010, 2022)]
        public void GetProps_ShouldExport_MarginIncomeEmp(Int16 testMinYear, Int16 testMaxYear)
        {
            // 01_Health_07_MarginIncomeEmp
            using (var testProtokol = CreateProtokolFile("01_Health_07_MarginIncomeEmp.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MarginIncomeEmp)));
                }
            }
        }

        [Theory]
        [InlineData(2010, 2022)]
        public void GetProps_ShouldExport_MarginIncomeAgr(Int16 testMinYear, Int16 testMaxYear)
        {
            // 01_Health_08_MarginIncomeAgr
            using (var testProtokol = CreateProtokolFile("01_Health_08_MarginIncomeAgr.txt"))
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
