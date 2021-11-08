using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace ProcezorTests.Registry.Providers
{
    // TimeshtWorking           TIMESHT_WORKING
    class TimeshtWorkingResult : ExampleTermResult
    {
        public TimeshtWorkingResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public TimeshtWorkingResult(ITermTarget target)
        : base(target, ExampleResultConst.VALUE_ZERO, ExampleResultConst.BASIS_ZERO, ExampleResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
    // AmountBasis              AMOUNT_BASIS
    class AmountBasisResult : ExampleTermResult
    {
        public AmountBasisResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public AmountBasisResult(ITermTarget target)
        : base(target, ExampleResultConst.VALUE_ZERO, ExampleResultConst.BASIS_ZERO, ExampleResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
    // AmountFixed              AMOUNT_FIXED
    class AmountFixedResult : ExampleTermResult
    {
        public AmountFixedResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public AmountFixedResult(ITermTarget target)
        : base(target, ExampleResultConst.VALUE_ZERO, ExampleResultConst.BASIS_ZERO, ExampleResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
    // HealthInsBase            HEALTH_INSBASE
    class HealthInsBaseResult : ExampleTermResult
    {
        public HealthInsBaseResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public HealthInsBaseResult(ITermTarget target)
        : base(target, ExampleResultConst.VALUE_ZERO, ExampleResultConst.BASIS_ZERO, ExampleResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
    // SocialInsBase            SOCIAL_INSBASE
    class SocialInsBaseResult : ExampleTermResult
    {
        public SocialInsBaseResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public SocialInsBaseResult(ITermTarget target)
        : base(target, ExampleResultConst.VALUE_ZERO, ExampleResultConst.BASIS_ZERO, ExampleResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
    // TaxingAdvBase            TAXING_ADVBASE
    class TaxingAdvBaseResult : ExampleTermResult
    {
        public TaxingAdvBaseResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public TaxingAdvBaseResult(ITermTarget target)
        : base(target, ExampleResultConst.VALUE_ZERO, ExampleResultConst.BASIS_ZERO, ExampleResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
    // HealthInsPaym            HEALTH_INSPAYM
    class HealthInsPaymResult : ExampleTermResult
    {
        public HealthInsPaymResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public HealthInsPaymResult(ITermTarget target)
        : base(target, ExampleResultConst.VALUE_ZERO, ExampleResultConst.BASIS_ZERO, ExampleResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
    // SocialInsPaym            SOCIAL_INSPAYM
    class SocialInsPaymResult : ExampleTermResult
    {
        public SocialInsPaymResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public SocialInsPaymResult(ITermTarget target)
        : base(target, ExampleResultConst.VALUE_ZERO, ExampleResultConst.BASIS_ZERO, ExampleResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
    // TaxingAdvPaym            TAXING_ADVPAYM
    class TaxingAdvPaymResult : ExampleTermResult
    {
        public TaxingAdvPaymResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public TaxingAdvPaymResult(ITermTarget target)
        : base(target, ExampleResultConst.VALUE_ZERO, ExampleResultConst.BASIS_ZERO, ExampleResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
    // IncomeGross              INCOME_GROSS
    class IncomeGrossResult : ExampleTermResult
    {
        public IncomeGrossResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public IncomeGrossResult(ITermTarget target)
        : base(target, ExampleResultConst.VALUE_ZERO, ExampleResultConst.BASIS_ZERO, ExampleResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
    // IncomeNetto              INCOME_NETTO
    class IncomeNettoResult : ExampleTermResult
    {
        public IncomeNettoResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public IncomeNettoResult(ITermTarget target)
        : base(target, ExampleResultConst.VALUE_ZERO, ExampleResultConst.BASIS_ZERO, ExampleResultConst.DESCRIPTION_EMPTY)
        {
        }
    }
}
