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
    // TaxingDeclare			TAXING_DECLARE
    class TaxingDeclareConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_DECLARE;
        public TaxingDeclareConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingDeclareConSpec(this.Code.Value);
        }
    }

    class TaxingDeclareConSpec : PayrolexConceptSpec
    {
        public TaxingDeclareConSpec(Int32 code) : base(code)
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

            return ter.Select((t) => (new TaxingDeclareTarget(month, t.Contract, pos, var, article, this.Code, 1, WorkTaxingTerms.TAXING_TERM_BY_CONTRACT)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<TaxingDeclareTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingDeclareTarget evalTarget = resTarget.Value;

            var resContract = GetContractResult<ContractWorkTermResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_CONTRACT_WORK_TERM));

            if (resContract.IsFailure)
            {
                return BuildFailResults(resContract.Error);
            }

            var evalContract = resContract.Value;

            var evalContractType = evalTarget.ContractType;

            if (evalContractType == WorkTaxingTerms.TAXING_TERM_BY_CONTRACT)
            {
                switch (evalContract.TermType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        evalContractType = WorkTaxingTerms.TAXING_TERM_EMPLOYMENTS;
                        break;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        evalContractType = WorkTaxingTerms.TAXING_TERM_EMPLOYMENTS;
                        break;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        evalContractType = WorkTaxingTerms.TAXING_TERM_AGREEM_TASK;
                        break;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        evalContractType = WorkTaxingTerms.TAXING_TERM_STATUT_PART;
                        break;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        evalContractType = WorkTaxingTerms.TAXING_TERM_EMPLOYMENTS;
                        break;
                }
            }
            ITermResult resultsValues = new TaxingDeclareResult(target, spec, 
                evalTarget.InterestCode, evalContractType);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingSigning			TAXING_SIGNING
    class TaxingSigningConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_SIGNING;
        public TaxingSigningConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingSigningConSpec(this.Code.Value);
        }
    }

    class TaxingSigningConSpec : PayrolexConceptSpec
    {
        public TaxingSigningConSpec(Int32 code) : base(code)
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
                new TaxingSigningTarget(month, con, pos, var, article, this.Code, TaxDeclSignOption.DECL_TAX_DO_SIGNED, TaxNoneSignOption.NOSIGN_TAX_WITHHOLD),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<TaxingSigningTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingSigningTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new TaxingSigningResult(target, spec, 
                evalTarget.DeclSignOpts, evalTarget.NoneSignOpts);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingIncomeSubject			TAXING_INCOME_SUBJECT
    class TaxingIncomeSubjectConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_INCOME_SUBJECT;
        public TaxingIncomeSubjectConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingIncomeSubjectConSpec(this.Code.Value);
        }
    }

    class TaxingIncomeSubjectConSpec : PayrolexConceptSpec
    {
        public TaxingIncomeSubjectConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_DECLARE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var pos = PositionCode.Zero;

            var ter = conTerms.Where((t) => (targets.Any((x) => (x.Contract.Equals(t.Contract)))) == false).ToArray();

            return ter.Select((t) => (new TaxingIncomeSubjectTarget(month, t.Contract, pos, var, article, this.Code, WorkTaxingTerms.TAXING_TERM_BY_CONTRACT)));
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<TaxingIncomeSubjectTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingIncomeSubjectTarget evalTarget = resTarget.Value;

            var resTaxDeclare = GetContractResult<TaxingDeclareResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_DECLARE));

            if (resTaxDeclare.IsFailure)
            {
                return BuildFailResults(resTaxDeclare.Error);
            }

            var evalTaxDeclare = resTaxDeclare.Value;

            var evalSubjectsType = evalTaxDeclare.ContractType;

            var incomeList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Contract.Equals(evalTarget.Contract) && v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((tr) => (tr.ResultValue)).ToArray();

            decimal incomeSum = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 incomeRes = RoundingInt.RoundToInt(incomeSum);

            ITermResult resultsValues = new TaxingIncomeSubjectResult(target, spec,
                evalSubjectsType, incomeRes, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingIncomeHealth			TAXING_INCOME_HEALTH
    class TaxingIncomeHealthConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_INCOME_HEALTH;
        public TaxingIncomeHealthConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingIncomeHealthConSpec(this.Code.Value);
        }
    }

    class TaxingIncomeHealthConSpec : PayrolexConceptSpec
    {
        public TaxingIncomeHealthConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_DECLARE,
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
                new TaxingIncomeHealthTarget(month, con, pos, var, article, this.Code),
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

            var resTarget = GetTypedTarget<TaxingIncomeHealthTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingIncomeHealthTarget evalTarget = resTarget.Value;

            var incomeContractList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((tr) => (tr.Contract, tr.ResultValue)).ToArray();

            var incomeResultInit = Array.Empty<TaxingIncomeHealthResult>();
            var incomeResultList = incomeContractList.Aggregate(incomeResultInit, (agr, x) =>
            {
                var resTaxDeclare = GetContractResult<TaxingDeclareResult>(target, period, results,
                    x.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_DECLARE));

                if (resTaxDeclare.IsFailure)
                {
                    return agr;
                }

                var evalTaxDeclare = resTaxDeclare.Value;

                var evalSubjectsType = evalTaxDeclare.ContractType;

                var contractResult = agr.FirstOrDefault((a) => (a.Contract.Equals(x.Contract)));
                if (contractResult == null)
                {
                    contractResult = new TaxingIncomeHealthResult(evalTarget, x.Contract, spec,
                        evalSubjectsType, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY);
                    agr = agr.Concat(new TaxingIncomeHealthResult[] { contractResult }).ToArray();
                }
                contractResult.AddResultBasis(x.ResultValue);
                return agr;
            });

            var incomeOrdersList = incomeResultList.OrderBy((x) => new TaxingIncomeHealthComparator()).ToArray();

            Int32 perAnnuityBasis = 0;
            Int32 perAnnualsBasis = Math.Max(0, maxAnnualsBasis - perAnnuityBasis);
            var resultOrdersInit = new Tuple<Int32, Int32, TaxingIncomeHealthResult[]>(
                maxAnnualsBasis, perAnnualsBasis, Array.Empty<TaxingIncomeHealthResult>());

            var resultOrdersList = incomeOrdersList.Aggregate(resultOrdersInit,
                (agr, x) => {
                    Int32 cutAnnualsBasis = x.ResultBasis;
                    if (agr.Item1 > 0)
                    {
                        var ovrAnnualsBasis = Math.Max(0, x.ResultBasis - agr.Item2);
                        cutAnnualsBasis = (x.ResultBasis - ovrAnnualsBasis);
                    }

                    Int32 remAnnualsBasis = Math.Max(0, (agr.Item2 - cutAnnualsBasis));

                    x.SetResultValue(cutAnnualsBasis);
                    return new Tuple<Int32, Int32, TaxingIncomeHealthResult[]>(
                        agr.Item1, remAnnualsBasis, agr.Item3.Concat(new TaxingIncomeHealthResult[] { x }).ToArray());
                });

            return BuildOkResults(resultOrdersList.Item3);
        }
        private class TaxingIncomeHealthComparator : IComparer<TaxingIncomeHealthResult>
        {
            public TaxingIncomeHealthComparator()
            {
            }

            public int Compare(TaxingIncomeHealthResult x, TaxingIncomeHealthResult y)
            {
                Int32 xIncomeScore = x.IncomeScore();
                Int32 yIncomeScore = y.IncomeScore();

                return xIncomeScore.CompareTo(yIncomeScore);
            }
        }
    }

    // TaxingIncomeSocial			TAXING_INCOME_SOCIAL
    class TaxingIncomeSocialConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_INCOME_SOCIAL;
        public TaxingIncomeSocialConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingIncomeSocialConSpec(this.Code.Value);
        }
    }

    class TaxingIncomeSocialConSpec : PayrolexConceptSpec
    {
        public TaxingIncomeSocialConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_DECLARE,
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
                new TaxingIncomeSocialTarget(month, con, pos, var, article, this.Code),
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

            var resTarget = GetTypedTarget<TaxingIncomeSocialTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingIncomeSocialTarget evalTarget = resTarget.Value;

            var incomeContractList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((tr) => (tr.Contract, tr.ResultValue)).ToArray();

            var incomeResultInit = Array.Empty<TaxingIncomeSocialResult>();
            var incomeResultList = incomeContractList.Aggregate(incomeResultInit, (agr, x) =>
            {
                var resTaxDeclare = GetContractResult<TaxingDeclareResult>(target, period, results,
                    x.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_DECLARE));

                if (resTaxDeclare.IsFailure)
                {
                    return agr;
                }

                var evalTaxDeclare = resTaxDeclare.Value;

                var evalSubjectsType = evalTaxDeclare.ContractType;

                var contractResult = agr.FirstOrDefault((a) => (a.Contract.Equals(x.Contract)));
                if (contractResult == null)
                {
                    contractResult = new TaxingIncomeSocialResult(evalTarget, x.Contract, spec,
                        evalSubjectsType, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY);
                    agr = agr.Concat(new TaxingIncomeSocialResult[] { contractResult }).ToArray();
                }
                contractResult.AddResultBasis(x.ResultValue);
                return agr;
            });

            var incomeOrdersList = incomeResultList.OrderBy((x) => new TaxingIncomeSocialComparator()).ToArray();

            Int32 perAnnuityBasis = 0;
            Int32 perAnnualsBasis = Math.Max(0, maxAnnualsBasis - perAnnuityBasis);
            var resultOrdersInit = new Tuple<Int32, Int32, TaxingIncomeSocialResult[]>(
               maxAnnualsBasis, perAnnualsBasis, Array.Empty<TaxingIncomeSocialResult>());

            var resultOrdersList = incomeOrdersList.Aggregate(resultOrdersInit,
                (agr, x) => {
                    Int32 cutAnnualsBasis = x.ResultBasis;
                    if (agr.Item1 > 0)
                    {
                        var ovrAnnualsBasis = Math.Max(0, x.ResultBasis - agr.Item2);
                        cutAnnualsBasis = (x.ResultBasis - ovrAnnualsBasis);
                    }

                    Int32 remAnnualsBasis = Math.Max(0, (agr.Item2 - cutAnnualsBasis));

                    x.SetResultValue(cutAnnualsBasis);
                    return new Tuple<Int32, Int32, TaxingIncomeSocialResult[]>(
                        agr.Item1, remAnnualsBasis, agr.Item3.Concat(new TaxingIncomeSocialResult[] { x }).ToArray());
                });

            return BuildOkResults(resultOrdersList.Item3);
        }
        private class TaxingIncomeSocialComparator : IComparer<TaxingIncomeSocialResult>
        {
            public TaxingIncomeSocialComparator()
            {
            }

            public int Compare(TaxingIncomeSocialResult x, TaxingIncomeSocialResult y)
            {
                Int32 xIncomeScore = x.IncomeScore();
                Int32 yIncomeScore = y.IncomeScore();

                return xIncomeScore.CompareTo(yIncomeScore);
            }
        }
    }

    // TaxingAdvancesIncome			TAXING_ADVANCES_INCOME
    class TaxingAdvancesIncomeConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ADVANCES_INCOME;
        public TaxingAdvancesIncomeConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            //*****************************************************************************
            // Tax income for advance from Year 2008 to Year 2013
            //*****************************************************************************
            // - withhold tax (non-signed declaration) and income is less than X CZK
            //*****************************************************************************
            // Tax income for advance from Year 2014 to Year 2017
            //*****************************************************************************
            // - withhold tax (non-signed declaration) and income
            // -- income from DPP is less than X CZK
            // -- income from low-income employment is less than X CZK
            // -- income from statutory employment and non-resident is always withhold tax

            return new TaxingAdvancesIncomeConSpec(this.Code.Value);
            // if (period.Year < 2014)
            // if (period.Year > 2013 && period.Year < 2018)
            // else
        }
    }

    class TaxingAdvancesIncomeConSpec : PayrolexConceptSpec
    {
        public TaxingAdvancesIncomeConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_SIGNING,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_HEALTH,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SOCIAL,
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
                new TaxingAdvancesIncomeTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            Int32 withholdMarginIncome = taxingRules.MarginIncomeOfWithhold;

            var resTarget = GetTypedTarget<TaxingAdvancesIncomeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingAdvancesIncomeTarget evalTarget = resTarget.Value;

            var resTaxSigning = GetContractResult<TaxingSigningResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_SIGNING));

            if (resTaxSigning.IsFailure)
            {
                return BuildFailResults(resTaxSigning.Error);
            }

            var evalTaxSigning = resTaxSigning.Value;

            var evalDeclSignOpts = evalTaxSigning.DeclSignOpts;
            var evalNoneSignOpts = evalTaxSigning.NoneSignOpts;

            var incomeList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value==(Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT))
               .Select((x) => (x as TaxingIncomeSubjectResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal incomeSum = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 incomeRes = RoundingInt.RoundToInt(incomeSum);

            Int32 resValue = 0;
            if (evalDeclSignOpts == TaxDeclSignOption.DECL_TAX_DO_SIGNED)
            {
                resValue = incomeRes;
            }
            else if (evalDeclSignOpts == TaxDeclSignOption.DECL_TAX_NO_SIGNED)
            {
                if (evalNoneSignOpts == TaxNoneSignOption.NOSIGN_TAX_ADVANCES)
                {
                    resValue = incomeRes;
                }
                else if (evalNoneSignOpts == TaxNoneSignOption.NOSIGN_TAX_WITHHOLD)
                {
                    if (withholdMarginIncome == 0 || incomeRes > withholdMarginIncome)
                    {
                        resValue = incomeRes;
                    }
                }
            }
            ITermResult resultsValues = new TaxingAdvancesIncomeResult(target, spec,
                resValue, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingAdvancesHealth			TAXING_ADVANCES_HEALTH
    class TaxingAdvancesHealthConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ADVANCES_HEALTH;
        public TaxingAdvancesHealthConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvancesHealthConSpec(this.Code.Value);
        }
    }

    class TaxingAdvancesHealthConSpec : PayrolexConceptSpec
    {
        public TaxingAdvancesHealthConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_SIGNING,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_HEALTH,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SOCIAL,
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
                new TaxingAdvancesHealthTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            Int32 withholdMarginIncome = taxingRules.MarginIncomeOfWithhold;

            var resPrHealth = GetHealthPropsResult(ruleset, target, period);
            if (resPrHealth.IsFailure)
            {
                return BuildFailResults(resPrHealth.Error);
            }
            IPropsHealth healthRules = resPrHealth.Value;

            decimal factorCompound = OperationsDec.Divide(healthRules.FactorCompound, 100);
            decimal factorEmployee = healthRules.FactorEmployee;

            var resTarget = GetTypedTarget<TaxingAdvancesHealthTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingAdvancesHealthTarget evalTarget = resTarget.Value;

            var resTaxSigning = GetContractResult<TaxingSigningResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_SIGNING));

            if (resTaxSigning.IsFailure)
            {
                return BuildFailResults(resTaxSigning.Error);
            }

            var evalTaxSigning = resTaxSigning.Value;

            var evalDeclSignOpts = evalTaxSigning.DeclSignOpts;
            var evalNoneSignOpts = evalTaxSigning.NoneSignOpts;

            var incomeList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT))
               .Select((x) => (x as TaxingIncomeSubjectResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal incomeSum = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 incomeRes = RoundingInt.RoundToInt(incomeSum);

            var healthList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_HEALTH))
               .Select((x) => (x as TaxingIncomeHealthResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal healthSum = healthList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 healthRes = RoundingInt.RoundToInt(healthSum);

            Int32 baseValue = 0;
            if (evalDeclSignOpts == TaxDeclSignOption.DECL_TAX_DO_SIGNED)
            {
                baseValue = healthRes;
            }
            else if (evalDeclSignOpts == TaxDeclSignOption.DECL_TAX_NO_SIGNED)
            {
                if (evalNoneSignOpts == TaxNoneSignOption.NOSIGN_TAX_ADVANCES)
                {
                    baseValue = healthRes;
                }
                else if (evalNoneSignOpts == TaxNoneSignOption.NOSIGN_TAX_WITHHOLD)
                {
                    if (withholdMarginIncome == 0 || incomeRes > withholdMarginIncome)
                    {
                        baseValue = healthRes;
                    }
                }
            }

            Int32 compoundPayment = OperationsHealth.IntInsuranceRoundUp(OperationsDec.Multiply(baseValue, factorCompound));
            Int32 employeePayment = OperationsHealth.IntInsuranceRoundUp(OperationsDec.MultiplyAndDivide(baseValue, factorCompound, factorEmployee));
            Int32 employerPayment = Math.Max(0, compoundPayment - employeePayment);

            ITermResult resultsValues = new TaxingAdvancesHealthResult(target, spec,
                employerPayment, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingAdvancesSocial			TAXING_ADVANCES_SOCIAL
    class TaxingAdvancesSocialConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ADVANCES_SOCIAL;
        public TaxingAdvancesSocialConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvancesSocialConSpec(this.Code.Value);
        }
    }

    class TaxingAdvancesSocialConSpec : PayrolexConceptSpec
    {
        public TaxingAdvancesSocialConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_SIGNING,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_HEALTH,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SOCIAL,
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
                new TaxingAdvancesSocialTarget(month, con, pos, var, article, this.Code, 0),
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

            decimal factorEmployer = OperationsDec.Divide(socialRules.FactorEmployer, 100);

            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            Int32 withholdMarginIncome = taxingRules.MarginIncomeOfWithhold;

            var resTarget = GetTypedTarget<TaxingAdvancesSocialTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingAdvancesSocialTarget evalTarget = resTarget.Value;

            var resTaxSigning = GetContractResult<TaxingSigningResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_SIGNING));

            if (resTaxSigning.IsFailure)
            {
                return BuildFailResults(resTaxSigning.Error);
            }

            var evalTaxSigning = resTaxSigning.Value;

            var evalDeclSignOpts = evalTaxSigning.DeclSignOpts;
            var evalNoneSignOpts = evalTaxSigning.NoneSignOpts;

            var incomeList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT))
               .Select((x) => (x as TaxingIncomeSubjectResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal incomeSum = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 incomeRes = RoundingInt.RoundToInt(incomeSum);

            var socialList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SOCIAL))
               .Select((x) => (x as TaxingIncomeSocialResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal socialSum = socialList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 socialRes = RoundingInt.RoundToInt(socialSum);

            Int32 baseValue = 0;
            if (evalDeclSignOpts == TaxDeclSignOption.DECL_TAX_DO_SIGNED)
            {
                baseValue = socialRes;
            }
            else if (evalDeclSignOpts == TaxDeclSignOption.DECL_TAX_NO_SIGNED)
            {
                if (evalNoneSignOpts == TaxNoneSignOption.NOSIGN_TAX_ADVANCES)
                {
                    baseValue = socialRes;
                }
                else if (evalNoneSignOpts == TaxNoneSignOption.NOSIGN_TAX_WITHHOLD)
                {
                    if (withholdMarginIncome == 0 || incomeRes > withholdMarginIncome)
                    {
                        baseValue = socialRes;
                    }
                }
            }

            Int32 employerPayment = OperationsSocial.IntInsuranceRoundUp(OperationsDec.Multiply(baseValue, factorEmployer));

            ITermResult resultsValues = new TaxingAdvancesSocialResult(target, spec,
                employerPayment, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingAdvancesBasis			TAXING_ADVANCES_BASIS
    class TaxingAdvancesBasisConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ADVANCES_BASIS;
        public TaxingAdvancesBasisConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvancesBasisConSpec(this.Code.Value);
        }
    }

    class TaxingAdvancesBasisConSpec : PayrolexConceptSpec
    {
        public TaxingAdvancesBasisConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_DECLARE,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_INCOME,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_HEALTH,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_SOCIAL,
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
                new TaxingAdvancesBasisTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            Int32 marginIncomeOfRounding = taxingRules.MarginIncomeOfRounding;

            var resTarget = GetTypedTarget<TaxingAdvancesBasisTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingAdvancesBasisTarget evalTarget = resTarget.Value;

            var incomeList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_INCOME))
               .Select((x) => (x as TaxingAdvancesIncomeResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal incomeSum = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 incomeRes = RoundingInt.RoundToInt(incomeSum);

            var healthList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_HEALTH))
               .Select((x) => (x as TaxingAdvancesHealthResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal healthSum = healthList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 healthRes = RoundingInt.RoundToInt(healthSum);

            var socialList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_SOCIAL))
               .Select((x) => (x as TaxingAdvancesSocialResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal socialSum = socialList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 socialRes = RoundingInt.RoundToInt(socialSum);

            Int32 taxableSuper = incomeRes + healthRes + socialRes;

            Int32 advancesBase = TaxAdvancesRoundedBase(taxingRules, taxableSuper);

            ITermResult resultsValues = new TaxingAdvancesBasisResult(target, spec, advancesBase, taxableSuper, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }

        private int TaxAdvancesRoundedBase(IPropsTaxing taxingRules, Int32 taxableSuper)
        {
            Int32 marginIncomeOfRounding = taxingRules.MarginIncomeOfRounding;

            Int32 advanceBase = 0;
            Int32 amountForCalc = Math.Max(0, taxableSuper);
            if (amountForCalc > marginIncomeOfRounding)
            {
                advanceBase = OperationsTaxing.IntTaxRoundNearUp(amountForCalc, 100);
            }
            else
            {
                advanceBase = OperationsTaxing.IntTaxRoundUp(amountForCalc);
            }

            return advanceBase;
        }
    }

    // TaxingSolidaryBasis			TAXING_SOLIDARY_BASIS
    class TaxingSolidaryBasisConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_SOLIDARY_BASIS;
        public TaxingSolidaryBasisConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingSolidaryBasisConSpec(this.Code.Value);
        }
    }

    class TaxingSolidaryBasisConSpec : PayrolexConceptSpec
    {
        public TaxingSolidaryBasisConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_BASIS,
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
                new TaxingSolidaryBasisTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<TaxingSolidaryBasisTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingSolidaryBasisTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new TaxingSolidaryBasisResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingAdvances			TAXING_ADVANCES
    class TaxingAdvancesConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ADVANCES;
        public TaxingAdvancesConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvancesConSpec(this.Code.Value);
        }
    }

    class TaxingAdvancesConSpec : PayrolexConceptSpec
    {
        public TaxingAdvancesConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_BASIS,
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
                new TaxingAdvancesTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<TaxingAdvancesTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingAdvancesTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new TaxingAdvancesResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingSolidary			TAXING_SOLIDARY
    class TaxingSolidaryConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_SOLIDARY;
        public TaxingSolidaryConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingSolidaryConSpec(this.Code.Value);
        }
    }

    class TaxingSolidaryConSpec : PayrolexConceptSpec
    {
        public TaxingSolidaryConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_SOLIDARY_BASIS,
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
                new TaxingSolidaryTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<TaxingSolidaryTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingSolidaryTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new TaxingSolidaryResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingAdvancesTotal			TAXING_ADVANCES_TOTAL
    class TaxingAdvancesTotalConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ADVANCES_TOTAL;
        public TaxingAdvancesTotalConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvancesTotalConSpec(this.Code.Value);
        }
    }

    class TaxingAdvancesTotalConSpec : PayrolexConceptSpec
    {
        public TaxingAdvancesTotalConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_SOLIDARY,
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
                new TaxingAdvancesTotalTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<TaxingAdvancesTotalTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingAdvancesTotalTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new TaxingAdvancesTotalResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingWithholdIncome			TAXING_WITHHOLD_INCOME
    class TaxingWithholdIncomeConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_WITHHOLD_INCOME;
        public TaxingWithholdIncomeConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingWithholdIncomeConSpec(this.Code.Value);
        }
    }

    class TaxingWithholdIncomeConSpec : PayrolexConceptSpec
    {
        public TaxingWithholdIncomeConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_SIGNING,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_HEALTH,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SOCIAL,
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
                new TaxingWithholdIncomeTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            Int32 withholdMarginIncome = taxingRules.MarginIncomeOfWithhold;

            var resTarget = GetTypedTarget<TaxingWithholdIncomeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingWithholdIncomeTarget evalTarget = resTarget.Value;

            var resTaxSigning = GetContractResult<TaxingSigningResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_SIGNING));

            if (resTaxSigning.IsFailure)
            {
                return BuildFailResults(resTaxSigning.Error);
            }

            var evalTaxSigning = resTaxSigning.Value;

            var evalDeclSignOpts = evalTaxSigning.DeclSignOpts;
            var evalNoneSignOpts = evalTaxSigning.NoneSignOpts;

            var incomeList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT))
               .Select((x) => (x as TaxingIncomeSubjectResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal incomeSum = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 incomeRes = RoundingInt.RoundToInt(incomeSum);

            Int32 resValue = 0;
            if (evalDeclSignOpts == TaxDeclSignOption.DECL_TAX_NO_SIGNED)
            {
                if (evalNoneSignOpts == TaxNoneSignOption.NOSIGN_TAX_WITHHOLD)
                {
                    if (withholdMarginIncome > 0 && incomeRes <= withholdMarginIncome)
                    {
                        resValue = incomeRes;
                    }
                }
            }
            ITermResult resultsValues = new TaxingWithholdIncomeResult(target, spec,
                resValue, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingWithholdHealth			TAXING_WITHHOLD_HEALTH
    class TaxingWithholdHealthConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_WITHHOLD_HEALTH;
        public TaxingWithholdHealthConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingWithholdHealthConSpec(this.Code.Value);
        }
    }

    class TaxingWithholdHealthConSpec : PayrolexConceptSpec
    {
        public TaxingWithholdHealthConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_SIGNING,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_HEALTH,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SOCIAL,
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
                new TaxingWithholdHealthTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            Int32 withholdMarginIncome = taxingRules.MarginIncomeOfWithhold;

            var resPrHealth = GetHealthPropsResult(ruleset, target, period);
            if (resPrHealth.IsFailure)
            {
                return BuildFailResults(resPrHealth.Error);
            }
            IPropsHealth healthRules = resPrHealth.Value;

            decimal factorCompound = OperationsDec.Divide(healthRules.FactorCompound, 100);
            decimal factorEmployee = healthRules.FactorEmployee;

            var resTarget = GetTypedTarget<TaxingWithholdHealthTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingWithholdHealthTarget evalTarget = resTarget.Value;

            var resTaxSigning = GetContractResult<TaxingSigningResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_SIGNING));

            if (resTaxSigning.IsFailure)
            {
                return BuildFailResults(resTaxSigning.Error);
            }

            var evalTaxSigning = resTaxSigning.Value;

            var evalDeclSignOpts = evalTaxSigning.DeclSignOpts;
            var evalNoneSignOpts = evalTaxSigning.NoneSignOpts;

            var incomeList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT))
               .Select((x) => (x as TaxingIncomeSubjectResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal incomeSum = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 incomeRes = RoundingInt.RoundToInt(incomeSum);

            var healthList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_HEALTH))
               .Select((x) => (x as TaxingIncomeHealthResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal healthSum = healthList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 healthRes = RoundingInt.RoundToInt(healthSum);

            Int32 baseValue = 0;
            if (evalDeclSignOpts == TaxDeclSignOption.DECL_TAX_NO_SIGNED)
            {
                if (evalNoneSignOpts == TaxNoneSignOption.NOSIGN_TAX_WITHHOLD)
                {
                    if (withholdMarginIncome > 0 && incomeRes <= withholdMarginIncome)
                    {
                        baseValue = incomeRes;
                    }
                }
            }

            Int32 compoundPayment = OperationsHealth.IntInsuranceRoundUp(OperationsDec.Multiply(baseValue, factorCompound));
            Int32 employeePayment = OperationsHealth.IntInsuranceRoundUp(OperationsDec.MultiplyAndDivide(baseValue, factorCompound, factorEmployee));
            Int32 employerPayment = Math.Max(0, compoundPayment - employeePayment);

            ITermResult resultsValues = new TaxingWithholdHealthResult(target, spec,
                employerPayment, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }

    }

    // TaxingWithholdSocial			TAXING_WITHHOLD_SOCIAL
    class TaxingWithholdSocialConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_WITHHOLD_SOCIAL;
        public TaxingWithholdSocialConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingWithholdSocialConSpec(this.Code.Value);
        }
    }

    class TaxingWithholdSocialConSpec : PayrolexConceptSpec
    {
        public TaxingWithholdSocialConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_SIGNING,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_HEALTH,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SOCIAL,
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
                new TaxingWithholdSocialTarget(month, con, pos, var, article, this.Code, 0),
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

            decimal factorEmployer = OperationsDec.Divide(socialRules.FactorEmployer, 100);

            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            Int32 withholdMarginIncome = taxingRules.MarginIncomeOfWithhold;

            var resTarget = GetTypedTarget<TaxingWithholdSocialTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingWithholdSocialTarget evalTarget = resTarget.Value;

            var resTaxSigning = GetContractResult<TaxingSigningResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_SIGNING));

            if (resTaxSigning.IsFailure)
            {
                return BuildFailResults(resTaxSigning.Error);
            }

            var evalTaxSigning = resTaxSigning.Value;

            var evalDeclSignOpts = evalTaxSigning.DeclSignOpts;
            var evalNoneSignOpts = evalTaxSigning.NoneSignOpts;

            var incomeList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT))
               .Select((x) => (x as TaxingIncomeSubjectResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal incomeSum = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 incomeRes = RoundingInt.RoundToInt(incomeSum);

            var socialList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SOCIAL))
               .Select((x) => (x as TaxingIncomeSocialResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal socialSum = socialList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 socialRes = RoundingInt.RoundToInt(socialSum);

            Int32 baseValue = 0;
            if (evalDeclSignOpts == TaxDeclSignOption.DECL_TAX_NO_SIGNED)
            {
                if (evalNoneSignOpts == TaxNoneSignOption.NOSIGN_TAX_WITHHOLD)
                {
                    if (withholdMarginIncome > 0 && incomeRes <= withholdMarginIncome)
                    {
                        baseValue = incomeRes;
                    }
                }
            }

            Int32 employerPayment = OperationsSocial.IntInsuranceRoundUp(OperationsDec.Multiply(baseValue, factorEmployer));

            ITermResult resultsValues = new TaxingWithholdSocialResult(target, spec, 
                employerPayment, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingWithholdBasis			TAXING_WITHHOLD_BASIS
    class TaxingWithholdBasisConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_WITHHOLD_BASIS;
        public TaxingWithholdBasisConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingWithholdBasisConSpec(this.Code.Value);
        }
    }

    class TaxingWithholdBasisConSpec : PayrolexConceptSpec
    {
        public TaxingWithholdBasisConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_INCOME,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_HEALTH,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_SOCIAL,
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
                new TaxingWithholdBasisTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<TaxingWithholdBasisTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingWithholdBasisTarget evalTarget = resTarget.Value;

            var incomeList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_INCOME))
               .Select((x) => (x as TaxingWithholdIncomeResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal incomeSum = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 incomeRes = RoundingInt.RoundToInt(incomeSum);

            var healthList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_HEALTH))
               .Select((x) => (x as TaxingWithholdHealthResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal healthSum = healthList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 healthRes = RoundingInt.RoundToInt(healthSum);

            var socialList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_SOCIAL))
               .Select((x) => (x as TaxingWithholdSocialResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal socialSum = socialList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 socialRes = RoundingInt.RoundToInt(socialSum);

            Int32 withholdBase = incomeRes + healthRes + socialRes;

            ITermResult resultsValues = new TaxingWithholdBasisResult(target, spec, withholdBase, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingWithholdTotal			TAXING_WITHHOLD_TOTAL
    class TaxingWithholdTotalConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_WITHHOLD_TOTAL;
        public TaxingWithholdTotalConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingWithholdTotalConSpec(this.Code.Value);
        }
    }

    class TaxingWithholdTotalConSpec : PayrolexConceptSpec
    {
        public TaxingWithholdTotalConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_BASIS,
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
                new TaxingWithholdTotalTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<TaxingWithholdTotalTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingWithholdTotalTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new TaxingWithholdTotalResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

}
