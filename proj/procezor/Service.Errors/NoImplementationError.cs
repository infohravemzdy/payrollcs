using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using ResultMonad;

namespace HraveMzdy.Procezor.Service.Errors
{
    class NoImplementationError<EA, EC> : TermResultError<EA, EC>
        where EA : struct, IComparable
        where EC : struct, IComparable
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target)
        {
            return new NoImplementationError<EA, EC>(period, target);
        }
        public static Result<ITermResult, ITermResultError> CreateResultError(IPeriod period, ITermTarget target)
        {
            return Result.Fail<ITermResult, ITermResultError>(NoImplementationError<EA, EC>.CreateError(period, target));
        }
        NoImplementationError(IPeriod period, ITermTarget target) : base(period, target, null, "No implementation!")
        {
        }
    }
}
