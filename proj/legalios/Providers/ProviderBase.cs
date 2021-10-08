using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Providers
{
    class ProviderBase
    {
        public ProviderBase(Int16 version)
        {
            this.Version = new VersionId(version);
        }
        public ProviderBase(VersionId version)
        {
            this.Version = new VersionId(version.Value);
        }
        public VersionId Version { get; }

        protected bool IsPeriodGreaterOrEqualThan(IPeriod period, Int16 yearFrom, Int16 monthFrom)
        {
            return (period.Year > yearFrom || (period.Year == yearFrom && period.Month >= monthFrom));
        }
    }
}
