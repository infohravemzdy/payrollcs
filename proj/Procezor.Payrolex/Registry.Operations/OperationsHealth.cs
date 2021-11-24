using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procezor.Payrolex.Registry.Operations
{
    public static class OperationsHealth
    {
        public static decimal DecInsuranceRoundUp(decimal valueDec)
        {
            return RoundingDec.RoundUp(valueDec);
        }


        public static Int32 IntInsuranceRoundUp(decimal valueDec)
        {
            return RoundingInt.RoundUp(valueDec);
        }

        public static decimal DecTaxRoundUp(decimal valueDec)
        {
            return RoundingDec.RoundUp(valueDec);
        }

        public static Int32 IntTaxRoundUp(decimal valueDec)
        {
            return RoundingInt.RoundUp(valueDec);
        }


        public static decimal DecTaxRoundDown(decimal valueDec)
        {
            return RoundingDec.RoundDown(valueDec);
        }


        public static Int32 IntTaxRoundDown(decimal valueDec)
        {
            return RoundingInt.RoundDown(valueDec);
        }
    }
}
