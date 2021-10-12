using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace ProcezorTests.Registry.Providers.Results
{
    // AmountFixed              AMOUNT_FIXED
    class AmountFixedResult : TestTermResult
    {
        public AmountFixedResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public AmountFixedResult(ITermTarget target)
        : base(target, TestResultConst.VALUE_ZERO, TestResultConst.BASIS_ZERO, TestResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
}
