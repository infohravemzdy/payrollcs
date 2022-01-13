using System;
using System.Collections.Generic;
using System.Linq;
using HraveMzdy.Legalios.Service.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Props
{
    public class PropsBase : IProps
    {
        protected static readonly decimal INT_ROUNDING_CONST = 0.5m;

        public const Int16 VERSION_ZERO = 0;
        public PropsBase(Int16 version)
        {
            this.Version = new VersionId(version);
        }
        public PropsBase(VersionId version)
        {
            this.Version = new VersionId(version.Value);
        }
        public VersionId Version { get; }

        public bool IsValid() { return Version.Value != VERSION_ZERO; }

        public Int32 RoundToInt(decimal valueDec)
        {
            decimal roundRet = decimal.Floor(Math.Abs(valueDec) + INT_ROUNDING_CONST);

            return decimal.ToInt32(valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
        }
        public Int32 RoundUp(decimal valueDec)
        {
            decimal roundRet = decimal.Ceiling(Math.Abs(valueDec));

            return decimal.ToInt32(valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
        }

        public Int32 RoundDown(decimal valueDec)
        {
            decimal roundRet = decimal.Floor(Math.Abs(valueDec));

            return decimal.ToInt32(valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
        }
        public Int32 RoundNorm(decimal valueDec)
        {
            // decimal roundRet = decimal.Round(Math.Abs(valueDec));
            decimal roundRet = decimal.Truncate(Math.Abs(valueDec + INT_ROUNDING_CONST));

            return decimal.ToInt32(valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
        }

        public Int32 NearRoundUp(decimal valueDec, Int32 nearest = 100)
        {
            decimal dividRet = OperationsDec.Divide(valueDec, nearest);

            decimal multiRet = OperationsDec.Multiply(RoundUp(dividRet), nearest);

            return RoundToInt(multiRet);
        }

        public Int32 NearRoundDown(decimal valueDec, Int32 nearest = 100)
        {
            decimal dividRet = OperationsDec.Divide(valueDec, nearest);

            decimal multiRet = OperationsDec.Multiply(RoundDown(dividRet), nearest);

            return RoundToInt(multiRet);
        }
        public Int32 RoundUp50(decimal valueDec)
        {
            decimal dividRet = OperationsDec.Divide(DecRoundUp(OperationsDec.Multiply(valueDec, 2m)), 2m);
            return RoundToInt(dividRet);
        }
        public Int32 RoundUp25(decimal valueDec)
        {
            decimal dividRet = OperationsDec.Divide(DecRoundUp(OperationsDec.Multiply(valueDec, 4m)), 4m);
            return RoundToInt(dividRet);
        }

        public decimal DecRoundUp(decimal valueDec)
        {
            decimal roundRet = decimal.Ceiling(Math.Abs(valueDec));

            return (valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
        }

        public decimal DecRoundDown(decimal valueDec)
        {
            decimal roundRet = decimal.Floor(Math.Abs(valueDec));

            return (valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
        }
        public decimal DecRoundNorm(decimal valueDec)
        {
            decimal roundRet = decimal.Round(Math.Abs(valueDec));

            return (valueDec < 0m ? decimal.Negate(roundRet) : roundRet);
        }

        public decimal DecNearRoundUp(decimal valueDec, Int32 nearest = 100)
        {
            decimal dividRet = OperationsDec.Divide(valueDec, nearest);

            decimal multiRet = OperationsDec.Multiply(DecRoundUp(dividRet), nearest);

            return multiRet;
        }


        public decimal DecNearRoundDown(decimal valueDec, Int32 nearest = 100)
        {
            decimal dividRet = OperationsDec.Divide(valueDec, nearest);

            decimal multiRet = OperationsDec.Multiply(DecRoundDown(dividRet), nearest);

            return multiRet;
        }
        public decimal DecRoundUp50(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundUp(OperationsDec.Multiply(valueDec, 2m)), 2m);
        }
        public decimal DecRoundUp25(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundUp(OperationsDec.Multiply(valueDec, 4m)), 4m);
        }
        public decimal DecRoundUp01(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundUp(OperationsDec.Multiply(valueDec, 100m)), 100m);
        }
        public decimal DecRoundDown50(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundDown(OperationsDec.Multiply(valueDec, 2m)), 2m);
        }
        public decimal DecRoundDown25(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundDown(OperationsDec.Multiply(valueDec, 4m)), 4m);
        }
        public decimal DecRoundDown01(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundDown(OperationsDec.Multiply(valueDec, 100m)), 100m);
        }
        public decimal DecRoundNorm50(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundNorm(OperationsDec.Multiply(valueDec, 2m)), 2m);
        }
        public decimal DecRoundNorm25(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundNorm(OperationsDec.Multiply(valueDec, 4m)), 4m);
        }
        public decimal DecRoundNorm01(decimal valueDec)
        {
            return OperationsDec.Divide(DecRoundNorm(OperationsDec.Multiply(valueDec, 100m)), 100m);
        }

        public Tuple<Int32, Int32, T[]> MaximResultCut<T>(IEnumerable<T> incomeList, Int32 annuityBasis, Int32 annualyMaxim)
            where T : IParticyResult
        {
            Int32 annualsBasis = Math.Max(0, annualyMaxim - annuityBasis);
            var resultInit = new Tuple<Int32, Int32, T[]>(
                annualyMaxim, annualsBasis, Array.Empty<T>());

            var resultList = incomeList.Aggregate(resultInit,
                (agr, x) => {
                    Int32 cutAnnualsBasis = 0;
                    Int32 rawAnnualsBasis = x.ResultBasis;
                    Int32 remAnnualsBasis = agr.Item2;

                    if (x.ParticyCode != 0)
                    {
                        cutAnnualsBasis = rawAnnualsBasis;
                        if (agr.Item1 > 0)
                        {
                            var ovrAnnualsBasis = Math.Max(0, rawAnnualsBasis - agr.Item2);
                            cutAnnualsBasis = (rawAnnualsBasis - ovrAnnualsBasis);
                        }
                        remAnnualsBasis = Math.Max(0, (agr.Item2 - cutAnnualsBasis));
                    }

                    x.SetResultValue(Math.Max(0, cutAnnualsBasis));
                    return new Tuple<Int32, Int32, T[]>(
                        agr.Item1, remAnnualsBasis, agr.Item3.Concat(new T[] { x }).ToArray());
                });

            return resultList;
        }
    }
}
