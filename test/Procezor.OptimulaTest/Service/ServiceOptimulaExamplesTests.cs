using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Procezor.Optimula.Service;
using HraveMzdy.Procezor.Optimula.Registry.Providers;
using HraveMzdy.Procezor.Optimula.Registry.Constants;
using HraveMzdy.Legalios.Service;

namespace Procezor.OptimulaTest.Service
{
    public class ServiceOptimulaExamplesTests
    {
        private readonly ITestOutputHelper output;

        private readonly ServiceOptimula _sut;
        private readonly ServiceLegalios _leg;

        public ServiceOptimulaExamplesTests(ITestOutputHelper output)
        {
            this.output = output;

            this._sut = new ServiceOptimula();
            this._leg = new ServiceLegalios();
        }
    }
}
