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
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_PLAN, (Int32)OptimulaConceptConst.CONCEPT_TIMESHEETS_PLAN,
            Array.Empty<Int32>()),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_WORK, (Int32)OptimulaConceptConst.CONCEPT_TIMESHEETS_WORK,
            new Int32[] {
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK, (Int32)OptimulaConceptConst.CONCEPT_TIMEACTUAL_WORK,
            new Int32[] {
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_MSALARY_BASICAL, (Int32)OptimulaConceptConst.CONCEPT_PAYMENT_BASIS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_MSALARY_BONUSED, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_BASIS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMIUM_BONUSED, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMIUM_BOSSING, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMIUM_PERSONA, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_AGRWORK, (Int32)OptimulaConceptConst.CONCEPT_AGRWORK_HOURS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXBASE,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_HOFFICE, (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HFULL,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTHES, (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE, (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXFREE,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXBASE, (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXBASE,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS, (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXWINS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY, (Int32)OptimulaConceptConst.CONCEPT_INCOMES_SUMMARY,
            Array.Empty<Int32>()),
        };
        public ServiceArticleFactory()
        {
            this.Providers = BuildProvidersFromRecords(ArticleConfig);
        }
    }
}
