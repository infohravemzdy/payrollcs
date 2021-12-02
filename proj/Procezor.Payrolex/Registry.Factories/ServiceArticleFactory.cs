using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Registry.Constants;
using HraveMzdy.Procezor.Registry.Factories;
using HraveMzdy.Procezor.Payrolex.Registry.Constants;

namespace HraveMzdy.Procezor.Payrolex.Registry.Factories
{
    class ServiceArticleFactory : ArticleSpecFactory
    {
        private readonly IEnumerable<ProviderRecord> ArticleConfig = new ProviderRecord[] {
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_CONTRACT_WORK_TERM, (Int32)PayrolexConceptConst.CONCEPT_CONTRACT_WORK_TERM,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_POSITION_WORK_TERM, (Int32)PayrolexConceptConst.CONCEPT_POSITION_WORK_TERM,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_POSITION_WORK_PLAN, (Int32)PayrolexConceptConst.CONCEPT_POSITION_WORK_PLAN,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_PLAN, (Int32)PayrolexConceptConst.CONCEPT_POSITION_TIME_PLAN,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_WORK, (Int32)PayrolexConceptConst.CONCEPT_POSITION_TIME_WORK,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_ABSC, (Int32)PayrolexConceptConst.CONCEPT_POSITION_TIME_ABSC,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_CONTRACT_TIME_PLAN, (Int32)PayrolexConceptConst.CONCEPT_CONTRACT_TIME_PLAN,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_CONTRACT_TIME_WORK, (Int32)PayrolexConceptConst.CONCEPT_CONTRACT_TIME_WORK,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_CONTRACT_TIME_ABSC, (Int32)PayrolexConceptConst.CONCEPT_CONTRACT_TIME_ABSC,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_PAYMENT_SALARY, (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_BASIS,
                new Int32[] {
                    (Int32)PayrolexArticleConst.ARTICLE_INCOME_GROSS,
                    (Int32)PayrolexArticleConst.ARTICLE_EMPLOYER_COSTS,
                    (Int32)PayrolexArticleConst.ARTICLE_HEALTH_INCOME,
                }),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_PAYMENT_BONUS, (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_FIXED,
                new Int32[] {
                    (Int32)PayrolexArticleConst.ARTICLE_INCOME_GROSS,
                    (Int32)PayrolexArticleConst.ARTICLE_EMPLOYER_COSTS,
                    (Int32)PayrolexArticleConst.ARTICLE_HEALTH_INCOME,
                }),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_PAYMENT_BARTER, (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_FIXED,
                new Int32[] {
                    (Int32)PayrolexArticleConst.ARTICLE_HEALTH_INCOME,
                }),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_ALLOWCE_HOFFICE, (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_FIXED,
                new Int32[] {
                    (Int32)PayrolexArticleConst.ARTICLE_INCOME_NETTO,
                }),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_INCOME_GROSS, (Int32)PayrolexConceptConst.CONCEPT_INCOME_GROSS,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_INCOME_NETTO, (Int32)PayrolexConceptConst.CONCEPT_INCOME_NETTO,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_EMPLOYER_COSTS, (Int32)PayrolexConceptConst.CONCEPT_EMPLOYER_COSTS,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE, (Int32)PayrolexConceptConst.CONCEPT_HEALTH_DECLARE,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_HEALTH_INCOME, (Int32)PayrolexConceptConst.CONCEPT_HEALTH_INCOME,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE, (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYEE, (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_EMPLOYEE,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYER, (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_EMPLOYER,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_MANDATE, (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_MANDATE,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_OVERCAP, (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_OVERCAP,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_HEALTH_PAYM_EMPLOYEE, (Int32)PayrolexConceptConst.CONCEPT_HEALTH_PAYM_EMPLOYEE,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_HEALTH_PAYM_EMPLOYER, (Int32)PayrolexConceptConst.CONCEPT_HEALTH_PAYM_EMPLOYER,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_DECLARE, (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_DECLARE,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_INCOME, (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_INCOME,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE, (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_BASE,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_EMPLOYEE, (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_BASE_EMPLOYEE,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_EMPLOYER, (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_BASE_EMPLOYER,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_BASE_OVERCAP, (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_BASE_OVERCAP,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_PAYM_EMPLOYEE, (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_PAYM_EMPLOYEE,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)PayrolexArticleConst.ARTICLE_SOCIAL_PAYM_EMPLOYER, (Int32)PayrolexConceptConst.CONCEPT_SOCIAL_PAYM_EMPLOYER,
                Array.Empty<Int32>()),
       };
        public ServiceArticleFactory()
        {
            this.Providers = BuildProvidersFromRecords(ArticleConfig);
        }
    }
}
