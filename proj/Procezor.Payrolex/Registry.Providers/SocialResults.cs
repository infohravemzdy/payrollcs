﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;
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
        public Int16 InterestCode { get; private set; }
        public WorkSocialTerms SubjectType { get; private set; }
        public Int16 ParticyCode { get; private set; }
        public SocialIncomeResult(ITermTarget target, ContractCode con, IArticleSpec spec,
            Int16 interestCode, WorkSocialTerms subjectType, Int16 particyCode, Int32 value, Int32 basis, string descr) : base(target, con, spec, value, basis, descr)
        {
            InterestCode = interestCode;
            SubjectType = subjectType;
            ParticyCode = particyCode;
        }
        public override string ResultMessage()
        {
            return $"Interrest: {this.InterestCode}, Term: {Enum.GetName<WorkSocialTerms>(this.IncomeTerm())}, Particy: {this.ParticyCode}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
        public Int16 SetParticyCode(Int16 particyCode)
        {
            ParticyCode = particyCode;
            return ParticyCode;
        }
        public Int16 HasSubjectTermZMR()
        {
            switch (SubjectType)
            {
                case WorkSocialTerms.SOCIAL_TERM_EMPLOYMENTS:
                    return 0;
                case WorkSocialTerms.SOCIAL_TERM_SMALLS_EMPL:
                    return 1;
                case WorkSocialTerms.SOCIAL_TERM_SHORTS_MEET:
                    return 0;
                case WorkSocialTerms.SOCIAL_TERM_SHORTS_DENY:
                    return 0;
                case WorkSocialTerms.SOCIAL_TERM_AGREEM_TASK:
                    return 0;
                case WorkSocialTerms.SOCIAL_TERM_BY_CONTRACT:
                    return 0;
            }
            return 0;
        }
        public Int16 HasSubjectTermZKR()
        {
            switch (SubjectType)
            {
                case WorkSocialTerms.SOCIAL_TERM_EMPLOYMENTS:
                    return 0;
                case WorkSocialTerms.SOCIAL_TERM_SMALLS_EMPL:
                    return 0;
                case WorkSocialTerms.SOCIAL_TERM_SHORTS_MEET:
                    return 1;
                case WorkSocialTerms.SOCIAL_TERM_SHORTS_DENY:
                    return 1;
                case WorkSocialTerms.SOCIAL_TERM_AGREEM_TASK:
                    return 0;
                case WorkSocialTerms.SOCIAL_TERM_BY_CONTRACT:
                    return 0;
            }
            return 0;
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
        public Int32 TermScore()
        {
            Int32 resultBase = 0;
            switch (SubjectType)
            {
                case WorkSocialTerms.SOCIAL_TERM_EMPLOYMENTS:
                    resultBase = 9000;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_SMALLS_EMPL:
                    resultBase = 5000;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_SHORTS_MEET:
                    resultBase = 4000;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_SHORTS_DENY:
                    resultBase = 0;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_BY_CONTRACT:
                    resultBase = 0;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_AGREEM_TASK:
                    resultBase = 0;
                    break;
            }
            Int32 resultScore = resultBase;
            return resultScore;
        }
        private class IncomeTermComparator : IComparer<SocialIncomeResult>
        {
            public IncomeTermComparator()
            {
            }

            public int Compare(SocialIncomeResult x, SocialIncomeResult y)
            {
                Int32 xScore = x.TermScore();
                Int32 yScore = y.TermScore();

                if (xScore.CompareTo(yScore) == 0)
                {
                    return x.Contract.CompareTo(y.Contract);
                }
                return xScore.CompareTo(yScore);
            }
        }
        public static IComparer<SocialIncomeResult> ResultComparator()
        {
            return new IncomeTermComparator();
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
        private class IncomeTermComparator : IComparer<SocialBaseOvercapResult>
        {
            public IncomeTermComparator()
            {
            }

            public int Compare(SocialBaseOvercapResult x, SocialBaseOvercapResult y)
            {
                Int32 xIncomeScore = x.IncomeScore();
                Int32 yIncomeScore = y.IncomeScore();

                if (xIncomeScore.CompareTo(yIncomeScore) == 0)
                {
                    return x.Contract.CompareTo(y.Contract);
                }
                return xIncomeScore.CompareTo(yIncomeScore);
            }
        }
        public static IComparer<SocialBaseOvercapResult> ResultComparator()
        {
            return new IncomeTermComparator();
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
