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
    // EmployerCosts		EMPLOYER_COSTS
    public class EmployerCostsTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public EmployerCostsTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }
}
