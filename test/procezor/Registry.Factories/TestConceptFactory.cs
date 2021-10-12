using System;
using HraveMzdy.Procezor.Registry.Factories;

namespace ProcezorTests.Registry.Factories
{
    class TestConceptFactory : ConceptSpecFactory
    {
        public TestConceptFactory()
        {
            this.Providers = BuildProvidersFromAssembly<TestConceptFactory>();
        }
    }
}