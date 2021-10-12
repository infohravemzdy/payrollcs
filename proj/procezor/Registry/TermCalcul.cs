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

        public IEnumerable<Result<ITermResult, ITermResultError>> GetResults<EA, EC>(IPeriod period, IBundleProps propsLegal, IList<Result<ITermResult, ITermResultError>> results)
            where EA : struct, IComparable
            where EC : struct, IComparable
        {
            var resultTarget = CallResultDelegate<EA, EC>(Target, period, propsLegal, results);
            return resultTarget.ToArray();
        }
        public IEnumerable<Result<ITermResult, ITermResultError>> CallResultDelegate<EA, EC>(ITermTarget target, IPeriod period, IBundleProps propsLegal, IList<Result<ITermResult, ITermResultError>> results)
            where EA : struct, IComparable
            where EC : struct, IComparable
        {
            if (ResultDelegate == null)
            {
                var resultError = NoResultFuncError<EA, EC>.CreateResultError(period, target);
                return new Result<ITermResult, ITermResultError>[] { resultError };
            }
            var resultTarget = ResultDelegate(target, period, propsLegal, results);
            return resultTarget.ToArray();
        }
    }
}
