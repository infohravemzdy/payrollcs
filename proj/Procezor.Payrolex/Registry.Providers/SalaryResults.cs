using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Interfaces;
using Procezor.Payrolex.Registry.Constants;

namespace Procezor.Payrolex.Registry.Providers
{
    // PaymentBasis		PAYMENT_BASIS
    class PaymentBasisResult : PayrolexTermResult
    {
        public PaymentBasisResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // PaymentFixed		PAYMENT_FIXED
    class PaymentFixedResult : PayrolexTermResult
    {
        public PaymentFixedResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }
}
