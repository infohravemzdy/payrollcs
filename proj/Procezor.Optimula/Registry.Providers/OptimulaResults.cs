using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Optimula.Registry.Constants;

namespace HraveMzdy.Procezor.Optimula.Registry.Providers
{
    // TimesheetsPlan		TIMESHEETS_PLAN
    public class TimesheetsPlanResult : OptimulaTermResult
    {
        public TimesheetsPlanResult(ITermTarget target, IArticleSpec spec,
            decimal fullSheetHrsVal,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            FullSheetHrsVal = fullSheetHrsVal;
        }

        public decimal FullSheetHrsVal { get; private set; }

        public override string ResultMessage()
        {
            return $"Full Time: {this.FullSheetHrsVal}";
        }
    }

    // TimesheetsWork		TIMESHEETS_WORK
    public class TimesheetsWorkResult : OptimulaTermResult
    {
        public TimesheetsWorkResult(ITermTarget target, IArticleSpec spec,
            decimal timeSheetHrsVal, decimal holiSheetHrsVal, decimal workLoadHrsCoef,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            TimeSheetHrsVal = timeSheetHrsVal;
            HoliSheetHrsVal = holiSheetHrsVal;
            WorkLoadHrsCoef = workLoadHrsCoef;
        }
        public decimal TimeSheetHrsVal { get; private set; }
        public decimal HoliSheetHrsVal { get; private set; }
        public decimal WorkLoadHrsCoef { get; private set; }

        public override string ResultMessage()
        {
            return $"Work Time: {this.TimeSheetHrsVal}, Holi Time: {this.HoliSheetHrsVal}, Work Coeff: {this.WorkLoadHrsCoef}";
        }
    }

    // TimeactualWork		TIMEACTUAL_WORK
    public class TimeactualWorkResult : OptimulaTermResult
    {
        public TimeactualWorkResult(ITermTarget target, IArticleSpec spec,
            decimal workSheetHrsVal, decimal workSheetDayVal, decimal overSheetHrsVal, decimal workTimeHrsCoef, 
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            WorkSheetHrsVal = workSheetHrsVal;
            WorkSheetDayVal = workSheetDayVal;
            OverSheetHrsVal = overSheetHrsVal;
            WorkTimeHrsCoef = workTimeHrsCoef;
        }

        public decimal WorkSheetHrsVal { get; private set; }
        public decimal WorkSheetDayVal { get; private set; }
        public decimal OverSheetHrsVal { get; private set; }
        public decimal WorkTimeHrsCoef { get; private set; }

        public override string ResultMessage()
        {
            return $"Work Hours: {this.WorkSheetHrsVal}, Work Days: {this.WorkSheetDayVal}, Over Hours: {this.OverSheetHrsVal}, Work Coeff: {this.WorkTimeHrsCoef}";
        }
    }

    // PaymentBasis		PAYMENT_BASIS
    public class PaymentBasisResult : OptimulaTermResult
    {
        public PaymentBasisResult(ITermTarget target, IArticleSpec spec,
            decimal msalaryBasisVal,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            MSalaryBasisVal = msalaryBasisVal;
        }
        public decimal MSalaryBasisVal { get; private set; }

        public override string ResultMessage()
        {
            return $"Salary Basis: {this.MSalaryBasisVal}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // OptimusBasis		OPTIMUS_BASIS
    public class OptimusBasisResult : OptimulaTermResult
    {
        public OptimusBasisResult(ITermTarget target, IArticleSpec spec,
            decimal msalaryBonusVal,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            MSalaryBonusVal = msalaryBonusVal;
        }

        public decimal MSalaryBonusVal { get; private set; }

        public override string ResultMessage()
        {
            return $"Salary Basis: {this.MSalaryBonusVal}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // OptimusFixed		OPTIMUS_FIXED
    public class OptimusFixedResult : OptimulaTermResult
    {
        public OptimusFixedResult(ITermTarget target, IArticleSpec spec,
            decimal premiumBasisVal,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            PremiumBasisVal = premiumBasisVal;
        }

        public decimal PremiumBasisVal;

        public override string ResultMessage()
        {
            return $"Premium Basis: {this.PremiumBasisVal}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // AgrworkHours		AGRWORK_HOURS
    public class AgrworkHoursResult : OptimulaTermResult
    {
        public AgrworkHoursResult(ITermTarget target, IArticleSpec spec,
            decimal agrWorkTarifVal, decimal agrWorkRatioVal, decimal agrWorkLimitVal, decimal agrHourLimitVal,
            decimal agrResultsHours,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            AgrWorkTarifVal = agrWorkTarifVal;
            AgrWorkRatioVal = agrWorkRatioVal;
            AgrWorkLimitVal = agrWorkLimitVal;
            AgrHourLimitVal = agrHourLimitVal;
            AgrResultsHours = agrResultsHours;
        }

        public decimal AgrWorkTarifVal { get; private set; }
        public decimal AgrWorkRatioVal { get; private set; }
        public decimal AgrWorkLimitVal { get; private set; }
        public decimal AgrHourLimitVal { get; private set; }
        public decimal AgrResultsHours { get; private set; }

        public override string ResultMessage()
        {
            return $"Tariff: {this.AgrWorkTarifVal}, Ratio: {this.AgrWorkRatioVal}, Tariff Limit: {this.AgrWorkLimitVal}, Hours Limit: {this.AgrHourLimitVal}, Hours Result: {this.AgrResultsHours}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // AllowceHFull		ALLOWCE_HFULL
    public class AllowceHFullResult : OptimulaTermResult
    {
        public AllowceHFullResult(ITermTarget target, IArticleSpec spec,
            decimal allowceTarifVal, decimal allowceHFullVal, 
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            AllowceTarifVal = allowceTarifVal;
            AllowceHFullVal = allowceHFullVal;
        }

        public decimal AllowceTarifVal { get; private set; }
        public decimal AllowceHFullVal { get; private set; }
       
        public override string ResultMessage()
        {
            return $"Tariff: {this.AllowceTarifVal}, Full Hours: {this.AllowceHFullVal}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // AllowceHours		ALLOWCE_HOURS
    public class AllowceHoursResult : OptimulaTermResult
    {
        public AllowceHoursResult(ITermTarget target, IArticleSpec spec,
            decimal allowceTarifVal, 
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            AllowceTarifVal = allowceTarifVal;
        }
        public decimal AllowceTarifVal { get; private set; }

        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // IncomesTaxFree		INCOMES_TAXFREE
    public class IncomesTaxFreeResult : OptimulaTermResult
    {
        public IncomesTaxFreeResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // IncomesTaxBase		INCOMES_TAXBASE
    public class IncomesTaxBaseResult : OptimulaTermResult
    {
        public IncomesTaxBaseResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // IncomesTaxWIns		INCOMES_TAXWINS
    public class IncomesTaxWInsResult : OptimulaTermResult
    {
        public IncomesTaxWInsResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // IncomesSummary		INCOMES_SUMMARY
    public class IncomesSummaryResult : OptimulaTermResult
    {
        public IncomesSummaryResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

}
