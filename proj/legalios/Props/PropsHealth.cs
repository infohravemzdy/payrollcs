using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Props
{
    public class PropsHealth : PropsBase, IPropsHealth
    {
        public static IPropsHealth Empty()
        {
            return new PropsHealth(VERSION_ZERO);
        }
        public PropsHealth(Int16 version) : base(version)
        {
            this.MinMonthlyBasis = 0;
            this.MaxAnnualsBasis = 0;
            this.LimMonthlyState = 0;
            this.LimMonthlyDis50 = 0;
            this.FactorCompound = 0m;
            this.FactorEmployee = 0m;
            this.MarginIncomeEmp = 0;
            this.MarginIncomeAgr = 0;
        }
        public PropsHealth(VersionId version,
            Int32 minMonthlyBasis, Int32 maxAnnualsBasis,
            Int32 limMonthlyState, Int32 limMonthlyDis50,
            decimal factorCompound, decimal factorEmployee,
            Int32 marginIncomeEmp, Int32 marginIncomeAgr) : base(version)
        {
            this.MinMonthlyBasis = minMonthlyBasis;
            this.MaxAnnualsBasis = maxAnnualsBasis;
            this.LimMonthlyState = limMonthlyState;
            this.LimMonthlyDis50 = limMonthlyDis50;
            this.FactorCompound = factorCompound;
            this.FactorEmployee = factorEmployee;
            this.MarginIncomeEmp = marginIncomeEmp;
            this.MarginIncomeAgr = marginIncomeAgr;
        }
        public Int32 MinMonthlyBasis { get; set; }
        public Int32 MaxAnnualsBasis { get; set; }
        public Int32 LimMonthlyState { get; set; }
        public Int32 LimMonthlyDis50 { get; set; }
        public decimal FactorCompound { get; set; }
        public decimal FactorEmployee { get; set; }
        public Int32 MarginIncomeEmp { get; set; }
        public Int32 MarginIncomeAgr { get; set; }
        public bool HasParticy(WorkHealthTerms term, Int32 incomeTerm, Int32 incomeSpec)
        {
            bool particySpec = true;
            if (HasTermExemptionParticy(term))
            {
                particySpec = false;
            }
            else if (HasIncomeBasedAgreementsParticy(term) && MarginIncomeAgr > 0)
            {
                particySpec = false;
                if (HasIncomeCumulatedParticy(term))
                {
                    if (incomeTerm >= MarginIncomeAgr)
                    {
                        particySpec = true;
                    }
                }
                else
                {
                    if (incomeSpec >= MarginIncomeAgr)
                    {
                        particySpec = true;
                    }
                }
            }
            else if (HasIncomeBasedEmploymentParticy(term) && MarginIncomeEmp > 0)
            {
                particySpec = false;
                if (HasIncomeCumulatedParticy(term))
                {
                    if (incomeTerm >= MarginIncomeEmp)
                    {
                        particySpec = true;
                    }
                }
                else
                {
                    if (incomeSpec >= MarginIncomeEmp)
                    {
                        particySpec = true;
                    }
                }
            }
            return particySpec;
        }
        private bool HasTermExemptionParticy(WorkHealthTerms term)
        {
            return false;
        }
        private bool HasIncomeBasedEmploymentParticy(WorkHealthTerms term)
        {
            return (term == WorkHealthTerms.HEALTH_TERM_AGREEM_WORK);
        }
        private bool HasIncomeBasedAgreementsParticy(WorkHealthTerms term)
        {
            return (term == WorkHealthTerms.HEALTH_TERM_AGREEM_TASK);
        }
        private bool HasIncomeCumulatedParticy(WorkHealthTerms term)
        {
            switch (term)
            {
                case WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS:
                    return false;
                case WorkHealthTerms.HEALTH_TERM_AGREEM_WORK:
                    return false;
                case WorkHealthTerms.HEALTH_TERM_AGREEM_TASK:
                    return false;
                case WorkHealthTerms.HEALTH_TERM_BY_CONTRACT:
                    return false;
            }
            return false;
        }
    }
}
