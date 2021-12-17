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

         private static readonly ExampleGenerator[] _genTests = new ExampleGenerator[] {
            ExampleGenerator.Spec(101, "PP-Mzda_DanPoj-SlevyZaklad",      "101").WithContracts(ContractGenerator.SpecEmp(1)),
            ExampleGenerator.Spec(102, "PP-Mzda_DanPoj-SlevyDite1",       "102").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(15600))).WithChild(ChildGenerator.SpecDisb1(1)), //, CZK 15600    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 1,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(103, "PP-Mzda_DanPoj-BonusDite1",       "103").WithContracts(ContractGenerator.SpecEmp(1)).WithChild(ChildGenerator.SpecDisb1(1)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 1,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(104, "PP-Mzda_DanPoj-BonusDite2",       "104").WithContracts(ContractGenerator.SpecEmp(1)).WithChild(ChildGenerator.SpecDisb(1, 1, 0)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 2,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(105, "PP-Mzda_DanPoj-MaxBonus",         "105").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(MaxBonus())).WithChild(ChildGenerator.SpecDisb(1, 1, 5)), //, CZK 10000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 7,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(106, "PP-Mzda_DanPoj-MinZdravPrev",     "106").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(MinZdrPrev(-200))), //, CZK 7800     ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(107, "PP-Mzda_DanPoj-MinZdravCurr",     "107").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(MinZdr(-200))), //, CZK 7800     ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(108, "PP-Mzda_DanPoj-MaxZdravPrev",     "108").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(MaxZdrPrev(100))), //, CZK 1809964  ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(109, "PP-Mzda_DanPoj-MaxZdravCurr",     "109").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(MaxZdr(100))), //, CZK 1809964  ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(110, "PP-Mzda_DanPoj-MaxSocialPrev",    "110").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(MaxSocPrev(100))), //, CZK 1206676  ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(111, "PP-Mzda_DanPoj-MaxSocialCurr",    "111").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(MaxSoc(100))), //, CZK 1242532  ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(112, "PP-Mzda_DanPoj-SolidarDanPrev",   "112").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(SolTaxPrev(1000))), //, CZK 104536   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(113, "PP-Mzda_DanPoj-SolidarDanCurr",   "113").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(SolTax(1000))), //, CZK 104536   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(114, "PP-Mzda_DanPoj-DuchSpor",         "114").WithContracts(ContractGenerator.SpecEmp(1)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(115, "PP-Mzda_DanPoj-SlevyInv1",        "115").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(20000))).WithBenDisab1(GenValue(1)), //, CZK 20000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  YES, NO, NO              ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(116, "PP-Mzda_DanPoj-SlevyInv2",        "116").WithContracts(ContractGenerator.SpecEmp(1)).WithBenDisab2(GenValue(1)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, YES, NO              ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(117, "PP-Mzda_DanPoj-SlevyInv3",        "117").WithContracts(ContractGenerator.SpecEmp(1)).WithBenDisab3(GenValue(1)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, YES, NO              ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(118, "PP-Mzda_DanPoj-SlevyStud",        "118").WithContracts(ContractGenerator.SpecEmp(1)).WithBenStudy(GenValue(1)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  YES                  ,  YES             ,  YES             , 
            ExampleGenerator.Spec(119, "PP-Mzda_DanPoj-SlevyZakl015",     "119").WithContracts(ContractGenerator.SpecEmp(1)), //, CZK 15000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(120, "PP-Mzda_DanPoj-SlevyZakl020",     "120").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(20000 ))), //, CZK 20000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(121, "PP-Mzda_DanPoj-SlevyZakl025",     "121").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(25000 ))), //, CZK 25000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(122, "PP-Mzda_DanPoj-SlevyZakl030",     "122").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(30000 ))), //, CZK 30000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(123, "PP-Mzda_DanPoj-SlevyZakl035",     "123").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(35000 ))), //, CZK 35000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(124, "PP-Mzda_DanPoj-SlevyZakl040",     "124").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(40000 ))), //, CZK 40000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(125, "PP-Mzda_DanPoj-SlevyZakl045",     "125").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(45000 ))), //, CZK 45000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(126, "PP-Mzda_DanPoj-SlevyZakl050",     "126").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(50000 ))), //, CZK 50000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(127, "PP-Mzda_DanPoj-SlevyZakl055",     "127").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(55000 ))), //, CZK 55000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(128, "PP-Mzda_DanPoj-SlevyZakl060",     "128").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(60000 ))), //, CZK 60000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(129, "PP-Mzda_DanPoj-SlevyZakl065",     "129").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(65000 ))), //, CZK 65000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(130, "PP-Mzda_DanPoj-SlevyZakl070",     "130").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(70000 ))), //, CZK 70000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(131, "PP-Mzda_DanPoj-SlevyZakl075",     "131").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(75000 ))), //, CZK 75000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(132, "PP-Mzda_DanPoj-SlevyZakl080",     "132").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(80000 ))), //, CZK 80000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(133, "PP-Mzda_DanPoj-SlevyZakl085",     "133").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(85000 ))), //, CZK 85000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(134, "PP-Mzda_DanPoj-SlevyZakl090",     "134").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(90000 ))), //, CZK 90000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(135, "PP-Mzda_DanPoj-SlevyZakl095",     "135").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(95000 ))), //, CZK 95000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(136, "PP-Mzda_DanPoj-SlevyZakl100",     "136").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(100000))), //, CZK 100000   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(137, "PP-Mzda_DanPoj-SlevyZakl105",     "137").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(105000))), //, CZK 105000   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(138, "PP-Mzda_DanPoj-SlevyZakl110",     "138").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(110000))), //, CZK 110000   ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

            ExampleGenerator.Spec(201, "PP-Mzda_NepodPoj-PrevLo",         "201").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(SrazNepPrev(0))).WithTaxDecl(GenValue(0)), //, CZK 5000     ,  YES       , NO,  YES          ,  YES          ,  YES          ,  NO            ,  NO                , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(202, "PP-Mzda_NepodPoj-PrevHi",         "202").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(SrazNepPrev(1))).WithTaxDecl(GenValue(0)), //, CZK 5001     ,  YES       , NO,  YES          ,  YES          ,  YES          ,  NO            ,  NO                , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(203, "PP-Mzda_NepodPoj-CurrLo",         "203").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(SrazNep(0))).WithTaxDecl(GenValue(0)), //, CZK 5000     ,  YES       , NO,  YES          ,  YES          ,  YES          ,  NO            ,  NO                , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(204, "PP-Mzda_NepodPoj-CurrHi",         "204").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(SrazNep(1))).WithTaxDecl(GenValue(0)), //, CZK 5001     ,  YES       , NO,  YES          ,  YES          ,  YES          ,  NO            ,  NO                , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

            ExampleGenerator.Spec(301, "PP-Mzda_DanPoj-Dan099",           "301").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(0)).WithAgreem(ConValue(74)).WithHealthMinim(ConValue(0))), //, CZK 74       ,  YES          ,  YES          ,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(302, "PP-Mzda_DanPoj-Dan100",           "302").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(75)).WithHealthMinim(ConValue(0))), //, CZK 75       ,  YES          ,  YES          ,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(303, "PP-Mzda_DanPoj-Dan101",           "303").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(100)).WithHealthMinim(ConValue(0))), //, CZK 100      ,  YES          ,  YES          ,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

            ExampleGenerator.Spec(401, "PP-Mzda_DanPoj-Neodpr064",        "401").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(20000)).WithAbsence(ConValue(46))), //, CZK 20000    ,  YES          ,  YES          ,  YES          ,  YES          ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(402, "PP-Mzda_DanPoj-Neodpr184",        "402").WithContracts(ContractGenerator.SpecEmp(1).WithSalary(ConValue(20000)).WithHealthMinim(ConValue(0)).WithAbsence(ConValue(184))), //, CZK 20000    ,  YES          ,  YES          ,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

            ExampleGenerator.Spec(501, "DPC-Mzda_NeUcastZdrav-Prev",      "501").WithContracts(ContractGenerator.SpecDpc(1).WithSalary(ConValue(0)).WithAgreem(UcastZdrPrev(-1)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(502, "DPC-Mzda_UcastZdrav-Prev",        "502").WithContracts(ContractGenerator.SpecDpc(1).WithSalary(ConValue(0)).WithAgreem(UcastZdrPrev(0)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(503, "DPC-Mzda_NeUcastNemoc-Prev",      "503").WithContracts(ContractGenerator.SpecDpc(1).WithSalary(ConValue(0)).WithAgreem(UcastNemPrev(-1)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(504, "DPC-Mzda_UcastNemoc-Prev",        "504").WithContracts(ContractGenerator.SpecDpc(1).WithSalary(ConValue(0)).WithAgreem(UcastNemPrev(0)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(505, "DPP-Mzda_NeUcastZdrav-Prev",      "505").WithContracts(ContractGenerator.SpecDpc(1).WithSalary(ConValue(0)).WithAgreem(UcastZdrEmpPrev(-1)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(506, "DPP-Mzda_UcastZdrav-Prev",        "506").WithContracts(ContractGenerator.SpecDpc(1).WithSalary(ConValue(0)).WithAgreem(UcastZdrEmpPrev(0)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(507, "DPC-Mzda_NeUcastZdrav-Curr",      "507").WithContracts(ContractGenerator.SpecDpc(1).WithSalary(ConValue(0)).WithAgreem(UcastZdr(-1)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(508, "DPC-Mzda_UcastZdrav-Curr",        "508").WithContracts(ContractGenerator.SpecDpc(1).WithSalary(ConValue(0)).WithAgreem(UcastZdr(0)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(509, "DPC-Mzda_NeUcastNemoc-Curr",      "509").WithContracts(ContractGenerator.SpecDpc(1).WithSalary(ConValue(0)).WithAgreem(UcastNem(-1)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(510, "DPC-Mzda_UcastNemoc-Curr",        "510").WithContracts(ContractGenerator.SpecDpc(1).WithSalary(ConValue(0)).WithAgreem(UcastNem(0)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(511, "DPP-Mzda_NeUcastZdrav-Curr",      "511").WithContracts(ContractGenerator.SpecDpp(1).WithSalary(ConValue(0)).WithAgreem(UcastZdrEmp(-1)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(512, "DPP-Mzda_UcastZdrav-Curr",        "512").WithContracts(ContractGenerator.SpecDpp(1).WithSalary(ConValue(0)).WithAgreem(UcastZdrEmp(0)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

            ExampleGenerator.Spec(601, "DPP-Mzda_NeUcastNemoc-Prev",      "601").WithContracts(ContractGenerator.SpecDpp(1).WithSalary(ConValue(0)).WithAgreem(UcastNemPrev(-1)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(602, "DPP-Mzda_UcastNemoc-Prev",        "602").WithContracts(ContractGenerator.SpecDpp(1).WithSalary(ConValue(0)).WithAgreem(UcastNemPrev(0)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(603, "DPP-Mzda_NeUcastNemoc-Curr",      "603").WithContracts(ContractGenerator.SpecDpp(1).WithSalary(ConValue(0)).WithAgreem(UcastNem(-1)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 
            ExampleGenerator.Spec(604, "DPP-Mzda_UcastNemoc-Curr",        "604").WithContracts(ContractGenerator.SpecDpp(1).WithSalary(ConValue(0)).WithAgreem(UcastNem(0)).WithHealthMinim(ConValue(0))).WithTaxDecl(GenValue(0)), //,CZK 0,  YES       , NO,  YES          ,  NO           ,  YES          ,  NO            ,  YES               , 0,  NO, NO, NO               ,  NO                   ,  YES             ,  YES             , 

            ExampleGenerator.Spec(701, "MPOM-PPOM-Mzda_NeUcastNemoc",     "701").WithContracts(
                ContractGenerator.SpecEmp(1)
                    .WithSalary(UcastNem(-1))
                    .WithHealthMinim(ConValue(0))
                    .WithSocialLoIncome(ConValue(1)),
                ContractGenerator.SpecEmp(2)
                    .WithSalary(ConValue(2500)))
             .WithTaxDecl(GenValue(0)), 
            ExampleGenerator.Spec(702, "MDPC-PPOM-Mzda_NeUcastNemoc",     "702").WithContracts(
                ContractGenerator.SpecDpc(1)
                    .WithSalary(ConValue(0))
                    .WithAgreem(UcastNem(-1))
                    .WithHealthMinim(ConValue(0))
                    .WithSocialLoIncome(ConValue(1)),
                ContractGenerator.SpecEmp(2)
                    .WithSalary(ConValue(2500)))
             .WithTaxDecl(GenValue(0)), 
            ExampleGenerator.Spec(702, "XDPP-PPOM-Mzda_NeUcastNemoc",     "703").WithContracts(
                ContractGenerator.SpecDpp(1)
                    .WithSalary(ConValue(0))
                    .WithAgreem(UcastNem(-1))
                    .WithHealthMinim(ConValue(0)),
                ContractGenerator.SpecEmp(2)
                    .WithSalary(ConValue(2500)))
             .WithTaxDecl(GenValue(0)), 
            ExampleGenerator.Spec(711, "MPOM-PPOM-Mzda_UcastNemoc",     "711").WithContracts(
                ContractGenerator.SpecEmp(1)
                    .WithSalary(UcastNem(0))
                    .WithHealthMinim(ConValue(0))
                    .WithSocialLoIncome(ConValue(1)),
                ContractGenerator.SpecEmp(2)
                    .WithSalary(ConValue(2500)))
             .WithTaxDecl(GenValue(0)), 
            ExampleGenerator.Spec(712, "MDPC-PPOM-Mzda_UcastNemoc",     "712").WithContracts(
                ContractGenerator.SpecDpc(1)
                    .WithSalary(ConValue(0))
                    .WithAgreem(UcastNem(0))
                    .WithHealthMinim(ConValue(0))
                    .WithSocialLoIncome(ConValue(1)),
                ContractGenerator.SpecEmp(2)
                    .WithSalary(ConValue(2500)))
             .WithTaxDecl(GenValue(0)), 
            ExampleGenerator.Spec(713, "XDPP-PPOM-Mzda_UcastNemoc",     "713").WithContracts(
                ContractGenerator.SpecDpp(1)
                    .WithSalary(ConValue(0))
                    .WithAgreem(UcastNem(0))
                    .WithHealthMinim(ConValue(0)),
                ContractGenerator.SpecEmp(2)
                    .WithSalary(ConValue(2500)))
             .WithTaxDecl(GenValue(0)), 
        };
        public static IEnumerable<object[]> GenTestData => GetGenTestDecData(_genTests);
        public static IEnumerable<object[]> GetGenTestDecData(ExampleGenerator[] tests) {
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
                "CONTRACT_TYPE",
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
        private void ServiceExampleTest(ExampleGenerator example)
        {
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

            var targets = example.BuildSpecTargets(TestPeriod, testRuleset, prevRuleset);
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

            var testPracResults = GetExamplePracResultsLine(example, TestPeriod, restService);

            output.WriteLine(testPracResults);

            var testPPomResults = GetExamplePPomResultsLine(example, TestPeriod, restService);

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

        [Fact]
        public void ServiceExamples_CreateImport()
        {
            System.Text.EncodingProvider ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);

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

                foreach (var example in _genTests)
                {
                    foreach (var impLine in example.BuildImportString(TestPeriod, testRuleset, prevRuleset))
                    {
                        testProtokol.WriteLine(impLine);
                    }
                }
                ExportPropsEnd(testProtokol);
            }
        }

        [Fact]
        public void ServiceExamples_101_PPomMzdaDanPojSlevyZakladTest()
        {
            ExampleGenerator example = ExampleGenerator.Spec(101, "PP-Mzda_DanPoj-SlevyZaklad", "101")
                .WithContracts(ContractGenerator.SpecEmp(1));
            ServiceExampleTest(example);
        }

        [Fact]
        public void ServiceExamples_105_PPomMzdaDanMaxBonusTest()
        {
            ExampleGenerator example = ExampleGenerator.Spec(105, "PP-Mzda_DanPoj-MaxBonus", "105")
                .WithContracts(ContractGenerator.SpecEmp(1)
                    .WithSalary(MaxBonus()))
                .WithChild(ChildGenerator.SpecDisb(1, 1, 5));
            ServiceExampleTest(example);
        }

        [Fact]
        public void ServiceExamples_108_PPomMzdaDanMaxZdravPrevTest()
        {
            ExampleGenerator example = ExampleGenerator.Spec(108, "PP-Mzda_DanPoj-MaxZdravPrev", "108")
                .WithContracts(ContractGenerator.SpecEmp(1)
                    .WithSalary(MaxZdrPrev(100)));
            ServiceExampleTest(example);
        }

        [Fact]
        public void ServiceExamples_201_PPomMzdaNepodPojPrevLoTest()
        {
            ExampleGenerator example = ExampleGenerator.Spec(201, "PP-Mzda_NepodPoj-PrevLo", "201")
                .WithContracts(ContractGenerator.SpecEmp(1)
                    .WithSalary(SrazNepPrev(0)))
                .WithTaxDecl(GenValue(0));
            ServiceExampleTest(example);
        }

        [Fact]
        public void ServiceExamples_301_PPomMzdaDanPojDan099Test()
        {
            ExampleGenerator example = ExampleGenerator.Spec(301, "PP-Mzda_DanPoj-Dan099", "301")
                .WithContracts(ContractGenerator.SpecEmp(1)
                    .WithSalary(ConValue(0))
                    .WithAgreem(ConValue(74))
                    .WithHealthMinim(ConValue(0)));
            ServiceExampleTest(example);
        }

        [Fact]
        public void ServiceExamples_501_PPomMzdaNeUcastZdravPrevTest()
        {
            ExampleGenerator example = ExampleGenerator.Spec(501, "DPC-Mzda_NeUcastZdrav-Prev", "501")
                .WithContracts(ContractGenerator.SpecDpc(1)
                    .WithSalary(ConValue(0))
                    .WithAgreem(UcastZdrPrev(-1))
                    .WithHealthMinim(ConValue(0)))
                .WithTaxDecl(GenValue(0));
            ServiceExampleTest(example);
        }

        [Fact]
        public void ServiceExamples_502_PPomMzdaUcastZdravPrevTest()
        {
            ExampleGenerator example = ExampleGenerator.Spec(502, "DPC-Mzda_UcastZdrav-Prev", "502")
                .WithContracts(ContractGenerator.SpecDpc(1)
                    .WithSalary(ConValue(0))
                    .WithAgreem(UcastZdrPrev(0))
                    .WithHealthMinim(ConValue(0)))
                .WithTaxDecl(GenValue(0));
            ServiceExampleTest(example);
        }

        [Fact]
        public void ServiceExamples_601_PPomMzdaNeUcastNemocPrevTest()
        {
            ExampleGenerator example = ExampleGenerator.Spec(601, "DPP-Mzda_NeUcastNemoc-Prev", "601")
                .WithContracts(ContractGenerator.SpecDpp(1)
                    .WithSalary(ConValue(0))
                    .WithAgreem(UcastNemPrev(-1))
                    .WithHealthMinim(ConValue(0)))
                .WithTaxDecl(GenValue(0));
            ServiceExampleTest(example);
        }

        [Theory]
        [MemberData(nameof(GenTestData))]
        public void ServiceExamplesTest(ExampleGenerator example)
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

            var targets = example.BuildSpecTargets(TestPeriod, testRuleset, prevRuleset);

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

            using (var testProtokol = OpenProtokolFile($"OKPRAC_TEST_2013_HRM_{TestPeriod.Code}.CSV"))
            {
                var testResults = GetExamplePracResultsLine(example, TestPeriod, restService);
                testProtokol.WriteLine(testResults);
            }
            using (var testProtokol = OpenProtokolFile($"OKPPOM_TEST_2013_HRM_{TestPeriod.Code}.CSV"))
            {
                var testResults = GetExamplePPomResultsLine(example, TestPeriod, restService);
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
