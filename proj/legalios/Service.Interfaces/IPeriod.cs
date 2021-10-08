using System;

namespace HraveMzdy.Legalios.Service.Interfaces
{
    public interface IPeriod : ICloneable
    {
        Int32 Code { get; }
        Int16 Year { get; }
        Int16 Month { get; }
    }
}
