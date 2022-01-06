using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Procezor.Optimula.Registry.Constants;
using HraveMzdy.Procezor.Optimula.Registry.Factories;
using HraveMzdy.Procezor.Optimula.Registry.Providers;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Procezor.Optimula.Service
{
    public class ServiceOptimula : ServiceProcezor
    {
        public const Int32 TEST_VERSION = 100;

        private static readonly IList<ArticleCode> TEST_FINAL_DEFS = new List<ArticleCode>() {
            ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_AGRWORK),
            ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_HOFFICE),
            ArticleCode.Get((Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTHES),
        };

        public ServiceOptimula() : base(TEST_VERSION, TEST_FINAL_DEFS)
        {
        }

        public override IEnumerable<IContractTerm> GetContractTerms(IPeriod period, IEnumerable<ITermTarget> targets)
        {
            return new List<IContractTerm>();
        }

        public override IEnumerable<IPositionTerm> GetPositionTerms(IPeriod period, IEnumerable<IContractTerm> contracts, IEnumerable<ITermTarget> targets)
        {
            return new List<IPositionTerm>();
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
