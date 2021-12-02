using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Payrolex.Registry.Constants;

namespace HraveMzdy.Procezor.Payrolex.Registry.Providers
{
    // PositionWorkPlan		POSITION_WORK_PLAN
    class PositionWorkPlanResult : PayrolexTermResult
    {
        public WorkScheduleType WorkType { get; private set; }
        public Int32[] HoursFullWeeks { get; private set; }
        public Int32[] HoursRealWeeks { get; private set; }
        public Int32[] HoursFullMonth { get; private set; }
        public Int32[] HoursRealMonth { get; private set; }

        public PositionWorkPlanResult(ITermTarget target, IArticleSpec spec, 
            WorkScheduleType workType, Int32[] fullWeeks, Int32[] realWeeks, Int32[] fullMonth, Int32[] realMonth)
            : base(target, spec, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            WorkType = workType;
            HoursFullWeeks = fullWeeks.ToArray();
            HoursRealWeeks = realWeeks.ToArray();
            HoursFullMonth = fullMonth.ToArray();
            HoursRealMonth = realMonth.ToArray();
        }
        public override string ResultMessage()
        {
            Int32 TotalFullWeeks = HoursFullWeeks.Aggregate(0, (agr, x) => agr + x);
            Int32 TotalRealWeeks = HoursRealWeeks.Aggregate(0, (agr, x) => agr + x);
            Int32 TotalFullMonth = HoursFullMonth.Aggregate(0, (agr, x) => agr + x);
            Int32 TotalRealMonth = HoursRealMonth.Aggregate(0, (agr, x) => agr + x);
            return $"{TotalFullWeeks}/{TotalRealWeeks} => {TotalFullMonth}/{TotalRealMonth}";
        }
    }

    // PositionTimePlan		POSITION_TIME_PLAN
    class PositionTimePlanResult : PayrolexTermResult
    {
        public Byte TermDayFrom { get; private set; }
        public Byte TermDayStop { get; private set; }
        public Int32[] HoursRealMonth { get; private set; }
        public Int32[] HoursTermMonth { get; private set; }
        public PositionTimePlanResult(ITermTarget target, IArticleSpec spec, Byte dayTermFrom, Byte dayTermStop, 
            Int32[] realMonth, Int32[] termMonth)
            : base(target, spec, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TermDayFrom = dayTermFrom;
            TermDayStop = dayTermStop;
            HoursRealMonth = realMonth.ToArray();
            HoursTermMonth = termMonth.ToArray();
        }
        public override string ResultMessage()
        {
            Int32 TotalRealMonth = HoursRealMonth.Aggregate(0, (agr, x) => agr + x);
            Int32 TotalTermMonth = HoursTermMonth.Aggregate(0, (agr, x) => agr + x);
            return $"{TermDayFrom} - {TermDayStop} => {TotalRealMonth}/{TotalTermMonth}";
        }
    }

    // PositionTimeWork		POSITION_TIME_WORK
    class PositionTimeWorkResult : PayrolexTermResult
    {
        public Byte TermDayFrom { get; private set; }
        public Byte TermDayStop { get; private set; }
        public Int32[] HoursTermMonth { get; private set; }
        public PositionTimeWorkResult(ITermTarget target, IArticleSpec spec, Byte dayTermFrom, Byte dayTermStop, Int32[] termMonth)
            : base(target, spec, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TermDayFrom = dayTermFrom;
            TermDayStop = dayTermStop;
            HoursTermMonth = termMonth.ToArray();
        }
        public override string ResultMessage()
        {
            Int32 TotalTermMonth = HoursTermMonth.Aggregate(0, (agr, x) => agr + x);
            return $"{TermDayFrom} - {TermDayStop} => {TotalTermMonth}";
        }
    }

    // PositionTimeAbsc		POSITION_TIME_ABSC
    class PositionTimeAbscResult : PayrolexTermResult
    {
        public Byte TermDayFrom { get; private set; }
        public Byte TermDayStop { get; private set; }
        public Int32[] HoursTermMonth { get; private set; }
        public PositionTimeAbscResult(ITermTarget target, IArticleSpec spec, Byte dayTermFrom, Byte dayTermStop, Int32[] termMonth)
            : base(target, spec, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TermDayFrom = dayTermFrom;
            TermDayStop = dayTermStop;
            HoursTermMonth = termMonth.ToArray();
        }
        public override string ResultMessage()
        {
            Int32 TotalTermMonth = HoursTermMonth.Aggregate(0, (agr, x) => agr + x);
            return $"{TermDayFrom} - {TermDayStop} => {TotalTermMonth}";
        }
    }

    // ContractTimePlan		CONTRACT_TIME_PLAN
    class ContractTimePlanResult : PayrolexTermResult
    {
        public Int32[] HoursTimeMonth { get; private set; }
        public ContractTimePlanResult(ITermTarget target, IArticleSpec spec, Int32[] timeMonth)
            : base(target, spec, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            HoursTimeMonth = timeMonth.ToArray();
        }
        public override string ResultMessage()
        {
            Int32 TotalTimeMonth = HoursTimeMonth.Aggregate(0, (agr, x) => agr + x);
            return $"Total Work Schedule => {TotalTimeMonth}";
        }
    }

    // ContractTimeWork		CONTRACT_TIME_WORK
    class ContractTimeWorkResult : PayrolexTermResult
    {
        public Int32[] HoursTimeMonth { get; private set; }
        public ContractTimeWorkResult(ITermTarget target, IArticleSpec spec, Int32[] timeMonth)
            : base(target, spec, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            HoursTimeMonth = timeMonth.ToArray();
        }
        public override string ResultMessage()
        {
            Int32 TotalTimeMonth = HoursTimeMonth.Aggregate(0, (agr, x) => agr + x);
            return $"Total worked => {TotalTimeMonth}";
        }
    }

    // ContractTimeAbsc		CONTRACT_TIME_ABSC
    class ContractTimeAbscResult : PayrolexTermResult
    {
        public Int32[] HoursTimeMonth { get; private set; }
        public ContractTimeAbscResult(ITermTarget target, IArticleSpec spec, Int32[] timeMonth)
            : base(target, spec, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            HoursTimeMonth = timeMonth.ToArray();
        }
        public override string ResultMessage()
        {
            Int32 TotalTimeMonth = HoursTimeMonth.Aggregate(0, (agr, x) => agr + x);
            return $"Total absence => {TotalTimeMonth}";
        }
    }

}
