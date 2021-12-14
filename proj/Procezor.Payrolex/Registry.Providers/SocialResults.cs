using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Payrolex.Registry.Constants;
using HraveMzdy.Procezor.Service.Types;

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
        public WorkSocialTerms SubjectType { get; private set; }
        public Int16 ParticeCode { get; private set; }
        public SocialIncomeResult(ITermTarget target, ContractCode con, IArticleSpec spec,
            WorkSocialTerms subjectType, Int16 particeCode, Int32 value, Int32 basis, string descr) : base(target, con, spec, value, basis, descr)
        {
            SubjectType = subjectType;
            ParticeCode = particeCode;
        }
        public override string ResultMessage()
        {
            return $"Term: {Enum.GetName<WorkSocialTerms>(this.IncomeTerm())}, Partice: {this.ParticeCode}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
        public Int16 SetParticeCode(Int16 particeCode)
        {
            ParticeCode = particeCode;
            return ParticeCode;
        }
        public WorkSocialTerms IncomeTerm()
        {
            WorkSocialTerms resultKind = WorkSocialTerms.SOCIAL_TERM_EMPLOYMENTS;
            switch (SubjectType)
            {
                case WorkSocialTerms.SOCIAL_TERM_EMPLOYMENTS:
                    resultKind = WorkSocialTerms.SOCIAL_TERM_EMPLOYMENTS;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_SMALLS_EMPL:
                    resultKind = WorkSocialTerms.SOCIAL_TERM_SMALLS_EMPL;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_SHORTS_MEET:
                    resultKind = WorkSocialTerms.SOCIAL_TERM_SHORTS_MEET;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_SHORTS_DENY:
                    resultKind = WorkSocialTerms.SOCIAL_TERM_SHORTS_DENY;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_AGREEM_TASK:
                    resultKind = WorkSocialTerms.SOCIAL_TERM_AGREEM_TASK;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_BY_CONTRACT:
                    resultKind = WorkSocialTerms.SOCIAL_TERM_EMPLOYMENTS;
                    break;
            }
            return resultKind;
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
        public WorkSocialTerms SubjectType { get; private set; }
        public SocialBaseOvercapResult(ITermTarget target, ContractCode con, IArticleSpec spec,
            WorkSocialTerms subjectType, Int32 value, Int32 basis, string descr) : base(target, con, spec, value, basis, descr)
        {
            SubjectType = subjectType;
        }
        public override string ResultMessage()
        {
            return $"Type: {Enum.GetName<WorkSocialTerms>(this.SubjectType)}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
        public Int32 IncomeScore()
        {
            Int32 resultBase = 0;
            Int32 resultType = 0;
            switch (SubjectType)
            {
                case WorkSocialTerms.SOCIAL_TERM_EMPLOYMENTS:
                    resultType = 900;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_SMALLS_EMPL:
                    resultType = 100;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_SHORTS_MEET:
                    resultType = 500;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_SHORTS_DENY:
                    resultType = 0;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_BY_CONTRACT:
                    resultType = 0;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_AGREEM_TASK:
                    resultType = 0;
                    break;
            }
            return resultType + resultBase;
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
        public Int32 TotalBasic()
        {
            return (EmployeeBasis + GeneralsBasis);
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
        public Int32 TotalBasic()
        {
            return (EmployerBasis + GeneralsBasis);
        }
    }
}
