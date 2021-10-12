﻿using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;

namespace ProcezorTests.Registry.Providers.Articles
{
    // HealthInsBase            HEALTH_INSBASE
    class HealthInsBaseArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)TestArticleConst.ARTICLE_HEALTH_INSBASE;
        class HealthInsBaseArtSpec : ArticleSpec
        {
            const Int32 CONCEPT_CODE = (Int32)TestConceptConst.CONCEPT_HEALTH_INSBASE;

            public HealthInsBaseArtSpec(Int32 code) : base(code, CONCEPT_CODE)
            {
                Sums = new List<ArticleCode>();
            }
        }
        public HealthInsBaseArtProv() : base(ARTICLE_CODE)
        {
        }
        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthInsBaseArtSpec(this.Code.Value);
        }
    }
}