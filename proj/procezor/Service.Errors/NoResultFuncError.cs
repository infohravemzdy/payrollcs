using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using ResultMonad;

namespace HraveMzdy.Procezor.Service.Errors
{
    class NoResultFuncError<EA, EC> : TermResultError<EA, EC>
        where EA : struct, IComparable
        where EC : struct, IComparable
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target)
        {
            return new NoResultFuncError<EA, EC>(period, target);
        }
        public static Result<ITermResult, ITermResultError> CreateResultError(IPeriod period, ITermTarget target)
        {
            return Result.Fail<ITermResult, ITermResultError>(NoResultFuncError<EA, EC>.CreateError(period, target));
        }
        NoResultFuncError(IPeriod period, ITermTarget target) : base(period, target, null, "No result calculation function!")
        {
        }
    }
}
