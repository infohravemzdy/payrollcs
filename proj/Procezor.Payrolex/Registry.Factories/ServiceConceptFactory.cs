using HraveMzdy.Procezor.Registry.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procezor.Payrolex.Registry.Factories
{
    class ServiceConceptFactory : ConceptSpecFactory
    {
        public ServiceConceptFactory()
        {
            this.Providers = BuildProvidersFromAssembly<ServiceConceptFactory>();
        }
    }
}
