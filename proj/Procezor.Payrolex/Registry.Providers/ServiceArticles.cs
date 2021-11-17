using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using Procezor.Payrolex.Registry.Constants;

namespace Procezor.Payrolex.Registry.Providers
{
    // ContractTerm		CONTRACT_TERM
    class ContractTermArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_CONTRACT_TERM;
        public ContractTermArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new ContractTermArtSpec(this.Code.Value);
        }
    }

    class ContractTermArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_CONTRACT_TERM;
        public ContractTermArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PositionTerm		POSITION_TERM
    class PositionTermArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_POSITION_TERM;
        public PositionTermArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PositionTermArtSpec(this.Code.Value);
        }
    }

    class PositionTermArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_POSITION_TERM;
        public PositionTermArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PositionWorkPlan		POSITION_WORK_PLAN
    class PositionWorkPlanArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_POSITION_WORK_PLAN;
        public PositionWorkPlanArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PositionWorkPlanArtSpec(this.Code.Value);
        }
    }

    class PositionWorkPlanArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_POSITION_WORK_PLAN;
        public PositionWorkPlanArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PositionTimePlan		POSITION_TIME_PLAN
    class PositionTimePlanArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_PLAN;
        public PositionTimePlanArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PositionTimePlanArtSpec(this.Code.Value);
        }
    }

    class PositionTimePlanArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_POSITION_TIME_PLAN;
        public PositionTimePlanArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PositionTimeWork		POSITION_TIME_WORK
    class PositionTimeWorkArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_WORK;
        public PositionTimeWorkArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PositionTimeWorkArtSpec(this.Code.Value);
        }
    }

    class PositionTimeWorkArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_POSITION_TIME_WORK;
        public PositionTimeWorkArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PositionTimeAbsc		POSITION_TIME_ABSC
    class PositionTimeAbscArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_POSITION_TIME_ABSC;
        public PositionTimeAbscArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PositionTimeAbscArtSpec(this.Code.Value);
        }
    }

    class PositionTimeAbscArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_POSITION_TIME_ABSC;
        public PositionTimeAbscArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // ContractTimePlan		CONTRACT_TIME_PLAN
    class ContractTimePlanArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_CONTRACT_TIME_PLAN;
        public ContractTimePlanArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new ContractTimePlanArtSpec(this.Code.Value);
        }
    }

    class ContractTimePlanArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_CONTRACT_TIME_PLAN;
        public ContractTimePlanArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // ContractTimeWork		CONTRACT_TIME_WORK
    class ContractTimeWorkArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_CONTRACT_TIME_WORK;
        public ContractTimeWorkArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new ContractTimeWorkArtSpec(this.Code.Value);
        }
    }

    class ContractTimeWorkArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_CONTRACT_TIME_WORK;
        public ContractTimeWorkArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // ContractTimeAbsc		CONTRACT_TIME_ABSC
    class ContractTimeAbscArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_CONTRACT_TIME_ABSC;
        public ContractTimeAbscArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new ContractTimeAbscArtSpec(this.Code.Value);
        }
    }

    class ContractTimeAbscArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_CONTRACT_TIME_ABSC;
        public ContractTimeAbscArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PaymentSalary		PAYMENT_SALARY
    class PaymentSalaryArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_PAYMENT_SALARY;
        public PaymentSalaryArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentSalaryArtSpec(this.Code.Value);
        }
    }

    class PaymentSalaryArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_BASIS;
        public PaymentSalaryArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                    (Int32)PayrolexArticleConst.ARTICLE_INCOME_GROSS,
                });
        }
    }

    // PaymentBonus		PAYMENT_BONUS
    class PaymentBonusArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_PAYMENT_BONUS;
        public PaymentBonusArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentBonusArtSpec(this.Code.Value);
        }
    }

    class PaymentBonusArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_FIXED;
        public PaymentBonusArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                    (Int32)PayrolexArticleConst.ARTICLE_INCOME_GROSS,
                });
        }
    }

    // PaymentBarter		PAYMENT_BARTER
    class PaymentBarterArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_PAYMENT_BARTER;
        public PaymentBarterArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentBarterArtSpec(this.Code.Value);
        }
    }

    class PaymentBarterArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_FIXED;
        public PaymentBarterArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // AllowceHoffice		ALLOWCE_HOFFICE
    class AllowceHofficeArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)PayrolexArticleConst.ARTICLE_ALLOWCE_HOFFICE;
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
        public const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_PAYMENT_FIXED;
        public AllowceHofficeArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = ArticleSpec.ConstToSumsArray(new List<Int32>() {
                    (Int32)PayrolexArticleConst.ARTICLE_INCOME_NETTO,
                });
        }
    }

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
        public IncomeGrossArtSpec(Int32 code) : base(code, CONCEPT_CODE)
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
        public IncomeNettoArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }
}

