using System;
using HraveMzdy.Legalios.Service.Interfaces;

namespace HraveMzdy.Legalios.Service.Types
{
    public class Period : IPeriod
    {
        public static readonly Int32 ZeroCode = 0;

        public static readonly Period Zero = New();
        public static Period New() => new(ZeroCode);

        public Period(int code)
        {
            this.Code = code;
        }
        public Period(int year, int month)
        {
            this.Code = (year * 100 + month);
        }

        public Int32 Code { get; }

        public Int16 Year { get { return (Int16)(Code / 100); } }

        public Int16 Month { get { return (Int16)(Code % 100); } }

        public object Clone()
        {
            IPeriod clone = new Period(this.Code);
            return clone;
        }

    }
}
