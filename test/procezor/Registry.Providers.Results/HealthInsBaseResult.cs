using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace ProcezorTests.Registry.Providers.Results
{
    // HealthInsBase            HEALTH_INSBASE
    class HealthInsBaseResult : TestTermResult
    {
        public HealthInsBaseResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public HealthInsBaseResult(ITermTarget target)
        : base(target, TestResultConst.VALUE_ZERO, TestResultConst.BASIS_ZERO, TestResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
}
