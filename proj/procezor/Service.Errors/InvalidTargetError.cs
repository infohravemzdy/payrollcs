using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using ResultMonad;

namespace HraveMzdy.Procezor.Service.Errors
{
    public class InvalidTargetError : TermResultError
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget target)
        {
            return new InvalidTargetError(period, target);
        }
        public static Result<ITermResult, ITermResultError> CreateResultError(IPeriod period, ITermTarget target)
        {
            return Result.Fail<ITermResult, ITermResultError>(NoResultFuncError.CreateError(period, target));
        }
        InvalidTargetError(IPeriod period, ITermTarget target) : base(period, target, null, "Invalid target type error!")
        {
        }
    }
}
