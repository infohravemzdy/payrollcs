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
    // ContractTerm			CONTRACT_TERM
    class ContractTermConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ServiceConceptConst.CONCEPT_CONTRACT_TERM;
        public ContractTermConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new ContractTermConSpec(this.Code.Value);
        }
    }

    class ContractTermConSpec : PayrolexConceptSpec
    {
        public ContractTermConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ContractTermTarget evalTarget = target as ContractTermTarget;

            if (evalTarget == null)
            {
                var resultError = InvalidTargetError.CreateError(period, target);
                return BuildFailResults(resultError);
            }

            Byte termDayFrom = OperationsPeriod.DateFromInPeriod(period, evalTarget.DateFrom);
            Byte termDayStop = OperationsPeriod.DateStopInPeriod(period, evalTarget.DateStop);

            ITermResult resultsValues = new ContractTermResult(target, evalTarget.TermType, termDayFrom, termDayStop);

            return BuildOkResults(resultsValues);
        }
    }


    // PositionTerm			POSITION_TERM
    class PositionTermConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ServiceConceptConst.CONCEPT_POSITION_TERM;
        public PositionTermConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PositionTermConSpec(this.Code.Value);
        }
    }

    class PositionTermConSpec : PayrolexConceptSpec
    {
        public PositionTermConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)ServiceArticleConst.ARTICLE_CONTRACT_TERM,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            PositionTermTarget evalTarget = target as PositionTermTarget;

            if (evalTarget == null)
            {
                var resultError = InvalidTargetError.CreateError(period, target);
                return BuildFailResults(resultError);
            }

            var resContract = GetContractResult<ContractTermResult>(target, period, results, 
                target.Contract, ArticleCode.Get((Int32)ServiceArticleConst.ARTICLE_CONTRACT_TERM));

            if (resContract.IsFailure)
            {
                return BuildFailResults(resContract.Error);
            }

            var evalContract = resContract.Value;

            Byte termDayFrom = OperationsPeriod.DateFromInPeriod(period, evalTarget.DateFrom);
            if (termDayFrom < evalContract.TermDayFrom)
            {
                termDayFrom = evalContract.TermDayFrom;
            }
            Byte termDayStop = OperationsPeriod.DateStopInPeriod(period, evalTarget.DateStop);
            if (termDayStop > evalContract.TermDayStop)
            {
                termDayStop = evalContract.TermDayStop;
            }
            ITermResult resultsValues = new PositionTermResult(target, evalTarget.TermName, termDayFrom, termDayStop);

            return BuildOkResults(resultsValues);
        }
    }


    // PositionWorkPlan			POSITION_WORK_PLAN
    class PositionWorkPlanConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ServiceConceptConst.CONCEPT_POSITION_WORK_PLAN;
        public PositionWorkPlanConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PositionWorkPlanConSpec(this.Code.Value);
        }
    }

    class PositionWorkPlanConSpec : PayrolexConceptSpec
    {
        public PositionWorkPlanConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)ServiceArticleConst.ARTICLE_POSITION_TERM,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new PositionWorkPlanResult(target, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


    // PositionTimePlan			POSITION_TIME_PLAN
    class PositionTimePlanConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ServiceConceptConst.CONCEPT_POSITION_TIME_PLAN;
        public PositionTimePlanConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PositionTimePlanConSpec(this.Code.Value);
        }
    }

    class PositionTimePlanConSpec : PayrolexConceptSpec
    {
        public PositionTimePlanConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)ServiceArticleConst.ARTICLE_POSITION_WORK_PLAN,
                (Int32)ServiceArticleConst.ARTICLE_POSITION_TERM,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new PositionTimePlanResult(target, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


    // PositionTimeWork			POSITION_TIME_WORK
    class PositionTimeWorkConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ServiceConceptConst.CONCEPT_POSITION_TIME_WORK;
        public PositionTimeWorkConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PositionTimeWorkConSpec(this.Code.Value);
        }
    }

    class PositionTimeWorkConSpec : PayrolexConceptSpec
    {
        public PositionTimeWorkConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)ServiceArticleConst.ARTICLE_POSITION_TIME_PLAN,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new PositionTimeWorkResult(target, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


    // PositionTimeAbsc			POSITION_TIME_ABSC
    class PositionTimeAbscConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ServiceConceptConst.CONCEPT_POSITION_TIME_ABSC;
        public PositionTimeAbscConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PositionTimeAbscConSpec(this.Code.Value);
        }
    }

    class PositionTimeAbscConSpec : PayrolexConceptSpec
    {
        public PositionTimeAbscConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)ServiceArticleConst.ARTICLE_POSITION_TIME_PLAN,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new PositionTimeAbscResult(target, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


    // ContractTimePlan			CONTRACT_TIME_PLAN
    class ContractTimePlanConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ServiceConceptConst.CONCEPT_CONTRACT_TIME_PLAN;
        public ContractTimePlanConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new ContractTimePlanConSpec(this.Code.Value);
        }
    }

    class ContractTimePlanConSpec : PayrolexConceptSpec
    {
        public ContractTimePlanConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)ServiceArticleConst.ARTICLE_POSITION_TERM,
                (Int32)ServiceArticleConst.ARTICLE_POSITION_TIME_PLAN,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new ContractTimePlanResult(target, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


    // ContractTimeWork			CONTRACT_TIME_WORK
    class ContractTimeWorkConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ServiceConceptConst.CONCEPT_CONTRACT_TIME_WORK;
        public ContractTimeWorkConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new ContractTimeWorkConSpec(this.Code.Value);
        }
    }

    class ContractTimeWorkConSpec : PayrolexConceptSpec
    {
        public ContractTimeWorkConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)ServiceArticleConst.ARTICLE_POSITION_TERM,
                (Int32)ServiceArticleConst.ARTICLE_POSITION_TIME_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new ContractTimeWorkResult(target, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


    // ContractTimeAbsc			CONTRACT_TIME_ABSC
    class ContractTimeAbscConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ServiceConceptConst.CONCEPT_CONTRACT_TIME_ABSC;
        public ContractTimeAbscConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new ContractTimeAbscConSpec(this.Code.Value);
        }
    }

    class ContractTimeAbscConSpec : PayrolexConceptSpec
    {
        public ContractTimeAbscConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)ServiceArticleConst.ARTICLE_POSITION_TERM,
                (Int32)ServiceArticleConst.ARTICLE_POSITION_TIME_ABSC,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new ContractTimeAbscResult(target, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


    // PaymentBasis			PAYMENT_BASIS
    class PaymentBasisConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ServiceConceptConst.CONCEPT_PAYMENT_BASIS;
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
                (Int32)ServiceArticleConst.ARTICLE_POSITION_TIME_PLAN,
                (Int32)ServiceArticleConst.ARTICLE_POSITION_TIME_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new PaymentBasisResult(target, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


    // PaymentFixed			PAYMENT_FIXED
    class PaymentFixedConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ServiceConceptConst.CONCEPT_PAYMENT_FIXED;
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

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new PaymentFixedResult(target, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


    // IncomeGross			INCOME_GROSS
    class IncomeGrossConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ServiceConceptConst.CONCEPT_INCOME_GROSS;
        public IncomeGrossConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomeGrossConSpec(this.Code.Value);
        }
    }

    class IncomeGrossConSpec : PayrolexConceptSpec
    {
        public IncomeGrossConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new IncomeGrossResult(target, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


    // IncomeNetto			INCOME_NETTO
    class IncomeNettoConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ServiceConceptConst.CONCEPT_INCOME_NETTO;
        public IncomeNettoConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomeNettoConSpec(this.Code.Value);
        }
    }

    class IncomeNettoConSpec : PayrolexConceptSpec
    {
        public IncomeNettoConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)ServiceArticleConst.ARTICLE_INCOME_GROSS,
            });

            ResultDelegate = ConceptEval;
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            ITermResult resultsValues = new IncomeNettoResult(target, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }
}
