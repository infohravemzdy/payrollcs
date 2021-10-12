using System;
using System.Collections.Generic;
using HraveMzdy.Procezor.Registry.Factories;
using ProcezorTests.Registry.Constants;

namespace ProcezorTests.Registry.Factories
{
    class TestArticleFactory : ArticleSpecFactory
    {
        private readonly IEnumerable<ProviderRecord> ArticleConfig = new ProviderRecord[] {
             new ProviderRecord((Int32)TestArticleConst.ARTICLE_TIMESHT_WORKING, (Int32)TestConceptConst.CONCEPT_TIMESHT_WORKING,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)TestArticleConst.ARTICLE_PAYMENT_SALARY, (Int32)TestConceptConst.CONCEPT_AMOUNT_BASIS,
                new Int32[] {
                    (Int32)TestArticleConst.ARTICLE_INCOME_GROSS,
                    (Int32)TestArticleConst.ARTICLE_HEALTH_INSBASE,
                    (Int32)TestArticleConst.ARTICLE_SOCIAL_INSBASE,
                    (Int32)TestArticleConst.ARTICLE_TAXING_ADVBASE,
                }),

             new ProviderRecord((Int32)TestArticleConst.ARTICLE_PAYMENT_BONUS, (Int32)TestConceptConst.CONCEPT_AMOUNT_FIXED,
                new Int32[] {
                    (Int32)TestArticleConst.ARTICLE_INCOME_GROSS,
                    (Int32)TestArticleConst.ARTICLE_HEALTH_INSBASE,
                    (Int32)TestArticleConst.ARTICLE_SOCIAL_INSBASE,
                    (Int32)TestArticleConst.ARTICLE_TAXING_ADVBASE,
                }),

             new ProviderRecord((Int32)TestArticleConst.ARTICLE_PAYMENT_BARTER, (Int32)TestConceptConst.CONCEPT_AMOUNT_FIXED,
                new Int32[] {
                    (Int32)TestArticleConst.ARTICLE_HEALTH_INSBASE,
                    (Int32)TestArticleConst.ARTICLE_SOCIAL_INSBASE,
                    (Int32)TestArticleConst.ARTICLE_TAXING_ADVBASE,
                }),

             new ProviderRecord((Int32)TestArticleConst.ARTICLE_ALLOWCE_HOFFICE, (Int32)TestConceptConst.CONCEPT_AMOUNT_FIXED,
                new Int32[] {
                    (Int32)TestArticleConst.ARTICLE_INCOME_NETTO,
                }),

             new ProviderRecord((Int32)TestArticleConst.ARTICLE_HEALTH_INSBASE, (Int32)TestConceptConst.CONCEPT_HEALTH_INSBASE,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)TestArticleConst.ARTICLE_SOCIAL_INSBASE, (Int32)TestConceptConst.CONCEPT_SOCIAL_INSBASE,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)TestArticleConst.ARTICLE_HEALTH_INSPAYM, (Int32)TestConceptConst.CONCEPT_HEALTH_INSPAYM,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)TestArticleConst.ARTICLE_SOCIAL_INSPAYM, (Int32)TestConceptConst.CONCEPT_SOCIAL_INSPAYM,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)TestArticleConst.ARTICLE_TAXING_ADVBASE, (Int32)TestConceptConst.CONCEPT_TAXING_ADVBASE,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)TestArticleConst.ARTICLE_TAXING_ADVPAYM, (Int32)TestConceptConst.CONCEPT_TAXING_ADVPAYM,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)TestArticleConst.ARTICLE_INCOME_GROSS, (Int32)TestConceptConst.CONCEPT_INCOME_GROSS,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)TestArticleConst.ARTICLE_INCOME_NETTO, (Int32)TestConceptConst.CONCEPT_INCOME_NETTO,
                Array.Empty<Int32>()),
        };
        public TestArticleFactory()
        {
            this.Providers = BuildProvidersFromRecords(ArticleConfig);
        }
    }
}