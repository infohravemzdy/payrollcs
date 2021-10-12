using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;

namespace ProcezorTests.Registry.Providers.Articles
{
    // PaymentBonus             PAYMENT_BONUS
    class PaymentBonusArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)TestArticleConst.ARTICLE_PAYMENT_BONUS;
        class PaymentBonusArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)TestConceptConst.CONCEPT_AMOUNT_FIXED;

            public PaymentBonusArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>() {
                    ArticleCode.Get((Int32)TestArticleConst.ARTICLE_INCOME_GROSS),
                    ArticleCode.Get((Int32)TestArticleConst.ARTICLE_HEALTH_INSBASE),
                    ArticleCode.Get((Int32)TestArticleConst.ARTICLE_SOCIAL_INSBASE),
                    ArticleCode.Get((Int32)TestArticleConst.ARTICLE_TAXING_ADVBASE),
                };
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
}
