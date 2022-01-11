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
            Int32 fullSheetHrsVal,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            FullSheetHrsVal = fullSheetHrsVal;
        }

        public Int32 FullSheetHrsVal { get; private set; }

        public override string ResultMessage()
        {
            return $"Full Time: {this.FullSheetHrsVal}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TimesheetsWork		TIMESHEETS_WORK
    public class TimesheetsWorkResult : OptimulaTermResult
    {
        public TimesheetsWorkResult(ITermTarget target, IArticleSpec spec,
            Int32 timeSheetHrsVal, Int32 holiSheetHrsVal,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            TimeSheetHrsVal = timeSheetHrsVal;
            HoliSheetHrsVal = holiSheetHrsVal;
        }
        public Int32 TimeSheetHrsVal { get; private set; }
        public Int32 HoliSheetHrsVal { get; private set; }

        public override string ResultMessage()
        {
            return $"Work Time: {this.TimeSheetHrsVal}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TimeactualWork		TIMEACTUAL_WORK
    public class TimeactualWorkResult : OptimulaTermResult
    {
        public TimeactualWorkResult(ITermTarget target, IArticleSpec spec,
            Int32 workSheetHrsVal, Int32 workSheetDayVal, Int32 overSheetHrsVal,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            WorkSheetHrsVal = workSheetHrsVal;
            WorkSheetDayVal = workSheetDayVal;
            OverSheetHrsVal = overSheetHrsVal;
        }

        public Int32 WorkSheetHrsVal { get; private set; }
        public Int32 WorkSheetDayVal { get; private set; }
        public Int32 OverSheetHrsVal { get; private set; }

        public override string ResultMessage()
        {
            return $"Work Hours: {this.WorkSheetHrsVal}, Work Days: {this.WorkSheetDayVal}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // PaymentBasis		PAYMENT_BASIS
    public class PaymentBasisResult : OptimulaTermResult
    {
        public PaymentBasisResult(ITermTarget target, IArticleSpec spec,
            Int32 msalaryBasisVal,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            MSalaryBasisVal = msalaryBasisVal;
        }
        public Int32 MSalaryBasisVal { get; private set; }

        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // OptimusBasis		OPTIMUS_BASIS
    public class OptimusBasisResult : OptimulaTermResult
    {
        public OptimusBasisResult(ITermTarget target, IArticleSpec spec,
            Int32 msalaryBonusVal,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            MSalaryBonusVal = msalaryBonusVal;
        }

        public Int32 MSalaryBonusVal { get; private set; }

        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // OptimusFixed		OPTIMUS_FIXED
    public class OptimusFixedResult : OptimulaTermResult
    {
        public OptimusFixedResult(ITermTarget target, IArticleSpec spec,
            Int32 premiumBasisVal,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            PremiumBasisVal = premiumBasisVal;
        }

        public Int32 PremiumBasisVal;

        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // AgrworkHours		AGRWORK_HOURS
    public class AgrworkHoursResult : OptimulaTermResult
    {
        public AgrworkHoursResult(ITermTarget target, IArticleSpec spec,
            Int32 agrWorkTarifVal, Int32 agrWorkRatioVal, Int32 agrWorkLimitVal, Int32 agrHourLimitVal,
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            AgrWorkTarifVal = agrWorkTarifVal;
            AgrWorkRatioVal = agrWorkRatioVal;
            AgrWorkLimitVal = agrWorkLimitVal;
            AgrHourLimitVal = agrHourLimitVal;
        }

        public Int32 AgrWorkTarifVal { get; private set; }
        public Int32 AgrWorkRatioVal { get; private set; }
        public Int32 AgrWorkLimitVal { get; private set; }
        public Int32 AgrHourLimitVal { get; private set; }

        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // AllowceHFull		ALLOWCE_HFULL
    public class AllowceHFullResult : OptimulaTermResult
    {
        public AllowceHFullResult(ITermTarget target, IArticleSpec spec,
            Int32 allowceTarifVal, Int32 allowceHFullVal, 
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            AllowceTarifVal = allowceTarifVal;
            AllowceHFullVal = allowceHFullVal;
        }

        public Int32 AllowceTarifVal { get; private set; }
        public Int32 AllowceHFullVal { get; private set; }
        
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // AllowceHours		ALLOWCE_HOURS
    public class AllowceHoursResult : OptimulaTermResult
    {
        public AllowceHoursResult(ITermTarget target, IArticleSpec spec,
            Int32 allowceTarifVal, 
            Int32 value, Int32 basis) : base(target, spec, value, basis)
        {
            AllowceTarifVal = allowceTarifVal;
        }
        public Int32 AllowceTarifVal { get; private set; }

        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

}
