using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;

namespace ProcezorTests.Registry.Providers.Articles
{
    // TaxingAdvBase            TAXING_ADVBASE
    class TaxingAdvBaseArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)TestArticleConst.ARTICLE_TAXING_ADVBASE;
        class TaxingAdvBaseArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)TestConceptConst.CONCEPT_TAXING_ADVBASE;

            public TaxingAdvBaseArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>();
            }
        }
        public TaxingAdvBaseArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvBaseArtSpec(this.Code.Value);
        }
    }
}
