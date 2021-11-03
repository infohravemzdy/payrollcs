using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using ResultMonad;

namespace HraveMzdy.Procezor.Service.Errors
{
    class NoImplementationError : TermResultError
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target)
        {
            return new NoImplementationError(period, target);
        }
        public static Result<ITermResult, ITermResultError> CreateResultError(IPeriod period, ITermTarget target)
        {
            return Result.Fail<ITermResult, ITermResultError>(NoImplementationError.CreateError(period, target));
        }
        NoImplementationError(IPeriod period, ITermTarget target) : base(period, target, null, "No implementation!")
        {
        }
    }
}
