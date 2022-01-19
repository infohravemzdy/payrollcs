using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Registry.Constants;
using HraveMzdy.Procezor.Registry.Factories;
using HraveMzdy.Procezor.Optimula.Registry.Constants;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Optimula.Registry.Factories
{
    class ServiceScmArticleFactory : ArticleSpecFactory
    {
        const Int16 ARTICLE_DEFAULT_SEQUENS = 0;

        private readonly IEnumerable<ProviderRecord> ArticleConfig = new ProviderRecord[] {
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_PLAN, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_TIMESHEETS_PLAN,
            Array.Empty<Int32>()),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_WORK, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_TIMESHEETS_WORK,
            new Int32[] {
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_TIMEACTUAL_WORK,
            new Int32[] {
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_MSALARY_TARGETS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_PAYMENT_BASIS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_HSALARY_TARGETS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_PAYMENT_HOURS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_MAWARDS_TARGETS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_BASIS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_HAWARDS_TARGETS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_HOURS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMIUM_TARGETS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMADV_TARGETS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMEXT_TARGETS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_MAWARDS_RESULTS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_REDUCED_BASIS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_HAWARDS_RESULTS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_REDUCED_HOURS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMIUM_RESULTS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_REDUCED_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMADV_RESULTS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_REDUCED_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMEXT_RESULTS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_REDUCED_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_AGRWORK_TARGETS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_AGRWORK_HOURS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_AGRWORK,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXBASE,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_HOFFICE, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HFULL,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTDAY, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_DAILY,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTHRS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_TARGETS,
            Array.Empty<Int32>()),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_ALLOWCE,
            Array.Empty<Int32>()),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_AGRWORK, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_AGRWORK,
            Array.Empty<Int32>()),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_RESULTS,
            Array.Empty<Int32>()),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXFREE,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXBASE, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXBASE,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXWINS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_INCOMES_SUMMARY,
            Array.Empty<Int32>()),
        };
        public ServiceScmArticleFactory()
        {
            this.Providers = BuildProvidersFromRecords(ArticleConfig);
        }
    }
    class ServiceEpsArticleFactory : ArticleSpecFactory
    {
        const Int16 ARTICLE_DEFAULT_SEQUENS = 0;
        const Int16 ARTICLE_MAWARDS_SEQUENS = 1;
        const Int16 ARTICLE_HAWARDS_SEQUENS = 2;
        const Int16 ARTICLE_PREMIUM_SEQUENS = 3;
        const Int16 ARTICLE_PREMADV_SEQUENS = 4;
        const Int16 ARTICLE_PREMEXT_SEQUENS = 5;

        private readonly IEnumerable<ProviderRecord> ArticleConfig = new ProviderRecord[] {
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_PLAN, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_TIMESHEETS_PLAN,
            Array.Empty<Int32>()),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_WORK, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_TIMESHEETS_WORK,
            new Int32[] {
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_TIMEACTUAL_WORK,
            new Int32[] {
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_MSALARY_TARGETS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_PAYMENT_BASIS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_HSALARY_TARGETS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_PAYMENT_HOURS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_MAWARDS_TARGETS, ARTICLE_MAWARDS_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_BASIS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_HAWARDS_TARGETS, ARTICLE_HAWARDS_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_HOURS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMIUM_TARGETS, ARTICLE_PREMIUM_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMADV_TARGETS, ARTICLE_PREMADV_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMEXT_TARGETS, ARTICLE_PREMEXT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_MAWARDS_RESULTS, ARTICLE_MAWARDS_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_REDUCED_BASIS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_HAWARDS_RESULTS, ARTICLE_HAWARDS_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_REDUCED_HOURS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMIUM_RESULTS, ARTICLE_PREMIUM_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_REDUCED_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMADV_RESULTS, ARTICLE_PREMADV_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_REDUCED_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_PREMEXT_RESULTS, ARTICLE_PREMEXT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_REDUCED_FIXED,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_AGRWORK_TARGETS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_AGRWORK_HOURS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_AGRWORK,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXBASE,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_HOFFICE, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HFULL,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTDAY, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_DAILY,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTHRS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_TARGETS,
            Array.Empty<Int32>()),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_ALLOWCE,
            Array.Empty<Int32>()),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_AGRWORK, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_AGRWORK,
            Array.Empty<Int32>()),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_RESULTS,
            Array.Empty<Int32>()),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXFREE,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXBASE, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXBASE,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXWINS,
            new Int32[] {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY,
            }),
        new ProviderRecord((Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY, ARTICLE_DEFAULT_SEQUENS, (Int32)OptimulaConceptConst.CONCEPT_INCOMES_SUMMARY,
            Array.Empty<Int32>()),
        };
        public ServiceEpsArticleFactory()
        {
            this.Providers = BuildProvidersFromRecords(ArticleConfig);
        }
    }
}
