using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ResultMonad;

namespace HraveMzdy.Procezor.Service
{
    public interface IServiceProcezor<EA, EC> 
        where EA : struct, IComparable where EC : struct, IComparable
   {
        VersionCode Version { get; }
        IArticleDefine FinDefs { get; }
        IList<ArticleCode> BuilderOrder { get; }
        IDictionary<ArticleCode, IEnumerable<IArticleDefine>> BuilderPaths { get; }

        IEnumerable<Result<ITermResult, ITermResultError>> GetResults(IPeriod period, IEnumerable<ITermTarget> targets);
        bool BuildFactories();
        bool InitWithPeriod(IPeriod period);
        IArticleSpec GetArticleSpec(ArticleCode code, IPeriod period, VersionCode version);
        IConceptSpec GetConceptSpec(ConceptCode code, IPeriod period, VersionCode version);
    }
}
