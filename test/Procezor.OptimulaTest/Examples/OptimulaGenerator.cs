using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;
using HraveMzdy.Procezor.Optimula.Registry.Constants;
using HraveMzdy.Procezor.Optimula.Registry.Providers;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;

namespace Procezor.OptimulaTest.Examples
{
    public class OptimulaGenerator
    {
        public OptimulaGenerator(int id, string name, string number)
        {
            Id = id;
            Name = name;
            Number = number;

            DefaultAgrWorkTarifValue = 0;
            DefaultAgrWorkRatioValue = 0;
            DefaultAgrHourLimitValue = 0;
            DefaultAgrWorkLimitValue = 0;
            DefaultClothesHoursValue = 0;
            DefaultClothesDailyValue = 0;
            DefaultHomeOffTarifValue = 0;
            DefaultHomeOffHoursValue = 0;
            DefaultMSalaryAwardValue = 0;
            DefaultHSalaryAwardValue = 0;
            DefaultFPremiumBaseValue = 0;
            DefaultFPremiumBossValue = 0;
            DefaultFPremiumPersValue = 0;
            DefaultFullSheetHrsValue = 0;
            DefaultTimeSheetHrsValue = 0;
            DefaultHoliSheetHrsValue = 0;
            DefaultWorkSheetHrsValue = 0;
            DefaultWorkSheetDayValue = 0;
            DefaultOverSheetHrsValue = 0;
            DefaultVacaRecomHrsValue = 0;
            DefaultPaidRecomHrsValue = 0;
            DefaultHoliRecomHrsValue = 0;
            DefaultOverAllowHrsValue = 0;
            DefaultOverAllowRioValue = 0;
            DefaultRestAllowHrsValue = 0;
            DefaultRestAllowRioValue = 0;
            DefaultWendAllowHrsValue = 0;
            DefaultWendAllowRioValue = 0;
            DefaultNighAllowHrsValue = 0;
            DefaultNighAllowRioValue = 0;
            DefaultHoliAllowHrsValue = 0;
            DefaultHoliAllowRioValue = 0;
            DefaultQClothesBaseValue = 0;
            DefaultQHOfficeBaseValue = 0;
            DefaultQAgrWorkBaseValue = 0;
            DefaultQSumWorkHourValue = 0;

            AgrWorkTarifFunc = DefaultAgrWorkTarif;
            AgrWorkRatioFunc = DefaultAgrWorkRatio;
            AgrHourLimitFunc = DefaultAgrHourLimit;
            AgrWorkLimitFunc = DefaultAgrWorkLimit;
            ClothesHoursFunc = DefaultClothesHours;
            ClothesDailyFunc = DefaultClothesDaily;
            HomeOffTarifFunc = DefaultHomeOffTarif;
            HomeOffHoursFunc = DefaultHomeOffHours;
            MSalaryAwardFunc = DefaultMSalaryAward;
            HSalaryAwardFunc = DefaultHSalaryAward;
            FPremiumBaseFunc = DefaultFPremiumBase;
            FPremiumBossFunc = DefaultFPremiumBoss;
            FPremiumPersFunc = DefaultFPremiumPers;
            FullSheetHrsFunc = DefaultFullSheetHrs;
            TimeSheetHrsFunc = DefaultTimeSheetHrs;
            HoliSheetHrsFunc = DefaultHoliSheetHrs;
            WorkSheetHrsFunc = DefaultWorkSheetHrs;
            WorkSheetDayFunc = DefaultWorkSheetDay;
            OverSheetHrsFunc = DefaultOverSheetHrs;
            VacaRecomHrsFunc = DefaultVacaRecomHrs;
            PaidRecomHrsFunc = DefaultPaidRecomHrs;
            HoliRecomHrsFunc = DefaultHoliRecomHrs;
            OverAllowHrsFunc = DefaultOverAllowHrs;
            OverAllowRioFunc = DefaultOverAllowRio;
            RestAllowHrsFunc = DefaultRestAllowHrs;
            RestAllowRioFunc = DefaultRestAllowRio;
            WendAllowHrsFunc = DefaultWendAllowHrs;
            WendAllowRioFunc = DefaultWendAllowRio;
            NighAllowHrsFunc = DefaultNighAllowHrs;
            NighAllowRioFunc = DefaultNighAllowRio;
            HoliAllowHrsFunc = DefaultHoliAllowHrs;
            HoliAllowRioFunc = DefaultHoliAllowRio;
            QClothesBaseFunc = DefaultQClothesBase;
            QHOfficeBaseFunc = DefaultQHOfficeBase;
            QAgrWorkBaseFunc = DefaultQAgrWorkBase;
            QSumWorkHourFunc = DefaultQSumWorkHour;
            /*
            "$C",  "CompAgrWorkTariff",   OPTIONAL,  3), // SAZBA DPP
            "$D",  "CompAgrWorkRatio",    OPTIONAL,  4), // Procento DPP
            "$E",  "CompClothDsTariff",   OPTIONAL,  5), // Sazba ošatné
            "$F",  "CompHOfficeTariff",   OPTIONAL,  6), // Sazba HO
            "$G",  "CompHOfficeHours",    OPTIONAL,  7), // Počet hodin HO
            "$I",  "BonusSalaryAmount",   OPTIONAL,  9), // Osobní ohodnocení
            "$H",  "BonusHourlyAmount",   OPTIONAL,  8), // Osobní ohodnocení
            "$J",  "PremiumBaseAmount",   OPTIONAL, 10), // Prémie
            "$K",  "PremiumBossAmount",   OPTIONAL, 11), // Prémie
            "$L",  "PremiumOsobAmount",   OPTIONAL, 12), // Prémie - Osobní ohodnocení
            "$M",  "FullsheetHours",      OPTIONAL, 13), // Zákonný úvazek
            "$N",  "TimesheetHours",      OPTIONAL, 14), // Úvazek
            "$O",  "HolisheetHours",      OPTIONAL, 15), // Hodiny svátků v ES
            "$P",  "WorksheetHours",      OPTIONAL, 16), // Odprac. bez přesčasů
            "$Q",  "WorksheetDays",       OPTIONAL, 17), // Počet odprac směn
            "$R",  "OversheetHours",      OPTIONAL, 18), // Přesčas  (hod)
            "$S",  "RecomVacaHours",      OPTIONAL, 19), // Dovolená (hod)
            "$T",  "RecomHoliHours",      OPTIONAL, 20), // Svátky (hod)
            "$AA", "AllowOverHours",      OPTIONAL, 21), // Příplatky (hod, proc)
            "$AB", "AllowOverRatio",      OPTIONAL, 22), // Příplatky (hod, proc)
            "$AC", "AllowRestHours",      OPTIONAL, 23), // Příplatky (hod, proc)
            "$AD", "AllowRestRatio",      OPTIONAL, 24), // Příplatky (hod, proc)
            "$AE", "AllowWendHours",      OPTIONAL, 25), // Příplatky (hod, proc)
            "$AF", "AllowWendRatio",      OPTIONAL, 26), // Příplatky (hod, proc)
            "$AG", "AllowNighHours",      OPTIONAL, 27), // Příplatky (hod, proc)
            "$AH", "AllowNighRatio",      OPTIONAL, 28), // Příplatky (hod, proc)
            "$AI", "AllowHoliHours",      OPTIONAL, 29), // Příplatky (hod, proc)
            "$AJ", "AllowHoliRatio",      OPTIONAL, 30), // Příplatky (hod, proc)
            */
        }

