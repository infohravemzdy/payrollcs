﻿using System;
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
using ResultMonad;
using MaybeMonad;

namespace HraveMzdy.Procezor.Payrolex.Registry.Providers
{
    // SocialDeclare			SOCIAL_DECLARE
    class SocialDeclareConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_DECLARE;
        public SocialDeclareConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialDeclareConSpec(this.Code.Value);
        }
    }

    class SocialDeclareConSpec : PayrolexConceptSpec
    {
        public SocialDeclareConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_CONTRACT_WORK_TERM,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract)))) == false).ToArray();

            return ter.Select((t) => (new SocialDeclareTarget(month, t.Contract, pos, var, article, this.Code, 1, WorkSocialTerms.SOCIAL_TERM_BY_CONTRACT)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<SocialDeclareTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            SocialDeclareTarget evalTarget = resTarget.Value;

            var resContract = GetContractResult<ContractWorkTermResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_CONTRACT_WORK_TERM));

            if (resContract.IsFailure)
            {
                return BuildFailResults(resContract.Error);
            }

            var evalContract = resContract.Value;

            var evalContractType = evalTarget.ContractType;

            if (evalContractType == WorkSocialTerms.SOCIAL_TERM_BY_CONTRACT)
            {
                switch (evalContract.TermType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        evalContractType = WorkSocialTerms.SOCIAL_TERM_EMPLOYMENTS;
                        break;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        evalContractType = WorkSocialTerms.SOCIAL_TERM_SMALLS_EMPL;
                        break;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        evalContractType = WorkSocialTerms.SOCIAL_TERM_SMALLS_EMPL;
                        break;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        evalContractType = WorkSocialTerms.SOCIAL_TERM_EMPLOYMENTS;
                        break;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        evalContractType = WorkSocialTerms.SOCIAL_TERM_EMPLOYMENTS;
                        break;
                }
            }
            ITermResult resultsValues = new SocialDeclareResult(target, spec,
                evalTarget.InterestCode, evalContractType);

            return BuildOkResults(resultsValues);
        }
    }

    // SocialIncome			SOCIAL_INCOME
    class SocialIncomeConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_INCOME;
        public SocialIncomeConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialIncomeConSpec(this.Code.Value);
        }
    }

    class SocialIncomeConSpec : PayrolexConceptSpec
    {
        public SocialIncomeConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_DECLARE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract)))) == false).ToArray();

            return ter.Select((t) => (new SocialIncomeTarget(month, t.Contract, pos, var, article, this.Code, 0)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<SocialIncomeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            SocialIncomeTarget evalTarget = resTarget.Value;

            var incomeList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Contract.Equals(evalTarget.Contract) && v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((tr) => (tr.ResultValue)).ToArray();

            decimal resValue = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            ITermResult resultsValues = new SocialIncomeResult(target, spec, RoundingInt.RoundToInt(resValue), 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // SocialBase			SOCIAL_BASE
    class SocialBaseConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_BASE;
        public SocialBaseConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialBaseConSpec(this.Code.Value);
        }
    }

    class SocialBaseConSpec : PayrolexConceptSpec
    {
        public SocialBaseConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_INCOME,
                (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_DECLARE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract)))) == false).ToArray();

            return ter.Select((t) => (new SocialBaseTarget(month, t.Contract, pos, var, article, this.Code, 0)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<SocialBaseTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            SocialBaseTarget evalTarget = resTarget.Value;

            var resDeclare = GetContractResult<SocialDeclareResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_DECLARE));
            var resIncomes = GetContractResult<SocialIncomeResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_INCOME));

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
                resGeneralBase = evalIncomes.ResultValue;
            }

            ITermResult resultsValues = new SocialBaseResult(target, spec,
                evalTarget.AnnuityBase, resGeneralBase, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // SocialBaseEmployee			SOCIAL_BASE_EMPLOYEE
    class SocialBaseEmployeeConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_BASE_EMPLOYEE;
        public SocialBaseEmployeeConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialBaseEmployeeConSpec(this.Code.Value);
        }
    }

    class SocialBaseEmployeeConSpec : PayrolexConceptSpec
    {
        public SocialBaseEmployeeConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract)))) == false).ToArray();

            return ter.Select((t) => (new SocialBaseEmployeeTarget(month, t.Contract, pos, var, article, this.Code, 0)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<SocialBaseEmployeeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            SocialBaseEmployeeTarget evalTarget = resTarget.Value;

            Int32 resBasis = 0;

            ITermResult resultsValues = new SocialBaseEmployeeResult(target, spec, resBasis, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // SocialBaseEmployer			SOCIAL_BASE_EMPLOYER
    class SocialBaseEmployerConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_BASE_EMPLOYER;
        public SocialBaseEmployerConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialBaseEmployerConSpec(this.Code.Value);
        }
    }

    class SocialBaseEmployerConSpec : PayrolexConceptSpec
    {
        public SocialBaseEmployerConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract)))) == false).ToArray();

            return ter.Select((t) => (new SocialBaseEmployerTarget(month, t.Contract, pos, var, article, this.Code, 0)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<SocialBaseEmployerTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            SocialBaseEmployerTarget evalTarget = resTarget.Value;

            Int32 resBasis = 0;

            ITermResult resultsValues = new SocialBaseEmployerResult(target, spec, resBasis, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // SocialBaseOvercap			SOCIAL_BASE_OVERCAP
    class SocialBaseOvercapConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_BASE_OVERCAP;
        public SocialBaseOvercapConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialBaseOvercapConSpec(this.Code.Value);
        }
    }

    class SocialBaseOvercapConSpec : PayrolexConceptSpec
    {
        public SocialBaseOvercapConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE,
                (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_DECLARE,
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
                new SocialBaseOvercapTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSocial = GetSocialPropsResult(ruleset, target, period);
            if (resPrSocial.IsFailure)
            {
                return BuildFailResults(resPrSocial.Error);
            }
            IPropsSocial socialRules = resPrSocial.Value;

            Int32 maxAnnualsBasis = socialRules.MaxAnnualsBasis;

            var resTarget = GetTypedTarget<SocialBaseOvercapTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            SocialBaseOvercapTarget evalTarget = resTarget.Value;

            var incomeContractList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE))
                .Select((tr) => (tr.Contract, tr.ResultValue)).ToArray();

            var incomeResultInit = Array.Empty<SocialBaseOvercapResult>();
            var incomeResultList = incomeContractList.Aggregate(incomeResultInit, (agr, x) =>
            {
                var resSocialDeclare = GetContractResult<SocialDeclareResult>(target, period, results,
                    x.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_DECLARE));

                if (resSocialDeclare.IsFailure)
                {
                    return agr;
                }

                var evalSocialDeclare = resSocialDeclare.Value;

                var evalSubjectsType = evalSocialDeclare.ContractType;

                var contractResult = agr.FirstOrDefault((a) => (a.Contract.Equals(x.Contract)));
                if (contractResult == null)
                {
                    contractResult = new SocialBaseOvercapResult(evalTarget, x.Contract, spec,
                        evalSubjectsType, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY);
                    agr = agr.Concat(new SocialBaseOvercapResult[] { contractResult }).ToArray();
                }
                contractResult.AddResultBasis(x.ResultValue);
                return agr;
            });

            var incomeOrdersList = incomeResultList.OrderBy((x) => new SocialBaseOvercapComparator()).ToArray();

            Int32 perAnnuityBasis = 0;
            Int32 perAnnualsBasis = Math.Max(0, maxAnnualsBasis - perAnnuityBasis);
            var resultOrdersInit = new Tuple<Int32, Int32, SocialBaseOvercapResult[]>(
                maxAnnualsBasis, perAnnualsBasis, Array.Empty<SocialBaseOvercapResult>());

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

                        return new Tuple<Int32, Int32, SocialBaseOvercapResult[]>(
                            agr.Item1, remAnnualsBasis, agr.Item3.Concat(new SocialBaseOvercapResult[] { x }).ToArray());
                    }
                    return new Tuple<Int32, Int32, SocialBaseOvercapResult[]>(agr.Item1, agr.Item2, agr.Item3);
                });

            return BuildOkResults(resultOrdersList.Item3);
        }
        private class SocialBaseOvercapComparator : IComparer<SocialBaseOvercapResult>
        {
            public SocialBaseOvercapComparator()
            {
            }

            public int Compare(SocialBaseOvercapResult x, SocialBaseOvercapResult y)
            {
                Int32 xIncomeScore = x.IncomeScore();
                Int32 yIncomeScore = y.IncomeScore();

                return xIncomeScore.CompareTo(yIncomeScore);
            }
        }
    }

    // SocialPaymEmployee			SOCIAL_PAYM_EMPLOYEE
    class SocialPaymEmployeeConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_PAYM_EMPLOYEE;
        public SocialPaymEmployeeConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialPaymEmployeeConSpec(this.Code.Value);
        }
    }

    class SocialPaymEmployeeConSpec : PayrolexConceptSpec
    {
        public SocialPaymEmployeeConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_OVERCAP,
                (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_EMPLOYEE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract)))) == false).ToArray();

            return ter.Select((t) => (new SocialPaymEmployeeTarget(month, t.Contract, pos, var, article, this.Code, 0)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSocial = GetSocialPropsResult(ruleset, target, period);
            if (resPrSocial.IsFailure)
            {
                return BuildFailResults(resPrSocial.Error);
            }
            IPropsSocial socialRules = resPrSocial.Value;

            decimal factorEmployee = OperationsDec.Divide(socialRules.FactorEmployee, 100);

            var resTarget = GetTypedTarget<SocialPaymEmployeeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            SocialPaymEmployeeTarget evalTarget = resTarget.Value;

            var resBaseVal = GetContractResult<SocialBaseResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE));

            if (resBaseVal.IsFailure)
            {
                return BuildFailResults(resBaseVal.Error);
            }

            var evalBaseVal = resBaseVal.Value;

            Int32 valBaseGenerals = evalBaseVal.ResultValue;

            Int32 valBaseEmployee = 0;
            Int32 valBaseOvercaps = 0;
            var resBaseEmployee = GetContractResult<SocialBaseEmployeeResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_EMPLOYEE));

            if (resBaseEmployee.IsSuccess)
            {
                valBaseEmployee = resBaseEmployee.Value.ResultValue;
            }

            var resBaseOvercaps = GetContractResult<SocialBaseOvercapResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_OVERCAP));

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

            Int32 compoundBasis = valBaseEmployee + valBaseGenerals;

            Int32 employeePayment = OperationsSocial.IntInsuranceRoundUp(OperationsDec.Multiply(compoundBasis, factorEmployee));

            ITermResult resultsValues = new SocialPaymEmployeeResult(target, spec, valBaseEmployee, valBaseGenerals, employeePayment, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // SocialPaymEmployer			SOCIAL_PAYM_EMPLOYER
    class SocialPaymEmployerConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_PAYM_EMPLOYER;
        public SocialPaymEmployerConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialPaymEmployerConSpec(this.Code.Value);
        }
    }

    class SocialPaymEmployerConSpec : PayrolexConceptSpec
    {
        public SocialPaymEmployerConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_OVERCAP,
                (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_EMPLOYER,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract)))) == false).ToArray();

            return ter.Select((t) => (new SocialPaymEmployerTarget(month, t.Contract, pos, var, article, this.Code, 0)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrSocial = GetSocialPropsResult(ruleset, target, period);
            if (resPrSocial.IsFailure)
            {
                return BuildFailResults(resPrSocial.Error);
            }
            IPropsSocial socialRules = resPrSocial.Value;

            decimal factorEmployer = OperationsDec.Divide(socialRules.FactorEmployer, 100);

            var resTarget = GetTypedTarget<SocialPaymEmployerTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            SocialPaymEmployerTarget evalTarget = resTarget.Value;

            var resBaseVal = GetContractResult<SocialBaseResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE));

            if (resBaseVal.IsFailure)
            {
                return BuildFailResults(resBaseVal.Error);
            }

            var evalBaseVal = resBaseVal.Value;

            Int32 valBaseGenerals = evalBaseVal.ResultValue;

            Int32 valBaseEmployee = 0;
            Int32 valBaseEmployer = 0;
            Int32 valBaseOvercaps = 0;
            var resBaseEmployee = GetContractResult<SocialBaseEmployeeResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_EMPLOYEE));

            if (resBaseEmployee.IsSuccess)
            {
                valBaseEmployee = resBaseEmployee.Value.ResultValue;
            }
            var resBaseEmployer = GetContractResult<SocialBaseEmployerResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_EMPLOYER));

            if (resBaseEmployer.IsSuccess)
            {
                valBaseEmployer = resBaseEmployer.Value.ResultValue;
            }

            var resBaseOvercaps = GetContractResult<SocialBaseOvercapResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_OVERCAP));

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

            Int32 compoundBasis = valBaseEmployer + valBaseGenerals;

            Int32 employerPayment = OperationsSocial.IntInsuranceRoundUp(OperationsDec.Multiply(compoundBasis, factorEmployer));

            ITermResult resultsValues = new SocialPaymEmployerResult(target, spec, valBaseEmployer, valBaseGenerals, employerPayment, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

}
