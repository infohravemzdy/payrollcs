using System;
using HraveMzdy.Legalios.Factories;
using HraveMzdy.Legalios.Providers;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Interfaces;
using Xunit;

namespace LegaliosUnitTest
{
    public class ProtokolSalaryTest : ProtokolBaseTest
    {
        private readonly IProviderFactory<IProviderSalary, IPropsSalary> _sut;
        public ProtokolSalaryTest() : base(PROTOKOL_TEST_FOLDER)
        {
            _sut = new FactorySalary();
        }

#if __PROTOKOL_TEST_FILE__
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_WorkingShiftWeek(Int16 testMinYear, Int16 testMaxYear)
        {
            // 02_Salary_01_WorkingShiftWeek
            using (var testProtokol = CreateProtokolFile("02_Salary_01_WorkingShiftWeek.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.WorkingShiftWeek)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_WorkingShiftTime(Int16 testMinYear, Int16 testMaxYear)
        {
            // 02_Salary_02_WorkingShiftTime
            using (var testProtokol = CreateProtokolFile("02_Salary_02_WorkingShiftTime.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.WorkingShiftTime)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_MinMonthlyWage(Int16 testMinYear, Int16 testMaxYear)
        {
            // 02_Salary_03_MinMonthlyWage
            using (var testProtokol = CreateProtokolFile("02_Salary_03_MinMonthlyWage.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MinMonthlyWage)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_MinHourlyWage(Int16 testMinYear, Int16 testMaxYear)
        {
            // 02_Salary_04_MinHourlyWage
            using (var testProtokol = CreateProtokolFile("02_Salary_04_MinHourlyWage.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MinHourlyWage)));
                }
            }
        }
#endif
    }
}
