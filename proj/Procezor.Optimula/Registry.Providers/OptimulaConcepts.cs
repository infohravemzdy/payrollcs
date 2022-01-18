using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Procezor.Optimula.Registry.Constants;
using MaybeMonad;
using ResultMonad;
using HraveMzdy.Legalios.Service.Types;
using HraveMzdy.Procezor.Optimula.Service;

namespace HraveMzdy.Procezor.Optimula.Registry.Providers
{
    // TimesheetsPlan   TIMESHEETS_PLAN
    class TimesheetsPlanConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_TIMESHEETS_PLAN;
        public TimesheetsPlanConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TimesheetsPlanConSpec(this.Code.Value);
        }
    }

    class TimesheetsPlanConSpec : OptimulaConceptSpec
    {
        public TimesheetsPlanConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new TimesheetsPlanTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<TimesheetsPlanTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TimesheetsPlanTarget evalTarget = resTarget.Value;

            decimal fullSheetHrsVal = OperationsDec.Divide(evalTarget.FullSheetHrsVal, 60);

            ITermResult resultsValues = new TimesheetsPlanResult(target, spec, 
                fullSheetHrsVal, 
                0, 0);

            return BuildOkResults(resultsValues);
        }
    }

    // TimesheetsWork   TIMESHEETS_WORK
    class TimesheetsWorkConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_TIMESHEETS_WORK;
        public TimesheetsWorkConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TimesheetsWorkConSpec(this.Code.Value);
        }
    }

    class TimesheetsWorkConSpec : OptimulaConceptSpec
    {
        public TimesheetsWorkConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_PLAN,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new TimesheetsWorkTarget(month, con, pos, var, article, this.Code, 0, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<TimesheetsWorkTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TimesheetsWorkTarget evalTarget = resTarget.Value;

            decimal timeSheetHrsVal = OperationsDec.Divide(evalTarget.TimeSheetHrsVal, 60);
            decimal holiSheetHrsVal = OperationsDec.Divide(evalTarget.HoliSheetHrsVal, 60);

            var resTimePlan = GetContractResult<TimesheetsPlanResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_PLAN));

            if (resTimePlan.IsFailure)
            {
                return BuildFailResults(resTimePlan.Error);
            }

            var evalTimePlan = resTimePlan.Value;

            decimal hoursWorkPlan = evalTimePlan.FullSheetHrsVal;

            decimal hoursWorkCoef = salaryRules.CoeffWithPartAndFullHours(timeSheetHrsVal, hoursWorkPlan);

            ITermResult resultsValues = new TimesheetsWorkResult(target, spec,
                timeSheetHrsVal, holiSheetHrsVal, hoursWorkCoef,
                0, 0);

            return BuildOkResults(resultsValues);
        }
    }

    // TimeactualWork	TIMEACTUAL_WORK
    class TimeactualWorkConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_TIMEACTUAL_WORK;
        public TimeactualWorkConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TimeactualWorkConSpec(this.Code.Value);
        }
    }

    class TimeactualWorkConSpec : OptimulaConceptSpec
    {
        public TimeactualWorkConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new TimeactualWorkTarget(month, con, pos, var, article, this.Code, 0, 0, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<TimeactualWorkTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TimeactualWorkTarget evalTarget = resTarget.Value;

            decimal workSheetHrsVal = OperationsDec.Divide(evalTarget.WorkSheetHrsVal, 60);
            decimal workSheetDayVal = OperationsDec.Divide(evalTarget.WorkSheetDayVal, 100); 
            decimal overSheetHrsVal = OperationsDec.Divide(evalTarget.OverSheetHrsVal, 60);

            var resTimeWork = GetContractResult<TimesheetsWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_WORK));

            if (resTimeWork.IsFailure)
            {
                return BuildFailResults(resTimeWork.Error);
            }

            var evalTimeWork = resTimeWork.Value;

            decimal hoursTimeWork = evalTimeWork.TimeSheetHrsVal;

            decimal hoursWorkCoef = salaryRules.CoeffWithPartAndFullHours(hoursTimeWork, workSheetHrsVal);

            ITermResult resultsValues = new TimeactualWorkResult(target, spec,
                workSheetHrsVal, workSheetDayVal, overSheetHrsVal, hoursWorkCoef,
                0, 0);

            return BuildOkResults(resultsValues);
        }
    }

    // PaymentBasis		PAYMENT_BASIS
    class PaymentBasisConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_PAYMENT_BASIS;
        public PaymentBasisConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentBasisConSpec(this.Code.Value);
        }
    }

    class PaymentBasisConSpec : OptimulaConceptSpec
    {
        public PaymentBasisConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_WORK,
                (Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new PaymentBasisTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<PaymentBasisTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            PaymentBasisTarget evalTarget = resTarget.Value;

            decimal paymentBasisVal = OperationsDec.Divide(evalTarget.PaymentBasisVal, 100);

            var resTimeWork = GetContractResult<TimesheetsWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_WORK));

            if (resTimeWork.IsFailure)
            {
                return BuildFailResults(resTimeWork.Error);
            }

            var evalTimeWork = resTimeWork.Value;

            decimal hoursTimeCoef = evalTimeWork.WorkLoadHrsCoef;

            var resTimeActa = GetContractResult<TimeactualWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK));

            if (resTimeActa.IsFailure)
            {
                return BuildFailResults(resTimeActa.Error);
            }

            var evalTimeActa = resTimeActa.Value;

            decimal hoursWorkCoef = evalTimeActa.WorkTimeHrsCoef;

            decimal paymentValueRes = salaryRules.RelativePaymentWithMonthlyAndCoeffAndWorkCoeff(
                paymentBasisVal, hoursTimeCoef, hoursWorkCoef);

            ITermResult resultsValues = new PaymentBasisResult(target, spec,
                paymentBasisVal, 
                RoundToInt(paymentValueRes), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // PaymentFixed		PAYMENT_FIXED
    class PaymentFixedConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_PAYMENT_FIXED;
        public PaymentFixedConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentFixedConSpec(this.Code.Value);
        }
    }

    class PaymentFixedConSpec : OptimulaConceptSpec
    {
        public PaymentFixedConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new PaymentFixedTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<PaymentFixedTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            PaymentFixedTarget evalTarget = resTarget.Value;

            decimal paymentBasisVal = OperationsDec.Divide(evalTarget.PaymentBasisVal, 100);

            decimal paymentValueRes = salaryRules.PaymentWithAmountFixed(paymentBasisVal);

            ITermResult resultsValues = new PaymentFixedResult(target, spec,
                paymentBasisVal,
                RoundToInt(paymentValueRes), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // PaymentHours		PAYMENT_HOURS
    class PaymentHoursConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_PAYMENT_HOURS;
        public PaymentHoursConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentHoursConSpec(this.Code.Value);
        }
    }

    class PaymentHoursConSpec : OptimulaConceptSpec
    {
        public PaymentHoursConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new PaymentHoursTarget(month, con, pos, var, article, this.Code, 0, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<PaymentHoursTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            PaymentHoursTarget evalTarget = resTarget.Value;

            decimal paymentBasisVal = OperationsDec.Divide(evalTarget.PaymentBasisVal, 100);
            decimal paymentHoursVal = OperationsDec.Divide(evalTarget.PaymentHoursVal, 60);

            decimal paymentValueRes = salaryRules.PaymentWithTariffAndHours(paymentBasisVal, paymentHoursVal);

            ITermResult resultsValues = new PaymentHoursResult(target, spec,
                paymentBasisVal, paymentHoursVal, 
                RoundToInt(paymentValueRes), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // OptimusBasis		OPTIMUS_BASIS
    class OptimusBasisConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_BASIS;
        public OptimusBasisConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new OptimusBasisConSpec(this.Code.Value);
        }
    }

    class OptimusBasisConSpec : OptimulaConceptSpec
    {
        public OptimusBasisConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_WORK,
                (Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new OptimusBasisTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<OptimusBasisTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            OptimusBasisTarget evalTarget = resTarget.Value;

            decimal paymentBasisVal = OperationsDec.Divide(evalTarget.OptimusBasisVal, 100);

            var resTimeWork = GetContractResult<TimesheetsWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_WORK));

            if (resTimeWork.IsFailure)
            {
                return BuildFailResults(resTimeWork.Error);
            }

            var evalTimeWork = resTimeWork.Value;

            decimal hoursTimeCoef = evalTimeWork.WorkLoadHrsCoef;

            var resTimeActa = GetContractResult<TimeactualWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK));

            if (resTimeActa.IsFailure)
            {
                return BuildFailResults(resTimeActa.Error);
            }

            var evalTimeActa = resTimeActa.Value;

            decimal hoursWorkCoef = evalTimeActa.WorkTimeHrsCoef;

            decimal paymentValueRes = salaryRules.RelativePaymentWithMonthlyAndCoeffAndWorkCoeff(
                paymentBasisVal, hoursTimeCoef, hoursWorkCoef);

            ITermResult resultsValues = new OptimusBasisResult(target, spec,
                paymentBasisVal,
                RoundToInt(paymentValueRes), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // OptimusFixed		OPTIMUS_FIXED
    class OptimusFixedConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED;
        public OptimusFixedConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new OptimusFixedConSpec(this.Code.Value);
        }
    }

    class OptimusFixedConSpec : OptimulaConceptSpec
    {
        public OptimusFixedConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new OptimusFixedTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<OptimusFixedTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            OptimusFixedTarget evalTarget = resTarget.Value;

            decimal paymentBasisVal = OperationsDec.Divide(evalTarget.OptimusBasisVal, 100);

            decimal paymentValueRes = salaryRules.PaymentWithAmountFixed(paymentBasisVal);

            ITermResult resultsValues = new OptimusFixedResult(target, spec,
                paymentBasisVal,
                RoundToInt(paymentValueRes), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // OptimusHours		OPTIMUS_HOURS
    class OptimusHoursConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_HOURS;
        public OptimusHoursConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new OptimusHoursConSpec(this.Code.Value);
        }
    }

    class OptimusHoursConSpec : OptimulaConceptSpec
    {
        public OptimusHoursConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new OptimusHoursTarget(month, con, pos, var, article, this.Code, 0, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<OptimusHoursTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            OptimusHoursTarget evalTarget = resTarget.Value;

            decimal paymentBasisVal = OperationsDec.Divide(evalTarget.OptimusBasisVal, 100);
            decimal paymentHoursVal = OperationsDec.Divide(evalTarget.OptimusHoursVal, 60);

            decimal paymentValueRes = salaryRules.PaymentWithTariffAndHours(paymentBasisVal, paymentHoursVal);

            ITermResult resultsValues = new OptimusHoursResult(target, spec,
                paymentBasisVal, paymentHoursVal,
                RoundToInt(paymentValueRes), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // ReducedBasis		REDUCED_BASIS
    class ReducedBasisConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_REDUCED_BASIS;
        public ReducedBasisConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new ReducedBasisConSpec(this.Code.Value);
        }
    }

    class ReducedBasisConSpec : OptimulaConceptSpec
    {
        public ReducedBasisConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_AGRWORK,
                (Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new ReducedBasisTarget(month, con, pos, var, article, this.Code, ArticleCode.Zero),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<ReducedBasisTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            ReducedBasisTarget evalTarget = resTarget.Value;

            var resTimeWork = GetContractResult<TimesheetsWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_WORK));

            if (resTimeWork.IsFailure)
            {
                return BuildFailResults(resTimeWork.Error);
            }

            var evalTimeWork = resTimeWork.Value;

            decimal hoursTimeCoef = evalTimeWork.WorkLoadHrsCoef;

            var resTimeActa = GetContractResult<TimeactualWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK));

            if (resTimeActa.IsFailure)
            {
                return BuildFailResults(resTimeActa.Error);
            }

            var evalTimeActa = resTimeActa.Value;

            decimal hoursWorkCoef = evalTimeActa.WorkTimeHrsCoef;

            var resOptimusTargets = GetContractResult<OptimusBasisResult>(target, period, results,
               target.Contract, evalTarget.ArticleTarget);

            if (resOptimusTargets.IsFailure)
            {
                return BuildFailResults(resOptimusTargets.Error);
            }

            var evalOptimusTargets = resOptimusTargets.Value;

            var resSettlemAllowce = GetContractResult<SettlemAllowceResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE));

            if (resSettlemAllowce.IsFailure)
            {
                return BuildFailResults(resSettlemAllowce.Error);
            }

            var evalSettlemAllowce = resSettlemAllowce.Value;

            decimal settlemAllowceVal = evalSettlemAllowce.ResultValue;
            decimal optimusTargetsVal = evalOptimusTargets.ResultValue;

            var resSettlemAgrWork = GetContractResult<SettlemAgrWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_AGRWORK));

            if (resSettlemAgrWork.IsFailure)
            {
                return BuildFailResults(resSettlemAgrWork.Error);
            }

            var evalSettlemAgrWork = resSettlemAgrWork.Value;

            decimal settlemAgrWorkVal = evalSettlemAgrWork.ResultValue;

            var settlemResultsList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS))))
                .Select((v) => (v as OptimulaTermResult))
                .Select((tr) => (tr.ResultValue, tr.ResultBasis)).ToArray();

            decimal settlemResultsValue = settlemResultsList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item.ResultValue));
            decimal settlemResultsBasis = settlemResultsList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item.ResultBasis));

            decimal settlemDiffsVal = (optimusTargetsVal + settlemResultsBasis - settlemAllowceVal - settlemAgrWorkVal);

            decimal reducedBasisVal = salaryRules.ReverzedPaymentWithMonthlyAndCoeffAndWorkCoeff(Math.Max(0, settlemDiffsVal), 
                hoursTimeCoef, hoursWorkCoef);
            decimal reducedResValue = Math.Max(0, settlemDiffsVal);
            decimal reducedResBasis = Math.Max(0, optimusTargetsVal - reducedBasisVal);

            ITermResult resultsValues = new ReducedBasisResult(target, spec,
                reducedBasisVal,
                RoundToInt(reducedResValue), RoundToInt(reducedResBasis));

            return BuildOkResults(resultsValues);
        }
    }

    // ReducedFixed		REDUCED_FIXED
    class ReducedFixedConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_REDUCED_FIXED;
        public ReducedFixedConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new ReducedFixedConSpec(this.Code.Value);
        }
    }

    class ReducedFixedConSpec : OptimulaConceptSpec
    {
        public ReducedFixedConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_AGRWORK,
                (Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new ReducedFixedTarget(month, con, pos, var, article, this.Code, ArticleCode.Zero),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<ReducedFixedTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            ReducedFixedTarget evalTarget = resTarget.Value;

            var resOptimusTargets = GetContractResult<OptimusFixedResult>(target, period, results,
               target.Contract, evalTarget.ArticleTarget);

            if (resOptimusTargets.IsFailure)
            {
                return BuildFailResults(resOptimusTargets.Error);
            }

            var evalOptimusTargets = resOptimusTargets.Value;

            var resSettlemAllowce = GetContractResult<SettlemAllowceResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE));

            if (resSettlemAllowce.IsFailure)
            {
                return BuildFailResults(resSettlemAllowce.Error);
            }

            var evalSettlemAllowce = resSettlemAllowce.Value;

            decimal settlemAllowceVal = evalSettlemAllowce.ResultValue;
            decimal optimusTargetsVal = evalOptimusTargets.ResultValue;

            var resSettlemAgrWork = GetContractResult<SettlemAgrWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_AGRWORK));

            if (resSettlemAgrWork.IsFailure)
            {
                return BuildFailResults(resSettlemAgrWork.Error);
            }

            var evalSettlemAgrWork = resSettlemAgrWork.Value;

            decimal settlemAgrWorkVal = evalSettlemAgrWork.ResultValue;

            var settlemResultsList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS))))
                .Select((v) => (v as OptimulaTermResult))
                .Select((tr) => (tr.ResultValue, tr.ResultBasis)).ToArray();

            decimal settlemResultsValue = settlemResultsList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item.ResultValue));
            decimal settlemResultsBasis = settlemResultsList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item.ResultBasis));

            decimal settlemDiffsVal = (optimusTargetsVal + settlemResultsBasis - settlemAllowceVal - settlemAgrWorkVal);

            decimal reducedBasisVal = Math.Max(0, settlemDiffsVal);
            decimal reducedResValue = Math.Max(0, settlemDiffsVal);
            decimal reducedResBasis = Math.Max(0, optimusTargetsVal - reducedBasisVal);

            ITermResult resultsValues = new ReducedFixedResult(target, spec,
                reducedBasisVal,
                RoundToInt(reducedResValue), RoundToInt(reducedResBasis));

            return BuildOkResults(resultsValues);
        }
    }

    // ReducedHours		REDUCED_HOURS
    class ReducedHoursConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_REDUCED_HOURS;
        public ReducedHoursConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new ReducedHoursConSpec(this.Code.Value);
        }
    }

    class ReducedHoursConSpec : OptimulaConceptSpec
    {
        public ReducedHoursConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_AGRWORK,
                (Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new ReducedHoursTarget(month, con, pos, var, article, this.Code, ArticleCode.Zero),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<ReducedHoursTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            ReducedHoursTarget evalTarget = resTarget.Value;

            var resOptimusTargets = GetContractResult<OptimusHoursResult>(target, period, results,
               target.Contract, evalTarget.ArticleTarget);

            if (resOptimusTargets.IsFailure)
            {
                return BuildFailResults(resOptimusTargets.Error);
            }

            var evalOptimusTargets = resOptimusTargets.Value;

            var resSettlemAllowce = GetContractResult<SettlemAllowceResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE));

            if (resSettlemAllowce.IsFailure)
            {
                return BuildFailResults(resSettlemAllowce.Error);
            }

            var evalSettlemAllowce = resSettlemAllowce.Value;

            decimal settlemAllowceVal = evalSettlemAllowce.ResultValue;
            decimal optimusTargetsVal = evalOptimusTargets.ResultValue;

            var resSettlemAgrWork = GetContractResult<SettlemAgrWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_AGRWORK));

            if (resSettlemAgrWork.IsFailure)
            {
                return BuildFailResults(resSettlemAgrWork.Error);
            }

            var evalSettlemAgrWork = resSettlemAgrWork.Value;

            decimal settlemAgrWorkVal = evalSettlemAgrWork.ResultValue;

            var settlemResultsList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS))))
                .Select((v) => (v as OptimulaTermResult))
                .Select((tr) => (tr.ResultValue, tr.ResultBasis)).ToArray();

            decimal settlemResultsValue = settlemResultsList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item.ResultValue));
            decimal settlemResultsBasis = settlemResultsList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item.ResultBasis));

            decimal settlemDiffsVal = (optimusTargetsVal + settlemResultsBasis - settlemAllowceVal - settlemAgrWorkVal);

            decimal reducedHoursVal = evalOptimusTargets.OptimusHoursVal;
            decimal reducedBasisVal = salaryRules.TariffWithPaymentAndHours(Math.Max(0, settlemDiffsVal), reducedHoursVal);
            decimal reducedResValue = Math.Max(0, settlemDiffsVal);
            decimal reducedResBasis = Math.Max(0, optimusTargetsVal - reducedBasisVal);

            ITermResult resultsValues = new ReducedHoursResult(target, spec,
                reducedBasisVal, reducedHoursVal,
                RoundToInt(reducedResValue), RoundToInt(reducedResBasis));

            return BuildOkResults(resultsValues);
        }
    }

    // AgrworkHours		AGRWORK_HOURS
    class AgrworkHoursConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_AGRWORK_HOURS;
        public AgrworkHoursConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            if (version.Value == ServiceOptimula.TEST_VERSION_SCM)
            {
                return new AgrworkHoursConScmSpec(this.Code.Value);
            }
            return new AgrworkHoursConSpec(this.Code.Value);
        }
    }

    class AgrworkHoursConScmSpec : OptimulaConceptSpec
    {
        public AgrworkHoursConScmSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK,
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new AgrworkHoursTarget(month, con, pos, var, article, this.Code, 0, 0, 0, 0),
            };
        }
        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<AgrworkHoursTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            AgrworkHoursTarget evalTarget = resTarget.Value;

            var resSettlemTargets = GetContractResult<SettlemTargetsResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS));

            var resSettlemAllowce = GetContractResult<SettlemAllowceResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE));

            var resCompound = GetFailedOrOk(resSettlemTargets.ErrOrOk(), resSettlemAllowce.ErrOrOk());
            if (resCompound.IsFailure)
            {
                return BuildFailResults(resCompound.Error);
            }

            var evalSettlemTargets = resSettlemTargets.Value;
            var evalSettlemAllowce = resSettlemAllowce.Value;

            decimal redWorkTarifVal = OperationsDec.Divide(evalTarget.AgrWorkTarifVal, 100);
            decimal redWorkRatioVal = OperationsDec.Divide(evalTarget.AgrWorkRatioVal, 100);
            decimal redWorkLimitVal = OperationsDec.Divide(evalTarget.AgrWorkLimitVal, 100);
            decimal redHourLimitVal = OperationsDec.Divide(evalTarget.AgrHourLimitVal, 60);

            decimal paymentHoursRes = 0.0m;
            decimal paymentBasisRes = 0.0m;

            decimal paymentValueRes = 0.0m;

            Int32 settlemResultsDif = (evalSettlemTargets.ResultValue - evalSettlemAllowce.ResultValue);
            if (settlemResultsDif > 0)
            {
                paymentValueRes = settlemResultsDif;

                decimal agrCandidsHours = salaryRules.HoursToHalfHoursDown(OperationsDec.Divide(paymentValueRes, redWorkTarifVal));

                paymentHoursRes = Math.Max(0, agrCandidsHours);

                if (paymentHoursRes != 0.0m)
                {
                    decimal redCandidsValue = Math.Min(10000.0m, paymentValueRes);

                    decimal redCandidsHours = salaryRules.HoursToHalfHoursDown(OperationsDec.Divide(redCandidsValue, redWorkTarifVal));
                    decimal redCandidsBasis = salaryRules.MoneyToRoundDown(OperationsDec.Divide(redCandidsValue, redCandidsHours));

                    if (redCandidsHours > 25.0m)
                    {
                        redCandidsHours = 25.0m;
                        redCandidsBasis = salaryRules.MoneyToRoundDown(OperationsDec.Divide(redCandidsValue, redCandidsHours));
                    }
                    decimal minCandidsBasis = salaryRules.PaymentWithAmountFixed(OperationsDec.Divide(salaryRules.MinHourlyWage + 200, 100m));

                    if (redCandidsBasis < minCandidsBasis)
                    {
                        redCandidsBasis = minCandidsBasis;
                        redCandidsHours = salaryRules.HoursToHalfHoursDown(OperationsDec.Divide(redCandidsValue, redCandidsBasis));
                    }
                    paymentHoursRes = Math.Max(0, redCandidsHours);
                    paymentBasisRes = Math.Max(0, Math.Max(paymentBasisRes, redCandidsBasis));

                    paymentValueRes = redCandidsValue;
                }
            }

            ITermResult resultsValues = new AgrworkHoursResult(target, spec,
                redWorkTarifVal, redWorkRatioVal, redWorkLimitVal, redHourLimitVal,
                paymentHoursRes, paymentBasisRes,
                RoundToInt(paymentValueRes), 0);

            return BuildOkResults(resultsValues);
        }
    }

    class AgrworkHoursConSpec : OptimulaConceptSpec
    {
        public AgrworkHoursConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK,
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new AgrworkHoursTarget(month, con, pos, var, article, this.Code, 0, 0, 0, 0),
            };
        }
        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<AgrworkHoursTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            AgrworkHoursTarget evalTarget = resTarget.Value;

            decimal redWorkTarifVal = OperationsDec.Divide(evalTarget.AgrWorkTarifVal, 100);
            decimal redWorkRatioVal = OperationsDec.Divide(evalTarget.AgrWorkRatioVal, 100);
            decimal redWorkLimitVal = OperationsDec.Divide(evalTarget.AgrWorkLimitVal, 100);
            decimal redHourLimitVal = OperationsDec.Divide(evalTarget.AgrHourLimitVal, 60);

            var resTimeActa = GetContractResult<TimeactualWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK));

            if (resTimeActa.IsFailure)
            {
                return BuildFailResults(resTimeActa.Error);
            }

            var evalTimeActa = resTimeActa.Value;

            decimal hoursWorkActa = evalTimeActa.WorkSheetHrsVal;

            decimal paymentBasisRes = redWorkTarifVal;
            decimal paymentHoursRes = 0m;

            if (redHourLimitVal == 0m)
            {
                paymentHoursRes = salaryRules.HoursToHalfHoursNorm(OperationsDec.Multiply(hoursWorkActa, redWorkRatioVal));
            }
            else
            {
                decimal agrCandidsHours = 0m;
                agrCandidsHours = salaryRules.HoursToHalfHoursNorm(OperationsDec.Multiply(hoursWorkActa, redWorkRatioVal));
                if (redWorkRatioVal == 0m)
                {
                    paymentHoursRes = Math.Min(agrCandidsHours, salaryRules.HoursToHalfHoursNorm(redHourLimitVal));
                }
                else
                {
                    paymentHoursRes = salaryRules.HoursToHalfHoursNorm(redHourLimitVal);
                }
            }
            decimal paymentValueRes = salaryRules.PaymentWithTariffAndHours(paymentBasisRes, paymentHoursRes);

            var resSettlemTargets = GetContractResult<SettlemTargetsResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS));

            var resSettlemAllowce = GetContractResult<SettlemAllowceResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE));

            var resCompound = GetFailedOrOk(resSettlemTargets.ErrOrOk(), resSettlemAllowce.ErrOrOk());
            if (resCompound.IsFailure)
            {
                return BuildFailResults(resCompound.Error);
            }

            var evalSettlemTargets = resSettlemTargets.Value;
            var evalSettlemAllowce = resSettlemAllowce.Value;

            Int32 settlemResultsDif = (evalSettlemTargets.ResultValue - evalSettlemAllowce.ResultValue);
            if (settlemResultsDif < paymentValueRes)
            {
                decimal overcapValueRes = (paymentValueRes - settlemResultsDif);

                decimal agrCandidsHours = salaryRules.HoursToHalfHoursUp(OperationsDec.Divide(overcapValueRes, paymentBasisRes));

                paymentHoursRes = Math.Max(0, (paymentHoursRes - agrCandidsHours));

                paymentValueRes = salaryRules.PaymentWithTariffAndHours(paymentBasisRes, paymentHoursRes);
            }

            ITermResult resultsValues = new AgrworkHoursResult(target, spec,
                redWorkTarifVal, redWorkRatioVal, redWorkLimitVal, redHourLimitVal,
                paymentHoursRes, paymentBasisRes,
                RoundToInt(paymentValueRes), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // AllowceHFull		ALLOWCE_HFULL
    class AllowceHFullConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HFULL;
        public AllowceHFullConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AllowceHFullConSpec(this.Code.Value);
        }
    }

    class AllowceHFullConSpec : OptimulaConceptSpec
    {
        public AllowceHFullConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new AllowceHFullTarget(month, con, pos, var, article, this.Code, 0, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<AllowceHFullTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            AllowceHFullTarget evalTarget = resTarget.Value;

            decimal allowceTarifVal = OperationsDec.Divide(evalTarget.AllowceTarifVal, 100);
            decimal allowceHFullVal = OperationsDec.Divide(evalTarget.AllowceHFullVal, 60);

            var resTimeActa = GetContractResult<TimeactualWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK));

            if (resTimeActa.IsFailure)
            {
                return BuildFailResults(resTimeActa.Error);
            }

            var evalTimeActa = resTimeActa.Value;

            decimal workHoursActa = evalTimeActa.WorkSheetHrsVal;

            decimal monthlyCoeffs = 1.0m;

            decimal workingCoeffs = evalTimeActa.WorkTimeHrsCoef;

            decimal hoursAllowceRes = salaryRules.RelativeAmountWithMonthlyAndCoeffAndWorkCoeff(allowceHFullVal, monthlyCoeffs, workingCoeffs);

            decimal allowceValueRes = salaryRules.PaymentWithTariffAndHours(allowceTarifVal, hoursAllowceRes);

            ITermResult resultsValues = new AllowceHFullResult(target, spec, 
                allowceTarifVal, allowceHFullVal, 
                RoundToInt(allowceValueRes), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // AllowceHours		ALLOWCE_HOURS
    class AllowceHoursConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS;
        public AllowceHoursConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AllowceHoursConSpec(this.Code.Value);
        }
    }

    class AllowceHoursConSpec : OptimulaConceptSpec
    {
        public AllowceHoursConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new AllowceHoursTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<AllowceHoursTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            AllowceHoursTarget evalTarget = resTarget.Value;

            decimal allowceTarifVal = OperationsDec.Divide(evalTarget.AllowceTarifVal, 100);

            var resTimeActa = GetContractResult<TimeactualWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK));

            if (resTimeActa.IsFailure)
            {
                return BuildFailResults(resTimeActa.Error);
            }

            var evalTimeActa = resTimeActa.Value;

            decimal hoursWorked = evalTimeActa.WorkSheetHrsVal;

            decimal allowceValueRes = salaryRules.PaymentWithTariffAndHours(allowceTarifVal, hoursWorked);

            ITermResult resultsValues = new AllowceHoursResult(target, spec, 
                allowceTarifVal, 
                RoundToInt(allowceValueRes), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // AllowceDaily		ALLOWCE_DAILY
    class AllowceDailyConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_DAILY;
        public AllowceDailyConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AllowceDailyConSpec(this.Code.Value);
        }
    }

    class AllowceDailyConSpec : OptimulaConceptSpec
    {
        public AllowceDailyConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new AllowceDailyTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSalary = GetSalaryPropsResult(ruleset, target, period);
            if (resPrSalary.IsFailure)
            {
                return BuildFailResults(resPrSalary.Error);
            }
            IPropsSalary salaryRules = resPrSalary.Value;

            var resTarget = GetTypedTarget<AllowceDailyTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            AllowceDailyTarget evalTarget = resTarget.Value;

            decimal allowceDailyVal = OperationsDec.Divide(evalTarget.AllowceDailyVal, 100);

            var resTimeActa = GetContractResult<TimeactualWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK));

            if (resTimeActa.IsFailure)
            {
                return BuildFailResults(resTimeActa.Error);
            }

            var evalTimeActa = resTimeActa.Value;

            decimal dailyWorked = evalTimeActa.WorkSheetDayVal;

            decimal allowceValueRes = salaryRules.PaymentWithTariffAndHours(allowceDailyVal, dailyWorked);

            ITermResult resultsValues = new AllowceDailyResult(target, spec, 
                allowceDailyVal, 
                RoundToInt(allowceValueRes), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // SettlemTargets	SETTLEM_TARGETS
    class SettlemTargetsConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_TARGETS;
        public SettlemTargetsConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SettlemTargetsConSpec(this.Code.Value);
        }
    }

    class SettlemTargetsConSpec : OptimulaConceptSpec
    {
        public SettlemTargetsConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new SettlemTargetsTarget(month, con, pos, var, article, this.Code),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<SettlemTargetsTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            SettlemTargetsTarget evalTarget = resTarget.Value;


            var incomeList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((v) => (v as OptimulaTermResult))
                .Select((tr) => (tr.ResultValue)).ToArray();

            decimal resValue = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            ITermResult resultsValues = new SettlemTargetsResult(target, spec,
                RoundToInt(resValue), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // SettlemAllowce	SETTLEM_ALLOWCE
    class SettlemAllowceConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_ALLOWCE;
        public SettlemAllowceConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SettlemAllowceConSpec(this.Code.Value);
        }
    }

    class SettlemAllowceConSpec : OptimulaConceptSpec
    {
        public SettlemAllowceConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new SettlemAllowceTarget(month, con, pos, var, article, this.Code),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<SettlemAllowceTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            SettlemAllowceTarget evalTarget = resTarget.Value;


            var incomeList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((v) => (v as OptimulaTermResult))
                .Select((tr) => (tr.ResultValue)).ToArray();

            decimal resValue = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            ITermResult resultsValues = new SettlemAllowceResult(target, spec,
                RoundToInt(resValue), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // SettlemAgrWork	SETTLEM_AGRWORK
    class SettlemAgrWorkConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_AGRWORK;
        public SettlemAgrWorkConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SettlemAgrWorkConSpec(this.Code.Value);
        }
    }

    class SettlemAgrWorkConSpec : OptimulaConceptSpec
    {
        public SettlemAgrWorkConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new SettlemAgrWorkTarget(month, con, pos, var, article, this.Code),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<SettlemAgrWorkTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            SettlemAgrWorkTarget evalTarget = resTarget.Value;


            var incomeList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((v) => (v as OptimulaTermResult))
                .Select((tr) => (tr.ResultValue)).ToArray();

            decimal resValue = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            ITermResult resultsValues = new SettlemAgrWorkResult(target, spec,
                RoundToInt(resValue), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // SettlemResults	SETTLEM_RESULTS
    class SettlemResultsConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_RESULTS;
        public SettlemResultsConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SettlemResultsConSpec(this.Code.Value);
        }
    }

    class SettlemResultsConSpec : OptimulaConceptSpec
    {
        public SettlemResultsConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new SettlemResultsTarget(month, con, pos, var, article, this.Code),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<SettlemResultsTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            SettlemResultsTarget evalTarget = resTarget.Value;


            var incomeList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((v) => (v as OptimulaTermResult))
                .Select((tr) => (tr.ResultValue)).ToArray();

            decimal resValue = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            ITermResult resultsValues = new SettlemResultsResult(target, spec,
                RoundToInt(resValue), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // IncomesTaxFree	INCOMES_TAXFREE
    class IncomesTaxFreeConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXFREE;
        public IncomesTaxFreeConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomesTaxFreeConSpec(this.Code.Value);
        }
    }

    class IncomesTaxFreeConSpec : OptimulaConceptSpec
    {
        public IncomesTaxFreeConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new IncomesTaxFreeTarget(month, con, pos, var, article, this.Code),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<IncomesTaxFreeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            IncomesTaxFreeTarget evalTarget = resTarget.Value;


            var incomeList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((v) => (v as OptimulaTermResult))
                .Select((tr) => (tr.ResultValue)).ToArray();

            decimal resValue = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            ITermResult resultsValues = new IncomesTaxFreeResult(target, spec,
                RoundToInt(resValue), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // IncomesTaxBase	INCOMES_TAXBASE
    class IncomesTaxBaseConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXBASE;
        public IncomesTaxBaseConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomesTaxBaseConSpec(this.Code.Value);
        }
    }

    class IncomesTaxBaseConSpec : OptimulaConceptSpec
    {
        public IncomesTaxBaseConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new IncomesTaxBaseTarget(month, con, pos, var, article, this.Code),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<IncomesTaxBaseTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            IncomesTaxBaseTarget evalTarget = resTarget.Value;

            var incomeList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((v) => (v as OptimulaTermResult))
                .Select((tr) => (tr.ResultValue)).ToArray();

            decimal resValue = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            ITermResult resultsValues = new IncomesTaxBaseResult(target, spec,
                RoundToInt(resValue), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // IncomesTaxWIns	INCOMES_TAXWINS
    class IncomesTaxWInsConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXWINS;
        public IncomesTaxWInsConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomesTaxWInsConSpec(this.Code.Value);
        }
    }

    class IncomesTaxWInsConSpec : OptimulaConceptSpec
    {
        public IncomesTaxWInsConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new IncomesTaxWInsTarget(month, con, pos, var, article, this.Code),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<IncomesTaxWInsTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            IncomesTaxWInsTarget evalTarget = resTarget.Value;


            var incomeList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((v) => (v as OptimulaTermResult))
                .Select((tr) => (tr.ResultValue)).ToArray();

            decimal resValue = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            ITermResult resultsValues = new IncomesTaxWInsResult(target, spec,
                RoundToInt(resValue), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // IncomesSummary	INCOMES_SUMMARY
    class IncomesSummaryConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_INCOMES_SUMMARY;
        public IncomesSummaryConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomesSummaryConSpec(this.Code.Value);
        }
    }

    class IncomesSummaryConSpec : OptimulaConceptSpec
    {
        public IncomesSummaryConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new IncomesSummaryTarget(month, con, pos, var, article, this.Code),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<IncomesSummaryTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            IncomesSummaryTarget evalTarget = resTarget.Value;


            var incomeList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((v) => (v as OptimulaTermResult))
                .Select((tr) => (tr.ResultValue)).ToArray();

            decimal resValue = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            ITermResult resultsValues = new IncomesSummaryResult(target, spec,
                RoundToInt(resValue), 0);

            return BuildOkResults(resultsValues);
        }
    }

}
