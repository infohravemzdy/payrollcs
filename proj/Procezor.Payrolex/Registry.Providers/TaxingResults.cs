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
        public TaxDeclSignOption DeclSignOpts { get; private set; }
        public TaxNoneSignOption NoneSignOpts { get; private set; }
        public TaxingSigningResult(ITermTarget target, IArticleSpec spec,
            TaxDeclSignOption declSignOpts, TaxNoneSignOption noneSignOpts)
            : base(target, spec, VALUE_ZERO, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            DeclSignOpts = declSignOpts;
            NoneSignOpts = noneSignOpts;
        }
        public override string ResultMessage()
        {
            return $"Declaration Sign Opts: {Enum.GetName<TaxDeclSignOption>(this.DeclSignOpts)}, None Sign Opts: {Enum.GetName<TaxNoneSignOption>(this.NoneSignOpts)}";
        }
        public string DeclSignText()
        {
            switch (DeclSignOpts)
            {
                case TaxDeclSignOption.DECL_TAX_DO_SIGNED:
                    return "YES";
                case TaxDeclSignOption.DECL_TAX_NO_SIGNED:
                    return "NO";
            }
            return "NO";
        }
        public TaxingSigningTarget ResultTarget()
        {
            return Target as TaxingSigningTarget;
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
        public WorkTaxingTerms SubjectType { get; private set; }
        public WorkHealthTerms SubjectTerm { get; private set; }
        public TaxingIncomeHealthResult(ITermTarget target, ContractCode con, IArticleSpec spec, 
            WorkTaxingTerms subjectType, Int32 value, Int32 basis, string descr) : base(target, con, spec, value, basis, descr)
        {
            SubjectType = subjectType;
        }
        public override string ResultMessage()
        {
            return $"Type: {Enum.GetName<WorkTaxingTerms>(this.SubjectType)}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
        public Int32 IncomeScore()
        {
            Int32 resultType = 0;
            switch (SubjectType)
            {
                case WorkTaxingTerms.TAXING_TERM_EMPLOYMENTS:
                    resultType = 900;
                    break;
                case WorkTaxingTerms.TAXING_TERM_AGREEM_TASK:
                    resultType = 100;
                    break;
                case WorkTaxingTerms.TAXING_TERM_STATUT_PART:
                    resultType = 500;
                    break;
                case WorkTaxingTerms.TAXING_TERM_BY_CONTRACT:
                    resultType = 0;
                    break;
            }
            Int32 resultBase = 0;
            switch (SubjectTerm)
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

    // TaxingIncomeSocial		TAXING_INCOME_SOCIAL
    public class TaxingIncomeSocialResult : PayrolexTermResult
    {
        public WorkTaxingTerms SubjectType { get; private set; }
        public WorkSocialTerms SubjectTerm { get; private set; }
        public TaxingIncomeSocialResult(ITermTarget target, ContractCode con, IArticleSpec spec,
            WorkTaxingTerms subjectType, Int32 value, Int32 basis, string descr) : base(target, con, spec, value, basis, descr)
        {
            SubjectType = subjectType;
        }
        public override string ResultMessage()
        {
            return $"Type: {Enum.GetName<WorkTaxingTerms>(this.SubjectType)}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
        public Int32 IncomeScore()
        {
            Int32 resultType = 0;
            switch (SubjectType)
            {
                case WorkTaxingTerms.TAXING_TERM_EMPLOYMENTS:
                    resultType = 900;
                    break;
                case WorkTaxingTerms.TAXING_TERM_AGREEM_TASK:
                    resultType = 100;
                    break;
                case WorkTaxingTerms.TAXING_TERM_STATUT_PART:
                    resultType = 500;
                    break;
                case WorkTaxingTerms.TAXING_TERM_BY_CONTRACT:
                    resultType = 0;
                    break;
            }
            Int32 resultBase = 0;
            switch (SubjectTerm)
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
            }
            return resultType + resultBase;
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
    // TaxingAllowancePayer		TAXING_ALLOWANCE_PAYER
    public class TaxingAllowancePayerResult : PayrolexTermResult
    {
        public TaxDeclBenfOption BenefitApply { get; private set; }
        public TaxingAllowancePayerResult(ITermTarget target, IArticleSpec spec,
            TaxDeclBenfOption benefitApply, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
            BenefitApply = benefitApply;
        }
        public override string ResultMessage()
        {
            return $"Benefit: {Enum.GetName<TaxDeclBenfOption>(this.BenefitApply)}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingAllowanceChild		TAXING_ALLOWANCE_CHILD
    public class TaxingAllowanceChildResult : PayrolexTermResult
    {
        public TaxDeclBenfOption BenefitApply { get; private set; }
        public Int32 BenefitDisab { get; private set; }
        public Int32 BenefitOrder { get; private set; }
        public TaxingAllowanceChildResult(ITermTarget target, IArticleSpec spec,
            TaxDeclBenfOption benefitApply, Int32 benefitDisab, Int32 benefitOrder, 
            Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
            BenefitApply = benefitApply;
            BenefitDisab = benefitDisab;
            BenefitOrder = benefitOrder;
        }
        public override string ResultMessage()
        {
            return $"Benefit: {Enum.GetName<TaxDeclBenfOption>(this.BenefitApply)}, Disability: {this.BenefitDisab}, Order: {this.BenefitOrder}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingAllowanceDisab		TAXING_ALLOWANCE_DISAB
    public class TaxingAllowanceDisabResult : PayrolexTermResult
    {
        public TaxDeclDisabOption BenefitApply { get; private set; }
        public TaxingAllowanceDisabResult(ITermTarget target, IArticleSpec spec,
            TaxDeclDisabOption benefitApply, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
            BenefitApply = benefitApply;
        }
        public override string ResultMessage()
        {
            return $"Benefit: {Enum.GetName<TaxDeclDisabOption>(this.BenefitApply)}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingAllowanceStudy		TAXING_ALLOWANCE_STUDY
    public class TaxingAllowanceStudyResult : PayrolexTermResult
    {
        public TaxDeclBenfOption BenefitApply { get; private set; }
        public TaxingAllowanceStudyResult(ITermTarget target, IArticleSpec spec,
            TaxDeclBenfOption benefitApply, Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
            BenefitApply = benefitApply;
        }
        public override string ResultMessage()
        {
            return $"Benefit: {Enum.GetName<TaxDeclBenfOption>(this.BenefitApply)}, Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingRebatePayer		TAXING_REBATE_PAYER
    public class TaxingRebatePayerResult : PayrolexTermResult
    {
        public TaxingRebatePayerResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingRebateChild		TAXING_REBATE_CHILD
    public class TaxingRebateChildResult : PayrolexTermResult
    {
        public TaxingRebateChildResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingBonusChild		TAXING_BONUS_CHILD
    public class TaxingBonusChildResult : PayrolexTermResult
    {
        public TaxingBonusChildResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }
    // TaxingPaymAdvances		TAXING_PAYM_ADVANCES
    public class TaxingPaymAdvancesResult : PayrolexTermResult
    {
        public TaxingPaymAdvancesResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }

    // TaxingPaymWithhold		TAXING_PAYM_WITHHOLD
    public class TaxingPaymWithholdResult : PayrolexTermResult
    {
        public TaxingPaymWithholdResult(ITermTarget target, IArticleSpec spec,
            Int32 value, Int32 basis, string descr) : base(target, spec, value, basis, descr)
        {
        }
        public override string ResultMessage()
        {
            return $"Value: {this.ResultValue}, Basis: {this.ResultBasis}";
        }
    }
}
