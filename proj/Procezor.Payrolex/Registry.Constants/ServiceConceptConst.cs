using HraveMzdy.Procezor.Registry.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procezor.Payrolex.Registry.Constants
{
    public enum ServiceConceptConst : Int32
    {
        CONCEPT_CONTRACT_TERM,
        CONCEPT_POSITION_TERM,
        CONCEPT_POSITION_WORK_PLAN,
        CONCEPT_POSITION_TIME_PLAN,
        CONCEPT_POSITION_TIME_WORK,
        CONCEPT_POSITION_TIME_ABSC,
        CONCEPT_CONTRACT_TIME_PLAN,
        CONCEPT_CONTRACT_TIME_WORK,
        CONCEPT_CONTRACT_TIME_ABSC,
        CONCEPT_PAYMENT_BASIS,
        CONCEPT_PAYMENT_FIXED,
        CONCEPT_INCOME_GROSS,
        CONCEPT_INCOME_NETTO,
    }
    public static class ServiceConceptExtensions
    {
        public static string GetSymbol(this ServiceConceptConst article)
        {
            return article.ToString();
        }
    }
    class ServiceConceptEnumUtils : EnumConstUtils<ServiceConceptConst>
    {
    }
}
