using System;
using System.Collections.Generic;
using HraveMzdy.Procezor.Service;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;
using ProcezorTests.Registry.Factories;

namespace ProcezorTests.Service
{
    public class ExampleService : ServiceProcezor
    {
        public const Int32 TEST_VERSION = 100;

        public const Int32 TEST_FINAL_ARTICLE = (Int32)ExampleArticleConst.ARTICLE_INCOME_NETTO;

        public const Int32 TEST_FINAL_CONCEPT = (Int32)ExampleConceptConst.CONCEPT_INCOME_NETTO;

        private static readonly IList<ArticleCode> TEST_FINAL_DEFS = new List<ArticleCode>() {
            ArticleCode.Get(TEST_FINAL_ARTICLE),
        };

        public ExampleService() : base(TEST_VERSION, TEST_FINAL_DEFS)
        {
        }

        protected override bool BuildArticleFactory()
        {
            ArticleFactory = new ExampleArticleFactory();

            return true;
        }

        protected override bool BuildConceptFactory()
        {
            ConceptFactory = new ExampleConceptFactory();

            return true;
        }
    }
}

