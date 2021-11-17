using System;
using System.Collections.Generic;
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

        public const Int32 TEST_FINAL_ARTICLE = (Int32)PayrolexArticleConst.ARTICLE_INCOME_NETTO;

        private static readonly IList<ArticleCode> TEST_FINAL_DEFS = new List<ArticleCode>() {
            ArticleCode.Get(TEST_FINAL_ARTICLE),
        };

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
