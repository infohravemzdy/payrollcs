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
using HraveMzdy.Procezor.Optimula.Registry.Constants;
using HraveMzdy.Procezor.Optimula.Service;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Optimula.Registry.Providers;
using Procezor.OptimulaTest.Examples;
using System.IO;

namespace Procezor.OptimulaTest.Service
{
    public class ServiceTestExampleTemplate
    {
#if __MACOS__
        public const string PROTOKOL_TEST_FOLDER = "../../../test_import";
#else
        public const string PROTOKOL_TEST_FOLDER = "..\\..\\..\\test_import";
#endif
        public const string PROTOKOL_FOLDER_NAME = "test_import";
        public const string PARENT_PROTOKOL_FOLDER_NAME = "Procezor.OptimulaTest";

        protected const string TestFolder = PROTOKOL_TEST_FOLDER;

        protected readonly ITestOutputHelper output;

        protected readonly IServiceProcezor _sut;
        protected readonly IServiceLegalios _leg;

        protected static readonly OptimulaGenerator[] _genTests = new OptimulaGenerator[] {
            OptimulaGenerator.Spec(101, "FullTime_OverTimeZeroHolidaysZero", "101").WithFullSheetHrsVal(168*60).WithTimeSheetHrsVal(168*60).WithWorkSheetHrsVal(168*60).WithOverSheetHrsVal(0).WithHoliSheetHrsVal(0).WithMSalaryBonusVal(570000).WithHomeOffTarifVal(11000).WithHomeOffHoursVal(40*60).WithClothesTarifVal(10600).WithAgrWorkRatioVal(14).WithAgrWorkTarifVal(10000),
            OptimulaGenerator.Spec(102, "FullTime_OverTimeHs16HolidaysZero", "102").WithFullSheetHrsVal(168*60).WithTimeSheetHrsVal(168*60).WithWorkSheetHrsVal(168*60).WithOverSheetHrsVal(16*60).WithHoliSheetHrsVal(0).WithMSalaryBonusVal(570000).WithHomeOffTarifVal(11000).WithHomeOffHoursVal(40*60).WithClothesTarifVal(10600).WithAgrWorkRatioVal(14).WithAgrWorkTarifVal(10000),
            OptimulaGenerator.Spec(103, "FullTime_OverTimeZeroHolidaysHs16", "103").WithFullSheetHrsVal(168*60).WithTimeSheetHrsVal(168*60).WithWorkSheetHrsVal(168*60).WithOverSheetHrsVal(0).WithHoliSheetHrsVal(16*60).WithMSalaryBonusVal(570000).WithHomeOffTarifVal(11000).WithHomeOffHoursVal(40*60).WithClothesTarifVal(10600).WithAgrWorkRatioVal(14).WithAgrWorkTarifVal(10000),
            OptimulaGenerator.Spec(104, "FullTime_OverTimeHs16HolidaysHs16", "104").WithFullSheetHrsVal(168*60).WithTimeSheetHrsVal(168*60).WithWorkSheetHrsVal(168*60).WithOverSheetHrsVal(16*60).WithHoliSheetHrsVal(16*60).WithMSalaryBonusVal(570000).WithHomeOffTarifVal(11000).WithHomeOffHoursVal(40*60).WithClothesTarifVal(10600).WithAgrWorkRatioVal(14).WithAgrWorkTarifVal(10000),
            OptimulaGenerator.Spec(111, "WorkTime_OverTimeZeroHolidaysZero", "111").WithFullSheetHrsVal(168*60).WithTimeSheetHrsVal(168*60).WithWorkSheetHrsVal(160*60).WithOverSheetHrsVal(0).WithHoliSheetHrsVal(0).WithMSalaryBonusVal(570000).WithHomeOffTarifVal(11000).WithHomeOffHoursVal(40*60).WithClothesTarifVal(10600).WithAgrWorkRatioVal(14).WithAgrWorkTarifVal(10000),
            OptimulaGenerator.Spec(112, "WorkTime_OverTimeHs16HolidaysZero", "112").WithFullSheetHrsVal(168*60).WithTimeSheetHrsVal(168*60).WithWorkSheetHrsVal(160*60).WithOverSheetHrsVal(16*60).WithHoliSheetHrsVal(0).WithMSalaryBonusVal(570000).WithHomeOffTarifVal(11000).WithHomeOffHoursVal(40*60).WithClothesTarifVal(10600).WithAgrWorkRatioVal(14).WithAgrWorkTarifVal(10000),
            OptimulaGenerator.Spec(113, "WorkTime_OverTimeZeroHolidaysHs16", "113").WithFullSheetHrsVal(168*60).WithTimeSheetHrsVal(168*60).WithWorkSheetHrsVal(160*60).WithOverSheetHrsVal(0).WithHoliSheetHrsVal(16*60).WithMSalaryBonusVal(570000).WithHomeOffTarifVal(11000).WithHomeOffHoursVal(40*60).WithClothesTarifVal(10600).WithAgrWorkRatioVal(14).WithAgrWorkTarifVal(10000),
            OptimulaGenerator.Spec(114, "WorkTime_OverTimeHs16HolidaysHs16", "114").WithFullSheetHrsVal(168*60).WithTimeSheetHrsVal(168*60).WithWorkSheetHrsVal(160*60).WithOverSheetHrsVal(16*60).WithHoliSheetHrsVal(16*60).WithMSalaryBonusVal(570000).WithHomeOffTarifVal(11000).WithHomeOffHoursVal(40*60).WithClothesTarifVal(10600).WithAgrWorkRatioVal(14).WithAgrWorkTarifVal(10000),
        };

