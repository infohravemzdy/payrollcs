using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Props
{
    public class PropsSocial2012 : PropsSocial, IPropsSocial
    {
        public PropsSocial2012(Int16 version) : base(version)
        {
        }
        public PropsSocial2012(VersionId version,
            Int32 maxAnnualsBasis,
            decimal factorEmployer, decimal factorEmployerHigher,
            decimal factorEmployee, decimal factorEmployeeGarant, decimal factorEmployeeReduce,
            Int32 marginIncomeEmp, Int32 marginIncomeAgr)
            : base(version,
                maxAnnualsBasis,
                factorEmployer, factorEmployerHigher,
                factorEmployee, factorEmployeeGarant, factorEmployeeReduce,
                marginIncomeEmp, marginIncomeAgr)
        {
        }
        protected override bool HasTermExemptionParticy(WorkSocialTerms term)
        {
            return false;
        }
        protected override bool HasIncomeBasedEmploymentParticy(WorkSocialTerms term)
        {
            return (term == WorkSocialTerms.SOCIAL_TERM_SMALLS_EMPL);
        }
        protected override bool HasIncomeBasedAgreementsParticy(WorkSocialTerms term)
        {
            return (term == WorkSocialTerms.SOCIAL_TERM_AGREEM_TASK);
        }
        protected override bool HasIncomeCumulatedParticy(WorkSocialTerms term)
        {
            switch (term)
            {
                case WorkSocialTerms.SOCIAL_TERM_EMPLOYMENTS:
                    return false;
                case WorkSocialTerms.SOCIAL_TERM_AGREEM_TASK:
                    return true;
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
