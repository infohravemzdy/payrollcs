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
using HraveMzdy.Procezor.Payrolex.Registry.Constants;
using HraveMzdy.Procezor.Payrolex.Service;
using Procezor.PayrolexTest.Examples;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Payrolex.Registry.Providers;

namespace Procezor.PayrolexTest.Service
{
    public class ServiceTestExamples2013 : ServiceTestExampleTemplate
    {
        private static IPeriod TestPeriod = new Period(2013,1);

        private static readonly TestSpecParams[] _tests = new TestSpecParams[] {
                new TestSpecParams(101, "PP-Mzda_DanPoj-SlevyZaklad",      "101", 40, 0, pomGenItem, exDefaults), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(102, "PP-Mzda_DanPoj-SlevyDite1",       "102", 40, 0, pomGenItem, exSalaryDiteZtp(15600, 1, 0, 0)), //, CZK 15600    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 1,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(103, "PP-Mzda_DanPoj-BonusDite1",       "103", 40, 0, pomGenItem, exDiteZtp(1,0,0)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 1,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(104, "PP-Mzda_DanPoj-BonusDite2",       "104", 40, 0, pomGenItem, exDiteZtp(1,1,0)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 2,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(105, "PP-Mzda_DanPoj-MaxBonus",         "105", 40, 0, pomGenItem, exDiteMaxBonus), //, CZK 10000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 7,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(106, "PP-Mzda_DanPoj-MinZdravPrev",     "106", 40, 0, pomGenItem, exSalaryMinZdrPrev(-200)), //, CZK 7800     ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(107, "PP-Mzda_DanPoj-MinZdravCurr",     "107", 40, 0, pomGenItem, exSalaryMinZdr(-200)), //, CZK 7800     ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(108, "PP-Mzda_DanPoj-MaxZdravPrev",     "108", 40, 0, pomGenItem, exSalaryMaxZdrPrev(100)), //, CZK 1809964  ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(109, "PP-Mzda_DanPoj-MaxZdravCurr",     "109", 40, 0, pomGenItem, exSalaryMaxZdr(100)), //, CZK 1809964  ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(110, "PP-Mzda_DanPoj-MaxSocialPrev",    "110", 40, 0, pomGenItem, exSalaryMaxSocPrev(100)), //, CZK 1206676  ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(111, "PP-Mzda_DanPoj-MaxSocialCurr",    "111", 40, 0, pomGenItem, exSalaryMaxSoc(100)), //, CZK 1242532  ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(112, "PP-Mzda_DanPoj-SolidarDanPrev",   "112", 40, 0, pomGenItem, exSalarySolTaxPrev(1000)), //, CZK 104536   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(113, "PP-Mzda_DanPoj-SolidarDanCurr",   "113", 40, 0, pomGenItem, exSalarySolTax(1000)), //, CZK 104536   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(114, "PP-Mzda_DanPoj-DuchSpor",         "114", 40, 0, pomGenItem, exDefaults), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(115, "PP-Mzda_DanPoj-SlevyInv1",        "115", 40, 0, pomGenItem, exSalaryInv(20000, yes, no, no)), //, CZK 20000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  YES, NO, NO              ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(116, "PP-Mzda_DanPoj-SlevyInv2",        "116", 40, 0, pomGenItem, exTaxInval(no, yes, no)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, YES, NO              ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(117, "PP-Mzda_DanPoj-SlevyInv3",        "117", 40, 0, pomGenItem, exTaxInval(no, no, yes)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, YES, NO              ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(118, "PP-Mzda_DanPoj-SlevyStud",        "118", 40, 0, pomGenItem, exTaxStudy), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  YES                  ,  YES             ,  YES             , 
                new TestSpecParams(119, "PP-Mzda_DanPoj-SlevyZakl015",     "119", 40, 0, pomGenItem, exDefaults), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(120, "PP-Mzda_DanPoj-SlevyZakl020",     "120", 40, 0, pomGenItem, exSalary(20000 )), //, CZK 20000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(121, "PP-Mzda_DanPoj-SlevyZakl025",     "121", 40, 0, pomGenItem, exSalary(25000 )), //, CZK 25000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(122, "PP-Mzda_DanPoj-SlevyZakl030",     "122", 40, 0, pomGenItem, exSalary(30000 )), //, CZK 30000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(123, "PP-Mzda_DanPoj-SlevyZakl035",     "123", 40, 0, pomGenItem, exSalary(35000 )), //, CZK 35000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(124, "PP-Mzda_DanPoj-SlevyZakl040",     "124", 40, 0, pomGenItem, exSalary(40000 )), //, CZK 40000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(125, "PP-Mzda_DanPoj-SlevyZakl045",     "125", 40, 0, pomGenItem, exSalary(45000 )), //, CZK 45000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(126, "PP-Mzda_DanPoj-SlevyZakl050",     "126", 40, 0, pomGenItem, exSalary(50000 )), //, CZK 50000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(127, "PP-Mzda_DanPoj-SlevyZakl055",     "127", 40, 0, pomGenItem, exSalary(55000 )), //, CZK 55000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(128, "PP-Mzda_DanPoj-SlevyZakl060",     "128", 40, 0, pomGenItem, exSalary(60000 )), //, CZK 60000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(129, "PP-Mzda_DanPoj-SlevyZakl065",     "129", 40, 0, pomGenItem, exSalary(65000 )), //, CZK 65000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(130, "PP-Mzda_DanPoj-SlevyZakl070",     "130", 40, 0, pomGenItem, exSalary(70000 )), //, CZK 70000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(131, "PP-Mzda_DanPoj-SlevyZakl075",     "131", 40, 0, pomGenItem, exSalary(75000 )), //, CZK 75000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(132, "PP-Mzda_DanPoj-SlevyZakl080",     "132", 40, 0, pomGenItem, exSalary(80000 )), //, CZK 80000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(133, "PP-Mzda_DanPoj-SlevyZakl085",     "133", 40, 0, pomGenItem, exSalary(85000 )), //, CZK 85000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(134, "PP-Mzda_DanPoj-SlevyZakl090",     "134", 40, 0, pomGenItem, exSalary(90000 )), //, CZK 90000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(135, "PP-Mzda_DanPoj-SlevyZakl095",     "135", 40, 0, pomGenItem, exSalary(95000 )), //, CZK 95000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(136, "PP-Mzda_DanPoj-SlevyZakl100",     "136", 40, 0, pomGenItem, exSalary(100000)), //, CZK 100000   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(137, "PP-Mzda_DanPoj-SlevyZakl105",     "137", 40, 0, pomGenItem, exSalary(105000)), //, CZK 105000   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(138, "PP-Mzda_DanPoj-SlevyZakl110",     "138", 40, 0, pomGenItem, exSalary(110000)), //, CZK 110000   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

                new TestSpecParams(201, "PP-Mzda_NepodPoj-PrevLo",         "201", 40, 0, pomGenItem, exSrazNepPrev0), //, CZK 5000     ,  YES       , NO,  YES          ,  YES          ,  YES          ,  NO            ,  NO                , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(202, "PP-Mzda_NepodPoj-PrevHi",         "202", 40, 0, pomGenItem, exSrazNepPrev1), //, CZK 5001     ,  YES       , NO,  YES          ,  YES          ,  YES          ,  NO            ,  NO                , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(203, "PP-Mzda_NepodPoj-CurrLo",         "203", 40, 0, pomGenItem, exSrazNep0), //, CZK 5000     ,  YES       , NO,  YES          ,  YES          ,  YES          ,  NO            ,  NO                , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(204, "PP-Mzda_NepodPoj-CurrHi",         "204", 40, 0, pomGenItem, exSrazNep1), //, CZK 5001     ,  YES       , NO,  YES          ,  YES          ,  YES          ,  NO            ,  NO                , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

                new TestSpecParams(301, "PP-Mzda_DanPoj-Dan099",           "301", 40, 0, pomGenItem, exNoMinAgreem(74)), //, CZK 74       ,  YES          ,  YES          ,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(302, "PP-Mzda_DanPoj-Dan100",           "302", 40, 0, pomGenItem, exNoMinSalary(75)), //, CZK 75       ,  YES          ,  YES          ,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(303, "PP-Mzda_DanPoj-Dan101",           "303", 40, 0, pomGenItem, exNoMinSalary(100)), //, CZK 100      ,  YES          ,  YES          ,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

                new TestSpecParams(401, "PP-Mzda_DanPoj-Neodpr064",        "401", 40,  46, pomGenItem, exSalary(20000)), //, CZK 20000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(402, "PP-Mzda_DanPoj-Neodpr184",        "402", 40, 184, pomGenItem, exNoMinSalary(20000)), //, CZK 20000    ,  YES          ,  YES          ,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

                new TestSpecParams(501, "DPC-Mzda_NeUcastZdrav-Prev",      "501", 40, 0, dpcGenItem, exSalaryUcastZdrPrev(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(502, "DPC-Mzda_UcastZdrav-Prev",        "502", 40, 0, dpcGenItem, exSalaryUcastZdrPrev(0)),  //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(503, "DPC-Mzda_NeUcastNemoc-Prev",      "503", 40, 0, dpcGenItem, exSalaryUcastNemPrev(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(504, "DPC-Mzda_UcastNemoc-Prev",        "504", 40, 0, dpcGenItem, exSalaryUcastNemPrev(0)),  //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(505, "DPP-Mzda_NeUcastZdrav-Prev",      "505", 40, 0, dpcGenItem, exSalaryUcastZdrEmpPrev(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(506, "DPP-Mzda_UcastZdrav-Prev",        "506", 40, 0, dpcGenItem, exSalaryUcastZdrEmpPrev(0)),  //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(507, "DPC-Mzda_NeUcastZdrav-Curr",      "507", 40, 0, dpcGenItem, exSalaryUcastZdr(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(508, "DPC-Mzda_UcastZdrav-Curr",        "508", 40, 0, dpcGenItem, exSalaryUcastZdr(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(509, "DPC-Mzda_NeUcastNemoc-Curr",      "509", 40, 0, dpcGenItem, exSalaryUcastNem(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(510, "DPC-Mzda_UcastNemoc-Curr",        "510", 40, 0, dpcGenItem, exSalaryUcastNem(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(511, "DPP-Mzda_NeUcastZdrav-Curr",      "511", 40, 0, dppGenItem, exSalaryUcastZdrEmp(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(512, "DPP-Mzda_UcastZdrav-Curr",        "512", 40, 0, dppGenItem, exSalaryUcastZdrEmp(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

                new TestSpecParams(601, "DPP-Mzda_NeUcastNemoc-Prev",      "601", 40, 0, dppGenItem, exSalaryUcastNemPrev(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(602, "DPP-Mzda_UcastNemoc-Prev",        "602", 40, 0, dppGenItem, exSalaryUcastNemPrev(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(603, "DPP-Mzda_NeUcastNemoc-Curr",      "603", 40, 0, dppGenItem, exSalaryUcastNem(-1)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
                new TestSpecParams(604, "DPP-Mzda_UcastNemoc-Curr",        "604", 40, 0, dppGenItem, exSalaryUcastNem(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
        };

        public static IEnumerable<object[]> TestData => GetTestDecData(_tests);
        public static IEnumerable<object[]> GetTestDecData(TestSpecParams[] tests) {
            System.Text.EncodingProvider ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);

            string[] strHeaderRadkaPRAC = new string[] {
                "EMPLOYEEID",
                "PERIOD",
                "TAXING_INCOME_SUBJECT",
                "TAXING_INCOME_HEALTH_RAW",
                "TAXING_INCOME_HEALTH_FIX",
                "TAXING_INCOME_SOCIAL_RAW",
                "TAXING_INCOME_SOCIAL_FIX",
                "TAXING_SIGNING",
                "TAXING_SIGNING_NONE",
                "TAXING_ADVANCES_INCOME",
                "TAXING_ADVANCES_HEALTH",
                "TAXING_ADVANCES_SOCIAL",
                "TAXING_ADVANCES_BASIS_RAW",
                "TAXING_ADVANCES_BASIS_RND",
                "TAXING_SOLIDARY_BASIS",
                "TAXING_ADVANCES",
                "TAXING_SOLIDARY",
                "TAXING_ADVANCES_TOTAL",
                "TAXING_ALLOWANCE_PAYER",
                "TAXING_ALLOWANCE_PAYER_SUM",
                "TAXING_ALLOWANCE_CHILD_ORD1",
                "TAXING_ALLOWANCE_CHILD_ORD2",
                "TAXING_ALLOWANCE_CHILD_ORD3",
                "TAXING_ALLOWANCE_CHILD_DIS1",
                "TAXING_ALLOWANCE_CHILD_DIS2",
                "TAXING_ALLOWANCE_CHILD_DIS3",
                "TAXING_ALLOWANCE_CHILD_SUM",
                "TAXING_ALLOWANCE_DISAB_DIS1",
                "TAXING_ALLOWANCE_DISAB_DIS2",
                "TAXING_ALLOWANCE_DISAB_DIS3",
                "TAXING_ALLOWANCE_DISAB_SUM",
                "TAXING_ALLOWANCE_STUDY",
                "TAXING_ALLOWANCE_STUDY_SUM",
                "TAXING_REBATE_PAYER",
                "TAXING_REBATE_CHILD",
                "TAXING_BONUS_CHILD_CAL",
                "TAXING_BONUS_CHILD_PAY",
                "TAXING_WITHHOLD_INCOME",
                "TAXING_WITHHOLD_HEALTH",
                "TAXING_WITHHOLD_SOCIAL",
                "TAXING_WITHHOLD_BASIS_RAW",
                "TAXING_WITHHOLD_BASIS_RND",
                "TAXING_WITHHOLD_TOTAL",
                "TAXING_PAYM_ADVANCES",
                "TAXING_PAYM_WITHHOLD",
                "INCOME_GROSS",
                "INCOME_NETTO",
                "EMPLOYER_COSTS",
            };
            string[] strHeaderRadkaPPOM = new string[] {
                "EMPLOYEEID",
                "CONTRACTID",
                "PERIOD",
                "POSITION_WORK_PLAN",
                "CONTRACT_TIME_PLAN",
                "CONTRACT_TIME_WORK",
                "CONTRACT_TIME_ABSC",
                "PAYMENT_SALARY",
                "PAYMENT_FIXED",
                "HEALTH_DECLARE_SUB",
                "HEALTH_DECLARE_MIN",
                "HEALTH_DECLARE_FOR",
                "HEALTH_DECLARE_EHS",
                "HEALTH_DECLARE_PAR",
                "HEALTH_INCOME",
                "HEALTH_BASE",
                "HEALTH_BASE_ANNUALLY",
                "HEALTH_BASE_EMPLOYEE",
                "HEALTH_BASE_EMPLOYER",
                "HEALTH_BASE_MANDATE",
                "HEALTH_BASE_OVERCAP",
                "HEALTH_PAYM_EMPLOYEE",
                "HEALTH_PAYM_EMPLOYER",
                "SOCIAL_DECLARE",
                "SOCIAL_DECLARE_ZMR",
                "SOCIAL_DECLARE_KRZ",
                "SOCIAL_DECLARE_FOR",
                "SOCIAL_DECLARE_EHS",
                "SOCIAL_DECLARE_PAR",
                "SOCIAL_INCOME",
                "SOCIAL_BASE",
                "SOCIAL_BASE_ANNUALLY",
                "SOCIAL_BASE_EMPLOYEE",
                "SOCIAL_BASE_EMPLOYER",
                "SOCIAL_BASE_OVERCAP",
                "SOCIAL_PAYM_EMPLOYEE",
                "SOCIAL_PAYM_EMPLOYER",
                "TAXING_DECLARE",
                "TAXING_INCOME_SUBJECT",
                "TAXING_INCOME_HEALTH_RAW",
                "TAXING_INCOME_SOCIAL_RAW",
                };
            using (var testProtokol = CreateProtokolFile($"OKPRAC_TEST_2013_HRM_{TestPeriod.Code}.CSV"))
            {
                testProtokol.WriteLine(string.Join(";", strHeaderRadkaPRAC));
            }
            using (var testProtokol = CreateProtokolFile($"OKPPOM_TEST_2013_HRM_{TestPeriod.Code}.CSV"))
            {
                testProtokol.WriteLine(string.Join(";", strHeaderRadkaPPOM));
            }
            return tests.Select((tt) => (new object[] { tt })); 
        }
        public ServiceTestExamples2013(ITestOutputHelper output) : base(output)
        {
        }
        [Fact]
        public void ServiceExamples_CreateImport()
        {
            TestPeriod.Code.Should().Be(201301);

            var prevPeriod = PrevYear(TestPeriod);
            prevPeriod.Code.Should().Be(201201);

            var testLegalResult = _leg.GetBundle(TestPeriod);
            testLegalResult.IsSuccess.Should().Be(true);

            var testRuleset = testLegalResult.Value;

            var prevLegalResult = _leg.GetBundle(prevPeriod);
            prevLegalResult.IsSuccess.Should().Be(true);

            var prevRuleset = prevLegalResult.Value;

            using (var testProtokol = CreateProtokolFile($"OKmzdyImport_{TestPeriod.Year}.txt"))
            {
                ExportPropsStart(testProtokol);

                foreach (var test in _tests)
                {
                    var example = test.gen.CreateExample(TestPeriod, testRuleset, prevRuleset, 
                        test.id, test.name, test.number, test.schedWeek, test.nonAtten, test.exp);

                    foreach (var impLine in example.importString(TestPeriod))
                    {
                        testProtokol.WriteLine(impLine);
                    }
                }
                ExportPropsEnd(testProtokol);
            }
        }

        [Fact]
        public void ServiceExamples_PPomMzdaDanPojSlevyZakladTest()
        {
            TestSpecParams test = new TestSpecParams(101, "PP-Mzda_DanPoj-SlevyZaklad", "101", 40, 0, pomGenItem, exDefaults);
#if __TEST_PRESCRIPTION__
            //name                             |101-PP-Mzda-DanPoj-SlevyZaklad
            //period                           |01 2013
            //schedule                         |40
            //absence                          |0
            //salary                           |CZK 15000
            //tax payer                        |DECLARE
            //health payer                     |YES
            //health minim                     |YES
            //social payer                     |YES
            //pension payer                    |NO
            //tax payer benefit                |YES
            //tax child benefit                |0
            //tax disability benefit           |NO:NO:NO
            //tax studying benefit             |NO
            //health employer                  |YES
            //social employer                  |YES
            //tax income                       |CZK 15000
            //premium insurance                |CZK 5100
            //tax base                         |CZK 20100
            //health base                      |CZK 15000
            //social base                      |CZK 15000
            //health ins                       |CZK 675
            //social ins                       |CZK 975
            //tax before                       |CZK 3015
            //payer relief                     |CZK 2070
            //tax after A relief               |CZK 945
            //child relief                     |CZK 0
            //tax after C relief               |CZK 945
            //tax advance                      |CZK 945
            //tax bonus                        |CZK 0
            //gross income                     |CZK 15000
            //netto income                     |CZK 12405
#endif
            TestPeriod.Code.Should().Be(201301);

            var prevPeriod = PrevYear(TestPeriod);
            prevPeriod.Code.Should().Be(201201);

            var testLegalResult = _leg.GetBundle(TestPeriod);
            testLegalResult.IsSuccess.Should().Be(true);

            var testRuleset = testLegalResult.Value;

            var prevLegalResult = _leg.GetBundle(prevPeriod);
            prevLegalResult.IsSuccess.Should().Be(true);

            var prevRuleset = prevLegalResult.Value;

            var example = test.gen.CreateExample(TestPeriod, testRuleset, prevRuleset, 
                test.id, test.name, test.number, test.schedWeek, test.nonAtten, test.exp);

            output.WriteLine(example.exampleString());

            var targets = example.GetSpecTargets(TestPeriod);
            foreach (var (target, index) in targets.Select((item, index) => (item, index)))
            {
                var articleSymbol = target.ArticleDescr();
                var conceptSymbol = target.ConceptDescr();
                output.WriteLine("Index: {0}, ART: {1}, CON: {2}, con: {3}, pos: {4}, var: {5}", index, articleSymbol, conceptSymbol, target.Contract.Value, target.Position.Value, target.Variant.Value);
            }

            var initService = _sut.InitWithPeriod(TestPeriod);
            initService.Should().BeTrue();

            var restService = _sut.GetResults(TestPeriod, testRuleset, targets);
            restService.Count().Should().NotBe(0);

            var testPracResults = GetPracResultsLine(example, TestPeriod, restService);

            output.WriteLine(testPracResults);

            var testPPomResults = GetPPomResultsLine(example, TestPeriod, restService);

            foreach (var ppomResult in testPPomResults)
            {
                output.WriteLine(ppomResult);
            }

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

        [Theory]
        [MemberData(nameof(TestData))]
        public void ServiceExamplesTest(TestSpecParams test)
        {
            TestPeriod.Code.Should().Be(201301);

            var prevPeriod = PrevYear(TestPeriod);
            prevPeriod.Code.Should().Be(201201);

            var testLegalResult = _leg.GetBundle(TestPeriod);
            testLegalResult.IsSuccess.Should().Be(true);

            var testRuleset = testLegalResult.Value;

            var prevLegalResult = _leg.GetBundle(prevPeriod);
            prevLegalResult.IsSuccess.Should().Be(true);

            var prevRuleset = prevLegalResult.Value;

            var example = test.gen.CreateExample(TestPeriod, testRuleset, prevRuleset, 
                test.id, test.name, test.number, test.schedWeek, test.nonAtten, test.exp);

            output.WriteLine(example.exampleString());

            var targets = example.GetSpecTargets(TestPeriod);

            foreach (var (target, index) in targets.Select((item, index) => (item, index)))
            {
                var articleSymbol = target.ArticleDescr();
                var conceptSymbol = target.ConceptDescr();
                output.WriteLine("Index: {0}, ART: {1}, CON: {2}, con: {3}, pos: {4}, var: {5}", index, articleSymbol, conceptSymbol, target.Contract.Value, target.Position.Value, target.Variant.Value);
            }

            var initService = _sut.InitWithPeriod(TestPeriod);
            initService.Should().BeTrue();

            var restService = _sut.GetResults(TestPeriod, testRuleset, targets);
            restService.Count().Should().NotBe(0);

            using (var testProtokol = OpenProtokolFile($"OKPRAC_TEST_2013_HRM_{TestPeriod.Year}.CSV"))
            {
                var testResults = GetPracResultsLine(example, TestPeriod, restService);
                testProtokol.WriteLine(testResults);
            }
            using (var testProtokol = OpenProtokolFile($"OKPPOM_TEST_2013_HRM_{TestPeriod.Year}.CSV"))
            {
                var testResults = GetPPomResultsLine(example, TestPeriod, restService);
                foreach (var ppomResult in testResults)
                {
                    testProtokol.WriteLine(ppomResult);
                }
            }

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
    }
}
