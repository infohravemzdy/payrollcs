using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Procezor.Payrolex.Registry.Constants;
using HraveMzdy.Procezor.Payrolex.Registry.Operations;
using MaybeMonad;
using ResultMonad;

namespace HraveMzdy.Procezor.Payrolex.Registry.Providers
{
    // HealthDeclare			HEALTH_DECLARE
    class HealthDeclareConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_DECLARE;
        public HealthDeclareConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthDeclareConSpec(this.Code.Value);
        }
    }

    class HealthDeclareConSpec : PayrolexConceptSpec
    {
        public HealthDeclareConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_CONTRACT_WORK_TERM,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract))))==false).ToArray();
            
            return ter.Select((t) => (new HealthDeclareTarget(month, t.Contract, pos, var, article, this.Code, 1, WorkHealthTerms.HEALTH_TERM_BY_CONTRACT, 1)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthDeclareTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthDeclareTarget evalTarget = resTarget.Value;

            var resContract = GetContractResult<ContractWorkTermResult>(target, period, results,
             target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_CONTRACT_WORK_TERM));

            if (resContract.IsFailure)
            {
                return BuildFailResults(resContract.Error);
            }

            var evalContract = resContract.Value;

            var evalContractType = evalTarget.ContractType;

            if (evalContractType == WorkHealthTerms.HEALTH_TERM_BY_CONTRACT)
            {
                switch (evalContract.TermType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        evalContractType = WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS;
                        break;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        evalContractType = WorkHealthTerms.HEALTH_TERM_AGREEM_WORK;
                        break;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        evalContractType = WorkHealthTerms.HEALTH_TERM_AGREEM_TASK;
                        break;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        evalContractType = WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS;
                        break;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        evalContractType = WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS;
                        break;
                }
            }
            ITermResult resultsValues = new HealthDeclareResult(target, spec, 
                evalTarget.InterestCode, evalContractType, evalTarget.MandatorBase);

            return BuildOkResults(resultsValues);
        }
    }

    // HealthIncome			HEALTH_INCOME
    class HealthIncomeConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_INCOME;
        public HealthIncomeConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthIncomeConSpec(this.Code.Value);
        }
    }

    class HealthIncomeConSpec : PayrolexConceptSpec
    {
        public HealthIncomeConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE,
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
                new HealthIncomeTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrHealth = GetHealthPropsResult(ruleset, target, period);
            if (resPrHealth.IsFailure)
            {
                return BuildFailResults(resPrHealth.Error);
            }
            IPropsHealth healthRules = resPrHealth.Value;

            Int32 marginIncomeEmp = healthRules.MarginIncomeEmp;
            Int32 marginIncomeAgr = healthRules.MarginIncomeAgr;

            var resTarget = GetTypedTarget<HealthIncomeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthIncomeTarget evalTarget = resTarget.Value;

            var incomeContractList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE))
                .Select((tr) => (tr as HealthDeclareResult)).ToArray();

            var incomeResultInit = Array.Empty<HealthIncomeResult>();
            var incomeResultList = incomeContractList.Aggregate(incomeResultInit, (agr, x) =>
            {
                var evalSubjectsType = x.ContractType;
                var evalInterestCode = x.InterestCode;
                var evalMandatorBase = x.MandatorBase;

                var contractResult = agr.FirstOrDefault((a) => (a.Contract.Equals(x.Contract)));
                if (contractResult == null)
                {
                    contractResult = new HealthIncomeResult(evalTarget, x.Contract, spec,
                        evalInterestCode, evalSubjectsType, evalMandatorBase, VALUE_ZERO, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY);
                    agr = agr.Concat(new HealthIncomeResult[] { contractResult }).ToArray();
                }
                var incomeList = results
                    .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                    .Where((v) => (v.Contract.Equals(x.Contract) && v.Spec.Sums.Contains(evalTarget.Article)))
                    .Select((tr) => (tr.ResultValue)).ToArray();

                decimal resValue = incomeList.Aggregate(decimal.Zero,
                    (agr, item) => decimal.Add(agr, item));

                contractResult.AddResultValue(RoundingInt.RoundToInt(resValue));
                return agr;
            });

            var incomeOrdersList = incomeResultList.OrderBy((x) => new HealthIncomeComparator()).ToArray();

            var resultOrdersInit = Array.Empty<HealthIncomeResult>();

            var resultOrdersList = incomeOrdersList.Aggregate(resultOrdersInit,
                (agr, x) => {
                    Int32 sumTermIncome = incomeResultList.Where((c) => (c.InterestCode != 0 && c.IncomeTerm().Equals(x.IncomeTerm())))
                        .Aggregate(0, (sum, c) => (sum + c.ResultValue));

                    Int16 particeCode = 0;
                    if (x.InterestCode != 0)
                    {
                        if (HealthParticeBasedOnIncome(period, x.IncomeTerm())==false)
                        {
                            particeCode = 1;
                        }
                        else
                        {
                            if (x.IncomeTerm()==WorkHealthTerms.HEALTH_TERM_AGREEM_TASK)
                            {
                                particeCode = 1;
                                if (marginIncomeAgr > 0)
                                {
                                    particeCode = 0;
                                    if (sumTermIncome >= marginIncomeAgr)
                                    {
                                        particeCode = 1;
                                    }
                                }
                            }
                            else
                            {
                                particeCode = 1;
                                if (marginIncomeEmp > 0)
                                {
                                    particeCode = 0;
                                    if (sumTermIncome >= marginIncomeEmp)
                                    {
                                        particeCode = 1;
                                    }
                                }
                            }
                        }
                    }
                    x.SetParticeCode(particeCode);

                    return agr.Concat(new HealthIncomeResult[] { x }).ToArray();
                });

            return BuildOkResults(resultOrdersList);
        }
        bool HealthParticeBasedOnIncome(IPeriod period, WorkHealthTerms term)
        {
            switch (term)
            {
                case WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS:
                    return false;
                case WorkHealthTerms.HEALTH_TERM_AGREEM_TASK:
                    return (period.Year >= 2015 ? true : 
                           (period.Year >= 2012 ? true : true));
                case WorkHealthTerms.HEALTH_TERM_AGREEM_WORK:
                    return (period.Year >= 2015 ? true : 
                           (period.Year >= 2012 ? true : false));
                case WorkHealthTerms.HEALTH_TERM_NONE_EMPLOY:
                    return (period.Year >= 2015 ? true : 
                           (period.Year >= 2012 ? true : false));
                case WorkHealthTerms.HEALTH_TERM_BY_CONTRACT:
                    return (period.Year >= 2015 ? true : 
                           (period.Year >= 2012 ? true : false));
            }
            return false;
        }
        private class HealthIncomeComparator : IComparer<HealthIncomeResult>
        {
            public HealthIncomeComparator()
            {
            }

            public int Compare(HealthIncomeResult x, HealthIncomeResult y)
            {
                WorkHealthTerms xIncomeTerm = x.IncomeTerm();
                WorkHealthTerms yIncomeTerm = y.IncomeTerm();

                if (xIncomeTerm.CompareTo(yIncomeTerm)==0)
                {
                    return x.Contract.CompareTo(y.Contract);
                }
                return xIncomeTerm.CompareTo(yIncomeTerm);
            }
        }
    }

    // HealthBase			HEALTH_BASE
    class HealthBaseConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE;
        public HealthBaseConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthBaseConSpec(this.Code.Value);
        }
    }

    class HealthBaseConSpec : PayrolexConceptSpec
    {
        public HealthBaseConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_INCOME,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract)))) == false).ToArray();

            return ter.Select((t) => (new HealthBaseTarget(month, t.Contract, pos, var, article, this.Code, 0)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthBaseTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthBaseTarget evalTarget = resTarget.Value;

            var resDeclare = GetContractResult<HealthDeclareResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE));
            var resIncomes = GetContractResult<HealthIncomeResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_INCOME));

            var resCompound = GetFailedOrOk(resDeclare.ErrOrOk(), resIncomes.ErrOrOk());
            if (resCompound.IsFailure)
            {
                return BuildFailResults(resCompound.Error);
            }

            var evalDeclare = resDeclare.Value;
            var evalIncomes = resIncomes.Value;

            Int32 resGeneralBase = 0;
            if (evalDeclare.InterestCode != 0)
            {
                if (evalIncomes.ParticeCode != 0)
                {
                    resGeneralBase = evalIncomes.ResultValue;
                }
            }

            ITermResult resultsValues = new HealthBaseResult(target, spec, 
                evalTarget.AnnuityBase, resGeneralBase, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // HealthBaseEmployee			HEALTH_BASE_EMPLOYEE
    class HealthBaseEmployeeConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_EMPLOYEE;
        public HealthBaseEmployeeConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthBaseEmployeeConSpec(this.Code.Value);
        }
    }

    class HealthBaseEmployeeConSpec : PayrolexConceptSpec
    {
        public HealthBaseEmployeeConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_MANDATE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract)))) == false).ToArray();

            return ter.Select((t) => (new HealthBaseEmployeeTarget(month, t.Contract, pos, var, article, this.Code, 0)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthBaseEmployeeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthBaseEmployeeTarget evalTarget = resTarget.Value;

            Int32 baseEmployee = 0;

            Int32 baseMandated = 0;

            var resBaseMandated = GetContractResult<HealthBaseMandateResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_MANDATE));

            if (resBaseMandated.IsSuccess)
            {
                baseMandated = resBaseMandated.Value.ResultValue;
            }

            ITermResult resultsValues = new HealthBaseEmployeeResult(target, spec, baseMandated + baseEmployee, baseEmployee, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // HealthBaseEmployer			HEALTH_BASE_EMPLOYER
    class HealthBaseEmployerConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_EMPLOYER;
        public HealthBaseEmployerConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthBaseEmployerConSpec(this.Code.Value);
        }
    }

    class HealthBaseEmployerConSpec : PayrolexConceptSpec
    {
        public HealthBaseEmployerConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract)))) == false).ToArray();

            return ter.Select((t) => (new HealthBaseEmployerTarget(month, t.Contract, pos, var, article, this.Code, 0)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthBaseEmployerTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthBaseEmployerTarget evalTarget = resTarget.Value;

            Int32 baseEmployer = 0;

            ITermResult resultsValues = new HealthBaseEmployerResult(target, spec, baseEmployer, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // HealthBaseMandate			HEALTH_BASE_MANDATE
    class HealthBaseMandateConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_MANDATE;
        public HealthBaseMandateConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthBaseMandateConSpec(this.Code.Value);
        }
    }

    class HealthBaseMandateConSpec : PayrolexConceptSpec
    {
        public HealthBaseMandateConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract)))) == false).ToArray();

            return ter.Select((t) => (new HealthBaseMandateTarget(month, t.Contract, pos, var, article, this.Code, 0)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrHealth = GetHealthPropsResult(ruleset, target, period);
            if (resPrHealth.IsFailure)
            {
                return BuildFailResults(resPrHealth.Error);
            }
            IPropsHealth healthRules = resPrHealth.Value;

            Int32 minMonthlyBasis = healthRules.MinMonthlyBasis;

            var resTarget = GetTypedTarget<HealthBaseMandateTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthBaseMandateTarget evalTarget = resTarget.Value;

            var resDeclare = GetContractResult<HealthDeclareResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE));
            var resIncomes = GetContractResult<HealthIncomeResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_INCOME));
            var resBaseVal = GetContractResult<HealthBaseResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE));

            var resCompound = GetFailedOrOk(resDeclare.ErrOrOk(), resIncomes.ErrOrOk(), resBaseVal.ErrOrOk());
            if (resCompound.IsFailure)
            {
                return BuildFailResults(resCompound.Error);
            }

            var evalDeclare = resDeclare.Value;
            var evalBaseVal = resBaseVal.Value;
            var evalIncomes = resIncomes.Value;

            var basisList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE))
                .Select((tr) => (tr.ResultValue)).ToArray();

            var mandtList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_MANDATE))
                .Select((tr) => (tr.ResultValue)).ToArray();

            Int32 resSumBasis = basisList.Aggregate(0,
                (agr, item) => (agr + item));
            Int32 resSumMandt = mandtList.Aggregate(0,
                (agr, item) => (agr + item));

            Int32 resGeneralBase = 0;
            Int32 resMandateBase = 0;
            if (evalDeclare.InterestCode != 0)
            {
                if (evalIncomes.ParticeCode != 0)
                {
                    resGeneralBase = evalBaseVal.ResultValue;

                    if (evalDeclare.MandatorBase != 0)
                    {
                        Int32 curManHealth = Math.Max(0, minMonthlyBasis - (resSumBasis - resGeneralBase + resSumMandt));
                        Int32 sumManHealth = Math.Max(resGeneralBase, curManHealth);
                        resMandateBase = Math.Max(0, sumManHealth - resGeneralBase);
                    }
                }

            }

            if (resMandateBase > 0)
            {
                ITermResult resultsValues = new HealthBaseMandateResult(target, spec, resMandateBase, 0, DESCRIPTION_EMPTY);
                return BuildOkResults(resultsValues);
            }
            return BuildEmptyResults();
        }
    }

    // HealthBaseOvercap			HEALTH_BASE_OVERCAP
    class HealthBaseOvercapConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_OVERCAP;
        public HealthBaseOvercapConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthBaseOvercapConSpec(this.Code.Value);
        }
    }

    class HealthBaseOvercapConSpec : PayrolexConceptSpec
    {
        public HealthBaseOvercapConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE,
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
                new HealthBaseOvercapTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrHealth = GetHealthPropsResult(ruleset, target, period);
            if (resPrHealth.IsFailure)
            {
                return BuildFailResults(resPrHealth.Error);
            }
            IPropsHealth healthRules = resPrHealth.Value;

            Int32 maxAnnualsBasis = healthRules.MaxAnnualsBasis;

            var resTarget = GetTypedTarget<HealthBaseOvercapTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthBaseOvercapTarget evalTarget = resTarget.Value;

            var incomeContractList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE))
                .Select((tr) => (tr.Contract, tr.ResultValue)).ToArray();

            var incomeResultInit = Array.Empty<HealthBaseOvercapResult>();
            var incomeResultList = incomeContractList.Aggregate(incomeResultInit, (agr, x) =>
            {
                var resHealthDeclare = GetContractResult<HealthDeclareResult>(target, period, results,
                    x.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE));

                if (resHealthDeclare.IsFailure)
                {
                    return agr;
                }

                var evalHealthDeclare = resHealthDeclare.Value;

                var evalSubjectsType = evalHealthDeclare.ContractType;

                var contractResult = agr.FirstOrDefault((a) => (a.Contract.Equals(x.Contract)));
                if (contractResult == null)
                {
                    contractResult = new HealthBaseOvercapResult(evalTarget, x.Contract, spec,
                        evalSubjectsType, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY);
                    agr = agr.Concat(new HealthBaseOvercapResult[] { contractResult }).ToArray();
                }
                contractResult.AddResultBasis(x.ResultValue);
                return agr;
            });

            var incomeOrdersList = incomeResultList.OrderBy((x) => new HealthBaseOvercapComparator()).ToArray();

            Int32 perAnnuityBasis = 0;
            Int32 perAnnualsBasis = Math.Max(0, maxAnnualsBasis - perAnnuityBasis);
            var resultOrdersInit = new Tuple<Int32, Int32, HealthBaseOvercapResult[]>(
                maxAnnualsBasis, perAnnualsBasis, Array.Empty<HealthBaseOvercapResult>());

            var resultOrdersList = incomeOrdersList.Aggregate(resultOrdersInit,
                (agr, x) => {
                    Int32 ovrAnnualsBasis = 0;
                    Int32 cutAnnualsBasis = x.ResultBasis;
                    if (agr.Item1 > 0)
                    {
                        ovrAnnualsBasis = Math.Max(0, x.ResultBasis - agr.Item2);
                        cutAnnualsBasis = (x.ResultBasis - ovrAnnualsBasis);
                    }

                    if (ovrAnnualsBasis > 0)
                    {
                        Int32 remAnnualsBasis = Math.Max(0, (agr.Item2 - cutAnnualsBasis));

                        x.SetResultValue(ovrAnnualsBasis);

                        return new Tuple<Int32, Int32, HealthBaseOvercapResult[]>(
                            agr.Item1, remAnnualsBasis, agr.Item3.Concat(new HealthBaseOvercapResult[] { x }).ToArray());
                    }
                    return new Tuple<Int32, Int32, HealthBaseOvercapResult[]>(agr.Item1, agr.Item2, agr.Item3);
                });

            return BuildOkResults(resultOrdersList.Item3);
        }
        private class HealthBaseOvercapComparator : IComparer<HealthBaseOvercapResult>
        {
            public HealthBaseOvercapComparator()
            {
            }

            public int Compare(HealthBaseOvercapResult x, HealthBaseOvercapResult y)
            {
                Int32 xIncomeScore = x.IncomeScore();
                Int32 yIncomeScore = y.IncomeScore();

                if (xIncomeScore.CompareTo(yIncomeScore) == 0)
                {
                    return x.Contract.CompareTo(y.Contract);
                }
                return xIncomeScore.CompareTo(yIncomeScore);
            }
        }
    }

    // HealthPaymEmployee			HEALTH_PAYM_EMPLOYEE
    class HealthPaymEmployeeConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_PAYM_EMPLOYEE;
        public HealthPaymEmployeeConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthPaymEmployeeConSpec(this.Code.Value);
        }
    }

    class HealthPaymEmployeeConSpec : PayrolexConceptSpec
    {
        public HealthPaymEmployeeConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_OVERCAP,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYEE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract)))) == false).ToArray();

            return ter.Select((t) => (new HealthPaymEmployeeTarget(month, t.Contract, pos, var, article, this.Code, 0)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrHealth = GetHealthPropsResult(ruleset, target, period);
            if (resPrHealth.IsFailure)
            {
                return BuildFailResults(resPrHealth.Error);
            }
            IPropsHealth healthRules = resPrHealth.Value;

            decimal factorCompound = OperationsDec.Divide(healthRules.FactorCompound, 100);
            decimal factorEmployee = healthRules.FactorEmployee;

            var resTarget = GetTypedTarget<HealthPaymEmployeeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthPaymEmployeeTarget evalTarget = resTarget.Value;

            var resBaseVal = GetContractResult<HealthBaseResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE));

            if (resBaseVal.IsFailure)
            {
                return BuildFailResults(resBaseVal.Error);
            }

            var evalBaseVal = resBaseVal.Value;

            Int32 valBaseGenerals = evalBaseVal.ResultValue;

            Int32 valBaseEmployee = 0;
            Int32 valBaseOvercaps = 0;
            var resBaseEmployee = GetContractResult<HealthBaseEmployeeResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYEE));

            if (resBaseEmployee.IsSuccess)
            {
                valBaseEmployee = resBaseEmployee.Value.ResultValue;
            }
            
            var resBaseOvercaps = GetContractResult<HealthBaseOvercapResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_OVERCAP));

            if (resBaseOvercaps.IsSuccess)
            {
                valBaseOvercaps = resBaseOvercaps.Value.ResultValue;
            }

            Int32 empBaseOvercaps = Math.Max(0, valBaseOvercaps - valBaseEmployee);
            valBaseEmployee = valBaseEmployee - empBaseOvercaps;
            valBaseOvercaps = (valBaseOvercaps - empBaseOvercaps);

            Int32 genBaseOvercaps = Math.Max(0, valBaseOvercaps - valBaseGenerals);
            valBaseGenerals = valBaseGenerals - genBaseOvercaps;
            valBaseOvercaps = (valBaseOvercaps - genBaseOvercaps);

            Int32 employeePayment = OperationsHealth.IntInsuranceRoundUp(
                OperationsDec.Multiply(valBaseEmployee, factorCompound)
                + OperationsDec.MultiplyAndDivide(valBaseGenerals, factorCompound, factorEmployee));

            ITermResult resultsValues = new HealthPaymEmployeeResult(target, spec, valBaseEmployee, valBaseGenerals, employeePayment, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // HealthPaymEmployer			HEALTH_PAYM_EMPLOYER
    class HealthPaymEmployerConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_PAYM_EMPLOYER;
        public HealthPaymEmployerConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthPaymEmployerConSpec(this.Code.Value);
        }
    }

    class HealthPaymEmployerConSpec : PayrolexConceptSpec
    {
        public HealthPaymEmployerConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_OVERCAP,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYEE,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYER,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract)))) == false).ToArray();

            return ter.Select((t) => (new HealthPaymEmployerTarget(month, t.Contract, pos, var, article, this.Code, 0)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrHealth = GetHealthPropsResult(ruleset, target, period);
            if (resPrHealth.IsFailure)
            {
                return BuildFailResults(resPrHealth.Error);
            }
            IPropsHealth healthRules = resPrHealth.Value;

            decimal factorCompound = OperationsDec.Divide(healthRules.FactorCompound, 100);
            decimal factorEmployee = healthRules.FactorEmployee;

            var resTarget = GetTypedTarget<HealthPaymEmployerTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthPaymEmployerTarget evalTarget = resTarget.Value;

            var resBaseVal = GetContractResult<HealthBaseResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE));

            if (resBaseVal.IsFailure)
            {
                return BuildFailResults(resBaseVal.Error);
            }

            var evalBaseVal = resBaseVal.Value;

            Int32 valBaseGenerals = evalBaseVal.ResultValue;

            Int32 valBaseEmployee = 0;
            Int32 valBaseEmployer = 0;
            Int32 valBaseOvercaps = 0;
            var resBaseEmployee = GetContractResult<HealthBaseEmployeeResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYEE));

            if (resBaseEmployee.IsSuccess)
            {
                valBaseEmployee = resBaseEmployee.Value.ResultValue;
            }
            var resBaseEmployer = GetContractResult<HealthBaseEmployeeResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYER));

            if (resBaseEmployer.IsSuccess)
            {
                valBaseEmployer = resBaseEmployer.Value.ResultValue;
            }

            var resBaseOvercaps = GetContractResult<HealthBaseOvercapResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_OVERCAP));

            if (resBaseOvercaps.IsSuccess)
            {
                valBaseOvercaps = resBaseOvercaps.Value.ResultValue;
            }

            Int32 empBaseOvercaps = Math.Max(0, valBaseOvercaps - valBaseEmployee);
            valBaseEmployee = valBaseEmployee - empBaseOvercaps;
            valBaseOvercaps = (valBaseOvercaps - empBaseOvercaps);

            Int32 genBaseOvercaps = Math.Max(0, valBaseOvercaps - valBaseGenerals);
            valBaseGenerals = valBaseGenerals - genBaseOvercaps;
            valBaseOvercaps = (valBaseOvercaps - genBaseOvercaps);

            Int32 emrBaseOvercaps = Math.Max(0, valBaseOvercaps - valBaseEmployer);
            valBaseEmployer = valBaseEmployer - emrBaseOvercaps;
            valBaseOvercaps = (valBaseOvercaps - emrBaseOvercaps);

            Int32 compoundBasis = valBaseEmployer + valBaseEmployee + valBaseGenerals;

            Int32 compoundPayment = OperationsHealth.IntInsuranceRoundUp(OperationsDec.Multiply(compoundBasis, factorCompound));
            Int32 employeePayment = OperationsHealth.IntInsuranceRoundUp(OperationsDec.Multiply(valBaseEmployee, factorCompound)
                + OperationsDec.MultiplyAndDivide(valBaseGenerals, factorCompound, factorEmployee));
            Int32 employerPayment = Math.Max(0, compoundPayment - employeePayment);

            ITermResult resultsValues = new HealthPaymEmployerResult(target, spec, valBaseEmployer, valBaseGenerals, employerPayment, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }
}