        protected static readonly OptimulaGenerator[] _genExamplesTests = new OptimulaGenerator[] {
            OptimulaGenerator.ParseSpec(101, "101;Drahota Jakub;105,00;0,14;0,00;0,00;57,00;0,00;0,00;8 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;96,00;12,00;40,00;80,00;0,00;0,00;;;;40,00;0,25;0,00;0,00;0,00;0,00;18,25;0,10;0,00;0,00;3 506,00;0,00;8 852,00;912,08;"),
            OptimulaGenerator.ParseSpec(106, "106;Svoboda Tomáš;150,00;0,14;0,00;0,00;83,00;0,00;0,00;11 250,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;136,00;17,00;0,00;40,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;5 229,00;0,00;16 021,00;840,00;"),
            OptimulaGenerator.ParseSpec(114, "114;Kotlas Tomáš;120,00;0,14;0,00;0,00;48,00;0,00;0,00;5 100,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;128,00;16,00;0,00;48,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;2 880,00;0,00;11 238,00;800,00;"),
            OptimulaGenerator.ParseSpec(116, "116;Kyrianová Miroslava;0,00;0,00;0,00;0,00;100,00;0,00;0,00;6 250,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;128,00;16,00;0,00;40,00;8,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,10;0,00;0,00;5 550,00;0,00;0,00;741,67;"),
            OptimulaGenerator.ParseSpec(131, "131;Novotný Michal;200,00;0,14;0,00;0,00;57,00;0,00;0,00;5 250,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;136,00;17,00;24,75;40,00;0,00;0,00;;;;24,75;0,25;0,00;0,00;0,00;0,00;0,00;0,10;0,00;0,00;3 648,00;0,00;11 852,00;1 146,25;"),
            OptimulaGenerator.ParseSpec(134, "134;Henzl Pavel;270,00;0,14;0,00;0,00;100,00;0,00;0,00;10 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;112,00;14,00;0,00;64,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;6,50;0,10;0,00;0,00;6 500,00;0,00;22 250,00;866,67;"),
            OptimulaGenerator.ParseSpec(140, "140;Šorf Vít;120,00;0,14;0,00;0,00;48,00;0,00;0,00;7 500,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,10;0,00;0,00;2 304,00;0,00;14 319,00;646,25;"),
            OptimulaGenerator.ParseSpec(149, "149;Smejkal Jiří;105,00;0,14;0,00;0,00;57,00;0,00;0,00;4 200,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;152,00;19,00;1,75;24,00;0,00;0,00;;;;1,75;0,25;0,00;0,00;0,00;0,00;5,75;0,10;0,00;0,00;3 534,00;0,00;8 475,00;834,58;"),
            OptimulaGenerator.ParseSpec(164, "164;Hánová Lenka;100,00;0,14;0,00;0,00;52,00;0,00;0,00;3 450,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;152,00;19,00;0,00;24,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;3 276,00;0,00;6 760,00;840,00;"),
            OptimulaGenerator.ParseSpec(170, "170;Švadlenka Martin;200,00;0,14;0,00;0,00;48,00;0,00;0,00;20 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;104,00;13,00;0,00;72,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;3 096,00;0,00;10 302,00;860,00;"),
            OptimulaGenerator.ParseSpec(176, "176;Čejková Martina;100,00;0,14;0,00;0,00;48,00;0,00;0,00;6 500,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;136,00;17,00;13,25;0,00;0,00;0,00;;;;13,25;0,25;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;2 976,00;0,00;12 754,00;906,67;"),
            OptimulaGenerator.ParseSpec(194, "194;Slabý Jiří;0,00;0,00;0,00;0,00;100,00;0,00;0,00;3 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;160,00;20,00;0,00;16,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;6 500,00;0,00;0,00;773,33;"),
            OptimulaGenerator.ParseSpec(197, "197;Musil Jiří;110,00;0,14;0,00;0,00;100,00;0,00;0,00;7 500,00;0,00;0,00;0,00;0,00;165,00;165,00;0,00;165,00;22,00;21,50;0,00;0,00;0,00;;;;21,50;0,25;0,00;0,00;0,00;0,00;14,25;0,10;0,00;0,00;6 200,00;0,00;8 800,00;924,17;"),
            OptimulaGenerator.ParseSpec(213, "213;Lipková Olga;120,00;0,14;0,00;0,00;52,00;0,00;0,00;3 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;152,00;19,00;0,00;24,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;3 172,00;0,00;5 270,00;813,33;"),
            OptimulaGenerator.ParseSpec(219, "219;Kohoutová Lucie;170,00;0,14;0,00;0,00;100,00;0,00;0,00;3 600,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;136,00;17,00;119,00;40,00;0,00;0,00;;;;119,00;0,25;0,00;0,00;0,00;0,00;65,00;0,10;0,00;0,00;5 500,00;0,00;3 625,00;1 506,67;"),
            OptimulaGenerator.ParseSpec(220, "220;Kárník Ondřej;105,00;0,14;0,00;0,00;57,00;0,00;0,00;7 500,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;120,00;15,00;23,50;56,00;0,00;0,00;;;;23,50;0,25;0,00;0,00;0,00;0,00;5,50;0,10;0,00;0,00;3 192,00;0,00;12 742,00;989,17;"),
            OptimulaGenerator.ParseSpec(222, "222;Strašilová Jitka;110,00;0,14;0,00;0,00;100,00;0,00;0,00;5 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;152,00;19,00;0,00;24,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;6,50;0,10;0,00;0,00;6 200,00;0,00;8 118,00;826,67;"),
            OptimulaGenerator.ParseSpec(226, "226;Prokš Michal;130,00;0,14;0,00;0,00;100,00;0,00;0,00;7 000,00;0,00;0,00;0,00;0,00;165,00;165,00;0,00;67,50;9,00;10,25;97,50;0,00;0,00;;;;10,25;0,25;0,00;0,00;0,00;0,00;1,50;0,10;0,00;0,00;5 400,00;0,00;8 707,00;786,25;"),
            OptimulaGenerator.ParseSpec( 24, "24;Pejzlová Hana;110,00;0,14;0,00;0,00;52,00;0,00;0,00;8 750,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;136,00;17,00;0,00;40,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;3 380,00;0,00;19 120,00;880,00;"),
            OptimulaGenerator.ParseSpec(240, "240;Pazourová Jitka;100,00;0,14;0,00;0,00;48,00;0,00;0,00;6 250,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;132,00;16,50;0,00;44,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;2 952,00;0,00;14 790,00;820,00;"),
            OptimulaGenerator.ParseSpec(275, "275;Ondráček Vojtěch;105,00;0,14;0,00;0,00;57,00;0,00;0,00;6 500,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;96,00;12,00;4,75;72,00;8,00;0,00;;;;4,75;0,25;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;3 363,00;0,00;5 630,00;892,08;"),
            OptimulaGenerator.ParseSpec(294, "294;Havelková Ludmila;200,00;0,14;0,00;0,00;52,00;0,00;0,00;10 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;136,00;17,00;0,00;24,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;3 172,00;0,00;24 988,00;740,00;"),
            OptimulaGenerator.ParseSpec(296, "296;Škrábek Michal;120,00;0,14;0,00;0,00;57,00;0,00;0,00;4 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;144,00;18,00;34,00;0,00;8,00;0,00;;;;34,00;0,25;0,00;0,00;0,00;0,00;21,75;0,10;0,00;0,00;3 192,00;0,00;7 146,00;812,08;"),
            OptimulaGenerator.ParseSpec(306, "306;Skopalová Iveta;91,00;0,14;0,00;0,00;100,00;0,00;0,00;5 750,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;176,00;22,00;14,50;0,00;0,00;0,00;;;;14,50;0,25;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;"),
            OptimulaGenerator.ParseSpec(309, "309;Fajmon Jan;105,00;0,14;0,00;0,00;57,00;0,00;0,00;6 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;152,00;19,00;5,75;24,00;0,00;0,00;;;;5,75;0,25;0,00;0,00;0,00;0,00;10,25;0,10;0,00;0,00;3 192,00;0,00;12 314,00;898,75;"),
            OptimulaGenerator.ParseSpec(331, "331;Makaloušová Marie;91,00;0,14;0,00;0,00;48,00;0,00;0,00;5 750,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;40,00;5,00;0,00;16,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,10;0,00;0,00;3 000,00;0,00;12 994,00;889,17;"),
            OptimulaGenerator.ParseSpec(336, "336;Andrš Martin;120,00;0,14;0,00;0,00;48,00;0,00;0,00;10 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;112,00;14,00;0,00;64,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;2 544,00;0,00;21 980,00;706,67;"),
            OptimulaGenerator.ParseSpec(344, "344;Nováček Tomáš;120,00;0,14;0,00;0,00;57,00;0,00;0,00;6 750,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;96,00;12,00;23,00;80,00;0,00;0,00;;;;23,00;0,25;0,00;0,00;0,00;0,00;8,50;0,10;0,00;0,00;3 591,00;0,00;16 031,00;989,58;"),
            OptimulaGenerator.ParseSpec(348, "348;Staněk Jaroslav;120,00;0,14;0,00;0,00;83,00;0,00;0,00;10 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;136,00;17,00;0,00;0,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;5 395,00;0,00;22 730,00;866,67;"),
            OptimulaGenerator.ParseSpec(349, "349;Augustinová Jana;120,00;0,14;0,00;0,00;100,00;0,00;0,00;5 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;96,00;12,00;0,00;80,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;6 400,00;0,00;8 362,00;853,33;"),
            OptimulaGenerator.ParseSpec(351, "351;Matoušková Veronika;120,00;0,14;0,00;0,00;48,00;0,00;0,00;8 250,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;152,00;19,00;0,00;24,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;3 120,00;0,00;20 130,00;866,67;"),
            OptimulaGenerator.ParseSpec(365, "365;Kohout Lukáš;350,00;0,14;0,00;0,00;48,00;0,00;0,00;12 500,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;176,00;22,00;0,00;0,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;2 152,00;0,00;30 000,00;866,67;"),
            OptimulaGenerator.ParseSpec(366, "366;Průchová Marcela;320,00;0,14;0,00;0,00;48,00;110,00;40,00;12 500,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;112,00;14,00;0,00;56,00;8,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;4 400,00;8 100,00;293,33;"),
            OptimulaGenerator.ParseSpec(370, "370;Pešek Pavel;150,00;0,14;0,00;0,00;48,00;0,00;0,00;6 625,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;136,00;17,00;7,75;40,00;0,00;0,00;;;;7,75;0,25;0,00;0,00;0,00;0,00;14,50;0,10;0,00;0,00;2 064,00;0,00;10 436,00;625,42;"),
            OptimulaGenerator.ParseSpec(375, "375;Štefanová Nela;120,00;0,14;0,00;0,00;48,00;0,00;0,00;4 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;120,00;15,00;0,00;56,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;2 016,00;0,00;6 591,00;560,00;"),
            OptimulaGenerator.ParseSpec(377, "377;Brůha Jiří;110,00;0,14;0,00;0,00;100,00;0,00;0,00;6 250,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;139,50;17,50;0,00;8,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;2,00;0,10;0,00;0,00;5 200,00;0,00;9 804,00;690,83;"),
            OptimulaGenerator.ParseSpec(387, "387;Krejča Vojtěch;150,00;0,14;0,00;0,00;48,00;0,00;0,00;7 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;176,00;22,00;68,75;0,00;0,00;0,00;;;;68,75;0,25;0,00;0,00;0,00;0,00;45,75;0,10;0,00;0,00;3 000,00;0,00;5 626,00;591,25;"),
            OptimulaGenerator.ParseSpec(400, "400;Vytlačil Lukáš;120,00;0,14;0,00;0,00;48,00;0,00;0,00;7 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;176,00;22,00;18,25;0,00;0,00;0,00;;;;18,25;0,25;0,00;0,00;0,00;0,00;10,75;0,10;0,00;0,00;1 056,00;0,00;5 944,00;321,25;"),
            OptimulaGenerator.ParseSpec(401, "401;Beranová Dana;130,00;0,14;0,00;0,00;48,00;0,00;0,00;7 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;176,00;22,00;0,00;0,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;"),
            OptimulaGenerator.ParseSpec(403, "403;Košetický Jiří;105,00;0,14;0,00;0,00;48,00;0,00;0,00;6 250,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;176,00;22,00;21,50;0,00;0,00;0,00;;;;21,50;0,25;0,00;0,00;0,00;0,00;0,00;0,10;0,00;0,00;1 056,00;0,00;5 194,00;322,92;"),
            OptimulaGenerator.ParseSpec(408, "408;Prchal Zdeněk;130,00;0,14;0,00;0,00;48,00;0,00;0,00;6 750,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;176,00;22,00;0,00;0,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;"),
            OptimulaGenerator.ParseSpec(410, "410;Bleha Stanislav;120,00;0,14;0,00;0,00;48,00;0,00;0,00;7 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;168,00;21,00;28,00;0,00;8,00;0,00;;;;28,00;0,25;0,00;0,00;0,00;0,00;22,75;0,10;0,00;0,00;384,00;0,00;2 161,00;110,00;"),
            OptimulaGenerator.ParseSpec(413, "413;Klusáček Tomáš;120,00;0,14;0,00;0,00;48,00;0,00;0,00;7 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;176,00;22,00;33,50;0,00;0,00;0,00;;;;33,50;0,25;0,00;0,00;0,00;0,00;25,00;0,10;0,00;0,00;288,00;0,00;1 621,00;88,33;"),
            OptimulaGenerator.ParseSpec(425, "425;Herold Lukáš;150,00;0,14;0,00;0,00;100,00;0,00;0,00;8 750,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;176,00;22,00;28,00;0,00;0,00;0,00;;;;28,00;0,25;0,00;0,00;0,00;0,00;4,25;0,10;0,00;0,00;0,00;0,00;0,00;0,00;"),
            OptimulaGenerator.ParseSpec( 49, "49;Pometlo Jan;110,00;0,14;0,00;0,00;100,00;0,00;0,00;8 250,00;0,00;0,00;0,00;0,00;165,00;165,00;0,00;165,00;22,00;115,25;0,00;0,00;0,00;;;;115,25;0,25;0,00;0,00;0,00;0,00;58,25;0,10;0,00;0,00;6 300,00;0,00;10 253,00;1 249,17;"),
            OptimulaGenerator.ParseSpec( 65, "65;Ježilová Hana;130,00;0,14;0,00;0,00;48,00;0,00;0,00;7 500,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;152,00;19,00;4,50;16,00;8,00;0,00;;;;4,50;0,25;0,00;0,00;0,00;0,00;11,50;0,10;0,00;0,00;2 448,00;0,00;15 231,00;703,33;"),
            OptimulaGenerator.ParseSpec( 86, "86;Hanzalová Michaela;220,00;0,14;0,00;0,00;52,00;110,00;40,00;15 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;104,00;13,00;0,00;72,00;0,00;0,00;;;;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;2 236,00;8 705,00;18 734,00;573,33;"),
            OptimulaGenerator.ParseSpec( 91, "91;Pejzl Jan;120,00;0,14;0,00;0,00;83,00;0,00;0,00;5 250,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;48,00;6,00;9,25;128,00;0,00;0,00;;;;9,25;0,25;0,00;0,00;0,00;0,00;0,00;0,00;0,00;0,00;4 648,00;0,00;8 908,00;965,42;"),
        };

