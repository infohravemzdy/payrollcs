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

namespace HraveMzdy.Procezor.Optimula.Registry.Providers
{
    // TimesheetsPlan			TIMESHEETS_PLAN
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

    // TimesheetsWork			TIMESHEETS_WORK
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

            decimal hoursWorkCoef = salaryRules.WorkingHoursCoeff(timeSheetHrsVal, hoursWorkPlan);

            ITermResult resultsValues = new TimesheetsWorkResult(target, spec,
                timeSheetHrsVal, holiSheetHrsVal, hoursWorkCoef,
                0, 0);

            return BuildOkResults(resultsValues);
        }
    }

    // TimeactualWork			TIMEACTUAL_WORK
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

            decimal hoursWorkCoef = salaryRules.WorkingHoursCoeff(hoursTimeWork, workSheetHrsVal);

            ITermResult resultsValues = new TimeactualWorkResult(target, spec,
                workSheetHrsVal, workSheetDayVal, overSheetHrsVal, hoursWorkCoef,
                0, 0);

            return BuildOkResults(resultsValues);
        }
    }

    // PaymentBasis			PAYMENT_BASIS
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
                new PaymentBasisTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<PaymentBasisTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            PaymentBasisTarget evalTarget = resTarget.Value;

            decimal msalaryBasisVal = OperationsDec.Divide(evalTarget.MSalaryBasisVal, 100);

            ITermResult resultsValues = new PaymentBasisResult(target, spec, 
                msalaryBasisVal, 
                0, 0);

            return BuildOkResults(resultsValues);
        }
    }

    // OptimusBasis			OPTIMUS_BASIS
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
                new OptimusBasisTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<OptimusBasisTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            OptimusBasisTarget evalTarget = resTarget.Value;

            decimal msalaryBonusVal = OperationsDec.Divide(evalTarget.MSalaryBonusVal, 100);

            ITermResult resultsValues = new OptimusBasisResult(target, spec, 
                msalaryBonusVal, 
                0, 0);

            return BuildOkResults(resultsValues);
        }
    }

    // OptimusFixed			OPTIMUS_FIXED
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
            var resTarget = GetTypedTarget<OptimusFixedTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            OptimusFixedTarget evalTarget = resTarget.Value;

            decimal premiumBasisVal = OperationsDec.Divide(evalTarget.PremiumBasisVal, 100);

            ITermResult resultsValues = new OptimusFixedResult(target, spec, 
                premiumBasisVal, 
                0, 0);

            return BuildOkResults(resultsValues);
        }
    }

    // AgrworkHours			AGRWORK_HOURS
    class AgrworkHoursConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_AGRWORK_HOURS;
        public AgrworkHoursConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AgrworkHoursConSpec(this.Code.Value);
        }
    }

    class AgrworkHoursConSpec : OptimulaConceptSpec
    {
        public AgrworkHoursConSpec(Int32 code) : base(code)
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

            decimal agrWorkTarifVal = OperationsDec.Divide(evalTarget.AgrWorkTarifVal, 100);
            decimal agrWorkRatioVal = OperationsDec.Divide(evalTarget.AgrWorkRatioVal, 100);
            decimal agrWorkLimitVal = OperationsDec.Divide(evalTarget.AgrWorkLimitVal, 100);
            decimal agrHourLimitVal = OperationsDec.Divide(evalTarget.AgrHourLimitVal, 60);

            var resTimeActa = GetContractResult<TimeactualWorkResult>(target, period, results,
               target.Contract, ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK));

            if (resTimeActa.IsFailure)
            {
                return BuildFailResults(resTimeActa.Error);
            }

            var evalTimeActa = resTimeActa.Value;

            decimal hoursWorkActa = evalTimeActa.WorkSheetHrsVal;

            decimal agrResultsHours = 0m;
            if (agrHourLimitVal == 0m)
            {
                agrResultsHours = salaryRules.HoursToHalfHoursNorm(OperationsDec.Multiply(hoursWorkActa, agrWorkRatioVal));
            }
            else
            {
                decimal agrCandidsHours = 0m;
                agrCandidsHours = salaryRules.HoursToHalfHoursNorm(OperationsDec.Multiply(hoursWorkActa, agrWorkRatioVal));
                if (agrWorkRatioVal == 0m)
                {
                    agrResultsHours = Math.Min(agrCandidsHours, salaryRules.HoursToHalfHoursNorm(agrHourLimitVal));
                }
                else
                {
                    agrResultsHours = salaryRules.HoursToHalfHoursNorm(agrHourLimitVal);
                }
            }
            decimal agrWorkValueRes = salaryRules.SalaryAmountHourlyValue(agrWorkTarifVal, agrResultsHours);

            ITermResult resultsValues = new AgrworkHoursResult(target, spec, 
                agrWorkTarifVal, agrWorkRatioVal, agrWorkLimitVal, agrHourLimitVal,
                agrResultsHours, 
                RoundToInt(agrWorkValueRes), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // AllowceHFull			ALLOWCE_HFULL
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

            decimal hoursWorkActa = evalTimeActa.WorkSheetHrsVal;

            decimal hoursWorkCoef = evalTimeActa.WorkTimeHrsCoef;

            decimal hoursAllowceRes = salaryRules.FactorizeValue(allowceHFullVal, hoursWorkCoef);

            decimal allowceValueRes = salaryRules.SalaryAmountHourlyValue(allowceTarifVal, hoursAllowceRes);

            ITermResult resultsValues = new AllowceHFullResult(target, spec, 
                allowceTarifVal, allowceHFullVal, 
                RoundToInt(allowceValueRes), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // AllowceHours			ALLOWCE_HOURS
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

            decimal allowceValueRes = salaryRules.SalaryAmountHourlyValue(allowceTarifVal, hoursWorked);

            ITermResult resultsValues = new AllowceHoursResult(target, spec, 
                allowceTarifVal, 
                RoundToInt(allowceValueRes), 0);

            return BuildOkResults(resultsValues);
        }
    }

    // IncomesTaxFree		INCOMES_TAXFREE
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

    // IncomesTaxBase		INCOMES_TAXBASE
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

    // IncomesTaxWIns		INCOMES_TAXWINS
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

    // IncomesSummary		INCOMES_SUMMARY
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
