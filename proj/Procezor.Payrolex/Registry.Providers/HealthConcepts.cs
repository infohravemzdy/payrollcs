﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Procezor.Service.Errors;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Providers;
using HraveMzdy.Procezor.Service.Types;
using MaybeMonad;
using Procezor.Payrolex.Registry.Constants;
using Procezor.Payrolex.Registry.Operations;
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

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;

            return new ITermTarget[] {
                new HealthDeclareTarget(month, con, pos, var, article, this.Code, 1, WorkHealthTerms.HEALTH_TERM_BY_CONTRACT, 1)
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthDeclareTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthDeclareTarget evalTarget = resTarget.Value;

            var resContract = GetContractResult<ContractWorkTermResult>(target, period, results,
             target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_CONTRACT_WORK_TERM));

            if (resContract.IsFailure)
            {
                return BuildFailResults(resContract.Error);
            }

            var evalContract = resContract.Value;

            var evalContractType = evalTarget.ContractType;

            if (evalContractType == WorkHealthTerms.HEALTH_TERM_BY_CONTRACT)
            {
                switch (evalContract.TermType)
                {
                    case WorkContractTerms.WORKTERM_EMPLOYMENT_1:
                        evalContractType = WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS;
                        break;
                    case WorkContractTerms.WORKTERM_CONTRACTER_A:
                        evalContractType = WorkHealthTerms.HEALTH_TERM_AGREEM_WORK;
                        break;
                    case WorkContractTerms.WORKTERM_CONTRACTER_T:
                        evalContractType = WorkHealthTerms.HEALTH_TERM_AGREEM_TASK;
                        break;
                    case WorkContractTerms.WORKTERM_PARTNER_STAT:
                        evalContractType = WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS;
                        break;
                    case WorkContractTerms.WORKTERM_UNKNOWN_TYPE:
                        evalContractType = WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS;
                        break;
                }
            }
            ITermResult resultsValues = new HealthDeclareResult(target, spec, 
                evalTarget.InterestCode, evalContractType, evalTarget.MandatorBase);

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

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;
            return new ITermTarget[] {
                new HealthIncomeTarget(month, con, pos, var, article, this.Code, 0)
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthIncomeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthIncomeTarget evalTarget = resTarget.Value;

            var incomeList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Contract.Equals(evalTarget.Contract) && v.Spec.Sums.Contains(evalTarget.Article)))
                .Select((tr) => (tr.ResultValue)).ToArray();

            decimal resValue = incomeList.Aggregate(decimal.Zero,
                (agr, item) => decimal.Add(agr, item));

            ITermResult resultsValues = new HealthIncomeResult(target, spec, RoundingInt.RoundToInt(resValue), 0, DESCRIPTION_EMPTY);

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

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;

            return new ITermTarget[] {
                new HealthBaseTarget(month, con, pos, var, article, this.Code, 0)
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthBaseTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthBaseTarget evalTarget = resTarget.Value;

            var resDeclare = GetContractResult<HealthDeclareResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE));
            var resIncomes = GetContractResult<HealthIncomeResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_INCOME));

            var resCompound = GetFailedOrOk(resDeclare.ErrOrOk(), resIncomes.ErrOrOk());
            if (resCompound.IsFailure)
            {
                return BuildFailResults(resCompound.Error);
            }

            var evalDeclare = resDeclare.Value;
            var evalIncomes = resIncomes.Value;

            Int32 resGeneralBase = 0;
            if (evalDeclare.InterestCode != 0)
            {
                resGeneralBase = evalIncomes.ResultValue;
            }

            ITermResult resultsValues = new HealthBaseResult(target, spec, 
                evalTarget.AnnuityBase, resGeneralBase, 0, DESCRIPTION_EMPTY);

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

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;

            return new ITermTarget[] {
                new HealthBaseEmployeeTarget(month, con, pos, var, article, this.Code, 0) 
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthBaseEmployeeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthBaseEmployeeTarget evalTarget = resTarget.Value;

            Int32 resBasis = 0;

            ITermResult resultsValues = new HealthBaseEmployeeResult(target, spec, resBasis, 0, DESCRIPTION_EMPTY);

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

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;

            return new ITermTarget[] {
                new HealthBaseEmployerTarget(month, con, pos, var, article, this.Code, 0) 
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resTarget = GetTypedTarget<HealthBaseEmployerTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthBaseEmployerTarget evalTarget = resTarget.Value;

            Int32 resBasis = 0;

            ITermResult resultsValues = new HealthBaseEmployerResult(target, spec, resBasis, 0, DESCRIPTION_EMPTY);

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

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;

            return new ITermTarget[] {
                new HealthBaseMandateTarget(month, con, pos, var, article, this.Code, 0) 
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrHealth = GetHealthPropsResult(ruleset, target, period);
            if (resPrHealth.IsFailure)
            {
                return BuildFailResults(resPrHealth.Error);
            }
            IPropsHealth healthRules = resPrHealth.Value;

            Int32 minMonthlyBasis = healthRules.MinMonthlyBasis;

            var resTarget = GetTypedTarget<HealthBaseMandateTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthBaseMandateTarget evalTarget = resTarget.Value;

            var resDeclare = GetContractResult<HealthDeclareResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE));
            var resBaseVal = GetContractResult<HealthBaseResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE));

            var resCompound = GetFailedOrOk(resDeclare.ErrOrOk(), resBaseVal.ErrOrOk());
            if (resCompound.IsFailure)
            {
                return BuildFailResults(resCompound.Error);
            }

            var evalDeclare = resDeclare.Value;
            var evalBaseVal = resBaseVal.Value;

            var basisList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE))
                .Select((tr) => (tr.ResultValue)).ToArray();

            var mandtList = results
                .Where((x) => (x.IsSuccess)).Select((r) => (r.Value))
                .Where((v) => (v.Article.Value == (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_MANDATE))
                .Select((tr) => (tr.ResultValue)).ToArray();

            Int32 resSumBasis = basisList.Aggregate(0,
                (agr, item) => (agr + item));
            Int32 resSumMandt = mandtList.Aggregate(0,
                (agr, item) => (agr + item));

            Int32 resGeneralBase = 0;
            Int32 resMandateBase = 0;
            if (evalDeclare.InterestCode != 0)
            {
                resGeneralBase = evalBaseVal.ResultValue;

                if (evalDeclare.MandatorBase != 0)
                {
                    Int32 curManHealth = Math.Max(0, minMonthlyBasis - (resSumBasis - resGeneralBase + resSumMandt));
                    Int32 sumManHealth = Math.Max(resGeneralBase, curManHealth);
                    resMandateBase = Math.Max(0, sumManHealth - resGeneralBase);
                }
            }

            if (resMandateBase > 0)
            {
                ITermResult resultsValues = new HealthBaseMandateResult(target, spec, resMandateBase, 0, DESCRIPTION_EMPTY);
                return BuildOkResults(resultsValues);
            }
            return BuildEmptyResults();
        }
    }

    // HealthBaseOvercap			HEALTH_BASE_OVERCAP
    class HealthBaseOvercapConProv : ConceptSpecProvider
    {
        const Int32 CONCEPT_CODE = (Int32)PayrolexConceptConst.CONCEPT_HEALTH_BASE_OVERCAP;
        public HealthBaseOvercapConProv() : base(CONCEPT_CODE)
        {
        }

        public override IConceptSpec GetSpec(IPeriod period, VersionCode version)
        {
            return new HealthBaseOvercapConSpec(this.Code.Value);
        }
    }

    class HealthBaseOvercapConSpec : PayrolexConceptSpec
    {
        public HealthBaseOvercapConSpec(Int32 code) : base(code)
        {
            Path = ConceptSpec.ConstToPathArray(new List<Int32>() {
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_DECLARE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;

            return new ITermTarget[] {
                new HealthBaseOvercapTarget(month, con, pos, var, article, this.Code, 0) 
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrHealth = GetHealthPropsResult(ruleset, target, period);
            if (resPrHealth.IsFailure)
            {
                return BuildFailResults(resPrHealth.Error);
            }
            IPropsHealth healthRules = resPrHealth.Value;

            Int32 maxAnnualsBasis = healthRules.MaxAnnualsBasis;

            var resTarget = GetTypedTarget<HealthBaseOvercapTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthBaseOvercapTarget evalTarget = resTarget.Value;

            var resBaseVal = GetContractResult<HealthBaseResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE));

            if (resBaseVal.IsFailure)
            {
                return BuildFailResults(resBaseVal.Error);
            }

            var evalBaseVal = resBaseVal.Value;

            Int32 resAnnuityBase = 0;
            if (maxAnnualsBasis > 0)
            {
                resAnnuityBase = Math.Max(0, (evalBaseVal.AnnuityBase + evalBaseVal.ResultValue) - maxAnnualsBasis);
            }

            if (resAnnuityBase > 0)
            {
                ITermResult resultsValues = new HealthBaseOvercapResult(target, spec, resAnnuityBase, 0, DESCRIPTION_EMPTY);
                return BuildOkResults(resultsValues);
            }
            return BuildEmptyResults();
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
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_OVERCAP,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_MANDATE,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYEE,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;

            return new ITermTarget[] {
                new HealthPaymEmployeeTarget(month, con, pos, var, article, this.Code, 0) 
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrHealth = GetHealthPropsResult(ruleset, target, period);
            if (resPrHealth.IsFailure)
            {
                return BuildFailResults(resPrHealth.Error);
            }
            IPropsHealth healthRules = resPrHealth.Value;

            decimal factorCompound = OperationsDec.Divide(healthRules.FactorCompound, 100);
            decimal factorEmployee = healthRules.FactorEmployee;

            var resTarget = GetTypedTarget<HealthPaymEmployeeTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthPaymEmployeeTarget evalTarget = resTarget.Value;

            var resBaseVal = GetContractResult<HealthBaseResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE));

            if (resBaseVal.IsFailure)
            {
                return BuildFailResults(resBaseVal.Error);
            }

            var evalBaseVal = resBaseVal.Value;

            Int32 valBaseGenerals = evalBaseVal.ResultValue;

            Int32 valBaseEmployee = 0;
            Int32 valBaseMandated = 0;
            Int32 valBaseOvercaps = 0;
            var resBaseEmployee = GetContractResult<HealthBaseEmployeeResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYEE));

            if (resBaseEmployee.IsSuccess)
            {
                valBaseEmployee = resBaseEmployee.Value.ResultValue;
            }
            var resBaseMandated = GetContractResult<HealthBaseMandateResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_MANDATE));

            if (resBaseMandated.IsSuccess)
            {
                valBaseMandated = resBaseMandated.Value.ResultValue;
            }
            
            valBaseEmployee = (valBaseEmployee + valBaseMandated);
            
            var resBaseOvercaps = GetContractResult<HealthBaseOvercapResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_OVERCAP));

            if (resBaseOvercaps.IsSuccess)
            {
                valBaseOvercaps = resBaseOvercaps.Value.ResultValue;
            }

            Int32 empBaseOvercaps = Math.Max(0, valBaseOvercaps - valBaseEmployee);
            valBaseEmployee = valBaseEmployee - empBaseOvercaps;
            valBaseOvercaps = (valBaseOvercaps - empBaseOvercaps);

            Int32 genBaseOvercaps = Math.Max(0, valBaseOvercaps - valBaseGenerals);
            valBaseGenerals = valBaseGenerals - genBaseOvercaps;
            valBaseOvercaps = (valBaseOvercaps - genBaseOvercaps);

            Int32 employeePayment = OperationsHealth.IntInsuranceRoundUp(
                OperationsDec.Multiply(valBaseEmployee, factorCompound)
                + OperationsDec.MultiplyAndDivide(valBaseGenerals, factorCompound, factorEmployee));

            ITermResult resultsValues = new HealthPaymEmployeeResult(target, spec, valBaseEmployee, valBaseGenerals, employeePayment, valBaseEmployee, DESCRIPTION_EMPTY);

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
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_OVERCAP,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_MANDATE,
                (Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYER,
            });

            ResultDelegate = ConceptEval;
        }

        public override IEnumerable<ITermTarget> DefaultTargetList(ArticleCode article, IPeriod period, IBundleProps ruleset, MonthCode month, IEnumerable<IContractTerm> conTerms, IEnumerable<IPositionTerm> posTerms, VariantCode var)
        {
            var con = ContractCode.Zero;
            var pos = PositionCode.Zero;

            return new ITermTarget[] {
                new HealthPaymEmployerTarget(month, con, pos, var, article, this.Code, 0) 
            };
        }

        private IList<Result<ITermResult, ITermResultError>> ConceptEval(ITermTarget target, IArticleSpec spec, IPeriod period, IBundleProps ruleset, IList<Result<ITermResult, ITermResultError>> results)
        {
            var resPrHealth = GetHealthPropsResult(ruleset, target, period);
            if (resPrHealth.IsFailure)
            {
                return BuildFailResults(resPrHealth.Error);
            }
            IPropsHealth healthRules = resPrHealth.Value;

            decimal factorCompound = OperationsDec.Divide(healthRules.FactorCompound, 100);
            decimal factorEmployee = healthRules.FactorEmployee;

            var resTarget = GetTypedTarget<HealthPaymEmployerTarget>(target, period);
            if (resTarget.IsFailure)
            {
                return BuildFailResults(resTarget.Error);
            }
            HealthPaymEmployerTarget evalTarget = resTarget.Value;

            var resBaseVal = GetContractResult<HealthBaseResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE));

            if (resBaseVal.IsFailure)
            {
                return BuildFailResults(resBaseVal.Error);
            }

            var evalBaseVal = resBaseVal.Value;

            Int32 valBaseGenerals = evalBaseVal.ResultValue;

            Int32 valBaseEmployee = 0;
            Int32 valBaseEmployer = 0;
            Int32 valBaseMandated = 0;
            Int32 valBaseOvercaps = 0;
            var resBaseEmployee = GetContractResult<HealthBaseEmployeeResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYEE));

            if (resBaseEmployee.IsSuccess)
            {
                valBaseEmployee = resBaseEmployee.Value.ResultValue;
            }
            var resBaseEmployer = GetContractResult<HealthBaseEmployeeResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_EMPLOYER));

            if (resBaseEmployer.IsSuccess)
            {
                valBaseEmployer = resBaseEmployer.Value.ResultValue;
            }
            var resBaseMandated = GetContractResult<HealthBaseMandateResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_MANDATE));

            if (resBaseMandated.IsSuccess)
            {
                valBaseMandated = resBaseMandated.Value.ResultValue;
            }

            valBaseEmployee = (valBaseEmployee + valBaseMandated);

            var resBaseOvercaps = GetContractResult<HealthBaseOvercapResult>(target, period, results,
                target.Contract, ArticleCode.Get((Int32)PayrolexArticleConst.ARTICLE_HEALTH_BASE_OVERCAP));

            if (resBaseOvercaps.IsSuccess)
            {
                valBaseOvercaps = resBaseOvercaps.Value.ResultValue;
            }

            Int32 empBaseOvercaps = Math.Max(0, valBaseOvercaps - valBaseEmployee);
            valBaseEmployee = valBaseEmployee - empBaseOvercaps;
            valBaseOvercaps = (valBaseOvercaps - empBaseOvercaps);

            Int32 genBaseOvercaps = Math.Max(0, valBaseOvercaps - valBaseGenerals);
            valBaseGenerals = valBaseGenerals - genBaseOvercaps;
            valBaseOvercaps = (valBaseOvercaps - genBaseOvercaps);

            Int32 emrBaseOvercaps = Math.Max(0, valBaseOvercaps - valBaseEmployer);
            valBaseEmployer = valBaseEmployer - emrBaseOvercaps;
            valBaseOvercaps = (valBaseOvercaps - emrBaseOvercaps);

            Int32 compoundBasis = valBaseEmployer + valBaseEmployee + valBaseGenerals;

            Int32 compoundPayment = OperationsHealth.IntInsuranceRoundUp(OperationsDec.Multiply(compoundBasis, factorCompound));
            Int32 employeePayment = OperationsHealth.IntInsuranceRoundUp(OperationsDec.Multiply(valBaseEmployee, factorCompound) + OperationsDec.MultiplyAndDivide(valBaseGenerals, factorCompound, factorEmployee));
            Int32 employerPayment = Math.Max(0, compoundPayment - employeePayment);

            ITermResult resultsValues = new HealthPaymEmployerResult(target, spec, valBaseEmployer, valBaseGenerals, employerPayment, 0, DESCRIPTION_EMPTY);

            return BuildOkResults(resultsValues);
        }
    }
}