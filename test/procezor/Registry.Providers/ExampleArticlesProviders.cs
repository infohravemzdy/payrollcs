using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;

namespace ProcezorTests.Registry.Providers
{
    // TimeshtWorking           TIMESHT_WORKING
    class TimeshtWorkingArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_TIMESHT_WORKING;
        class TimeshtWorkingArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_TIMESHT_WORKING;

            public TimeshtWorkingArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>();
            }
        }

        public TimeshtWorkingArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TimeshtWorkingArtSpec(this.Code.Value);
        }
    }
    // PaymentSalary            PAYMENT_SALARY
    class PaymentSalaryArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_PAYMENT_SALARY;
        class PaymentSalaryArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_AMOUNT_BASIS;

            public PaymentSalaryArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                    (Int32)ExampleArticleConst.ARTICLE_INCOME_GROSS,
                    (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE,
               });
            }
        }
        public PaymentSalaryArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentSalaryArtSpec(this.Code.Value);
        }
    }
    // PaymentBonus             PAYMENT_BONUS
    class PaymentBonusArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_PAYMENT_BONUS;
        class PaymentBonusArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED;

            public PaymentBonusArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                    (Int32)ExampleArticleConst.ARTICLE_INCOME_GROSS,
                    (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE,
                });
            }
        }
        public PaymentBonusArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentBonusArtSpec(this.Code.Value);
        }
    }
    // PaymentBarter            PAYMENT_BARTER
    class PaymentBarterArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_PAYMENT_BARTER;
        class PaymentBarterArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED;

            public PaymentBarterArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                    (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE,
                });
            }
        }
        public PaymentBarterArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentBarterArtSpec(this.Code.Value);
        }
    }
    // AllowceHoffice           ALLOWCE_HOFFICE
    class AllowceHofficeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_ALLOWCE_HOFFICE;
        class AllowceHofficeArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED;

            public AllowceHofficeArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                    (Int32)ExampleArticleConst.ARTICLE_INCOME_NETTO,
                });
            }
        }
        public AllowceHofficeArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AllowceHofficeArtSpec(this.Code.Value);
        }
    }
    // HealthInsBase            HEALTH_INSBASE
    class HealthInsBaseArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE;
        class HealthInsBaseArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_HEALTH_INSBASE;

            public HealthInsBaseArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>();
            }
        }
        public HealthInsBaseArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthInsBaseArtSpec(this.Code.Value);
        }
    }
    // SocialInsBase            SOCIAL_INSBASE
    class SocialInsBaseArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE;
        class SocialInsBaseArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_SOCIAL_INSBASE;

            public SocialInsBaseArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>();
            }
        }
        public SocialInsBaseArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialInsBaseArtSpec(this.Code.Value);
        }
    }
    // TaxingAdvBase            TAXING_ADVBASE
    class TaxingAdvBaseArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE;
        class TaxingAdvBaseArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_TAXING_ADVBASE;

            public TaxingAdvBaseArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>();
            }
        }
        public TaxingAdvBaseArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvBaseArtSpec(this.Code.Value);
        }
    }
    // HealthInsPaym            HEALTH_INSPAYM
    class HealthInsPaymArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSPAYM;
        class HealthInsPaymArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_HEALTH_INSPAYM;

            public HealthInsPaymArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>();
            }
        }
        public HealthInsPaymArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthInsPaymArtSpec(this.Code.Value);
        }
    }
    // SocialInsPaym            SOCIAL_INSPAYM
    class SocialInsPaymArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSPAYM;
        class SocialInsPaymArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_SOCIAL_INSPAYM;

            public SocialInsPaymArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>();
            }
        }
        public SocialInsPaymArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SocialInsPaymArtSpec(this.Code.Value);
        }
    }
    // TaxingAdvPaym            TAXING_ADVPAYM
    class TaxingAdvPaymArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVPAYM;
        class TaxingAdvPaymArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_TAXING_ADVPAYM;

            public TaxingAdvPaymArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>();
            }
        }
        public TaxingAdvPaymArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvPaymArtSpec(this.Code.Value);
        }
    }
    // IncomeGross              INCOME_GROSS
    class IncomeGrossArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_INCOME_GROSS;
        class IncomeGrossArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_INCOME_GROSS;

            public IncomeGrossArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>();
            }
        }
        public IncomeGrossArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomeGrossArtSpec(this.Code.Value);
        }
    }
    // IncomeNetto              INCOME_NETTO
    class IncomeNettoArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)ExampleArticleConst.ARTICLE_INCOME_NETTO;
        class IncomeNettoArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)ExampleConceptConst.CONCEPT_INCOME_NETTO;

            public IncomeNettoArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>();
            }
        }
        public IncomeNettoArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomeNettoArtSpec(this.Code.Value);
        }
    }
}
