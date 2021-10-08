using System;
using HraveMzdy.Legalios.Service.Errors;
using HraveMzdy.Legalios.Factories;
using HraveMzdy.Legalios.Interfaces;
using HraveMzdy.Legalios.Service.Interfaces;
using ResultMonad;

namespace HraveMzdy.Legalios.Service
{
    public class ServiceLegalios : IServiceLegalios
    {
        public ServiceLegalios()
        {
            Builder = new BundleBuilder();
        }

        private IBundleBuilder Builder { get; }

        public Result<IBundleProps, IHistoryResultError> GetBundle(IPeriod period)
        {
            var resultBundle = Builder.GetBundle(period);
            if (resultBundle == null)
            {
                return Result.Fail<IBundleProps, IHistoryResultError>(HistoryResultError.CreateBundleNoneError());
            }
            if (resultBundle.PeriodProps.Code == 0)
            {
                return Result.Fail<IBundleProps, IHistoryResultError>(HistoryResultError.CreateBundleEmptyError());
            }
            if (resultBundle.PeriodProps.Code < period.Code)
            {
                return Result.Fail<IBundleProps, IHistoryResultError>(HistoryResultError.CreateBundleInvalidError());
            }
            return Result.Ok<IBundleProps, IHistoryResultError>(resultBundle);
        }
    }
}
