using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Legalios.Factories;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Providers;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;
using LegaliosTest.Protokol;
using Xunit;

namespace LegaliosTests.History
{
    public class FactoriesHistoryTest : ProtokolBaseTest
    {
        public const Int32 HEALTH_MIN_MONTHLY_BASIS         = 101;
        public const Int32 HEALTH_MAX_ANNUALS_BASIS         = 102;
        public const Int32 HEALTH_LIM_MONTHLY_STATE         = 103;
        public const Int32 HEALTH_LIM_MONTHLY_DIS50         = 104;
        public const Int32 HEALTH_FACTOR_COMPOUND           = 105;
        public const Int32 HEALTH_FACTOR_EMPLOYEE           = 106;
        public const Int32 HEALTH_MARGIN_INCOME_EMP         = 107;
        public const Int32 HEALTH_MARGIN_INCOME_AGR         = 108;
                                                            
        public const Int32 SALARY_WORKING_SHIFT_WEEK        = 201;
        public const Int32 SALARY_WORKING_SHIFT_TIME        = 202;
        public const Int32 SALARY_MIN_MONTHLY_WAGE          = 203;
        public const Int32 SALARY_MIN_HOURLY_WAGE           = 204;
                                                            
        public const Int32 SOCIAL_MAX_ANNUALS_BASIS         = 301;
        public const Int32 SOCIAL_FACTOR_EMPLOYER           = 302;
        public const Int32 SOCIAL_FACTOR_EMPLOYER_HIGHER    = 303;
        public const Int32 SOCIAL_FACTOR_EMPLOYEE           = 304;
        public const Int32 SOCIAL_FACTOR_EMPLOYEE_GARANT    = 305;
        public const Int32 SOCIAL_FACTOR_EMPLOYEE_REDUCE    = 306;
        public const Int32 SOCIAL_MARGIN_INCOME_EMP         = 307;
        public const Int32 SOCIAL_MARGIN_INCOME_AGR         = 308;
                                                            
        public const Int32 TAXING_ALLOWANCE_PAYER           = 401;
        public const Int32 TAXING_ALLOWANCE_DISAB_1ST       = 402;
        public const Int32 TAXING_ALLOWANCE_DISAB_2ND       = 403;
        public const Int32 TAXING_ALLOWANCE_DISAB_3RD       = 404;
        public const Int32 TAXING_ALLOWANCE_STUDY           = 405;
        public const Int32 TAXING_ALLOWANCE_CHILD_1ST       = 406;
        public const Int32 TAXING_ALLOWANCE_CHILD_2ND       = 407;
        public const Int32 TAXING_ALLOWANCE_CHILD_3RD       = 408;
        public const Int32 TAXING_FACTOR_ADVANCES           = 409;
        public const Int32 TAXING_FACTOR_WITHHOLD           = 410;
        public const Int32 TAXING_FACTOR_SOLIDARY           = 411;
        public const Int32 TAXING_FACTOR_TAXRATE2           = 412;
        public const Int32 TAXING_MIN_AMOUNT_OF_TAXBONUS    = 413;
        public const Int32 TAXING_MAX_AMOUNT_OF_TAXBONUS    = 414;
        public const Int32 TAXING_MARGIN_INCOME_OF_TAXBONUS = 415;
        public const Int32 TAXING_MARGIN_INCOME_OF_ROUNDING = 416;
        public const Int32 TAXING_MARGIN_INCOME_OF_WITHHOLD = 417;
        public const Int32 TAXING_MARGIN_INCOME_OF_SOLIDARY = 418;
        public const Int32 TAXING_MARGIN_INCOME_OF_TAXRATE2 = 419;
        public const Int32 TAXING_MARGIN_INCOME_OF_WHT_EMP  = 420;
        public const Int32 TAXING_MARGIN_INCOME_OF_WHT_AGR  = 421;

        private readonly IProviderFactory<IProviderSalary, IPropsSalary> _sutSalary;
        private readonly IProviderFactory<IProviderHealth, IPropsHealth> _sutHealth;
        private readonly IProviderFactory<IProviderSocial, IPropsSocial> _sutSocial;
        private readonly IProviderFactory<IProviderTaxing, IPropsTaxing> _sutTaxing;

#if __MACOS__
        public const string HISTORY_TEST_FOLDER = "../../../test_history";
#else
        public const string HISTORY_TEST_FOLDER = "..\\..\\..\\test_history";
#endif

