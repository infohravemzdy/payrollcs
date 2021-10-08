using HraveMzdy.Legalios.Service.Types;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Providers
{
    public interface IPropsProvider<P>
    {
        P GetProps(IPeriod period);
        VersionId Version { get; }
    }
}
