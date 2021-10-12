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
    // TaxingAdvBase            TAXING_ADVBASE
    class TaxingAdvBaseConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)TestConceptConst.CONCEPT_TAXING_ADVBASE;
        class TaxingAdvBaseConSpec : TestConceptSpec
        {
            public TaxingAdvBaseConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>();

                ResultDelegate = ConceptEval;
            }
            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new TaxingAdvBaseResult(target, 0, 0, TestResultConst.DESCRIPTION_EMPTY);

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
}
