using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Payrolex.Registry.Constants;

namespace HraveMzdy.Procezor.Payrolex.Registry.Providers
{
    // SocialDeclare		SOCIAL_DECLARE
    public class SocialDeclareResult : PayrolexTermResult
    {
        public Int16 InterestCode { get; private set; }
        public WorkSocialTerms ContractType { get; private set; }
        public SocialDeclareResult(ITermTarget target, IArticleSpec spec,
            Int16 interestCode, WorkSocialTerms contractType) 
            : base(target, spec, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            InterestCode = interestCode;
            ContractType = contractType;
        }
        public override string ResultMessage()
        {
            return $"Interrest: {this.InterestCode}, Type: {Enum.GetName<WorkSocialTerms>(this.ContractType)}";
        }
    }

    // SocialIncome		SOCIAL_INCOME
    public class SocialIncomeResult : PayrolexTermResult
    {
        public SocialIncomeResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // SocialBase		SOCIAL_BASE
    public class SocialBaseResult : PayrolexTermResult
    {
        public Int32 AnnuityBase { get; private set; }
        public SocialBaseResult(ITermTarget target, IArticleSpec spec,
            Int32 annuityBase, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
            AnnuityBase = annuityBase;
        }
        public override string ResultMessage()
        {
            return $"Annuity Base: {this.AnnuityBase}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // SocialBaseEmployee		SOCIAL_BASE_EMPLOYEE
    public class SocialBaseEmployeeResult : PayrolexTermResult
    {
        public SocialBaseEmployeeResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // SocialBaseEmployer		SOCIAL_BASE_EMPLOYER
    public class SocialBaseEmployerResult : PayrolexTermResult
    {
        public SocialBaseEmployerResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // SocialBaseOvercap		SOCIAL_BASE_OVERCAP
    public class SocialBaseOvercapResult : PayrolexTermResult
    {
        public SocialBaseOvercapResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // SocialPaymEmployee		SOCIAL_PAYM_EMPLOYEE
    public class SocialPaymEmployeeResult : PayrolexTermResult
    {
        public Int32 EmployeeBasis { get; private set; }
        public Int32 GeneralsBasis { get; private set; }
        public SocialPaymEmployeeResult(ITermTarget target, IArticleSpec spec,
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

    // SocialPaymEmployer		SOCIAL_PAYM_EMPLOYER
    public class SocialPaymEmployerResult : PayrolexTermResult
    {
        public Int32 EmployerBasis { get; private set; }
        public Int32 GeneralsBasis { get; private set; }
        public SocialPaymEmployerResult(ITermTarget target, IArticleSpec spec,
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