        private Int32 DefaultAgrWorkTarif(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultAgrWorkTarifValue;
        }
        private Int32 DefaultAgrWorkRatio(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultAgrWorkRatioValue;
        }
        private Int32 DefaultAgrHourLimit(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultAgrHourLimitValue;
        }
        private Int32 DefaultAgrWorkLimit(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultAgrWorkLimitValue;
        }
        private Int32 DefaultClothesHours(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultClothesHoursValue;
        }
        private Int32 DefaultClothesDaily(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultClothesDailyValue;
        }
        private Int32 DefaultHomeOffTarif(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultHomeOffTarifValue;
        }
        private Int32 DefaultHomeOffHours(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultHomeOffHoursValue;
        }
        private Int32 DefaultMSalaryAward(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultMSalaryAwardValue;
        }
        private Int32 DefaultHSalaryAward(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultHSalaryAwardValue;
        }
        private Int32 DefaultFPremiumBase(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultFPremiumBaseValue;
        }
        private Int32 DefaultFPremiumBoss(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultFPremiumBossValue;
        }
        private Int32 DefaultFPremiumPers(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultFPremiumPersValue;
        }
        private Int32 DefaultFullSheetHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultFullSheetHrsValue;
        }
        private Int32 DefaultTimeSheetHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultTimeSheetHrsValue;
        }
        private Int32 DefaultHoliSheetHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultHoliSheetHrsValue;
        }
        private Int32 DefaultWorkSheetHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultWorkSheetHrsValue;
        }
        private Int32 DefaultWorkSheetDay(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultWorkSheetDayValue;
        }
        private Int32 DefaultOverSheetHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultOverSheetHrsValue;
        }
        private Int32 DefaultVacaRecomHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultVacaRecomHrsValue;
        }
        private Int32 DefaultPaidRecomHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultPaidRecomHrsValue;
        }
        private Int32 DefaultHoliRecomHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultHoliRecomHrsValue;
        }
        private Int32 DefaultOverAllowHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultOverAllowHrsValue;
        }
        private Int32 DefaultOverAllowRio(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultOverAllowRioValue;
        }
        private Int32 DefaultRestAllowHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultRestAllowHrsValue;
        }
        private Int32 DefaultRestAllowRio(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultRestAllowRioValue;
        }
        private Int32 DefaultWendAllowHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultWendAllowHrsValue;
        }
        private Int32 DefaultWendAllowRio(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultWendAllowRioValue;
        }
        private Int32 DefaultNighAllowHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultNighAllowHrsValue;
        }
        private Int32 DefaultNighAllowRio(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultNighAllowRioValue;
        }
        private Int32 DefaultHoliAllowHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultHoliAllowHrsValue;
        }
        private Int32 DefaultHoliAllowRio(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultHoliAllowRioValue;
        }
        private Int32 DefaultQClothesBase(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultQClothesBaseValue;
        }
        private Int32 DefaultQHOfficeBase(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultQHOfficeBaseValue;
        }
        private Int32 DefaultQAgrWorkBase(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultQAgrWorkBaseValue;
        }
        private Int32 DefaultQSumWorkHour(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultQSumWorkHourValue;
        }

        public int Id { get; }
        public string Name { get; }
        public string Number { get; }

        public Int32 DefaultAgrWorkTarifValue { get; private set; }
        public Int32 DefaultAgrWorkRatioValue { get; private set; }
        public Int32 DefaultAgrHourLimitValue { get; private set; }
        public Int32 DefaultAgrWorkLimitValue { get; private set; }
        public Int32 DefaultClothesHoursValue { get; private set; }
        public Int32 DefaultClothesDailyValue { get; private set; }
        public Int32 DefaultHomeOffTarifValue { get; private set; }
        public Int32 DefaultHomeOffHoursValue { get; private set; }
        public Int32 DefaultMSalaryAwardValue { get; private set; }
        public Int32 DefaultHSalaryAwardValue { get; private set; }
        public Int32 DefaultFPremiumBaseValue { get; private set; }
        public Int32 DefaultFPremiumBossValue { get; private set; }
        public Int32 DefaultFPremiumPersValue { get; private set; }
        public Int32 DefaultFullSheetHrsValue { get; private set; }
        public Int32 DefaultTimeSheetHrsValue { get; private set; }
        public Int32 DefaultHoliSheetHrsValue { get; private set; }
        public Int32 DefaultWorkSheetHrsValue { get; private set; }
        public Int32 DefaultWorkSheetDayValue { get; private set; }
        public Int32 DefaultOverSheetHrsValue { get; private set; }
        public Int32 DefaultVacaRecomHrsValue { get; private set; }
        public Int32 DefaultPaidRecomHrsValue { get; private set; }
        public Int32 DefaultHoliRecomHrsValue { get; private set; }
        public Int32 DefaultOverAllowHrsValue { get; private set; }
        public Int32 DefaultOverAllowRioValue { get; private set; }
        public Int32 DefaultRestAllowHrsValue { get; private set; }
        public Int32 DefaultRestAllowRioValue { get; private set; }
        public Int32 DefaultWendAllowHrsValue { get; private set; }
        public Int32 DefaultWendAllowRioValue { get; private set; }
        public Int32 DefaultNighAllowHrsValue { get; private set; }
        public Int32 DefaultNighAllowRioValue { get; private set; }
        public Int32 DefaultHoliAllowHrsValue { get; private set; }
        public Int32 DefaultHoliAllowRioValue { get; private set; }
        public Int32 DefaultQClothesBaseValue { get; private set; }
        public Int32 DefaultQHOfficeBaseValue { get; private set; }
        public Int32 DefaultQAgrWorkBaseValue { get; private set; }
        public Int32 DefaultQSumWorkHourValue { get; private set; }

        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> AgrWorkTarifFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> AgrWorkRatioFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> AgrHourLimitFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> AgrWorkLimitFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> ClothesHoursFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> ClothesDailyFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> HomeOffTarifFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> HomeOffHoursFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> MSalaryAwardFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> HSalaryAwardFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> FPremiumBaseFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> FPremiumBossFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> FPremiumPersFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> FullSheetHrsFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> TimeSheetHrsFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> HoliSheetHrsFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> WorkSheetHrsFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> WorkSheetDayFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> OverSheetHrsFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> VacaRecomHrsFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> PaidRecomHrsFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> HoliRecomHrsFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> OverAllowHrsFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> OverAllowRioFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> RestAllowHrsFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> RestAllowRioFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> WendAllowHrsFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> WendAllowRioFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> NighAllowHrsFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> NighAllowRioFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> HoliAllowHrsFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> HoliAllowRioFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> QClothesBaseFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> QHOfficeBaseFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> QAgrWorkBaseFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> QSumWorkHourFunc { get; private set; }
        public static OptimulaGenerator Spec(Int32 id, string name, string number)
        {
            return new OptimulaGenerator(id, name, number);
        }
        public static Int32 ParseNANothing(string valString)
        {
            return 0;
        }
        public static Int32 ParseIntNumber(string valString)
        {
            if (valString.Trim().Equals(""))
            {
                return 0;
            }
            string numberToParse = valString.Replace('.', ',').TrimEnd('%').Replace("Kč", "").TrimEnd(' ');
            decimal numberValue = 0;
            try
            {
                numberValue = decimal.Parse(numberToParse);
            }
            catch (Exception e)
            {
            }
            return decimal.ToInt32(numberValue);
        }
        public static Int32 ParseDecNumber(string valString)
        {
            if (valString.Trim().Equals(""))
            {
                return 0;
            }
            string numberToParse = valString.Replace('.', ',').TrimEnd('%').Replace("Kč", "").TrimEnd(' ');
            decimal numberValue = 0;
            try
            {
                numberValue = decimal.Parse(numberToParse);
            }
            catch (Exception e)
            {
            }
            return decimal.ToInt32(numberValue * 100);
        }
        public static Int32 ParseHrsNumber(string valString)
        {
            if (valString.Trim().Equals(""))
            {
                return 0;
            }
            string numberToParse = valString.Replace('.', ',').TrimEnd('%').Replace("Kč", "").TrimEnd(' ');
            decimal numberValue = 0;
            try
            {
                numberValue = decimal.Parse(numberToParse);
            }
            catch (Exception e)
            {
            }
            return decimal.ToInt32(numberValue * 60);
        }
        public static OptimulaGenerator ParseSpec(Int32 id, string specString)
        {
            string[] specDefValues = specString.Split(';');
            if (specDefValues.Length < 1)
            {
                return new OptimulaGenerator(id, "Unknownn", "Unknownn");
            }
            if (specDefValues.Length < 2)
            {
                return new OptimulaGenerator(id, "Unknownn", specDefValues[0]);
            }
            var gen = new OptimulaGenerator(id, specDefValues[1], specDefValues[0]);

            Func<string, Int32>[] specParser = new Func<string, Int32>[]
            {
                ParseIntNumber,   //   1  EmployeeNumb	101
                ParseNANothing,   //   2  EmployeeName	Drahota Jakub
                ParseNANothing,   //   3  PeriodName  	202201
                ParseDecNumber,   //   3  AgrWorkTarif	105,00
                ParseDecNumber,   //   4  AgrWorkRatio	0,14
                ParseHrsNumber,   //   5  AgrHourLimit	0,00
                ParseDecNumber,   //   6  AgrWorkLimit	0,00
                ParseDecNumber,   //   7  ClothesHours	11,17
                ParseDecNumber,   //   8  ClothesDaily	57,00
                ParseDecNumber,   //   9  HomeOffTarif	0,00
                ParseHrsNumber,   //  10  HomeOffHours	0,00
                ParseDecNumber,   //  11  MSalaryAward	8 000,00
                ParseHrsNumber,   //  12  HSalaryAward	0,00
                ParseDecNumber,   //  13  FPremiumBase	0,00
                ParseDecNumber,   //  14  FPremiumBoss	0,00
                ParseDecNumber,   //  15  FPremiumPers	0,00
                ParseHrsNumber,   //  16  FullSheetHrs	176,00
                ParseHrsNumber,   //  17  TimeSheetHrs	176,00
                ParseHrsNumber,   //  18  HoliSheetHrs	0,00
                ParseHrsNumber,   //  19  WorkSheetHrs	96,00
                ParseDecNumber,   //  20  WorkSheetDay	12,00
                ParseHrsNumber,   //  21  OverSheetHrs	40,00
                ParseHrsNumber,   //  22  VacaRecomHrs	80,00
                ParseHrsNumber,   //  23  PaidRecomHrs	0,00
                ParseHrsNumber,   //  24  HoliRecomHrs	0,00
                ParseNANothing,   //25  -----------
                ParseNANothing,   //26  -----------
                ParseHrsNumber,   //   27  OverAllowHrs	40,00
                ParseDecNumber,   //   28  OverAllowRio	0,25
                ParseHrsNumber,   //   29  RestAllowHrs	0,00
                ParseDecNumber,   //   30  RestAllowRio	0,00
                ParseHrsNumber,   //   31  WendAllowHrs	0,00
                ParseDecNumber,   //   32  WendAllowRio	0,00
                ParseHrsNumber,   //   33  NighAllowHrs	18,25
                ParseDecNumber,   //   34  NighAllowRio	0,10
                ParseHrsNumber,   //   35  HoliAllowHrs	0,00
                ParseDecNumber,   //   36  HoliAllowRio	0,00
                ParseDecNumber,   //   37  QClothesBase	3 506,00
                ParseDecNumber,   //   38  QHOfficeBase	0,00
                ParseDecNumber,   //   39  QAgrWorkBase	8 852,00
                ParseDecNumber,   //   40  QSumWorkHour	912,08
            };
            Int32[] specIntValues = specDefValues.Zip(specParser).Select((x) => x.Second(x.First)).ToArray();


#if __ALL_VALUES__
            Func<Int32, OptimulaGenerator>[] specGenerator = new Func<Int32, OptimulaGenerator>[]
            {
                gen.WithNANothingVal,   //   1  EmployeeNumb	101
                gen.WithNANothingVal,   //   2  EmployeeName	Drahota Jakub
                gen.WithNANothingVal,   //   3  PeriodName  	202201
                gen.WithAgrWorkTarifVal,   //   3  AgrWorkTarif	105,00
                gen.WithAgrWorkRatioVal,   //   4  AgrWorkRatio	0,14
                gen.WithAgrHourLimitVal,   //   5  AgrHourLimit	0,00
                gen.WithAgrWorkLimitVal,   //   6  AgrWorkLimit	0,00
                gen.WithClothesDailyVal,   //   7  ClothesHours	11,17
                gen.WithClothesDailyVal,   //   8  ClothesDaily	106,00
                gen.WithHomeOffTarifVal,   //   9  HomeOffTarif	0,00
                gen.WithHomeOffHoursVal,   //  10  HomeOffHours	0,00
                gen.WithMSalaryAwardVal,   //  11  MSalaryAward	8 000,00
                gen.WithHSalaryAwardVal,   //  12  HSalaryAward	0,00
                gen.WithFPremiumBaseVal,   //  13  FPremiumBase	0,00
                gen.WithFPremiumBossVal,   //  14  FPremiumBoss	0,00
                gen.WithFPremiumPersVal,   //  15  FPremiumPers	0,00
                gen.WithFullSheetHrsVal,   //  16  FullSheetHrs	176,00
                gen.WithTimeSheetHrsVal,   //  17  TimeSheetHrs	176,00
                gen.WithHoliSheetHrsVal,   //  18  HoliSheetHrs	0,00
                gen.WithWorkSheetHrsVal,   //  19  WorkSheetHrs	96,00
                gen.WithWorkSheetDayVal,   //  20  WorkSheetDay	12,00
                gen.WithOverSheetHrsVal,   //  21  OverSheetHrs	40,00
                gen.WithVacaRecomHrsVal,   //  22  VacaRecomHrs	80,00
                gen.WithPaidRecomHrsVal,   //  23  PaidRecomHrs	0,00
                gen.WithHoliRecomHrsVal,   //  24  HoliRecomHrs	0,00
                gen.WithNANothingVal,   //25  -----------
                gen.WithNANothingVal,   //26  -----------
                gen.WithOverAllowHrsVal,   //   27  OverAllowHrs	40,00
                gen.WithOverAllowRioVal,   //   28  OverAllowRio	0,25
                gen.WithRestAllowHrsVal,   //   29  RestAllowHrs	0,00
                gen.WithRestAllowRioVal,   //   30  RestAllowRio	0,00
                gen.WithWendAllowHrsVal,   //   31  WendAllowHrs	0,00
                gen.WithWendAllowRioVal,   //   32  WendAllowRio	0,00
                gen.WithNighAllowHrsVal,   //   33  NighAllowHrs	18,25
                gen.WithNighAllowRioVal,   //   34  NighAllowRio	0,10
                gen.WithHoliAllowHrsVal,   //   35  HoliAllowHrs	0,00
                gen.WithHoliAllowRioVal,   //   36  HoliAllowRio	0,00
                gen.WithQClothesBaseVal,   //   37  QClothesBase	3 506,00
                gen.WithQHOfficeBaseVal,   //   38  QHOfficeBase	0,00
                gen.WithQAgrWorkBaseVal,   //   39  QAgrWorkBase	8 852,00
                gen.WithQSumWorkHourVal,   //   40  QSumWorkHour	912,08
            };
#else
            Func<Int32, OptimulaGenerator>[] specGenerator = new Func<Int32, OptimulaGenerator>[]
            {
                gen.WithNANothingVal,   //   1  EmployeeNumb	101
                gen.WithNANothingVal,   //   2  EmployeeName	Drahota Jakub
                gen.WithNANothingVal,   //   3  PeriodName  	202201
                gen.WithAgrWorkTarifVal,   //   3  AgrWorkTarif	105,00
                gen.WithAgrWorkRatioVal,   //   4  AgrWorkRatio	0,14
                gen.WithAgrHourLimitVal,   //   5  AgrHourLimit	0,00
                gen.WithAgrWorkLimitVal,   //   6  AgrWorkLimit	0,00
                gen.WithClothesDailyVal,   //   7  ClothesHours	11,17
                gen.WithClothesDailyVal,   //   8  ClothesDaily	106,00
                gen.WithHomeOffTarifVal,   //   9  HomeOffTarif	0,00
                gen.WithHomeOffHoursVal,   //  10 HomeOffHours	0,00
                gen.WithMSalaryAwardVal,   //  11  MSalaryAward	8 000,00
                gen.WithHSalaryAwardVal,   //  12  HSalaryAward	0,00
                gen.WithFPremiumBaseVal,   //  13  FPremiumBase	0,00
                gen.WithFPremiumBossVal,   //  14  FPremiumBoss	0,00
                gen.WithFPremiumPersVal,   //  15  FPremiumPers	0,00
                gen.WithFullSheetHrsVal,   //  16  FullSheetHrs	176,00
                gen.WithTimeSheetHrsVal,   //  17  TimeSheetHrs	176,00
                gen.WithHoliSheetHrsVal,   //  18  HoliSheetHrs	0,00
                gen.WithWorkSheetHrsVal,   //  19  WorkSheetHrs	96,00
                gen.WithWorkSheetDayVal,   //  20  WorkSheetDay	12,00
                gen.WithOverSheetHrsVal,   //  21  OverSheetHrs	40,00
                gen.WithVacaRecomHrsVal,   //  22  VacaRecomHrs	80,00
                gen.WithPaidRecomHrsVal,   //  23  PaidRecomHrs	0,00
                gen.WithHoliRecomHrsVal,   //  24  HoliRecomHrs	0,00
                gen.WithNANothingVal,   //25  -----------
                gen.WithNANothingVal,   //26  -----------
                gen.WithNANothingVal,   //   27  OverAllowHrs	40,00
                gen.WithNANothingVal,   //   28  OverAllowRio	0,25
                gen.WithNANothingVal,   //   29  RestAllowHrs	0,00
                gen.WithNANothingVal,   //   30  RestAllowRio	0,00
                gen.WithNANothingVal,   //   31  WendAllowHrs	0,00
                gen.WithNANothingVal,   //   32  WendAllowRio	0,00
                gen.WithNANothingVal,   //   33  NighAllowHrs	18,25
                gen.WithNANothingVal,   //   34  NighAllowRio	0,10
                gen.WithNANothingVal,   //   35  HoliAllowHrs	0,00
                gen.WithNANothingVal,   //   36  HoliAllowRio	0,00
                gen.WithNANothingVal,   //   37  QClothesBase	3 506,00
                gen.WithNANothingVal,   //   38  QHOfficeBase	0,00
                gen.WithNANothingVal,   //   39  QAgrWorkBase	8 852,00
                gen.WithNANothingVal,   //   40  QSumWorkHour	912,08
            };
#endif
            specIntValues.Zip(specGenerator).Select((x) => x.Second(x.First)).ToArray();

            return gen;
        }
        protected static Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> WithValue(Int32 val)
        {
            return (OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset) => (val);
        }
        public OptimulaGenerator WithNANothingVal(Int32 val)
        {
            return this;
        }
        public OptimulaGenerator WithAgrWorkTarifVal(Int32 val)
        {
            DefaultAgrWorkTarifValue = val;
            return this;
        }
        public OptimulaGenerator WithAgrWorkRatioVal(Int32 val)
        {
            DefaultAgrWorkRatioValue = val;
            return this;
        }
        public OptimulaGenerator WithAgrHourLimitVal(Int32 val)
        {
            DefaultAgrHourLimitValue = val;
            return this;
        }
        public OptimulaGenerator WithAgrWorkLimitVal(Int32 val)
        {
            DefaultAgrWorkLimitValue = val;
            return this;
        }
        public OptimulaGenerator WithClothesTarifVal(Int32 val)
        {
            DefaultClothesHoursValue = val;
            return this;
        }
        public OptimulaGenerator WithClothesDailyVal(Int32 val)
        {
            DefaultClothesDailyValue = val;
            return this;
        }
        public OptimulaGenerator WithHomeOffTarifVal(Int32 val)
        {
            DefaultHomeOffTarifValue = val;
            return this;
        }
        public OptimulaGenerator WithHomeOffHoursVal(Int32 val)
        {
            DefaultHomeOffHoursValue = val;
            return this;
        }
        public OptimulaGenerator WithMSalaryAwardVal(Int32 val)
        {
            DefaultMSalaryAwardValue = val;
            return this;
        }
        public OptimulaGenerator WithHSalaryAwardVal(Int32 val)
        {
            DefaultHSalaryAwardValue = val;
            return this;
        }
        public OptimulaGenerator WithFPremiumBaseVal(Int32 val)
        {
            DefaultFPremiumBaseValue = val;
            return this;
        }
        public OptimulaGenerator WithFPremiumBossVal(Int32 val)
        {
            DefaultFPremiumBossValue = val;
            return this;
        }
        public OptimulaGenerator WithFPremiumPersVal(Int32 val)
        {
            DefaultFPremiumPersValue = val;
            return this;
        }
        public OptimulaGenerator WithFullSheetHrsVal(Int32 val)
        {
            DefaultFullSheetHrsValue = val;
            return this;
        }
        public OptimulaGenerator WithTimeSheetHrsVal(Int32 val)
        {
            DefaultTimeSheetHrsValue = val;
            return this;
        }
        public OptimulaGenerator WithHoliSheetHrsVal(Int32 val)
        {
            DefaultHoliSheetHrsValue = val;
            return this;
        }
        public OptimulaGenerator WithWorkSheetHrsVal(Int32 val)
        {
            DefaultWorkSheetHrsValue = val;
            return this;
        }
        public OptimulaGenerator WithWorkSheetDayVal(Int32 val)
        {
            DefaultWorkSheetDayValue = val;
            return this;
        }
        public OptimulaGenerator WithOverSheetHrsVal(Int32 val)
        {
            DefaultOverSheetHrsValue = val;
            return this;
        }
        public OptimulaGenerator WithVacaRecomHrsVal(Int32 val)
        {
            DefaultVacaRecomHrsValue = val;
            return this;
        }
        public OptimulaGenerator WithPaidRecomHrsVal(Int32 val)
        {
            DefaultPaidRecomHrsValue = val;
            return this;
        }
        public OptimulaGenerator WithHoliRecomHrsVal(Int32 val)
        {
            DefaultHoliRecomHrsValue = val;
            return this;
        }
        public OptimulaGenerator WithOverAllowHrsVal(Int32 val)
        {
            DefaultOverAllowHrsValue = val;
            return this;
        }
        public OptimulaGenerator WithOverAllowRioVal(Int32 val)
        {
            DefaultOverAllowRioValue = val;
            return this;
        }
        public OptimulaGenerator WithRestAllowHrsVal(Int32 val)
        {
            DefaultRestAllowHrsValue = val;
            return this;
        }
        public OptimulaGenerator WithRestAllowRioVal(Int32 val)
        {
            DefaultRestAllowRioValue = val;
            return this;
        }
        public OptimulaGenerator WithWendAllowHrsVal(Int32 val)
        {
            DefaultWendAllowHrsValue = val;
            return this;
        }
        public OptimulaGenerator WithWendAllowRioVal(Int32 val)
        {
            DefaultWendAllowRioValue = val;
            return this;
        }
        public OptimulaGenerator WithNighAllowHrsVal(Int32 val)
        {
            DefaultNighAllowHrsValue = val;
            return this;
        }
        public OptimulaGenerator WithNighAllowRioVal(Int32 val)
        {
            DefaultNighAllowRioValue = val;
            return this;
        }
        public OptimulaGenerator WithHoliAllowHrsVal(Int32 val)
        {
            DefaultHoliAllowHrsValue = val;
            return this;
        }
        public OptimulaGenerator WithHoliAllowRioVal(Int32 val)
        {
            DefaultHoliAllowRioValue = val;
            return this;
        }
        public OptimulaGenerator WithQClothesBaseVal(Int32 val)
        {
            DefaultQClothesBaseValue = val;
            return this;
        }
        public OptimulaGenerator WithQHOfficeBaseVal(Int32 val)
        {
            DefaultQHOfficeBaseValue = val;
            return this;
        }
        public OptimulaGenerator WithQAgrWorkBaseVal(Int32 val)
        {
            DefaultQAgrWorkBaseValue = val;
            return this;
        }
        public OptimulaGenerator WithQSumWorkHourVal(Int32 val)
        {
            DefaultQSumWorkHourValue = val;
            return this;
        }

        public OptimulaGenerator WithNANothing(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            return this;
        }
        public OptimulaGenerator WithAgrWorkTarif(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            AgrWorkTarifFunc = func;
            return this;
        }
        public OptimulaGenerator WithAgrWorkRatio(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            AgrWorkRatioFunc = func;
            return this;
        }
        public OptimulaGenerator WithAgrHourLimit(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            AgrHourLimitFunc = func;
            return this;
        }
        public OptimulaGenerator WithAgrWorkLimit(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            AgrWorkLimitFunc = func;
            return this;
        }
        public OptimulaGenerator WithClothesTarif(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            ClothesHoursFunc = func;
            return this;
        }
        public OptimulaGenerator WithClothesDaily(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            ClothesDailyFunc = func;
            return this;
        }
        public OptimulaGenerator WithHomeOffTarif(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            HomeOffTarifFunc = func;
            return this;
        }
        public OptimulaGenerator WithHomeOffHours(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            HomeOffHoursFunc = func;
            return this;
        }
        public OptimulaGenerator WithMSalaryAward(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            MSalaryAwardFunc = func;
            return this;
        }
        public OptimulaGenerator WithHSalaryAward(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            HSalaryAwardFunc = func;
            return this;
        }
        public OptimulaGenerator WithFPremiumBase(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            FPremiumBaseFunc = func;
            return this;
        }
        public OptimulaGenerator WithFPremiumBoss(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            FPremiumBossFunc = func;
            return this;
        }
        public OptimulaGenerator WithFPremiumPers(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            FPremiumPersFunc = func;
            return this;
        }
        public OptimulaGenerator WithFullSheetHrs(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            FullSheetHrsFunc = func;
            return this;
        }
        public OptimulaGenerator WithTimeSheetHrs(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            TimeSheetHrsFunc = func;
            return this;
        }
        public OptimulaGenerator WithHoliSheetHrs(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            HoliSheetHrsFunc = func;
            return this;
        }
        public OptimulaGenerator WithWorkSheetHrs(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            WorkSheetHrsFunc = func;
            return this;
        }
        public OptimulaGenerator WithWorkSheetDay(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            WorkSheetDayFunc = func;
            return this;
        }
        public OptimulaGenerator WithOverSheetHrs(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            OverSheetHrsFunc = func;
            return this;
        }
        public OptimulaGenerator WithVacaRecomHrs(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            VacaRecomHrsFunc = func;
            return this;
        }
        public OptimulaGenerator WithPaidRecomHrs(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            PaidRecomHrsFunc = func;
            return this;
        }
        public OptimulaGenerator WithHoliRecomHrs(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            HoliRecomHrsFunc = func;
            return this;
        }
        public OptimulaGenerator WithOverAllowHrs(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            OverAllowHrsFunc = func;
            return this;
        }
        public OptimulaGenerator WithOverAllowRio(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            OverAllowRioFunc = func;
            return this;
        }
        public OptimulaGenerator WithRestAllowHrs(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            RestAllowHrsFunc = func;
            return this;
        }
        public OptimulaGenerator WithRestAllowRio(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            RestAllowRioFunc = func;
            return this;
        }
        public OptimulaGenerator WithWendAllowHrs(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            WendAllowHrsFunc = func;
            return this;
        }
        public OptimulaGenerator WithWendAllowRio(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            WendAllowRioFunc = func;
            return this;
        }
        public OptimulaGenerator WithNighAllowHrs(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            NighAllowHrsFunc = func;
            return this;
        }
        public OptimulaGenerator WithNighAllowRio(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            NighAllowRioFunc = func;
            return this;
        }
        public OptimulaGenerator WithHoliAllowHrs(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            HoliAllowHrsFunc = func;
            return this;
        }
        public OptimulaGenerator WithHoliAllowRio(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            HoliAllowRioFunc = func;
            return this;
        }
        public OptimulaGenerator WithQClothesBase(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            QClothesBaseFunc = func;
            return this;
        }
        public OptimulaGenerator WithQHOfficeBase(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            QHOfficeBaseFunc = func;
            return this;
        }
        public OptimulaGenerator WithQAgrWorkBase(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            QAgrWorkBaseFunc = func;
            return this;
        }
        public OptimulaGenerator WithQSumWorkHour(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            QSumWorkHourFunc = func;
            return this;
        }
        public string[] BuildImportXlsString(IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            Int32 AgrWorkTarifVal = AgrWorkTarifFunc(this, period, ruleset, prevset);
            Int32 AgrWorkRatioVal = AgrWorkRatioFunc(this, period, ruleset, prevset);
            Int32 AgrHourLimitVal = AgrHourLimitFunc(this, period, ruleset, prevset);
            Int32 AgrWorkLimitVal = AgrWorkLimitFunc(this, period, ruleset, prevset);
            Int32 ClothesHoursVal = ClothesHoursFunc(this, period, ruleset, prevset);
            Int32 ClothesDailyVal = ClothesDailyFunc(this, period, ruleset, prevset);
            Int32 HomeOffTarifVal = HomeOffTarifFunc(this, period, ruleset, prevset);
            Int32 HomeOffHoursVal = HomeOffHoursFunc(this, period, ruleset, prevset);

            Int32 MSalaryAwardVal = MSalaryAwardFunc(this, period, ruleset, prevset);
            Int32 HSalaryAwardVal = HSalaryAwardFunc(this, period, ruleset, prevset);
            Int32 FPremiumBaseVal = FPremiumBaseFunc(this, period, ruleset, prevset);
            Int32 FPremiumBossVal = FPremiumBossFunc(this, period, ruleset, prevset);
            Int32 FPremiumPersVal = FPremiumPersFunc(this, period, ruleset, prevset);
            Int32 FullSheetHrsVal = FullSheetHrsFunc(this, period, ruleset, prevset);
            Int32 TimeSheetHrsVal = TimeSheetHrsFunc(this, period, ruleset, prevset);
            Int32 HoliSheetHrsVal = HoliSheetHrsFunc(this, period, ruleset, prevset);
            Int32 WorkSheetHrsVal = WorkSheetHrsFunc(this, period, ruleset, prevset);
            Int32 WorkSheetDayVal = WorkSheetDayFunc(this, period, ruleset, prevset);
            Int32 OverSheetHrsVal = OverSheetHrsFunc(this, period, ruleset, prevset);
            Int32 VacaRecomHrsVal = VacaRecomHrsFunc(this, period, ruleset, prevset);
            Int32 PaidRecomHrsVal = PaidRecomHrsFunc(this, period, ruleset, prevset);
            Int32 HoliRecomHrsVal = HoliRecomHrsFunc(this, period, ruleset, prevset);
            Int32 OverAllowHrsVal = OverAllowHrsFunc(this, period, ruleset, prevset);
            Int32 OverAllowRioVal = OverAllowRioFunc(this, period, ruleset, prevset);
            Int32 RestAllowHrsVal = RestAllowHrsFunc(this, period, ruleset, prevset);
            Int32 RestAllowRioVal = RestAllowRioFunc(this, period, ruleset, prevset);
            Int32 WendAllowHrsVal = WendAllowHrsFunc(this, period, ruleset, prevset);
            Int32 WendAllowRioVal = WendAllowRioFunc(this, period, ruleset, prevset);
            Int32 NighAllowHrsVal = NighAllowHrsFunc(this, period, ruleset, prevset);
            Int32 NighAllowRioVal = NighAllowRioFunc(this, period, ruleset, prevset);
            Int32 HoliAllowHrsVal = HoliAllowHrsFunc(this, period, ruleset, prevset);
            Int32 HoliAllowRioVal = HoliAllowRioFunc(this, period, ruleset, prevset);
            Int32 QClothesBaseVal = QClothesBaseFunc(this, period, ruleset, prevset);
            Int32 QHOfficeBaseVal = QHOfficeBaseFunc(this, period, ruleset, prevset);
            Int32 QAgrWorkBaseVal = QAgrWorkBaseFunc(this, period, ruleset, prevset);
            Int32 QSumWorkHourVal = QSumWorkHourFunc(this, period, ruleset, prevset);

            string[] valuesList = new string[]
            {
                Number, // A
                Name,   // B
                period.Code.ToString(),                 // C
                $"{CcyFormatIntX100(AgrWorkTarifVal)}", // D
                $"{NumFormatIntX100(AgrWorkRatioVal)}", // E
                $"{HrsFormatIntX060(AgrHourLimitVal)}", // F
                $"{NumFormatIntX100(AgrWorkLimitVal)}", // G
                $"{CcyFormatIntX100(ClothesHoursVal)}", // H
                $"{CcyFormatIntX100(ClothesDailyVal)}", // I
                $"{CcyFormatIntX100(HomeOffTarifVal)}", // J
                $"{HrsFormatIntX060(HomeOffHoursVal)}", // K
                $"{CcyFormatIntX100(MSalaryAwardVal)}", // L
                $"{CcyFormatIntX100(HSalaryAwardVal)}", // M
                $"{CcyFormatIntX100(FPremiumBaseVal)}", // N
                $"{CcyFormatIntX100(FPremiumBossVal)}", // O  
                $"{CcyFormatIntX100(FPremiumPersVal)}", // P  
                $"{HrsFormatIntX060(FullSheetHrsVal)}", // Q  
                $"{HrsFormatIntX060(TimeSheetHrsVal)}", // R  
                $"{HrsFormatIntX060(HoliSheetHrsVal)}", // S   
                $"{HrsFormatIntX060(WorkSheetHrsVal)}", // T
                $"{DayFormatIntX100(WorkSheetDayVal)}", // U
                $"{HrsFormatIntX060(OverSheetHrsVal)}", // V
                $"{HrsFormatIntX060(VacaRecomHrsVal)}", // W  
                $"{HrsFormatIntX060(PaidRecomHrsVal)}", // X   
                $"{HrsFormatIntX060(HoliRecomHrsVal)}", // Y     
                "", // Z     
                $"{HrsFormatIntX060(OverAllowHrsVal)}", // AA
                $"{CcyFormatIntX100(OverAllowRioVal)}", // AB
                $"{HrsFormatIntX060(RestAllowHrsVal)}", // AC
                $"{CcyFormatIntX100(RestAllowRioVal)}", // AD
                $"{HrsFormatIntX060(WendAllowHrsVal)}", // AE
                $"{CcyFormatIntX100(WendAllowRioVal)}", // AF
                $"{HrsFormatIntX060(NighAllowHrsVal)}", // AG
                $"{CcyFormatIntX100(NighAllowRioVal)}", // AH
                $"{HrsFormatIntX060(HoliAllowHrsVal)}", // AI
                $"{CcyFormatIntX100(HoliAllowRioVal)}", // AJ
                $"{CcyFormatIntX100(QClothesBaseVal)}", // AK
                $"{CcyFormatIntX100(QHOfficeBaseVal)}", // AL
                $"{CcyFormatIntX100(QAgrWorkBaseVal)}", // AM
                $"{CcyFormatIntX100(QSumWorkHourVal)}", // AN
        };                                             
            string[] importResult = new string[] { string.Join('\t', valuesList) };

            return importResult;
        }
        public string[] BuildImportCsvString(IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            Int32 AgrWorkTarifVal = AgrWorkTarifFunc(this, period, ruleset, prevset);
            Int32 AgrWorkRatioVal = AgrWorkRatioFunc(this, period, ruleset, prevset);
            Int32 AgrHourLimitVal = AgrHourLimitFunc(this, period, ruleset, prevset);
            Int32 AgrWorkLimitVal = AgrWorkLimitFunc(this, period, ruleset, prevset);
            Int32 ClothesHoursVal = ClothesHoursFunc(this, period, ruleset, prevset);
            Int32 ClothesDailyVal = ClothesDailyFunc(this, period, ruleset, prevset);
            Int32 HomeOffTarifVal = HomeOffTarifFunc(this, period, ruleset, prevset);
            Int32 HomeOffHoursVal = HomeOffHoursFunc(this, period, ruleset, prevset);

            Int32 MSalaryAwardVal = MSalaryAwardFunc(this, period, ruleset, prevset);
            Int32 HSalaryAwardVal = HSalaryAwardFunc(this, period, ruleset, prevset);
            Int32 FPremiumBaseVal = FPremiumBaseFunc(this, period, ruleset, prevset);
            Int32 FPremiumBossVal = FPremiumBossFunc(this, period, ruleset, prevset);
            Int32 FPremiumPersVal = FPremiumPersFunc(this, period, ruleset, prevset);
            Int32 FullSheetHrsVal = FullSheetHrsFunc(this, period, ruleset, prevset);
            Int32 TimeSheetHrsVal = TimeSheetHrsFunc(this, period, ruleset, prevset);
            Int32 HoliSheetHrsVal = HoliSheetHrsFunc(this, period, ruleset, prevset);
            Int32 WorkSheetHrsVal = WorkSheetHrsFunc(this, period, ruleset, prevset);
            Int32 WorkSheetDayVal = WorkSheetDayFunc(this, period, ruleset, prevset);
            Int32 OverSheetHrsVal = OverSheetHrsFunc(this, period, ruleset, prevset);
            Int32 VacaRecomHrsVal = VacaRecomHrsFunc(this, period, ruleset, prevset);
            Int32 PaidRecomHrsVal = PaidRecomHrsFunc(this, period, ruleset, prevset);
            Int32 HoliRecomHrsVal = HoliRecomHrsFunc(this, period, ruleset, prevset);
            Int32 OverAllowHrsVal = OverAllowHrsFunc(this, period, ruleset, prevset);
            Int32 OverAllowRioVal = OverAllowRioFunc(this, period, ruleset, prevset);
            Int32 RestAllowHrsVal = RestAllowHrsFunc(this, period, ruleset, prevset);
            Int32 RestAllowRioVal = RestAllowRioFunc(this, period, ruleset, prevset);
            Int32 WendAllowHrsVal = WendAllowHrsFunc(this, period, ruleset, prevset);
            Int32 WendAllowRioVal = WendAllowRioFunc(this, period, ruleset, prevset);
            Int32 NighAllowHrsVal = NighAllowHrsFunc(this, period, ruleset, prevset);
            Int32 NighAllowRioVal = NighAllowRioFunc(this, period, ruleset, prevset);
            Int32 HoliAllowHrsVal = HoliAllowHrsFunc(this, period, ruleset, prevset);
            Int32 HoliAllowRioVal = HoliAllowRioFunc(this, period, ruleset, prevset);
            Int32 QClothesBaseVal = QClothesBaseFunc(this, period, ruleset, prevset);
            Int32 QHOfficeBaseVal = QHOfficeBaseFunc(this, period, ruleset, prevset);
            Int32 QAgrWorkBaseVal = QAgrWorkBaseFunc(this, period, ruleset, prevset);
            Int32 QSumWorkHourVal = QSumWorkHourFunc(this, period, ruleset, prevset);

            string[] valuesList = new string[]
            {
                Number, // A
                Name,   // B
                period.Code.ToString(),                 // C
                $"{CcyFormatIntX100(AgrWorkTarifVal)}", // D
                $"{NumFormatIntX100(AgrWorkRatioVal)}", // E
                $"{HrsFormatIntX060(AgrHourLimitVal)}", // F
                $"{NumFormatIntX100(AgrWorkLimitVal)}", // G
                $"{CcyFormatIntX100(ClothesHoursVal)}", // H
                $"{CcyFormatIntX100(ClothesDailyVal)}", // I
                $"{CcyFormatIntX100(HomeOffTarifVal)}", // J
                $"{HrsFormatIntX060(HomeOffHoursVal)}", // K
                $"{CcyFormatIntX100(MSalaryAwardVal)}", // L
                $"{CcyFormatIntX100(HSalaryAwardVal)}", // M
                $"{CcyFormatIntX100(FPremiumBaseVal)}", // N
                $"{CcyFormatIntX100(FPremiumBossVal)}", // O 
                $"{CcyFormatIntX100(FPremiumPersVal)}", // P 
                $"{HrsFormatIntX060(FullSheetHrsVal)}", // Q 
                $"{HrsFormatIntX060(TimeSheetHrsVal)}", // R 
                $"{HrsFormatIntX060(HoliSheetHrsVal)}", // S 
                $"{HrsFormatIntX060(WorkSheetHrsVal)}", // T 
                $"{DayFormatIntX100(WorkSheetDayVal)}", // U
                $"{HrsFormatIntX060(OverSheetHrsVal)}", // V
                $"{HrsFormatIntX060(VacaRecomHrsVal)}", // W 
                $"{HrsFormatIntX060(PaidRecomHrsVal)}", // X    
                $"{HrsFormatIntX060(HoliRecomHrsVal)}", // Y     
                "", // Z     
                $"{HrsFormatIntX060(OverAllowHrsVal)}", // AA
                $"{CcyFormatIntX100(OverAllowRioVal)}", // AB
                $"{HrsFormatIntX060(RestAllowHrsVal)}", // AC
                $"{CcyFormatIntX100(RestAllowRioVal)}", // AD
                $"{HrsFormatIntX060(WendAllowHrsVal)}", // AE
                $"{CcyFormatIntX100(WendAllowRioVal)}", // AF
                $"{HrsFormatIntX060(NighAllowHrsVal)}", // AG
                $"{CcyFormatIntX100(NighAllowRioVal)}", // AH
                $"{HrsFormatIntX060(HoliAllowHrsVal)}", // AI
                $"{CcyFormatIntX100(HoliAllowRioVal)}", // AJ
                $"{CcyFormatIntX100(QClothesBaseVal)}", // AK
                $"{CcyFormatIntX100(QHOfficeBaseVal)}", // AL
                $"{CcyFormatIntX100(QAgrWorkBaseVal)}", // AM
                $"{CcyFormatIntX100(QSumWorkHourVal)}", // AN
            };                                             
            string[] importResult = new string[] { string.Join(';', valuesList) + ";" };

            return importResult;
        }
        public IEnumerable<ITermTarget> BuildSpecTargets(IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            var montCode = MonthCode.Get(period.Code);

            Int16 CONTRACT_NULL = 0;
            Int16 POSITION_NULL = 0;

            var contractEmp = ContractCode.Get(CONTRACT_NULL);
            var positionEmp = PositionCode.Get(POSITION_NULL);
            var variant1Emp = VariantCode.Get(1);

            Int32 AgrWorkTarifVal = AgrWorkTarifFunc(this, period, ruleset, prevset);
            Int32 AgrWorkRatioVal = AgrWorkRatioFunc(this, period, ruleset, prevset);
            Int32 AgrHourLimitVal = AgrHourLimitFunc(this, period, ruleset, prevset);
            Int32 AgrWorkLimitVal = AgrWorkLimitFunc(this, period, ruleset, prevset);
            Int32 ClothesHoursVal = ClothesHoursFunc(this, period, ruleset, prevset);
            Int32 ClothesDailyVal = ClothesDailyFunc(this, period, ruleset, prevset);
            Int32 HomeOffTarifVal = HomeOffTarifFunc(this, period, ruleset, prevset);
            Int32 HomeOffHoursVal = HomeOffHoursFunc(this, period, ruleset, prevset);

            Int32 MSalaryBasisVal = 0;
            Int32 MAwardsBasisVal = MSalaryAwardFunc(this, period, ruleset, prevset);
            Int32 HSalaryAwardVal = HSalaryAwardFunc(this, period, ruleset, prevset);
            Int32 FPremiumBaseVal = FPremiumBaseFunc(this, period, ruleset, prevset);
            Int32 FPremiumBossVal = FPremiumBossFunc(this, period, ruleset, prevset);
            Int32 FPremiumPersVal = FPremiumPersFunc(this, period, ruleset, prevset);
            Int32 FullSheetHrsVal = FullSheetHrsFunc(this, period, ruleset, prevset);
            Int32 TimeSheetHrsVal = TimeSheetHrsFunc(this, period, ruleset, prevset);
            Int32 HoliSheetHrsVal = HoliSheetHrsFunc(this, period, ruleset, prevset);
            Int32 WorkSheetHrsVal = WorkSheetHrsFunc(this, period, ruleset, prevset);
            Int32 WorkSheetDayVal = WorkSheetDayFunc(this, period, ruleset, prevset);
            Int32 OverSheetHrsVal = OverSheetHrsFunc(this, period, ruleset, prevset);
            Int32 VacaRecomHrsVal = VacaRecomHrsFunc(this, period, ruleset, prevset);
            Int32 HoliRecomHrsVal = HoliRecomHrsFunc(this, period, ruleset, prevset);
            Int32 OverAllowHrsVal = OverAllowHrsFunc(this, period, ruleset, prevset);
            Int32 OverAllowRioVal = OverAllowRioFunc(this, period, ruleset, prevset);
            Int32 RestAllowHrsVal = RestAllowHrsFunc(this, period, ruleset, prevset);
            Int32 RestAllowRioVal = RestAllowRioFunc(this, period, ruleset, prevset);
            Int32 WendAllowHrsVal = WendAllowHrsFunc(this, period, ruleset, prevset);
            Int32 WendAllowRioVal = WendAllowRioFunc(this, period, ruleset, prevset);
            Int32 NighAllowHrsVal = NighAllowHrsFunc(this, period, ruleset, prevset);
            Int32 NighAllowRioVal = NighAllowRioFunc(this, period, ruleset, prevset);
            Int32 HoliAllowHrsVal = HoliAllowHrsFunc(this, period, ruleset, prevset);
            Int32 HoliAllowRioVal = HoliAllowRioFunc(this, period, ruleset, prevset);

            // ContractTimePlan	CONTRACT_TIME_PLAN
            var contractTimePlan = new TimesheetsPlanTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_PLAN),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_TIMESHEETS_PLAN), FullSheetHrsVal);
            // ContractTimeWork	CONTRACT_TIME_WORK
            var contractTimeWork = new TimesheetsWorkTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_WORK),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_TIMESHEETS_WORK), TimeSheetHrsVal, HoliSheetHrsVal);
            // TimeactualWork	TIMEACTUAL_WORK
            var contractTimeActa = new TimeactualWorkTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_TIMEACTUAL_WORK), 
                WorkSheetHrsVal, WorkSheetDayVal, OverSheetHrsVal);
            // PaymentBasis		PAYMENT_BASIS
            var paymentMSalary = new PaymentBasisTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_MSALARY_TARGETS),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_PAYMENT_BASIS), 
                MSalaryBasisVal);
            // OptimusBasis		OPTIMUS_BASIS
            var optimusMAwards = new OptimusBasisTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_MAWARDS_TARGETS),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_BASIS), 
                MAwardsBasisVal);
            // ReducedBasis		REDUCED_BASIS
            var reducedMAwards = new ReducedBasisTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_MAWARDS_RESULTS),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_REDUCED_BASIS),
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_MAWARDS_TARGETS));
            // OptimusFixed		OPTIMUS_FIXED
            var optPremiumBase = new OptimusFixedTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PREMIUM_TARGETS),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED), 
                FPremiumBaseVal);
            var optPremiumBoss = new OptimusFixedTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PREMADV_TARGETS),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED), 
                FPremiumBossVal);
            var optPremiumPers = new OptimusFixedTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PREMEXT_TARGETS),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED), 
                FPremiumPersVal);
            // ReducedFixed		REDUCED_FIXED
            var redPremiumBase = new ReducedFixedTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PREMIUM_RESULTS),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_REDUCED_FIXED), 
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PREMIUM_TARGETS));           
            var redPremiumBoss = new ReducedFixedTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PREMADV_RESULTS),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_REDUCED_FIXED), 
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PREMADV_TARGETS));   
            var redPremiumPers = new ReducedFixedTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PREMEXT_RESULTS),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_REDUCED_FIXED), 
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PREMEXT_TARGETS));          
            // AgrworkHours		AGRWORK_HOURS
            var allowceAgrwork = new AgrworkHoursTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_AGRWORK_TARGETS),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_AGRWORK_HOURS), 
                AgrWorkTarifVal, AgrWorkRatioVal, AgrWorkLimitVal, AgrHourLimitVal);
            // AllowceHours		ALLOWCE_HOURS
            var allowceHOffice = new AllowceHFullTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_HOFFICE),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HFULL), 
                HomeOffTarifVal, HomeOffHoursVal);
            // AllowceDaily		ALLOWCE_DAILY
            var allowceClothes = new AllowceDailyTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTHES),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_DAILY),
                ClothesDailyVal);

            var targets = new ITermTarget[] {
                contractTimePlan,
                contractTimeWork,
                contractTimeActa,
            };

            if (MSalaryBasisVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { paymentMSalary }).ToArray();
            }
            if (MAwardsBasisVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { optimusMAwards, reducedMAwards }).ToArray();
            }
            if (FPremiumBaseVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { optPremiumBase, redPremiumBase }).ToArray();
            }
            if (FPremiumBossVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { optPremiumBoss, redPremiumBoss }).ToArray();
            }
            if (FPremiumPersVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { optPremiumPers, redPremiumPers }).ToArray();
            }
            if (AgrWorkTarifVal != 0 && AgrWorkRatioVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { allowceAgrwork }).ToArray();
            }
            if (HomeOffTarifVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { allowceHOffice }).ToArray();
            }
            if (ClothesDailyVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { allowceClothes }).ToArray();
            }

            return targets;
        }
        public static double ResultDivDouble(double dblUpper, double dblDown, double multiplex = 1.0)
        {
            if (dblDown == 0.0)
            {
                return 0;
            }

            double dblReturn = ((dblUpper / dblDown) * multiplex);

            return (dblReturn);
        }
        public static Int32 RoundDoubleToInt(double dblValue)
        {
            const double NEZADANO_N0DOUBLE = 0.0;
            double dblAdjusted5 = ((dblValue >= NEZADANO_N0DOUBLE) ? dblValue + 0.5 : dblValue - 0.5);
            double dblRoundRown = Math.Truncate(dblAdjusted5);
            return Convert.ToInt32(dblRoundRown);
        }
        public static string CcyFormatDouble(double dblValue)
        {
            string resultText = string.Format("{0:N2}", dblValue);
            // No fear of rounding and takes the default number format
            // decimal decValue = dblValue;
            // decValue.ToString("0.00");
            // dblValue.ToString("F");
            // String.Format("{0:0.00}", dblValue);
            return resultText;
        }
        public static string NumFormatDouble(double dblValue)
        {
            string resultText = string.Format("{0:0.00}", dblValue);
            // No fear of rounding and takes the default number format
            // decimal decValue = dblValue;
            // decValue.ToString("0.00");
            // dblValue.ToString("F");
            return resultText;
        }
        public static string NumFormatInteger(Int32 nValue)
        {
            string resultText = string.Format("{0:0}", nValue);
            // No fear of rounding and takes the default number format
            // decimal decValue = dblValue;
            // decValue.ToString("0.00");
            // dblValue.ToString("F");
            return resultText;
        }
        public static string HrsFormatHHMM(double dblValue)
        {
            int nIntSumMinut = RoundDoubleToInt(dblValue * 60);
            int nIntHours = nIntSumMinut / 60;
            int nIntMinut = nIntSumMinut % 60;

            return string.Format("{0}:{1:00}", nIntHours, nIntMinut);
        }
        public static string HrsFormatDouble(double dblValue)
        {
            return string.Format("{0:N2}", dblValue);
        }
        public static string HrdFormatDouble(double dblValue)
        {
            return string.Format("{0:0.00}", dblValue);
        }
        public static string DayFormatDouble(double dblValue)
        {
            return string.Format("{0:N2}", dblValue);
        }
        public static string DecFormatDouble(double dblValue)
        {
            return string.Format("{0:N4}", dblValue);
        }
        public static string CcyFormatIntX100(Int32 value)
        {
            double dblValue = ResultDivDouble(value, 100);
            return CcyFormatDouble(dblValue);
        }
        public static string NumFormatIntX(Int32 value, bool bIntNumbers)
        {
            if (bIntNumbers)
            {
                return NumFormatInteger(value / 100);
            }
            else
            {
                double dblValue = ResultDivDouble(value, 100);
                return NumFormatDouble(dblValue);
            }
        }
        public static string RatFormatIntX100(Int32 value)
        {
            double dblValue = ResultDivDouble(value, 10000);
            return NumFormatDouble(dblValue);
        }
        public static string NumFormatIntX100(Int32 value)
        {
            double dblValue = ResultDivDouble(value, 100);
            return NumFormatDouble(dblValue);
        }
        public static string HrsFormatIntX060(Int32 value)
        {
            double dblValue = ResultDivDouble(value, 60);
            return HrsFormatDouble(dblValue);
        }
        public static string HrdFormatIntX060(Int32 value)
        {
            double dblValue = ResultDivDouble(value, 60);
            return HrdFormatDouble(dblValue);
        }
        public static string DayFormatIntX100(Int32 value)
        {
            double dblValue = ResultDivDouble(value, 100);
            return DayFormatDouble(dblValue);
        }
    }
}
