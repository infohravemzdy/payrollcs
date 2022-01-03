using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Registry.Constants;
using HraveMzdy.Procezor.Registry.Factories;
using HraveMzdy.Procezor.Optimula.Registry.Constants;

namespace HraveMzdy.Procezor.Optimula.Registry.Factories
{
    class ServiceArticleFactory : ArticleSpecFactory
    {
        private readonly IEnumerable<ProviderRecord> ArticleConfig = new ProviderRecord[] {
            new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_CONTRACT_TIME_PLAN, (Int32)OptimulaConceptConst.CONCEPT_CONTRACT_TIME_PLAN,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_CONTRACT_TIME_WORK, (Int32)OptimulaConceptConst.CONCEPT_CONTRACT_TIME_WORK,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PAYMENT_MSALARY, (Int32)OptimulaConceptConst.CONCEPT_PAYMENT_BASIS,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PAYMENT_MPERSON, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_BASIS,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PAYMENT_PREMIUM, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PAYMENT_AGRWORK, (Int32)OptimulaConceptConst.CONCEPT_AGRWORK_HOURS,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_HOFFICE, (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS,
                Array.Empty<Int32>()),
            new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTHES, (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS,
                Array.Empty<Int32>()),
       };
        public ServiceArticleFactory()
        {
            this.Providers = BuildProvidersFromRecords(ArticleConfig);
        }
    }
}
