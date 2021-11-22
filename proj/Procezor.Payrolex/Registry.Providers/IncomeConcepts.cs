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
                        return agr;
                    }
                    var itemValue = item.Value;
                    if (itemValue.Spec.Sums.Contains(evalTarget.Article)==false)
                    {
                        return agr;
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
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_PAYM_EMPLOYEE,
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
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new EmployerCostsTarget(month, con, pos, var, article, this.Code, 0);
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<EmployerCostsTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            EmployerCostsTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new EmployerCostsResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

}
