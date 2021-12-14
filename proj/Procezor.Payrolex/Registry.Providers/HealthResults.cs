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
        public WorkHealthTerms SubjectType { get; private set; }
        public Int16 ParticeCode { get; private set; }
        public HealthIncomeResult(ITermTarget target, ContractCode con, IArticleSpec spec,
            WorkHealthTerms subjectType, Int16 particeCode, Int32 value, Int32 basis, string descr) : base(target, con, spec, value, basis, descr)
        {
            SubjectType = subjectType;
            ParticeCode = particeCode;
        }
        public override string ResultMessage()
        {
            return $"Term: {Enum.GetName<WorkHealthTerms>(this.IncomeTerm())}, Partice: {this.ParticeCode}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
        public Int16 SetParticeCode(Int16 particeCode)
        {
            ParticeCode = particeCode;
            return ParticeCode;
        }
        public WorkHealthTerms IncomeTerm()
        {
            WorkHealthTerms resultKind = WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS;
            switch (SubjectType)
            {
                case WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS:
                    resultKind = WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS;
                    break;
                case WorkHealthTerms.HEALTH_TERM_AGREEM_WORK:
                    resultKind = WorkHealthTerms.HEALTH_TERM_AGREEM_WORK;
                    break;
                case WorkHealthTerms.HEALTH_TERM_AGREEM_TASK:
                    resultKind = WorkHealthTerms.HEALTH_TERM_AGREEM_TASK;
                    break;
                case WorkHealthTerms.HEALTH_TERM_NONE_EMPLOY:
                    resultKind = WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS;
                    break;
                case WorkHealthTerms.HEALTH_TERM_BY_CONTRACT:
                    resultKind = WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS;
                    break;
            }
            return resultKind;
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
        public HealthBaseEmployeeResult(ITermTarget target, IArticleSpec spec, 
            Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
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
        public WorkHealthTerms SubjectType { get; private set; }
        public HealthBaseOvercapResult(ITermTarget target, ContractCode con, IArticleSpec spec,
            WorkHealthTerms subjectType, Int32 value, Int32 basis, string descr) : base(target, con, spec, value, basis, descr)
        {
            SubjectType = subjectType;
        }
        public override string ResultMessage()
        {
            return $"Type: {Enum.GetName<WorkHealthTerms>(this.SubjectType)}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
        public Int32 IncomeScore()
        {
            Int32 resultBase = 0;
            Int32 resultType = 0;
            switch (SubjectType)
            {
                case WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS:
                    resultBase = 9000;
                    break;
                case WorkHealthTerms.HEALTH_TERM_AGREEM_WORK:
                    resultBase = 5000;
                    break;
                case WorkHealthTerms.HEALTH_TERM_AGREEM_TASK:
                    resultBase = 4000;
                    break;
                case WorkHealthTerms.HEALTH_TERM_NONE_EMPLOY:
                    resultBase = 0;
                    break;
                case WorkHealthTerms.HEALTH_TERM_BY_CONTRACT:
                    resultBase = 0;
                    break;
            }
            return resultType + resultBase;
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
        public Int32 TotalBasic()
        {
            return (EmployeeBasis + GeneralsBasis);
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
        public Int32 TotalBasic()
        {
            return (EmployerBasis + GeneralsBasis);
        }
    }
}
