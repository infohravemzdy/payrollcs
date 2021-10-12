using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace ProcezorTests.Registry.Providers.Results
{
    // SocialInsPaym            SOCIAL_INSPAYM
    class SocialInsPaymResult : TestTermResult
    {
        public SocialInsPaymResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public SocialInsPaymResult(ITermTarget target)
        : base(target, TestResultConst.VALUE_ZERO, TestResultConst.BASIS_ZERO, TestResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
}
