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
    class ContractTermResult : PayrolexTermResult
    {
        public WorkContractTerms TermType { get; private set; }
        public Byte TermDayFrom { get; private set; }
        public Byte TermDayStop { get; private set; }
        public ContractTermResult(ITermTarget target, WorkContractTerms termType, Byte dayFrom, Byte dayStop) : base(target, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TermType = termType;
            TermDayFrom = dayFrom;
            TermDayStop = dayStop;
        }
    }

    // PositionTerm		POSITION_TERM
    class PositionTermResult : PayrolexTermResult
    {
        public string TermName { get; private set; }
        public Byte TermDayFrom { get; private set; }
        public Byte TermDayStop { get; private set; }
        public PositionTermResult(ITermTarget target, string termName, Byte dayFrom, Byte dayStop) : base(target, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TermName = termName;
            TermDayFrom = dayFrom;
            TermDayStop = dayStop;
        }
    }

    // PositionWorkPlan		POSITION_WORK_PLAN
    class PositionWorkPlanResult : PayrolexTermResult
    {
        public PositionWorkPlanResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, value, basis, descr)
        {
        }
    }

    // PositionTimePlan		POSITION_TIME_PLAN
    class PositionTimePlanResult : PayrolexTermResult
    {
        public PositionTimePlanResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, value, basis, descr)
        {
        }
    }

    // PositionTimeWork		POSITION_TIME_WORK
    class PositionTimeWorkResult : PayrolexTermResult
    {
        public PositionTimeWorkResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, value, basis, descr)
        {
        }
    }

    // PositionTimeAbsc		POSITION_TIME_ABSC
    class PositionTimeAbscResult : PayrolexTermResult
    {
        public PositionTimeAbscResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, value, basis, descr)
        {
        }
    }

    // ContractTimePlan		CONTRACT_TIME_PLAN
    class ContractTimePlanResult : PayrolexTermResult
    {
        public ContractTimePlanResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, value, basis, descr)
        {
        }
    }

    // ContractTimeWork		CONTRACT_TIME_WORK
    class ContractTimeWorkResult : PayrolexTermResult
    {
        public ContractTimeWorkResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, value, basis, descr)
        {
        }
    }

    // ContractTimeAbsc		CONTRACT_TIME_ABSC
    class ContractTimeAbscResult : PayrolexTermResult
    {
        public ContractTimeAbscResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, value, basis, descr)
        {
        }
    }

    // PaymentBasis		PAYMENT_BASIS
    class PaymentBasisResult : PayrolexTermResult
    {
        public PaymentBasisResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, value, basis, descr)
        {
        }
    }

    // PaymentFixed		PAYMENT_FIXED
    class PaymentFixedResult : PayrolexTermResult
    {
        public PaymentFixedResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, value, basis, descr)
        {
        }
    }

    // IncomeGross		INCOME_GROSS
    class IncomeGrossResult : PayrolexTermResult
    {
        public IncomeGrossResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, value, basis, descr)
        {
        }
    }

    // IncomeNetto		INCOME_NETTO
    class IncomeNettoResult : PayrolexTermResult
    {
        public IncomeNettoResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, value, basis, descr)
        {
        }
    }

}
