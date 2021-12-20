using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Props
{
    public class PropsSocial : PropsBase, IPropsSocial
    {
        public static IPropsSocial Empty()
        {
            return new PropsSocial(VERSION_ZERO);
        }
        public PropsSocial(Int16 version) : base(version)
        {
            this.MaxAnnualsBasis = 0;
            this.FactorEmployer = 0m;
            this.FactorEmployerHigher = 0m;
            this.FactorEmployee = 0m;
            this.FactorEmployeeGarant = 0m;
            this.FactorEmployeeReduce = 0m;
            this.MarginIncomeEmp = 0;
            this.MarginIncomeAgr = 0;
        }
        public PropsSocial(VersionId version,
            Int32 maxAnnualsBasis,
            decimal factorEmployer, decimal factorEmployerHigher,
            decimal factorEmployee, decimal factorEmployeeGarant, decimal factorEmployeeReduce,
            Int32 marginIncomeEmp, Int32 marginIncomeAgr) : base(version)
        {
            this.MaxAnnualsBasis = maxAnnualsBasis;
            this.FactorEmployer = factorEmployer;
            this.FactorEmployerHigher = factorEmployerHigher;
            this.FactorEmployee = factorEmployee;
            this.FactorEmployeeGarant = factorEmployeeGarant;
            this.FactorEmployeeReduce = factorEmployeeReduce;
            this.MarginIncomeEmp = marginIncomeEmp;
            this.MarginIncomeAgr = marginIncomeAgr;
        }
        public Int32 MaxAnnualsBasis { get; set; }
        public decimal FactorEmployer { get; set; }
        public decimal FactorEmployerHigher { get; set; }
        public decimal FactorEmployee { get; set; }
        public decimal FactorEmployeeGarant { get; set; }
        public decimal FactorEmployeeReduce { get; set; }
        public Int32 MarginIncomeEmp { get; set; }
        public Int32 MarginIncomeAgr { get; set; }
        public bool HasParticy(WorkSocialTerms term, Int32 incomeTerm, Int32 incomeSpec)
        {
            bool particySpec = true;
            if (HasIncomeBasedAgreementsParticy(term) && MarginIncomeAgr > 0)
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
        public bool HasIncomeBasedEmploymentParticy(WorkSocialTerms term)
        {
            return (term == WorkSocialTerms.SOCIAL_TERM_SMALLS_EMPL);
        }
        public bool HasIncomeBasedAgreementsParticy(WorkSocialTerms term)
        {
            return (term == WorkSocialTerms.SOCIAL_TERM_AGREEM_TASK);
        }
        public bool HasIncomeCumulatedParticy(WorkSocialTerms term)
        {
            switch (term)
            {
                case WorkSocialTerms.SOCIAL_TERM_EMPLOYMENTS:
                    return false;
                case WorkSocialTerms.SOCIAL_TERM_AGREEM_TASK:
                    return false;
                case WorkSocialTerms.SOCIAL_TERM_SMALLS_EMPL:
                    return false;
                case WorkSocialTerms.SOCIAL_TERM_SHORTS_MEET:
                    return false;
                case WorkSocialTerms.SOCIAL_TERM_SHORTS_DENY:
                    return false;
                case WorkSocialTerms.SOCIAL_TERM_BY_CONTRACT:
                    return false;
            }
            return false;
        }
    }
}
