using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using Procezor.Payrolex.Registry.Constants;
using ResultMonad;

namespace Procezor.Payrolex.Registry.Providers
{
    // HealthDeclare			HEALTH_DECLARE
    class HealthDeclareConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_DECLARE;
        public HealthDeclareConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthDeclareConSpec(this.Code.Value);
        }
    }

    class HealthDeclareConSpec : PayrolexConceptSpec
    {
        public HealthDeclareConSpec(Int32 code) : base(code)
        {
            Path = new List<ArticleCode>();

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new HealthDeclareTarget(month, con, pos, var, article, this.Code, 0);
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthDeclareTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthDeclareTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new HealthDeclareResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // HealthIncome			HEALTH_INCOME
    class HealthIncomeConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_INCOME;
        public HealthIncomeConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthIncomeConSpec(this.Code.Value);
        }
    }

    class HealthIncomeConSpec : PayrolexConceptSpec
    {
        public HealthIncomeConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new HealthIncomeTarget(month, con, pos, var, article, this.Code, 0);
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthIncomeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthIncomeTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new HealthIncomeResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // HealthBase			HEALTH_BASE
    class HealthBaseConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE;
        public HealthBaseConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthBaseConSpec(this.Code.Value);
        }
    }

    class HealthBaseConSpec : PayrolexConceptSpec
    {
        public HealthBaseConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_INCOME,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new HealthBaseTarget(month, con, pos, var, article, this.Code, 0);
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthBaseTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthBaseTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new HealthBaseResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // HealthBaseEmployee			HEALTH_BASE_EMPLOYEE
    class HealthBaseEmployeeConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_EMPLOYEE;
        public HealthBaseEmployeeConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthBaseEmployeeConSpec(this.Code.Value);
        }
    }

    class HealthBaseEmployeeConSpec : PayrolexConceptSpec
    {
        public HealthBaseEmployeeConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new HealthBaseEmployeeTarget(month, con, pos, var, article, this.Code, 0);
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthBaseEmployeeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthBaseEmployeeTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new HealthBaseEmployeeResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // HealthBaseEmployer			HEALTH_BASE_EMPLOYER
    class HealthBaseEmployerConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_EMPLOYER;
        public HealthBaseEmployerConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthBaseEmployerConSpec(this.Code.Value);
        }
    }

    class HealthBaseEmployerConSpec : PayrolexConceptSpec
    {
        public HealthBaseEmployerConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new HealthBaseEmployerTarget(month, con, pos, var, article, this.Code, 0);
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthBaseEmployerTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthBaseEmployerTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new HealthBaseEmployerResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // HealthBaseMandate			HEALTH_BASE_MANDATE
    class HealthBaseMandateConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_MANDATE;
        public HealthBaseMandateConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthBaseMandateConSpec(this.Code.Value);
        }
    }

    class HealthBaseMandateConSpec : PayrolexConceptSpec
    {
        public HealthBaseMandateConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new HealthBaseMandateTarget(month, con, pos, var, article, this.Code, 0);
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthBaseMandateTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthBaseMandateTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new HealthBaseMandateResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // HealthPaymEmployee			HEALTH_PAYM_EMPLOYEE
    class HealthPaymEmployeeConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_PAYM_EMPLOYEE;
        public HealthPaymEmployeeConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthPaymEmployeeConSpec(this.Code.Value);
        }
    }

    class HealthPaymEmployeeConSpec : PayrolexConceptSpec
    {
        public HealthPaymEmployeeConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_MANDATE,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYEE,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new HealthPaymEmployeeTarget(month, con, pos, var, article, this.Code, 0);
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthPaymEmployeeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthPaymEmployeeTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new HealthPaymEmployeeResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }

    // HealthPaymEmployer			HEALTH_PAYM_EMPLOYER
    class HealthPaymEmployerConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_PAYM_EMPLOYER;
        public HealthPaymEmployerConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthPaymEmployerConSpec(this.Code.Value);
        }
    }

    class HealthPaymEmployerConSpec : PayrolexConceptSpec
    {
        public HealthPaymEmployerConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_MANDATE,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYER,
            });

            ResultDelegate = ConceptEval;
        }

        public override ITermTarget DefaultTarget(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, ContractCode con, PositionCode pos, VariantCode var)
        {
            return new HealthPaymEmployerTarget(month, con, pos, var, article, this.Code, 0);
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthPaymEmployerTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthPaymEmployerTarget evalTarget = resTarget.Value;

            ITermResult resultsValues = new HealthPaymEmployerResult(target, spec, 0, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }
}
