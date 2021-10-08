using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Providers;
using HraveMzdy.Legalios.Props;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Factories
{
    using VERSION = Int16;
    public class FactorySalary : ProviderFactory<IProviderSalary, IPropsSalary>
    {
        private readonly IProviderSalary defaultProvider = new ProviderSalary2021();

        private readonly IPropsSalary emptyPeriodProps = PropsSalary.Empty();

        protected override IProviderSalary DefaultProvider => defaultProvider;
        protected override IPropsSalary EmptyPeriodProps => emptyPeriodProps;
    }
}
