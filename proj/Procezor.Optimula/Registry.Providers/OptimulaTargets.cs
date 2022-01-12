using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Legalios.Service.Types;
using HraveMzdy.Procezor.Optimula.Registry.Constants;

namespace HraveMzdy.Procezor.Optimula.Registry.Providers
{
    // TimesheetsPlan		TIMESHEETS_PLAN
    public class TimesheetsPlanTarget : OptimulaTermTarget
    {
        public Int32 FullSheetHrsVal { get; private set; }

        public TimesheetsPlanTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 fullSheetHrsVal) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO)
        {
            FullSheetHrsVal = fullSheetHrsVal;
        }
    }

    // TimesheetsWork		TIMESHEETS_WORK
    public class TimesheetsWorkTarget : OptimulaTermTarget
    {
        public Int32 TimeSheetHrsVal { get; private set; }
        public Int32 HoliSheetHrsVal { get; private set; }

        public TimesheetsWorkTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 timeSheetHrsVal, Int32 holiSheetHrsVal) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO)
        {
            TimeSheetHrsVal = timeSheetHrsVal;
            HoliSheetHrsVal = holiSheetHrsVal;
        }
    }

    // TimeactualWork		TIMEACTUAL_WORK
    public class TimeactualWorkTarget : OptimulaTermTarget
    {
        public Int32 WorkSheetHrsVal { get; private set; }
        public Int32 WorkSheetDayVal { get; private set; }
        public Int32 OverSheetHrsVal { get; private set; }

        public TimeactualWorkTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 workSheetHrsVal, Int32 workSheetDayVal, Int32 overSheetHrsVal) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO)
        {
            WorkSheetHrsVal = workSheetHrsVal;
            WorkSheetDayVal = workSheetDayVal;
            OverSheetHrsVal = overSheetHrsVal;
        }
    }

    // PaymentBasis		PAYMENT_BASIS
    public class PaymentBasisTarget : OptimulaTermTarget
    {
        public Int32 MSalaryBasisVal { get; private set; }

        public PaymentBasisTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 msalaryBasisVal) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO)
        {
            MSalaryBasisVal = msalaryBasisVal;
        }
    }

    // OptimusBasis		OPTIMUS_BASIS
    public class OptimusBasisTarget : OptimulaTermTarget
    {
        public Int32 MSalaryBonusVal { get; private set; }

        public OptimusBasisTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 msalaryBonusVal) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO)
        {
            MSalaryBonusVal = msalaryBonusVal;
        }
    }

    // OptimusFixed		OPTIMUS_FIXED
    public class OptimusFixedTarget : OptimulaTermTarget
    {
        public Int32 PremiumBasisVal { get; private set; }

        public OptimusFixedTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 premiumBasisVal) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO)
        {
            PremiumBasisVal = premiumBasisVal;
        }
    }

    // AgrworkHours		AGRWORK_HOURS
    public class AgrworkHoursTarget : OptimulaTermTarget
    {
        public Int32 AgrWorkTarifVal { get; private set; }
        public Int32 AgrWorkRatioVal { get; private set; }
        public Int32 AgrWorkLimitVal { get; private set; }
        public Int32 AgrHourLimitVal { get; private set; }

        public AgrworkHoursTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 agrWorkTarifVal, Int32 agrWorkRatioVal, Int32 agrWorkLimitVal, Int32 agrHourLimitVal) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO)
        {
            AgrWorkTarifVal = agrWorkTarifVal;
            AgrWorkRatioVal = agrWorkRatioVal;
            AgrWorkLimitVal = agrWorkLimitVal;
            AgrHourLimitVal = agrHourLimitVal;
        }
    }

    // AllowceHFull		ALLOWCE_HFULL
    public class AllowceHFullTarget : OptimulaTermTarget
    {
        public Int32 AllowceTarifVal { get; private set; }
        public Int32 AllowceHFullVal { get; private set; }

        public AllowceHFullTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 allowceTarifVal, Int32 allowceHFullVal) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO)
        {
            AllowceTarifVal = allowceTarifVal;
            AllowceHFullVal = allowceHFullVal;
        }
    }

    // AllowceHours		ALLOWCE_HOURS
    public class AllowceHoursTarget : OptimulaTermTarget
    {
        public Int32 AllowceTarifVal { get; private set; }

        public AllowceHoursTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 allowceTarifVal) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO)
        {
            AllowceTarifVal = allowceTarifVal;
        }
    }

    // IncomesTaxFree		INCOMES_TAXFREE
    public class IncomesTaxFreeTarget : OptimulaTermTarget
    {
        public IncomesTaxFreeTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO)
        {
        }
    }

    // IncomesTaxBase		INCOMES_TAXBASE
    public class IncomesTaxBaseTarget : OptimulaTermTarget
    {
        public IncomesTaxBaseTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO)
        {
        }
    }

    // IncomesTaxWIns		INCOMES_TAXWINS
    public class IncomesTaxWInsTarget : OptimulaTermTarget
    {
        public IncomesTaxWInsTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO)
        {
        }
    }

    // IncomesSummary		INCOMES_SUMMARY
    public class IncomesSummaryTarget : OptimulaTermTarget
    {
        public IncomesSummaryTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO)
        {
        }
    }

}
