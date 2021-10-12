using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace ProcezorTests.Registry.Providers.Results
{
    // AmountBasis              AMOUNT_BASIS
    class AmountBasisResult : TestTermResult
    {
        public AmountBasisResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public AmountBasisResult(ITermTarget target)
        : base(target, TestResultConst.VALUE_ZERO, TestResultConst.BASIS_ZERO, TestResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
}
