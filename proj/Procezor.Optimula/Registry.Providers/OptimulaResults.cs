using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Optimula.Registry.Constants;

namespace HraveMzdy.Procezor.Optimula.Registry.Providers
{
    // ContractTimePlan		CONTRACT_TIME_PLAN
    public class ContractTimePlanResult : OptimulaTermResult
    {
        public ContractTimePlanResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // ContractTimeWork		CONTRACT_TIME_WORK
    public class ContractTimeWorkResult : OptimulaTermResult
    {
        public ContractTimeWorkResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // PaymentBasis		PAYMENT_BASIS
    public class PaymentBasisResult : OptimulaTermResult
    {
        public PaymentBasisResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // OptimusBasis		OPTIMUS_BASIS
    public class OptimusBasisResult : OptimulaTermResult
    {
        public OptimusBasisResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // OptimusFixed		OPTIMUS_FIXED
    public class OptimusFixedResult : OptimulaTermResult
    {
        public OptimusFixedResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // AgrworkHours		AGRWORK_HOURS
    public class AgrworkHoursResult : OptimulaTermResult
    {
        public AgrworkHoursResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // AllowceHours		ALLOWCE_HOURS
    public class AllowceHoursResult : OptimulaTermResult
    {
        public AllowceHoursResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

}
