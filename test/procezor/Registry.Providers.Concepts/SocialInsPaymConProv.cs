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
    // SocialInsPaym            SOCIAL_INSPAYM
    class SocialInsPaymConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)TestConceptConst.CONCEPT_SOCIAL_INSPAYM;
        class SocialInsPaymConSpec : TestConceptSpec
        {
            public SocialInsPaymConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>() {
                    ArticleCode.Get((Int32)TestArticleConst.ARTICLE_SOCIAL_INSBASE),
                };

                ResultDelegate = ConceptEval;
            }
            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new SocialInsPaymResult(target, 0, 0, TestResultConst.DESCRIPTION_EMPTY);

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
}
