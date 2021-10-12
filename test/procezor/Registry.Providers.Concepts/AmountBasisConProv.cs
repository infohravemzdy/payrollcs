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
    // AmountBasis              AMOUNT_BASIS
    class AmountBasisConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)TestConceptConst.CONCEPT_AMOUNT_BASIS;
        class AmountBasisConSpec : TestConceptSpec
        {
            public AmountBasisConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>() {
                    ArticleCode.Get((Int32)TestArticleConst.ARTICLE_TIMESHT_WORKING),
                };

                ResultDelegate = ConceptEval;
            }
            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IBundleProps propsLegal, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new AmountBasisResult(target, 0, 0, TestResultConst.DESCRIPTION_EMPTY);

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
}
