using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Procezor.Payrolex.Registry.Constants;

namespace HraveMzdy.Procezor.Payrolex.Registry.Providers
{
    // TaxingDeclare		TAXING_DECLARE
    class TaxingDeclareArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_DECLARE;
        public TaxingDeclareArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingDeclareArtSpec(this.Code.Value);
        }
    }

    class TaxingDeclareArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_DECLARE;
        public TaxingDeclareArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingSigning		TAXING_SIGNING
    class TaxingSigningArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_SIGNING;
        public TaxingSigningArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingSigningArtSpec(this.Code.Value);
        }
    }

    class TaxingSigningArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_SIGNING;
        public TaxingSigningArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }
    // TaxingIncomeSubject		TAXING_INCOME_SUBJECT
    class TaxingIncomeSubjectArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SUBJECT;
        public TaxingIncomeSubjectArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingIncomeSubjectArtSpec(this.Code.Value);
        }
    }

    class TaxingIncomeSubjectArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_INCOME_SUBJECT;
        public TaxingIncomeSubjectArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingIncomeHealth		TAXING_INCOME_HEALTH
    class TaxingIncomeHealthArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_HEALTH;
        public TaxingIncomeHealthArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingIncomeHealthArtSpec(this.Code.Value);
        }
    }

    class TaxingIncomeHealthArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_INCOME_HEALTH;
        public TaxingIncomeHealthArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingIncomeSocial		TAXING_INCOME_SOCIAL
    class TaxingIncomeSocialArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_INCOME_SOCIAL;
        public TaxingIncomeSocialArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingIncomeSocialArtSpec(this.Code.Value);
        }
    }

    class TaxingIncomeSocialArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_INCOME_SOCIAL;
        public TaxingIncomeSocialArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingAdvancesIncome		TAXING_ADVANCES_INCOME
    class TaxingAdvancesIncomeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_INCOME;
        public TaxingAdvancesIncomeArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvancesIncomeArtSpec(this.Code.Value);
        }
    }

    class TaxingAdvancesIncomeArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ADVANCES_INCOME;
        public TaxingAdvancesIncomeArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingAdvancesHealth		TAXING_ADVANCES_HEALTH
    class TaxingAdvancesHealthArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_HEALTH;
        public TaxingAdvancesHealthArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvancesHealthArtSpec(this.Code.Value);
        }
    }

    class TaxingAdvancesHealthArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ADVANCES_HEALTH;
        public TaxingAdvancesHealthArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingAdvancesSocial		TAXING_ADVANCES_SOCIAL
    class TaxingAdvancesSocialArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_SOCIAL;
        public TaxingAdvancesSocialArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvancesSocialArtSpec(this.Code.Value);
        }
    }

    class TaxingAdvancesSocialArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ADVANCES_SOCIAL;
        public TaxingAdvancesSocialArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingAdvancesBasis		TAXING_ADVANCES_BASIS
    class TaxingAdvancesBasisArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_BASIS;
        public TaxingAdvancesBasisArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvancesBasisArtSpec(this.Code.Value);
        }
    }

    class TaxingAdvancesBasisArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ADVANCES_BASIS;
        public TaxingAdvancesBasisArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingSolidaryBasis		TAXING_SOLIDARY_BASIS
    class TaxingSolidaryBasisArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_SOLIDARY_BASIS;
        public TaxingSolidaryBasisArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingSolidaryBasisArtSpec(this.Code.Value);
        }
    }

    class TaxingSolidaryBasisArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_SOLIDARY_BASIS;
        public TaxingSolidaryBasisArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingAdvances		TAXING_ADVANCES
    class TaxingAdvancesArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES;
        public TaxingAdvancesArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvancesArtSpec(this.Code.Value);
        }
    }

    class TaxingAdvancesArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ADVANCES;
        public TaxingAdvancesArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingSolidary		TAXING_SOLIDARY
    class TaxingSolidaryArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_SOLIDARY;
        public TaxingSolidaryArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingSolidaryArtSpec(this.Code.Value);
        }
    }

    class TaxingSolidaryArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_SOLIDARY;
        public TaxingSolidaryArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingAdvancesTotal		TAXING_ADVANCES_TOTAL
    class TaxingAdvancesTotalArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_ADVANCES_TOTAL;
        public TaxingAdvancesTotalArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvancesTotalArtSpec(this.Code.Value);
        }
    }

    class TaxingAdvancesTotalArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ADVANCES_TOTAL;
        public TaxingAdvancesTotalArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingWithholdIncome		TAXING_WITHHOLD_INCOME
    class TaxingWithholdIncomeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_INCOME;
        public TaxingWithholdIncomeArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingWithholdIncomeArtSpec(this.Code.Value);
        }
    }

    class TaxingWithholdIncomeArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_WITHHOLD_INCOME;
        public TaxingWithholdIncomeArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingWithholdHealth		TAXING_WITHHOLD_HEALTH
    class TaxingWithholdHealthArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_HEALTH;
        public TaxingWithholdHealthArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingWithholdHealthArtSpec(this.Code.Value);
        }
    }

    class TaxingWithholdHealthArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_WITHHOLD_HEALTH;
        public TaxingWithholdHealthArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingWithholdSocial		TAXING_WITHHOLD_SOCIAL
    class TaxingWithholdSocialArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_SOCIAL;
        public TaxingWithholdSocialArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingWithholdSocialArtSpec(this.Code.Value);
        }
    }

    class TaxingWithholdSocialArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_WITHHOLD_SOCIAL;
        public TaxingWithholdSocialArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingWithholdBasis		TAXING_WITHHOLD_BASIS
    class TaxingWithholdBasisArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_BASIS;
        public TaxingWithholdBasisArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingWithholdBasisArtSpec(this.Code.Value);
        }
    }

    class TaxingWithholdBasisArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_WITHHOLD_BASIS;
        public TaxingWithholdBasisArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingWithholdTotal		TAXING_WITHHOLD_TOTAL
    class TaxingWithholdTotalArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_WITHHOLD_TOTAL;
        public TaxingWithholdTotalArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingWithholdTotalArtSpec(this.Code.Value);
        }
    }

    class TaxingWithholdTotalArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_WITHHOLD_TOTAL;
        public TaxingWithholdTotalArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }
    // TaxingAllowancePayer		TAXING_ALLOWANCE_PAYER
    class TaxingAllowancePayerArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_PAYER;
        public TaxingAllowancePayerArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAllowancePayerArtSpec(this.Code.Value);
        }
    }

    class TaxingAllowancePayerArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ALLOWANCE_PAYER;
        public TaxingAllowancePayerArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingAllowanceChild		TAXING_ALLOWANCE_CHILD
    class TaxingAllowanceChildArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_CHILD;
        public TaxingAllowanceChildArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAllowanceChildArtSpec(this.Code.Value);
        }
    }

    class TaxingAllowanceChildArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ALLOWANCE_CHILD;
        public TaxingAllowanceChildArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingAllowanceDisab		TAXING_ALLOWANCE_DISAB
    class TaxingAllowanceDisabArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_DISAB;
        public TaxingAllowanceDisabArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAllowanceDisabArtSpec(this.Code.Value);
        }
    }

    class TaxingAllowanceDisabArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ALLOWANCE_DISAB;
        public TaxingAllowanceDisabArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingAllowanceStudy		TAXING_ALLOWANCE_STUDY
    class TaxingAllowanceStudyArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_ALLOWANCE_STUDY;
        public TaxingAllowanceStudyArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAllowanceStudyArtSpec(this.Code.Value);
        }
    }

    class TaxingAllowanceStudyArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_ALLOWANCE_STUDY;
        public TaxingAllowanceStudyArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingRebatePayer		TAXING_REBATE_PAYER
    class TaxingRebatePayerArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_REBATE_PAYER;
        public TaxingRebatePayerArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingRebatePayerArtSpec(this.Code.Value);
        }
    }

    class TaxingRebatePayerArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_REBATE_PAYER;
        public TaxingRebatePayerArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingRebateChild		TAXING_REBATE_CHILD
    class TaxingRebateChildArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_REBATE_CHILD;
        public TaxingRebateChildArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingRebateChildArtSpec(this.Code.Value);
        }
    }

    class TaxingRebateChildArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_REBATE_CHILD;
        public TaxingRebateChildArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingBonusChild		TAXING_BONUS_CHILD
    class TaxingBonusChildArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_BONUS_CHILD;
        public TaxingBonusChildArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingBonusChildArtSpec(this.Code.Value);
        }
    }

    class TaxingBonusChildArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_BONUS_CHILD;
        public TaxingBonusChildArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }
    // TaxingPaymAdvances		TAXING_PAYM_ADVANCES
    class TaxingPaymAdvancesArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_PAYM_ADVANCES;
        public TaxingPaymAdvancesArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingPaymAdvancesArtSpec(this.Code.Value);
        }
    }

    class TaxingPaymAdvancesArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_PAYM_ADVANCES;
        public TaxingPaymAdvancesArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingPaymWithhold		TAXING_PAYM_WITHHOLD
    class TaxingPaymWithholdArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_TAXING_PAYM_WITHHOLD;
        public TaxingPaymWithholdArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingPaymWithholdArtSpec(this.Code.Value);
        }
    }

    class TaxingPaymWithholdArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_TAXING_PAYM_WITHHOLD;
        public TaxingPaymWithholdArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }
}
