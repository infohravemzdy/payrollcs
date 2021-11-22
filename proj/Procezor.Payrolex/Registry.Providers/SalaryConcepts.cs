using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using Procezor.Payrolex.Registry.Constants;
using Procezor.Payrolex.Registry.Operations;
using ResultMonad;

namespace Procezor.Payrolex.Registry.Providers
{
    // PaymentBasis			PAYMENT_BASIS
    class PaymentBasisConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_BASIS;
        public PaymentBasisConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentBasisConSpec(this.Code.Value);
        }
    }

    class PaymentBasisConSpec : PayrolexConceptSpec
    {
        public PaymentBasisConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_PLAN,
                (Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new PaymentBasisTarget(month, con, pos, var, article, this.Code, 0);
        }
        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<PaymentBasisTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            PaymentBasisTarget evalTarget = resTarget.Value;

            var resWorkPlan = GetPositionResult<PositionWorkPlanResult>(target, period, results,
               target.Contract, target.Position, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_POSITION_WORK_PLAN));

            var resTimePlan = GetPositionResult<PositionTimePlanResult>(target, period, results,
               target.Contract, target.Position, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_PLAN));

            var resTimeWork = GetPositionResult<PositionTimeWorkResult>(target, period, results,
               target.Contract, target.Position, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_WORK));

            var resCompound = GetFailedOrOk(resWorkPlan.ErrOrOk(), resTimePlan.ErrOrOk(), resTimeWork.ErrOrOk());
            if (resCompound.IsFailure)
            {
                return BuildFailResults(resCompound.Error);
            }

            var evalWorkPlan = resWorkPlan.Value;

            var evalTimePlan = resTimePlan.Value;

            var evalTimeWork = resTimeWork.Value;

            Int32 shiftLiable = OperationsPeriod.TotalWeeksHours(evalWorkPlan.HoursFullWeeks);
            Int32 shiftWorked = OperationsPeriod.TotalWeeksHours(evalWorkPlan.HoursRealWeeks);
            Int32 hoursLiable = OperationsPeriod.TotalMonthHours(evalTimePlan.HoursRealMonth);
            Int32 hoursWorked = OperationsPeriod.TotalMonthHours(evalTimeWork.HoursTermMonth);

            Decimal resValue = OperationsPeriod.SalaryAmountScheduleWork(evalTarget.TargetBasis, 
                shiftLiable, shiftWorked,
                hoursLiable, hoursWorked);
            ITermResult resultsValues = new PaymentBasisResult(target, spec,
                RoundingInt.RoundUp(resValue), evalTarget.TargetBasis, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


    // PaymentFixed			PAYMENT_FIXED
    class PaymentFixedConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_FIXED;
        public PaymentFixedConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentFixedConSpec(this.Code.Value);
        }
    }

    class PaymentFixedConSpec : PayrolexConceptSpec
    {
        public PaymentFixedConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new PaymentFixedTarget(month, con, pos, var, article, this.Code, 0);
        }
        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<PaymentFixedTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            PaymentFixedTarget evalTarget = resTarget.Value;

            Decimal resValue = OperationsPeriod.SalaryAmountFixedValue(evalTarget.TargetBasis);

            ITermResult resultsValues = new PaymentFixedResult(target, spec,
                RoundingInt.RoundUp(resValue), evalTarget.TargetBasis, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }
}
