using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;

namespace ProcezorTests.Registry.Providers.Articles
{
    // IncomeNetto              INCOME_NETTO
    class IncomeNettoArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)TestArticleConst.ARTICLE_INCOME_NETTO;
        class IncomeNettoArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)TestConceptConst.CONCEPT_INCOME_NETTO;

            public IncomeNettoArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>();
            }
        }
        public IncomeNettoArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomeNettoArtSpec(this.Code.Value);
        }
    }
}
