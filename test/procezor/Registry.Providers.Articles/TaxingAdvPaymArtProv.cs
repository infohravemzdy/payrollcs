using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;

namespace ProcezorTests.Registry.Providers.Articles
{
    // TaxingAdvPaym            TAXING_ADVPAYM
    class TaxingAdvPaymArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)TestArticleConst.ARTICLE_TAXING_ADVPAYM;
        class TaxingAdvPaymArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)TestConceptConst.CONCEPT_TAXING_ADVPAYM;

            public TaxingAdvPaymArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>();
            }
        }
        public TaxingAdvPaymArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TaxingAdvPaymArtSpec(this.Code.Value);
        }
    }
}
