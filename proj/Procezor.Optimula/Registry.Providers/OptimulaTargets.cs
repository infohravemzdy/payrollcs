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
        public Int32 TargetVals { get; private set; }

        public TimesheetsPlanTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // TimesheetsWork		TIMESHEETS_WORK
    public class TimesheetsWorkTarget : OptimulaTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TimesheetsWorkTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // TimeactualWork		TIMEACTUAL_WORK
    public class TimeactualWorkTarget : OptimulaTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TimeactualWorkTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // PaymentBasis		PAYMENT_BASIS
    public class PaymentBasisTarget : OptimulaTermTarget
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

    // OptimusBasis		OPTIMUS_BASIS
    public class OptimusBasisTarget : OptimulaTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public OptimusBasisTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // OptimusFixed		OPTIMUS_FIXED
    public class OptimusFixedTarget : OptimulaTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public OptimusFixedTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // AgrworkHours		AGRWORK_HOURS
    public class AgrworkHoursTarget : OptimulaTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public AgrworkHoursTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // AllowceHours		ALLOWCE_HOURS
    public class AllowceHoursTarget : OptimulaTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public AllowceHoursTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

}
