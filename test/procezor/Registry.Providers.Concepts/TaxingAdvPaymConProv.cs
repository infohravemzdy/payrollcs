using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;
using ProcezorTests.Registry.Providers.Results;
using ResultMonad;

namespace ProcezorTests.Registry.Providers.Concepts
{
    // TaxingAdvPaym            TAXING_ADVPAYM
    class TaxingAdvPaymConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)TestConceptConst.CONCEPT_TAXING_ADVPAYM;
        class TaxingAdvPaymConSpec : TestConceptSpec
        {
            public TaxingAdvPaymConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>() {
                    ArticleCode.Get((Int32)TestArticleConst.ARTICLE_TAXING_ADVBASE),
                };

                ResultDelegate = ConceptEval;
            }
            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps propsLegal, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new TaxingAdvPaymResult(target, 0, 0, TestResultConst.DESCRIPTION_EMPTY);

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
}
