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
    // TimeshtWorking			TIMESHT_WORKING
    class TimeshtWorkingConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)TestConceptConst.CONCEPT_TIMESHT_WORKING;
        class TimeshtWorkingConSpec : TestConceptSpec
        {

            public TimeshtWorkingConSpec(Int32 code) : base(code)
            {
                Path = new List<ArticleCode>();
                ResultDelegate = ConceptEval;
            }

            private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IPeriod period, IList<Result<ITermResult, ITermResultError>> results)
            {
                ITermResult resultsValues = new TimeshtWorkingResult(target, 0, 0, TestResultConst.DESCRIPTION_EMPTY);
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
}
