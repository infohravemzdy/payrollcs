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
    // SocialDeclare		SOCIAL_DECLARE
    class SocialDeclareArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_DECLARE;
        public SocialDeclareArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialDeclareArtSpec(this.Code.Value);
        }
    }

    class SocialDeclareArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_DECLARE;
        public SocialDeclareArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SocialIncome		SOCIAL_INCOME
    class SocialIncomeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_INCOME;
        public SocialIncomeArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialIncomeArtSpec(this.Code.Value);
        }
    }

    class SocialIncomeArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_INCOME;
        public SocialIncomeArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SocialBase		SOCIAL_BASE
    class SocialBaseArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE;
        public SocialBaseArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialBaseArtSpec(this.Code.Value);
        }
    }

    class SocialBaseArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_BASE;
        public SocialBaseArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SocialBaseEmployee		SOCIAL_BASE_EMPLOYEE
    class SocialBaseEmployeeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_EMPLOYEE;
        public SocialBaseEmployeeArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialBaseEmployeeArtSpec(this.Code.Value);
        }
    }

    class SocialBaseEmployeeArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_BASE_EMPLOYEE;
        public SocialBaseEmployeeArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SocialBaseEmployer		SOCIAL_BASE_EMPLOYER
    class SocialBaseEmployerArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_EMPLOYER;
        public SocialBaseEmployerArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialBaseEmployerArtSpec(this.Code.Value);
        }
    }

    class SocialBaseEmployerArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_BASE_EMPLOYER;
        public SocialBaseEmployerArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SocialBaseOvercap		SOCIAL_BASE_OVERCAP
    class SocialBaseOvercapArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_OVERCAP;
        public SocialBaseOvercapArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialBaseOvercapArtSpec(this.Code.Value);
        }
    }

    class SocialBaseOvercapArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_BASE_OVERCAP;
        public SocialBaseOvercapArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SocialPaymEmployee		SOCIAL_PAYM_EMPLOYEE
    class SocialPaymEmployeeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_PAYM_EMPLOYEE;
        public SocialPaymEmployeeArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialPaymEmployeeArtSpec(this.Code.Value);
        }
    }

    class SocialPaymEmployeeArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_PAYM_EMPLOYEE;
        public SocialPaymEmployeeArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SocialPaymEmployer		SOCIAL_PAYM_EMPLOYER
    class SocialPaymEmployerArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_SOCIAL_PAYM_EMPLOYER;
        public SocialPaymEmployerArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialPaymEmployerArtSpec(this.Code.Value);
        }
    }

    class SocialPaymEmployerArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_PAYM_EMPLOYER;
        public SocialPaymEmployerArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }
}
