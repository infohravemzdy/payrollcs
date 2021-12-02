using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Payrolex.Registry.Constants;

namespace HraveMzdy.Procezor.Payrolex.Registry.Providers
{
    // HealthDeclare		HEALTH_DECLARE
    public class HealthDeclareResult : PayrolexTermResult
    {
        public Int16 InterestCode { get; private set; }
        public WorkHealthTerms ContractType { get; private set; }
        public Int16 MandatorBase { get; private set; }

        public HealthDeclareResult(ITermTarget target, IArticleSpec spec, 
            Int16 interestCode, WorkHealthTerms contractType, Int16 mandatorBase) 
            : base(target, spec, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            InterestCode = interestCode;
            ContractType = contractType;
            MandatorBase = mandatorBase;
        }
        public override string ResultMessage()
        {
            return $"Interrest: {this.InterestCode}, Type: {Enum.GetName<WorkHealthTerms>(this.ContractType)}, Mandatory: {this.MandatorBase}";
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
        public Int32 AnnuityBase { get; private set; }

        public HealthBaseResult(ITermTarget target, IArticleSpec spec, 
            Int32 annuityBase, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
            AnnuityBase = annuityBase;
        }
        public override string ResultMessage()
        {
            return $"Annuity Base: {this.AnnuityBase}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
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

    // HealthBaseOvercap		HEALTH_BASE_OVERCAP
    public class HealthBaseOvercapResult : PayrolexTermResult
    {
        public HealthBaseOvercapResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
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
        public Int32 EmployeeBasis { get; private set; }
        public Int32 GeneralsBasis { get; private set; }
        public HealthPaymEmployeeResult(ITermTarget target, IArticleSpec spec, 
            Int32 employeeBasis, Int32 generalsBasis, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
            EmployeeBasis = employeeBasis;
            GeneralsBasis = generalsBasis;
        }
        public override string ResultMessage()
        {
            return $"Employee: {this.EmployeeBasis}, Generals: {this.GeneralsBasis}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // HealthPaymEmployer		HEALTH_PAYM_EMPLOYER
    public class HealthPaymEmployerResult : PayrolexTermResult
    {
        public Int32 EmployerBasis { get; private set; }
        public Int32 GeneralsBasis { get; private set; }
        public HealthPaymEmployerResult(ITermTarget target, IArticleSpec spec, 
            Int32 employerBasis, Int32 generalsBasis, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
            EmployerBasis = employerBasis;
            GeneralsBasis = generalsBasis;
        }
        public override string ResultMessage()
        {
            return $"Employer: {this.EmployerBasis}, Generals: {this.GeneralsBasis}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

}
