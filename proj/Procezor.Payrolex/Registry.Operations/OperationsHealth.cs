using System;

namespace HraveMzdy.Procezor.Payrolex.Registry.Operations
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
    }
}
