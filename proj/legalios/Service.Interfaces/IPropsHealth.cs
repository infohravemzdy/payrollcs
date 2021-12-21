using System;
using HraveMzdy.Legalios.Interfaces;
using HraveMzdy.Legalios.Service.Types;

namespace HraveMzdy.Legalios.Service.Interfaces
{
    public interface IPropsHealth : IProps
    {
        Int32 MinMonthlyBasis { get; }
        Int32 MaxAnnualsBasis { get; }
        Int32 LimMonthlyState { get; }
        Int32 LimMonthlyDis50 { get; }
        decimal FactorCompound { get; }
        decimal FactorEmployee { get; }
        Int32 MarginIncomeEmp { get; }
        Int32 MarginIncomeAgr { get; }
        bool ValueEquals(IPropsHealth other);
        bool HasParticy(WorkHealthTerms term, Int32 incomeTerm, Int32 incomeSpec);
    }
}
