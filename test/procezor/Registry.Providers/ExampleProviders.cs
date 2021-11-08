using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;
using ResultMonad;

namespace ProcezorTests.Registry.Providers
{
    class ExampleConceptSpec : ConceptSpec
    {
        public ExampleConceptSpec(Int32 code) : base(code)
        {
        }
    }

    class ExampleTermTarget : TermTarget
    {
        public ExampleTermTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 basis, string descr) :
            base(monthCode, contract, position, variant, article, concept, basis, descr)
        {
        }
        public ExampleTermTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept) :
            base(monthCode, contract, position, variant, article, concept)
        {
        }
        public override string ArticleDescr()
        {
            return ArticleEnumUtils.GetSymbol(Article.Value);
        }
        public override string ConceptDescr()
        {
            return ConceptEnumUtils.GetSymbol(Concept.Value);
        }
    }

    class ExampleTermResult : TermResult
    {
        public ExampleTermResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public override string ArticleDescr()
        {
            return ArticleEnumUtils.GetSymbol(Article.Value);
        }
        public override string ConceptDescr()
        {
            return ConceptEnumUtils.GetSymbol(Concept.Value);
        }
    }

    // TimeshtWorking			TIMESHT_WORKING
    class TimeshtWorkingConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_TIMESHT_WORKING;
        class TimeshtWorkingConSpec : ExampleConceptSpec
        {

            public TimeshtWorkingConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>();
                ResultDelegate = ConceptEval;
            }

            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new TimeshtWorkingResult(target, 0, 0, ExampleResultConst.DESCRIPTION_EMPTY);
                return BuildOkResults(resultsValues);
            }
        }

        public TimeshtWorkingConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TimeshtWorkingConSpec(this.Code.Value);
        }
    }
    // AmountBasis              AMOUNT_BASIS
    class AmountBasisConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_AMOUNT_BASIS;
        class AmountBasisConSpec : ExampleConceptSpec
        {
            public AmountBasisConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>() {
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_TIMESHT_WORKING),
                };

                ResultDelegate = ConceptEval;
            }
            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new AmountBasisResult(target, 0, 0, ExampleResultConst.DESCRIPTION_EMPTY);

                return BuildOkResults(resultsValues);
            }
        }

        public AmountBasisConProv() : base(CONCEPT_CODE)
        {
        }
        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AmountBasisConSpec(this.Code.Value);
        }
    }
    // AmountFixed              AMOUNT_FIXED
    class AmountFixedConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED;
        class AmountFixedConSpec : ExampleConceptSpec
        {
            public AmountFixedConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>();

                ResultDelegate = ConceptEval;
            }
            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new AmountFixedResult(target, 0, 0, ExampleResultConst.DESCRIPTION_EMPTY);

                return BuildOkResults(resultsValues);
            }
        }

        public AmountFixedConProv() : base(CONCEPT_CODE)
        {
        }
        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AmountFixedConSpec(this.Code.Value);
        }
    }
    // HealthInsBase            HEALTH_INSBASE
    class HealthInsBaseConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_HEALTH_INSBASE;
        class HealthInsBaseConSpec : ExampleConceptSpec
        {
            public HealthInsBaseConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>();

                ResultDelegate = ConceptEval;
            }
            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new HealthInsBaseResult(target, 0, 0, ExampleResultConst.DESCRIPTION_EMPTY);

                return BuildOkResults(resultsValues);
            }
        }

        public HealthInsBaseConProv() : base(CONCEPT_CODE)
        {
        }
        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthInsBaseConSpec(this.Code.Value);
        }
    }
    // SocialInsBase            SOCIAL_INSBASE
    class SocialInsBaseConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_SOCIAL_INSBASE;
        class SocialInsBaseConSpec : ExampleConceptSpec
        {
            public SocialInsBaseConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>();

                ResultDelegate = ConceptEval;
            }
            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new SocialInsBaseResult(target, 0, 0, ExampleResultConst.DESCRIPTION_EMPTY);

                return BuildOkResults(resultsValues);
            }
        }

        public SocialInsBaseConProv() : base(CONCEPT_CODE)
        {
        }
        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialInsBaseConSpec(this.Code.Value);
        }
    }
    // TaxingAdvBase            TAXING_ADVBASE
    class TaxingAdvBaseConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_TAXING_ADVBASE;
        class TaxingAdvBaseConSpec : ExampleConceptSpec
        {
            public TaxingAdvBaseConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>();

                ResultDelegate = ConceptEval;
            }
            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new TaxingAdvBaseResult(target, 0, 0, ExampleResultConst.DESCRIPTION_EMPTY);

                return BuildOkResults(resultsValues);
            }
        }

        public TaxingAdvBaseConProv() : base(CONCEPT_CODE)
        {
        }
        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvBaseConSpec(this.Code.Value);
        }
    }
    // HealthInsPaym            HEALTH_INSPAYM
    class HealthInsPaymConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_HEALTH_INSPAYM;
        class HealthInsPaymConSpec : ExampleConceptSpec
        {
            public HealthInsPaymConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>() {
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE),
                };

                ResultDelegate = ConceptEval;
            }
            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new HealthInsPaymResult(target, 0, 0, ExampleResultConst.DESCRIPTION_EMPTY);

                return BuildOkResults(resultsValues);
            }
        }

        public HealthInsPaymConProv() : base(CONCEPT_CODE)
        {
        }
        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthInsPaymConSpec(this.Code.Value);
        }
    }
    // SocialInsPaym            SOCIAL_INSPAYM
    class SocialInsPaymConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_SOCIAL_INSPAYM;
        class SocialInsPaymConSpec : ExampleConceptSpec
        {
            public SocialInsPaymConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>() {
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE),
                };

                ResultDelegate = ConceptEval;
            }
            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new SocialInsPaymResult(target, 0, 0, ExampleResultConst.DESCRIPTION_EMPTY);

                return BuildOkResults(resultsValues);
            }
        }

        public SocialInsPaymConProv() : base(CONCEPT_CODE)
        {
        }
        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialInsPaymConSpec(this.Code.Value);
        }
    }
    // TaxingAdvPaym            TAXING_ADVPAYM
    class TaxingAdvPaymConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_TAXING_ADVPAYM;
        class TaxingAdvPaymConSpec : ExampleConceptSpec
        {
            public TaxingAdvPaymConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>() {
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE),
                };

                ResultDelegate = ConceptEval;
            }
            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new TaxingAdvPaymResult(target, 0, 0, ExampleResultConst.DESCRIPTION_EMPTY);

                return BuildOkResults(resultsValues);
            }
        }

        public TaxingAdvPaymConProv() : base(CONCEPT_CODE)
        {
        }
        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvPaymConSpec(this.Code.Value);
        }
    }
    // IncomeGross              INCOME_GROSS
    class IncomeGrossConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_INCOME_GROSS;
        class IncomeGrossConSpec : ExampleConceptSpec
        {
            public IncomeGrossConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>();

                ResultDelegate = ConceptEval;
            }
            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new IncomeGrossResult(target, 0, 0, ExampleResultConst.DESCRIPTION_EMPTY);

                return BuildOkResults(resultsValues);
            }
        }

        public IncomeGrossConProv() : base(CONCEPT_CODE)
        {
        }
        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomeGrossConSpec(this.Code.Value);
        }
    }
    // IncomeNetto              INCOME_NETTO
    class IncomeNettoConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_INCOME_NETTO;
        class IncomeNettoConSpec : ExampleConceptSpec
        {
            public IncomeNettoConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>() {
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_INCOME_GROSS),
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_HEALTH_INSPAYM),
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSPAYM),
                    ArticleCode.Get((Int32)ExampleArticleConst.ARTICLE_TAXING_ADVPAYM),
                };

                ResultDelegate = ConceptEval;
            }
            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new IncomeNettoResult(target, 0, 0, ExampleResultConst.DESCRIPTION_EMPTY);

                return BuildOkResults(resultsValues);
            }
        }

        public IncomeNettoConProv() : base(CONCEPT_CODE)
        {
        }
        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomeNettoConSpec(this.Code.Value);
        }
    }
}
