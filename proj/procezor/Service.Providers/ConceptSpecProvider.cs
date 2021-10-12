using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Providers
{
    public abstract class ConceptSpecProvider : IConceptSpecProvider
    {
        public ConceptSpecProvider(Int32 code)
        {
            Code = new ConceptCode(code);
        }

        public ConceptCode Code { get; protected set; }

        public abstract IConceptSpec GetSpec(IPeriod period, VersionCode version);
    }
}
