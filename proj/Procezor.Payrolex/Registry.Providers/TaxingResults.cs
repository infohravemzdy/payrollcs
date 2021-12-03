using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Payrolex.Registry.Constants;

namespace HraveMzdy.Procezor.Payrolex.Registry.Providers
{
    // TaxingDeclare		TAXING_DECLARE
    public class TaxingDeclareResult : PayrolexTermResult
    {
        public Int16 InterestCode { get; private set; }
        public WorkTaxingTerms ContractType { get; private set; }

        public TaxingDeclareResult(ITermTarget target, IArticleSpec spec, 
            Int16 interestCode, WorkTaxingTerms contractType)
            : base(target, spec, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            InterestCode = interestCode;
            ContractType = contractType;
        }
        public override string ResultMessage()
        {
            return $"Interrest: {this.InterestCode}, Type: {Enum.GetName<WorkTaxingTerms>(this.ContractType)}";
        }
    }

    // TaxingSigning		TAXING_SIGNING
    public class TaxingSigningResult : PayrolexTermResult
    {
        public Int16 DeclSignCode { get; private set; }
        public TaxingSigningResult(ITermTarget target, IArticleSpec spec,
            Int16 declSignCode)
            : base(target, spec, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            DeclSignCode = declSignCode;
        }
        public override string ResultMessage()
        {
            return $"Declaration Sign: {this.DeclSignCode}";
        }
    }

    // TaxingIncomeSubject		TAXING_INCOME_SUBJECT
    public class TaxingIncomeSubjectResult : PayrolexTermResult
    {
        public WorkTaxingTerms SubjectType { get; private set; }

        public TaxingIncomeSubjectResult(ITermTarget target, IArticleSpec spec, 
            WorkTaxingTerms subjectType, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
            SubjectType = subjectType;
        }
        public override string ResultMessage()
        {
            return $"Type: {Enum.GetName<WorkTaxingTerms>(this.SubjectType)}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingIncomeHealth		TAXING_INCOME_HEALTH
    public class TaxingIncomeHealthResult : PayrolexTermResult
    {
        public TaxingIncomeHealthResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingIncomeSocial		TAXING_INCOME_SOCIAL
    public class TaxingIncomeSocialResult : PayrolexTermResult
    {
        public TaxingIncomeSocialResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingAdvancesIncome		TAXING_ADVANCES_INCOME
    public class TaxingAdvancesIncomeResult : PayrolexTermResult
    {
        public TaxingAdvancesIncomeResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingAdvancesHealth		TAXING_ADVANCES_HEALTH
    public class TaxingAdvancesHealthResult : PayrolexTermResult
    {
        public TaxingAdvancesHealthResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingAdvancesSocial		TAXING_ADVANCES_SOCIAL
    public class TaxingAdvancesSocialResult : PayrolexTermResult
    {
        public TaxingAdvancesSocialResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingAdvancesBasis		TAXING_ADVANCES_BASIS
    public class TaxingAdvancesBasisResult : PayrolexTermResult
    {
        public TaxingAdvancesBasisResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingSolidaryBasis		TAXING_SOLIDARY_BASIS
    public class TaxingSolidaryBasisResult : PayrolexTermResult
    {
        public TaxingSolidaryBasisResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingAdvances		TAXING_ADVANCES
    public class TaxingAdvancesResult : PayrolexTermResult
    {
        public TaxingAdvancesResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingSolidary		TAXING_SOLIDARY
    public class TaxingSolidaryResult : PayrolexTermResult
    {
        public TaxingSolidaryResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingAdvancesTotal		TAXING_ADVANCES_TOTAL
    public class TaxingAdvancesTotalResult : PayrolexTermResult
    {
        public TaxingAdvancesTotalResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingWithholdIncome		TAXING_WITHHOLD_INCOME
    public class TaxingWithholdIncomeResult : PayrolexTermResult
    {
        public TaxingWithholdIncomeResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingWithholdHealth		TAXING_WITHHOLD_HEALTH
    public class TaxingWithholdHealthResult : PayrolexTermResult
    {
        public TaxingWithholdHealthResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingWithholdSocial		TAXING_WITHHOLD_SOCIAL
    public class TaxingWithholdSocialResult : PayrolexTermResult
    {
        public TaxingWithholdSocialResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingWithholdBasis		TAXING_WITHHOLD_BASIS
    public class TaxingWithholdBasisResult : PayrolexTermResult
    {
        public TaxingWithholdBasisResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingWithholdTotal		TAXING_WITHHOLD_TOTAL
    public class TaxingWithholdTotalResult : PayrolexTermResult
    {
        public TaxingWithholdTotalResult(ITermTarget target, IArticleSpec spec, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

}
