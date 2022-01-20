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
        public TimesheetsPlanArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
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
        public TimesheetsWorkArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
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
        public TimeactualWorkArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
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
        public MsalaryTargetsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            });
        }
    }

    // HsalaryTargets		HSALARY_TARGETS
    class HsalaryTargetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_HSALARY_TARGETS;
        public HsalaryTargetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HsalaryTargetsArtSpec(this.Code.Value);
        }
    }

    class HsalaryTargetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_PAYMENT_HOURS;
        public HsalaryTargetsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            });
        }
    }

    // MawardsTargets		MAWARDS_TARGETS
    class MawardsTargetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_MAWARDS_TARGETS;
        public MawardsTargetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new MawardsTargetsArtSpec(this.Code.Value);
        }
    }

    class MawardsTargetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_BASIS;
        public MawardsTargetsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
            });
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
        public PremiumTargetsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
            });
        }
    }

    // PremadvTargets		PREMADV_TARGETS
    class PremadvTargetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PREMADV_TARGETS;
        public PremadvTargetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PremadvTargetsArtSpec(this.Code.Value);
        }
    }

    class PremadvTargetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED;
        public PremadvTargetsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
            });
        }
    }

    // PremextTargets		PREMEXT_TARGETS
    class PremextTargetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PREMEXT_TARGETS;
        public PremextTargetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PremextTargetsArtSpec(this.Code.Value);
        }
    }

    class PremextTargetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED;
        public PremextTargetsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_TARGETS,
            });
        }
    }

    // MawardsResults		MAWARDS_RESULTS
    class MawardsResultsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_MAWARDS_RESULTS;
        public MawardsResultsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new MawardsResultsArtSpec(this.Code.Value);
        }
    }

    class MawardsResultsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_REDUCED_BASIS;
        public MawardsResultsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            });
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
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_REDUCED_FIXED;
        public PremiumResultsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            });
        }
    }

    // PremadvResults		PREMADV_RESULTS
    class PremadvResultsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PREMADV_RESULTS;
        public PremadvResultsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PremadvResultsArtSpec(this.Code.Value);
        }
    }

    class PremadvResultsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_REDUCED_FIXED;
        public PremadvResultsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            });
        }
    }

    // PremextResults		PREMEXT_RESULTS
    class PremextResultsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PREMEXT_RESULTS;
        public PremextResultsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PremextResultsArtSpec(this.Code.Value);
        }
    }

    class PremextResultsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_REDUCED_FIXED;
        public PremextResultsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_RESULTS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS,
            });
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
        public AgrworkTargetsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_AGRWORK,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXBASE,
            });
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
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS;
        public AllowceHofficeArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE,
            });
        }
    }

    // AllowceClothrs		ALLOWCE_CLOTHRS
    class AllowceClothrsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTHRS;
        public AllowceClothrsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AllowceClothrsArtSpec(this.Code.Value);
        }
    }

    class AllowceClothrsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS;
        public AllowceClothrsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE,
            });
        }
    }

    // AllowceClotday		ALLOWCE_CLOTDAY
    class AllowceClotdayArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_ALLOWCE_CLOTDAY;
        public AllowceClotdayArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new AllowceClotdayArtSpec(this.Code.Value);
        }
    }

    class AllowceClotdayArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_DAILY;
        public AllowceClotdayArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_ALLOWCE,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE,
            });
        }
    }

    // OffworkTargets		OFFWORK_TARGETS
    class OffworkTargetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_OFFWORK_TARGETS;
        public OffworkTargetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new OffworkTargetsArtSpec(this.Code.Value);
        }
    }

    class OffworkTargetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OFFWORK_HOURS;
        public OffworkTargetsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_OFFWORK,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXBASE,
            });
        }
    }

    // OffsetsHoffice		OFFSETS_HOFFICE
    class OffsetsHofficeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_OFFSETS_HOFFICE;
        public OffsetsHofficeArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new OffsetsHofficeArtSpec(this.Code.Value);
        }
    }

    class OffsetsHofficeArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OFFSETS_HFULL;
        public OffsetsHofficeArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_OFFSETS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE,
            });
        }
    }

    // OffsetsClothrs		OFFSETS_CLOTHRS
    class OffsetsClothrsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_OFFSETS_CLOTHRS;
        public OffsetsClothrsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new OffsetsClothrsArtSpec(this.Code.Value);
        }
    }

    class OffsetsClothrsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OFFSETS_HOURS;
        public OffsetsClothrsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_OFFSETS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE,
            });
        }
    }

    // OffsetsClotday		OFFSETS_CLOTDAY
    class OffsetsClotdayArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_OFFSETS_CLOTDAY;
        public OffsetsClotdayArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new OffsetsClotdayArtSpec(this.Code.Value);
        }
    }

    class OffsetsClotdayArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OFFSETS_DAILY;
        public OffsetsClotdayArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_OFFSETS,
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE,
            });
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
        public SettlemTargetsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
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
        public SettlemAllowceArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SettlemAgrwork		SETTLEM_AGRWORK
    class SettlemAgrworkArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_AGRWORK;
        public SettlemAgrworkArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SettlemAgrworkArtSpec(this.Code.Value);
        }
    }

    class SettlemAgrworkArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_AGRWORK;
        public SettlemAgrworkArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SettlemOffsets		SETTLEM_OFFSETS
    class SettlemOffsetsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_OFFSETS;
        public SettlemOffsetsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SettlemOffsetsArtSpec(this.Code.Value);
        }
    }

    class SettlemOffsetsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_OFFSETS;
        public SettlemOffsetsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // SettlemOffwork		SETTLEM_OFFWORK
    class SettlemOffworkArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_SETTLEM_OFFWORK;
        public SettlemOffworkArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new SettlemOffworkArtSpec(this.Code.Value);
        }
    }

    class SettlemOffworkArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_SETTLEM_OFFWORK;
        public SettlemOffworkArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
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
        public SettlemResultsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // IncomesTaxfree		INCOMES_TAXFREE
    class IncomesTaxfreeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXFREE;
        public IncomesTaxfreeArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomesTaxfreeArtSpec(this.Code.Value);
        }
    }

    class IncomesTaxfreeArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXFREE;
        public IncomesTaxfreeArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY,
            });
        }
    }

    // IncomesTaxbase		INCOMES_TAXBASE
    class IncomesTaxbaseArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXBASE;
        public IncomesTaxbaseArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomesTaxbaseArtSpec(this.Code.Value);
        }
    }

    class IncomesTaxbaseArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXBASE;
        public IncomesTaxbaseArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY,
            });
        }
    }

    // IncomesTaxwins		INCOMES_TAXWINS
    class IncomesTaxwinsArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_INCOMES_TAXWINS;
        public IncomesTaxwinsArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new IncomesTaxwinsArtSpec(this.Code.Value);
        }
    }

    class IncomesTaxwinsArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_INCOMES_TAXWINS;
        public IncomesTaxwinsArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                (Int32)OptimulaArticleConst.ARTICLE_INCOMES_SUMMARY,
            });
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
        public IncomesSummaryArtSpec(Int32 code) : base(code, ArticleSeqs.ZeroCode, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }
}
