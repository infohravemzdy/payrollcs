using System;

namespace HraveMzdy.Procezor.Payrolex.Registry.Operations
{
    public static class OperationsTaxing
    {
        public static decimal DecTaxRoundUp(decimal valueDec)
        {
            return RoundingDec.RoundUp(valueDec);
        }

        public static Int32 IntTaxRoundUp(decimal valueDec)
        {
            return RoundingInt.RoundUp(valueDec);
        }

        public static decimal DecTaxRoundNearUp(decimal valueDec, Int32 nearest = 100)
        {
            return RoundingDec.NearRoundUp(valueDec, nearest);
        }
        public static Int32 IntTaxRoundNearUp(decimal valueDec, Int32 nearest = 100)
        {
            return RoundingInt.NearRoundUp(valueDec, nearest);
        }
        public static decimal DecTaxRoundDown(decimal valueDec)
        {
            return RoundingDec.RoundDown(valueDec);
        }
        public static Int32 IntTaxRoundDown(decimal valueDec)
        {
            return RoundingInt.RoundDown(valueDec);
        }
        public static decimal DecTaxRoundNearDown(decimal valueDec, Int32 nearest = 100)
        {
            return RoundingDec.NearRoundDown(valueDec, nearest);
        }
        public static Int32 IntTaxRoundNearDown(decimal valueDec, Int32 nearest = 100)
        {
            return RoundingInt.NearRoundDown(valueDec, nearest);
        }
    }
}
