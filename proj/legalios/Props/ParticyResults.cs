using System;
using System.Collections.Generic;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Props
{
    public class ParticyHealthTarget
    {
        public Int16 ContractCode { get; private set; }
        public WorkTaxingTerms SubjectType { get; private set; }
        public Int16 InterestCode { get; private set; }
        public WorkHealthTerms SubjectTerm { get; private set; }
        public Int16 ParticyCode { get; private set; }
        public Int32 TargetsBase { get; private set; }
        public ParticyHealthTarget(Int16 contractCode, WorkTaxingTerms subjectType, Int16 interestCode, WorkHealthTerms subjectTerm, Int16 particyCode, Int32 targetsBase)
        { 
            this.ContractCode = contractCode;
            this.SubjectType = subjectType;
            this.InterestCode = interestCode;
            this.SubjectTerm = subjectTerm;
            this.ParticyCode = particyCode;
            this.TargetsBase = targetsBase;
        }
        public Int32 AddTargetsBase(Int32 targetsBase)
        {
            TargetsBase += targetsBase;
            return TargetsBase;
        }
        public Int32 IncomeScore()
        {
            Int32 resultType = 0;
            switch (SubjectType)
            {
                case WorkTaxingTerms.TAXING_TERM_EMPLOYMENTS:
                    resultType = 900;
                    break;
                case WorkTaxingTerms.TAXING_TERM_AGREEM_TASK:
                    resultType = 100;
                    break;
                case WorkTaxingTerms.TAXING_TERM_STATUT_PART:
                    resultType = 500;
                    break;
                case WorkTaxingTerms.TAXING_TERM_BY_CONTRACT:
                    resultType = 0;
                    break;
            }
            Int32 resultBase = 0;
            switch (SubjectTerm)
            {
                case WorkHealthTerms.HEALTH_TERM_EMPLOYMENTS:
                    resultBase = 9000;
                    break;
                case WorkHealthTerms.HEALTH_TERM_AGREEM_WORK:
                    resultBase = 5000;
                    break;
                case WorkHealthTerms.HEALTH_TERM_AGREEM_TASK:
                    resultBase = 4000;
                    break;
                case WorkHealthTerms.HEALTH_TERM_BY_CONTRACT:
                    resultBase = 0;
                    break;
            }
            Int32 interestRes = 0;
            if (InterestCode == 1)
            {
                interestRes = 10000;
            }
            Int32 particyRes = 0;
            if (ParticyCode == 1)
            {
                particyRes = 100000;
            }
            return resultType + resultBase + interestRes + particyRes;
        }
        private class ParticyHealthTargetComparator : IComparer<ParticyHealthTarget>
        {
            public ParticyHealthTargetComparator()
            {
            }

            public int Compare(ParticyHealthTarget x, ParticyHealthTarget y)
            {
                Int32 xIncomeScore = x.IncomeScore();
                Int32 yIncomeScore = y.IncomeScore();

                if (xIncomeScore.CompareTo(yIncomeScore) == 0)
                {
                    return x.ContractCode.CompareTo(y.ContractCode);
                }
                return yIncomeScore.CompareTo(xIncomeScore);
            }
        }
        public static IComparer<ParticyHealthTarget> ResultComparator()
        {
            return new ParticyHealthTargetComparator();
        }
    }
    public record ParticyHealthResult(Int16 ContractCode, WorkTaxingTerms SubjectType, Int16 InterestCode, WorkHealthTerms SubjectTerm, Int16 ParticyCode, Int32 TargetsBase, Int32 ResultsBase);
    public class ParticySocialTarget
    {
        public Int16 ContractCode { get; private set; }
        public WorkTaxingTerms SubjectType { get; private set; }
        public Int16 InterestCode { get; private set; }
        public WorkSocialTerms SubjectTerm { get; private set; }
        public Int16 ParticyCode { get; private set; }
        public Int32 TargetsBase { get; private set; }
        public ParticySocialTarget(Int16 contractCode, WorkTaxingTerms subjectType, Int16 interestCode, WorkSocialTerms subjectTerm, Int16 particyCode, Int32 targetsBase)
        { 
            this.ContractCode = contractCode;
            this.SubjectType = subjectType;
            this.InterestCode = interestCode;
            this.SubjectTerm = subjectTerm;
            this.ParticyCode = particyCode;
            this.TargetsBase = targetsBase;
        }
        public Int32 AddTargetsBase(Int32 targetsBase)
        {
            TargetsBase += targetsBase;
            return TargetsBase;
        }
        public Int32 IncomeScore()
        {
            Int32 resultType = 0;
            switch (SubjectType)
            {
                case WorkTaxingTerms.TAXING_TERM_EMPLOYMENTS:
                    resultType = 900;
                    break;
                case WorkTaxingTerms.TAXING_TERM_AGREEM_TASK:
                    resultType = 100;
                    break;
                case WorkTaxingTerms.TAXING_TERM_STATUT_PART:
                    resultType = 500;
                    break;
                case WorkTaxingTerms.TAXING_TERM_BY_CONTRACT:
                    resultType = 0;
                    break;
            }
            Int32 resultBase = 0;
            switch (SubjectTerm)
            {
                case WorkSocialTerms.SOCIAL_TERM_EMPLOYMENTS:
                    resultBase = 9000;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_SMALLS_EMPL:
                    resultBase = 5000;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_SHORTS_MEET:
                    resultBase = 4000;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_SHORTS_DENY:
                    resultBase = 0;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_BY_CONTRACT:
                    resultBase = 0;
                    break;
                case WorkSocialTerms.SOCIAL_TERM_AGREEM_TASK:
                    resultBase = 0;
                    break;
            }
            Int32 interestRes = 0;
            if (InterestCode == 1)
            {
                interestRes = 10000;
            }
            Int32 particyRes = 0;
            if (ParticyCode == 1)
            {
                particyRes = 100000;
            }
            return resultType + resultBase + interestRes + particyRes;
        }
        private class ParticySocialTargetComparator : IComparer<ParticySocialTarget>
        {
            public ParticySocialTargetComparator()
            {
            }

            public int Compare(ParticySocialTarget x, ParticySocialTarget y)
            {
                Int32 xIncomeScore = x.IncomeScore();
                Int32 yIncomeScore = y.IncomeScore();

                if (xIncomeScore.CompareTo(yIncomeScore) == 0)
                {
                    return x.ContractCode.CompareTo(y.ContractCode);
                }
                return yIncomeScore.CompareTo(xIncomeScore);
            }
        }
        public static IComparer<ParticySocialTarget> ResultComparator()
        {
            return new ParticySocialTargetComparator();
        }
    }
    public record ParticySocialResult(Int16 ContractCode, WorkTaxingTerms SubjectType, Int16 InterestCode, WorkSocialTerms SubjectTerm, Int16 ParticyCode, Int32 TargetsBase, Int32 ResultsBase);
}
