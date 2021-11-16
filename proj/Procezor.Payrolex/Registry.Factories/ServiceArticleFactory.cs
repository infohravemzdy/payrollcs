using HraveMzdy.Procezor.Registry.Constants;
using HraveMzdy.Procezor.Registry.Factories;
using Procezor.Payrolex.Registry.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procezor.Payrolex.Registry.Factories
{
    class ServiceArticleFactory : ArticleSpecFactory
    {
        private readonly IEnumerable<ProviderRecord> ArticleConfig = new ProviderRecord[] {
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_CONTRACT_TERM, (Int32)ServiceConceptConst.CONCEPT_CONTRACT_TERM,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_POSITION_TERM, (Int32)ServiceConceptConst.CONCEPT_POSITION_TERM,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_POSITION_WORK_PLAN, (Int32)ServiceConceptConst.CONCEPT_POSITION_WORK_PLAN,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_POSITION_TIME_PLAN, (Int32)ServiceConceptConst.CONCEPT_POSITION_TIME_PLAN,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_POSITION_TIME_WORK, (Int32)ServiceConceptConst.CONCEPT_POSITION_TIME_WORK,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_POSITION_TIME_ABSC, (Int32)ServiceConceptConst.CONCEPT_POSITION_TIME_ABSC,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_CONTRACT_TIME_PLAN, (Int32)ServiceConceptConst.CONCEPT_CONTRACT_TIME_PLAN,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_CONTRACT_TIME_WORK, (Int32)ServiceConceptConst.CONCEPT_CONTRACT_TIME_WORK,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_CONTRACT_TIME_ABSC, (Int32)ServiceConceptConst.CONCEPT_CONTRACT_TIME_ABSC,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_PAYMENT_SALARY, (Int32)ServiceConceptConst.CONCEPT_PAYMENT_BASIS,
                new Int32[] {
                    (Int32)ServiceArticleConst.ARTICLE_INCOME_GROSS,
                }),
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_PAYMENT_BONUS, (Int32)ServiceConceptConst.CONCEPT_PAYMENT_FIXED,
                new Int32[] {
                    (Int32)ServiceArticleConst.ARTICLE_INCOME_GROSS,
                }),
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_PAYMENT_BARTER, (Int32)ServiceConceptConst.CONCEPT_PAYMENT_FIXED,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_ALLOWCE_HOFFICE, (Int32)ServiceConceptConst.CONCEPT_PAYMENT_FIXED,
                new Int32[] {
                    (Int32)ServiceArticleConst.ARTICLE_INCOME_NETTO,
                }),
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_INCOME_GROSS, (Int32)ServiceConceptConst.CONCEPT_INCOME_GROSS,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)ServiceArticleConst.ARTICLE_INCOME_NETTO, (Int32)ServiceConceptConst.CONCEPT_INCOME_NETTO,
                Array.Empty<Int32>()),
        };
        public ServiceArticleFactory()
        {
            this.Providers = BuildProvidersFromRecords(ArticleConfig);
        }
    }
}
