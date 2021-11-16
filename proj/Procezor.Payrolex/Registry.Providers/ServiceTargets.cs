using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Types;
using Procezor.Payrolex.Registry.Constants;

namespace Procezor.Payrolex.Registry.Providers
{
    // ContractTerm		CONTRACT_TERM
    class ContractTermTarget : PayrolexTermTarget
    {
        public WorkContractTerms TermType { get; private set; }
        public DateTime? DateFrom { get; private set; }
        public DateTime? DateStop { get; private set; }

        public ContractTermTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
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
    class PositionTermTarget : PayrolexTermTarget
    {
        public DateTime? DateFrom { get; private set; }
        public DateTime? DateStop { get; private set; }
        public string TermName { get; private set; }
        public PositionTermTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
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
    class PositionWorkPlanTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public PositionWorkPlanTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // PositionTimePlan		POSITION_TIME_PLAN
    class PositionTimePlanTarget : PayrolexTermTarget
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
    class PositionTimeWorkTarget : PayrolexTermTarget
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
    class PositionTimeAbscTarget : PayrolexTermTarget
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
    class ContractTimePlanTarget : PayrolexTermTarget
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
    class ContractTimeWorkTarget : PayrolexTermTarget
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
    class ContractTimeAbscTarget : PayrolexTermTarget
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
    class PaymentBasisTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public PaymentBasisTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // PaymentFixed		PAYMENT_FIXED
    class PaymentFixedTarget : PayrolexTermTarget
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
    class IncomeGrossTarget : PayrolexTermTarget
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
    class IncomeNettoTarget : PayrolexTermTarget
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
