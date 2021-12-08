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

        private Int32 TaxAdvancesRoundedBase(IPropsTaxing taxingRules, Int32 taxableSuper)
        {
            Int32 marginIncomeOfRounding = taxingRules.MarginIncomeOfRounding;

            Int32 advanceBase = 0;
            Int32 amountForCalc = Math.Max(0, taxableSuper);
            if (amountForCalc <= marginIncomeOfRounding)
            {
                advanceBase = OperationsTaxing.IntTaxRoundUp(amountForCalc);
            }
            else
            {
                advanceBase = OperationsTaxing.IntTaxRoundNearUp(amountForCalc, 100);
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
            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            var resTarget = GetTypedTarget<TaxingSolidaryBasisTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingSolidaryBasisTarget evalTarget = resTarget.Value;

            var resBaseVal = GetContractResult<TaxingAdvancesBasisResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_BASIS));

            if (resBaseVal.IsFailure)
            {
                return BuildFailResults(resBaseVal.Error);
            }

            var evalBaseVal = resBaseVal.Value;

            Int32 taxableSuper = evalBaseVal.ResultBasis;

            Int32 solidaryBase = TaxSolidaryRoundedBase(taxingRules, taxableSuper);

            ITermResult resultsValues = new TaxingSolidaryBasisResult(target, spec, solidaryBase, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
        private Int32 TaxSolidaryRoundedBase(IPropsTaxing taxingRules, Int32 taxableSuper)
        {
            Int32 marginIncomeOfSolidary = taxingRules.MarginIncomeOfSolidary;
            Int32 marginIncomeOfRounding = taxingRules.MarginIncomeOfRounding;

            Int32 solidaryBase = 0;
            Int32 taxableIncome = Math.Max(0, taxableSuper);
            if (marginIncomeOfSolidary != 0)
            {
                solidaryBase = Math.Max(0, taxableIncome - marginIncomeOfSolidary);
            }
            return solidaryBase;
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
            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            var resTarget = GetTypedTarget<TaxingAdvancesTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingAdvancesTarget evalTarget = resTarget.Value;

            var resBaseVal = GetContractResult<TaxingAdvancesBasisResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_BASIS));

            if (resBaseVal.IsFailure)
            {
                return BuildFailResults(resBaseVal.Error);
            }

            var evalBaseVal = resBaseVal.Value;

            Int32 advanceSuper = evalBaseVal.ResultValue;

            Int32 advanceBasis = evalBaseVal.ResultValue;

            Int32 advancePaym = TaxAdvancesRoundedPaym(taxingRules, advanceSuper, advanceBasis);

            ITermResult resultsValues = new TaxingAdvancesResult(target, spec, advancePaym, advanceBasis, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
        private Int32 TaxAdvancesRoundedPaym(IPropsTaxing taxingRules, Int32 taxableIncome, Int32 taxableBasis)
        {
            Int32 marginIncomeOfRounding = taxingRules.MarginIncomeOfRounding;
            decimal factorAdvances = OperationsDec.Divide(taxingRules.FactorAdvances, 100);

            Int32 advanceTaxing = 0;
            if (taxableBasis <= marginIncomeOfRounding)
            {
                advanceTaxing = OperationsTaxing.IntTaxRoundUp(OperationsDec.Multiply(taxableBasis, factorAdvances));
            }
            else
            {
                advanceTaxing = OperationsTaxing.IntTaxRoundUp(OperationsDec.Multiply(taxableBasis, factorAdvances));
            }

            return advanceTaxing;
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
            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            var resTarget = GetTypedTarget<TaxingSolidaryTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingSolidaryTarget evalTarget = resTarget.Value;

            var resBaseVal = GetContractResult<TaxingSolidaryBasisResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_SOLIDARY_BASIS));

            if (resBaseVal.IsFailure)
            {
                return BuildFailResults(resBaseVal.Error);
            }

            var evalBaseVal = resBaseVal.Value;

            Int32 solidaryBasis = evalBaseVal.ResultValue;

            Int32 solidaryPaym = TaxSolidaryRoundedPaym(taxingRules, solidaryBasis);

            if (solidaryPaym != 0)
            {
                ITermResult resultsValues = new TaxingSolidaryResult(target, spec, solidaryPaym, 0, DESCRIPTION_EMPTY);

                return BuildOkResults(resultsValues);
            }
            return BuildEmptyResults();
        }
        private Int32 TaxSolidaryRoundedPaym(IPropsTaxing taxingRules, Int32 solidaryBasis)
        {
            Int32 marginIncomeOfSolidary = taxingRules.MarginIncomeOfSolidary;
            decimal factorSolidary = OperationsDec.Divide(taxingRules.FactorSolidary, 100);

            Int32 solidaryTaxing = 0;
            if (marginIncomeOfSolidary != 0)
            {
                solidaryTaxing = OperationsTaxing.IntTaxRoundUp(OperationsDec.Multiply(solidaryBasis, factorSolidary));
            }

            return solidaryTaxing;
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

            var advancesList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES))
               .Select((x) => (x as TaxingAdvancesResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal advancesSum = advancesList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 advancesTaxing = RoundingInt.RoundToInt(advancesSum);

            var solidaryList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_SOLIDARY))
               .Select((x) => (x as TaxingSolidaryResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal solidarySum = solidaryList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 solidaryTaxing = RoundingInt.RoundToInt(solidarySum);

            Int32 advancesTotals = (advancesTaxing + solidaryTaxing);

            ITermResult resultsValues = new TaxingAdvancesTotalResult(target, spec, advancesTotals, 0, DESCRIPTION_EMPTY);

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
            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

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

            Int32 taxableSuper = incomeRes + healthRes + socialRes;

            Int32 withholdBase = TaxWithholdRoundedBase(taxingRules, taxableSuper);

            ITermResult resultsValues = new TaxingWithholdBasisResult(target, spec, withholdBase, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
        private Int32 TaxWithholdRoundedBase(IPropsTaxing taxingRules, Int32 taxableSuper)
        {
            Int32 amountForCalc = Math.Max(0, taxableSuper);
            Int32 withholdBase = OperationsTaxing.IntTaxRoundDown(amountForCalc);

            return withholdBase;
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
            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            var resTarget = GetTypedTarget<TaxingWithholdTotalTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingWithholdTotalTarget evalTarget = resTarget.Value;

            var resBaseVal = GetContractResult<TaxingWithholdBasisResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_BASIS));

            if (resBaseVal.IsFailure)
            {
                return BuildFailResults(resBaseVal.Error);
            }

            var evalBaseVal = resBaseVal.Value;

            Int32 withholdBasis = evalBaseVal.ResultBasis;

            ITermResult resultsValues = new TaxingWithholdTotalResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
        private Int32 TaxWithholdRoundedPaym(IPropsTaxing taxingRules, Int32 withholdBasis)
        {
            decimal factorWithhold = OperationsDec.Divide(taxingRules.FactorWithhold, 100);

            Int32 withholdTaxing = 0;
            if (withholdTaxing != 0)
            {
                withholdTaxing = OperationsTaxing.IntTaxRoundUp(OperationsDec.Multiply(withholdBasis, factorWithhold));
            }
            return withholdTaxing;
        }
    }
    // TaxingAllowancePayer			TAXING_ALLOWANCE_PAYER
    class TaxingAllowancePayerConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ALLOWANCE_PAYER;
        public TaxingAllowancePayerConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAllowancePayerConSpec(this.Code.Value);
        }
    }

    class TaxingAllowancePayerConSpec : PayrolexConceptSpec
    {
        public TaxingAllowancePayerConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            return Array.Empty<ITermTarget>();
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            Int32 allowancePayer = taxingRules.AllowancePayer;

            var resTarget = GetTypedTarget<TaxingAllowancePayerTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingAllowancePayerTarget evalTarget = resTarget.Value;

            Int32 benefitValue = 0;
            if (evalTarget.BenefitApply == TaxDeclBenfOption.DECL_TAX_BENEF1)
            {
                benefitValue = allowancePayer;
            }

            ITermResult resultsValues = new TaxingAllowancePayerResult(target, spec,
                evalTarget.BenefitApply, benefitValue, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingAllowanceChild			TAXING_ALLOWANCE_CHILD
    class TaxingAllowanceChildConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ALLOWANCE_CHILD;
        public TaxingAllowanceChildConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAllowanceChildConSpec(this.Code.Value);
        }
    }

    class TaxingAllowanceChildConSpec : PayrolexConceptSpec
    {
        public TaxingAllowanceChildConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            return Array.Empty<ITermTarget>();
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            Int32 allowanceChild1 = taxingRules.AllowanceChild1st;
            Int32 allowanceChild2 = taxingRules.AllowanceChild2nd;
            Int32 allowanceChild3 = taxingRules.AllowanceChild3rd;

            var resTarget = GetTypedTarget<TaxingAllowanceChildTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingAllowanceChildTarget evalTarget = resTarget.Value;

            Int32 benefitUnits = 0;
            switch (evalTarget.BenefitOrder)
            {
                case 0:
                    benefitUnits = allowanceChild1;
                    break;
                case 1:
                    benefitUnits = allowanceChild1;
                    break;
                case 2:
                    benefitUnits = allowanceChild2;
                    break;
                case 3:
                    benefitUnits = allowanceChild3;
                    break;
            }
            Int32 benefitValue = 0;
            if (evalTarget.BenefitApply == TaxDeclBenfOption.DECL_TAX_BENEF1)
            {
                if (evalTarget.BenefitDisab == 1)
                {
                    benefitValue = benefitUnits * 2;
                }
                else
                {
                    benefitValue = benefitUnits;
                }
            }

            ITermResult resultsValues = new TaxingAllowanceChildResult(target, spec,
                evalTarget.BenefitApply, evalTarget.BenefitDisab, evalTarget.BenefitOrder, benefitValue, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingAllowanceDisab			TAXING_ALLOWANCE_DISAB
    class TaxingAllowanceDisabConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ALLOWANCE_DISAB;
        public TaxingAllowanceDisabConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAllowanceDisabConSpec(this.Code.Value);
        }
    }

    class TaxingAllowanceDisabConSpec : PayrolexConceptSpec
    {
        public TaxingAllowanceDisabConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            return Array.Empty<ITermTarget>();
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            Int32 allowanceDisab1 = taxingRules.AllowanceDisab1st;
            Int32 allowanceDisab2 = taxingRules.AllowanceDisab2nd;
            Int32 allowanceDisab3 = taxingRules.AllowanceDisab3rd;

            var resTarget = GetTypedTarget<TaxingAllowanceDisabTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingAllowanceDisabTarget evalTarget = resTarget.Value;

            Int32 benefitValue = 0;
            switch (evalTarget.BenefitApply)
            {
                case TaxDeclDisabOption.DECL_TAX_DISAB1:
                    benefitValue = allowanceDisab1;
                    break;
                case TaxDeclDisabOption.DECL_TAX_DISAB2:
                    benefitValue = allowanceDisab2;
                    break;
                case TaxDeclDisabOption.DECL_TAX_DISAB3:
                    benefitValue = allowanceDisab3;
                    break;
            }

            ITermResult resultsValues = new TaxingAllowanceDisabResult(target, spec,
                evalTarget.BenefitApply, benefitValue, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingAllowanceStudy			TAXING_ALLOWANCE_STUDY
    class TaxingAllowanceStudyConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ALLOWANCE_STUDY;
        public TaxingAllowanceStudyConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAllowanceStudyConSpec(this.Code.Value);
        }
    }

    class TaxingAllowanceStudyConSpec : PayrolexConceptSpec
    {
        public TaxingAllowanceStudyConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            return Array.Empty<ITermTarget>();
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrTaxing = GetTaxingPropsResult(ruleset, target, period);
            if (resPrTaxing.IsFailure)
            {
                return BuildFailResults(resPrTaxing.Error);
            }
            IPropsTaxing taxingRules = resPrTaxing.Value;

            Int32 allowanceStudy = taxingRules.AllowanceStudy;

            var resTarget = GetTypedTarget<TaxingAllowanceStudyTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingAllowanceStudyTarget evalTarget = resTarget.Value;

            Int32 benefitValue = 0;
            if (evalTarget.BenefitApply == TaxDeclBenfOption.DECL_TAX_BENEF1)
            {
                benefitValue = allowanceStudy;
            }

            ITermResult resultsValues = new TaxingAllowanceStudyResult(target, spec, 
                evalTarget.BenefitApply, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingRebatePayer			TAXING_REBATE_PAYER
    class TaxingRebatePayerConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_REBATE_PAYER;
        public TaxingRebatePayerConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingRebatePayerConSpec(this.Code.Value);
        }
    }

    class TaxingRebatePayerConSpec : PayrolexConceptSpec
    {
        public TaxingRebatePayerConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_TOTAL,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_PAYER,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_DISAB,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_STUDY,
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
                new TaxingRebatePayerTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<TaxingRebatePayerTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingRebatePayerTarget evalTarget = resTarget.Value;

            var resAdvancesTotal = GetContractResult<TaxingAdvancesTotalResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_TOTAL));

            if (resAdvancesTotal.IsFailure)
            {
                return BuildFailResults(resAdvancesTotal.Error);
            }

            var evalAdvancesTotal = resAdvancesTotal.Value;

            var rebatePayerList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_PAYER))
               .Select((x) => (x as TaxingAllowancePayerResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal rebatePayerSum = rebatePayerList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            var rebateDisabList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_DISAB))
               .Select((x) => (x as TaxingAllowanceDisabResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal rebateDisabSum = rebateDisabList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            var rebateStudyList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_STUDY))
               .Select((x) => (x as TaxingAllowanceStudyResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal rebateStudySum = rebateStudyList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 allowancePayer = RoundingInt.RoundToInt(rebatePayerSum);
            Int32 allowanceDisab = RoundingInt.RoundToInt(rebateDisabSum);
            Int32 allowanceStudy = RoundingInt.RoundToInt(rebateStudySum);

            Int32 advancesTotal = evalAdvancesTotal.ResultValue;

            Int32 taxPayerRebat = TaxPayerRebate(advancesTotal, allowancePayer + allowanceDisab + allowanceStudy, 0);

            ITermResult resultsValues = new TaxingRebatePayerResult(target, spec, taxPayerRebat, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
        private Int32 TaxPayerRebate(Int32 taxingBasis, Int32 taxingAllow, Int32 taxingRebat)
        {
            decimal taxAfterRebat = decimal.Subtract(taxingBasis, taxingRebat);
            decimal taxRebatValue = decimal.Subtract(taxingAllow,
                Math.Max(0m, decimal.Subtract(taxingAllow, taxAfterRebat)));

            return RoundingInt.RoundToInt(taxRebatValue);
        }
    }

    // TaxingRebateChild			TAXING_REBATE_CHILD
    class TaxingRebateChildConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_REBATE_CHILD;
        public TaxingRebateChildConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingRebateChildConSpec(this.Code.Value);
        }
    }

    class TaxingRebateChildConSpec : PayrolexConceptSpec
    {
        public TaxingRebateChildConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_REBATE_PAYER,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_CHILD,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_TOTAL,
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
                new TaxingRebateChildTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<TaxingRebateChildTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingRebateChildTarget evalTarget = resTarget.Value;

            var resAdvancesTotal = GetContractResult<TaxingAdvancesTotalResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_TOTAL));

            if (resAdvancesTotal.IsFailure)
            {
                return BuildFailResults(resAdvancesTotal.Error);
            }

            var evalAdvancesTotal = resAdvancesTotal.Value;

            var resRebPayerTotal = GetContractResult<TaxingRebatePayerResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_REBATE_PAYER));

            if (resRebPayerTotal.IsFailure)
            {
                return BuildFailResults(resRebPayerTotal.Error);
            }

            var evalRebPayerTotal = resRebPayerTotal.Value;

            var rebateChildList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_CHILD))
               .Select((x) => (x as TaxingAllowanceChildResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal rebateChildSum = rebateChildList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 allowanceChild = RoundingInt.RoundToInt(rebateChildSum);

            Int32 rebPayerTotal = evalRebPayerTotal.ResultValue;

            Int32 advancesTotal = evalAdvancesTotal.ResultValue;

            Int32 taxChildRebat = TaxChildRebate(advancesTotal, allowanceChild, rebPayerTotal);

            ITermResult resultsValues = new TaxingRebateChildResult(target, spec, taxChildRebat, allowanceChild, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
        private Int32 TaxChildRebate(Int32 taxingBasis, Int32 taxingAllow, Int32 taxingRebat)
        {
            decimal taxAfterRebat = decimal.Subtract(taxingBasis, taxingRebat);
            decimal taxRebatValue = decimal.Subtract(taxingAllow,
                Math.Max(0m, decimal.Subtract(taxingAllow, taxAfterRebat)));

            return RoundingInt.RoundToInt(taxRebatValue);
        }
    }

    // TaxingBonusChild			TAXING_BONUS_CHILD
    class TaxingBonusChildConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_BONUS_CHILD;
        public TaxingBonusChildConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingBonusChildConSpec(this.Code.Value);
        }
    }

    class TaxingBonusChildConSpec : PayrolexConceptSpec
    {
        public TaxingBonusChildConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_CHILD,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_REBATE_PAYER,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_REBATE_CHILD,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_TOTAL,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT,
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
                new TaxingBonusChildTarget(month, con, pos, var, article, this.Code, 0),
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

            var resTarget = GetTypedTarget<TaxingBonusChildTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingBonusChildTarget evalTarget = resTarget.Value;

            var resAdvancesTotal = GetContractResult<TaxingAdvancesTotalResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_TOTAL));

            if (resAdvancesTotal.IsFailure)
            {
                return BuildFailResults(resAdvancesTotal.Error);
            }

            var evalAdvancesTotal = resAdvancesTotal.Value;

            var resRebPayerTotal = GetContractResult<TaxingRebatePayerResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_REBATE_PAYER));

            if (resRebPayerTotal.IsFailure)
            {
                return BuildFailResults(resRebPayerTotal.Error);
            }

            var evalRebPayerTotal = resRebPayerTotal.Value;

            var resRebChildTotal = GetContractResult<TaxingRebateChildResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_REBATE_CHILD));

            if (resRebChildTotal.IsFailure)
            {
                return BuildFailResults(resRebChildTotal.Error);
            }

            var evalRebChildTotal = resRebChildTotal.Value;

            var incomeList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT))
               .Select((x) => (x as TaxingIncomeSubjectResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal incomeSum = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 rebateChild = evalRebChildTotal.ResultValue;
            Int32 summarChild = evalRebChildTotal.ResultBasis;

            Int32 incomeTaxs = RoundingInt.RoundToInt(incomeSum);

            Int32 bonusValue = RoundingInt.RoundToInt(BonusAfterRebate(taxingRules, incomeTaxs, summarChild, rebateChild));

            ITermResult resultsValues = new TaxingBonusChildResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
        private decimal BonusAfterRebate(IPropsTaxing taxingRules, Int32 taxingBasis, Int32 childAllow, Int32 childRebat)
        {
            Int32 marIncomeOfTaxBonus = taxingRules.MarginIncomeOfTaxBonus;

            decimal bonusForChild = decimal.Negate(Math.Min(0, childRebat - childAllow));

            if (taxingBasis < marIncomeOfTaxBonus)
            {
                bonusForChild = 0;
            }
            return MaxMinBonus(taxingRules, taxingBasis, bonusForChild);
        }
        private decimal MaxMinBonus(IPropsTaxing taxingRules, Int32 taxingBasis, decimal taxChildBonus)
        {
            Int32 minAmountOfTaxBonus = taxingRules.MinAmountOfTaxBonus;
            Int32 maxAmountOfTaxBonus = taxingRules.MaxAmountOfTaxBonus;

            if (taxChildBonus < minAmountOfTaxBonus)
            {
                return 0m;
            }
            else if (taxChildBonus > maxAmountOfTaxBonus)
            {
                return maxAmountOfTaxBonus;
            }
            else
            {
                return taxChildBonus;
            }
        }
    }
    // TaxingPaymAdvances			TAXING_PAYM_ADVANCES
    class TaxingPaymAdvancesConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_PAYM_ADVANCES;
        public TaxingPaymAdvancesConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingPaymAdvancesConSpec(this.Code.Value);
        }
    }

    class TaxingPaymAdvancesConSpec : PayrolexConceptSpec
    {
        public TaxingPaymAdvancesConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_TOTAL,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_REBATE_PAYER,
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_REBATE_CHILD,
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
                new TaxingPaymAdvancesTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<TaxingPaymAdvancesTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingPaymAdvancesTarget evalTarget = resTarget.Value;

            var resAdvancesTotal = GetContractResult<TaxingAdvancesTotalResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_TOTAL));

            if (resAdvancesTotal.IsFailure)
            {
                return BuildFailResults(resAdvancesTotal.Error);
            }

            var evalAdvancesTotal = resAdvancesTotal.Value;

            var rebatePayerList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_REBATE_PAYER))
               .Select((x) => (x as TaxingRebatePayerResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal rebatePayerSum = rebatePayerList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 rebatePayer = RoundingInt.RoundToInt(rebatePayerSum);

            var rebateChildList = results
               .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
               .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_TAXING_REBATE_CHILD))
               .Select((x) => (x as TaxingRebateChildResult))
               .Where((v) => (v is not null))
               .Select((r) => (r.ResultValue)).ToArray();

            decimal rebateChildSum = rebateChildList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            Int32 rebateChild = RoundingInt.RoundToInt(rebateChildSum);

            Int32 advancesPayment = (evalAdvancesTotal.ResultValue - rebatePayer - rebateChild);

            ITermResult resultsValues = new TaxingPaymAdvancesResult(target, spec, advancesPayment, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // TaxingPaymWithhold			TAXING_PAYM_WITHHOLD
    class TaxingPaymWithholdConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_PAYM_WITHHOLD;
        public TaxingPaymWithholdConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingPaymWithholdConSpec(this.Code.Value);
        }
    }

    class TaxingPaymWithholdConSpec : PayrolexConceptSpec
    {
        public TaxingPaymWithholdConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_TOTAL,
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
                new TaxingPaymWithholdTarget(month, con, pos, var, article, this.Code, 0),
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<TaxingPaymWithholdTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            TaxingPaymWithholdTarget evalTarget = resTarget.Value;

            var resWithholdTotal = GetContractResult<TaxingWithholdTotalResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_TOTAL));

            if (resWithholdTotal.IsFailure)
            {
                return BuildFailResults(resWithholdTotal.Error);
            }

            var evalWithholdTotal = resWithholdTotal.Value;

            Int32 withholdPayment = evalWithholdTotal.ResultValue;

            ITermResult resultsValues = new TaxingPaymWithholdResult(target, spec, withholdPayment, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }
}
