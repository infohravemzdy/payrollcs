using HraveMzdy.Legalios.Providers;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Factories
{
    public interface IProviderFactory<B, P> where B : IPropsProvider<P>
    {
        P GetProps(IPeriod period);
    }
}