        public FactoriesHistoryTest() : base(HISTORY_TEST_FOLDER)
        {
            _sutSalary = new FactorySalary();
            _sutHealth = new FactoryHealth();
            _sutSocial = new FactorySocial();
            _sutTaxing = new FactoryTaxing();
        }
        [Theory]
        [InlineData(2010, 2022)]
        public void GetProps_ShouldExport_History(Int16 testMinYear, Int16 testMaxYear)
        {
            using (var testProtokol = CreateProtokolFile($"history_{testMinYear}_{testMaxYear}.xls"))
            {
                List<Tuple<Int16, bool>> headerData = new List<Tuple<short, bool>>();
                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    bool yearWithChanges = false;

                    IPeriod testPeriod = new Period(testYear, 1);

                    IPropsSalary testSalaryProp = _sutSalary.GetProps(testPeriod);
                    IPropsHealth testHealthProp = _sutHealth.GetProps(testPeriod);
                    IPropsSocial testSocialProp = _sutSocial.GetProps(testPeriod);
                    IPropsTaxing testTaxingProp = _sutTaxing.GetProps(testPeriod);

                    for (int testMonth = 2; testMonth <= 12; testMonth++)
                    {
                        IPeriod nextPeriod = new Period(testYear, testMonth);

                        IPropsSalary testSalaryNext = _sutSalary.GetProps(nextPeriod);
                        IPropsHealth testHealthNext = _sutHealth.GetProps(nextPeriod);
                        IPropsSocial testSocialNext = _sutSocial.GetProps(nextPeriod);
                        IPropsTaxing testTaxingNext = _sutTaxing.GetProps(nextPeriod);

                        if (testSalaryNext.ValueEquals(testSalaryProp)==false)
                        {
                            yearWithChanges = true;
                        }
                        if (testHealthNext.ValueEquals(testHealthProp) == false)
                        {
                            yearWithChanges = true;
                        }
                        if (testSocialNext.ValueEquals(testSocialProp) == false)
                        {
                            yearWithChanges = true;
                        }
                        if (testTaxingNext.ValueEquals(testTaxingProp) == false)
                        {
                            yearWithChanges = true;
                        }
                        testSalaryProp = testSalaryNext;
                        testHealthProp = testHealthNext;
                        testSocialProp = testSocialNext;
                        testTaxingProp = testTaxingNext;
                    }
                    headerData.Add(new Tuple<Int16, bool>(testYear, yearWithChanges));
                }

                ExportHistoryStart(testProtokol, headerData);

                List<Tuple<Int16, Int16, string, string>> VECT_HEALTH_MIN_MONTHLY_BASIS = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_HEALTH_MAX_ANNUALS_BASIS = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_HEALTH_LIM_MONTHLY_STATE = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_HEALTH_LIM_MONTHLY_DIS50 = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_HEALTH_FACTOR_COMPOUND = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_HEALTH_FACTOR_EMPLOYEE = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_HEALTH_MARGIN_INCOME_EMP = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_HEALTH_MARGIN_INCOME_AGR = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_SALARY_WORKING_SHIFT_WEEK = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_SALARY_WORKING_SHIFT_TIME = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_SALARY_MIN_MONTHLY_WAGE = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_SALARY_MIN_HOURLY_WAGE = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_SOCIAL_MAX_ANNUALS_BASIS = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_SOCIAL_FACTOR_EMPLOYER = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_SOCIAL_FACTOR_EMPLOYER_HIGHER = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_SOCIAL_FACTOR_EMPLOYEE = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_SOCIAL_FACTOR_EMPLOYEE_GARANT = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_SOCIAL_FACTOR_EMPLOYEE_REDUCE = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_SOCIAL_MARGIN_INCOME_EMP = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_SOCIAL_MARGIN_INCOME_AGR = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_ALLOWANCE_PAYER = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_ALLOWANCE_DISAB_1ST = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_ALLOWANCE_DISAB_2ND = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_ALLOWANCE_DISAB_3RD = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_ALLOWANCE_STUDY = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_ALLOWANCE_CHILD_1ST = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_ALLOWANCE_CHILD_2ND = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_ALLOWANCE_CHILD_3RD = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_FACTOR_ADVANCES = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_FACTOR_WITHHOLD = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_FACTOR_SOLIDARY = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_FACTOR_TAXRATE2 = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_MIN_AMOUNT_OF_TAXBONUS = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_MAX_AMOUNT_OF_TAXBONUS = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_MARGIN_INCOME_OF_TAXBONUS = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_MARGIN_INCOME_OF_ROUNDING = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_MARGIN_INCOME_OF_WITHHOLD = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_MARGIN_INCOME_OF_SOLIDARY = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_MARGIN_INCOME_OF_TAXRATE2 = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_MARGIN_INCOME_OF_WHT_EMP = new List<Tuple<Int16, Int16, string, string>>();
                List<Tuple<Int16, Int16, string, string>> VECT_TAXING_MARGIN_INCOME_OF_WHT_AGR = new List<Tuple<Int16, Int16, string, string>>();

                List<Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>> tableData = new List<Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>>() {
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(HEALTH_MIN_MONTHLY_BASIS         , VECT_HEALTH_MIN_MONTHLY_BASIS),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(HEALTH_MAX_ANNUALS_BASIS         , VECT_HEALTH_MAX_ANNUALS_BASIS),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(HEALTH_LIM_MONTHLY_STATE         , VECT_HEALTH_LIM_MONTHLY_STATE),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(HEALTH_LIM_MONTHLY_DIS50         , VECT_HEALTH_LIM_MONTHLY_DIS50),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(HEALTH_FACTOR_COMPOUND           , VECT_HEALTH_FACTOR_COMPOUND),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(HEALTH_FACTOR_EMPLOYEE           , VECT_HEALTH_FACTOR_EMPLOYEE),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(HEALTH_MARGIN_INCOME_EMP         , VECT_HEALTH_MARGIN_INCOME_EMP),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(HEALTH_MARGIN_INCOME_AGR         , VECT_HEALTH_MARGIN_INCOME_AGR),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(SALARY_WORKING_SHIFT_WEEK        , VECT_SALARY_WORKING_SHIFT_WEEK),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(SALARY_WORKING_SHIFT_TIME        , VECT_SALARY_WORKING_SHIFT_TIME),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(SALARY_MIN_MONTHLY_WAGE          , VECT_SALARY_MIN_MONTHLY_WAGE),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(SALARY_MIN_HOURLY_WAGE           , VECT_SALARY_MIN_HOURLY_WAGE),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(SOCIAL_MAX_ANNUALS_BASIS         , VECT_SOCIAL_MAX_ANNUALS_BASIS),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(SOCIAL_FACTOR_EMPLOYER           , VECT_SOCIAL_FACTOR_EMPLOYER),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(SOCIAL_FACTOR_EMPLOYER_HIGHER    , VECT_SOCIAL_FACTOR_EMPLOYER_HIGHER),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(SOCIAL_FACTOR_EMPLOYEE           , VECT_SOCIAL_FACTOR_EMPLOYEE),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(SOCIAL_FACTOR_EMPLOYEE_GARANT    , VECT_SOCIAL_FACTOR_EMPLOYEE_GARANT),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(SOCIAL_FACTOR_EMPLOYEE_REDUCE    , VECT_SOCIAL_FACTOR_EMPLOYEE_REDUCE),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(SOCIAL_MARGIN_INCOME_EMP         , VECT_SOCIAL_MARGIN_INCOME_EMP),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(SOCIAL_MARGIN_INCOME_AGR         , VECT_SOCIAL_MARGIN_INCOME_AGR),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_ALLOWANCE_PAYER           , VECT_TAXING_ALLOWANCE_PAYER),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_ALLOWANCE_DISAB_1ST       , VECT_TAXING_ALLOWANCE_DISAB_1ST),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_ALLOWANCE_DISAB_2ND       , VECT_TAXING_ALLOWANCE_DISAB_2ND),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_ALLOWANCE_DISAB_3RD       , VECT_TAXING_ALLOWANCE_DISAB_3RD),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_ALLOWANCE_STUDY           , VECT_TAXING_ALLOWANCE_STUDY),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_ALLOWANCE_CHILD_1ST       , VECT_TAXING_ALLOWANCE_CHILD_1ST),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_ALLOWANCE_CHILD_2ND       , VECT_TAXING_ALLOWANCE_CHILD_2ND),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_ALLOWANCE_CHILD_3RD       , VECT_TAXING_ALLOWANCE_CHILD_3RD),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_FACTOR_ADVANCES           , VECT_TAXING_FACTOR_ADVANCES),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_FACTOR_WITHHOLD           , VECT_TAXING_FACTOR_WITHHOLD),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_FACTOR_SOLIDARY           , VECT_TAXING_FACTOR_SOLIDARY),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_FACTOR_TAXRATE2           , VECT_TAXING_FACTOR_TAXRATE2),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_MIN_AMOUNT_OF_TAXBONUS    , VECT_TAXING_MIN_AMOUNT_OF_TAXBONUS),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_MAX_AMOUNT_OF_TAXBONUS    , VECT_TAXING_MAX_AMOUNT_OF_TAXBONUS),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_MARGIN_INCOME_OF_TAXBONUS , VECT_TAXING_MARGIN_INCOME_OF_TAXBONUS),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_MARGIN_INCOME_OF_ROUNDING , VECT_TAXING_MARGIN_INCOME_OF_ROUNDING),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_MARGIN_INCOME_OF_WITHHOLD , VECT_TAXING_MARGIN_INCOME_OF_WITHHOLD),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_MARGIN_INCOME_OF_SOLIDARY , VECT_TAXING_MARGIN_INCOME_OF_SOLIDARY),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_MARGIN_INCOME_OF_TAXRATE2 , VECT_TAXING_MARGIN_INCOME_OF_TAXRATE2),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_MARGIN_INCOME_OF_WHT_EMP  , VECT_TAXING_MARGIN_INCOME_OF_WHT_EMP),
                    new Tuple<Int32, List<Tuple<Int16, Int16, string, string>>>(TAXING_MARGIN_INCOME_OF_WHT_AGR  , VECT_TAXING_MARGIN_INCOME_OF_WHT_AGR),
                };

                for (Int16 testYear = testMinYear; testYear <= testMaxYear; testYear++)
                {
                    Int16 MES_HEALTH_MIN_MONTHLY_BASIS         = 0;
                    Int16 MES_HEALTH_MAX_ANNUALS_BASIS         = 0;
                    Int16 MES_HEALTH_LIM_MONTHLY_STATE         = 0;
                    Int16 MES_HEALTH_LIM_MONTHLY_DIS50         = 0;
                    Int16 MES_HEALTH_FACTOR_COMPOUND           = 0;
                    Int16 MES_HEALTH_FACTOR_EMPLOYEE           = 0;
                    Int16 MES_HEALTH_MARGIN_INCOME_EMP         = 0;
                    Int16 MES_HEALTH_MARGIN_INCOME_AGR         = 0;
                    Int16 MES_SALARY_WORKING_SHIFT_WEEK        = 0;
                    Int16 MES_SALARY_WORKING_SHIFT_TIME        = 0;
                    Int16 MES_SALARY_MIN_MONTHLY_WAGE          = 0;
                    Int16 MES_SALARY_MIN_HOURLY_WAGE           = 0;
                    Int16 MES_SOCIAL_MAX_ANNUALS_BASIS         = 0;
                    Int16 MES_SOCIAL_FACTOR_EMPLOYER           = 0;
                    Int16 MES_SOCIAL_FACTOR_EMPLOYER_HIGHER    = 0;
                    Int16 MES_SOCIAL_FACTOR_EMPLOYEE           = 0;
                    Int16 MES_SOCIAL_FACTOR_EMPLOYEE_GARANT    = 0;
                    Int16 MES_SOCIAL_FACTOR_EMPLOYEE_REDUCE    = 0;
                    Int16 MES_SOCIAL_MARGIN_INCOME_EMP         = 0;
                    Int16 MES_SOCIAL_MARGIN_INCOME_AGR         = 0;
                    Int16 MES_TAXING_ALLOWANCE_PAYER           = 0;
                    Int16 MES_TAXING_ALLOWANCE_DISAB_1ST       = 0;
                    Int16 MES_TAXING_ALLOWANCE_DISAB_2ND       = 0;
                    Int16 MES_TAXING_ALLOWANCE_DISAB_3RD       = 0;
                    Int16 MES_TAXING_ALLOWANCE_STUDY           = 0;
                    Int16 MES_TAXING_ALLOWANCE_CHILD_1ST       = 0;
                    Int16 MES_TAXING_ALLOWANCE_CHILD_2ND       = 0;
                    Int16 MES_TAXING_ALLOWANCE_CHILD_3RD       = 0;
                    Int16 MES_TAXING_FACTOR_ADVANCES           = 0;
                    Int16 MES_TAXING_FACTOR_WITHHOLD           = 0;
                    Int16 MES_TAXING_FACTOR_SOLIDARY           = 0;
                    Int16 MES_TAXING_FACTOR_TAXRATE2           = 0;
                    Int16 MES_TAXING_MIN_AMOUNT_OF_TAXBONUS    = 0;
                    Int16 MES_TAXING_MAX_AMOUNT_OF_TAXBONUS    = 0;
                    Int16 MES_TAXING_MARGIN_INCOME_OF_TAXBONUS = 0;
                    Int16 MES_TAXING_MARGIN_INCOME_OF_ROUNDING = 0;
                    Int16 MES_TAXING_MARGIN_INCOME_OF_WITHHOLD = 0;
                    Int16 MES_TAXING_MARGIN_INCOME_OF_SOLIDARY = 0;
                    Int16 MES_TAXING_MARGIN_INCOME_OF_TAXRATE2 = 0;
                    Int16 MES_TAXING_MARGIN_INCOME_OF_WHT_EMP  = 0;
                    Int16 MES_TAXING_MARGIN_INCOME_OF_WHT_AGR  = 0;

                    IPeriod testPeriod = new Period(testYear, 1);

                    IPropsSalary testSalaryProp = _sutSalary.GetProps(testPeriod);
                    IPropsHealth testHealthProp = _sutHealth.GetProps(testPeriod);
                    IPropsSocial testSocialProp = _sutSocial.GetProps(testPeriod);
                    IPropsTaxing testTaxingProp = _sutTaxing.GetProps(testPeriod);

                    string JAN_HEALTH_MIN_MONTHLY_BASIS         = PropsValueToString(testHealthProp.MinMonthlyBasis);
                    string JAN_HEALTH_MAX_ANNUALS_BASIS         = PropsValueToString(testHealthProp.MaxAnnualsBasis);
                    string JAN_HEALTH_LIM_MONTHLY_STATE         = PropsValueToString(testHealthProp.LimMonthlyState);
                    string JAN_HEALTH_LIM_MONTHLY_DIS50         = PropsValueToString(testHealthProp.LimMonthlyDis50);
                    string JAN_HEALTH_FACTOR_COMPOUND           = PropsValueToString(testHealthProp.FactorCompound );
                    string JAN_HEALTH_FACTOR_EMPLOYEE           = PropsValueToString(testHealthProp.FactorEmployee );
                    string JAN_HEALTH_MARGIN_INCOME_EMP         = PropsValueToString(testHealthProp.MarginIncomeEmp);
                    string JAN_HEALTH_MARGIN_INCOME_AGR         = PropsValueToString(testHealthProp.MarginIncomeAgr);
                    string JAN_SALARY_WORKING_SHIFT_WEEK        = PropsValueToString(testSalaryProp.WorkingShiftWeek);
                    string JAN_SALARY_WORKING_SHIFT_TIME        = PropsValueToString(testSalaryProp.WorkingShiftTime);
                    string JAN_SALARY_MIN_MONTHLY_WAGE          = PropsValueToString(testSalaryProp.MinMonthlyWage);
                    string JAN_SALARY_MIN_HOURLY_WAGE           = PropsValueToString(testSalaryProp.MinHourlyWage  );
                    string JAN_SOCIAL_MAX_ANNUALS_BASIS         = PropsValueToString(testSocialProp.MaxAnnualsBasis);
                    string JAN_SOCIAL_FACTOR_EMPLOYER           = PropsValueToString(testSocialProp.FactorEmployer);
                    string JAN_SOCIAL_FACTOR_EMPLOYER_HIGHER    = PropsValueToString(testSocialProp.FactorEmployerHigher);
                    string JAN_SOCIAL_FACTOR_EMPLOYEE           = PropsValueToString(testSocialProp.FactorEmployee);
                    string JAN_SOCIAL_FACTOR_EMPLOYEE_GARANT    = PropsValueToString(testSocialProp.FactorEmployeeGarant);
                    string JAN_SOCIAL_FACTOR_EMPLOYEE_REDUCE    = PropsValueToString(testSocialProp.FactorEmployeeReduce);
                    string JAN_SOCIAL_MARGIN_INCOME_EMP         = PropsValueToString(testSocialProp.MarginIncomeEmp);
                    string JAN_SOCIAL_MARGIN_INCOME_AGR         = PropsValueToString(testSocialProp.MarginIncomeAgr);
                    string JAN_TAXING_ALLOWANCE_PAYER           = PropsValueToString(testTaxingProp.AllowancePayer);
                    string JAN_TAXING_ALLOWANCE_DISAB_1ST       = PropsValueToString(testTaxingProp.AllowanceDisab1st );
                    string JAN_TAXING_ALLOWANCE_DISAB_2ND       = PropsValueToString(testTaxingProp.AllowanceDisab2nd );
                    string JAN_TAXING_ALLOWANCE_DISAB_3RD       = PropsValueToString(testTaxingProp.AllowanceDisab3rd );
                    string JAN_TAXING_ALLOWANCE_STUDY           = PropsValueToString(testTaxingProp.AllowanceStudy );
                    string JAN_TAXING_ALLOWANCE_CHILD_1ST       = PropsValueToString(testTaxingProp.AllowanceChild1st );
                    string JAN_TAXING_ALLOWANCE_CHILD_2ND       = PropsValueToString(testTaxingProp.AllowanceChild2nd );
                    string JAN_TAXING_ALLOWANCE_CHILD_3RD       = PropsValueToString(testTaxingProp.AllowanceChild3rd );
                    string JAN_TAXING_FACTOR_ADVANCES           = PropsValueToString(testTaxingProp.FactorAdvances );
                    string JAN_TAXING_FACTOR_WITHHOLD           = PropsValueToString(testTaxingProp.FactorWithhold );
                    string JAN_TAXING_FACTOR_SOLIDARY           = PropsValueToString(testTaxingProp.FactorSolidary );
                    string JAN_TAXING_FACTOR_TAXRATE2           = PropsValueToString(testTaxingProp.FactorTaxRate2 );
                    string JAN_TAXING_MIN_AMOUNT_OF_TAXBONUS    = PropsValueToString(testTaxingProp.MinAmountOfTaxBonus );
                    string JAN_TAXING_MAX_AMOUNT_OF_TAXBONUS    = PropsValueToString(testTaxingProp.MaxAmountOfTaxBonus );
                    string JAN_TAXING_MARGIN_INCOME_OF_TAXBONUS = PropsValueToString(testTaxingProp.MarginIncomeOfTaxBonus );
                    string JAN_TAXING_MARGIN_INCOME_OF_ROUNDING = PropsValueToString(testTaxingProp.MarginIncomeOfRounding );
                    string JAN_TAXING_MARGIN_INCOME_OF_WITHHOLD = PropsValueToString(testTaxingProp.MarginIncomeOfWithhold );
                    string JAN_TAXING_MARGIN_INCOME_OF_SOLIDARY = PropsValueToString(testTaxingProp.MarginIncomeOfSolidary );
                    string JAN_TAXING_MARGIN_INCOME_OF_TAXRATE2 = PropsValueToString(testTaxingProp.MarginIncomeOfTaxRate2 );
                    string JAN_TAXING_MARGIN_INCOME_OF_WHT_EMP  = PropsValueToString(testTaxingProp.MarginIncomeOfWthEmp );
                    string JAN_TAXING_MARGIN_INCOME_OF_WHT_AGR  = PropsValueToString(testTaxingProp.MarginIncomeOfWthAgr );

                    for (Int16 testMonth = 2; testMonth <= 12; testMonth++)
                    {
                        IPeriod nextPeriod = new Period(testYear, testMonth);

                        IPropsSalary testSalaryNext = _sutSalary.GetProps(nextPeriod);
                        IPropsHealth testHealthNext = _sutHealth.GetProps(nextPeriod);
                        IPropsSocial testSocialNext = _sutSocial.GetProps(nextPeriod);
                        IPropsTaxing testTaxingNext = _sutTaxing.GetProps(nextPeriod);

                        if (testHealthNext.MinMonthlyBasis.Equals(testHealthProp.MinMonthlyBasis)==false) { MES_HEALTH_MIN_MONTHLY_BASIS = testMonth; }
                        if (testHealthNext.MaxAnnualsBasis.Equals(testHealthProp.MaxAnnualsBasis)==false) { MES_HEALTH_MAX_ANNUALS_BASIS = testMonth; }
                        if (testHealthNext.LimMonthlyState.Equals(testHealthProp.LimMonthlyState)==false) { MES_HEALTH_LIM_MONTHLY_STATE = testMonth; }
                        if (testHealthNext.LimMonthlyDis50.Equals(testHealthProp.LimMonthlyDis50)==false) { MES_HEALTH_LIM_MONTHLY_DIS50 = testMonth; }
                        if (testHealthNext.FactorCompound.Equals(testHealthProp.FactorCompound)==false) { MES_HEALTH_FACTOR_COMPOUND = testMonth; }
                        if (testHealthNext.FactorEmployee.Equals(testHealthProp.FactorEmployee)==false) { MES_HEALTH_FACTOR_EMPLOYEE = testMonth; }
                        if (testHealthNext.MarginIncomeEmp.Equals(testHealthProp.MarginIncomeEmp)==false) { MES_HEALTH_MARGIN_INCOME_EMP = testMonth; }
                        if (testHealthNext.MarginIncomeAgr.Equals(testHealthProp.MarginIncomeAgr)==false) { MES_HEALTH_MARGIN_INCOME_AGR = testMonth; }
                        if (testSalaryNext.WorkingShiftWeek.Equals(testSalaryProp.WorkingShiftWeek)==false) { MES_SALARY_WORKING_SHIFT_WEEK = testMonth; }
                        if (testSalaryNext.WorkingShiftTime.Equals(testSalaryProp.WorkingShiftTime)==false) { MES_SALARY_WORKING_SHIFT_TIME = testMonth; }
                        if (testSalaryNext.MinMonthlyWage.Equals(testSalaryProp.MinMonthlyWage)==false) { MES_SALARY_MIN_MONTHLY_WAGE = testMonth; }
                        if (testSalaryNext.MinHourlyWage .Equals(testSalaryProp.MinHourlyWage)==false) { MES_SALARY_MIN_HOURLY_WAGE = testMonth; }
                        if (testSocialNext.MaxAnnualsBasis.Equals(testSocialProp.MaxAnnualsBasis)==false) { MES_SOCIAL_MAX_ANNUALS_BASIS = testMonth; }
                        if (testSocialNext.FactorEmployer.Equals(testSocialProp.FactorEmployer)==false) { MES_SOCIAL_FACTOR_EMPLOYER = testMonth; }
                        if (testSocialNext.FactorEmployerHigher.Equals(testSocialProp.FactorEmployerHigher)==false) { MES_SOCIAL_FACTOR_EMPLOYER_HIGHER = testMonth; }
                        if (testSocialNext.FactorEmployee.Equals(testSocialProp.FactorEmployee)==false) { MES_SOCIAL_FACTOR_EMPLOYEE = testMonth; }
                        if (testSocialNext.FactorEmployeeReduce.Equals(testSocialProp.FactorEmployeeReduce) == false) { MES_SOCIAL_FACTOR_EMPLOYEE_REDUCE = testMonth; }
                        if (testSocialNext.FactorEmployeeGarant.Equals(testSocialProp.FactorEmployeeGarant)==false) { MES_SOCIAL_FACTOR_EMPLOYEE_GARANT = testMonth; }
                        if (testSocialNext.MarginIncomeEmp.Equals(testSocialProp.MarginIncomeEmp)==false) { MES_SOCIAL_MARGIN_INCOME_EMP = testMonth; }
                        if (testSocialNext.MarginIncomeAgr.Equals(testSocialProp.MarginIncomeAgr)==false) { MES_SOCIAL_MARGIN_INCOME_AGR = testMonth; }
                        if (testTaxingNext.AllowancePayer.Equals(testTaxingProp.AllowancePayer)==false) { MES_TAXING_ALLOWANCE_PAYER = testMonth; }
                        if (testTaxingNext.AllowanceDisab1st.Equals(testTaxingProp.AllowanceDisab1st)==false) { MES_TAXING_ALLOWANCE_DISAB_1ST = testMonth; }
                        if (testTaxingNext.AllowanceDisab2nd.Equals(testTaxingProp.AllowanceDisab2nd)==false) { MES_TAXING_ALLOWANCE_DISAB_2ND = testMonth; }
                        if (testTaxingNext.AllowanceDisab3rd.Equals(testTaxingProp.AllowanceDisab3rd)==false) { MES_TAXING_ALLOWANCE_DISAB_3RD = testMonth; }
                        if (testTaxingNext.AllowanceStudy.Equals(testTaxingProp.AllowanceStudy)==false) { MES_TAXING_ALLOWANCE_STUDY = testMonth; }
                        if (testTaxingNext.AllowanceChild1st.Equals(testTaxingProp.AllowanceChild1st)==false) { MES_TAXING_ALLOWANCE_CHILD_1ST = testMonth; }
                        if (testTaxingNext.AllowanceChild2nd.Equals(testTaxingProp.AllowanceChild2nd)==false) { MES_TAXING_ALLOWANCE_CHILD_2ND = testMonth; }
                        if (testTaxingNext.AllowanceChild3rd.Equals(testTaxingProp.AllowanceChild3rd)==false) { MES_TAXING_ALLOWANCE_CHILD_3RD = testMonth; }
                        if (testTaxingNext.FactorAdvances.Equals(testTaxingProp.FactorAdvances)==false) { MES_TAXING_FACTOR_ADVANCES = testMonth; }
                        if (testTaxingNext.FactorWithhold.Equals(testTaxingProp.FactorWithhold)==false) { MES_TAXING_FACTOR_WITHHOLD = testMonth; }
                        if (testTaxingNext.FactorSolidary.Equals(testTaxingProp.FactorSolidary)==false) { MES_TAXING_FACTOR_SOLIDARY = testMonth; }
                        if (testTaxingNext.FactorTaxRate2.Equals(testTaxingProp.FactorTaxRate2)==false) { MES_TAXING_FACTOR_TAXRATE2 = testMonth; }
                        if (testTaxingNext.MinAmountOfTaxBonus.Equals(testTaxingProp.MinAmountOfTaxBonus)==false) { MES_TAXING_MIN_AMOUNT_OF_TAXBONUS = testMonth; }
                        if (testTaxingNext.MaxAmountOfTaxBonus.Equals(testTaxingProp.MaxAmountOfTaxBonus)==false) { MES_TAXING_MAX_AMOUNT_OF_TAXBONUS = testMonth; }
                        if (testTaxingNext.MarginIncomeOfTaxBonus.Equals(testTaxingProp.MarginIncomeOfTaxBonus)==false) { MES_TAXING_MARGIN_INCOME_OF_TAXBONUS = testMonth; }
                        if (testTaxingNext.MarginIncomeOfRounding.Equals(testTaxingProp.MarginIncomeOfRounding)==false) { MES_TAXING_MARGIN_INCOME_OF_ROUNDING = testMonth; }
                        if (testTaxingNext.MarginIncomeOfWithhold.Equals(testTaxingProp.MarginIncomeOfWithhold)==false) { MES_TAXING_MARGIN_INCOME_OF_WITHHOLD = testMonth; }
                        if (testTaxingNext.MarginIncomeOfSolidary.Equals(testTaxingProp.MarginIncomeOfSolidary)==false) { MES_TAXING_MARGIN_INCOME_OF_SOLIDARY = testMonth; }
                        if (testTaxingNext.MarginIncomeOfTaxRate2.Equals(testTaxingProp.MarginIncomeOfTaxRate2)==false) { MES_TAXING_MARGIN_INCOME_OF_TAXRATE2 = testMonth; }
                        if (testTaxingNext.MarginIncomeOfWthEmp.Equals(testTaxingProp.MarginIncomeOfWthEmp)==false) { MES_TAXING_MARGIN_INCOME_OF_WHT_EMP = testMonth; }
                        if (testTaxingNext.MarginIncomeOfWthAgr.Equals(testTaxingProp.MarginIncomeOfWthAgr)==false) { MES_TAXING_MARGIN_INCOME_OF_WHT_AGR = testMonth; }

                        testSalaryProp = testSalaryNext;
                        testHealthProp = testHealthNext;
                        testSocialProp = testSocialNext;
                        testTaxingProp = testTaxingNext;
                    }

                    VECT_HEALTH_MIN_MONTHLY_BASIS.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_HEALTH_MIN_MONTHLY_BASIS, JAN_HEALTH_MIN_MONTHLY_BASIS, PropsValueToString(testHealthProp.MinMonthlyBasis)));
                    VECT_HEALTH_MAX_ANNUALS_BASIS.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_HEALTH_MAX_ANNUALS_BASIS, JAN_HEALTH_MAX_ANNUALS_BASIS, PropsValueToString(testHealthProp.MaxAnnualsBasis)));
                    VECT_HEALTH_LIM_MONTHLY_STATE.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_HEALTH_LIM_MONTHLY_STATE, JAN_HEALTH_LIM_MONTHLY_STATE, PropsValueToString(testHealthProp.LimMonthlyState)));
                    VECT_HEALTH_LIM_MONTHLY_DIS50.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_HEALTH_LIM_MONTHLY_DIS50, JAN_HEALTH_LIM_MONTHLY_DIS50, PropsValueToString(testHealthProp.LimMonthlyDis50)));
                    VECT_HEALTH_FACTOR_COMPOUND.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_HEALTH_FACTOR_COMPOUND, JAN_HEALTH_FACTOR_COMPOUND, PropsValueToString(testHealthProp.FactorCompound)));
                    VECT_HEALTH_FACTOR_EMPLOYEE.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_HEALTH_FACTOR_EMPLOYEE, JAN_HEALTH_FACTOR_EMPLOYEE, PropsValueToString(testHealthProp.FactorEmployee)));
                    VECT_HEALTH_MARGIN_INCOME_EMP.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_HEALTH_MARGIN_INCOME_EMP, JAN_HEALTH_MARGIN_INCOME_EMP, PropsValueToString(testHealthProp.MarginIncomeEmp)));
                    VECT_HEALTH_MARGIN_INCOME_AGR.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_HEALTH_MARGIN_INCOME_AGR, JAN_HEALTH_MARGIN_INCOME_AGR, PropsValueToString(testHealthProp.MarginIncomeAgr)));
                    VECT_SALARY_WORKING_SHIFT_WEEK.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_SALARY_WORKING_SHIFT_WEEK, JAN_SALARY_WORKING_SHIFT_WEEK, PropsValueToString(testSalaryProp.WorkingShiftWeek)));
                    VECT_SALARY_WORKING_SHIFT_TIME.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_SALARY_WORKING_SHIFT_TIME, JAN_SALARY_WORKING_SHIFT_TIME, PropsValueToString(testSalaryProp.WorkingShiftTime)));
                    VECT_SALARY_MIN_MONTHLY_WAGE.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_SALARY_MIN_MONTHLY_WAGE, JAN_SALARY_MIN_MONTHLY_WAGE, PropsValueToString(testSalaryProp.MinMonthlyWage)));
                    VECT_SALARY_MIN_HOURLY_WAGE.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_SALARY_MIN_HOURLY_WAGE, JAN_SALARY_MIN_HOURLY_WAGE, PropsValueToString(testSalaryProp.MinHourlyWage)));
                    VECT_SOCIAL_MAX_ANNUALS_BASIS.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_SOCIAL_MAX_ANNUALS_BASIS, JAN_SOCIAL_MAX_ANNUALS_BASIS, PropsValueToString(testSocialProp.MaxAnnualsBasis)));
                    VECT_SOCIAL_FACTOR_EMPLOYER.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_SOCIAL_FACTOR_EMPLOYER, JAN_SOCIAL_FACTOR_EMPLOYER, PropsValueToString(testSocialProp.FactorEmployer)));
                    VECT_SOCIAL_FACTOR_EMPLOYER_HIGHER.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_SOCIAL_FACTOR_EMPLOYER_HIGHER, JAN_SOCIAL_FACTOR_EMPLOYER_HIGHER, PropsValueToString(testSocialProp.FactorEmployerHigher)));
                    VECT_SOCIAL_FACTOR_EMPLOYEE.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_SOCIAL_FACTOR_EMPLOYEE, JAN_SOCIAL_FACTOR_EMPLOYEE, PropsValueToString(testSocialProp.FactorEmployee)));
                    VECT_SOCIAL_FACTOR_EMPLOYEE_GARANT.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_SOCIAL_FACTOR_EMPLOYEE_GARANT, JAN_SOCIAL_FACTOR_EMPLOYEE_GARANT, PropsValueToString(testSocialProp.FactorEmployeeGarant)));
                    VECT_SOCIAL_FACTOR_EMPLOYEE_REDUCE.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_SOCIAL_FACTOR_EMPLOYEE_REDUCE, JAN_SOCIAL_FACTOR_EMPLOYEE_REDUCE, PropsValueToString(testSocialProp.FactorEmployeeReduce)));
                    VECT_SOCIAL_MARGIN_INCOME_EMP.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_SOCIAL_MARGIN_INCOME_EMP, JAN_SOCIAL_MARGIN_INCOME_EMP, PropsValueToString(testSocialProp.MarginIncomeEmp)));
                    VECT_SOCIAL_MARGIN_INCOME_AGR.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_SOCIAL_MARGIN_INCOME_AGR, JAN_SOCIAL_MARGIN_INCOME_AGR, PropsValueToString(testSocialProp.MarginIncomeAgr)));
                    VECT_TAXING_ALLOWANCE_PAYER.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_ALLOWANCE_PAYER, JAN_TAXING_ALLOWANCE_PAYER, PropsValueToString(testTaxingProp.AllowancePayer)));
                    VECT_TAXING_ALLOWANCE_DISAB_1ST.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_ALLOWANCE_DISAB_1ST, JAN_TAXING_ALLOWANCE_DISAB_1ST, PropsValueToString(testTaxingProp.AllowanceDisab1st)));
                    VECT_TAXING_ALLOWANCE_DISAB_2ND.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_ALLOWANCE_DISAB_2ND, JAN_TAXING_ALLOWANCE_DISAB_2ND, PropsValueToString(testTaxingProp.AllowanceDisab2nd)));
                    VECT_TAXING_ALLOWANCE_DISAB_3RD.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_ALLOWANCE_DISAB_3RD, JAN_TAXING_ALLOWANCE_DISAB_3RD, PropsValueToString(testTaxingProp.AllowanceDisab3rd)));
                    VECT_TAXING_ALLOWANCE_STUDY.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_ALLOWANCE_STUDY, JAN_TAXING_ALLOWANCE_STUDY, PropsValueToString(testTaxingProp.AllowanceStudy)));
                    VECT_TAXING_ALLOWANCE_CHILD_1ST.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_ALLOWANCE_CHILD_1ST, JAN_TAXING_ALLOWANCE_CHILD_1ST, PropsValueToString(testTaxingProp.AllowanceChild1st)));
                    VECT_TAXING_ALLOWANCE_CHILD_2ND.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_ALLOWANCE_CHILD_2ND, JAN_TAXING_ALLOWANCE_CHILD_2ND, PropsValueToString(testTaxingProp.AllowanceChild2nd)));
                    VECT_TAXING_ALLOWANCE_CHILD_3RD.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_ALLOWANCE_CHILD_3RD, JAN_TAXING_ALLOWANCE_CHILD_3RD, PropsValueToString(testTaxingProp.AllowanceChild3rd)));
                    VECT_TAXING_FACTOR_ADVANCES.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_FACTOR_ADVANCES, JAN_TAXING_FACTOR_ADVANCES, PropsValueToString(testTaxingProp.FactorAdvances)));
                    VECT_TAXING_FACTOR_WITHHOLD.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_FACTOR_WITHHOLD, JAN_TAXING_FACTOR_WITHHOLD, PropsValueToString(testTaxingProp.FactorWithhold)));
                    VECT_TAXING_FACTOR_SOLIDARY.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_FACTOR_SOLIDARY, JAN_TAXING_FACTOR_SOLIDARY, PropsValueToString(testTaxingProp.FactorSolidary)));
                    VECT_TAXING_FACTOR_TAXRATE2.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_FACTOR_TAXRATE2, JAN_TAXING_FACTOR_TAXRATE2, PropsValueToString(testTaxingProp.FactorTaxRate2)));
                    VECT_TAXING_MIN_AMOUNT_OF_TAXBONUS.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_MIN_AMOUNT_OF_TAXBONUS, JAN_TAXING_MIN_AMOUNT_OF_TAXBONUS, PropsValueToString(testTaxingProp.MinAmountOfTaxBonus)));
                    VECT_TAXING_MAX_AMOUNT_OF_TAXBONUS.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_MAX_AMOUNT_OF_TAXBONUS, JAN_TAXING_MAX_AMOUNT_OF_TAXBONUS, PropsValueToString(testTaxingProp.MaxAmountOfTaxBonus)));
                    VECT_TAXING_MARGIN_INCOME_OF_TAXBONUS.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_MARGIN_INCOME_OF_TAXBONUS, JAN_TAXING_MARGIN_INCOME_OF_TAXBONUS, PropsValueToString(testTaxingProp.MarginIncomeOfTaxBonus)));
                    VECT_TAXING_MARGIN_INCOME_OF_ROUNDING.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_MARGIN_INCOME_OF_ROUNDING, JAN_TAXING_MARGIN_INCOME_OF_ROUNDING, PropsValueToString(testTaxingProp.MarginIncomeOfRounding)));
                    VECT_TAXING_MARGIN_INCOME_OF_WITHHOLD.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_MARGIN_INCOME_OF_WITHHOLD, JAN_TAXING_MARGIN_INCOME_OF_WITHHOLD, PropsValueToString(testTaxingProp.MarginIncomeOfWithhold)));
                    VECT_TAXING_MARGIN_INCOME_OF_SOLIDARY.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_MARGIN_INCOME_OF_SOLIDARY, JAN_TAXING_MARGIN_INCOME_OF_SOLIDARY, PropsValueToString(testTaxingProp.MarginIncomeOfSolidary)));
                    VECT_TAXING_MARGIN_INCOME_OF_TAXRATE2.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_MARGIN_INCOME_OF_TAXRATE2, JAN_TAXING_MARGIN_INCOME_OF_TAXRATE2, PropsValueToString(testTaxingProp.MarginIncomeOfTaxRate2)));
                    VECT_TAXING_MARGIN_INCOME_OF_WHT_EMP.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_MARGIN_INCOME_OF_WHT_EMP, JAN_TAXING_MARGIN_INCOME_OF_WHT_EMP, PropsValueToString(testTaxingProp.MarginIncomeOfWthEmp)));
                    VECT_TAXING_MARGIN_INCOME_OF_WHT_AGR.Add(new Tuple<Int16, Int16, string, string>(testYear, MES_TAXING_MARGIN_INCOME_OF_WHT_AGR, JAN_TAXING_MARGIN_INCOME_OF_WHT_AGR, PropsValueToString(testTaxingProp.MarginIncomeOfWthAgr)));
                }

                foreach (var data in tableData)
                {
                    ExportHistoryTerm(testProtokol, headerData, data);
                }
            }

        }

        private void ExportHistoryStart(StreamWriter protokol, List<Tuple<Int16, bool>> data)
        {
            protokol.Write("History Term");
            foreach (var col in data) {
                if (col.Item2)
                {
                    protokol.Write($"\t{col.Item1} Begin Value");
                    protokol.Write($"\t{col.Item1} Change Month");
                    protokol.Write($"\t{col.Item1} End Value");
                }
                else
                {
                    protokol.Write($"\t{col.Item1} Value");
                }
            }
            protokol.WriteLine("");
        }
        private void ExportHistoryTerm(StreamWriter protokol, List<Tuple<Int16, bool>> head, Tuple<Int32, List<Tuple<Int16, Int16, string, string>>> data)
        {
            protokol.Write(HistoryTermName(data.Item1));
            foreach (var col in data.Item2)
            {
                Tuple<Int16, bool> header = head.FirstOrDefault((x) => (x.Item1 == col.Item1));
                bool yearOfChange = false;
                if (header != null)
                {
                    yearOfChange = header.Item2;
                }
                protokol.Write($"\t{col.Item3}");
                if (yearOfChange)
                {
                    if (col.Item2 == 0)
                    {
                        protokol.Write($"\t");
                    }
                    else
                    {
                        protokol.Write($"\t{col.Item2}");
                    }
                    protokol.Write($"\t{col.Item4}");
                }
            }
            protokol.WriteLine("");
        }

        private string HistoryTermName(Int32 termId)
        {
            switch (termId)
            {
                case HEALTH_MIN_MONTHLY_BASIS:
                    return "01_Health_01_MinMonthlyBasis";
                case HEALTH_MAX_ANNUALS_BASIS:
                    return "01_Health_02_MaxAnnualsBasis";
                case HEALTH_LIM_MONTHLY_STATE:
                    return "01_Health_03_LimMonthlyState";
                case HEALTH_LIM_MONTHLY_DIS50:
                    return "01_Health_04_LimMonthlyDis50";
                case HEALTH_FACTOR_COMPOUND:
                    return "01_Health_05_FactorCompound";
                case HEALTH_FACTOR_EMPLOYEE:
                    return "01_Health_06_FactorEmployee";
                case HEALTH_MARGIN_INCOME_EMP:
                    return "01_Health_07_MarginIncomeEmp";
                case HEALTH_MARGIN_INCOME_AGR:
                    return "01_Health_08_MarginIncomeAgr";
                case SALARY_WORKING_SHIFT_WEEK:
                    return "02_Salary_01_WorkingShiftWeek";
                case SALARY_WORKING_SHIFT_TIME:
                    return "02_Salary_02_WorkingShiftTime";
                case SALARY_MIN_MONTHLY_WAGE:
                    return "02_Salary_03_MinMonthlyWage";
                case SALARY_MIN_HOURLY_WAGE:
                    return "02_Salary_04_MinHourlyWage";
                case SOCIAL_MAX_ANNUALS_BASIS:
                    return "03_Social_01_MaxAnnualsBasis";
                case SOCIAL_FACTOR_EMPLOYER:
                    return "03_Social_02_FactorEmployer";
                case SOCIAL_FACTOR_EMPLOYER_HIGHER:
                    return "03_Social_03_FactorEmployerHigher";
                case SOCIAL_FACTOR_EMPLOYEE:
                    return "03_Social_04_FactorEmployee";
                case SOCIAL_FACTOR_EMPLOYEE_GARANT:
                    return "03_Social_05_FactorEmployeeGarant";
                case SOCIAL_FACTOR_EMPLOYEE_REDUCE:
                    return "03_Social_06_FactorEmployeeReduce";
                case SOCIAL_MARGIN_INCOME_EMP:
                    return "03_Social_07_MarginIncomeEmp";
                case SOCIAL_MARGIN_INCOME_AGR:
                    return "03_Social_08_MarginIncomeAgr";
                case TAXING_ALLOWANCE_PAYER:
                    return "04_Taxing_01_AllowancePayer";
                case TAXING_ALLOWANCE_DISAB_1ST:
                    return "04_Taxing_02_AllowanceDisab1st";
                case TAXING_ALLOWANCE_DISAB_2ND:
                    return "04_Taxing_03_AllowanceDisab2nd";
                case TAXING_ALLOWANCE_DISAB_3RD:
                    return "04_Taxing_04_AllowanceDisab3rd";
                case TAXING_ALLOWANCE_STUDY:
                    return "04_Taxing_05_AllowanceStudy";
                case TAXING_ALLOWANCE_CHILD_1ST:
                    return "04_Taxing_06_AllowanceChild1st";
                case TAXING_ALLOWANCE_CHILD_2ND:
                    return "04_Taxing_07_AllowanceChild2nd";
                case TAXING_ALLOWANCE_CHILD_3RD:
                    return "04_Taxing_08_AllowanceChild3rd";
                case TAXING_FACTOR_ADVANCES:
                    return "04_Taxing_09_FactorAdvances";
                case TAXING_FACTOR_WITHHOLD:
                    return "04_Taxing_10_FactorWithhold";
                case TAXING_FACTOR_SOLIDARY:
                    return "04_Taxing_11_FactorSolidary";
                case TAXING_FACTOR_TAXRATE2:
                    return "04_Taxing_12_FactorTaxRate2";
                case TAXING_MIN_AMOUNT_OF_TAXBONUS:
                    return "04_Taxing_13_MinAmountOfTaxBonus";
                case TAXING_MAX_AMOUNT_OF_TAXBONUS:
                    return "04_Taxing_14_MaxAmountOfTaxBonus";
                case TAXING_MARGIN_INCOME_OF_TAXBONUS:
                    return "04_Taxing_15_MarginIncomeOfTaxBonus";
                case TAXING_MARGIN_INCOME_OF_ROUNDING:
                    return "04_Taxing_16_MarginIncomeOfRounding";
                case TAXING_MARGIN_INCOME_OF_WITHHOLD:
                    return "04_Taxing_17_MarginIncomeOfWithhold";
                case TAXING_MARGIN_INCOME_OF_SOLIDARY:
                    return "04_Taxing_18_MarginIncomeOfSolidary";
                case TAXING_MARGIN_INCOME_OF_TAXRATE2:
                    return "04_Taxing_18_MarginIncomeOfTaxRate2";
                case TAXING_MARGIN_INCOME_OF_WHT_EMP:
                    return "04_Taxing_20_MarginIncomeOfWthEmp";
                case TAXING_MARGIN_INCOME_OF_WHT_AGR:
                    return "04_Taxing_21_MarginIncomeOfWthAgr";
            }
            return "Unknown Term";
        }

        private string HistoryTermNameCZ(Int32 termId)
        {
            switch (termId)
            {
                case HEALTH_MIN_MONTHLY_BASIS:
                    return "01_Health_01 Minimální základ zdravotního pojištění na jednoho pracovníka";
                case HEALTH_MAX_ANNUALS_BASIS:
                    return "01_Health_02 Maximální roční vyměřovací základ na jednoho pracovníka (tzv.strop)";
                case HEALTH_LIM_MONTHLY_STATE:
                    return "01_Health_03 Vyměřovací základ ze kterého platí pojistné stát za státní pojištěnce (mateřská, studenti, důchodci)";
                case HEALTH_LIM_MONTHLY_DIS50:
                    return "01_Health_04 Vyměřovací základ ze kterého platí pojistné stát za státní pojištěnce (mateřská, studenti, důchodci) u zaměstnavatele zaměstnávajícího více než 50% osob OZP";
                case HEALTH_FACTOR_COMPOUND:
                    return "01_Health_05 složená sazba zdravotního pojištění (zaměstnace + zaměstnavatele)";
                case HEALTH_FACTOR_EMPLOYEE:
                    return "01_Health_06 podíl sazby zdravotního pojištění připadajícího na zaměstnace (1/FACTOR_EMPLOYEE)";
                case HEALTH_MARGIN_INCOME_EMP:
                    return "01_Health_07 hranice příjmu pro vznik účasti na pojištění pro zaměstnace v pracovním poměru";
                case HEALTH_MARGIN_INCOME_AGR:
                    return "01_Health_08 hranice příjmu pro vznik účasti na pojištění pro zaměstnace na dohodu";
                case SALARY_WORKING_SHIFT_WEEK:
                    return "02_Salary_01 Počet pracovních dnů v týdnu";
                case SALARY_WORKING_SHIFT_TIME:
                    return "02_Salary_02 Počet pracovních hodin denně";
                case SALARY_MIN_MONTHLY_WAGE:
                    return "02_Salary_03 Minimální mzda měsíční";
                case SALARY_MIN_HOURLY_WAGE:
                    return "02_Salary_04 Minimální mzda hodinová (100*Kč)";
                case SOCIAL_MAX_ANNUALS_BASIS:
                    return "03_Social_01 Maximální roční vyměřovací základ na jednoho pracovníka (tzv.strop)";
                case SOCIAL_FACTOR_EMPLOYER:
                    return "03_Social_02 Sazba - standardní sociálního pojištění - zaměstnavatele";
                case SOCIAL_FACTOR_EMPLOYER_HIGHER:
                    return "03_Social_03 Sazba - vyší sociálního pojištění - zaměstnavatele";
                case SOCIAL_FACTOR_EMPLOYEE:
                    return "03_Social_04 Sazba sociálního pojištění - zaměstnance";
                case SOCIAL_FACTOR_EMPLOYEE_GARANT:
                    return "03_Social_05 Sazba důchodového spoření - zaměstnance - s důchodovým spořením";
                case SOCIAL_FACTOR_EMPLOYEE_REDUCE:
                    return "03_Social_06 Snížení sazby sociálního pojištění - zaměstnance - s důchodovým spořením";
                case SOCIAL_MARGIN_INCOME_EMP:
                    return "03_Social_07 hranice příjmu pro vznik účasti na pojištění pro zaměstnace v pracovním poměru";
                case SOCIAL_MARGIN_INCOME_AGR:
                    return "03_Social_08 hranice příjmu pro vznik účasti na pojištění pro zaměstnace na dohodu";
                case TAXING_ALLOWANCE_PAYER:
                    return "04_Taxing_01 Částka slevy na poplatníka";
                case TAXING_ALLOWANCE_DISAB_1ST:
                    return "04_Taxing_02 Částka slevy na invaliditu 1.stupně poplatníka";
                case TAXING_ALLOWANCE_DISAB_2ND:
                    return "04_Taxing_03 Částka slevy na invaliditu 2.stupně poplatníka";
                case TAXING_ALLOWANCE_DISAB_3RD:
                    return "04_Taxing_04 Částka slevy na invaliditu 3.stupně poplatníka";
                case TAXING_ALLOWANCE_STUDY:
                    return "04_Taxing_05 Částka slevy na poplatníka studenta";
                case TAXING_ALLOWANCE_CHILD_1ST:
                    return "04_Taxing_06 Částka slevy na dítě 1.pořadí";
                case TAXING_ALLOWANCE_CHILD_2ND:
                    return "04_Taxing_07 Částka slevy na dítě 2.pořadí";
                case TAXING_ALLOWANCE_CHILD_3RD:
                    return "04_Taxing_08 Částka slevy na dítě 3.pořadí";
                case TAXING_FACTOR_ADVANCES:
                    return "04_Taxing_09 Sazba daně na zálohový příjem";
                case TAXING_FACTOR_WITHHOLD:
                    return "04_Taxing_10 Sazba daně na srážkový příjem";
                case TAXING_FACTOR_SOLIDARY:
                    return "04_Taxing_11 Sazba daně na solidární zvýšení";
                case TAXING_FACTOR_TAXRATE2:
                    return "04_Taxing_12 Sazba daně pro druhé pásmo daně";
                case TAXING_MIN_AMOUNT_OF_TAXBONUS:
                    return "04_Taxing_13 Minimální částka pro daňový bonus";
                case TAXING_MAX_AMOUNT_OF_TAXBONUS:
                    return "04_Taxing_14 Maximální částka pro daňový bonus";
                case TAXING_MARGIN_INCOME_OF_TAXBONUS:
                    return "04_Taxing_15 Minimální výše příjmu pro nároku na daňový bonus";
                case TAXING_MARGIN_INCOME_OF_ROUNDING:
                    return "04_Taxing_16 Maximální výše příjmu pro zaokrouhlování";
                case TAXING_MARGIN_INCOME_OF_WITHHOLD:
                    return "04_Taxing_17 Maximální výše příjmu pro srážkový příjem";
                case TAXING_MARGIN_INCOME_OF_SOLIDARY:
                    return "04_Taxing_18 Minimální výše příjmu pro solidární zvýšení daně";
                case TAXING_MARGIN_INCOME_OF_TAXRATE2:
                    return "04_Taxing_18 Minimální výše příjmu pro druhé pásmo daně";
                case TAXING_MARGIN_INCOME_OF_WHT_EMP:
                    return "04_Taxing_20 hranice příjmu pro srážkovou daň pro zaměstnace v pracovním poměru (nepodepsal prohlášení)";
                case TAXING_MARGIN_INCOME_OF_WHT_AGR:
                    return "04_Taxing_21 hranice příjmu pro srážkovou daň pro zaměstnace na dohodu (nepodepsal prohlášení)";
            }
            return "Neznámý Termín";
        }
        protected string PropsValueToString(Int32 value)
        {
            return $"{value}";
        }

        protected string PropsValueToString(decimal value)
        {
            Int32 intValue = Convert.ToInt32(value * 100);
            return $"{intValue}";
        }

    }
}
