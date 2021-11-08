using System;
using HraveMzdy.Procezor.Registry.Factories;

namespace ProcezorTests.Registry.Factories
{
    class ExampleConceptFactory : ConceptSpecFactory
    {
        public ExampleConceptFactory()
        {
            this.Providers = BuildProvidersFromAssembly<ExampleConceptFactory>();
        }
    }
}