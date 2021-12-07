using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Procezor.Payrolex.Registry.Constants;

namespace HraveMzdy.Procezor.Payrolex.Registry.Providers
{
    // TaxingDeclare		TAXING_DECLARE
    public class TaxingDeclareTarget : PayrolexTermTarget
    {
        public Int16 InterestCode { get; private set; }
        public WorkTaxingTerms ContractType { get; private set; }

        public TaxingDeclareTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int16 interestCode, WorkTaxingTerms contractType) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            InterestCode = interestCode;
            ContractType = contractType;
        }
    }

    // TaxingSigning		TAXING_SIGNING
    public class TaxingSigningTarget : PayrolexTermTarget
    {
        public TaxDeclSignOption DeclSignOpts { get; private set; }
        public TaxNoneSignOption NoneSignOpts { get; private set; }

        public TaxingSigningTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            TaxDeclSignOption declSignOpts, TaxNoneSignOption noneSignOpts) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            DeclSignOpts = declSignOpts;
            NoneSignOpts = noneSignOpts;
        }
    }

    // TaxingIncomeSubject		TAXING_INCOME_SUBJECT
    public class TaxingIncomeSubjectTarget : PayrolexTermTarget
    {
        public WorkTaxingTerms SubjectType { get; private set; }

        public TaxingIncomeSubjectTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            WorkTaxingTerms subjectType) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            SubjectType = subjectType;
        }
    }

    // TaxingIncomeHealth		TAXING_INCOME_HEALTH
    public class TaxingIncomeHealthTarget : PayrolexTermTarget
    {
        public TaxingIncomeHealthTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
        }
    }

    // TaxingIncomeSocial		TAXING_INCOME_SOCIAL
    public class TaxingIncomeSocialTarget : PayrolexTermTarget
    {
        public TaxingIncomeSocialTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
        }
    }

    // TaxingAdvancesIncome		TAXING_ADVANCES_INCOME
    public class TaxingAdvancesIncomeTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TaxingAdvancesIncomeTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // TaxingAdvancesHealth		TAXING_ADVANCES_HEALTH
    public class TaxingAdvancesHealthTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TaxingAdvancesHealthTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // TaxingAdvancesSocial		TAXING_ADVANCES_SOCIAL
    public class TaxingAdvancesSocialTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TaxingAdvancesSocialTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // TaxingAdvancesBasis		TAXING_ADVANCES_BASIS
    public class TaxingAdvancesBasisTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TaxingAdvancesBasisTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // TaxingSolidaryBasis		TAXING_SOLIDARY_BASIS
    public class TaxingSolidaryBasisTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TaxingSolidaryBasisTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // TaxingAdvances		TAXING_ADVANCES
    public class TaxingAdvancesTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TaxingAdvancesTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // TaxingSolidary		TAXING_SOLIDARY
    public class TaxingSolidaryTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TaxingSolidaryTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // TaxingAdvancesTotal		TAXING_ADVANCES_TOTAL
    public class TaxingAdvancesTotalTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TaxingAdvancesTotalTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // TaxingWithholdIncome		TAXING_WITHHOLD_INCOME
    public class TaxingWithholdIncomeTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TaxingWithholdIncomeTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // TaxingWithholdHealth		TAXING_WITHHOLD_HEALTH
    public class TaxingWithholdHealthTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TaxingWithholdHealthTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // TaxingWithholdSocial		TAXING_WITHHOLD_SOCIAL
    public class TaxingWithholdSocialTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TaxingWithholdSocialTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // TaxingWithholdBasis		TAXING_WITHHOLD_BASIS
    public class TaxingWithholdBasisTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TaxingWithholdBasisTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

    // TaxingWithholdTotal		TAXING_WITHHOLD_TOTAL
    public class TaxingWithholdTotalTarget : PayrolexTermTarget
    {
        public Int32 TargetVals { get; private set; }

        public TaxingWithholdTotalTarget(MonthCode monthCode, ContractCode contract, PositionCode position, VariantCode variant,
            ArticleCode article, ConceptCode concept,
            Int32 targetVals) :
            base(monthCode, contract, position, variant, article, concept, BASIS_ZERO, DESCRIPTION_EMPTY)
        {
            TargetVals = targetVals;
        }
    }

}
