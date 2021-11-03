using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Types;
using ResultMonad;

namespace HraveMzdy.Procezor.Registry
{
    using ResultFunc = Func<ITermTarget, IPeriod, IBundleProps, IList<Result<ITermResult, ITermResultError>>, IEnumerable<Result<ITermResult, ITermResultError>>>;
    class TermCalcul : TermSymbol, ITermCalcul
    {
        public TermCalcul(ITermTarget target, ResultFunc resultDelegate)
            : base(target.MonthCode, target.Contract, target.Position, target.Variant, target.Article)
        {
            Target = target;

            ResultDelegate = resultDelegate;
        }
        public ITermTarget Target { get; }

        public ResultFunc ResultDelegate { get; }

        public IEnumerable<Result<ITermResult, ITermResultError>> GetResults(IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resultTarget = CallResultDelegate(Target, period, ruleset, results);
            return resultTarget.ToArray();
        }
        public IEnumerable<Result<ITermResult, ITermResultError>> CallResultDelegate(ITermTarget target, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            if (ResultDelegate == null)
            {
                var resultError = NoResultFuncError.CreateResultError(period, target);
                return new Result<ITermResult, ITermResultError>[] { resultError };
            }
            var resultTarget = ResultDelegate(target, period, ruleset, results);
            return resultTarget.ToArray();
        }
    }
}
