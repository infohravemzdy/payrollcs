﻿using System;
using AutoFixture;
using FluentAssertions;
using HraveMzdy.Legalios.Service;
using HraveMzdy.Legalios.Interfaces;
using HraveMzdy.Legalios.Service.Types;
using NSubstitute;
using System.Collections.Generic;
using Xunit;
using LegaliosTests;

namespace LegaliosTest.Service
{
    [Collection("TestEngine")]
    public class Service_Legalios_Example_04_Taxing_21_MarginIncomeOfWthAgrTest : Service_Legalios_Example_TaxingTest
    {
        private readonly IServiceLegalios _sut;

        private static readonly TestIntScenario[] _tests = new TestIntScenario[]
        {
            new TestIntScenario("2010", new TestIntParams[] {
                new TestIntParams( "2010-1", 2010, 1, 2010, 1, 0 ),
                new TestIntParams( "2010-2", 2010, 2, 2010, 2, 0 ),
                new TestIntParams( "2010-3", 2010, 3, 2010, 3, 0 ),
                new TestIntParams( "2010-4", 2010, 4, 2010, 4, 0 ),
                new TestIntParams( "2010-5", 2010, 5, 2010, 5, 0 ),
                new TestIntParams( "2010-6", 2010, 6, 2010, 6, 0 ),
                new TestIntParams( "2010-7", 2010, 7, 2010, 7, 0 ),
                new TestIntParams( "2010-8", 2010, 8, 2010, 8, 0 ),
                new TestIntParams( "2010-9", 2010, 9, 2010, 9, 0 ),
                new TestIntParams( "2010-10", 2010, 10, 2010, 10, 0 ),
                new TestIntParams( "2010-11", 2010, 11, 2010, 11, 0 ),
                new TestIntParams( "2010-12", 2010, 12, 2010, 12, 0 ),
            }),
            new TestIntScenario("2011", new TestIntParams[] {
                new TestIntParams( "2011-1", 2011, 1, 2011, 1, 0 ),
                new TestIntParams( "2011-2", 2011, 2, 2011, 2, 0 ),
                new TestIntParams( "2011-3", 2011, 3, 2011, 3, 0 ),
                new TestIntParams( "2011-4", 2011, 4, 2011, 4, 0 ),
                new TestIntParams( "2011-5", 2011, 5, 2011, 5, 0 ),
                new TestIntParams( "2011-6", 2011, 6, 2011, 6, 0 ),
                new TestIntParams( "2011-7", 2011, 7, 2011, 7, 0 ),
                new TestIntParams( "2011-8", 2011, 8, 2011, 8, 0 ),
                new TestIntParams( "2011-9", 2011, 9, 2011, 9, 0 ),
                new TestIntParams( "2011-10", 2011, 10, 2011, 10, 0 ),
                new TestIntParams( "2011-11", 2011, 11, 2011, 11, 0 ),
                new TestIntParams( "2011-12", 2011, 12, 2011, 12, 0 ),
            }),
            new TestIntScenario("2012", new TestIntParams[] {
                new TestIntParams( "2012-1", 2012, 1, 2012, 1, 0 ),
                new TestIntParams( "2012-2", 2012, 2, 2012, 2, 0 ),
                new TestIntParams( "2012-3", 2012, 3, 2012, 3, 0 ),
                new TestIntParams( "2012-4", 2012, 4, 2012, 4, 0 ),
                new TestIntParams( "2012-5", 2012, 5, 2012, 5, 0 ),
                new TestIntParams( "2012-6", 2012, 6, 2012, 6, 0 ),
                new TestIntParams( "2012-7", 2012, 7, 2012, 7, 0 ),
                new TestIntParams( "2012-8", 2012, 8, 2012, 8, 0 ),
                new TestIntParams( "2012-9", 2012, 9, 2012, 9, 0 ),
                new TestIntParams( "2012-10", 2012, 10, 2012, 10, 0 ),
                new TestIntParams( "2012-11", 2012, 11, 2012, 11, 0 ),
                new TestIntParams( "2012-12", 2012, 12, 2012, 12, 0 ),
            }),
            new TestIntScenario("2013", new TestIntParams[] {
                new TestIntParams( "2013-1", 2013, 1, 2013, 1, 0 ),
                new TestIntParams( "2013-2", 2013, 2, 2013, 2, 0 ),
                new TestIntParams( "2013-3", 2013, 3, 2013, 3, 0 ),
                new TestIntParams( "2013-4", 2013, 4, 2013, 4, 0 ),
                new TestIntParams( "2013-5", 2013, 5, 2013, 5, 0 ),
                new TestIntParams( "2013-6", 2013, 6, 2013, 6, 0 ),
                new TestIntParams( "2013-7", 2013, 7, 2013, 7, 0 ),
                new TestIntParams( "2013-8", 2013, 8, 2013, 8, 0 ),
                new TestIntParams( "2013-9", 2013, 9, 2013, 9, 0 ),
                new TestIntParams( "2013-10", 2013, 10, 2013, 10, 0 ),
                new TestIntParams( "2013-11", 2013, 11, 2013, 11, 0 ),
                new TestIntParams( "2013-12", 2013, 12, 2013, 12, 0 ),
            }),
            new TestIntScenario("2014", new TestIntParams[] {
                new TestIntParams( "2014-1", 2014, 1, 2014, 1, 10000 ),
                new TestIntParams( "2014-2", 2014, 2, 2014, 2, 10000 ),
                new TestIntParams( "2014-3", 2014, 3, 2014, 3, 10000 ),
                new TestIntParams( "2014-4", 2014, 4, 2014, 4, 10000 ),
                new TestIntParams( "2014-5", 2014, 5, 2014, 5, 10000 ),
                new TestIntParams( "2014-6", 2014, 6, 2014, 6, 10000 ),
                new TestIntParams( "2014-7", 2014, 7, 2014, 7, 10000 ),
                new TestIntParams( "2014-8", 2014, 8, 2014, 8, 10000 ),
                new TestIntParams( "2014-9", 2014, 9, 2014, 9, 10000 ),
                new TestIntParams( "2014-10", 2014, 10, 2014, 10, 10000 ),
                new TestIntParams( "2014-11", 2014, 11, 2014, 11, 10000 ),
                new TestIntParams( "2014-12", 2014, 12, 2014, 12, 10000 ),
            }),
            new TestIntScenario("2015", new TestIntParams[] {
                new TestIntParams( "2015-1", 2015, 1, 2015, 1, 10000 ),
                new TestIntParams( "2015-2", 2015, 2, 2015, 2, 10000 ),
                new TestIntParams( "2015-3", 2015, 3, 2015, 3, 10000 ),
                new TestIntParams( "2015-4", 2015, 4, 2015, 4, 10000 ),
                new TestIntParams( "2015-5", 2015, 5, 2015, 5, 10000 ),
                new TestIntParams( "2015-6", 2015, 6, 2015, 6, 10000 ),
                new TestIntParams( "2015-7", 2015, 7, 2015, 7, 10000 ),
                new TestIntParams( "2015-8", 2015, 8, 2015, 8, 10000 ),
                new TestIntParams( "2015-9", 2015, 9, 2015, 9, 10000 ),
                new TestIntParams( "2015-10", 2015, 10, 2015, 10, 10000 ),
                new TestIntParams( "2015-11", 2015, 11, 2015, 11, 10000 ),
                new TestIntParams( "2015-12", 2015, 12, 2015, 12, 10000 ),
            }),
            new TestIntScenario("2016", new TestIntParams[] {
                new TestIntParams( "2016-1", 2016, 1, 2016, 1, 10000 ),
                new TestIntParams( "2016-2", 2016, 2, 2016, 2, 10000 ),
                new TestIntParams( "2016-3", 2016, 3, 2016, 3, 10000 ),
                new TestIntParams( "2016-4", 2016, 4, 2016, 4, 10000 ),
                new TestIntParams( "2016-5", 2016, 5, 2016, 5, 10000 ),
                new TestIntParams( "2016-6", 2016, 6, 2016, 6, 10000 ),
                new TestIntParams( "2016-7", 2016, 7, 2016, 7, 10000 ),
                new TestIntParams( "2016-8", 2016, 8, 2016, 8, 10000 ),
                new TestIntParams( "2016-9", 2016, 9, 2016, 9, 10000 ),
                new TestIntParams( "2016-10", 2016, 10, 2016, 10, 10000 ),
                new TestIntParams( "2016-11", 2016, 11, 2016, 11, 10000 ),
                new TestIntParams( "2016-12", 2016, 12, 2016, 12, 10000 ),
            }),
            new TestIntScenario("2017", new TestIntParams[] {
                new TestIntParams( "2017-1", 2017, 1, 2017, 1, 10000 ),
                new TestIntParams( "2017-2", 2017, 2, 2017, 2, 10000 ),
                new TestIntParams( "2017-3", 2017, 3, 2017, 3, 10000 ),
                new TestIntParams( "2017-4", 2017, 4, 2017, 4, 10000 ),
                new TestIntParams( "2017-5", 2017, 5, 2017, 5, 10000 ),
                new TestIntParams( "2017-6", 2017, 6, 2017, 6, 10000 ),
                new TestIntParams( "2017-7", 2017, 7, 2017, 7, 10000 ),
                new TestIntParams( "2017-8", 2017, 8, 2017, 8, 10000 ),
                new TestIntParams( "2017-9", 2017, 9, 2017, 9, 10000 ),
                new TestIntParams( "2017-10", 2017, 10, 2017, 10, 10000 ),
                new TestIntParams( "2017-11", 2017, 11, 2017, 11, 10000 ),
                new TestIntParams( "2017-12", 2017, 12, 2017, 12, 10000 ),
            }),
            new TestIntScenario("2018", new TestIntParams[] {
                new TestIntParams( "2018-1", 2018, 1, 2018, 1, 10000 ),
                new TestIntParams( "2018-2", 2018, 2, 2018, 2, 10000 ),
                new TestIntParams( "2018-3", 2018, 3, 2018, 3, 10000 ),
                new TestIntParams( "2018-4", 2018, 4, 2018, 4, 10000 ),
                new TestIntParams( "2018-5", 2018, 5, 2018, 5, 10000 ),
                new TestIntParams( "2018-6", 2018, 6, 2018, 6, 10000 ),
                new TestIntParams( "2018-7", 2018, 7, 2018, 7, 10000 ),
                new TestIntParams( "2018-8", 2018, 8, 2018, 8, 10000 ),
                new TestIntParams( "2018-9", 2018, 9, 2018, 9, 10000 ),
                new TestIntParams( "2018-10", 2018, 10, 2018, 10, 10000 ),
                new TestIntParams( "2018-11", 2018, 11, 2018, 11, 10000 ),
                new TestIntParams( "2018-12", 2018, 12, 2018, 12, 10000 ),
            }),
            new TestIntScenario("2019", new TestIntParams[] {
                new TestIntParams( "2019-1", 2019, 1, 2019, 1, 10000 ),
                new TestIntParams( "2019-2", 2019, 2, 2019, 2, 10000 ),
                new TestIntParams( "2019-3", 2019, 3, 2019, 3, 10000 ),
                new TestIntParams( "2019-4", 2019, 4, 2019, 4, 10000 ),
                new TestIntParams( "2019-5", 2019, 5, 2019, 5, 10000 ),
                new TestIntParams( "2019-6", 2019, 6, 2019, 6, 10000 ),
                new TestIntParams( "2019-7", 2019, 7, 2019, 7, 10000 ),
                new TestIntParams( "2019-8", 2019, 8, 2019, 8, 10000 ),
                new TestIntParams( "2019-9", 2019, 9, 2019, 9, 10000 ),
                new TestIntParams( "2019-10", 2019, 10, 2019, 10, 10000 ),
                new TestIntParams( "2019-11", 2019, 11, 2019, 11, 10000 ),
                new TestIntParams( "2019-12", 2019, 12, 2019, 12, 10000 ),
            }),
            new TestIntScenario("2020", new TestIntParams[] {
                new TestIntParams( "2020-1", 2020, 1, 2020, 1, 10000 ),
                new TestIntParams( "2020-2", 2020, 2, 2020, 2, 10000 ),
                new TestIntParams( "2020-3", 2020, 3, 2020, 3, 10000 ),
                new TestIntParams( "2020-4", 2020, 4, 2020, 4, 10000 ),
                new TestIntParams( "2020-5", 2020, 5, 2020, 5, 10000 ),
                new TestIntParams( "2020-6", 2020, 6, 2020, 6, 10000 ),
                new TestIntParams( "2020-7", 2020, 7, 2020, 7, 10000 ),
                new TestIntParams( "2020-8", 2020, 8, 2020, 8, 10000 ),
                new TestIntParams( "2020-9", 2020, 9, 2020, 9, 10000 ),
                new TestIntParams( "2020-10", 2020, 10, 2020, 10, 10000 ),
                new TestIntParams( "2020-11", 2020, 11, 2020, 11, 10000 ),
                new TestIntParams( "2020-12", 2020, 12, 2020, 12, 10000 ),
            }),
            new TestIntScenario("2021", new TestIntParams[] {
                new TestIntParams( "2021-1", 2021, 1, 2021, 1, 10000 ),
                new TestIntParams( "2021-2", 2021, 2, 2021, 2, 10000 ),
                new TestIntParams( "2021-3", 2021, 3, 2021, 3, 10000 ),
                new TestIntParams( "2021-4", 2021, 4, 2021, 4, 10000 ),
                new TestIntParams( "2021-5", 2021, 5, 2021, 5, 10000 ),
                new TestIntParams( "2021-6", 2021, 6, 2021, 6, 10000 ),
                new TestIntParams( "2021-7", 2021, 7, 2021, 7, 10000 ),
                new TestIntParams( "2021-8", 2021, 8, 2021, 8, 10000 ),
                new TestIntParams( "2021-9", 2021, 9, 2021, 9, 10000 ),
                new TestIntParams( "2021-10", 2021, 10, 2021, 10, 10000 ),
                new TestIntParams( "2021-11", 2021, 11, 2021, 11, 10000 ),
                new TestIntParams( "2021-12", 2021, 12, 2021, 12, 10000 ),
            }),
            new TestIntScenario("2022", new TestIntParams[] {
                new TestIntParams( "2022-1", 2022, 1, 2022, 1, 10000 ),
                new TestIntParams( "2022-2", 2022, 2, 2022, 2, 10000 ),
                new TestIntParams( "2022-3", 2022, 3, 2022, 3, 10000 ),
                new TestIntParams( "2022-4", 2022, 4, 2022, 4, 10000 ),
                new TestIntParams( "2022-5", 2022, 5, 2022, 5, 10000 ),
                new TestIntParams( "2022-6", 2022, 6, 2022, 6, 10000 ),
                new TestIntParams( "2022-7", 2022, 7, 2022, 7, 10000 ),
                new TestIntParams( "2022-8", 2022, 8, 2022, 8, 10000 ),
                new TestIntParams( "2022-9", 2022, 9, 2022, 9, 10000 ),
                new TestIntParams( "2022-10", 2022, 10, 2022, 10, 10000 ),
                new TestIntParams( "2022-11", 2022, 11, 2022, 11, 10000 ),
                new TestIntParams( "2022-12", 2022, 12, 2022, 12, 10000 ),
            }),
        };
        public static IEnumerable<object[]> TestData => GetTestIntData(_tests);
        public Service_Legalios_Example_04_Taxing_21_MarginIncomeOfWthAgrTest()
        {
            _sut = new ServiceLegalios();
#if __PROTOKOL_TEST_FILE__
            //04_Taxing_21_MarginIncomeOfWthAgr
            LogTestExamples("04_Taxing_21_MarginIncomeOfWthAgr.txt", _tests);
#endif
        }
        [Theory]
        [MemberData(nameof(TestData))]
        public void GetBundle_ShouldReturnValid_MarginIncomeOfWthAgr(string testTitle, string testName, Int16 testYear, Int16 testMonth, Int16 resultYear, Int16 resultMonth, Int32 resultValue)
        {
            var testPeriod = new Period(testYear, testMonth);

            var testResult = _sut.GetBundle(testPeriod);

            ShoulBeValidBundle(testResult, resultYear, resultMonth);

            testResult.Value.TaxingProps.MarginIncomeOfWthAgr.Should().Be(resultValue, "Because Period: {0} - {1}", testTitle, testName);
        }
    }
}
