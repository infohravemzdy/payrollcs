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
    class ContractWorkTermConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_CONTRACT_WORK_TERM;
        public ContractWorkTermConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new ContractWorkTermConSpec(this.Code.Value);
        }
    }

    class ContractWorkTermConSpec : PayrolexConceptSpec
    {
        public ContractWorkTermConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new ContractWorkTermTarget(month, con, pos, var, article, this.Code, WorkContractTerms.WORKTERM_EMPLOYMENT_1, null, null);
        }
        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<ContractWorkTermTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            ContractWorkTermTarget evalTarget = resTarget.Value;

            Byte termDayFrom = OperationsPeriod.DateFromInPeriod(period, evalTarget.DateFrom);
            Byte termDayStop = OperationsPeriod.DateStopInPeriod(period, evalTarget.DateStop);

            ITermResult resultsValues = new ContractWorkTermResult(target, spec, evalTarget.TermType, termDayFrom, termDayStop);

            return BuildOkResults(resultsValues);
        }
    }


    // PositionTerm			POSITION_TERM
    class PositionWorkTermConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_POSITION_WORK_TERM;
        public PositionWorkTermConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PositionWorkTermConSpec(this.Code.Value);
        }
    }

    class PositionWorkTermConSpec : PayrolexConceptSpec
    {
        public PositionWorkTermConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_CONTRACT_WORK_TERM,
            });

            ResultDelegate = ConceptEval;
        }
        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new PositionWorkTermTarget(month, con, pos, var, article, this.Code, "position unknown", null, null);
        }
        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<PositionWorkTermTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            PositionWorkTermTarget evalTarget = resTarget.Value;

            var resContract = GetContractResult<ContractWorkTermResult>(target, period, results, 
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_CONTRACT_WORK_TERM));

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
            ITermResult resultsValues = new PositionWorkTermResult(target, spec, evalTarget.TermName, termDayFrom, termDayStop);

            return BuildOkResults(resultsValues);
        }
    }


    // PositionWorkPlan			POSITION_WORK_PLAN
    class PositionWorkPlanConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_POSITION_WORK_PLAN;
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
                (Int32)PayrolexArticleConst.ARTICLE_POSITION_WORK_TERM,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            Int32 RulesetWDays = 5;
            Int32 RulesetShift = 8;
            IPropsSalary salaryRules = GetSalaryProps(ruleset, period);
            if (salaryRules != null)
            {
                RulesetWDays = ruleset.SalaryProps.WorkingShiftWeek;
                RulesetShift = ruleset.SalaryProps.WorkingShiftTime;
            }
            return new PositionWorkPlanTarget(month, con, pos, var, article, this.Code, 
                WorkScheduleType.SCHEDULE_NORMALY_WEEK, RulesetWDays, RulesetShift, RulesetShift);
        }
        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<PositionWorkPlanTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            PositionWorkPlanTarget evalTarget = resTarget.Value;

            Int32[] hoursFullWeeks = Array.Empty<Int32>();
            Int32[] hoursRealWeeks = Array.Empty<Int32>();
            Int32[] hoursFullMonth = Array.Empty<Int32>();
            Int32[] hoursRealMonth = Array.Empty<Int32>();

            if (evalTarget.WorkType == WorkScheduleType.SCHEDULE_NORMALY_WEEK)
            {
                Int32 weekShiftPlaned = evalTarget.WeekShiftPlaned;
                Int32 weekShiftLiable = evalTarget.WeekShiftLiable * evalTarget.WeekShiftPlaned;
                hoursFullWeeks = OperationsPeriod.TimesheetWeekSchedule(period, weekShiftLiable, (Byte)weekShiftPlaned);
                hoursRealWeeks = OperationsPeriod.TimesheetWeekSchedule(period, weekShiftLiable, (Byte)weekShiftPlaned);
                hoursFullMonth = OperationsPeriod.TimesheetFullSchedule(period, hoursFullWeeks);
                hoursRealMonth = OperationsPeriod.TimesheetFullSchedule(period, hoursRealWeeks);
            }
            else
            {
                var error = NoImplementationError.CreateError(period, target, $"WorkScheduleType.{evalTarget.WorkType}");
                return BuildFailResults(error);
            }
            ITermResult resultsValues = new PositionWorkPlanResult(target, spec,
                evalTarget.WorkType, hoursFullWeeks, hoursRealWeeks, hoursFullMonth, hoursRealMonth);

            return BuildOkResults(resultsValues);
        }
    }


    // PositionTimePlan			POSITION_TIME_PLAN
    class PositionTimePlanConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_POSITION_TIME_PLAN;
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
                (Int32)PayrolexArticleConst.ARTICLE_POSITION_WORK_PLAN,
                (Int32)PayrolexArticleConst.ARTICLE_POSITION_WORK_TERM,
            });

            ResultDelegate = ConceptEval;
        }
        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new PositionTimePlanTarget(month, con, pos, var, article, this.Code, 0);
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<PositionTimePlanTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            PositionTimePlanTarget evalTarget = resTarget.Value;

            var resWorkPlan = GetPositionResult<PositionWorkPlanResult>(target, period, results,
                target.Contract, target.Position, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_POSITION_WORK_PLAN));

            if (resWorkPlan.IsFailure)
            {
                return BuildFailResults(resWorkPlan.Error);
            }

            var evalWorkPlan = resWorkPlan.Value;

            var resWorkTerm = GetPositionResult<PositionWorkTermResult>(target, period, results,
                target.Contract, target.Position, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_POSITION_WORK_TERM));

            if (resWorkTerm.IsFailure)
            {
                return BuildFailResults(resWorkTerm.Error);
            }

            var evalWorkTerm = resWorkTerm.Value;

            Int32[] hoursRealMonth = evalWorkPlan.HoursRealMonth.ToArray();
            Int32[] hoursTermMonth = OperationsPeriod.TimesheetWorkSchedule(hoursRealMonth, 
                evalWorkTerm.TermDayFrom, evalWorkTerm.TermDayStop);

            ITermResult resultsValues = new PositionTimePlanResult(target, spec,
                evalWorkTerm.TermDayFrom, evalWorkTerm.TermDayStop, hoursRealMonth, hoursTermMonth);

            return BuildOkResults(resultsValues);
        }
    }


    // PositionTimeWork			POSITION_TIME_WORK
    class PositionTimeWorkConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_POSITION_TIME_WORK;
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
                (Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_PLAN,
                (Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_ABSC,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new PositionTimeWorkTarget(month, con, pos, var, article, this.Code, 0);
        }
        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<PositionTimeWorkTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            PositionTimeWorkTarget evalTarget = resTarget.Value;

            var resTimePlan = GetPositionResult<PositionTimePlanResult>(target, period, results,
                target.Contract, target.Position, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_PLAN));

            if (resTimePlan.IsFailure)
            {
                return BuildFailResults(resTimePlan.Error);
            }

            var evalTimePlan = resTimePlan.Value;

            var resTimeAbsc = GetPositionResult<PositionTimeAbscResult>(target, period, results,
                target.Contract, target.Position, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_ABSC));

            if (resTimeAbsc.IsFailure)
            {
                return BuildFailResults(resTimeAbsc.Error);
            }

            var evalTimeAbsc = resTimeAbsc.Value;

            Int32[] hoursWorkMonth = OperationsPeriod.ScheduleBaseSubtract(
                evalTimePlan.HoursTermMonth, evalTimeAbsc.HoursTermMonth, 1, 31);

            ITermResult resultsValues = new PositionTimeWorkResult(target, spec,
                evalTimePlan.TermDayFrom, evalTimePlan.TermDayStop, hoursWorkMonth);

            return BuildOkResults(resultsValues);
        }
    }


    // PositionTimeAbsc			POSITION_TIME_ABSC
    class PositionTimeAbscConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_POSITION_TIME_ABSC;
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
                (Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_PLAN,
                (Int32)PayrolexArticleConst.ARTICLE_CONTRACT_TIME_ABSC,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new PositionTimeAbscTarget(month, con, pos, var, article, this.Code, 0);
        }
        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<PositionTimeAbscTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            PositionTimeAbscTarget evalTarget = resTarget.Value;

            var resTimePlan = GetPositionResult<PositionTimePlanResult>(target, period, results,
                target.Contract, target.Position, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_PLAN));

            if (resTimePlan.IsFailure)
            {
                return BuildFailResults(resTimePlan.Error);
            }

            var evalTimePlan = resTimePlan.Value;

            Int32[] hoursAbscMonth = OperationsPeriod.EmptyMonthSchedule();

            ITermResult resultsValues = new PositionTimeAbscResult(target, spec,
                evalTimePlan.TermDayFrom, evalTimePlan.TermDayStop, hoursAbscMonth);

            return BuildOkResults(resultsValues);
        }
    }


    // ContractTimePlan			CONTRACT_TIME_PLAN
    class ContractTimePlanConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_CONTRACT_TIME_PLAN;
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
                (Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_PLAN,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new ContractTimePlanTarget(month, con, pos, var, article, this.Code, 0);
        }
        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<ContractTimePlanTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            ContractTimePlanTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new ContractTimePlanResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


    // ContractTimeWork			CONTRACT_TIME_WORK
    class ContractTimeWorkConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_CONTRACT_TIME_WORK;
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
                (Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_WORK,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new ContractTimeWorkTarget(month, con, pos, var, article, this.Code, 0);
        }
        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<ContractTimeWorkTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            ContractTimeWorkTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new ContractTimeWorkResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


    // ContractTimeAbsc			CONTRACT_TIME_ABSC
    class ContractTimeAbscConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_CONTRACT_TIME_ABSC;
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
                (Int32)PayrolexArticleConst.ARTICLE_CONTRACT_TIME_PLAN,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new ContractTimeAbscTarget(month, con, pos, var, article, this.Code, 0);
        }
        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<ContractTimeAbscTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            ContractTimeAbscTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new ContractTimeAbscResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


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

            if (resWorkPlan.IsFailure)
            {
                return BuildFailResults(resWorkPlan.Error);
            }

            var evalWorkPlan = resWorkPlan.Value;

            var resTimePlan = GetPositionResult<PositionTimePlanResult>(target, period, results,
               target.Contract, target.Position, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_PLAN));

            if (resTimePlan.IsFailure)
            {
                return BuildFailResults(resTimePlan.Error);
            }

            var evalTimePlan = resTimePlan.Value;

            var resTimeWork = GetPositionResult<PositionTimeWorkResult>(target, period, results,
               target.Contract, target.Position, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_WORK));

            if (resTimeWork.IsFailure)
            {
                return BuildFailResults(resTimeWork.Error);
            }

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


    // IncomeGross			INCOME_GROSS
    class IncomeGrossConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_INCOME_GROSS;
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

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new IncomeGrossTarget(month, con, pos, var, article, this.Code, 0);
        }
        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<IncomeGrossTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            IncomeGrossTarget evalTarget = resTarget.Value;

            decimal resValue = results.Aggregate(decimal.Zero,
                (agr, item) =>
                {
                    if (item.IsFailure)
                    {
                        return 0;
                    }
                    var itemValue = item.Value;
                    if (itemValue.Spec.Sums.Contains(evalTarget.Article)==false)
                    {
                        return 0;
                    }
                    return decimal.Add(agr, itemValue.ResultValue);
                });

            ITermResult resultsValues = new IncomeGrossResult(target, spec, RoundingInt.RoundToInt(resValue), 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }


    // IncomeNetto			INCOME_NETTO
    class IncomeNettoConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_INCOME_NETTO;
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
                (Int32)PayrolexArticleConst.ARTICLE_INCOME_GROSS,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new IncomeNettoTarget(month, con, pos, var, article, this.Code, 0);
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<IncomeNettoTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            IncomeNettoTarget evalTarget = resTarget.Value;

            var resIncGross = GetResult<IncomeGrossResult>(target, period, results,
               ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_INCOME_GROSS));

            if (resIncGross.IsFailure)
            {
                return BuildFailResults(resIncGross.Error);
            }

            var evalIncGross = resIncGross.Value;

            decimal resValue = evalIncGross.ResultValue;

            ITermResult resultsValues = new IncomeNettoResult(target, spec, RoundingInt.RoundToInt(resValue), 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

}
