using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Interfaces;
using Procezor.Payrolex.Registry.Constants;

namespace Procezor.Payrolex.Registry.Providers
{
    // ContractTerm		CONTRACT_TERM
    class ContractWorkTermResult : PayrolexTermResult
    {
        public WorkContractTerms TermType { get; private set; }
        public Byte TermDayFrom { get; private set; }
        public Byte TermDayStop { get; private set; }
        public ContractWorkTermResult(ITermTarget target, IArticleSpec spec, WorkContractTerms termType, Byte dayTermFrom, Byte dayTermStop) : base(target, spec, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TermType = termType;
            TermDayFrom = dayTermFrom;
            TermDayStop = dayTermStop;
        }
        public override string ResultMessage()
        {
            return $"{TermDayFrom} - {TermDayStop}";
        }
    }

    // PositionTerm		POSITION_TERM
    class PositionWorkTermResult : PayrolexTermResult
    {
        public string TermName { get; private set; }
        public Byte TermDayFrom { get; private set; }
        public Byte TermDayStop { get; private set; }
        public PositionWorkTermResult(ITermTarget target, IArticleSpec spec, string termName, Byte dayFrom, Byte dayStop) : base(target, spec, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TermName = termName;
            TermDayFrom = dayFrom;
            TermDayStop = dayStop;
        }
        public override string ResultMessage()
        {
            return $"{TermDayFrom} - {TermDayStop}";
        }
    }

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
        public ContractTimePlanResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
    }

    // ContractTimeWork		CONTRACT_TIME_WORK
    class ContractTimeWorkResult : PayrolexTermResult
    {
        public ContractTimeWorkResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
    }

    // ContractTimeAbsc		CONTRACT_TIME_ABSC
    class ContractTimeAbscResult : PayrolexTermResult
    {
        public ContractTimeAbscResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
    }

    // PaymentBasis		PAYMENT_BASIS
    class PaymentBasisResult : PayrolexTermResult
    {
        public PaymentBasisResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // PaymentFixed		PAYMENT_FIXED
    class PaymentFixedResult : PayrolexTermResult
    {
        public PaymentFixedResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // IncomeGross		INCOME_GROSS
    class IncomeGrossResult : PayrolexTermResult
    {
        public IncomeGrossResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // IncomeNetto		INCOME_NETTO
    class IncomeNettoResult : PayrolexTermResult
    {
        public IncomeNettoResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

}
