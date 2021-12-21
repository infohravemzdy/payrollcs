using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Providers;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Interfaces;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Factories
{
    using VERSION = Int16;
    public class FactorySocial : ProviderFactory<IProviderSocial, IPropsSocial>
    {
        private readonly IProviderSocial defaultProvider = new ProviderSocial2021();

        private readonly IPropsSocial emptyPeriodProps = PropsSocial2010.Empty();

        protected override IProviderSocial DefaultProvider => defaultProvider;
        protected override IPropsSocial EmptyPeriodProps => emptyPeriodProps;
    }
}
