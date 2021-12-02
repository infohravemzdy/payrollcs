using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Procezor.Payrolex.Registry.Constants;
using HraveMzdy.Procezor.Payrolex.Registry.Operations;
using ResultMonad;

namespace HraveMzdy.Procezor.Payrolex.Registry.Providers
{
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

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, IEnumerable<ITermTarget> targets, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;

            if (targets.Count() != 0)
            {
                return Array.Empty<ITermTarget>();
            }
            return new ITermTarget[] {
                new IncomeGrossTarget(month, con, pos, var, article, this.Code, 0) 
            };
        }
        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<IncomeGrossTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            IncomeGrossTarget evalTarget = resTarget.Value;

            var incomeList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((tr) => (tr.ResultValue)).ToArray();

            decimal resValue = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

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
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_PAYM_EMPLOYEE,
                (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_PAYM_EMPLOYEE,
                (Int32)PayrolexArticleConst.ARTICLE_INCOME_GROSS,
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
                new IncomeNettoTarget(month, con, pos, var, article, this.Code, 0)
            };
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

            decimal resGross = evalIncGross.ResultValue;

            var resPayHealth = GetResult<HealthPaymEmployeeResult>(target, period, results,
               ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_PAYM_EMPLOYEE));

            if (resPayHealth.IsFailure)
            {
                return BuildFailResults(resPayHealth.Error);
            }

            var evalPayHealth = resPayHealth.Value;

            decimal resHealth = evalPayHealth.ResultValue;

            var incomeList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((tr) => (tr.ResultValue)).ToArray();

            decimal resNetto = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            decimal resValue = decimal.Subtract(decimal.Add(resGross, resNetto), resHealth);

            ITermResult resultsValues = new IncomeNettoResult(target, spec, RoundingInt.RoundToInt(resValue), 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // EmployerCosts			EMPLOYER_COSTS
    class EmployerCostsConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_EMPLOYER_COSTS;
        public EmployerCostsConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new EmployerCostsConSpec(this.Code.Value);
        }
    }

    class EmployerCostsConSpec : PayrolexConceptSpec
    {
        public EmployerCostsConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_PAYM_EMPLOYER,
                (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_PAYM_EMPLOYER,
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
                new EmployerCostsTarget(month, con, pos, var, article, this.Code, 0) 
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<EmployerCostsTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            EmployerCostsTarget evalTarget = resTarget.Value;

            var incomeList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((tr) => (tr.ResultValue)).ToArray();

            decimal resValue = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            var resCostHealth = GetResult<HealthPaymEmployerResult>(target, period, results,
               ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_PAYM_EMPLOYER));

            if (resCostHealth.IsFailure)
            {
                return BuildFailResults(resCostHealth.Error);
            }

            var evalCostHealth = resCostHealth.Value;
            resValue = decimal.Add(resValue, evalCostHealth.ResultValue);

            ITermResult resultsValues = new EmployerCostsResult(target, spec, RoundingInt.RoundToInt(resValue), 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

}
