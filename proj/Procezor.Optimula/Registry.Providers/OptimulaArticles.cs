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

    // MsalaryTargets		MSALARY_TARGETS
    class MsalaryTargetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_MSALARY_TARGETS;
        public MsalaryTargetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new MsalaryTargetsArtSpec(this.Code.Value);
        }
    }

    class MsalaryTargetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_PAYMENT_BASIS;
        public MsalaryTargetsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // HSalaryTargets		HSALARY_TARGETS
    class HSalaryTargetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_HSALARY_TARGETS;
        public HSalaryTargetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HSalaryTargetsArtSpec(this.Code.Value);
        }
    }

    class HSalaryTargetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_PAYMENT_HOURS;
        public HSalaryTargetsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // MAwardsTargets		MAWARDS_TARGETS
    class MAwardsTargetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_MAWARDS_TARGETS;
        public MAwardsTargetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new MAwardsTargetsArtSpec(this.Code.Value);
        }
    }

    class MAwardsTargetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_BASIS;
        public MAwardsTargetsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // HAwardsTargets		HAWARDS_TARGETS
    class HAwardsTargetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_HAWARDS_TARGETS;
        public HAwardsTargetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HAwardsTargetsArtSpec(this.Code.Value);
        }
    }

    class HAwardsTargetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_HOURS;
        public HAwardsTargetsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PremiumTargets		PREMIUM_TARGETS
    class PremiumTargetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PREMIUM_TARGETS;
        public PremiumTargetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PremiumTargetsArtSpec(this.Code.Value);
        }
    }

    class PremiumTargetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED;
        public PremiumTargetsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PremAdvTargets		PREMADV_TARGETS
    class PremAdvTargetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PREMADV_TARGETS;
        public PremAdvTargetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PremAdvTargetsArtSpec(this.Code.Value);
        }
    }

    class PremAdvTargetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED;
        public PremAdvTargetsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PremExtTargets		PREMEXT_TARGETS
    class PremExtTargetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PREMEXT_TARGETS;
        public PremExtTargetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PremExtTargetsArtSpec(this.Code.Value);
        }
    }

    class PremExtTargetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED;
        public PremExtTargetsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // MAwardsResults		MAWARDS_RESULTS
    class MAwardsResultsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_MAWARDS_RESULTS;
        public MAwardsResultsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new MAwardsResultsArtSpec(this.Code.Value);
        }
    }

    class MAwardsResultsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_BASIS;
        public MAwardsResultsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PremiumResults		PREMIUM_RESULTS
    class PremiumResultsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PREMIUM_RESULTS;
        public PremiumResultsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PremiumResultsArtSpec(this.Code.Value);
        }
    }

    class PremiumResultsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED;
        public PremiumResultsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PremAdvResults		PREMADV_RESULTS
    class PremAdvResultsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PREMADV_RESULTS;
        public PremAdvResultsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PremAdvResultsArtSpec(this.Code.Value);
        }
    }

    class PremAdvResultsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED;
        public PremAdvResultsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PremExtResults		PREMEXT_RESULTS
    class PremExtResultsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PREMEXT_RESULTS;
        public PremExtResultsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PremExtResultsArtSpec(this.Code.Value);
        }
    }

    class PremExtResultsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED;
        public PremExtResultsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // AgrworkTargets		AGRWORK_TARGETS
    class AgrworkTargetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_AGRWORK_TARGETS;
        public AgrworkTargetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AgrworkTargetsArtSpec(this.Code.Value);
        }
    }

    class AgrworkTargetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_AGRWORK_HOURS;
        public AgrworkTargetsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    class AgrworkResultsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_AGRWORK_HOURS;
        public AgrworkResultsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
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

    // AllowceClotDay		ALLOWCE_CLOTDAY
    class AllowceClotDayArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTDAY;
        public AllowceClotDayArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AllowceClotDayArtSpec(this.Code.Value);
        }
    }

    class AllowceClotDayArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_DAILY;
        public AllowceClotDayArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // AllowceClotHrs		ALLOWCE_CLOTHRS
    class AllowceClotHrsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTHRS;
        public AllowceClotHrsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AllowceClotHrsArtSpec(this.Code.Value);
        }
    }

    class AllowceClotHrsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS;
        public AllowceClotHrsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SettlemTargets		SETTLEM_TARGETS
    class SettlemTargetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS;
        public SettlemTargetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SettlemTargetsArtSpec(this.Code.Value);
        }
    }

    class SettlemTargetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_TARGETS;
        public SettlemTargetsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SettlemAllowce		SETTLEM_ALLOWCE
    class SettlemAllowceArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE;
        public SettlemAllowceArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SettlemAllowceArtSpec(this.Code.Value);
        }
    }

    class SettlemAllowceArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_ALLOWCE;
        public SettlemAllowceArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SettlemAgrWork		SETTLEM_AGRWORK
    class SettlemAgrWorkArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_AGRWORK;
        public SettlemAgrWorkArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SettlemAgrWorkArtSpec(this.Code.Value);
        }
    }

    class SettlemAgrWorkArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_AGRWORK;
        public SettlemAgrWorkArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SettlemResults		SETTLEM_RESULTS
    class SettlemResultsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS;
        public SettlemResultsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SettlemResultsArtSpec(this.Code.Value);
        }
    }

    class SettlemResultsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_RESULTS;
        public SettlemResultsArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // IncomesTaxFree		INCOMES_TAXFREE
    class IncomesTaxFreeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE;
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
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXFREE;
        public IncomesTaxFreeArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // IncomesTaxBase		INCOMES_TAXBASE
    class IncomesTaxBaseArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXBASE;
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
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXBASE;
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

    // IncomesSummary		INCOMES_SUMMARY
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
