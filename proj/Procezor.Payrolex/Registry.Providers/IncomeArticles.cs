using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Procezor.Payrolex.Registry.Constants;

namespace HraveMzdy.Procezor.Payrolex.Registry.Providers
{
    // IncomeGross		INCOME_GROSS
    class IncomeGrossArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_INCOME_GROSS;
        public IncomeGrossArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomeGrossArtSpec(this.Code.Value);
        }
    }

    class IncomeGrossArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_INCOME_GROSS;
        public IncomeGrossArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // IncomeNetto		INCOME_NETTO
    class IncomeNettoArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_INCOME_NETTO;
        public IncomeNettoArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomeNettoArtSpec(this.Code.Value);
        }
    }

    class IncomeNettoArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_INCOME_NETTO;
        public IncomeNettoArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }
    // EmployerCosts		EMPLOYER_COSTS
    class EmployerCostsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_EMPLOYER_COSTS;
        public EmployerCostsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new EmployerCostsArtSpec(this.Code.Value);
        }
    }

    class EmployerCostsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_EMPLOYER_COSTS;
        public EmployerCostsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

}

