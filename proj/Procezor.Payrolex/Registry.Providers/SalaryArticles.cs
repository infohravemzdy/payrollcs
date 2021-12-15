using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Procezor.Payrolex.Registry.Constants;

namespace HraveMzdy.Procezor.Payrolex.Registry.Providers
{
    // PaymentSalary		PAYMENT_SALARY
    class PaymentSalaryArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_PAYMENT_SALARY;
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
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_BASIS;
        public PaymentSalaryArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                    (Int32)PayrolexArticleConst.ARTICLE_INCOME_GROSS,
                });
        }
    }

    // PaymentBonus		PAYMENT_BONUS
    class PaymentBonusArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_PAYMENT_BONUS;
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
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_FIXED;
        public PaymentBonusArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                    (Int32)PayrolexArticleConst.ARTICLE_INCOME_GROSS,
                });
        }
    }

    // PaymentWorked		PAYMENT_WORKED
    class PaymentWorkedArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_PAYMENT_WORKED;
        public PaymentWorkedArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentWorkedArtSpec(this.Code.Value);
        }
    }

    class PaymentWorkedArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_FIXED;
        public PaymentWorkedArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                    (Int32)PayrolexArticleConst.ARTICLE_INCOME_GROSS,
                });
        }
    }

    // PaymentBarter		PAYMENT_BARTER
    class PaymentBarterArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_PAYMENT_BARTER;
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
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_FIXED;
        public PaymentBarterArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // AllowceHoffice		ALLOWCE_HOFFICE
    class AllowceHofficeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_ALLOWCE_HOFFICE;
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
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_FIXED;
        public AllowceHofficeArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                    (Int32)PayrolexArticleConst.ARTICLE_INCOME_NETTO,
                });
        }
    }
}

