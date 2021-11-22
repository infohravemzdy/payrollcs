using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Interfaces;

namespace Procezor.Payrolex.Registry.Providers
{
    // HealthDeclare		HEALTH_DECLARE
    public class HealthDeclareResult : PayrolexTermResult
    {
        public HealthDeclareResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // HealthIncome		HEALTH_INCOME
    public class HealthIncomeResult : PayrolexTermResult
    {
        public HealthIncomeResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // HealthBase		HEALTH_BASE
    public class HealthBaseResult : PayrolexTermResult
    {
        public HealthBaseResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // HealthBaseEmployee		HEALTH_BASE_EMPLOYEE
    public class HealthBaseEmployeeResult : PayrolexTermResult
    {
        public HealthBaseEmployeeResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // HealthBaseEmployer		HEALTH_BASE_EMPLOYER
    public class HealthBaseEmployerResult : PayrolexTermResult
    {
        public HealthBaseEmployerResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // HealthBaseMandate		HEALTH_BASE_MANDATE
    public class HealthBaseMandateResult : PayrolexTermResult
    {
        public HealthBaseMandateResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // HealthPaymEmployee		HEALTH_PAYM_EMPLOYEE
    public class HealthPaymEmployeeResult : PayrolexTermResult
    {
        public HealthPaymEmployeeResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // HealthPaymEmployer		HEALTH_PAYM_EMPLOYER
    public class HealthPaymEmployerResult : PayrolexTermResult
    {
        public HealthPaymEmployerResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

}
