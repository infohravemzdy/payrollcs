using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Types;
using ResultMonad;

namespace HraveMzdy.Procezor.Service.Interfaces
{
    using ResultFunc = Func<ITermTarget, IArticleSpec, IPeriod, IBundleProps, IList<Result<ITermResult, ITermResultError>>, IList<Result<ITermResult, ITermResultError>>>;
    public interface IConceptSpec : IConceptDefine
    {
        IEnumerable<ArticleCode> Path { get; }
        ResultFunc ResultDelegate { get; }
        ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var);
    }
}
