using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HraveMzdy.Legalios.Service.Types
{
    public static class OperationsRound
    {
        private static readonly decimal INT_ROUNDING_CONST = 0.5m;

        public static Int32 RoundToInt(decimal valueDec)
        {
            decimal roundRet = decimal.Floor(Math.Abs(valueDec) + INT_ROUNDING_CONST);

            return decimal.ToInt32(valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
        }
        public static Int32 RoundUp(decimal valueDec)
        {
            decimal roundRet = decimal.Ceiling(Math.Abs(valueDec));

            return decimal.ToInt32(valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
        }

        public static Int32 RoundDown(decimal valueDec)
        {
            decimal roundRet = decimal.Floor(Math.Abs(valueDec));

            return decimal.ToInt32(valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
        }
        public static Int32 RoundNorm(decimal valueDec)
        {
            // decimal roundRet = decimal.Round(Math.Abs(valueDec));
            decimal roundRet = decimal.Truncate(Math.Abs(valueDec + INT_ROUNDING_CONST));

            return decimal.ToInt32(valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
        }

        public static Int32 NearRoundUp(decimal valueDec, Int32 nearest = 100)
        {
            decimal dividRet = OperationsDec.Divide(valueDec, nearest);

            decimal multiRet = OperationsDec.Multiply(RoundUp(dividRet), nearest);

            return RoundToInt(multiRet);
        }

        public static Int32 NearRoundDown(decimal valueDec, Int32 nearest = 100)
        {
            decimal dividRet = OperationsDec.Divide(valueDec, nearest);

            decimal multiRet = OperationsDec.Multiply(RoundDown(dividRet), nearest);

            return RoundToInt(multiRet);
        }
        public static Int32 RoundUp50(decimal valueDec)
        {
            decimal dividRet = OperationsDec.Divide(DecRoundUp(OperationsDec.Multiply(valueDec, 2m)), 2m);
            return RoundToInt(dividRet);
        }
        public static Int32 RoundUp25(decimal valueDec)
        {
            decimal dividRet = OperationsDec.Divide(DecRoundUp(OperationsDec.Multiply(valueDec, 4m)), 4m);
            return RoundToInt(dividRet);
        }

        public static decimal DecRoundUp(decimal valueDec)
        {
            decimal roundRet = decimal.Ceiling(Math.Abs(valueDec));

            return (valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
        }

        public static decimal DecRoundDown(decimal valueDec)
        {
            decimal roundRet = decimal.Floor(Math.Abs(valueDec));

            return (valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
        }
        public static decimal DecRoundNorm(decimal valueDec)
        {
            decimal roundRet = decimal.Truncate(Math.Abs(valueDec + INT_ROUNDING_CONST));

            return (valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
        }

        public static decimal DecNearRoundUp(decimal valueDec, Int32 nearest = 100)
        {
            decimal dividRet = OperationsDec.Divide(valueDec, nearest);

            decimal multiRet = OperationsDec.Multiply(DecRoundUp(dividRet), nearest);

            return multiRet;
        }


        public static decimal DecNearRoundDown(decimal valueDec, Int32 nearest = 100)
        {
            decimal dividRet = OperationsDec.Divide(valueDec, nearest);

            decimal multiRet = OperationsDec.Multiply(DecRoundDown(dividRet), nearest);

            return multiRet;
        }
        public static decimal DecRoundUp50(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundUp(OperationsDec.Multiply(valueDec, 2m)), 2m);
        }
        public static decimal DecRoundUp25(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundUp(OperationsDec.Multiply(valueDec, 4m)), 4m);
        }
        public static decimal DecRoundUp01(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundUp(OperationsDec.Multiply(valueDec, 100m)), 100m);
        }
        public static decimal DecRoundDown50(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundDown(OperationsDec.Multiply(valueDec, 2m)), 2m);
        }
        public static decimal DecRoundDown25(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundDown(OperationsDec.Multiply(valueDec, 4m)), 4m);
        }
        public static decimal DecRoundDown01(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundDown(OperationsDec.Multiply(valueDec, 100m)), 100m);
        }
        public static decimal DecRoundNorm50(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundNorm(OperationsDec.Multiply(valueDec, 2m)), 2m);
        }
        public static decimal DecRoundNorm25(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundNorm(OperationsDec.Multiply(valueDec, 4m)), 4m);
        }
        public static decimal DecRoundNorm01(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundNorm(OperationsDec.Multiply(valueDec, 100m)), 100m);
        }

    }
}
