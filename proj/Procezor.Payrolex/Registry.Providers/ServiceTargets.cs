using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using Procezor.Payrolex.Registry.Constants;

namespace Procezor.Payrolex.Registry.Providers
{
    // ContractTerm		CONTRACT_TERM
    public class ContractWorkTermTarget : PayrolexTermTarget
    {
        public WorkContractTerms TermType { get; private set; }
        public DateTime? DateFrom { get; private set; }
        public DateTime? DateStop { get; private set; }

        public ContractWorkTermTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            WorkContractTerms termType, DateTime? dateFrom, DateTime? dateStop) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TermType = termType;
            DateFrom = dateFrom;
            DateStop = dateStop;
        }
    }

    // PositionTerm		POSITION_TERM
    public class PositionWorkTermTarget : PayrolexTermTarget
    {
        public DateTime? DateFrom { get; private set; }
        public DateTime? DateStop { get; private set; }
        public string TermName { get; private set; }
        public PositionWorkTermTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            string termName, DateTime? dateFrom, DateTime? dateStop) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TermName = termName;
            DateFrom = dateFrom;
            DateStop = dateStop;
        }
    }

    // PositionWorkPlan		POSITION_WORK_PLAN
    public class PositionWorkPlanTarget : PayrolexTermTarget
    {
        public WorkScheduleType WorkType { get; private set; }
        public Int32 WeekShiftPlaned { get; set; }
        public Int32 WeekShiftLiable { get; set; }
        public Int32 WeekShiftActual { get; set; }

        public PositionWorkPlanTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            WorkScheduleType workType, Int32 shiftPlaned, Int32 shiftLiable, Int32 shiftActual) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            WorkType = workType;
            WeekShiftPlaned = shiftPlaned;
            WeekShiftLiable = shiftLiable;
            WeekShiftActual = shiftActual;
        }
    }

    // PositionTimePlan		POSITION_TIME_PLAN
    public class PositionTimePlanTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public PositionTimePlanTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // PositionTimeWork		POSITION_TIME_WORK
    public class PositionTimeWorkTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public PositionTimeWorkTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // PositionTimeAbsc		POSITION_TIME_ABSC
    public class PositionTimeAbscTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public PositionTimeAbscTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // ContractTimePlan		CONTRACT_TIME_PLAN
    public class ContractTimePlanTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public ContractTimePlanTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // ContractTimeWork		CONTRACT_TIME_WORK
    public class ContractTimeWorkTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public ContractTimeWorkTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // ContractTimeAbsc		CONTRACT_TIME_ABSC
    public class ContractTimeAbscTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public ContractTimeAbscTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // PaymentBasis		PAYMENT_BASIS
    public class PaymentBasisTarget : PayrolexTermTarget
    {
        public PaymentBasisTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 monthBasis) :
            base(monthCode, contract, position, variant, article, concept, monthBasis, DESCRIPTION_EMPTY)
        {
        }
    }

    // PaymentFixed		PAYMENT_FIXED
    public class PaymentFixedTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public PaymentFixedTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // IncomeGross		INCOME_GROSS
    public class IncomeGrossTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public IncomeGrossTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // IncomeNetto		INCOME_NETTO
    public class IncomeNettoTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public IncomeNettoTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

}
