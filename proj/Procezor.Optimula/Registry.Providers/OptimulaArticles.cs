using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using HraveMzdy.Procezor.Optimula.Registry.Constants;

namespace HraveMzdy.Procezor.Optimula.Registry.Providers
{
    // ContractTimePlan		CONTRACT_TIME_PLAN
    class ContractTimePlanArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_CONTRACT_TIME_PLAN;
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
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_CONTRACT_TIME_PLAN;
        public ContractTimePlanArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // ContractTimeWork		CONTRACT_TIME_WORK
    class ContractTimeWorkArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_CONTRACT_TIME_WORK;
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
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_CONTRACT_TIME_WORK;
        public ContractTimeWorkArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PaymentMsalary		PAYMENT_MSALARY
    class PaymentMsalaryArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PAYMENT_MSALARY;
        public PaymentMsalaryArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentMsalaryArtSpec(this.Code.Value);
        }
    }

    class PaymentMsalaryArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_PAYMENT_BASIS;
        public PaymentMsalaryArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PaymentMperson		PAYMENT_MPERSON
    class PaymentMpersonArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PAYMENT_MPERSON;
        public PaymentMpersonArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentMpersonArtSpec(this.Code.Value);
        }
    }

    class PaymentMpersonArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_BASIS;
        public PaymentMpersonArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PaymentPremium		PAYMENT_PREMIUM
    class PaymentPremiumArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PAYMENT_PREMIUM;
        public PaymentPremiumArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentPremiumArtSpec(this.Code.Value);
        }
    }

    class PaymentPremiumArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_OPTIMUS_FIXED;
        public PaymentPremiumArtSpec(Int32 code) : base(code, CONCEPT_CODE)
        {
            Sums = new List<ArticleCode>();
        }
    }

    // PaymentAgrwork		PAYMENT_AGRWORK
    class PaymentAgrworkArtProv : ArticleSpecProvider
    {
        public const Int32 ARTICLE_CODE = (Int32)OptimulaArticleConst.ARTICLE_PAYMENT_AGRWORK;
        public PaymentAgrworkArtProv() : base(ARTICLE_CODE)
        {
        }

        public override IArticleSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new PaymentAgrworkArtSpec(this.Code.Value);
        }
    }

    class PaymentAgrworkArtSpec : ArticleSpec
    {
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_AGRWORK_HOURS;
        public PaymentAgrworkArtSpec(Int32 code) : base(code, CONCEPT_CODE)
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
        public const Int32 CONCEPT_CODE = (Int32)OptimulaConceptConst.CONCEPT_ALLOWCE_HOURS;
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

}
