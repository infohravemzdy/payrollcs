using System;
using HraveMzdy.Procezor.Service;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using Procezor.Payrolex.Registry.Constants;
using Procezor.Payrolex.Registry.Factories;

namespace Procezor.Payrolex.Service
{
    public class ServicePayrolex : ServiceProcezor
    {
        public const Int32 TEST_VERSION = 100;

        public const Int32 TEST_FINAL_ARTICLE = (Int32)ServiceArticleConst.ARTICLE_INCOME_NETTO;

        public const Int32 TEST_FINAL_CONCEPT = (Int32)ServiceConceptConst.CONCEPT_INCOME_NETTO;

        private static readonly IArticleDefine TEST_FINAL_DEFS = new ArticleDefine(TEST_FINAL_ARTICLE, TEST_FINAL_CONCEPT);

        public ServicePayrolex() : base(TEST_VERSION, TEST_FINAL_DEFS)
        {
        }

        protected override bool BuildArticleFactory()
        {
            ArticleFactory = new ServiceArticleFactory();

            return true;
        }

        protected override bool BuildConceptFactory()
        {
            ConceptFactory = new ServiceConceptFactory();

            return true;
        }
    }

}
