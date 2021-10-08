using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Errors;
using ResultMonad;

namespace HraveMzdy.Legalios.Service
{
    public interface IServiceLegalios
    {
        Result<IBundleProps, IHistoryResultError> GetBundle(IPeriod period);
    }
}
