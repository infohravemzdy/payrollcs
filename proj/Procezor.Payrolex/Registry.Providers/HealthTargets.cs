using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Types;

namespace Procezor.Payrolex.Registry.Providers
{
    // HealthDeclare		HEALTH_DECLARE
    public class HealthDeclareTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public HealthDeclareTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // HealthIncome		HEALTH_INCOME
    public class HealthIncomeTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public HealthIncomeTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // HealthBase		HEALTH_BASE
    public class HealthBaseTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public HealthBaseTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // HealthBaseEmployee		HEALTH_BASE_EMPLOYEE
    public class HealthBaseEmployeeTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public HealthBaseEmployeeTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // HealthBaseEmployer		HEALTH_BASE_EMPLOYER
    public class HealthBaseEmployerTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public HealthBaseEmployerTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // HealthBaseMandate		HEALTH_BASE_MANDATE
    public class HealthBaseMandateTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public HealthBaseMandateTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // HealthPaymEmployee		HEALTH_PAYM_EMPLOYEE
    public class HealthPaymEmployeeTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public HealthPaymEmployeeTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // HealthPaymEmployer		HEALTH_PAYM_EMPLOYER
    public class HealthPaymEmployerTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public HealthPaymEmployerTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

}