        public static IEnumerable<object[]> GetGenTestDecData(IEnumerable<OptimulaGenerator> tests, IPeriod testPeriod, Int32 testPeriodCode, Int32 prevPeriodCode)
        {
            System.Text.EncodingProvider ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);

            return tests.Select((tt) => (new object[] { tt }));
        }

        public ServiceTestExampleTemplate(ITestOutputHelper output)
        {
            this.output = output;

            this._sut = new ServiceOptimula();
            this._leg = new ServiceLegalios();
        }
        public static IPeriod PrevYear(IPeriod period)
        {
            return new Period(Math.Max(2010, period.Year - 1), period.Month);
        }
        public static IBundleProps CurrYearBundle(IServiceLegalios legSvc, IPeriod period)
        {
            var legResult = legSvc.GetBundle(period);
            return legResult.Value;
        }
        public static IBundleProps PrevYearBundle(IServiceLegalios legSvc, IPeriod period)
        {
            var legResult = legSvc.GetBundle(PrevYear(period));
            return legResult.Value;
        }
        protected static StreamWriter CreateProtokolFile(string fileName)
        {
            string filePath = Path.GetFullPath(Path.Combine(TestFolder, fileName));

            string currPath = Path.GetFullPath(".");
            int nameCount = currPath.Split(Path.DirectorySeparatorChar).Length;

            while (!currPath.EndsWith(PARENT_PROTOKOL_FOLDER_NAME) && nameCount != 1)
            {
                currPath = Path.GetDirectoryName(currPath);
            }
            string basePath = Path.Combine(currPath, PROTOKOL_FOLDER_NAME);
            if (nameCount <= 1)
            {
                basePath = Path.Combine(Path.GetFullPath("."), PROTOKOL_FOLDER_NAME);
            }
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            filePath = Path.Combine(basePath, fileName);
            FileStream fileStream = new FileInfo(filePath).Create();
            return new StreamWriter(fileStream, System.Text.Encoding.GetEncoding("windows-1250"));
        }
        protected static StreamWriter OpenProtokolFile(string fileName)
        {
            string filePath = Path.GetFullPath(Path.Combine(TestFolder, fileName));

            string currPath = Path.GetFullPath(".");
            int nameCount = currPath.Split(Path.DirectorySeparatorChar).Length;

            while (!currPath.EndsWith(PARENT_PROTOKOL_FOLDER_NAME) && nameCount != 1)
            {
                currPath = Path.GetDirectoryName(currPath);
            }
            string basePath = Path.Combine(currPath, PROTOKOL_FOLDER_NAME);
            if (nameCount <= 1)
            {
                basePath = Path.Combine(Path.GetFullPath("."), PROTOKOL_FOLDER_NAME);
            }
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            filePath = Path.Combine(basePath, fileName);
            FileStream fileStream = new FileInfo(filePath).Open(FileMode.Append, FileAccess.Write);
            return new StreamWriter(fileStream, System.Text.Encoding.GetEncoding("windows-1250"));
        }
        protected static void ExportPropsXlsStart(StreamWriter protokol)
        {
            string[] headerList = new string[]
            {
                "EmployeeNumb", // A
                "EmployeeName", // B
                "AgrWorkTarif", // C
                "AgrWorkRatio", // D
                "AgrHourLimit", // E
                "AgrWorkLimit", // F
                "ClothesTarif", // G
                "HomeOffTarif", // H
                "HomeOffHours", // I
                "MSalaryBonus", // J
                "HHourlyBonus", // K
                "FPremiumBase", // L
                "FPremiumBoss", // M
                "FPremiumPers", // N
                "FullSheetHrs", // O  
                "TimeSheetHrs", // P  
                "HoliSheetHrs", // Q  
                "WorkSheetHrs", // R  
                "WorkSheetDay", // S   
                "OverSheetHrs", // T
                "VacaRecomHrs", // U
                "PaidRecomHrs", // V
                "HoliRecomHrs", // W  
                "", // X
                "", // Y
                "", // Z
                "OverAllowHrs", // AA
                "OverAllowRio", // AB
                "RestAllowHrs", // AC
                "RestAllowRio", // AD
                "WendAllowHrs", // AE
                "WendAllowRio", // AF
                "NighAllowHrs", // AG
                "NighAllowRio", // AH
                "HoliAllowHrs", // AI
                "HoliAllowRio", // AJ
                "QClothesBase", // AK
                "QHOfficeBase", // AL
                "QAgrWorkBase", // AM
                "QSumWorkHour", // AN
            };                     
            protokol.WriteLine(string.Join('\t', headerList));
        }
        protected static void ExportPropsCsvStart(StreamWriter protokol)
        {
            string[] headerList = new string[]
            {
                "EmployeeNumb", // A
                "EmployeeName", // B
                "AgrWorkTarif", // C
                "AgrWorkRatio", // D
                "AgrHourLimit", // E
                "AgrWorkLimit", // F
                "ClothesTarif", // G
                "HomeOffTarif", // H
                "HomeOffHours", // I
                "MSalaryBonus", // J
                "HHourlyBonus", // K
                "FPremiumBase", // L
                "FPremiumBoss", // M
                "FPremiumPers", // N
                "FullSheetHrs", // O  
                "TimeSheetHrs", // P  
                "HoliSheetHrs", // Q  
                "WorkSheetHrs", // R  
                "WorkSheetDay", // S   
                "OverSheetHrs", // T
                "VacaRecomHrs", // U
                "PaidRecomHrs", // V
                "HoliRecomHrs", // W  
                "", // X
                "", // Y
                "", // Z
                "OverAllowHrs", // AA
                "OverAllowRio", // AB
                "RestAllowHrs", // AC
                "RestAllowRio", // AD
                "WendAllowHrs", // AE
                "WendAllowRio", // AF
                "NighAllowHrs", // AG
                "NighAllowRio", // AH
                "HoliAllowHrs", // AI
                "HoliAllowRio", // AJ
                "QClothesBase", // AK
                "QHOfficeBase", // AL
                "QAgrWorkBase", // AM
                "QSumWorkHour", // AN
            };                     
            protokol.WriteLine(string.Join(';', headerList)+";");
        }

