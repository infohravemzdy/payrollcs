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
            return 0;
        }
        private Int32 DefaultAgrWorkRatio(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultAgrHourLimit(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultAgrWorkLimit(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultClothesTarif(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultHomeOffTarif(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultHomeOffHours(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultMSalaryBonus(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultHHourlyBonus(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultFPremiumBase(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultFPremiumBoss(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultFPremiumPers(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultFullSheetHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultTimeSheetHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultHoliSheetHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultWorkSheetHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultWorkSheetDay(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultOverSheetHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultVacaRecomHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultHoliRecomHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultOverAllowHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultOverAllowRio(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultRestAllowHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultRestAllowRio(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultWendAllowHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultWendAllowRio(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultNighAllowHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultNighAllowRio(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultHoliAllowHrs(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }
        private Int32 DefaultHoliAllowRio(OptimulaGenerator gen, IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            return 0;
        }

        public int Id { get; }
        public string Name { get; }
        public string Number { get; }

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

        public static OptimulaGenerator Spec(Int32 id, string name, string number)
        {
            return new OptimulaGenerator(id, name, number);
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

        public string[] BuildImportString(IPeriod period, IBundleProps ruleset, IBundleProps prevset)
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

            string[] valuesList = new string[]
            {
                Number, // A
                Name,   // B
                $"{AgrWorkTarifVal}", // C
                $"{AgrWorkRatioVal}", // D
                $"{AgrHourLimitVal}", // E
                $"{AgrWorkLimitVal}", // F
                $"{ClothesTarifVal}", // G
                $"{HomeOffTarifVal}", // H
                $"{HomeOffHoursVal}", // I
                $"{MSalaryBonusVal}", // J
                $"{HHourlyBonusVal}", // K
                $"{FPremiumBaseVal}", // L
                $"{FPremiumBossVal}", // M
                $"{FPremiumPersVal}", // N
                $"{FullSheetHrsVal}", // O  
                $"{TimeSheetHrsVal}", // P  
                $"{HoliSheetHrsVal}", // Q  
                $"{WorkSheetHrsVal}", // R  
                $"{WorkSheetDayVal}", // S   
                $"{OverSheetHrsVal}", // T
                $"{VacaRecomHrsVal}", // U
                $"{HoliRecomHrsVal}", // V  
                "", // W     
                "", // X     
                "", // Y     
                "", // Z     
                $"{OverAllowHrsVal}", // AB
                $"{OverAllowRioVal}", // AC
                $"{RestAllowHrsVal}", // AD
                $"{RestAllowRioVal}", // AE
                $"{WendAllowHrsVal}", // AF
                $"{WendAllowRioVal}", // AG
                $"{NighAllowHrsVal}", // AH
                $"{NighAllowRioVal}", // AI
                $"{HoliAllowHrsVal}", // AJ
                $"{HoliAllowRioVal}", // AK
            };
            string[] importResult = new string[] { string.Join('\t', valuesList) };

            return importResult;
        }
        public IEnumerable<ITermTarget> BuildSpecTargets(IPeriod period, IBundleProps ruleset, IBundleProps prevset)
        {
            var targets = Array.Empty<ITermTarget>();

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
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_TIMESHEETS_PLAN), 0);
            // ContractTimeWork	CONTRACT_TIME_WORK
            var contractTimeWork = new TimesheetsWorkTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_WORK),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_TIMESHEETS_WORK), 0);
            // PaymentBasis		PAYMENT_BASIS
            var paymentMSalary = new PaymentBasisTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_MSALARY_BASICAL),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_PAYMENT_BASIS), 0);
            // OptimusBasis		OPTIMUS_BASIS
            var paymentMPerson = new OptimusBasisTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_MSALARY_BONUSED),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_BASIS), 0);
            // OptimusFixed		OPTIMUS_FIXED
            var paymentPremium = new OptimusFixedTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_PREMIUM_BONUSED),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED), 0);
            // AgrworkHours		AGRWORK_HOURS
            var agrworkHours = new AgrworkHoursTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_AGRWORK),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_AGRWORK_HOURS), 0);
            // AllowceHours		ALLOWCE_HOURS
            var allowceHOffice = new AllowceHoursTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_HOFFICE),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS), 0);
            // AllowceHours		ALLOWCE_HOURS
            var allowceClothes = new AllowceHoursTarget(montCode, contractEmp, positionEmp, variant1Emp,
                ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTHES),
                ConceptCode.Get((Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS), 0);

            //targets = targets.Concat(new ITermTarget[] { targetSgn }).ToArray();

            return targets;
        }
    }
}
