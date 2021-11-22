using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using Procezor.Payrolex.Registry.Constants;

namespace Procezor.Payrolex.Registry.Providers
{
    // HealthDeclare		HEALTH_DECLARE
    class HealthDeclareArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE;
        public HealthDeclareArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthDeclareArtSpec(this.Code.Value);
        }
    }

    class HealthDeclareArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_DECLARE;
        public HealthDeclareArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // HealthIncome		HEALTH_INCOME
    class HealthIncomeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_HEALTH_INCOME;
        public HealthIncomeArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthIncomeArtSpec(this.Code.Value);
        }
    }

    class HealthIncomeArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_INCOME;
        public HealthIncomeArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // HealthBase		HEALTH_BASE
    class HealthBaseArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE;
        public HealthBaseArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthBaseArtSpec(this.Code.Value);
        }
    }

    class HealthBaseArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE;
        public HealthBaseArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // HealthBaseEmployee		HEALTH_BASE_EMPLOYEE
    class HealthBaseEmployeeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYEE;
        public HealthBaseEmployeeArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthBaseEmployeeArtSpec(this.Code.Value);
        }
    }

    class HealthBaseEmployeeArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_EMPLOYEE;
        public HealthBaseEmployeeArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // HealthBaseEmployer		HEALTH_BASE_EMPLOYER
    class HealthBaseEmployerArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYER;
        public HealthBaseEmployerArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthBaseEmployerArtSpec(this.Code.Value);
        }
    }

    class HealthBaseEmployerArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_EMPLOYER;
        public HealthBaseEmployerArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // HealthBaseMandate		HEALTH_BASE_MANDATE
    class HealthBaseMandateArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_MANDATE;
        public HealthBaseMandateArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthBaseMandateArtSpec(this.Code.Value);
        }
    }

    class HealthBaseMandateArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_MANDATE;
        public HealthBaseMandateArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // HealthPaymEmployee		HEALTH_PAYM_EMPLOYEE
    class HealthPaymEmployeeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_HEALTH_PAYM_EMPLOYEE;
        public HealthPaymEmployeeArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthPaymEmployeeArtSpec(this.Code.Value);
        }
    }

    class HealthPaymEmployeeArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_PAYM_EMPLOYEE;
        public HealthPaymEmployeeArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // HealthPaymEmployer		HEALTH_PAYM_EMPLOYER
    class HealthPaymEmployerArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_HEALTH_PAYM_EMPLOYER;
        public HealthPaymEmployerArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthPaymEmployerArtSpec(this.Code.Value);
        }
    }

    class HealthPaymEmployerArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_PAYM_EMPLOYER;
        public HealthPaymEmployerArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }
}
