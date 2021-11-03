using System;
using HraveMzdy.Procezor.Service;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;
using ProcezorTests.Registry.Factories;

namespace ProcezorTests.Service
{
    public class TestService : ServiceProcezor
    {
        public const Int32 TEST_VERSION = 100;

        public const Int32 TEST_FINAL_ARTICLE = (Int32)TestArticleConst.ARTICLE_INCOME_NETTO;

        public const Int32 TEST_FINAL_CONCEPT = (Int32)TestConceptConst.CONCEPT_INCOME_NETTO;

        private static readonly IArticleDefine TEST_FINAL_DEFS = new ArticleDefine(TEST_FINAL_ARTICLE, TEST_FINAL_CONCEPT);

        public TestService() : base(TEST_VERSION, TEST_FINAL_DEFS)
        {
        }

        protected override bool BuildArticleFactory()
        {
            ArticleFactory = new TestArticleFactory();

            return true;
        }

        protected override bool BuildConceptFactory()
        {
            ConceptFactory = new TestConceptFactory();

            return true;
        }
    }
}

