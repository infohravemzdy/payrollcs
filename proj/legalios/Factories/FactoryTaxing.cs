using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Providers;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Factories
{
    using VERSION = Int16;
    public class FactoryTaxing : ProviderFactory<IProviderTaxing, IPropsTaxing>
    {
        private readonly IProviderTaxing defaultProvider = new ProviderTaxing2021();

        private readonly IPropsTaxing emptyPeriodProps = PropsTaxing.Empty();

        protected override IProviderTaxing DefaultProvider => defaultProvider;
        protected override IPropsTaxing EmptyPeriodProps => emptyPeriodProps;
    }
}
