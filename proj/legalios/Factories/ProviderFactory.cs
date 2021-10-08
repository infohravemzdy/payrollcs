using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using HraveMzdy.Legalios.Providers;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Factories
{
    using VERSION = Int16;
    public abstract class ProviderFactory<B, P> : IProviderFactory<B, P> 
        where B : class, IPropsProvider<P>
    {
        private IReadOnlyDictionary<VERSION, B> Versions { get; set; }

        protected abstract B DefaultProvider { get; }

        protected abstract P EmptyPeriodProps { get; }

        private static bool IsValidType(Type testType)
        {
            var providerType = typeof(B);

            return (providerType.IsAssignableFrom(testType) && !testType.IsInterface && !testType.IsAbstract);
        }
        private static bool HasValidConstructor(Type testType)
        {
            var parameterlessConstructor = testType.GetConstructors()
                .SingleOrDefault((c) => (c.GetParameters().Length == 0));
            return (parameterlessConstructor is not null);
        }
        private bool BuildFactory()
        {
            var providerType = typeof(B);

            this.Versions = providerType.Assembly.DefinedTypes
                .Where((x) => (IsValidType(x) && HasValidConstructor(x)))
                .Select((x) => (Activator.CreateInstance(x)))
                .Cast<B>()
                .ToImmutableDictionary(x => x.Version.Value, x => x);

            return true;
        }

        public ProviderFactory()
        {
            BuildFactory();
        }

        public P GetProps(IPeriod period)
        {
            B provider = GetProvider(period, DefaultProvider);
            if (provider == null)
            {
                return EmptyPeriodProps;
            }
            return provider.GetProps(period);
        }

        private B GetProvider(IPeriod period, B defProvider)
        {
            B provider = Versions.GetValueOrDefault(period.Year, null);
            if (provider == null)
            {
                if (period.Year > defProvider.Version.Value)
                {
                    return defProvider;
                }
                return provider;
            }
            if (period.Year == provider.Version.Value)
            {
                return provider;
            }
            return null;
        }
    }
}
