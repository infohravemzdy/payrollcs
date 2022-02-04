using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;

namespace ProcezorTests.Registry.Providers
{
    // TimeshtWorking		TIMESHT_WORKING
    class TimeshtWorkingArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_TIMESHT_WORKING;
        public TimeshtWorkingArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TimeshtWorkingArtSpec(this.Code.Value);
        }
    }

    class TimeshtWorkingArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_TIMESHT_WORKING;
        public TimeshtWorkingArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PaymentSalary		PAYMENT_SALARY
    class PaymentSalaryArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_PAYMENT_SALARY;
        public PaymentSalaryArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentSalaryArtSpec(this.Code.Value);
        }
    }

    class PaymentSalaryArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_AMOUNT_BASIS;
        public PaymentSalaryArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)ExampleArticleConst.ARTICLE_INCOME_GROSS,
                (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE,
                (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE,
                (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE,
            });
        }
    }

    // PaymentBonus		PAYMENT_BONUS
    class PaymentBonusArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_PAYMENT_BONUS;
        public PaymentBonusArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentBonusArtSpec(this.Code.Value);
        }
    }

    class PaymentBonusArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED;
        public PaymentBonusArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)ExampleArticleConst.ARTICLE_INCOME_GROSS,
                (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE,
                (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE,
                (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE,
            });
        }
    }

    // PaymentBarter		PAYMENT_BARTER
    class PaymentBarterArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_PAYMENT_BARTER;
        public PaymentBarterArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentBarterArtSpec(this.Code.Value);
        }
    }

    class PaymentBarterArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED;
        public PaymentBarterArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE,
                (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE,
                (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE,
            });
        }
    }

    // AllowceHoffice		ALLOWCE_HOFFICE
    class AllowceHofficeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_ALLOWCE_HOFFICE;
        public AllowceHofficeArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AllowceHofficeArtSpec(this.Code.Value);
        }
    }

    class AllowceHofficeArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED;
        public AllowceHofficeArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)ExampleArticleConst.ARTICLE_INCOME_NETTO,
            });
        }
    }

    // HealthInsbase		HEALTH_INSBASE
    class HealthInsbaseArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE;
        public HealthInsbaseArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthInsbaseArtSpec(this.Code.Value);
        }
    }

    class HealthInsbaseArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_HEALTH_INSBASE;
        public HealthInsbaseArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SocialInsbase		SOCIAL_INSBASE
    class SocialInsbaseArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE;
        public SocialInsbaseArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialInsbaseArtSpec(this.Code.Value);
        }
    }

    class SocialInsbaseArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_SOCIAL_INSBASE;
        public SocialInsbaseArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // HealthInspaym		HEALTH_INSPAYM
    class HealthInspaymArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSPAYM;
        public HealthInspaymArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthInspaymArtSpec(this.Code.Value);
        }
    }

    class HealthInspaymArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_HEALTH_INSPAYM;
        public HealthInspaymArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SocialInspaym		SOCIAL_INSPAYM
    class SocialInspaymArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSPAYM;
        public SocialInspaymArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialInspaymArtSpec(this.Code.Value);
        }
    }

    class SocialInspaymArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_SOCIAL_INSPAYM;
        public SocialInspaymArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingAdvbase		TAXING_ADVBASE
    class TaxingAdvbaseArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE;
        public TaxingAdvbaseArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvbaseArtSpec(this.Code.Value);
        }
    }

    class TaxingAdvbaseArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_TAXING_ADVBASE;
        public TaxingAdvbaseArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TaxingAdvpaym		TAXING_ADVPAYM
    class TaxingAdvpaymArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVPAYM;
        public TaxingAdvpaymArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvpaymArtSpec(this.Code.Value);
        }
    }

    class TaxingAdvpaymArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_TAXING_ADVPAYM;
        public TaxingAdvpaymArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // IncomeGross		INCOME_GROSS
    class IncomeGrossArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_INCOME_GROSS;
        public IncomeGrossArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomeGrossArtSpec(this.Code.Value);
        }
    }

    class IncomeGrossArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_INCOME_GROSS;
        public IncomeGrossArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // IncomeNetto		INCOME_NETTO
    class IncomeNettoArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_INCOME_NETTO;
        public IncomeNettoArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomeNettoArtSpec(this.Code.Value);
        }
    }

    class IncomeNettoArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_INCOME_NETTO;
        public IncomeNettoArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

}
