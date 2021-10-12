using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using ResultMonad;

namespace HraveMzdy.Procezor.Service.Errors
{
    class ExtractResultError<EA, EC> : TermResultError<EA, EC>
        where EA : struct, IComparable
        where EC : struct, IComparable
    {
        public static ITermResultError CreateError(IPeriod period, ITermTarget result, ITermSymbol target, ITermResultError inner, string errorText)
        {
            return new ExtractResultError<EA, EC>(period, result, target, inner, errorText);
        }
        public static Result<ITermResult, ITermResultError> CreateResultError(IPeriod period, ITermTarget result, ITermSymbol target, ITermResultError inner, string errorText)
        {
            return Result.Fail<ITermResult, ITermResultError>(ExtractResultError<EA, EC>.CreateError(period, result, target, inner, errorText));
        }
        protected ExtractResultError(IPeriod period, ITermTarget result, ITermSymbol target, ITermResultError inner, string errorText) : base(period, result, inner, errorText)
        {
            EA articleEnum = (EA)Enum.ToObject(typeof(EA), target.Article.Value);

            Error = string.Format("{0} for {1}", Error, articleEnum.ToString());  
        }
    }
}
