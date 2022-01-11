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
            DefaultClothesTarifValue = 0;
            DefaultHomeOffTarifValue = 0;
            DefaultHomeOffHoursValue = 0;
            DefaultMSalaryBonusValue = 0;
            DefaultHHourlyBonusValue = 0;
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
            ClothesTarifFunc = DefaultClothesTarif;
            HomeOffTarifFunc = DefaultHomeOffTarif;
            HomeOffHoursFunc = DefaultHomeOffHours;
            MSalaryBonusFunc = DefaultMSalaryBonus;
            HHourlyBonusFunc = DefaultHHourlyBonus;
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
        private Int32 DefaultClothesTarif(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultClothesTarifValue;
        }
        private Int32 DefaultHomeOffTarif(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultHomeOffTarifValue;
        }
        private Int32 DefaultHomeOffHours(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultHomeOffHoursValue;
        }
        private Int32 DefaultMSalaryBonus(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultMSalaryBonusValue;
        }
        private Int32 DefaultHHourlyBonus(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return DefaultHHourlyBonusValue;
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
        public Int32 DefaultClothesTarifValue { get; private set; }
        public Int32 DefaultHomeOffTarifValue { get; private set; }
        public Int32 DefaultHomeOffHoursValue { get; private set; }
        public Int32 DefaultMSalaryBonusValue { get; private set; }
        public Int32 DefaultHHourlyBonusValue { get; private set; }
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
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> ClothesTarifFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> HomeOffTarifFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> HomeOffHoursFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> MSalaryBonusFunc { get; private set; }
        public Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> HHourlyBonusFunc { get; private set; }
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
                ParseDecNumber,   //   3  AgrWorkTarif	105,00
                ParseDecNumber,   //   4  AgrWorkRatio	0,14
                ParseHrsNumber,   //   5  AgrHourLimit	0,00
                ParseDecNumber,   //   6  AgrWorkLimit	0,00
                ParseDecNumber,   //   7  ClothesTarif	57,00
                ParseDecNumber,   //   8  HomeOffTarif	0,00
                ParseHrsNumber,   //   9  HomeOffHours	0,00
                ParseDecNumber,   //   10  MSalaryBonus	8 000,00
                ParseHrsNumber,   //   11  HHourlyBonus	0,00
                ParseDecNumber,   //   12  FPremiumBase	0,00
                ParseDecNumber,   //   13  FPremiumBoss	0,00
                ParseDecNumber,   //   14  FPremiumPers	0,00
                ParseHrsNumber,   //   15  FullSheetHrs	176,00
                ParseHrsNumber,   //   16  TimeSheetHrs	176,00
                ParseHrsNumber,   //   17  HoliSheetHrs	0,00
                ParseHrsNumber,   //   18  WorkSheetHrs	96,00
                ParseDecNumber,   //   19  WorkSheetDay	12,00
                ParseHrsNumber,   //   20  OverSheetHrs	40,00
                ParseHrsNumber,   //   21  VacaRecomHrs	80,00
                ParseHrsNumber,   //   22  PaidRecomHrs	0,00
                ParseHrsNumber,   //   23  HoliRecomHrs	0,00
                ParseNANothing,   //24  -----------
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

            Func<Int32, OptimulaGenerator>[] specGenerator = new Func<Int32, OptimulaGenerator>[]
            {
                gen.WithNANothingVal,   //   1  EmployeeNumb	101
                gen.WithNANothingVal,   //   2  EmployeeName	Drahota Jakub
                gen.WithAgrWorkTarifVal,   //   3  AgrWorkTarif	105,00
                gen.WithAgrWorkRatioVal,   //   4  AgrWorkRatio	0,14
                gen.WithAgrHourLimitVal,   //   5  AgrHourLimit	0,00
                gen.WithAgrWorkLimitVal,   //   6  AgrWorkLimit	0,00
                gen.WithClothesTarifVal,   //   7  ClothesTarif	57,00
                gen.WithHomeOffTarifVal,   //   8  HomeOffTarif	0,00
                gen.WithHomeOffHoursVal,   //   9  HomeOffHours	0,00
                gen.WithMSalaryBonusVal,   //   10  MSalaryBonus	8 000,00
                gen.WithHHourlyBonusVal,   //   11  HHourlyBonus	0,00
                gen.WithFPremiumBaseVal,   //   12  FPremiumBase	0,00
                gen.WithFPremiumBossVal,   //   13  FPremiumBoss	0,00
                gen.WithFPremiumPersVal,   //   14  FPremiumPers	0,00
                gen.WithFullSheetHrsVal,   //   15  FullSheetHrs	176,00
                gen.WithTimeSheetHrsVal,   //   16  TimeSheetHrs	176,00
                gen.WithHoliSheetHrsVal,   //   17  HoliSheetHrs	0,00
                gen.WithWorkSheetHrsVal,   //   18  WorkSheetHrs	96,00
                gen.WithWorkSheetDayVal,   //   19  WorkSheetDay	12,00
                gen.WithOverSheetHrsVal,   //   20  OverSheetHrs	40,00
                gen.WithVacaRecomHrsVal,   //   21  VacaRecomHrs	80,00
                gen.WithPaidRecomHrsVal,   //   22  PaidRecomHrs	0,00
                gen.WithHoliRecomHrsVal,   //   23  HoliRecomHrs	0,00
                gen.WithNANothingVal,   //24  -----------
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
            /*
            EmployeeNumb;EmployeeName;AgrWorkTarif;AgrWorkRatio;AgrHourLimit;AgrWorkLimit;ClothesTarif;HomeOffTarif;HomeOffHours;MSalaryBonus;HHourlyBonus;FPremiumBase;FPremiumBoss;FPremiumPers;FullSheetHrs;TimeSheetHrs;HoliSheetHrs;WorkSheetHrs;WorkSheetDay;OverSheetHrs;VacaRecomHrs;PaidRecomHrs;HoliRecomHrs;OverAllowHrs;OverAllowRio;RestAllowHrs;RestAllowRio;WendAllowHrs;WendAllowRio;NighAllowHrs;NighAllowRio;HoliAllowHrs;HoliAllowRio;QClothesBase;QHOfficeBase;QAgrWorkBase;QSumWorkHour;
            101;Drahota Jakub;105,00;0,14;0,00;0,00;57,00;0,00;0,00;8 000,00;0,00;0,00;0,00;0,00;176,00;176,00;0,00;96,00;12,00;40,00;80,00;0,00;0,00;40,00;0,25;0,00;0,00;0,00;0,00;18,25;0,10;0,00;0,00;3 506,00;0,00;8 852,00;912,08
            */
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
            DefaultClothesTarifValue = val;
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
        public OptimulaGenerator WithMSalaryBonusVal(Int32 val)
        {
            DefaultMSalaryBonusValue = val;
            return this;
        }
        public OptimulaGenerator WithHHourlyBonusVal(Int32 val)
        {
            DefaultHHourlyBonusValue = val;
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
            ClothesTarifFunc = func;
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
        public OptimulaGenerator WithMSalaryBonus(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            MSalaryBonusFunc = func;
            return this;
        }
        public OptimulaGenerator WithHHourlyBonus(Func<OptimulaGenerator, IPeriod, IBundleProps, IBundleProps, Int32> func)
        {
            HHourlyBonusFunc = func;
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
            Int32 ClothesTarifVal = ClothesTarifFunc(this, period, ruleset, prevset);
            Int32 HomeOffTarifVal = HomeOffTarifFunc(this, period, ruleset, prevset);
            Int32 HomeOffHoursVal = HomeOffHoursFunc(this, period, ruleset, prevset);

            Int32 MSalaryBonusVal = MSalaryBonusFunc(this, period, ruleset, prevset);
            Int32 HHourlyBonusVal = HHourlyBonusFunc(this, period, ruleset, prevset);
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
                $"{CcyFormatIntX100(AgrWorkTarifVal)}", // C
                $"{NumFormatIntX100(AgrWorkRatioVal)}", // D
                $"{HrsFormatIntX060(AgrHourLimitVal)}", // E
                $"{NumFormatIntX100(AgrWorkLimitVal)}", // F
                $"{CcyFormatIntX100(ClothesTarifVal)}", // G
                $"{CcyFormatIntX100(HomeOffTarifVal)}", // H
                $"{HrsFormatIntX060(HomeOffHoursVal)}", // I
                $"{CcyFormatIntX100(MSalaryBonusVal)}", // J
                $"{CcyFormatIntX100(HHourlyBonusVal)}", // K
                $"{CcyFormatIntX100(FPremiumBaseVal)}", // L
                $"{CcyFormatIntX100(FPremiumBossVal)}", // M
                $"{CcyFormatIntX100(FPremiumPersVal)}", // N
                $"{HrsFormatIntX060(FullSheetHrsVal)}", // O  
                $"{HrsFormatIntX060(TimeSheetHrsVal)}", // P  
                $"{HrsFormatIntX060(HoliSheetHrsVal)}", // Q  
                $"{HrsFormatIntX060(WorkSheetHrsVal)}", // R  
                $"{DayFormatIntX100(WorkSheetDayVal)}", // S   
                $"{HrsFormatIntX060(OverSheetHrsVal)}", // T
                $"{HrsFormatIntX060(VacaRecomHrsVal)}", // U
                $"{HrsFormatIntX060(PaidRecomHrsVal)}", // V
                $"{HrsFormatIntX060(HoliRecomHrsVal)}", // W  
                "", // X     
                "", // Y     
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
            Int32 ClothesTarifVal = ClothesTarifFunc(this, period, ruleset, prevset);
            Int32 HomeOffTarifVal = HomeOffTarifFunc(this, period, ruleset, prevset);
            Int32 HomeOffHoursVal = HomeOffHoursFunc(this, period, ruleset, prevset);

            Int32 MSalaryBonusVal = MSalaryBonusFunc(this, period, ruleset, prevset);
            Int32 HHourlyBonusVal = HHourlyBonusFunc(this, period, ruleset, prevset);
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
                $"{CcyFormatIntX100(AgrWorkTarifVal)}", // C
                $"{NumFormatIntX100(AgrWorkRatioVal)}", // D
                $"{HrsFormatIntX060(AgrHourLimitVal)}", // E
                $"{NumFormatIntX100(AgrWorkLimitVal)}", // F
                $"{CcyFormatIntX100(ClothesTarifVal)}", // G
                $"{CcyFormatIntX100(HomeOffTarifVal)}", // H
                $"{HrsFormatIntX060(HomeOffHoursVal)}", // I
                $"{CcyFormatIntX100(MSalaryBonusVal)}", // J
                $"{CcyFormatIntX100(HHourlyBonusVal)}", // K
                $"{CcyFormatIntX100(FPremiumBaseVal)}", // L
                $"{CcyFormatIntX100(FPremiumBossVal)}", // M
                $"{CcyFormatIntX100(FPremiumPersVal)}", // N
                $"{HrsFormatIntX060(FullSheetHrsVal)}", // O  
                $"{HrsFormatIntX060(TimeSheetHrsVal)}", // P  
                $"{HrsFormatIntX060(HoliSheetHrsVal)}", // Q  
                $"{HrsFormatIntX060(WorkSheetHrsVal)}", // R  
                $"{DayFormatIntX100(WorkSheetDayVal)}", // S   
                $"{HrsFormatIntX060(OverSheetHrsVal)}", // T
                $"{HrsFormatIntX060(VacaRecomHrsVal)}", // U
                $"{HrsFormatIntX060(PaidRecomHrsVal)}", // V
                $"{HrsFormatIntX060(HoliRecomHrsVal)}", // W  
                "", // X     
                "", // Y     
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
            Int32 ClothesTarifVal = ClothesTarifFunc(this, period, ruleset, prevset);
            Int32 HomeOffTarifVal = HomeOffTarifFunc(this, period, ruleset, prevset);
            Int32 HomeOffHoursVal = HomeOffHoursFunc(this, period, ruleset, prevset);

            Int32 MSalaryBasisVal = 0;
            Int32 MSalaryBonusVal = MSalaryBonusFunc(this, period, ruleset, prevset);
            Int32 HHourlyBonusVal = HHourlyBonusFunc(this, period, ruleset, prevset);
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
            var timeactualWork = new TimeactualWorkTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_TIMEACTUAL_WORK), 
                WorkSheetHrsVal, WorkSheetDayVal, OverSheetHrsVal);
            // PaymentBasis		PAYMENT_BASIS
            var paymentMSalary = new PaymentBasisTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_MSALARY_BASICAL),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_PAYMENT_BASIS), 
                MSalaryBasisVal);
            // OptimusBasis		OPTIMUS_BASIS
            var paymentMPerson = new OptimusBasisTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_MSALARY_BONUSED),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_BASIS), 
                MSalaryBonusVal);
            // OptimusFixed		OPTIMUS_FIXED
            var payPremiumBase = new OptimusFixedTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PREMIUM_BONUSED),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED), 
                FPremiumBaseVal);
            var payPremiumBoss = new OptimusFixedTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PREMIUM_BONUSED),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED), 
                FPremiumBossVal);
            var payPremiumPers = new OptimusFixedTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PREMIUM_BONUSED),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED), 
                FPremiumPersVal);
            // AgrworkHours		AGRWORK_HOURS
            var allowceAgrwork = new AgrworkHoursTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_AGRWORK),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_AGRWORK_HOURS), 
                AgrWorkTarifVal, AgrWorkRatioVal, AgrWorkLimitVal, AgrHourLimitVal);
            // AllowceHours		ALLOWCE_HOURS
            var allowceHOffice = new AllowceHFullTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_HOFFICE),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HFULL), 
                HomeOffTarifVal, HomeOffHoursVal);
            // AllowceHours		ALLOWCE_HOURS
            var allowceClothes = new AllowceHoursTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTHES),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS), 
                ClothesTarifVal);

            var targets = new ITermTarget[] {
                contractTimePlan,
                contractTimeWork,
            };

            if (MSalaryBasisVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { paymentMSalary }).ToArray();
            }
            if (MSalaryBonusVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { paymentMPerson }).ToArray();
            }
            if (FPremiumBaseVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { payPremiumBase }).ToArray();
            }
            if (FPremiumBossVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { payPremiumBoss }).ToArray();
            }
            if (FPremiumPersVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { payPremiumPers }).ToArray();
            }
            if (AgrWorkTarifVal != 0 && AgrWorkRatioVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { allowceAgrwork }).ToArray();
            }
            if (HomeOffTarifVal != 0)
            {
                targets = targets.Concat(new ITermTarget[] { allowceHOffice }).ToArray();
            }
            if (ClothesTarifVal != 0)
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