        protected static void ExportPropsEnd(StreamWriter protokol)
        {
        }
        protected void ServiceExamplesCreateImport(IEnumerable<OptimulaGenerator> tests, IPeriod testPeriod, Int32 testPeriodCode, Int32 prevPeriodCode)
        {
            System.Text.EncodingProvider ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);

            try
            {
                testPeriod.Code.Should().Be(testPeriodCode);

                var prevPeriod = PrevYear(testPeriod);
                prevPeriod.Code.Should().Be(prevPeriodCode);

                var testLegalResult = _leg.GetBundle(testPeriod);
                testLegalResult.IsSuccess.Should().Be(true);

                var testRuleset = testLegalResult.Value;

                var prevLegalResult = _leg.GetBundle(prevPeriod);
                prevLegalResult.IsSuccess.Should().Be(true);

                var prevRuleset = prevLegalResult.Value;

                using (var testProtokol = CreateProtokolFile($"OptimulaImport_{testPeriod.Year}.xls"))
                {
                    ExportPropsXlsStart(testProtokol);

                    foreach (var example in tests)
                    {
                        foreach (var impLine in example.BuildImportXlsString(testPeriod, testRuleset, prevRuleset))
                        {
                            testProtokol.WriteLine(impLine);
                        }
                    }
                    ExportPropsEnd(testProtokol);
                }
                using (var testProtokol = CreateProtokolFile($"OptimulaImport_{testPeriod.Year}.csv"))
                {
                    ExportPropsCsvStart(testProtokol);

                    foreach (var example in tests)
                    {
                        foreach (var impLine in example.BuildImportCsvString(testPeriod, testRuleset, prevRuleset))
                        {
                            testProtokol.WriteLine(impLine);
                        }
                    }
                    ExportPropsEnd(testProtokol);
                }
            }
            catch (Xunit.Sdk.XunitException e)
            {
                throw e;
            }
        }
        protected void ServiceExampleTest(OptimulaGenerator example, IPeriod testPeriod, Int32 testPeriodCode, Int32 prevPeriodCode)
        {
            output.WriteLine($"Test: {example.Name}, Number: {example.Number}");
            try
            {
                testPeriod.Code.Should().Be(testPeriodCode);

                var prevPeriod = PrevYear(testPeriod);
                prevPeriod.Code.Should().Be(prevPeriodCode);

                var testLegalResult = _leg.GetBundle(testPeriod);
                testLegalResult.IsSuccess.Should().Be(true);

                var testRuleset = testLegalResult.Value;

                var prevLegalResult = _leg.GetBundle(prevPeriod);
                prevLegalResult.IsSuccess.Should().Be(true);

                var prevRuleset = prevLegalResult.Value;

                var targets = example.BuildSpecTargets(testPeriod, testRuleset, prevRuleset);
                foreach (var (target, index) in targets.Select((item, index) => (item, index)))
                {
                    var articleSymbol = target.ArticleDescr();
                    var conceptSymbol = target.ConceptDescr();
                    output.WriteLine("Index: {0}, ART: {1}, CON: {2}, con: {3}, pos: {4}, var: {5}", index, articleSymbol, conceptSymbol, target.Contract.Value, target.Position.Value, target.Variant.Value);
                }

                var initService = _sut.InitWithPeriod(testPeriod);
                initService.Should().BeTrue();

                var restService = _sut.GetResults(testPeriod, testRuleset, targets);
                restService.Count().Should().NotBe(0);

                output.WriteLine($"Result Test: {example.Name}, Number: {example.Number}");

                foreach (var (result, index) in restService.Select((item, index) => (item, index)))
                {
                    if (result.IsSuccess)
                    {
                        var resultValue = result.Value as OptimulaTermResult;
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
            catch (Xunit.Sdk.XunitException e)
            {
                throw e;
            }
        }
        protected void ServiceTemplateExampleTest(OptimulaGenerator example, IPeriod testPeriod, Int32 testPeriodCode, Int32 prevPeriodCode)
        {
            if (example.Id == 101)
            {
                string[] strHeaderRadkaPRAC = new string[] {
                    "EMPLOYEEID",
                };
                using (var testProtokol = CreateProtokolFile($"OPTIMIT_TEST_{testPeriod.Year}_{testPeriod.Code}.CSV"))
                {
                    testProtokol.WriteLine(string.Join(";", strHeaderRadkaPRAC));
                }
            }
            output.WriteLine($"Test: {example.Name}, Number: {example.Number}");

            try
            {
                testPeriod.Code.Should().Be(testPeriodCode);

                var prevPeriod = PrevYear(testPeriod);
                prevPeriod.Code.Should().Be(prevPeriodCode);

                var testLegalResult = _leg.GetBundle(testPeriod);
                testLegalResult.IsSuccess.Should().Be(true);

                var testRuleset = testLegalResult.Value;

                var prevLegalResult = _leg.GetBundle(prevPeriod);
                prevLegalResult.IsSuccess.Should().Be(true);

                var prevRuleset = prevLegalResult.Value;

                var targets = example.BuildSpecTargets(testPeriod, testRuleset, prevRuleset);

                foreach (var (target, index) in targets.Select((item, index) => (item, index)))
                {
                    var articleSymbol = target.ArticleDescr();
                    var conceptSymbol = target.ConceptDescr();
                    output.WriteLine("Index: {0}, ART: {1}, CON: {2}, con: {3}, pos: {4}, var: {5}", index, articleSymbol, conceptSymbol, target.Contract.Value, target.Position.Value, target.Variant.Value);
                }

                var initService = _sut.InitWithPeriod(testPeriod);
                initService.Should().BeTrue();

                var restService = _sut.GetResults(testPeriod, testRuleset, targets);
                restService.Count().Should().NotBe(0);

                using (var testProtokol = OpenProtokolFile($"OPTIMIT_TEST_{testPeriod.Year}_{testPeriod.Code}.CSV"))
                {
                    var testResults = ""; // GetExamplePracResultsLine(example, testPeriod, restService);
                    testProtokol.WriteLine(testResults);
                }

                output.WriteLine($"Result Test: {example.Name}, Number: {example.Number}");

                foreach (var (result, index) in restService.Select((item, index) => (item, index)))
                {
                    if (result.IsSuccess)
                    {
                        var resultValue = result.Value as OptimulaTermResult;
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
            catch (Xunit.Sdk.XunitException e)
            {
                throw e;
            }
        }

        public OptimulaGenerator Example_101_OPTDppPremieZaklad()
        {
            return OptimulaGenerator.ParseSpec(101, "101;Drahota Jakub;105,00;0,14;0,00;0,00;57,00;0,00;0,00;8 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;96,00;12,00;40,00;80,00;0,00;0,00;40,00;0,25;0,00;0,00;0,00;0,00;18,25;0,10;0,00;0,00;3 506,00;0,00;8 852,00;912,08");
        }
        public OptimulaGenerator Example_101_FullTime_OverTimeZeroHolidaysZero()
        {
            return OptimulaGenerator.Spec(101, "FullTime_OverTimeZeroHolidaysZero", "101")
                .WithFullSheetHrsVal(168 * 60)
                .WithTimeSheetHrsVal(168 * 60)
                .WithWorkSheetHrsVal(168 * 60)
                .WithOverSheetHrsVal(0 * 60)
                .WithHoliSheetHrsVal(0 * 60)
                .WithMSalaryBonusVal(5700 * 100)
                .WithHomeOffTarifVal(110 * 100)
                .WithHomeOffHoursVal(40 * 60)
                .WithClothesTarifVal(11 * 100 + 17) // 11,17 Kč
                .WithAgrWorkRatioVal(0 * 100 + 14) // procent 0,14
                .WithAgrWorkTarifVal(100 * 100);
        }
    }
}
