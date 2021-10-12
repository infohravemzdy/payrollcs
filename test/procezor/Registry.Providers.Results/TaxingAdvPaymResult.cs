using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace ProcezorTests.Registry.Providers.Results
{
    // TaxingAdvPaym            TAXING_ADVPAYM
    class TaxingAdvPaymResult : TestTermResult
    {
        public TaxingAdvPaymResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public TaxingAdvPaymResult(ITermTarget target)
        : base(target, TestResultConst.VALUE_ZERO, TestResultConst.BASIS_ZERO, TestResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
}
