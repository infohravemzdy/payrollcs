using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HraveMzdy.Procezor.Registry.Constants;

namespace HraveMzdy.Procezor.Optimula.Registry.Constants
{
    public enum OptimulaConceptConst : Int32
    {
        CONCEPT_CONTRACT_TIME_PLAN,
        CONCEPT_CONTRACT_TIME_WORK,
        CONCEPT_PAYMENT_BASIS,
        CONCEPT_OPTIMUS_BASIS,
        CONCEPT_PAYMENT_FIXED,
        CONCEPT_OPTIMUS_FIXED,
        CONCEPT_PAYMENT_HOURS,
        CONCEPT_ALLOWCE_HOURS,
        CONCEPT_AGRWORK_HOURS, 
    }
    public static class ServiceConceptExtensions
    {
        public static string GetSymbol(this OptimulaConceptConst article)
        {
            return article.ToString();
        }
    }
    class ServiceConceptEnumUtils : EnumConstUtils<OptimulaConceptConst>
    {
    }
}
