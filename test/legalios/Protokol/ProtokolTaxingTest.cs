using System;
using HraveMzdy.Legalios.Factories;
using HraveMzdy.Legalios.Providers;
using HraveMzdy.Legalios.Service.Interfaces;
using Xunit;

namespace LegaliosTest.Protokol
{
    public class ProtokolTaxingTest : ProtokolBaseTest
    {
        private readonly IProviderFactory<IProviderTaxing, IPropsTaxing> _sut;
        public ProtokolTaxingTest() : base(PROTOKOL_TEST_FOLDER)
        {
            _sut = new FactoryTaxing();
        }

#if __PROTOKOL_TEST_FILE__
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_AllowancePayer(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_01_AllowancePayer
            using (var testProtokol = CreateProtokolFile("04_Taxing_01_AllowancePayer.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.AllowancePayer)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_AllowanceDisab1st(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_02_AllowanceDisab1st
            using (var testProtokol = CreateProtokolFile("04_Taxing_02_AllowanceDisab1st.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.AllowanceDisab1st)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_AllowanceDisab2nd(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_03_AllowanceDisab2nd
            using (var testProtokol = CreateProtokolFile("04_Taxing_03_AllowanceDisab2nd.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.AllowanceDisab2nd)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_AllowanceDisab3rd(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_04_AllowanceDisab3rd
            using (var testProtokol = CreateProtokolFile("04_Taxing_04_AllowanceDisab3rd.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.AllowanceDisab3rd)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_AllowanceStudy(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_05_AllowanceStudy
            using (var testProtokol = CreateProtokolFile("04_Taxing_05_AllowanceStudy.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.AllowanceStudy)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_AllowanceChild1st(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_06_AllowanceChild1st
            using (var testProtokol = CreateProtokolFile("04_Taxing_06_AllowanceChild1st.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.AllowanceChild1st)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_AllowanceChild2nd(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_07_AllowanceChild2nd
            using (var testProtokol = CreateProtokolFile("04_Taxing_07_AllowanceChild2nd.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.AllowanceChild2nd)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_AllowanceChild3rd(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_08_AllowanceChild3rd
            using (var testProtokol = CreateProtokolFile("04_Taxing_08_AllowanceChild3rd.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.AllowanceChild3rd)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_FactorAdvances(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_09_FactorAdvances
            using (var testProtokol = CreateProtokolFile("04_Taxing_09_FactorAdvances.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.FactorAdvances)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_FactorWithhold(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_10_FactorWithhold
            using (var testProtokol = CreateProtokolFile("04_Taxing_10_FactorWithhold.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.FactorWithhold)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_FactorSolidary(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_11_FactorSolidary
            using (var testProtokol = CreateProtokolFile("04_Taxing_11_FactorSolidary.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.FactorSolidary)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_MinAmountOfTaxBonus(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_12_MinAmountOfTaxBonus
            using (var testProtokol = CreateProtokolFile("04_Taxing_12_MinAmountOfTaxBonus.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MinAmountOfTaxBonus)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_MaxAmountOfTaxBonus(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_13_MaxAmountOfTaxBonus
            using (var testProtokol = CreateProtokolFile("04_Taxing_13_MaxAmountOfTaxBonus.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MaxAmountOfTaxBonus)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_MarginIncomeOfTaxBonus(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_14_MarginIncomeOfTaxBonus
            using (var testProtokol = CreateProtokolFile("04_Taxing_14_MarginIncomeOfTaxBonus.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MarginIncomeOfTaxBonus)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_MarginIncomeOfRounding(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_15_MarginIncomeOfRounding
            using (var testProtokol = CreateProtokolFile("04_Taxing_15_MarginIncomeOfRounding.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MarginIncomeOfRounding)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_MarginIncomeOfWithhold(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_16_MarginIncomeOfWithhold
            using (var testProtokol = CreateProtokolFile("04_Taxing_16_MarginIncomeOfWithhold.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MarginIncomeOfWithhold)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_MarginIncomeOfSolidary(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_17_MarginIncomeOfSolidary
            using (var testProtokol = CreateProtokolFile("04_Taxing_17_MarginIncomeOfSolidary.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MarginIncomeOfSolidary)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_MarginIncomeOfWthEmp(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_18_MarginIncomeOfWthEmp
            using (var testProtokol = CreateProtokolFile("04_Taxing_18_MarginIncomeOfWthEmp.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MarginIncomeOfWthEmp)));
                }
            }
        }
        [Theory]
        [InlineData(2011, 2022)]
        public void GetProps_ShouldExport_MarginIncomeOfWthAgr(Int16 testMinYear, Int16 testMaxYear)
        {
            // 04_Taxing_19_MarginIncomeOfWthAgr
            using (var testProtokol = CreateProtokolFile("04_Taxing_19_MarginIncomeOfWthAgr.txt"))
            {
                ExportPropsStart(testProtokol);

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    ExportPropsLine(testProtokol, testYear, _sut, ((prop) => (prop.MarginIncomeOfWthAgr)));
                }
            }
        }
#endif
    }
}
