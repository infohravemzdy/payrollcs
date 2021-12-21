using System;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Props
{
    public class PropsHealth : PropsHealthBase, IPropsHealth
    {
        public static IPropsHealth Empty()
        {
            return new PropsHealth(VERSION_ZERO);
        }
        public PropsHealth(Int16 version) : base(version)
        {
        }
        public PropsHealth(VersionId version,
            Int32 minMonthlyBasis, Int32 maxAnnualsBasis,
            Int32 limMonthlyState, Int32 limMonthlyDis50,
            decimal factorCompound, decimal factorEmployee,
            Int32 marginIncomeEmp, Int32 marginIncomeAgr) 
            : base(version,
                minMonthlyBasis, maxAnnualsBasis,
                limMonthlyState, limMonthlyDis50,
                factorCompound, factorEmployee,
                marginIncomeEmp, marginIncomeAgr)

        {
        }
        protected override bool HasTermExemptionParticy(WorkHealthTerms term)
        {
            return false;
        }
        protected override bool HasIncomeBasedEmploymentParticy(WorkHealthTerms term)
        {
            return (term == WorkHealthTerms.HEALTH_TERM_AGREEM_WORK);
        }
        protected override bool HasIncomeBasedAgreementsParticy(WorkHealthTerms term)
        {
            return (term == WorkHealthTerms.HEALTH_TERM_AGREEM_TASK);
        }
        protected override bool HasIncomeCumulatedParticy(WorkHealthTerms term)
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
