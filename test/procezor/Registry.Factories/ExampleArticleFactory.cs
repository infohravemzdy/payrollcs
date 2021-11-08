using System;
using System.Collections.Generic;
using HraveMzdy.Procezor.Registry.Factories;
using ProcezorTests.Registry.Constants;

namespace ProcezorTests.Registry.Factories
{
    class ExampleArticleFactory : ArticleSpecFactory
    {
        private readonly IEnumerable<ProviderRecord> ArticleConfig = new ProviderRecord[] {
             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_TIMESHT_WORKING, (Int32)ExampleConceptConst.CONCEPT_TIMESHT_WORKING,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_PAYMENT_SALARY, (Int32)ExampleConceptConst.CONCEPT_AMOUNT_BASIS,
                new Int32[] {
                    (Int32)ExampleArticleConst.ARTICLE_INCOME_GROSS,
                    (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE,
                }),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_PAYMENT_BONUS, (Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED,
                new Int32[] {
                    (Int32)ExampleArticleConst.ARTICLE_INCOME_GROSS,
                    (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE,
                }),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_PAYMENT_BARTER, (Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED,
                new Int32[] {
                    (Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE,
                    (Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE,
                }),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_ALLOWCE_HOFFICE, (Int32)ExampleConceptConst.CONCEPT_AMOUNT_FIXED,
                new Int32[] {
                    (Int32)ExampleArticleConst.ARTICLE_INCOME_NETTO,
                }),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_HEALTH_INSBASE, (Int32)ExampleConceptConst.CONCEPT_HEALTH_INSBASE,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSBASE, (Int32)ExampleConceptConst.CONCEPT_SOCIAL_INSBASE,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_HEALTH_INSPAYM, (Int32)ExampleConceptConst.CONCEPT_HEALTH_INSPAYM,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_SOCIAL_INSPAYM, (Int32)ExampleConceptConst.CONCEPT_SOCIAL_INSPAYM,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_TAXING_ADVBASE, (Int32)ExampleConceptConst.CONCEPT_TAXING_ADVBASE,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_TAXING_ADVPAYM, (Int32)ExampleConceptConst.CONCEPT_TAXING_ADVPAYM,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_INCOME_GROSS, (Int32)ExampleConceptConst.CONCEPT_INCOME_GROSS,
                Array.Empty<Int32>()),

             new ProviderRecord((Int32)ExampleArticleConst.ARTICLE_INCOME_NETTO, (Int32)ExampleConceptConst.CONCEPT_INCOME_NETTO,
                Array.Empty<Int32>()),
        };
        public ExampleArticleFactory()
        {
            this.Providers = BuildProvidersFromRecords(ArticleConfig);
        }
    }
}