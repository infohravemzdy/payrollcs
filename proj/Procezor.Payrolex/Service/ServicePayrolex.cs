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

        private static readonly IList<ArticleCode> TEST_FINAL_DEFS = new List<ArticleCode>() {
            ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_EMPLOYER_COSTS),
            ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_CONTRACT_TIME_WORK),
            ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_CONTRACT_TIME_ABSC),
            ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_INCOME_NETTO),
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
