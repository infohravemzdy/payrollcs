using System;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Interfaces
{
    interface IBundleBuilder
    {
        IBundleProps GetBundle(IPeriod period);
    }
}
