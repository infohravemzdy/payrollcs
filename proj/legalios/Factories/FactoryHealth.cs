using System;
using HraveMzdy.Legalios.Providers;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Factories
{
    using VERSION = Int16;
    public class FactoryHealth : ProviderFactory<IProviderHealth, IPropsHealth>
    {
        private readonly IProviderHealth defaultProvider = new ProviderHealth2021();

        private readonly IPropsHealth emptyPeriodProps = PropsHealth.Empty();

        protected override IProviderHealth DefaultProvider => defaultProvider;
        protected override IPropsHealth EmptyPeriodProps => emptyPeriodProps;
    }
}
