using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Procezor.Optimula.Registry.Constants;

namespace HraveMzdy.Procezor.Optimula.Registry.Providers
{
    // TimesheetsPlan		TIMESHEETS_PLAN
    class TimesheetsPlanArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_PLAN;
        public TimesheetsPlanArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TimesheetsPlanArtSpec(this.Code.Value);
        }
    }

    class TimesheetsPlanArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_TIMESHEETS_PLAN;
        public TimesheetsPlanArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TimesheetsWork		TIMESHEETS_WORK
    class TimesheetsWorkArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_TIMESHEETS_WORK;
        public TimesheetsWorkArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TimesheetsWorkArtSpec(this.Code.Value);
        }
    }

    class TimesheetsWorkArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_TIMESHEETS_WORK;
        public TimesheetsWorkArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // TimeactualWork		TIMEACTUAL_WORK
    class TimeactualWorkArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_TIMEACTUAL_WORK;
        public TimeactualWorkArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new TimeactualWorkArtSpec(this.Code.Value);
        }
    }

    class TimeactualWorkArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_TIMEACTUAL_WORK;
        public TimeactualWorkArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // MsalaryBasical		MSALARY_BASICAL
    class MsalaryBasicalArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_MSALARY_BASICAL;
        public MsalaryBasicalArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new MsalaryBasicalArtSpec(this.Code.Value);
        }
    }

    class MsalaryBasicalArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_PAYMENT_BASIS;
        public MsalaryBasicalArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // MsalaryBonused		MSALARY_BONUSED
    class MsalaryBonusedArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_MSALARY_BONUSED;
        public MsalaryBonusedArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new MsalaryBonusedArtSpec(this.Code.Value);
        }
    }

    class MsalaryBonusedArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_BASIS;
        public MsalaryBonusedArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PremiumBonused		PREMIUM_BONUSED
    class PremiumBonusedArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PREMIUM_BONUSED;
        public PremiumBonusedArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PremiumBonusedArtSpec(this.Code.Value);
        }
    }

    class PremiumBonusedArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED;
        public PremiumBonusedArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PremiumBossing		PREMIUM_BOSSING
    class PremiumBossingArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PREMIUM_BOSSING;
        public PremiumBossingArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PremiumBossingArtSpec(this.Code.Value);
        }
    }

    class PremiumBossingArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED;
        public PremiumBossingArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PremiumPersona		PREMIUM_PERSONA
    class PremiumPersonaArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PREMIUM_PERSONA;
        public PremiumPersonaArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PremiumPersonaArtSpec(this.Code.Value);
        }
    }

    class PremiumPersonaArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED;
        public PremiumPersonaArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // AllowceAgrwork		ALLOWCE_AGRWORK
    class AllowceAgrworkArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_AGRWORK;
        public AllowceAgrworkArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AllowceAgrworkArtSpec(this.Code.Value);
        }
    }

    class AllowceAgrworkArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_AGRWORK_HOURS;
        public AllowceAgrworkArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // AllowceHoffice		ALLOWCE_HOFFICE
    class AllowceHofficeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_HOFFICE;
        public AllowceHofficeArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AllowceHofficeArtSpec(this.Code.Value);
        }
    }

    class AllowceHofficeArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HFULL;
        public AllowceHofficeArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // AllowceClothes		ALLOWCE_CLOTHES
    class AllowceClothesArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTHES;
        public AllowceClothesArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AllowceClothesArtSpec(this.Code.Value);
        }
    }

    class AllowceClothesArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS;
        public AllowceClothesArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // IncomesTaxFree		INCOMES_TAXFREE
    class IncomesTaxFreeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTHES;
        public IncomesTaxFreeArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomesTaxFreeArtSpec(this.Code.Value);
        }
    }

    class IncomesTaxFreeArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS;
        public IncomesTaxFreeArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // IncomesTaxBase		INCOMES_TAXBASE
    class IncomesTaxBaseArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTHES;
        public IncomesTaxBaseArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomesTaxBaseArtSpec(this.Code.Value);
        }
    }

    class IncomesTaxBaseArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS;
        public IncomesTaxBaseArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // IncomesTaxWIns		INCOMES_TAXWINS
    class IncomesTaxWInsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS;
        public IncomesTaxWInsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomesTaxWInsArtSpec(this.Code.Value);
        }
    }

    class IncomesTaxWInsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXWINS;
        public IncomesTaxWInsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // IncomesSummary		INCOMES_TAXWINS
    class IncomesSummaryArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY;
        public IncomesSummaryArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomesSummaryArtSpec(this.Code.Value);
        }
    }

    class IncomesSummaryArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_INCOMES_SUMMARY;
        public IncomesSummaryArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

}
